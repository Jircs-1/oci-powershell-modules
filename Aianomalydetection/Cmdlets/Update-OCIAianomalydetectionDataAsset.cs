/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.AianomalydetectionService.Requests;
using Oci.AianomalydetectionService.Responses;
using Oci.AianomalydetectionService.Models;
using Oci.Common.Model;

namespace Oci.AianomalydetectionService.Cmdlets
{
    [Cmdlet("Update", "OCIAianomalydetectionDataAsset")]
    [OutputType(new System.Type[] { typeof(Oci.AianomalydetectionService.Models.DataAsset), typeof(Oci.AianomalydetectionService.Responses.UpdateDataAssetResponse) })]
    public class UpdateOCIAianomalydetectionDataAsset : OCIAnomalyDetectionCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the Data Asset.")]
        public string DataAssetId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information to be updated.")]
        public UpdateDataAssetDetails UpdateDataAssetDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateDataAssetRequest request;

            try
            {
                request = new UpdateDataAssetRequest
                {
                    DataAssetId = DataAssetId,
                    UpdateDataAssetDetails = UpdateDataAssetDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateDataAsset(request).GetAwaiter().GetResult();
                WriteOutput(response, response.DataAsset);
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

        private UpdateDataAssetResponse response;
    }
}
