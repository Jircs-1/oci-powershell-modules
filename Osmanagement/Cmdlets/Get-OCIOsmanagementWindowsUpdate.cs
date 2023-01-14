/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190801
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OsmanagementService.Requests;
using Oci.OsmanagementService.Responses;
using Oci.OsmanagementService.Models;
using Oci.Common.Model;

namespace Oci.OsmanagementService.Cmdlets
{
    [Cmdlet("Get", "OCIOsmanagementWindowsUpdate")]
    [OutputType(new System.Type[] { typeof(Oci.OsmanagementService.Models.WindowsUpdate), typeof(Oci.OsmanagementService.Responses.GetWindowsUpdateResponse) })]
    public class GetOCIOsmanagementWindowsUpdate : OCIOsManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Windows Update")]
        public string WindowsUpdate { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetWindowsUpdateRequest request;

            try
            {
                request = new GetWindowsUpdateRequest
                {
                    WindowsUpdate = WindowsUpdate,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetWindowsUpdate(request).GetAwaiter().GetResult();
                WriteOutput(response, response.WindowsUpdate);
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

        private GetWindowsUpdateResponse response;
    }
}
