/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210330
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.AppmgmtcontrolService.Requests;
using Oci.AppmgmtcontrolService.Responses;
using Oci.AppmgmtcontrolService.Models;
using Oci.Common.Model;

namespace Oci.AppmgmtcontrolService.Cmdlets
{
    [Cmdlet("Get", "OCIAppmgmtcontrolMonitoredInstancesList")]
    [OutputType(new System.Type[] { typeof(Oci.AppmgmtcontrolService.Models.MonitoredInstanceCollection), typeof(Oci.AppmgmtcontrolService.Responses.ListMonitoredInstancesResponse) })]
    public class GetOCIAppmgmtcontrolMonitoredInstancesList : OCIAppmgmtControlCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the entire display name given.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending ('ASC') or descending ('DESC').")]
        public System.Nullable<Oci.AppmgmtcontrolService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. Default order for displayName is ascending. If no value is specified timeCreated is default.")]
        public System.Nullable<Oci.AppmgmtcontrolService.Requests.ListMonitoredInstancesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListMonitoredInstancesRequest request;

            try
            {
                request = new ListMonitoredInstancesRequest
                {
                    CompartmentId = CompartmentId,
                    DisplayName = DisplayName,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListMonitoredInstancesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.MonitoredInstanceCollection, true);
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
            IEnumerable<ListMonitoredInstancesResponse> DefaultRequest(ListMonitoredInstancesRequest request) => Enumerable.Repeat(client.ListMonitoredInstances(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListMonitoredInstancesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListMonitoredInstancesResponse response;
        private delegate IEnumerable<ListMonitoredInstancesResponse> RequestDelegate(ListMonitoredInstancesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
