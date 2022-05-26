/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20201101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DatabasemanagementService.Requests;
using Oci.DatabasemanagementService.Responses;
using Oci.DatabasemanagementService.Models;
using Oci.Common.Model;

namespace Oci.DatabasemanagementService.Cmdlets
{
    [Cmdlet("Get", "OCIDatabasemanagementSqlTuningAdvisorTaskFindingsList")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemanagementService.Models.SqlTuningAdvisorTaskFindingCollection), typeof(Oci.DatabasemanagementService.Responses.ListSqlTuningAdvisorTaskFindingsResponse) })]
    public class GetOCIDatabasemanagementSqlTuningAdvisorTaskFindingsList : OCISqlTuningCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the Managed Database.")]
        public string ManagedDatabaseId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The SQL tuning task identifier. This is not the [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm).")]
        public System.Nullable<long> SqlTuningAdvisorTaskId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional greater than or equal to filter on the execution ID related to a specific SQL Tuning Advisor task.")]
        public System.Nullable<long> BeginExecId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional less than or equal to query parameter to filter on the execution ID related to a specific SQL Tuning Advisor task.")]
        public System.Nullable<long> EndExecId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The search period during which the API will search for begin and end exec id, if not supplied. Unused if beginExecId and endExecId optional query params are both supplied.")]
        public System.Nullable<Oci.DatabasemanagementService.Requests.ListSqlTuningAdvisorTaskFindingsRequest.SearchPeriodEnum> SearchPeriod { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The filter used to display specific findings in the report.")]
        public System.Nullable<Oci.DatabasemanagementService.Requests.ListSqlTuningAdvisorTaskFindingsRequest.FindingFilterEnum> FindingFilter { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The hash value of the object for the statistic finding search.")]
        public string StatsHashFilter { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The hash value of the index table name.")]
        public string IndexHashFilter { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The possible sortBy values of an object's recommendations.")]
        public System.Nullable<Oci.DatabasemanagementService.Requests.ListSqlTuningAdvisorTaskFindingsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The option to sort information in ascending ('ASC') or descending ('DESC') order. Descending order is the default order.")]
        public System.Nullable<Oci.DatabasemanagementService.Models.SortOrders> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page from where the next set of paginated results are retrieved. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of records returned in the paginated response.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListSqlTuningAdvisorTaskFindingsRequest request;

            try
            {
                request = new ListSqlTuningAdvisorTaskFindingsRequest
                {
                    ManagedDatabaseId = ManagedDatabaseId,
                    SqlTuningAdvisorTaskId = SqlTuningAdvisorTaskId,
                    BeginExecId = BeginExecId,
                    EndExecId = EndExecId,
                    SearchPeriod = SearchPeriod,
                    FindingFilter = FindingFilter,
                    StatsHashFilter = StatsHashFilter,
                    IndexHashFilter = IndexHashFilter,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    Page = Page,
                    Limit = Limit,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListSqlTuningAdvisorTaskFindingsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.SqlTuningAdvisorTaskFindingCollection, true);
                }
                if(!ParameterSetName.Equals(AllPageSet) && !ParameterSetName.Equals(LimitSet) && response.OpcNextPage != null)
                {
                    WriteWarning("This operation supports pagination and not all resources were returned. Re-run using the -All option to auto paginate and list all resources.");
                }
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

        private RequestDelegate GetRequestDelegate()
        {
            IEnumerable<ListSqlTuningAdvisorTaskFindingsResponse> DefaultRequest(ListSqlTuningAdvisorTaskFindingsRequest request) => Enumerable.Repeat(client.ListSqlTuningAdvisorTaskFindings(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListSqlTuningAdvisorTaskFindingsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListSqlTuningAdvisorTaskFindingsResponse response;
        private delegate IEnumerable<ListSqlTuningAdvisorTaskFindingsResponse> RequestDelegate(ListSqlTuningAdvisorTaskFindingsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
