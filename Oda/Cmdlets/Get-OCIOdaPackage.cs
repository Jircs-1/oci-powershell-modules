/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190506
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OdaService.Requests;
using Oci.OdaService.Responses;
using Oci.OdaService.Models;

namespace Oci.OdaService.Cmdlets
{
    [Cmdlet("Get", "OCIOdaPackage")]
    [OutputType(new System.Type[] { typeof(Oci.OdaService.Models.Package), typeof(Oci.OdaService.Responses.GetPackageResponse) })]
    public class GetOCIOdaPackage : OCIOdapackageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Digital Assistant instance identifier.")]
        public string OdaInstanceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Digital Assistant package identifier.")]
        public string PackageId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing. This value is included in the opc-request-id response header.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetPackageRequest request;

            try
            {
                request = new GetPackageRequest
                {
                    OdaInstanceId = OdaInstanceId,
                    PackageId = PackageId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetPackage(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Package);
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

        private GetPackageResponse response;
    }
}
