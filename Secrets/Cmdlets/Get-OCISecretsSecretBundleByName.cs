/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190301
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.SecretsService.Requests;
using Oci.SecretsService.Responses;
using Oci.SecretsService.Models;
using Oci.Common.Model;

namespace Oci.SecretsService.Cmdlets
{
    [Cmdlet("Get", "OCISecretsSecretBundleByName")]
    [OutputType(new System.Type[] { typeof(Oci.SecretsService.Models.SecretBundle), typeof(Oci.SecretsService.Responses.GetSecretBundleByNameResponse) })]
    public class GetOCISecretsSecretBundleByName : OCISecretsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"A user-friendly name for the secret. Secret names are unique within a vault. Secret names are case-sensitive.")]
        public string SecretName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the vault that contains the secret.")]
        public string VaultId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The version number of the secret.")]
        public System.Nullable<long> VersionNumber { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the secret. (This might be referred to as the name of the secret version. Names are unique across the different versions of a secret.)")]
        public string SecretVersionName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The rotation state of the secret version.")]
        public System.Nullable<Oci.SecretsService.Requests.GetSecretBundleByNameRequest.StageEnum> Stage { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetSecretBundleByNameRequest request;

            try
            {
                request = new GetSecretBundleByNameRequest
                {
                    SecretName = SecretName,
                    VaultId = VaultId,
                    OpcRequestId = OpcRequestId,
                    VersionNumber = VersionNumber,
                    SecretVersionName = SecretVersionName,
                    Stage = Stage
                };

                response = client.GetSecretBundleByName(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SecretBundle);
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

        private GetSecretBundleByNameResponse response;
    }
}
