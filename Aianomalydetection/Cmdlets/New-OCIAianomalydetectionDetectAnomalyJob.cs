/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.AianomalydetectionService.Requests;
using Oci.AianomalydetectionService.Responses;
using Oci.AianomalydetectionService.Models;
using Oci.Common.Model;

namespace Oci.AianomalydetectionService.Cmdlets
{
    [Cmdlet("New", "OCIAianomalydetectionDetectAnomalyJob")]
    [OutputType(new System.Type[] { typeof(Oci.AianomalydetectionService.Models.DetectAnomalyJob), typeof(Oci.AianomalydetectionService.Responses.CreateDetectAnomalyJobResponse) })]
    public class NewOCIAianomalydetectionDetectAnomalyJob : OCIAnomalyDetectionCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The input is either:   - JSON object in the request. This object is defined, and the SDK generates the     object for it.   - Data embedded as Base64 string in format of either:     - CSV     - JSON     If this option is used, then you must provide the content of specified     CSV or JSON in Base64 encoded string. The Embedded JSON has to be     in the same format as the inline request JSON.")]
        public CreateDetectAnomalyJobDetails CreateDetectAnomalyJobDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateDetectAnomalyJobRequest request;

            try
            {
                request = new CreateDetectAnomalyJobRequest
                {
                    CreateDetectAnomalyJobDetails = CreateDetectAnomalyJobDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.CreateDetectAnomalyJob(request).GetAwaiter().GetResult();
                WriteOutput(response, response.DetectAnomalyJob);
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

        private CreateDetectAnomalyJobResponse response;
    }
}
