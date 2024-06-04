/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20231130
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using System.Net.Http;
using Oci.GenerativeaiinferenceService.Requests;
using Oci.GenerativeaiinferenceService.Responses;
using Oci.GenerativeaiinferenceService.Models;
using Oci.Common.Model;

namespace Oci.GenerativeaiinferenceService.Cmdlets
{
    [Cmdlet("New", "OCIGenerativeaiinferenceText")]
    [OutputType(new System.Type[] { typeof(Oci.GenerativeaiinferenceService.Models.GenerateTextResult), typeof(Oci.GenerativeaiinferenceService.Responses.GenerateTextResponse) })]
    public class NewOCIGenerativeaiinferenceText : OCIGenerativeAiInferenceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details for generating the text response.")]
        public GenerateTextDetails GenerateTextDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before that, in case of conflicting operations. For example, if a resource is deleted and purged from the system, then a retry of the original creation request is rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The http completion option to use for this request. Use ResponseHeadersRead for streams; Default is ResponseContentRead")]
        public HttpCompletionOption HttpCompletionOption { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GenerateTextRequest request;

            try
            {
                request = new GenerateTextRequest
                {
                    GenerateTextDetails = GenerateTextDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.GenerateText(request, completionOption: HttpCompletionOption).GetAwaiter().GetResult();
                WriteOutput(response, response.GenerateTextResult);
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

        private GenerateTextResponse response;
    }
}
