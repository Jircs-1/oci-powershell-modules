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
using Oci.Common.Model;

namespace Oci.DataconnectivityService.Cmdlets
{
    [Cmdlet("New", "OCIDataconnectivityDeReferenceArtifact")]
    [OutputType(new System.Type[] { typeof(Oci.DataconnectivityService.Models.DeReferenceInfo), typeof(Oci.DataconnectivityService.Responses.CreateDeReferenceArtifactResponse) })]
    public class NewOCIDataconnectivityDeReferenceArtifact : OCIDataConnectivityManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The registry OCID.")]
        public string RegistryId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of a dcms artifact (DataAsset or Endpoint).")]
        public string DcmsArtifactId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information required to delete a dcms artifact reference.")]
        public CreateDeReferenceArtifactDetails CreateDeReferenceArtifactDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without the risk of executing that same action again.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the `etag` from a previous GET or POST response for that resource. The resource will be updated or deleted only if the `etag` you provide matches the resource's current `etag` value. When 'if-match' is provided and its value does not exactly match the 'etag' of the resource on the server, the request fails with the 412 response code.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateDeReferenceArtifactRequest request;

            try
            {
                request = new CreateDeReferenceArtifactRequest
                {
                    RegistryId = RegistryId,
                    DcmsArtifactId = DcmsArtifactId,
                    CreateDeReferenceArtifactDetails = CreateDeReferenceArtifactDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken,
                    IfMatch = IfMatch
                };

                response = client.CreateDeReferenceArtifact(request).GetAwaiter().GetResult();
                WriteOutput(response, response.DeReferenceInfo);
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

        private CreateDeReferenceArtifactResponse response;
    }
}
