/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200531
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.LoggingService.Requests;
using Oci.LoggingService.Responses;
using Oci.LoggingService.Models;

namespace Oci.LoggingService.Cmdlets
{
    [Cmdlet("Get", "OCILoggingLogGroupsList")]
    [OutputType(new System.Type[] { typeof(Oci.LoggingService.Models.LogGroupSummary), typeof(Oci.LoggingService.Responses.ListLogGroupsResponse) })]
    public class GetOCILoggingLogGroupsList : OCILoggingManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Compartment OCID to list resources in. See compartmentIdInSubtree      for nested compartments traversal.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies whether or not nested compartments should be traversed. Defaults to false.")]
        public System.Nullable<bool> IsCompartmentIdInSubtree { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Resource name")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` or `opc-previous-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return in a paginated ""List"" call.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by (one column only). Default sort order is ascending exception of `timeCreated` and `timeLastModified` columns (descending).")]
        public System.Nullable<Oci.LoggingService.Requests.ListLogGroupsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, whether 'asc' or 'desc'.")]
        public System.Nullable<Oci.LoggingService.Requests.ListLogGroupsRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListLogGroupsRequest request;

            try
            {
                request = new ListLogGroupsRequest
                {
                    CompartmentId = CompartmentId,
                    IsCompartmentIdInSubtree = IsCompartmentIdInSubtree,
                    DisplayName = DisplayName,
                    Page = Page,
                    Limit = Limit,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListLogGroupsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.Items, true);
                }
                if(!ParameterSetName.Equals(AllPageSet) && response.OpcNextPage != null)
                {
                    WriteWarning("This operation supports pagination and not all resources were returned.  Re-run using the -all option to auto paginate and list all resources.");
                }
                FinishProcessing(response);
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
            IEnumerable<ListLogGroupsResponse> DefaultRequest(ListLogGroupsRequest request) => Enumerable.Repeat(client.ListLogGroups(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListLogGroupsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListLogGroupsResponse response;
        private delegate IEnumerable<ListLogGroupsResponse> RequestDelegate(ListLogGroupsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
