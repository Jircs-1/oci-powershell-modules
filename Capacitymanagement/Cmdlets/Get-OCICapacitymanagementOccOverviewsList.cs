/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20231107
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.CapacitymanagementService.Requests;
using Oci.CapacitymanagementService.Responses;
using Oci.CapacitymanagementService.Models;
using Oci.Common.Model;

namespace Oci.CapacitymanagementService.Cmdlets
{
    [Cmdlet("Get", "OCICapacitymanagementOccOverviewsList")]
    [OutputType(new System.Type[] { typeof(Oci.CapacitymanagementService.Models.OccOverviewCollection), typeof(Oci.CapacitymanagementService.Responses.ListOccOverviewsResponse) })]
    public class GetOCICapacitymanagementOccOverviewsList : OCICapacityManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The namespace by which we would filter the list.")]
        public System.Nullable<Oci.CapacitymanagementService.Models.Namespace> Namespace { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ocid of the compartment or tenancy in which resources are to be listed. This will also be used for authorization purposes.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The month corresponding to this date would be considered as the starting point of the time period against which we would like to perform an aggregation.")]
        public System.Nullable<System.DateTime> From { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The month corresponding to this date would be considered as the ending point of the time period against which we would like to perform an aggregation.")]
        public System.Nullable<System.DateTime> To { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Workload type using the resources in an availability catalog can be filtered.")]
        public string WorkloadType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing. The only valid characters for request IDs are letters, numbers, underscore, and dash.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.CapacitymanagementService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. The default order for periodValue is chronological order(latest month item at the end).")]
        public System.Nullable<Oci.CapacitymanagementService.Requests.ListOccOverviewsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListOccOverviewsRequest request;

            try
            {
                request = new ListOccOverviewsRequest
                {
                    Namespace = Namespace,
                    CompartmentId = CompartmentId,
                    From = From,
                    To = To,
                    WorkloadType = WorkloadType,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId,
                    SortOrder = SortOrder,
                    SortBy = SortBy
                };
                IEnumerable<ListOccOverviewsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.OccOverviewCollection, true);
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
            IEnumerable<ListOccOverviewsResponse> DefaultRequest(ListOccOverviewsRequest request) => Enumerable.Repeat(client.ListOccOverviews(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListOccOverviewsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListOccOverviewsResponse response;
        private delegate IEnumerable<ListOccOverviewsResponse> RequestDelegate(ListOccOverviewsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
