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
    [Cmdlet("New", "OCIDtsTransferApplianceEntitlement")]
    [OutputType(new System.Type[] { typeof(Oci.DtsService.Models.TransferApplianceEntitlement), typeof(Oci.DtsService.Responses.CreateTransferApplianceEntitlementResponse) })]
    public class NewOCIDtsTransferApplianceEntitlement : OCITransferApplianceEntitlementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Creates a Transfer Appliance Entitlement")]
        public CreateTransferApplianceEntitlementDetails CreateTransferApplianceEntitlementDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (e.g., if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateTransferApplianceEntitlementRequest request;

            try
            {
                request = new CreateTransferApplianceEntitlementRequest
                {
                    CreateTransferApplianceEntitlementDetails = CreateTransferApplianceEntitlementDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateTransferApplianceEntitlement(request).GetAwaiter().GetResult();
                WriteOutput(response, response.TransferApplianceEntitlement);
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

        private CreateTransferApplianceEntitlementResponse response;
    }
}
