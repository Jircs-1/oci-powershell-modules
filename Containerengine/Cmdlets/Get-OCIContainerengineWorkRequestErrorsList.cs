/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20180222
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ContainerengineService.Requests;
using Oci.ContainerengineService.Responses;
using Oci.ContainerengineService.Models;
using Oci.Common.Model;

namespace Oci.ContainerengineService.Cmdlets
{
    [Cmdlet("Get", "OCIContainerengineWorkRequestErrorsList")]
    [OutputType(new System.Type[] { typeof(Oci.ContainerengineService.Models.WorkRequestError), typeof(Oci.ContainerengineService.Responses.ListWorkRequestErrorsResponse) })]
    public class GetOCIContainerengineWorkRequestErrorsList : OCIContainerEngineCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the work request.")]
        public string WorkRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListWorkRequestErrorsRequest request;

            try
            {
                request = new ListWorkRequestErrorsRequest
                {
                    CompartmentId = CompartmentId,
                    WorkRequestId = WorkRequestId,
                    OpcRequestId = OpcRequestId
                };

                response = client.ListWorkRequestErrors(request).GetAwaiter().GetResult();
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

        private ListWorkRequestErrorsResponse response;
    }
}
