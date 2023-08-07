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
    [Cmdlet("Get", "OCIAilanguageModelType")]
    [OutputType(new System.Type[] { typeof(Oci.AilanguageService.Models.ModelTypeInfo), typeof(Oci.AilanguageService.Responses.GetModelTypeResponse) })]
    public class GetOCIAilanguageModelType : OCIAIServiceLanguageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Results like version and model supported info by specifying model type")]
        public string ModelType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetModelTypeRequest request;

            try
            {
                request = new GetModelTypeRequest
                {
                    ModelType = ModelType,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetModelType(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ModelTypeInfo);
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

        private GetModelTypeResponse response;
    }
}
