/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210501
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OsubusageService.Requests;
using Oci.OsubusageService.Responses;
using Oci.OsubusageService.Models;
using Oci.Common.Model;

namespace Oci.OsubusageService.Cmdlets
{
    [Cmdlet("Get", "OCIOsubusageComputedUsage")]
    [OutputType(new System.Type[] { typeof(Oci.OsubusageService.Models.ComputedUsage), typeof(Oci.OsubusageService.Responses.GetComputedUsageResponse) })]
    public class GetOCIOsubusageComputedUsage : OCIComputedUsageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Computed Usage Id")]
        public string ComputedUsageId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the root compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Partial response refers to an optimization technique offered by the RESTful web APIs to return only the information (fields) required by the client. This parameter is used to control what fields to return.")]
        public System.Collections.Generic.List<string> Fields { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCI home region name in case home region is not us-ashburn-1 (IAD), e.g. ap-mumbai-1, us-phoenix-1 etc.")]
        public string XOneOriginRegion { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetComputedUsageRequest request;

            try
            {
                request = new GetComputedUsageRequest
                {
                    ComputedUsageId = ComputedUsageId,
                    CompartmentId = CompartmentId,
                    Fields = Fields,
                    OpcRequestId = OpcRequestId,
                    XOneOriginRegion = XOneOriginRegion
                };

                response = client.GetComputedUsage(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ComputedUsage);
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

        private GetComputedUsageResponse response;
    }
}
