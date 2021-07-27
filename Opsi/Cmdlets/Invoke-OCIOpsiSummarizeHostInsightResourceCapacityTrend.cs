/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OpsiService.Requests;
using Oci.OpsiService.Responses;
using Oci.OpsiService.Models;

namespace Oci.OpsiService.Cmdlets
{
    [Cmdlet("Invoke", "OCIOpsiSummarizeHostInsightResourceCapacityTrend")]
    [OutputType(new System.Type[] { typeof(Oci.OpsiService.Models.SummarizeHostInsightResourceCapacityTrendAggregationCollection), typeof(Oci.OpsiService.Responses.SummarizeHostInsightResourceCapacityTrendResponse) })]
    public class InvokeOCIOpsiSummarizeHostInsightResourceCapacityTrend : OCIOperationsInsightsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter by host resource metric. Supported values are CPU, MEMORY, and LOGICAL_MEMORY.")]
        public string ResourceMetric { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specify time period in ISO 8601 format with respect to current time. Default is last 30 days represented by P30D. If timeInterval is specified, then timeIntervalStart and timeIntervalEnd will be ignored. Examples  P90D (last 90 days), P4W (last 4 weeks), P2M (last 2 months), P1Y (last 12 months), . Maximum value allowed is 25 months prior to current time (P25M).")]
        public string AnalysisTimeInterval { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Analysis start time in UTC in ISO 8601 format(inclusive). Example 2019-10-30T00:00:00Z (yyyy-MM-ddThh:mm:ssZ). The minimum allowed value is 2 years prior to the current day. timeIntervalStart and timeIntervalEnd parameters are used together. If analysisTimeInterval is specified, this parameter is ignored.")]
        public System.Nullable<System.DateTime> TimeIntervalStart { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Analysis end time in UTC in ISO 8601 format(exclusive). Example 2019-10-30T00:00:00Z (yyyy-MM-ddThh:mm:ssZ). timeIntervalStart and timeIntervalEnd are used together. If timeIntervalEnd is not specified, current time is used as timeIntervalEnd.")]
        public System.Nullable<System.DateTime> TimeIntervalEnd { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter by one or more platform types. Possible value is LINUX.")]
        public System.Collections.Generic.List<Oci.OpsiService.Requests.SummarizeHostInsightResourceCapacityTrendRequest.PlatformTypeEnum> PlatformType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Optional list of host insight resource [OCIDs](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm).")]
        public System.Collections.Generic.List<string> Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter by utilization level by the following buckets:   - HIGH_UTILIZATION: DBs with utilization greater or equal than 75.   - LOW_UTILIZATION: DBs with utilization lower than 25.   - MEDIUM_HIGH_UTILIZATION: DBs with utilization greater or equal than 50 but lower than 75.   - MEDIUM_LOW_UTILIZATION: DBs with utilization greater or equal than 25 but lower than 50.")]
        public System.Nullable<Oci.OpsiService.Requests.SummarizeHostInsightResourceCapacityTrendRequest.UtilizationLevelEnum> UtilizationLevel { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.OpsiService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Sorts using end timestamp or capacity")]
        public System.Nullable<Oci.OpsiService.Requests.SummarizeHostInsightResourceCapacityTrendRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A list of tag filters to apply.  Only resources with a defined tag matching the value will be returned. Each item in the list has the format ""{namespace}.{tagName}.{value}"".  All inputs are case-insensitive. Multiple values for the same key (i.e. same namespace and tag name) are interpreted as ""OR"". Values for different keys (i.e. different namespaces, different tag names, or both) are interpreted as ""AND"".")]
        public System.Collections.Generic.List<string> DefinedTagEquals { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A list of tag filters to apply.  Only resources with a freeform tag matching the value will be returned. The key for each tag is ""{tagName}.{value}"".  All inputs are case-insensitive. Multiple values for the same tag name are interpreted as ""OR"".  Values for different tag names are interpreted as ""AND"".")]
        public System.Collections.Generic.List<string> FreeformTagEquals { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A list of tag existence filters to apply.  Only resources for which the specified defined tags exist will be returned. Each item in the list has the format ""{namespace}.{tagName}.true"" (for checking existence of a defined tag) or ""{namespace}.true"".  All inputs are case-insensitive. Currently, only existence (""true"" at the end) is supported. Absence (""false"" at the end) is not supported. Multiple values for the same key (i.e. same namespace and tag name) are interpreted as ""OR"". Values for different keys (i.e. different namespaces, different tag names, or both) are interpreted as ""AND"".")]
        public System.Collections.Generic.List<string> DefinedTagExists { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A list of tag existence filters to apply.  Only resources for which the specified freeform tags exist the value will be returned. The key for each tag is ""{tagName}.true"".  All inputs are case-insensitive. Currently, only existence (""true"" at the end) is supported. Absence (""false"" at the end) is not supported. Multiple values for different tag names are interpreted as ""AND"".")]
        public System.Collections.Generic.List<string> FreeformTagExists { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeHostInsightResourceCapacityTrendRequest request;

            try
            {
                request = new SummarizeHostInsightResourceCapacityTrendRequest
                {
                    CompartmentId = CompartmentId,
                    ResourceMetric = ResourceMetric,
                    AnalysisTimeInterval = AnalysisTimeInterval,
                    TimeIntervalStart = TimeIntervalStart,
                    TimeIntervalEnd = TimeIntervalEnd,
                    PlatformType = PlatformType,
                    Id = Id,
                    UtilizationLevel = UtilizationLevel,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId,
                    DefinedTagEquals = DefinedTagEquals,
                    FreeformTagEquals = FreeformTagEquals,
                    DefinedTagExists = DefinedTagExists,
                    FreeformTagExists = FreeformTagExists
                };

                response = client.SummarizeHostInsightResourceCapacityTrend(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SummarizeHostInsightResourceCapacityTrendAggregationCollection);
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

        private SummarizeHostInsightResourceCapacityTrendResponse response;
    }
}
