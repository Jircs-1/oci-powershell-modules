/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DatasafeService.Requests;
using Oci.DatasafeService.Responses;
using Oci.DatasafeService.Models;
using Oci.Common.Model;

namespace Oci.DatasafeService.Cmdlets
{
    [Cmdlet("Get", "OCIDatasafeFindingsList")]
    [OutputType(new System.Type[] { typeof(Oci.DatasafeService.Models.FindingSummary), typeof(Oci.DatasafeService.Responses.ListFindingsResponse) })]
    public class GetOCIDatasafeFindingsList : OCIDataSafeCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the security assessment.")]
        public string SecurityAssessmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only the findings that are marked as top findings.")]
        public System.Nullable<bool> IsTopFinding { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only findings of a particular risk level.")]
        public System.Nullable<Oci.DatasafeService.Requests.ListFindingsRequest.SeverityEnum> Severity { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only the findings that match the specified lifecycle states.")]
        public System.Nullable<Oci.DatasafeService.Models.FindingLifecycleState> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"An optional filter to return only findings that match the specified reference.")]
        public System.Nullable<Oci.DatasafeService.Models.SecurityAssessmentReferences> References { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of items to return per page in a paginated ""List"" call. For details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/en-us/iaas/Content/API/Concepts/usingapi.htm#nine).", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The page token representing the page at which to start retrieving results. It is usually retrieved from a previous ""List"" call. For details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/en-us/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Default is false. When set to true, the hierarchy of compartments is traversed and all compartments and subcompartments in the tenancy are returned. Depends on the 'accessLevel' setting.")]
        public System.Nullable<bool> CompartmentIdInSubtree { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Valid values are RESTRICTED and ACCESSIBLE. Default is RESTRICTED. Setting this to ACCESSIBLE returns only those compartments for which the user has INSPECT permissions directly or indirectly (permissions can be on a resource in a subcompartment). When set to RESTRICTED permissions are checked and no partial results are displayed.")]
        public System.Nullable<Oci.DatasafeService.Requests.ListFindingsRequest.AccessLevelEnum> AccessLevel { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Each finding in security assessment has an associated key (think of key as a finding's name). For a given finding, the key will be the same across targets. The user can use these keys to filter the findings.")]
        public string FindingKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListFindingsRequest request;

            try
            {
                request = new ListFindingsRequest
                {
                    SecurityAssessmentId = SecurityAssessmentId,
                    OpcRequestId = OpcRequestId,
                    IsTopFinding = IsTopFinding,
                    Severity = Severity,
                    LifecycleState = LifecycleState,
                    References = References,
                    Limit = Limit,
                    Page = Page,
                    CompartmentIdInSubtree = CompartmentIdInSubtree,
                    AccessLevel = AccessLevel,
                    FindingKey = FindingKey
                };
                IEnumerable<ListFindingsResponse> responses = GetRequestDelegate().Invoke(request);
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
            IEnumerable<ListFindingsResponse> DefaultRequest(ListFindingsRequest request) => Enumerable.Repeat(client.ListFindings(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListFindingsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListFindingsResponse response;
        private delegate IEnumerable<ListFindingsResponse> RequestDelegate(ListFindingsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
