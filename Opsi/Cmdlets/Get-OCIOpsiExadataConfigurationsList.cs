/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.OpsiService.Requests;
using Oci.OpsiService.Responses;
using Oci.OpsiService.Models;
using Oci.Common.Model;

namespace Oci.OpsiService.Cmdlets
{
    [Cmdlet("Get", "OCIOpsiExadataConfigurationsList")]
    [OutputType(new System.Type[] { typeof(Oci.OpsiService.Models.ExadataConfigurationCollection), typeof(Oci.OpsiService.Responses.ListExadataConfigurationsResponse) })]
    public class GetOCIOpsiExadataConfigurationsList : OCIOperationsInsightsCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Optional list of exadata insight resource [OCIDs](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm).")]
        public System.Collections.Generic.List<string> ExadataInsightId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter by one or more Exadata types. Possible value are DBMACHINE, EXACS, and EXACC.")]
        public System.Collections.Generic.List<string> ExadataType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/Content/API/Concepts/usingapi.htm#nine). Example: `50`", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.OpsiService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Exadata configuration list sort options. If `fields` parameter is selected, the `sortBy` parameter must be one of the fields specified.")]
        public System.Nullable<Oci.OpsiService.Requests.ListExadataConfigurationsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A list of tag filters to apply.  Only resources with a defined tag matching the value will be returned. Each item in the list has the format ""{namespace}.{tagName}.{value}"".  All inputs are case-insensitive. Multiple values for the same key (i.e. same namespace and tag name) are interpreted as ""OR"". Values for different keys (i.e. different namespaces, different tag names, or both) are interpreted as ""AND"".")]
        public System.Collections.Generic.List<string> DefinedTagEquals { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A list of tag filters to apply.  Only resources with a freeform tag matching the value will be returned. The key for each tag is ""{tagName}.{value}"".  All inputs are case-insensitive. Multiple values for the same tag name are interpreted as ""OR"".  Values for different tag names are interpreted as ""AND"".")]
        public System.Collections.Generic.List<string> FreeformTagEquals { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A list of tag existence filters to apply.  Only resources for which the specified defined tags exist will be returned. Each item in the list has the format ""{namespace}.{tagName}.true"" (for checking existence of a defined tag) or ""{namespace}.true"".  All inputs are case-insensitive. Currently, only existence (""true"" at the end) is supported. Absence (""false"" at the end) is not supported. Multiple values for the same key (i.e. same namespace and tag name) are interpreted as ""OR"". Values for different keys (i.e. different namespaces, different tag names, or both) are interpreted as ""AND"".")]
        public System.Collections.Generic.List<string> DefinedTagExists { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A list of tag existence filters to apply.  Only resources for which the specified freeform tags exist the value will be returned. The key for each tag is ""{tagName}.true"".  All inputs are case-insensitive. Currently, only existence (""true"" at the end) is supported. Absence (""false"" at the end) is not supported. Multiple values for different tag names are interpreted as ""AND"".")]
        public System.Collections.Generic.List<string> FreeformTagExists { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListExadataConfigurationsRequest request;

            try
            {
                request = new ListExadataConfigurationsRequest
                {
                    CompartmentId = CompartmentId,
                    ExadataInsightId = ExadataInsightId,
                    ExadataType = ExadataType,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    DefinedTagEquals = DefinedTagEquals,
                    FreeformTagEquals = FreeformTagEquals,
                    DefinedTagExists = DefinedTagExists,
                    FreeformTagExists = FreeformTagExists,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListExadataConfigurationsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.ExadataConfigurationCollection, true);
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
            IEnumerable<ListExadataConfigurationsResponse> DefaultRequest(ListExadataConfigurationsRequest request) => Enumerable.Repeat(client.ListExadataConfigurations(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListExadataConfigurationsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListExadataConfigurationsResponse response;
        private delegate IEnumerable<ListExadataConfigurationsResponse> RequestDelegate(ListExadataConfigurationsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
