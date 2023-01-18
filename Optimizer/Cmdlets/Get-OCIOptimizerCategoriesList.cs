/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200606
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.OptimizerService.Requests;
using Oci.OptimizerService.Responses;
using Oci.OptimizerService.Models;
using Oci.Common.Model;

namespace Oci.OptimizerService.Cmdlets
{
    [Cmdlet("Get", "OCIOptimizerCategoriesList")]
    [OutputType(new System.Type[] { typeof(Oci.OptimizerService.Models.CategoryCollection), typeof(Oci.OptimizerService.Responses.ListCategoriesResponse) })]
    public class GetOCIOptimizerCategoriesList : OCIOptimizerCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"When set to true, the hierarchy of compartments is traversed and all compartments and subcompartments in the tenancy are returned depending on the the setting of `accessLevel`.

Can only be set to true when performing ListCompartments on the tenancy (root compartment).")]
        public System.Nullable<bool> CompartmentIdInSubtree { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A list of child tenancies for which the respective data will be returned. Please note that the parent tenancy id can also be included in this list. For example, if there is a parent P with two children A and B, to return results of only parent P and child A, this list should be populated with tenancy id of parent P and child A.

If this list contains a tenancy id that isn't part of the organization of parent P, the request will fail. That is, let's say there is an organization with parent P with children A and B, and also one other tenant T that isn't part of the organization. If T is included in the list of childTenancyIds, the request will fail.

It is important to note that if you are setting the includeOrganization parameter value as true and also populating the childTenancyIds parameter with a list of child tenancies, the request will fail. The childTenancyIds and includeOrganization should be used exclusively.

When using this parameter, please make sure to set the compartmentId with the parent tenancy ID.")]
        public System.Collections.Generic.List<string> ChildTenancyIds { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"When set to true, the data for all child tenancies including the parent is returned. That is, if there is an organization with parent P and children A and B, to return the data for the parent P, child A and child B, this parameter value should be set to true.

Please note that this parameter shouldn't be used along with childTenancyIds parameter. If you would like to get results specifically for parent P and only child A, use the childTenancyIds parameter and populate the list with tenancy id of P and A.

When using this parameter, please make sure to set the compartmentId with the parent tenancy ID.")]
        public System.Nullable<bool> IncludeOrganization { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Optional. A filter that returns results that match the name specified.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return in a paginated ""List"" call.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The value of the `opc-next-page` response header from the previous ""List"" call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.OptimizerService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. You can provide one sort order (`sortOrder`). Default order for TIMECREATED is descending. Default order for NAME is ascending. The NAME sort order is case sensitive.")]
        public System.Nullable<Oci.OptimizerService.Requests.ListCategoriesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter that returns results that match the lifecycle state specified.")]
        public System.Nullable<Oci.OptimizerService.Models.LifecycleState> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListCategoriesRequest request;

            try
            {
                request = new ListCategoriesRequest
                {
                    CompartmentId = CompartmentId,
                    CompartmentIdInSubtree = CompartmentIdInSubtree,
                    ChildTenancyIds = ChildTenancyIds,
                    IncludeOrganization = IncludeOrganization,
                    Name = Name,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    LifecycleState = LifecycleState,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListCategoriesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.CategoryCollection, true);
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
            IEnumerable<ListCategoriesResponse> DefaultRequest(ListCategoriesRequest request) => Enumerable.Repeat(client.ListCategories(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListCategoriesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListCategoriesResponse response;
        private delegate IEnumerable<ListCategoriesResponse> RequestDelegate(ListCategoriesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
