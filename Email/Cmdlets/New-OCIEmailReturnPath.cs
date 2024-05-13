/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20170907
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
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
    [Cmdlet("New", "OCIEmailReturnPath")]
    [OutputType(new System.Type[] { typeof(Oci.EmailService.Models.EmailReturnPath), typeof(Oci.EmailService.Responses.CreateEmailReturnPathResponse) })]
    public class NewOCIEmailReturnPath : OCIEmailCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The email return path to create.")]
        public CreateEmailReturnPathDetails CreateEmailReturnPathDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The request ID for tracing from the system")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateEmailReturnPathRequest request;

            try
            {
                request = new CreateEmailReturnPathRequest
                {
                    CreateEmailReturnPathDetails = CreateEmailReturnPathDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.CreateEmailReturnPath(request).GetAwaiter().GetResult();
                WriteOutput(response, response.EmailReturnPath);
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

        private CreateEmailReturnPathResponse response;
    }
}
