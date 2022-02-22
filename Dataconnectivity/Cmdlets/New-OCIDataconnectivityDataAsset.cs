/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210217
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DataconnectivityService.Requests;
using Oci.DataconnectivityService.Responses;
using Oci.DataconnectivityService.Models;

namespace Oci.DataconnectivityService.Cmdlets
{
    [Cmdlet("New", "OCIDataconnectivityDataAsset")]
    [OutputType(new System.Type[] { typeof(Oci.DataconnectivityService.Models.DataAsset), typeof(Oci.DataconnectivityService.Responses.CreateDataAssetResponse) })]
    public class NewOCIDataconnectivityDataAsset : OCIDataConnectivityManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The registry Ocid.")]
        public string RegistryId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information needed to create a data asset.")]
        public CreateDataAssetDetails CreateDataAssetDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again.")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateDataAssetRequest request;

            try
            {
                request = new CreateDataAssetRequest
                {
                    RegistryId = RegistryId,
                    CreateDataAssetDetails = CreateDataAssetDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.CreateDataAsset(request).GetAwaiter().GetResult();
                WriteOutput(response, response.DataAsset);
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

        private CreateDataAssetResponse response;
    }
}
