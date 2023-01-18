/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20221001
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.AilanguageService.Requests;
using Oci.AilanguageService.Responses;
using Oci.AilanguageService.Models;
using Oci.Common.Model;

namespace Oci.AilanguageService.Cmdlets
{
    [Cmdlet("Invoke", "OCIAilanguageBatchDetectLanguageTextClassification")]
    [OutputType(new System.Type[] { typeof(Oci.AilanguageService.Models.BatchDetectLanguageTextClassificationResult), typeof(Oci.AilanguageService.Responses.BatchDetectLanguageTextClassificationResponse) })]
    public class InvokeOCIAilanguageBatchDetectLanguageTextClassification : OCIAIServiceLanguageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details to make text classification detect call.")]
        public BatchDetectLanguageTextClassificationDetails BatchDetectLanguageTextClassificationDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            BatchDetectLanguageTextClassificationRequest request;

            try
            {
                request = new BatchDetectLanguageTextClassificationRequest
                {
                    BatchDetectLanguageTextClassificationDetails = BatchDetectLanguageTextClassificationDetails,
                    OpcRequestId = OpcRequestId
                };

                response = client.BatchDetectLanguageTextClassification(request).GetAwaiter().GetResult();
                WriteOutput(response, response.BatchDetectLanguageTextClassificationResult);
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

        private BatchDetectLanguageTextClassificationResponse response;
    }
}
