/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 1.0.017
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
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
    [Cmdlet("Update", "OCIDtsTransferDevice")]
    [OutputType(new System.Type[] { typeof(Oci.DtsService.Models.TransferDevice), typeof(Oci.DtsService.Responses.UpdateTransferDeviceResponse) })]
    public class UpdateOCIDtsTransferDevice : OCITransferDeviceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"ID of the Transfer Job")]
        public string Id { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Label of the Transfer Device")]
        public string TransferDeviceLabel { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"fields to update")]
        public UpdateTransferDeviceDetails UpdateTransferDeviceDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The entity tag to match. Optional, if set, the update will be successful only if the object's tag matches the tag specified in the request.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateTransferDeviceRequest request;

            try
            {
                request = new UpdateTransferDeviceRequest
                {
                    Id = Id,
                    TransferDeviceLabel = TransferDeviceLabel,
                    UpdateTransferDeviceDetails = UpdateTransferDeviceDetails,
                    IfMatch = IfMatch
                };

                response = client.UpdateTransferDevice(request).GetAwaiter().GetResult();
                WriteOutput(response, response.TransferDevice);
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

        private UpdateTransferDeviceResponse response;
    }
}
