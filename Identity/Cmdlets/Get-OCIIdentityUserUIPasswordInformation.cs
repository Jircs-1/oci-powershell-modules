/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.IdentityService.Requests;
using Oci.IdentityService.Responses;
using Oci.IdentityService.Models;
using Oci.Common.Model;

namespace Oci.IdentityService.Cmdlets
{
    [Cmdlet("Get", "OCIIdentityUserUIPasswordInformation")]
    [OutputType(new System.Type[] { typeof(Oci.IdentityService.Models.UIPasswordInformation), typeof(Oci.IdentityService.Responses.GetUserUIPasswordInformationResponse) })]
    public class GetOCIIdentityUserUIPasswordInformation : OCIIdentityCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the user.")]
        public string UserId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetUserUIPasswordInformationRequest request;

            try
            {
                request = new GetUserUIPasswordInformationRequest
                {
                    UserId = UserId
                };

                response = client.GetUserUIPasswordInformation(request).GetAwaiter().GetResult();
                WriteOutput(response, response.UIPasswordInformation);
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

        private GetUserUIPasswordInformationResponse response;
    }
}
