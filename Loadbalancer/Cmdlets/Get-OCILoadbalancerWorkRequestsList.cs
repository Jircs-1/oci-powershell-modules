/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20170115
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.LoadbalancerService.Requests;
using Oci.LoadbalancerService.Responses;
using Oci.LoadbalancerService.Models;

namespace Oci.LoadbalancerService.Cmdlets
{
    [Cmdlet("Get", "OCILoadbalancerWorkRequestsList")]
    [OutputType(new System.Type[] { typeof(Oci.LoadbalancerService.Models.WorkRequest), typeof(Oci.LoadbalancerService.Responses.ListWorkRequestsResponse) })]
    public class GetOCILoadbalancerWorkRequestsList : OCILoadBalancerCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the load balancer associated with the work requests to retrieve.")]
        public string LoadBalancerId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).

Example: `50`", ParameterSetName = LimitSet)]
        public System.Nullable<long> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).

Example: `3`")]
        public string Page { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListWorkRequestsRequest request;

            try
            {
                request = new ListWorkRequestsRequest
                {
                    LoadBalancerId = LoadBalancerId,
                    OpcRequestId = OpcRequestId,
                    Limit = Limit,
                    Page = Page
                };
                IEnumerable<ListWorkRequestsResponse> responses = GetRequestDelegate().Invoke(request);
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
            IEnumerable<ListWorkRequestsResponse> DefaultRequest(ListWorkRequestsRequest request) => Enumerable.Repeat(client.ListWorkRequests(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListWorkRequestsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListWorkRequestsResponse response;
        private delegate IEnumerable<ListWorkRequestsResponse> RequestDelegate(ListWorkRequestsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
