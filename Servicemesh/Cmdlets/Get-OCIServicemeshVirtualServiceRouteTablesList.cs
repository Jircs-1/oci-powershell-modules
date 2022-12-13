/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220615
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.ServicemeshService.Requests;
using Oci.ServicemeshService.Responses;
using Oci.ServicemeshService.Models;
using Oci.Common.Model;

namespace Oci.ServicemeshService.Cmdlets
{
    [Cmdlet("Get", "OCIServicemeshVirtualServiceRouteTablesList")]
    [OutputType(new System.Type[] { typeof(Oci.ServicemeshService.Models.VirtualServiceRouteTableCollection), typeof(Oci.ServicemeshService.Responses.ListVirtualServiceRouteTablesResponse) })]
    public class GetOCIServicemeshVirtualServiceRouteTablesList : OCIServiceMeshCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the entire name given.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from the `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.ServicemeshService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for 'timeCreated' is descending. Default order for 'name' is ascending.")]
        public System.Nullable<Oci.ServicemeshService.Requests.ListVirtualServiceRouteTablesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique VirtualService identifier.")]
        public string VirtualServiceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique VirtualServiceRouteTable identifier.")]
        public string Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the life cycle state given.")]
        public System.Nullable<Oci.ServicemeshService.Models.VirtualServiceRouteTable.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListVirtualServiceRouteTablesRequest request;

            try
            {
                request = new ListVirtualServiceRouteTablesRequest
                {
                    CompartmentId = CompartmentId,
                    Name = Name,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId,
                    VirtualServiceId = VirtualServiceId,
                    Id = Id,
                    LifecycleState = LifecycleState
                };
                IEnumerable<ListVirtualServiceRouteTablesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.VirtualServiceRouteTableCollection, true);
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
            IEnumerable<ListVirtualServiceRouteTablesResponse> DefaultRequest(ListVirtualServiceRouteTablesRequest request) => Enumerable.Repeat(client.ListVirtualServiceRouteTables(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListVirtualServiceRouteTablesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListVirtualServiceRouteTablesResponse response;
        private delegate IEnumerable<ListVirtualServiceRouteTablesResponse> RequestDelegate(ListVirtualServiceRouteTablesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
