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
    [Cmdlet("Remove", "OCIAianomalydetectionProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(new System.Type[] { typeof(Oci.PSModules.Common.Cmdlets.WorkRequest), typeof(Oci.AianomalydetectionService.Responses.DeleteProjectResponse) })]
    public class RemoveOCIAianomalydetectionProject : OCIAnomalyDetectionCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the Project.")]
        public string ProjectId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Ignore confirmation and force the Cmdlet to complete action.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmDelete("OCIAianomalydetectionProject", "Remove"))
            {
               return;
            }

            DeleteProjectRequest request;

            try
            {
                request = new DeleteProjectRequest
                {
                    ProjectId = ProjectId,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.DeleteProject(request).GetAwaiter().GetResult();
                WriteOutput(response, CreateWorkRequestObject(response.OpcWorkRequestId));
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

        private DeleteProjectResponse response;
    }
}
