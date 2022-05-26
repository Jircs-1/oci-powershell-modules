/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200131
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CloudguardService.Requests;
using Oci.CloudguardService.Responses;
using Oci.CloudguardService.Models;
using Oci.Common.Model;

namespace Oci.CloudguardService.Cmdlets
{
    [Cmdlet("Get", "OCICloudguardConditionMetadataType")]
    [OutputType(new System.Type[] { typeof(Oci.CloudguardService.Models.ConditionMetadataType), typeof(Oci.CloudguardService.Responses.GetConditionMetadataTypeResponse) })]
    public class GetOCICloudguardConditionMetadataType : OCICloudGuardCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The type of the condition meta data.")]
        public System.Nullable<Oci.CloudguardService.Models.ConditionTypeEnum> ConditionMetadataTypeId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"ServiceType filter for the condition meta data.")]
        public string ServiceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Resource filter for the condition meta data.")]
        public string ResourceType { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetConditionMetadataTypeRequest request;

            try
            {
                request = new GetConditionMetadataTypeRequest
                {
                    ConditionMetadataTypeId = ConditionMetadataTypeId,
                    OpcRequestId = OpcRequestId,
                    ServiceType = ServiceType,
                    ResourceType = ResourceType
                };

                response = client.GetConditionMetadataType(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ConditionMetadataType);
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

        private GetConditionMetadataTypeResponse response;
    }
}
