/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200129
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DataflowService.Requests;
using Oci.DataflowService.Responses;
using Oci.DataflowService.Models;
using Oci.Common.Model;

namespace Oci.DataflowService.Cmdlets
{
    [Cmdlet("Update", "OCIDataflowRun")]
    [OutputType(new System.Type[] { typeof(Oci.DataflowService.Models.Run), typeof(Oci.DataflowService.Responses.UpdateRunResponse) })]
    public class UpdateOCIDataflowRun : OCIDataFlowCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details for updating a run.")]
        public UpdateRunDetails UpdateRunDetails { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique ID for the run")]
        public string RunId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If provided, the returned request ID will include this value. Otherwise, a random request ID will be generated by the service.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateRunRequest request;

            try
            {
                request = new UpdateRunRequest
                {
                    UpdateRunDetails = UpdateRunDetails,
                    RunId = RunId,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.UpdateRun(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Run);
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

        private UpdateRunResponse response;
    }
}
