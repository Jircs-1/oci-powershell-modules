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
    [Cmdlet("Move", "OCIDtsApplianceExportJobCompartment")]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.DtsService.Responses.ChangeApplianceExportJobCompartmentResponse) })]
    public class MoveOCIDtsApplianceExportJobCompartment : OCIApplianceExportJobCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"ID of the Appliance Export Job")]
        public string ApplianceExportJobId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"CompartmentId of the destination compartment")]
        public ChangeApplianceExportJobCompartmentDetails ChangeApplianceExportJobCompartmentDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The entity tag to match. Optional, if set, the update will be successful only if the object's tag matches the tag specified in the request.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (e.g., if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ChangeApplianceExportJobCompartmentRequest request;

            try
            {
                request = new ChangeApplianceExportJobCompartmentRequest
                {
                    ApplianceExportJobId = ApplianceExportJobId,
                    ChangeApplianceExportJobCompartmentDetails = ChangeApplianceExportJobCompartmentDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.ChangeApplianceExportJobCompartment(request).GetAwaiter().GetResult();
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

        private ChangeApplianceExportJobCompartmentResponse response;
    }
}
