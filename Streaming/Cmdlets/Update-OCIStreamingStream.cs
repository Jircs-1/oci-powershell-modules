/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20180418
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.StreamingService.Requests;
using Oci.StreamingService.Responses;
using Oci.StreamingService.Models;
using Oci.Common.Model;

namespace Oci.StreamingService.Cmdlets
{
    [Cmdlet("Update", "OCIStreamingStream")]
    [OutputType(new System.Type[] { typeof(Stream), typeof(Oci.StreamingService.Responses.UpdateStreamResponse) })]
    public class UpdateOCIStreamingStream : OCIStreamAdminCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the stream.")]
        public string StreamId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The stream is updated with the values provided.")]
        public UpdateStreamDetails UpdateStreamDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the if-match parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateStreamRequest request;

            try
            {
                request = new UpdateStreamRequest
                {
                    StreamId = StreamId,
                    UpdateStreamDetails = UpdateStreamDetails,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.UpdateStream(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Stream);
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

        private UpdateStreamResponse response;
    }
}
