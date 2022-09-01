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
    [Cmdlet("Get", "OCIDataconnectivityOperation")]
    [OutputType(new System.Type[] { typeof(Oci.DataconnectivityService.Models.Operation), typeof(Oci.DataconnectivityService.Responses.GetOperationResponse) })]
    public class GetOCIDataconnectivityOperation : OCIDataConnectivityManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The registry OCID.")]
        public string RegistryId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The connection key.")]
        public string ConnectionKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The schema resource name used for retrieving schemas.")]
        public string SchemaResourceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The operation resource name used for retrieving the details of operation.")]
        public string OperationResourceName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Endpoint ID used for getDataAssetFullDetails.")]
        public string EndpointId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetOperationRequest request;

            try
            {
                request = new GetOperationRequest
                {
                    RegistryId = RegistryId,
                    ConnectionKey = ConnectionKey,
                    SchemaResourceName = SchemaResourceName,
                    OperationResourceName = OperationResourceName,
                    OpcRequestId = OpcRequestId,
                    EndpointId = EndpointId
                };

                response = client.GetOperation(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Operation);
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

        private GetOperationResponse response;
    }
}
