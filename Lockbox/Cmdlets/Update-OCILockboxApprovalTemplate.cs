/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220126
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.LockboxService.Requests;
using Oci.LockboxService.Responses;
using Oci.LockboxService.Models;
using Oci.Common.Model;

namespace Oci.LockboxService.Cmdlets
{
    [Cmdlet("Update", "OCILockboxApprovalTemplate")]
    [OutputType(new System.Type[] { typeof(Oci.LockboxService.Models.ApprovalTemplate), typeof(Oci.LockboxService.Responses.UpdateApprovalTemplateResponse) })]
    public class UpdateOCILockboxApprovalTemplate : OCILockboxCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier (OCID) of the approval template.")]
        public string ApprovalTemplateId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information to be updated.")]
        public UpdateApprovalTemplateDetails UpdateApprovalTemplateDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateApprovalTemplateRequest request;

            try
            {
                request = new UpdateApprovalTemplateRequest
                {
                    ApprovalTemplateId = ApprovalTemplateId,
                    UpdateApprovalTemplateDetails = UpdateApprovalTemplateDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateApprovalTemplate(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ApprovalTemplate);
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

        private UpdateApprovalTemplateResponse response;
    }
}
