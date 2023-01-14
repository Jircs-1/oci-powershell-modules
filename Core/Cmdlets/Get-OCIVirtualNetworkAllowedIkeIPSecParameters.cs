/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CoreService.Requests;
using Oci.CoreService.Responses;
using Oci.CoreService.Models;
using Oci.Common.Model;

namespace Oci.CoreService.Cmdlets
{
    [Cmdlet("Get", "OCIVirtualNetworkAllowedIkeIPSecParameters")]
    [OutputType(new System.Type[] { typeof(Oci.CoreService.Models.AllowedIkeIPSecParameters), typeof(Oci.CoreService.Responses.GetAllowedIkeIPSecParametersResponse) })]
    public class GetOCIVirtualNetworkAllowedIkeIPSecParameters : OCIVirtualNetworkCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetAllowedIkeIPSecParametersRequest request;

            try
            {
                request = new GetAllowedIkeIPSecParametersRequest
                {
                    OpcRequestId = OpcRequestId
                };

                response = client.GetAllowedIkeIPSecParameters(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AllowedIkeIPSecParameters);
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

        private GetAllowedIkeIPSecParametersResponse response;
    }
}
