/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20201101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
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
    [Cmdlet("Invoke", "OCIDatabasemanagementSummarizeAlertLogCounts")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemanagementService.Models.AlertLogCountsCollection), typeof(Oci.DatabasemanagementService.Responses.SummarizeAlertLogCountsResponse) })]
    public class InvokeOCIDatabasemanagementSummarizeAlertLogCounts : OCIDiagnosabilityCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the Managed Database.")]
        public string ManagedDatabaseId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional greater than or equal to timestamp to filter the logs.")]
        public System.Nullable<System.DateTime> TimeGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional less than or equal to timestamp to filter the logs.")]
        public System.Nullable<System.DateTime> TimeLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional parameter to filter the alert logs by log level.")]
        public System.Nullable<Oci.DatabasemanagementService.Requests.SummarizeAlertLogCountsRequest.LevelFilterEnum> LevelFilter { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional parameter used to group different alert logs.")]
        public System.Nullable<Oci.DatabasemanagementService.Requests.SummarizeAlertLogCountsRequest.GroupByEnum> GroupBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional parameter to filter the attention or alert logs by type.")]
        public System.Nullable<Oci.DatabasemanagementService.Requests.SummarizeAlertLogCountsRequest.TypeFilterEnum> TypeFilter { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional query parameter to filter the attention or alert logs by search text.")]
        public string LogSearchText { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The flag to indicate whether the search text is regular expression or not.")]
        public System.Nullable<bool> IsRegularExpression { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page from where the next set of paginated results are retrieved. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of records returned in the paginated response.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeAlertLogCountsRequest request;

            try
            {
                request = new SummarizeAlertLogCountsRequest
                {
                    ManagedDatabaseId = ManagedDatabaseId,
                    TimeGreaterThanOrEqualTo = TimeGreaterThanOrEqualTo,
                    TimeLessThanOrEqualTo = TimeLessThanOrEqualTo,
                    LevelFilter = LevelFilter,
                    GroupBy = GroupBy,
                    TypeFilter = TypeFilter,
                    LogSearchText = LogSearchText,
                    IsRegularExpression = IsRegularExpression,
                    Page = Page,
                    Limit = Limit,
                    OpcRequestId = OpcRequestId
                };

                response = client.SummarizeAlertLogCounts(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AlertLogCountsCollection);
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

        private SummarizeAlertLogCountsResponse response;
    }
}
