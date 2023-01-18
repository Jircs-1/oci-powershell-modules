/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20180828
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.EmwarehouseService.Requests;
using Oci.EmwarehouseService.Responses;
using Oci.EmwarehouseService.Models;
using Oci.Common.Model;

namespace Oci.EmwarehouseService.Cmdlets
{
    [Cmdlet("Get", "OCIEmwarehouseResourceUsage")]
    [OutputType(new System.Type[] { typeof(Oci.EmwarehouseService.Models.ResourceUsage), typeof(Oci.EmwarehouseService.Responses.GetEmWarehouseResourceUsageResponse) })]
    public class GetOCIEmwarehouseResourceUsage : OCIEmWarehouseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"unique EmWarehouse identifier")]
        public string EmWarehouseId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetEmWarehouseResourceUsageRequest request;

            try
            {
                request = new GetEmWarehouseResourceUsageRequest
                {
                    EmWarehouseId = EmWarehouseId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetEmWarehouseResourceUsage(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ResourceUsage);
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

        private GetEmWarehouseResourceUsageResponse response;
    }
}
