/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ApmconfigService.Requests;
using Oci.ApmconfigService.Responses;
using Oci.ApmconfigService.Models;
using Oci.Common.Model;

namespace Oci.ApmconfigService.Cmdlets
{
    [Cmdlet("Confirm", "OCIApmconfigSpanFilterPattern")]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.ApmconfigService.Responses.ValidateSpanFilterPatternResponse) })]
    public class ConfirmOCIApmconfigSpanFilterPattern : OCIConfigCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The APM Domain ID the request is intended for.")]
        public string ApmDomainId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Span Filter pattern to validate.")]
        public ValidateSpanFilterPatternDetails ValidateSpanFilterPatternDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ValidateSpanFilterPatternRequest request;

            try
            {
                request = new ValidateSpanFilterPatternRequest
                {
                    ApmDomainId = ApmDomainId,
                    ValidateSpanFilterPatternDetails = ValidateSpanFilterPatternDetails,
                    OpcRequestId = OpcRequestId
                };

                response = client.ValidateSpanFilterPattern(request).GetAwaiter().GetResult();
                WriteOutput(response);
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

        private ValidateSpanFilterPatternResponse response;
    }
}
