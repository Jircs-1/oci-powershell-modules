/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OperatoraccesscontrolService.Requests;
using Oci.OperatoraccesscontrolService.Responses;
using Oci.OperatoraccesscontrolService.Models;
using Oci.Common.Model;

namespace Oci.OperatoraccesscontrolService.Cmdlets
{
    [Cmdlet("Remove", "OCIOperatoraccesscontrolOperatorControlAssignment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.OperatoraccesscontrolService.Responses.DeleteOperatorControlAssignmentResponse) })]
    public class RemoveOCIOperatoraccesscontrolOperatorControlAssignment : OCIOperatorControlAssignmentCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"unique OperatorControl identifier")]
        public string OperatorControlAssignmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"reason for detachment of OperatorAssignment.")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Ignore confirmation and force the Cmdlet to complete action.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmDelete("OCIOperatoraccesscontrolOperatorControlAssignment", "Remove"))
            {
               return;
            }

            DeleteOperatorControlAssignmentRequest request;

            try
            {
                request = new DeleteOperatorControlAssignmentRequest
                {
                    OperatorControlAssignmentId = OperatorControlAssignmentId,
                    Description = Description,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.DeleteOperatorControlAssignment(request).GetAwaiter().GetResult();
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

        private DeleteOperatorControlAssignmentResponse response;
    }
}
