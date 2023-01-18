/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ApmconfigService.Requests;
using Oci.ApmconfigService.Responses;
using Oci.ApmconfigService.Models;
using Oci.Common.Model;

namespace Oci.ApmconfigService.Cmdlets
{
    [Cmdlet("Invoke", "OCIApmconfigRetrieveNamespaceMetrics")]
    [OutputType(new System.Type[] { typeof(Oci.ApmconfigService.Models.NamespaceMetricCollection), typeof(Oci.ApmconfigService.Responses.RetrieveNamespaceMetricsResponse) })]
    public class InvokeOCIApmconfigRetrieveNamespaceMetrics : OCIConfigCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The APM Domain ID the request is intended for.")]
        public string ApmDomainId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The namespace to get the metrics for.")]
        public RetrieveNamespaceMetricsDetails RetrieveNamespaceMetricsDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            RetrieveNamespaceMetricsRequest request;

            try
            {
                request = new RetrieveNamespaceMetricsRequest
                {
                    ApmDomainId = ApmDomainId,
                    RetrieveNamespaceMetricsDetails = RetrieveNamespaceMetricsDetails,
                    OpcRequestId = OpcRequestId
                };

                response = client.RetrieveNamespaceMetrics(request).GetAwaiter().GetResult();
                WriteOutput(response, response.NamespaceMetricCollection);
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

        private RetrieveNamespaceMetricsResponse response;
    }
}
