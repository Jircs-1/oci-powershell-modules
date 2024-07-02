/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20170907
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.EmailService.Requests;
using Oci.EmailService.Responses;
using Oci.EmailService.Models;
using Oci.Common.Model;

namespace Oci.EmailService.Cmdlets
{
    [Cmdlet("Get", "OCIEmailReturnPathsList")]
    [OutputType(new System.Type[] { typeof(Oci.EmailService.Models.EmailReturnPathCollection), typeof(Oci.EmailService.Responses.ListEmailReturnPathsResponse) })]
    public class GetOCIEmailReturnPathsList : OCIEmailCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The request ID for tracing from the system")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID for the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the Email Domain to which this Email Return Path belongs.")]
        public string ParentResourceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to only return resources that match the given id exactly.")]
        public string Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to only return resources that match the given name exactly.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. `1` is the minimum, `1000` is the maximum. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the opc-next-page response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending or descending order.")]
        public System.Nullable<Oci.EmailService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter returned list by specified lifecycle state. This parameter is case-insensitive.")]
        public System.Nullable<Oci.EmailService.Models.EmailReturnPath.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the attribute with which to sort the return paths.

Default: `TIMECREATED`

* **TIMECREATED:** Sorts by timeCreated. * **NAME:** Sorts by name. * **ID:** Sorts by id.")]
        public System.Nullable<Oci.EmailService.Requests.ListEmailReturnPathsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListEmailReturnPathsRequest request;

            try
            {
                request = new ListEmailReturnPathsRequest
                {
                    OpcRequestId = OpcRequestId,
                    CompartmentId = CompartmentId,
                    ParentResourceId = ParentResourceId,
                    Id = Id,
                    Name = Name,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    LifecycleState = LifecycleState,
                    SortBy = SortBy
                };
                IEnumerable<ListEmailReturnPathsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.EmailReturnPathCollection, true);
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
            IEnumerable<ListEmailReturnPathsResponse> DefaultRequest(ListEmailReturnPathsRequest request) => Enumerable.Repeat(client.ListEmailReturnPaths(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListEmailReturnPathsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListEmailReturnPathsResponse response;
        private delegate IEnumerable<ListEmailReturnPathsResponse> RequestDelegate(ListEmailReturnPathsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}