/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190531
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.BdsService.Requests;
using Oci.BdsService.Responses;
using Oci.BdsService.Models;
using Oci.Common.Model;

namespace Oci.BdsService.Cmdlets
{
    [Cmdlet("Get", "OCIBdsPatchHistoriesList")]
    [OutputType(new System.Type[] { typeof(Oci.BdsService.Models.PatchHistorySummary), typeof(Oci.BdsService.Responses.ListPatchHistoriesResponse) })]
    public class GetOCIBdsPatchHistoriesList : OCIBdsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the cluster.")]
        public string BdsInstanceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The status of the patch.")]
        public System.Nullable<Oci.BdsService.Models.PatchHistorySummary.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. Default order for displayName is ascending. If no value is specified timeCreated is default.")]
        public System.Nullable<Oci.BdsService.Requests.ListPatchHistoriesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The version of the patch")]
        public string PatchVersion { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.BdsService.Models.SortOrders> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The type of a BDS patch history entity.")]
        public System.Nullable<Oci.BdsService.Models.PatchHistorySummary.PatchTypeEnum> PatchType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListPatchHistoriesRequest request;

            try
            {
                request = new ListPatchHistoriesRequest
                {
                    BdsInstanceId = BdsInstanceId,
                    OpcRequestId = OpcRequestId,
                    LifecycleState = LifecycleState,
                    SortBy = SortBy,
                    PatchVersion = PatchVersion,
                    SortOrder = SortOrder,
                    Page = Page,
                    Limit = Limit,
                    PatchType = PatchType
                };
                IEnumerable<ListPatchHistoriesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.Items, true);
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
            IEnumerable<ListPatchHistoriesResponse> DefaultRequest(ListPatchHistoriesRequest request) => Enumerable.Repeat(client.ListPatchHistories(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListPatchHistoriesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListPatchHistoriesResponse response;
        private delegate IEnumerable<ListPatchHistoriesResponse> RequestDelegate(ListPatchHistoriesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
