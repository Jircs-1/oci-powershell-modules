/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.IdentityService.Requests;
using Oci.IdentityService.Responses;
using Oci.IdentityService.Models;

namespace Oci.IdentityService.Cmdlets
{
    [Cmdlet("Get", "OCIIdentityDomainsList")]
    [OutputType(new System.Type[] { typeof(Oci.IdentityService.Models.DomainSummary), typeof(Oci.IdentityService.Responses.ListDomainsResponse) })]
    public class GetOCIIdentityDomainsList : OCIIdentityCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment (remember that the tenancy is simply the root compartment).")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The mutable display name of the domain")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The region agnostic domain URL")]
        public string Url { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The region specific domain URL")]
        public string HomeRegionUrl { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The domain type")]
        public string Type { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The domain license type")]
        public string LicenseType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Indicate if the domain is visible at login screen or not")]
        public System.Nullable<bool> IsHiddenOnLogin { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The value of the `opc-next-page` response header from the previous ""List"" call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return in a paginated ""List"" call.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to only return resources that match the given name exactly.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. You can provide one sort order (`sortOrder`). Default order for TIMECREATED is descending. Default order for NAME is ascending. The NAME sort order is case sensitive.

**Note:** In general, some ""List"" operations (for example, `ListInstances`) let you optionally filter by Availability Domain if the scope of the resource type is within a single Availability Domain. If you call one of these ""List"" operations without specifying an Availability Domain, the resources are grouped by Availability Domain, then sorted.")]
        public System.Nullable<Oci.IdentityService.Requests.ListDomainsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`). The NAME sort order is case sensitive.")]
        public System.Nullable<Oci.IdentityService.Requests.ListDomainsRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to only return resources that match the given lifecycle state.  The state value is case-insensitive.")]
        public System.Nullable<Oci.IdentityService.Models.Domain.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListDomainsRequest request;

            try
            {
                request = new ListDomainsRequest
                {
                    CompartmentId = CompartmentId,
                    DisplayName = DisplayName,
                    Url = Url,
                    HomeRegionUrl = HomeRegionUrl,
                    Type = Type,
                    LicenseType = LicenseType,
                    IsHiddenOnLogin = IsHiddenOnLogin,
                    Page = Page,
                    Limit = Limit,
                    Name = Name,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    OpcRequestId = OpcRequestId,
                    LifecycleState = LifecycleState
                };
                IEnumerable<ListDomainsResponse> responses = GetRequestDelegate().Invoke(request);
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
            IEnumerable<ListDomainsResponse> DefaultRequest(ListDomainsRequest request) => Enumerable.Repeat(client.ListDomains(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListDomainsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListDomainsResponse response;
        private delegate IEnumerable<ListDomainsResponse> RequestDelegate(ListDomainsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}