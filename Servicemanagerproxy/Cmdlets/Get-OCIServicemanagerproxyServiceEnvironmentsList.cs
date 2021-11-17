/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210914
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.ServicemanagerproxyService.Requests;
using Oci.ServicemanagerproxyService.Responses;
using Oci.ServicemanagerproxyService.Models;

namespace Oci.ServicemanagerproxyService.Cmdlets
{
    [Cmdlet("Get", "OCIServicemanagerproxyServiceEnvironmentsList")]
    [OutputType(new System.Type[] { typeof(Oci.ServicemanagerproxyService.Models.ServiceEnvironmentCollection), typeof(Oci.ServicemanagerproxyService.Responses.ListServiceEnvironmentsResponse) })]
    public class GetOCIServicemanagerproxyServiceEnvironmentsList : OCIServiceManagerProxyCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier for the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Id associated with the service environment.")]
        public string ServiceEnvironmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The service definition type of the environment.")]
        public string ServiceEnvironmentType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"How many records to return. Specify a value greater than zero and less than or equal to 1000. The default is 30.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The value of the `opc-next-page` response header from the previous ""List"" call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. ID is default ordered as ascending.")]
        public System.Nullable<Oci.ServicemanagerproxyService.Requests.ListServiceEnvironmentsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either `ASC` or `DESC`.")]
        public System.Nullable<Oci.ServicemanagerproxyService.Requests.ListServiceEnvironmentsRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The display name of the resource.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListServiceEnvironmentsRequest request;

            try
            {
                request = new ListServiceEnvironmentsRequest
                {
                    CompartmentId = CompartmentId,
                    ServiceEnvironmentId = ServiceEnvironmentId,
                    ServiceEnvironmentType = ServiceEnvironmentType,
                    OpcRequestId = OpcRequestId,
                    Limit = Limit,
                    Page = Page,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    DisplayName = DisplayName
                };
                IEnumerable<ListServiceEnvironmentsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.ServiceEnvironmentCollection, true);
                }
                if(!ParameterSetName.Equals(AllPageSet) && !ParameterSetName.Equals(LimitSet) && response.OpcNextPage != null)
                {
                    WriteWarning("This operation supports pagination and not all resources were returned. Re-run using the -All option to auto paginate and list all resources.");
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
            IEnumerable<ListServiceEnvironmentsResponse> DefaultRequest(ListServiceEnvironmentsRequest request) => Enumerable.Repeat(client.ListServiceEnvironments(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListServiceEnvironmentsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListServiceEnvironmentsResponse response;
        private delegate IEnumerable<ListServiceEnvironmentsResponse> RequestDelegate(ListServiceEnvironmentsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
