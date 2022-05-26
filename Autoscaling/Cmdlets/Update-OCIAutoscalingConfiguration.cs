/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181001
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.AutoscalingService.Requests;
using Oci.AutoscalingService.Responses;
using Oci.AutoscalingService.Models;
using Oci.Common.Model;

namespace Oci.AutoscalingService.Cmdlets
{
    [Cmdlet("Update", "OCIAutoscalingConfiguration")]
    [OutputType(new System.Type[] { typeof(Oci.AutoscalingService.Models.AutoScalingConfiguration), typeof(Oci.AutoscalingService.Responses.UpdateAutoScalingConfigurationResponse) })]
    public class UpdateOCIAutoscalingConfiguration : OCIAutoScalingCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the autoscaling configuration.")]
        public string AutoScalingConfigurationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Update details for an autoscaling configuration.")]
        public UpdateAutoScalingConfigurationDetails UpdateAutoScalingConfigurationDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource.  The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (for example, if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateAutoScalingConfigurationRequest request;

            try
            {
                request = new UpdateAutoScalingConfigurationRequest
                {
                    AutoScalingConfigurationId = AutoScalingConfigurationId,
                    UpdateAutoScalingConfigurationDetails = UpdateAutoScalingConfigurationDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.UpdateAutoScalingConfiguration(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AutoScalingConfiguration);
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

        private UpdateAutoScalingConfigurationResponse response;
    }
}
