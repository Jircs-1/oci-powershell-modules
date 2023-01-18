/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20180530
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ComputeinstanceagentService.Requests;
using Oci.ComputeinstanceagentService.Responses;
using Oci.ComputeinstanceagentService.Models;
using Oci.Common.Model;

namespace Oci.ComputeinstanceagentService.Cmdlets
{
    [Cmdlet("Get", "OCIComputeinstanceagentInstanceAgentCommand")]
    [OutputType(new System.Type[] { typeof(Oci.ComputeinstanceagentService.Models.InstanceAgentCommand), typeof(Oci.ComputeinstanceagentService.Responses.GetInstanceAgentCommandResponse) })]
    public class GetOCIComputeinstanceagentInstanceAgentCommand : OCIComputeInstanceAgentCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the command.")]
        public string InstanceAgentCommandId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetInstanceAgentCommandRequest request;

            try
            {
                request = new GetInstanceAgentCommandRequest
                {
                    InstanceAgentCommandId = InstanceAgentCommandId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetInstanceAgentCommand(request).GetAwaiter().GetResult();
                WriteOutput(response, response.InstanceAgentCommand);
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

        private GetInstanceAgentCommandResponse response;
    }
}
