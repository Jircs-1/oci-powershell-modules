/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200601
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
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
    [Cmdlet("Get", "OCILoganalyticsSourcesList")]
    [OutputType(new System.Type[] { typeof(Oci.LoganalyticsService.Models.LogAnalyticsSourceCollection), typeof(Oci.LoganalyticsService.Responses.ListSourcesResponse) })]
    public class GetOCILoganalyticsSourcesList : OCILogAnalyticsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Logging Analytics namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only sources associated with entities of the specified type. The match is case-insensitive.")]
        public string EntityType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The source display text used for filtering.  Only sources with the specified name or description will be returned.")]
        public string SourceDisplayText { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The system value used for filtering.  Only items with the specified system value will be returned.  Valid values are built in, custom (for user defined items), or all (for all items, regardless of system value).")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ListSourcesRequest.IsSystemEnum> IsSystem { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"An auto-associate flag used for filtering.  Only sources which are marked for automatic association will be returned.")]
        public System.Nullable<bool> IsAutoAssociated { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ListSourcesRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The attribute used to sort the returned sources")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ListSourcesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only log analytics entities whose name matches the entire name given. The match is case-insensitive.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The source type.")]
        public string SourceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A comma-separated list of categories used for filtering")]
        public string Categories { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A flag specifying whether or not to return all source information, or a subset of the information about each source.  A value of true will return only the source unique identifier and the source name.  A value of false will return all source information (such as author, updated date, system flag, etc.)")]
        public System.Nullable<bool> IsSimplified { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListSourcesRequest request;

            try
            {
                request = new ListSourcesRequest
                {
                    NamespaceName = NamespaceName,
                    CompartmentId = CompartmentId,
                    EntityType = EntityType,
                    SourceDisplayText = SourceDisplayText,
                    IsSystem = IsSystem,
                    IsAutoAssociated = IsAutoAssociated,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    Limit = Limit,
                    Page = Page,
                    Name = Name,
                    SourceType = SourceType,
                    Categories = Categories,
                    IsSimplified = IsSimplified,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListSourcesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.LogAnalyticsSourceCollection, true);
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
            IEnumerable<ListSourcesResponse> DefaultRequest(ListSourcesRequest request) => Enumerable.Repeat(client.ListSources(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListSourcesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListSourcesResponse response;
        private delegate IEnumerable<ListSourcesResponse> RequestDelegate(ListSourcesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
