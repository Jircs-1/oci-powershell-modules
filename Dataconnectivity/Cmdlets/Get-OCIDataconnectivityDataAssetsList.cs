/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210217
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DataconnectivityService.Requests;
using Oci.DataconnectivityService.Responses;
using Oci.DataconnectivityService.Models;
using Oci.Common.Model;

namespace Oci.DataconnectivityService.Cmdlets
{
    [Cmdlet("Get", "OCIDataconnectivityDataAssetsList")]
    [OutputType(new System.Type[] { typeof(Oci.DataconnectivityService.Models.DataAssetSummaryCollection), typeof(Oci.DataconnectivityService.Responses.ListDataAssetsResponse) })]
    public class GetOCIDataconnectivityDataAssetsList : OCIDataConnectivityManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The registry OCID.")]
        public string RegistryId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value for this parameter is the `opc-next-page` or the `opc-prev-page` response header from the previous `List` call. See [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Sets the maximum number of results per page, or items to return in a paginated `List` call. See [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the fields to get for an object.")]
        public System.Collections.Generic.List<string> Fields { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Artifact type which needs to be listed while listing Artifacts.")]
        public System.Collections.Generic.List<string> IncludeTypes { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the field to sort by. Accepts only one field. By default, when you sort by time fields, results are shown in descending order. All other fields default to ascending order. Sorting related parameters are ignored when parameter `query` is present (search operation and sorting order are by relevance score in descending order).")]
        public System.Nullable<Oci.DataconnectivityService.Requests.ListDataAssetsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies sort order to use, either `ASC` (ascending) or `DESC` (descending).")]
        public System.Nullable<Oci.DataconnectivityService.Requests.ListDataAssetsRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Used to filter by the name of the object.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The types that will be excluded from the list of data assets/connections.")]
        public System.Collections.Generic.List<string> ExcludeTypes { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"If value is FAVORITES_ONLY, then only objects marked as favorite by the requesting user will be included in result. If value is NON_FAVORITES_ONLY, then objects marked as favorites by the requesting user will be skipped. If value is ALL or if not specified, all objects, irrespective of favorites or not will be returned. Default is ALL.")]
        public System.Nullable<Oci.DataconnectivityService.Requests.ListDataAssetsRequest.FavoritesQueryParamEnum> FavoritesQueryParam { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique key of the folder.")]
        public string FolderId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Endpoint IDs used for data-plane APIs to filter or prefer specific endpoint.")]
        public System.Collections.Generic.List<string> EndpointIds { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Endpoints which will be excluded while listing data assets.")]
        public System.Collections.Generic.List<string> ExcludeEndpointIds { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListDataAssetsRequest request;

            try
            {
                request = new ListDataAssetsRequest
                {
                    RegistryId = RegistryId,
                    Page = Page,
                    Limit = Limit,
                    Fields = Fields,
                    IncludeTypes = IncludeTypes,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    Name = Name,
                    OpcRequestId = OpcRequestId,
                    ExcludeTypes = ExcludeTypes,
                    FavoritesQueryParam = FavoritesQueryParam,
                    FolderId = FolderId,
                    EndpointIds = EndpointIds,
                    ExcludeEndpointIds = ExcludeEndpointIds
                };
                IEnumerable<ListDataAssetsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.DataAssetSummaryCollection, true);
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
            IEnumerable<ListDataAssetsResponse> DefaultRequest(ListDataAssetsRequest request) => Enumerable.Repeat(client.ListDataAssets(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListDataAssetsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListDataAssetsResponse response;
        private delegate IEnumerable<ListDataAssetsResponse> RequestDelegate(ListDataAssetsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
