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
    [Cmdlet("New", "OCIDataintegrationConnection")]
    [OutputType(new System.Type[] { typeof(Oci.DataintegrationService.Models.Connection), typeof(Oci.DataintegrationService.Responses.CreateConnectionResponse) })]
    public class NewOCIDataintegrationConnection : OCIDataIntegrationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The workspace ID.")]
        public string WorkspaceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information needed to create a connection. This parameter also accepts subtypes <Oci.DataintegrationService.Models.CreateConnectionFromMySQL>, <Oci.DataintegrationService.Models.CreateConnectionFromAmazonS3>, <Oci.DataintegrationService.Models.CreateConnectionFromLakehouse>, <Oci.DataintegrationService.Models.CreateConnectionFromJdbc>, <Oci.DataintegrationService.Models.CreateConnectionFromBICC>, <Oci.DataintegrationService.Models.CreateConnectionFromAtp>, <Oci.DataintegrationService.Models.CreateConnectionFromBIP>, <Oci.DataintegrationService.Models.CreateConnectionFromRestBasicAuth>, <Oci.DataintegrationService.Models.CreateConnectionFromAdwc>, <Oci.DataintegrationService.Models.CreateConnectionFromRestNoAuth>, <Oci.DataintegrationService.Models.CreateConnectionFromOracle>, <Oci.DataintegrationService.Models.CreateConnectionFromObjectStorage> of type <Oci.DataintegrationService.Models.CreateConnectionDetails>.")]
        public CreateConnectionDetails CreateConnectionDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again.")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateConnectionRequest request;

            try
            {
                request = new CreateConnectionRequest
                {
                    WorkspaceId = WorkspaceId,
                    CreateConnectionDetails = CreateConnectionDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.CreateConnection(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Connection);
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

        private CreateConnectionResponse response;
    }
}
