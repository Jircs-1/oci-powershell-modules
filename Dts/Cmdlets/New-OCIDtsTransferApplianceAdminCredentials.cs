/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 1.0.015
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
    [Cmdlet("New", "OCIDtsTransferApplianceAdminCredentials")]
    [OutputType(new System.Type[] { typeof(Oci.DtsService.Models.TransferApplianceCertificate), typeof(Oci.DtsService.Responses.CreateTransferApplianceAdminCredentialsResponse) })]
    public class NewOCIDtsTransferApplianceAdminCredentials : OCITransferApplianceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"ID of the Transfer Job")]
        public string Id { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Label of the Transfer Appliance")]
        public string TransferApplianceLabel { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public TransferAppliancePublicKey AdminPublicKey { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateTransferApplianceAdminCredentialsRequest request;

            try
            {
                request = new CreateTransferApplianceAdminCredentialsRequest
                {
                    Id = Id,
                    TransferApplianceLabel = TransferApplianceLabel,
                    AdminPublicKey = AdminPublicKey
                };

                response = client.CreateTransferApplianceAdminCredentials(request).GetAwaiter().GetResult();
                WriteOutput(response, response.TransferApplianceCertificate);
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

        private CreateTransferApplianceAdminCredentialsResponse response;
    }
}
