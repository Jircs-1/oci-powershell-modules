/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20180608
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.VaultService.Requests;
using Oci.VaultService.Responses;
using Oci.VaultService.Models;
using Oci.Common.Model;

namespace Oci.VaultService.Cmdlets
{
    [Cmdlet("New", "OCIVaultSecret")]
    [OutputType(new System.Type[] { typeof(Oci.VaultService.Models.Secret), typeof(Oci.VaultService.Responses.CreateSecretResponse) })]
    public class NewOCIVaultSecret : OCIVaultsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request to create a new secret.")]
        public CreateSecretDetails CreateSecretDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If provided, the returned request ID will include this value. Otherwise, a random request ID will be generated by the service.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (e.g., if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateSecretRequest request;

            try
            {
                request = new CreateSecretRequest
                {
                    CreateSecretDetails = CreateSecretDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.CreateSecret(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Secret);
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

        private CreateSecretResponse response;
    }
}
