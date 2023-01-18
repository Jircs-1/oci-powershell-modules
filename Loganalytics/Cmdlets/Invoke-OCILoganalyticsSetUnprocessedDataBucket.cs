/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200601
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.LoganalyticsService.Requests;
using Oci.LoganalyticsService.Responses;
using Oci.LoganalyticsService.Models;
using Oci.Common.Model;

namespace Oci.LoganalyticsService.Cmdlets
{
    [Cmdlet("Invoke", "OCILoganalyticsSetUnprocessedDataBucket")]
    [OutputType(new System.Type[] { typeof(Oci.LoganalyticsService.Models.UnprocessedDataBucket), typeof(Oci.LoganalyticsService.Responses.SetUnprocessedDataBucketResponse) })]
    public class InvokeOCILoganalyticsSetUnprocessedDataBucket : OCILogAnalyticsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Logging Analytics namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Name of the Object Storage bucket.")]
        public string BucketName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The enabled flag used for filtering.  Only items with the specified enabled value will be returned.")]
        public System.Nullable<bool> IsEnabled { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SetUnprocessedDataBucketRequest request;

            try
            {
                request = new SetUnprocessedDataBucketRequest
                {
                    NamespaceName = NamespaceName,
                    BucketName = BucketName,
                    IsEnabled = IsEnabled,
                    OpcRequestId = OpcRequestId
                };

                response = client.SetUnprocessedDataBucket(request).GetAwaiter().GetResult();
                WriteOutput(response, response.UnprocessedDataBucket);
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

        private SetUnprocessedDataBucketResponse response;
    }
}
