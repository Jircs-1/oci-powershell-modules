/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ObjectstorageService.Requests;
using Oci.ObjectstorageService.Responses;
using Oci.ObjectstorageService.Models;
using Oci.Common.Model;

namespace Oci.ObjectstorageService.Cmdlets
{
    [Cmdlet("Get", "OCIObjectstorageRetentionRule")]
    [OutputType(new System.Type[] { typeof(Oci.ObjectstorageService.Models.RetentionRule), typeof(Oci.ObjectstorageService.Responses.GetRetentionRuleResponse) })]
    public class GetOCIObjectstorageRetentionRule : OCIObjectStorageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Object Storage namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the bucket. Avoid entering confidential information. Example: `my-new-bucket1`")]
        public string BucketName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the retention rule.")]
        public string RetentionRuleId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcClientRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetRetentionRuleRequest request;

            try
            {
                request = new GetRetentionRuleRequest
                {
                    NamespaceName = NamespaceName,
                    BucketName = BucketName,
                    RetentionRuleId = RetentionRuleId,
                    OpcClientRequestId = OpcClientRequestId
                };

                response = client.GetRetentionRule(request).GetAwaiter().GetResult();
                WriteOutput(response, response.RetentionRule);
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

        private GetRetentionRuleResponse response;
    }
}
