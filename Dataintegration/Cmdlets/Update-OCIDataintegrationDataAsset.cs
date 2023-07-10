/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200430
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DataintegrationService.Requests;
using Oci.DataintegrationService.Responses;
using Oci.DataintegrationService.Models;
using Oci.Common.Model;

namespace Oci.DataintegrationService.Cmdlets
{
    [Cmdlet("Update", "OCIDataintegrationDataAsset")]
    [OutputType(new System.Type[] { typeof(Oci.DataintegrationService.Models.DataAsset), typeof(Oci.DataintegrationService.Responses.UpdateDataAssetResponse) })]
    public class UpdateOCIDataintegrationDataAsset : OCIDataIntegrationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The workspace ID.")]
        public string WorkspaceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The data asset key.")]
        public string DataAssetKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information needed to update a data asset. This parameter also accepts subtypes <Oci.DataintegrationService.Models.UpdateDataAssetFromRest>, <Oci.DataintegrationService.Models.UpdateDataAssetFromMySqlHeatWave>, <Oci.DataintegrationService.Models.UpdateDataAssetFromOracleEbs>, <Oci.DataintegrationService.Models.UpdateDataAssetFromAdwc>, <Oci.DataintegrationService.Models.UpdateDataAssetFromHdfs>, <Oci.DataintegrationService.Models.UpdateDataAssetFromOraclePeopleSoft>, <Oci.DataintegrationService.Models.UpdateDataAssetFromObjectStorage>, <Oci.DataintegrationService.Models.UpdateDataAssetFromAmazonS3>, <Oci.DataintegrationService.Models.UpdateDataAssetFromMySQL>, <Oci.DataintegrationService.Models.UpdateDataAssetFromOracleSiebel>, <Oci.DataintegrationService.Models.UpdateDataAssetFromLake>, <Oci.DataintegrationService.Models.UpdateDataAssetFromAtp>, <Oci.DataintegrationService.Models.UpdateDataAssetFromJdbc>, <Oci.DataintegrationService.Models.UpdateDataAssetFromFusionApp>, <Oci.DataintegrationService.Models.UpdateDataAssetFromOracle> of type <Oci.DataintegrationService.Models.UpdateDataAssetDetails>.")]
        public UpdateDataAssetDetails UpdateDataAssetDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the `etag` from a previous GET or POST response for that resource. The resource will be updated or deleted only if the `etag` you provide matches the resource's current `etag` value. When 'if-match' is provided and its value does not exactly match the 'etag' of the resource on the server, the request fails with the 412 response code.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateDataAssetRequest request;

            try
            {
                request = new UpdateDataAssetRequest
                {
                    WorkspaceId = WorkspaceId,
                    DataAssetKey = DataAssetKey,
                    UpdateDataAssetDetails = UpdateDataAssetDetails,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
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
