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
    [Cmdlet("Remove", "OCIUsageapiCustomTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.UsageapiService.Responses.DeleteCustomTableResponse) })]
    public class RemoveOCIUsageapiCustomTable : OCIUsageapiCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The custom table unique OCID.")]
        public string CustomTableId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted, only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Ignore confirmation and force the Cmdlet to complete action.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmDelete("OCIUsageapiCustomTable", "Remove"))
            {
               return;
            }

            DeleteCustomTableRequest request;

            try
            {
                request = new DeleteCustomTableRequest
                {
                    CustomTableId = CustomTableId,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.DeleteCustomTable(request).GetAwaiter().GetResult();
                WriteOutput(response);
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

        private DeleteCustomTableResponse response;
    }
}
