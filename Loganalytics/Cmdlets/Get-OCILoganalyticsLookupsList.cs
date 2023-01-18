/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200601
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.LoganalyticsService.Requests;
using Oci.LoganalyticsService.Responses;
using Oci.LoganalyticsService.Models;
using Oci.Common.Model;

namespace Oci.LoganalyticsService.Cmdlets
{
    [Cmdlet("Get", "OCILoganalyticsLookupsList")]
    [OutputType(new System.Type[] { typeof(Oci.LoganalyticsService.Models.LogAnalyticsLookupCollection), typeof(Oci.LoganalyticsService.Responses.ListLookupsResponse) })]
    public class GetOCILoganalyticsLookupsList : OCILogAnalyticsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Logging Analytics namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The lookup type.  Valid values are Lookup or Dictionary.")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ListLookupsRequest.TypeEnum> Type { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The lookup text used for filtering.  Only lookups with the specified name or description will be returned.")]
        public string LookupDisplayText { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The system value used for filtering.  Only items with the specified system value will be returned.  Valid values are built in, custom (for user defined items), or all (for all items, regardless of system value).")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ListLookupsRequest.IsSystemEnum> IsSystem { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"sort by field")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ListLookupsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The lookup status used for filtering when fetching a list of lookups.")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ListLookupsRequest.StatusEnum> Status { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A comma-separated list of categories used for filtering")]
        public string Categories { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A flag indicating whether or not to return OMC annotated or hidden lookups.")]
        public System.Nullable<bool> IsHideSpecial { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ListLookupsRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListLookupsRequest request;

            try
            {
                request = new ListLookupsRequest
                {
                    NamespaceName = NamespaceName,
                    Type = Type,
                    LookupDisplayText = LookupDisplayText,
                    IsSystem = IsSystem,
                    SortBy = SortBy,
                    Status = Status,
                    Categories = Categories,
                    IsHideSpecial = IsHideSpecial,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListLookupsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.LogAnalyticsLookupCollection, true);
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
            IEnumerable<ListLookupsResponse> DefaultRequest(ListLookupsRequest request) => Enumerable.Repeat(client.ListLookups(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListLookupsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListLookupsResponse response;
        private delegate IEnumerable<ListLookupsResponse> RequestDelegate(ListLookupsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
