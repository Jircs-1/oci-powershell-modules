/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220430
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.LicensemanagerService.Requests;
using Oci.LicensemanagerService.Responses;
using Oci.LicensemanagerService.Models;
using Oci.Common.Model;

namespace Oci.LicensemanagerService.Cmdlets
{
    [Cmdlet("Get", "OCILicensemanagerProductLicensesList")]
    [OutputType(new System.Type[] { typeof(Oci.LicensemanagerService.Models.ProductLicenseCollection), typeof(Oci.LicensemanagerService.Responses.ListProductLicensesResponse) })]
    public class GetOCILicensemanagerProductLicensesList : OCILicenseManagerCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The compartment [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) used for the license record, product license, and configuration.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from the `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Indicates if the given compartment is the root compartment.")]
        public System.Nullable<bool> IsCompartmentIdInSubtree { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, whether `ASC` or `DESC`.")]
        public System.Nullable<Oci.LicensemanagerService.Requests.ListProductLicensesRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the attribute with which to sort the rules.

Default: `totalLicenseUnitsConsumed`

* **totalLicenseUnitsConsumed:** Sorts by totalLicenseUnitsConsumed of ProductLicense.")]
        public System.Nullable<Oci.LicensemanagerService.Requests.ListProductLicensesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListProductLicensesRequest request;

            try
            {
                request = new ListProductLicensesRequest
                {
                    CompartmentId = CompartmentId,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId,
                    IsCompartmentIdInSubtree = IsCompartmentIdInSubtree,
                    SortOrder = SortOrder,
                    SortBy = SortBy
                };
                IEnumerable<ListProductLicensesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.ProductLicenseCollection, true);
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
            IEnumerable<ListProductLicensesResponse> DefaultRequest(ListProductLicensesRequest request) => Enumerable.Repeat(client.ListProductLicenses(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListProductLicensesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListProductLicensesResponse response;
        private delegate IEnumerable<ListProductLicensesResponse> RequestDelegate(ListProductLicensesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
