/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200801
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.TenantmanagercontrolplaneService.Requests;
using Oci.TenantmanagercontrolplaneService.Responses;
using Oci.TenantmanagercontrolplaneService.Models;

namespace Oci.TenantmanagercontrolplaneService.Cmdlets
{
    [Cmdlet("Get", "OCITenantmanagercontrolplaneOrder")]
    [OutputType(new System.Type[] { typeof(Oci.TenantmanagercontrolplaneService.Models.Order), typeof(Oci.TenantmanagercontrolplaneService.Responses.GetOrderResponse) })]
    public class GetOCITenantmanagercontrolplaneOrder : OCIOrdersCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Activation Token containing an order id. JWT RFC 7519 formatted string.")]
        public string ActivationToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetOrderRequest request;

            try
            {
                request = new GetOrderRequest
                {
                    ActivationToken = ActivationToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetOrder(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Order);
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

        private GetOrderResponse response;
    }
}
