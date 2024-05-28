/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20231107
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CapacitymanagementService.Requests;
using Oci.CapacitymanagementService.Responses;
using Oci.CapacitymanagementService.Models;
using Oci.Common.Model;

namespace Oci.CapacitymanagementService.Cmdlets
{
    [Cmdlet("Invoke", "OCICapacitymanagementPatchInternalOccCapacityRequest")]
    [OutputType(new System.Type[] { typeof(Oci.CapacitymanagementService.Models.OccCapacityRequest), typeof(Oci.CapacitymanagementService.Responses.PatchInternalOccCapacityRequestResponse) })]
    public class InvokeOCICapacitymanagementPatchInternalOccCapacityRequest : OCICapacityManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request to update the details of the capacity request.")]
        public PatchOccCapacityRequestDetails PatchOccCapacityRequestDetails { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the capacity request.")]
        public string OccCapacityRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing. The only valid characters for request IDs are letters, numbers, underscore, and dash.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            PatchInternalOccCapacityRequestRequest request;

            try
            {
                request = new PatchInternalOccCapacityRequestRequest
                {
                    PatchOccCapacityRequestDetails = PatchOccCapacityRequestDetails,
                    OccCapacityRequestId = OccCapacityRequestId,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.PatchInternalOccCapacityRequest(request).GetAwaiter().GetResult();
                WriteOutput(response, response.OccCapacityRequest);
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

        private PatchInternalOccCapacityRequestResponse response;
    }
}
