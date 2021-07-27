/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200107
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.UsageapiService.Requests;
using Oci.UsageapiService.Responses;
using Oci.UsageapiService.Models;

namespace Oci.UsageapiService.Cmdlets
{
    [Cmdlet("Update", "OCIUsageapiCustomTable")]
    [OutputType(new System.Type[] { typeof(Oci.UsageapiService.Models.CustomTable), typeof(Oci.UsageapiService.Responses.UpdateCustomTableResponse) })]
    public class UpdateOCIUsageapiCustomTable : OCIUsageapiCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information to be updated.")]
        public UpdateCustomTableDetails UpdateCustomTableDetails { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The custom table unique OCID.")]
        public string CustomTableId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted, only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateCustomTableRequest request;

            try
            {
                request = new UpdateCustomTableRequest
                {
                    UpdateCustomTableDetails = UpdateCustomTableDetails,
                    CustomTableId = CustomTableId,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.UpdateCustomTable(request).GetAwaiter().GetResult();
                WriteOutput(response, response.CustomTable);
                FinishProcessing(response);
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

        private UpdateCustomTableResponse response;
    }
}
