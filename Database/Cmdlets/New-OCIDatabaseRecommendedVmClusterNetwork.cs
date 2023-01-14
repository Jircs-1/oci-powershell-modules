/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatabaseService.Requests;
using Oci.DatabaseService.Responses;
using Oci.DatabaseService.Models;
using Oci.Common.Model;

namespace Oci.DatabaseService.Cmdlets
{
    [Cmdlet("New", "OCIDatabaseRecommendedVmClusterNetwork")]
    [OutputType(new System.Type[] { typeof(Oci.DatabaseService.Models.VmClusterNetworkDetails), typeof(Oci.DatabaseService.Responses.GenerateRecommendedVmClusterNetworkResponse) })]
    public class NewOCIDatabaseRecommendedVmClusterNetwork : OCIDatabaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Exadata infrastructure [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm).")]
        public string ExadataInfrastructureId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request to generate a recommended Cloud@Customer VM cluster network configuration.")]
        public GenerateRecommendedNetworkDetails GenerateRecommendedNetworkDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (for example, if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GenerateRecommendedVmClusterNetworkRequest request;

            try
            {
                request = new GenerateRecommendedVmClusterNetworkRequest
                {
                    ExadataInfrastructureId = ExadataInfrastructureId,
                    GenerateRecommendedNetworkDetails = GenerateRecommendedNetworkDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.GenerateRecommendedVmClusterNetwork(request).GetAwaiter().GetResult();
                WriteOutput(response, response.VmClusterNetworkDetails);
                FinishProcessing(response);
            }
            catch (OciException ex)
            {
                TerminatingErrorDuringExecution(ex);
            }
            catch (Exception ex)
            {
                TerminatingErrorDuringExecution(ex);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            TerminatingErrorDuringExecution(new OperationCanceledException("Cmdlet execution interrupted"));
        }

        private GenerateRecommendedVmClusterNetworkResponse response;
    }
}
