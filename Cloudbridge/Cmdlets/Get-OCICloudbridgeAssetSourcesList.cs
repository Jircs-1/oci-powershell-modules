/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220509
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.CloudbridgeService.Requests;
using Oci.CloudbridgeService.Responses;
using Oci.CloudbridgeService.Models;
using Oci.Common.Model;

namespace Oci.CloudbridgeService.Cmdlets
{
    [Cmdlet("Get", "OCICloudbridgeAssetSourcesList")]
    [OutputType(new System.Type[] { typeof(Oci.CloudbridgeService.Models.AssetSourceCollection), typeof(Oci.CloudbridgeService.Responses.ListAssetSourcesResponse) })]
    public class GetOCICloudbridgeAssetSourcesList : OCIDiscoveryCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the asset source.")]
        public string AssetSourceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. By default, the timeCreated is in descending order and displayName is in ascending order.")]
        public System.Nullable<Oci.CloudbridgeService.Requests.ListAssetSourcesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The current state of the asset source.")]
        public System.Nullable<Oci.CloudbridgeService.Models.AssetSourceLifecycleState> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.CloudbridgeService.Models.SortOrders> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the entire display name given.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from the `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListAssetSourcesRequest request;

            try
            {
                request = new ListAssetSourcesRequest
                {
                    CompartmentId = CompartmentId,
                    AssetSourceId = AssetSourceId,
                    SortBy = SortBy,
                    LifecycleState = LifecycleState,
                    SortOrder = SortOrder,
                    DisplayName = DisplayName,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListAssetSourcesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.AssetSourceCollection, true);
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
            IEnumerable<ListAssetSourcesResponse> DefaultRequest(ListAssetSourcesRequest request) => Enumerable.Repeat(client.ListAssetSources(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListAssetSourcesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListAssetSourcesResponse response;
        private delegate IEnumerable<ListAssetSourcesResponse> RequestDelegate(ListAssetSourcesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
