/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OpsiService.Requests;
using Oci.OpsiService.Responses;
using Oci.OpsiService.Models;
using Oci.Common.Model;

namespace Oci.OpsiService.Cmdlets
{
    [Cmdlet("Invoke", "OCIOpsiSummarizeDatabaseInsightResourceUsageTrend")]
    [OutputType(new System.Type[] { typeof(Oci.OpsiService.Models.SummarizeDatabaseInsightResourceUsageTrendAggregationCollection), typeof(Oci.OpsiService.Responses.SummarizeDatabaseInsightResourceUsageTrendResponse) })]
    public class InvokeOCIOpsiSummarizeDatabaseInsightResourceUsageTrend : OCIOperationsInsightsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter by resource metric. Supported values are CPU , STORAGE, MEMORY and IO.")]
        public string ResourceMetric { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specify time period in ISO 8601 format with respect to current time. Default is last 30 days represented by P30D. If timeInterval is specified, then timeIntervalStart and timeIntervalEnd will be ignored. Examples  P90D (last 90 days), P4W (last 4 weeks), P2M (last 2 months), P1Y (last 12 months), . Maximum value allowed is 25 months prior to current time (P25M).")]
        public string AnalysisTimeInterval { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Analysis start time in UTC in ISO 8601 format(inclusive). Example 2019-10-30T00:00:00Z (yyyy-MM-ddThh:mm:ssZ). The minimum allowed value is 2 years prior to the current day. timeIntervalStart and timeIntervalEnd parameters are used together. If analysisTimeInterval is specified, this parameter is ignored.")]
        public System.Nullable<System.DateTime> TimeIntervalStart { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Analysis end time in UTC in ISO 8601 format(exclusive). Example 2019-10-30T00:00:00Z (yyyy-MM-ddThh:mm:ssZ). timeIntervalStart and timeIntervalEnd are used together. If timeIntervalEnd is not specified, current time is used as timeIntervalEnd.")]
        public System.Nullable<System.DateTime> TimeIntervalEnd { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter by one or more database type. Possible values are ADW-S, ATP-S, ADW-D, ATP-D, EXTERNAL-PDB, EXTERNAL-NONCDB.")]
        public System.Collections.Generic.List<Oci.OpsiService.Requests.SummarizeDatabaseInsightResourceUsageTrendRequest.DatabaseTypeEnum> DatabaseType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Optional list of database [OCIDs](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the associated DBaaS entity.")]
        public System.Collections.Generic.List<string> DatabaseId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Optional list of database insight resource [OCIDs](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm).")]
        public System.Collections.Generic.List<string> Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Optional list of exadata insight resource [OCIDs](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm).")]
        public System.Collections.Generic.List<string> ExadataInsightId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.OpsiService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Sorts using end timestamp, usage or capacity")]
        public System.Nullable<Oci.OpsiService.Requests.SummarizeDatabaseInsightResourceUsageTrendRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter by one or more hostname.")]
        public System.Collections.Generic.List<string> HostName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Flag to indicate if database instance level metrics should be returned. The flag is ignored when a host name filter is not applied. When a hostname filter is applied this flag will determine whether to return metrics for the instances located on the specified host or for the whole database which contains an instance on this host.")]
        public System.Nullable<bool> IsDatabaseInstanceLevelMetrics { get; set; }

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

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A flag to search all resources within a given compartment and all sub-compartments.")]
        public System.Nullable<bool> CompartmentIdInSubtree { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Optional list of Exadata Insight VM cluster name.")]
        public System.Collections.Generic.List<string> VmclusterName { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeDatabaseInsightResourceUsageTrendRequest request;

            try
            {
                request = new SummarizeDatabaseInsightResourceUsageTrendRequest
                {
                    CompartmentId = CompartmentId,
                    ResourceMetric = ResourceMetric,
                    AnalysisTimeInterval = AnalysisTimeInterval,
                    TimeIntervalStart = TimeIntervalStart,
                    TimeIntervalEnd = TimeIntervalEnd,
                    DatabaseType = DatabaseType,
                    DatabaseId = DatabaseId,
                    Id = Id,
                    ExadataInsightId = ExadataInsightId,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    HostName = HostName,
                    IsDatabaseInstanceLevelMetrics = IsDatabaseInstanceLevelMetrics,
                    OpcRequestId = OpcRequestId,
                    DefinedTagEquals = DefinedTagEquals,
                    FreeformTagEquals = FreeformTagEquals,
                    DefinedTagExists = DefinedTagExists,
                    FreeformTagExists = FreeformTagExists,
                    CompartmentIdInSubtree = CompartmentIdInSubtree,
                    VmclusterName = VmclusterName
                };

                response = client.SummarizeDatabaseInsightResourceUsageTrend(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SummarizeDatabaseInsightResourceUsageTrendAggregationCollection);
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

        private SummarizeDatabaseInsightResourceUsageTrendResponse response;
    }
}
