/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CoreService.Requests;
using Oci.CoreService.Responses;
using Oci.CoreService.Models;
using Oci.Common.Model;

namespace Oci.CoreService.Cmdlets
{
    [Cmdlet("Invoke", "OCIComputeInstanceAction")]
    [OutputType(new System.Type[] { typeof(Oci.CoreService.Models.Instance), typeof(Oci.CoreService.Responses.InstanceActionResponse) })]
    public class InvokeOCIComputeInstanceAction : OCIComputeCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the instance.")]
        public string InstanceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The action to perform on the instance.")]
        public string Action { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (for example, if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Instance Power Action details. This parameter also accepts subtypes <Oci.CoreService.Models.ResetActionDetails>, <Oci.CoreService.Models.RebootMigrateActionDetails>, <Oci.CoreService.Models.SoftResetActionDetails> of type <Oci.CoreService.Models.InstancePowerActionDetails>.")]
        public InstancePowerActionDetails InstancePowerActionDetails { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            InstanceActionRequest request;

            try
            {
                request = new InstanceActionRequest
                {
                    InstanceId = InstanceId,
                    Action = Action,
                    OpcRetryToken = OpcRetryToken,
                    IfMatch = IfMatch,
                    InstancePowerActionDetails = InstancePowerActionDetails
                };

                response = client.InstanceAction(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Instance);
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

        private InstanceActionResponse response;
    }
}
