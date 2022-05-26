/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
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
    [Cmdlet("Get", "OCIApmsyntheticsScript")]
    [OutputType(new System.Type[] { typeof(Oci.ApmsyntheticsService.Models.Script), typeof(Oci.ApmsyntheticsService.Responses.GetScriptResponse) })]
    public class GetOCIApmsyntheticsScript : OCIApmSyntheticCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The APM domain ID the request is intended for.")]
        public string ApmDomainId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the script.")]
        public string ScriptId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetScriptRequest request;

            try
            {
                request = new GetScriptRequest
                {
                    ApmDomainId = ApmDomainId,
                    ScriptId = ScriptId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetScript(request).GetAwaiter().GetResult();
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

        private GetScriptResponse response;
    }
}
