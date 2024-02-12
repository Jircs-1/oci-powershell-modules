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
    [Cmdlet("Get", "OCILoganalyticsEntitiesList")]
    [OutputType(new System.Type[] { typeof(Oci.LoganalyticsService.Models.LogAnalyticsEntityCollection), typeof(Oci.LoganalyticsService.Responses.ListLogAnalyticsEntitiesResponse) })]
    public class GetOCILoganalyticsEntitiesList : OCILogAnalyticsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Logging Analytics namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only log analytics entities whose name matches the entire name given. The match is case-insensitive.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only log analytics entities whose name contains the name given. The match is case-insensitive.")]
        public string NameContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only log analytics entities whose entityTypeName matches the entire log analytics entity type name of one of the entityTypeNames given in the list. The match is case-insensitive.")]
        public System.Collections.Generic.List<string> EntityTypeName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only log analytics entities whose cloudResourceId matches the cloudResourceId given.")]
        public string CloudResourceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only those log analytics entities with the specified lifecycle state. The state value is case-insensitive.")]
        public System.Nullable<Oci.LoganalyticsService.Models.EntityLifecycleStates> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only log analytics entities whose lifecycleDetails contains the specified string.")]
        public string LifecycleDetailsContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only those log analytics entities whose managementAgentId is null or is not null.")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ListLogAnalyticsEntitiesRequest.IsManagementAgentIdNullEnum> IsManagementAgentIdNull { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only log analytics entities whose hostname matches the entire hostname given.")]
        public string Hostname { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only log analytics entities whose hostname contains the substring given. The match is case-insensitive.")]
        public string HostnameContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only log analytics entities whose sourceId matches the sourceId given.")]
        public string SourceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only those log analytics entities with the specified auto-creation source.")]
        public System.Collections.Generic.List<Oci.LoganalyticsService.Models.CreationSourceType> CreationSourceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only log analytics entities whose auto-creation source details contains the specified string.")]
        public string CreationSourceDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ListLogAnalyticsEntitiesRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort entities by. Only one sort order may be provided. Default order for timeCreated and timeUpdated is descending. Default order for entity name is ascending. If no value is specified timeCreated is default.")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ListLogAnalyticsEntitiesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only log analytics entities whose metadata name, value and type matches the specified string. Each item in the array has the format ""{name}:{value}:{type}"".  All inputs are case-insensitive.")]
        public System.Collections.Generic.List<string> MetadataEquals { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListLogAnalyticsEntitiesRequest request;

            try
            {
                request = new ListLogAnalyticsEntitiesRequest
                {
                    NamespaceName = NamespaceName,
                    CompartmentId = CompartmentId,
                    Name = Name,
                    NameContains = NameContains,
                    EntityTypeName = EntityTypeName,
                    CloudResourceId = CloudResourceId,
                    LifecycleState = LifecycleState,
                    LifecycleDetailsContains = LifecycleDetailsContains,
                    IsManagementAgentIdNull = IsManagementAgentIdNull,
                    Hostname = Hostname,
                    HostnameContains = HostnameContains,
                    SourceId = SourceId,
                    CreationSourceType = CreationSourceType,
                    CreationSourceDetails = CreationSourceDetails,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId,
                    MetadataEquals = MetadataEquals
                };
                IEnumerable<ListLogAnalyticsEntitiesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.LogAnalyticsEntityCollection, true);
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
            IEnumerable<ListLogAnalyticsEntitiesResponse> DefaultRequest(ListLogAnalyticsEntitiesRequest request) => Enumerable.Repeat(client.ListLogAnalyticsEntities(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListLogAnalyticsEntitiesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListLogAnalyticsEntitiesResponse response;
        private delegate IEnumerable<ListLogAnalyticsEntitiesResponse> RequestDelegate(ListLogAnalyticsEntitiesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
