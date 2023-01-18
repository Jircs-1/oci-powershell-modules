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
    [Cmdlet("New", "OCIDataintegrationEntityShape")]
    [OutputType(new System.Type[] { typeof(Oci.DataintegrationService.Models.EntityShape), typeof(Oci.DataintegrationService.Responses.CreateEntityShapeResponse) })]
    public class NewOCIDataintegrationEntityShape : OCIDataIntegrationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The workspace ID.")]
        public string WorkspaceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The connection key.")]
        public string ConnectionKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The schema resource name used for retrieving schemas.")]
        public string SchemaResourceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details needed to create the data entity shape. This parameter also accepts subtypes <Oci.DataintegrationService.Models.CreateEntityShapeFromSQL>, <Oci.DataintegrationService.Models.CreateEntityShapeFromFile> of type <Oci.DataintegrationService.Models.CreateEntityShapeDetails>.")]
        public CreateEntityShapeDetails CreateEntityShapeDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the `etag` from a previous GET or POST response for that resource. The resource will be updated or deleted only if the `etag` you provide matches the resource's current `etag` value. When 'if-match' is provided and its value does not exactly match the 'etag' of the resource on the server, the request fails with the 412 response code.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateEntityShapeRequest request;

            try
            {
                request = new CreateEntityShapeRequest
                {
                    WorkspaceId = WorkspaceId,
                    ConnectionKey = ConnectionKey,
                    SchemaResourceName = SchemaResourceName,
                    CreateEntityShapeDetails = CreateEntityShapeDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken,
                    IfMatch = IfMatch
                };

                response = client.CreateEntityShape(request).GetAwaiter().GetResult();
                WriteOutput(response, response.EntityShape);
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

        private CreateEntityShapeResponse response;
    }
}
