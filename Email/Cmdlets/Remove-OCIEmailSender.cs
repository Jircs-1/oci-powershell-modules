/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20170907
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.EmailService.Requests;
using Oci.EmailService.Responses;
using Oci.EmailService.Models;
using Oci.Common.Model;

namespace Oci.EmailService.Cmdlets
{
    [Cmdlet("Remove", "OCIEmailSender", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.EmailService.Responses.DeleteSenderResponse) })]
    public class RemoveOCIEmailSender : OCIEmailCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique OCID of the sender.")]
        public string SenderId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Used for optimistic concurrency control. In the update or delete call for a resource, set the `if-match` parameter to the value of the etag from a previous get, create, or update response for that resource.  The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The request ID for tracing from the system")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Ignore confirmation and force the Cmdlet to complete action.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmDelete("OCIEmailSender", "Remove"))
            {
               return;
            }

            DeleteSenderRequest request;

            try
            {
                request = new DeleteSenderRequest
                {
                    SenderId = SenderId,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.DeleteSender(request).GetAwaiter().GetResult();
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

        private DeleteSenderResponse response;
    }
}
