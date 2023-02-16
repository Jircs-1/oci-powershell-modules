/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20201101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatabasemanagementService.Requests;
using Oci.DatabasemanagementService.Responses;
using Oci.DatabasemanagementService.Models;
using Oci.Common.Model;

namespace Oci.DatabasemanagementService.Cmdlets
{
    [Cmdlet("Invoke", "OCIDatabasemanagementSummarizeExternalAsmMetrics")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemanagementService.Models.MetricsAggregationRangeCollection), typeof(Oci.DatabasemanagementService.Responses.SummarizeExternalAsmMetricsResponse) })]
    public class InvokeOCIDatabasemanagementSummarizeExternalAsmMetrics : OCIDbManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the external ASM.")]
        public string ExternalAsmId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The beginning of the time range set to retrieve metric data for the DB system and its members. Expressed in UTC in ISO-8601 format, which is `yyyy-MM-dd'T'hh:mm:ss.sss'Z'`.")]
        public string StartTime { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The end of the time range set to retrieve metric data for the DB system and its members. Expressed in UTC in ISO-8601 format, which is `yyyy-MM-dd'T'hh:mm:ss.sss'Z'`.")]
        public string EndTime { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page from where the next set of paginated results are retrieved. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of records returned in the paginated response.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The filter used to retrieve a specific set of metrics by passing the desired metric names with a comma separator. Note that, by default, the service returns all supported metrics.")]
        public string FilterByMetricNames { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeExternalAsmMetricsRequest request;

            try
            {
                request = new SummarizeExternalAsmMetricsRequest
                {
                    ExternalAsmId = ExternalAsmId,
                    StartTime = StartTime,
                    EndTime = EndTime,
                    OpcRequestId = OpcRequestId,
                    Page = Page,
                    Limit = Limit,
                    FilterByMetricNames = FilterByMetricNames
                };

                response = client.SummarizeExternalAsmMetrics(request).GetAwaiter().GetResult();
                WriteOutput(response, response.MetricsAggregationRangeCollection);
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

        private SummarizeExternalAsmMetricsResponse response;
    }
}
