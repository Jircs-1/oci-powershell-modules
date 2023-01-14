/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20211201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.FusionappsService.Requests;
using Oci.FusionappsService.Responses;
using Oci.FusionappsService.Models;
using Oci.Common.Model;

namespace Oci.FusionappsService.Cmdlets
{
    [Cmdlet("Get", "OCIFusionappsTimeAvailableForRefreshesList")]
    [OutputType(new System.Type[] { typeof(Oci.FusionappsService.Models.TimeAvailableForRefreshCollection), typeof(Oci.FusionappsService.Responses.ListTimeAvailableForRefreshesResponse) })]
    public class GetOCIFusionappsTimeAvailableForRefreshesList : OCIFusionApplicationsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"unique FusionEnvironment identifier")]
        public string FusionEnvironmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.FusionappsService.Requests.ListTimeAvailableForRefreshesRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. Default order for displayName is ascending. If no value is specified timeCreated is default.")]
        public System.Nullable<Oci.FusionappsService.Requests.ListTimeAvailableForRefreshesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListTimeAvailableForRefreshesRequest request;

            try
            {
                request = new ListTimeAvailableForRefreshesRequest
                {
                    FusionEnvironmentId = FusionEnvironmentId,
                    OpcRequestId = OpcRequestId,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy
                };
                IEnumerable<ListTimeAvailableForRefreshesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.TimeAvailableForRefreshCollection, true);
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
            IEnumerable<ListTimeAvailableForRefreshesResponse> DefaultRequest(ListTimeAvailableForRefreshesRequest request) => Enumerable.Repeat(client.ListTimeAvailableForRefreshes(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListTimeAvailableForRefreshesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListTimeAvailableForRefreshesResponse response;
        private delegate IEnumerable<ListTimeAvailableForRefreshesResponse> RequestDelegate(ListTimeAvailableForRefreshesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
