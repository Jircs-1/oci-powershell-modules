/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220901
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.OsmanagementhubService.Requests;
using Oci.OsmanagementhubService.Responses;
using Oci.OsmanagementhubService.Models;
using Oci.Common.Model;

namespace Oci.OsmanagementhubService.Cmdlets
{
    [Cmdlet("Get", "OCIOsmanagementhubErrataList")]
    [OutputType(new System.Type[] { typeof(Oci.OsmanagementhubService.Models.ErratumCollection), typeof(Oci.OsmanagementhubService.Responses.ListErrataResponse) })]
    public class GetOCIOsmanagementhubErrataList : OCISoftwareSourceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment that contains the resources to list. This parameter is required.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The assigned erratum name. It's unique and not changeable.

Example: `ELSA-2020-5804`")]
        public System.Collections.Generic.List<string> Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return resources that may partially match the erratum name given.")]
        public string NameContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only packages that match the given update classification type.")]
        public System.Collections.Generic.List<Oci.OsmanagementhubService.Models.ClassificationTypes> ClassificationType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only profiles that match the given osFamily.")]
        public System.Nullable<Oci.OsmanagementhubService.Models.OsFamily> OsFamily { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The advisory severity.")]
        public System.Collections.Generic.List<Oci.OsmanagementhubService.Models.AdvisorySeverity> AdvisorySeverity { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The issue date after which to list all errata, in ISO 8601 format

Example: 2017-07-14T02:40:00.000Z")]
        public System.Nullable<System.DateTime> TimeIssueDateStart { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The issue date before which to list all errata, in ISO 8601 format

Example: 2017-07-14T02:40:00.000Z")]
        public System.Nullable<System.DateTime> TimeIssueDateEnd { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).

Example: `50`", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).

Example: `3`")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.OsmanagementhubService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort errata by. Only one sort order may be provided. Default order for timeIssued is descending. Default order for name is ascending. If no value is specified timeIssued is default.")]
        public System.Nullable<Oci.OsmanagementhubService.Requests.ListErrataRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListErrataRequest request;

            try
            {
                request = new ListErrataRequest
                {
                    CompartmentId = CompartmentId,
                    Name = Name,
                    NameContains = NameContains,
                    ClassificationType = ClassificationType,
                    OsFamily = OsFamily,
                    AdvisorySeverity = AdvisorySeverity,
                    TimeIssueDateStart = TimeIssueDateStart,
                    TimeIssueDateEnd = TimeIssueDateEnd,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListErrataResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.ErratumCollection, true);
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
            IEnumerable<ListErrataResponse> DefaultRequest(ListErrataRequest request) => Enumerable.Repeat(client.ListErrata(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListErrataResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListErrataResponse response;
        private delegate IEnumerable<ListErrataResponse> RequestDelegate(ListErrataRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
