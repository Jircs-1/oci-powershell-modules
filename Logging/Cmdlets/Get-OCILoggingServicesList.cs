/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200531
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.LoggingService.Requests;
using Oci.LoggingService.Responses;
using Oci.LoggingService.Models;
using Oci.Common.Model;

namespace Oci.LoggingService.Cmdlets
{
    [Cmdlet("Get", "OCILoggingServicesList")]
    [OutputType(new System.Type[] { typeof(Oci.LoggingService.Models.ServiceSummary), typeof(Oci.LoggingService.Responses.ListServicesResponse) })]
    public class GetOCILoggingServicesList : OCILoggingManagementCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListServicesRequest request;

            try
            {
                request = new ListServicesRequest
                {
                    OpcRequestId = OpcRequestId
                };

                response = client.ListServices(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Items, true);
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

        private ListServicesResponse response;
    }
}
