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
    [Cmdlet("New", "OCIStreamingConnectHarness")]
    [OutputType(new System.Type[] { typeof(Oci.StreamingService.Models.ConnectHarness), typeof(Oci.StreamingService.Responses.CreateConnectHarnessResponse) })]
    public class NewOCIStreamingConnectHarness : OCIStreamAdminCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The connect harness to create.")]
        public CreateConnectHarnessDetails CreateConnectHarnessDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (for example, if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateConnectHarnessRequest request;

            try
            {
                request = new CreateConnectHarnessRequest
                {
                    CreateConnectHarnessDetails = CreateConnectHarnessDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.CreateConnectHarness(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ConnectHarness);
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

        private CreateConnectHarnessResponse response;
    }
}
