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
    [Cmdlet("Get", "OCIDatabaseCloudExadataInfrastructureUnallocatedResources")]
    [OutputType(new System.Type[] { typeof(Oci.DatabaseService.Models.CloudExadataInfrastructureUnallocatedResources), typeof(Oci.DatabaseService.Responses.GetCloudExadataInfrastructureUnallocatedResourcesResponse) })]
    public class GetOCIDatabaseCloudExadataInfrastructureUnallocatedResources : OCIDatabaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The cloud Exadata infrastructure [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm).")]
        public string CloudExadataInfrastructureId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The list of [OCIDs](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the Db servers.")]
        public System.Collections.Generic.List<string> DbServers { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetCloudExadataInfrastructureUnallocatedResourcesRequest request;

            try
            {
                request = new GetCloudExadataInfrastructureUnallocatedResourcesRequest
                {
                    CloudExadataInfrastructureId = CloudExadataInfrastructureId,
                    OpcRequestId = OpcRequestId,
                    DbServers = DbServers
                };

                response = client.GetCloudExadataInfrastructureUnallocatedResources(request).GetAwaiter().GetResult();
                WriteOutput(response, response.CloudExadataInfrastructureUnallocatedResources);
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

        private GetCloudExadataInfrastructureUnallocatedResourcesResponse response;
    }
}
