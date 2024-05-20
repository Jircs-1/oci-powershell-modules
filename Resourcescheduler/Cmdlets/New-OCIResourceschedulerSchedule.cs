/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20240430
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ResourceschedulerService.Requests;
using Oci.ResourceschedulerService.Responses;
using Oci.ResourceschedulerService.Models;
using Oci.Common.Model;

namespace Oci.ResourceschedulerService.Cmdlets
{
    [Cmdlet("New", "OCIResourceschedulerSchedule")]
    [OutputType(new System.Type[] { typeof(Oci.ResourceschedulerService.Models.Schedule), typeof(Oci.ResourceschedulerService.Responses.CreateScheduleResponse) })]
    public class NewOCIResourceschedulerSchedule : OCIScheduleCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"This API shows the details of the new schedule")]
        public CreateScheduleDetails CreateScheduleDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This is a token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of running that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and removed from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This is a unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID. The only valid characters for request IDs are letters, numbers, underscore, and dash.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateScheduleRequest request;

            try
            {
                request = new CreateScheduleRequest
                {
                    CreateScheduleDetails = CreateScheduleDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateSchedule(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Schedule);
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

        private CreateScheduleResponse response;
    }
}
