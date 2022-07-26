/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20211201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.FusionappsService.Requests;
using Oci.FusionappsService.Responses;
using Oci.FusionappsService.Models;
using Oci.Common.Model;

namespace Oci.FusionappsService.Cmdlets
{
    [Cmdlet("Get", "OCIFusionappsFusionEnvironmentFamilySubscriptionDetail")]
    [OutputType(new System.Type[] { typeof(Oci.FusionappsService.Models.SubscriptionDetail), typeof(Oci.FusionappsService.Responses.GetFusionEnvironmentFamilySubscriptionDetailResponse) })]
    public class GetOCIFusionappsFusionEnvironmentFamilySubscriptionDetail : OCIFusionApplicationsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier (OCID) of the FusionEnvironmentFamily.")]
        public string FusionEnvironmentFamilyId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetFusionEnvironmentFamilySubscriptionDetailRequest request;

            try
            {
                request = new GetFusionEnvironmentFamilySubscriptionDetailRequest
                {
                    FusionEnvironmentFamilyId = FusionEnvironmentFamilyId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetFusionEnvironmentFamilySubscriptionDetail(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SubscriptionDetail);
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

        private GetFusionEnvironmentFamilySubscriptionDetailResponse response;
    }
}
