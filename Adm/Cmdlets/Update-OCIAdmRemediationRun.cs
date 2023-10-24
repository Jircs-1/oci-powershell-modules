/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220421
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.AdmService.Requests;
using Oci.AdmService.Responses;
using Oci.AdmService.Models;
using Oci.Common.Model;

namespace Oci.AdmService.Cmdlets
{
    [Cmdlet("Update", "OCIAdmRemediationRun")]
    [OutputType(new System.Type[] { typeof(Oci.AdmService.Models.RemediationRun), typeof(Oci.AdmService.Responses.UpdateRemediationRunResponse) })]
    public class UpdateOCIAdmRemediationRun : OCIApplicationDependencyManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Remediation Run identifier path parameter.")]
        public string RemediationRunId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details used to update a remediation run.")]
        public UpdateRemediationRunDetails UpdateRemediationRunDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateRemediationRunRequest request;

            try
            {
                request = new UpdateRemediationRunRequest
                {
                    RemediationRunId = RemediationRunId,
                    UpdateRemediationRunDetails = UpdateRemediationRunDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateRemediationRun(request).GetAwaiter().GetResult();
                WriteOutput(response, response.RemediationRun);
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

        private UpdateRemediationRunResponse response;
    }
}
