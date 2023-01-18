/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ApmsyntheticsService.Requests;
using Oci.ApmsyntheticsService.Responses;
using Oci.ApmsyntheticsService.Models;
using Oci.Common.Model;

namespace Oci.ApmsyntheticsService.Cmdlets
{
    [Cmdlet("New", "OCIApmsyntheticsScript")]
    [OutputType(new System.Type[] { typeof(Oci.ApmsyntheticsService.Models.Script), typeof(Oci.ApmsyntheticsService.Responses.CreateScriptResponse) })]
    public class NewOCIApmsyntheticsScript : OCIApmSyntheticCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The APM domain ID the request is intended for.")]
        public string ApmDomainId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The configuration details for creating a script.")]
        public CreateScriptDetails CreateScriptDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateScriptRequest request;

            try
            {
                request = new CreateScriptRequest
                {
                    ApmDomainId = ApmDomainId,
                    CreateScriptDetails = CreateScriptDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateScript(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Script);
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

        private CreateScriptResponse response;
    }
}
