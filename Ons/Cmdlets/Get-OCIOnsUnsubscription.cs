/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OnsService.Requests;
using Oci.OnsService.Responses;
using Oci.OnsService.Models;
using Oci.Common.Model;

namespace Oci.OnsService.Cmdlets
{
    [Cmdlet("Get", "OCIOnsUnsubscription")]
    [OutputType(new System.Type[] { typeof(string), typeof(Oci.OnsService.Responses.GetUnsubscriptionResponse) })]
    public class GetOCIOnsUnsubscription : OCINotificationDataPlaneCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the subscription to unsubscribe from.")]
        public string Id { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The subscription confirmation token.")]
        public string Token { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The protocol used for the subscription.

Allowed values:   * `CUSTOM_HTTPS`   * `EMAIL`   * `HTTPS` (deprecated; for PagerDuty endpoints, use `PAGERDUTY`)   * `ORACLE_FUNCTIONS`   * `PAGERDUTY`   * `SLACK`   * `SMS`

For information about subscription protocols, see [To create a subscription](https://docs.cloud.oracle.com/iaas/Content/Notification/Tasks/managingtopicsandsubscriptions.htm#createSub).")]
        public string Protocol { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetUnsubscriptionRequest request;

            try
            {
                request = new GetUnsubscriptionRequest
                {
                    Id = Id,
                    Token = Token,
                    Protocol = Protocol,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetUnsubscription(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Value);
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

        private GetUnsubscriptionResponse response;
    }
}
