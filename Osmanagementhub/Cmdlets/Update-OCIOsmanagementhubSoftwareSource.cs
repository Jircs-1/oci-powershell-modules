/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220901
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OsmanagementhubService.Requests;
using Oci.OsmanagementhubService.Responses;
using Oci.OsmanagementhubService.Models;
using Oci.Common.Model;

namespace Oci.OsmanagementhubService.Cmdlets
{
    [Cmdlet("Update", "OCIOsmanagementhubSoftwareSource")]
    [OutputType(new System.Type[] { typeof(Oci.OsmanagementhubService.Models.SoftwareSource), typeof(Oci.OsmanagementhubService.Responses.UpdateSoftwareSourceResponse) })]
    public class UpdateOCIOsmanagementhubSoftwareSource : OCISoftwareSourceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The software source OCID.")]
        public string SoftwareSourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information to be updated. This parameter also accepts subtypes <Oci.OsmanagementhubService.Models.UpdateCustomSoftwareSourceDetails>, <Oci.OsmanagementhubService.Models.UpdateVendorSoftwareSourceDetails> of type <Oci.OsmanagementhubService.Models.UpdateSoftwareSourceDetails>.")]
        public UpdateSoftwareSourceDetails UpdateSoftwareSourceDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateSoftwareSourceRequest request;

            try
            {
                request = new UpdateSoftwareSourceRequest
                {
                    SoftwareSourceId = SoftwareSourceId,
                    UpdateSoftwareSourceDetails = UpdateSoftwareSourceDetails,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.UpdateSoftwareSource(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SoftwareSource);
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

        private UpdateSoftwareSourceResponse response;
    }
}
