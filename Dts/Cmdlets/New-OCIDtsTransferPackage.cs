/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 1.0.017
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DtsService.Requests;
using Oci.DtsService.Responses;
using Oci.DtsService.Models;
using Oci.Common.Model;

namespace Oci.DtsService.Cmdlets
{
    [Cmdlet("New", "OCIDtsTransferPackage")]
    [OutputType(new System.Type[] { typeof(Oci.DtsService.Models.TransferPackage), typeof(Oci.DtsService.Responses.CreateTransferPackageResponse) })]
    public class NewOCIDtsTransferPackage : OCITransferPackageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"ID of the Transfer Job")]
        public string Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (e.g., if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Creates a New Transfer Package")]
        public CreateTransferPackageDetails CreateTransferPackageDetails { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateTransferPackageRequest request;

            try
            {
                request = new CreateTransferPackageRequest
                {
                    Id = Id,
                    OpcRetryToken = OpcRetryToken,
                    CreateTransferPackageDetails = CreateTransferPackageDetails
                };

                response = client.CreateTransferPackage(request).GetAwaiter().GetResult();
                WriteOutput(response, response.TransferPackage);
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

        private CreateTransferPackageResponse response;
    }
}
