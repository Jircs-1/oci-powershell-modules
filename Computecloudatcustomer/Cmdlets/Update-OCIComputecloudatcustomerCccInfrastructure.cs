/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20221208
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ComputecloudatcustomerService.Requests;
using Oci.ComputecloudatcustomerService.Responses;
using Oci.ComputecloudatcustomerService.Models;
using Oci.Common.Model;

namespace Oci.ComputecloudatcustomerService.Cmdlets
{
    [Cmdlet("Update", "OCIComputecloudatcustomerCccInfrastructure")]
    [OutputType(new System.Type[] { typeof(Oci.ComputecloudatcustomerService.Models.CccInfrastructure), typeof(Oci.ComputecloudatcustomerService.Responses.UpdateCccInfrastructureResponse) })]
    public class UpdateOCIComputecloudatcustomerCccInfrastructure : OCIComputeCloudAtCustomerCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"An [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) for a Compute Cloud@Customer Infrastructure.")]
        public string CccInfrastructureId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information to be updated.")]
        public UpdateCccInfrastructureDetails UpdateCccInfrastructureDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateCccInfrastructureRequest request;

            try
            {
                request = new UpdateCccInfrastructureRequest
                {
                    CccInfrastructureId = CccInfrastructureId,
                    UpdateCccInfrastructureDetails = UpdateCccInfrastructureDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateCccInfrastructure(request).GetAwaiter().GetResult();
                WriteOutput(response, response.CccInfrastructure);
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

        private UpdateCccInfrastructureResponse response;
    }
}
