/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190801
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
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
    [Cmdlet("Get", "OCIOsmanagementModuleStream")]
    [OutputType(new System.Type[] { typeof(Oci.OsmanagementService.Models.ModuleStream), typeof(Oci.OsmanagementService.Responses.GetModuleStreamResponse) })]
    public class GetOCIOsmanagementModuleStream : OCIOsManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the software source.")]
        public string SoftwareSourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the module")]
        public string ModuleName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the stream of the containing module")]
        public string StreamName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetModuleStreamRequest request;

            try
            {
                request = new GetModuleStreamRequest
                {
                    SoftwareSourceId = SoftwareSourceId,
                    ModuleName = ModuleName,
                    StreamName = StreamName,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetModuleStream(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ModuleStream);
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

        private GetModuleStreamResponse response;
    }
}
