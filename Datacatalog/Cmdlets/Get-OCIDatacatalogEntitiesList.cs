/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190325
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DatacatalogService.Requests;
using Oci.DatacatalogService.Responses;
using Oci.DatacatalogService.Models;
using Oci.Common.Model;

namespace Oci.DatacatalogService.Cmdlets
{
    [Cmdlet("Get", "OCIDatacatalogEntitiesList")]
    [OutputType(new System.Type[] { typeof(Oci.DatacatalogService.Models.EntityCollection), typeof(Oci.DatacatalogService.Responses.ListEntitiesResponse) })]
    public class GetOCIDatacatalogEntitiesList : OCIDataCatalogCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique catalog identifier.")]
        public string CatalogId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique data asset key.")]
        public string DataAssetKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the entire display name given. The match is not case sensitive.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the entire business name given. The match is not case sensitive.")]
        public string BusinessName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match display name or business name pattern given. The match is not case sensitive. For Example : /folders?displayOrBusinessNameContains=Cu.* The above would match all folders with display name or business name that starts with ""Cu"" or has the pattern ""Cu"" anywhere in between.")]
        public string DisplayOrBusinessNameContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The key of the object type.")]
        public string TypeKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match display name pattern given. The match is not case sensitive. For Example : /folders?displayNameContains=Cu.* The above would match all folders with display name that starts with ""Cu"" or has the pattern ""Cu"" anywhere in between.")]
        public string DisplayNameContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the specified lifecycle state. The value is case insensitive.")]
        public System.Nullable<Oci.DatacatalogService.Models.LifecycleState> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Time that the resource was created. An [RFC3339](https://tools.ietf.org/html/rfc3339) formatted datetime string.")]
        public System.Nullable<System.DateTime> TimeCreated { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Time that the resource was updated. An [RFC3339](https://tools.ietf.org/html/rfc3339) formatted datetime string.")]
        public System.Nullable<System.DateTime> TimeUpdated { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"OCID of the user who created the resource.")]
        public string CreatedById { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"OCID of the user who updated the resource.")]
        public string UpdatedById { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique external identifier of this resource in the external source system.")]
        public string ExternalKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique pattern key.")]
        public string PatternKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Last modified timestamp of this object in the external system.")]
        public System.Nullable<System.DateTime> TimeExternal { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Time that the resource's status was last updated. An [RFC3339](https://tools.ietf.org/html/rfc3339) formatted datetime string.")]
        public System.Nullable<System.DateTime> TimeStatusUpdated { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Identifies if the object is a physical object (materialized) or virtual/logical object defined on other objects.")]
        public System.Nullable<bool> IsLogical { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Identifies if an object is a sub object (partition) of a physical or materialized parent object.")]
        public System.Nullable<bool> IsPartition { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Key of the associated folder.")]
        public string FolderKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Full path of the resource for resources that support paths.")]
        public string Path { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Harvest status of the harvestable resource as updated by the harvest process.")]
        public System.Nullable<Oci.DatacatalogService.Models.HarvestStatus> HarvestStatus { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Key of the last harvest process to update this resource.")]
        public string LastJobKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the fields to return in an entity summary response.")]
        public System.Collections.Generic.List<Oci.DatacatalogService.Requests.ListEntitiesRequest.FieldsEnum> Fields { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. DISPLAYORBUSINESSNAME considers businessName of a given object if set, else its displayName is used. Default sort order for TIMECREATED is descending and default sort order for DISPLAYNAME and DISPLAYORBUSINESSNAME is ascending. If no order is specified, TIMECREATED is the default.")]
        public System.Nullable<Oci.DatacatalogService.Requests.ListEntitiesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.DatacatalogService.Requests.ListEntitiesRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListEntitiesRequest request;

            try
            {
                request = new ListEntitiesRequest
                {
                    CatalogId = CatalogId,
                    DataAssetKey = DataAssetKey,
                    DisplayName = DisplayName,
                    BusinessName = BusinessName,
                    DisplayOrBusinessNameContains = DisplayOrBusinessNameContains,
                    TypeKey = TypeKey,
                    DisplayNameContains = DisplayNameContains,
                    LifecycleState = LifecycleState,
                    TimeCreated = TimeCreated,
                    TimeUpdated = TimeUpdated,
                    CreatedById = CreatedById,
                    UpdatedById = UpdatedById,
                    ExternalKey = ExternalKey,
                    PatternKey = PatternKey,
                    TimeExternal = TimeExternal,
                    TimeStatusUpdated = TimeStatusUpdated,
                    IsLogical = IsLogical,
                    IsPartition = IsPartition,
                    FolderKey = FolderKey,
                    Path = Path,
                    HarvestStatus = HarvestStatus,
                    LastJobKey = LastJobKey,
                    Fields = Fields,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListEntitiesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.EntityCollection, true);
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
            IEnumerable<ListEntitiesResponse> DefaultRequest(ListEntitiesRequest request) => Enumerable.Repeat(client.ListEntities(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListEntitiesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListEntitiesResponse response;
        private delegate IEnumerable<ListEntitiesResponse> RequestDelegate(ListEntitiesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
