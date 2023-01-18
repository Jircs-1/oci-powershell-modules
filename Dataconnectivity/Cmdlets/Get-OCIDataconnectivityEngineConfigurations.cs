/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210217
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
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
    [Cmdlet("Get", "OCIDataconnectivityEngineConfigurations")]
    [OutputType(new System.Type[] { typeof(Oci.DataconnectivityService.Models.ConfigDetails), typeof(Oci.DataconnectivityService.Responses.GetEngineConfigurationsResponse) })]
    public class GetOCIDataconnectivityEngineConfigurations : OCIDataConnectivityManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The registry OCID.")]
        public string RegistryId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The connection key.")]
        public string ConnectionKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the runtime engine for the bulk read/write operation. Default is SPARK.")]
        public System.Nullable<Oci.DataconnectivityService.Requests.GetEngineConfigurationsRequest.EngineTypeQueryParamEnum> EngineTypeQueryParam { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetEngineConfigurationsRequest request;

            try
            {
                request = new GetEngineConfigurationsRequest
                {
                    RegistryId = RegistryId,
                    ConnectionKey = ConnectionKey,
                    EngineTypeQueryParam = EngineTypeQueryParam,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetEngineConfigurations(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ConfigDetails);
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

        private GetEngineConfigurationsResponse response;
    }
}
