/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OpsiService.Requests;
using Oci.OpsiService.Responses;
using Oci.OpsiService.Models;
using Oci.Common.Model;

namespace Oci.OpsiService.Cmdlets
{
    [Cmdlet("New", "OCIOpsiOperationsInsightsWarehouse")]
    [OutputType(new System.Type[] { typeof(Oci.OpsiService.Models.OperationsInsightsWarehouse), typeof(Oci.OpsiService.Responses.CreateOperationsInsightsWarehouseResponse) })]
    public class NewOCIOpsiOperationsInsightsWarehouse : OCIOperationsInsightsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details using which an Operations Insights Warehouse resource will be created in Operations Insights.")]
        public CreateOperationsInsightsWarehouseDetails CreateOperationsInsightsWarehouseDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request that can be retried in case of a timeout or server error without risk of executing the same action again. Retry tokens expire after 24 hours.

*Note:* Retry tokens can be invalidated before the 24 hour time limit due to conflicting operations, such as a resource being deleted or purged from the system.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateOperationsInsightsWarehouseRequest request;

            try
            {
                request = new CreateOperationsInsightsWarehouseRequest
                {
                    CreateOperationsInsightsWarehouseDetails = CreateOperationsInsightsWarehouseDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateOperationsInsightsWarehouse(request).GetAwaiter().GetResult();
                WriteOutput(response, response.OperationsInsightsWarehouse);
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

        private CreateOperationsInsightsWarehouseResponse response;
    }
}
