/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220421
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.AdmService.Requests;
using Oci.AdmService.Responses;
using Oci.AdmService.Models;
using Oci.Common.Model;

namespace Oci.AdmService.Cmdlets
{
    [Cmdlet("Get", "OCIAdmApplicationDependencyRecommendationsList")]
    [OutputType(new System.Type[] { typeof(Oci.AdmService.Models.ApplicationDependencyRecommendationCollection), typeof(Oci.AdmService.Responses.ListApplicationDependencyRecommendationsResponse) })]
    public class GetOCIAdmApplicationDependencyRecommendationsList : OCIApplicationDependencyManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Remediation Run identifier path parameter.")]
        public string RemediationRunId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from the `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.AdmService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the entire GAV (Group Artifact Version) identifier given.")]
        public string Gav { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. If sort order is dfs, the nodes are returned by going through the application dependency tree in a depth-first manner. Children are sorted based on their GAV property alphabetically (either ascending or descending, depending on the order parameter). Default order is ascending. If sort order is bfs, the nodes are returned by going through the application dependency tree in a breadth-first manner. Children are sorted based on their GAV property alphabetically (either ascending or descending, depending on the order parameter). Default order is ascending. Default order for gav is ascending where ascending corresponds to alphanumerical order. Default order for nodeId is ascending where ascending corresponds to alphanumerical order. Sorting by DFS or BFS cannot be used in conjunction with the following query parameters: ""gav"", ""cvssV2GreaterThanOrEqual"", ""cvssV3GreaterThanOrEqual"" and ""vulnerabilityId"".")]
        public System.Nullable<Oci.AdmService.Requests.ListApplicationDependencyRecommendationsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListApplicationDependencyRecommendationsRequest request;

            try
            {
                request = new ListApplicationDependencyRecommendationsRequest
                {
                    RemediationRunId = RemediationRunId,
                    OpcRequestId = OpcRequestId,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    Gav = Gav,
                    SortBy = SortBy
                };
                IEnumerable<ListApplicationDependencyRecommendationsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.ApplicationDependencyRecommendationCollection, true);
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
            IEnumerable<ListApplicationDependencyRecommendationsResponse> DefaultRequest(ListApplicationDependencyRecommendationsRequest request) => Enumerable.Repeat(client.ListApplicationDependencyRecommendations(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListApplicationDependencyRecommendationsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListApplicationDependencyRecommendationsResponse response;
        private delegate IEnumerable<ListApplicationDependencyRecommendationsResponse> RequestDelegate(ListApplicationDependencyRecommendationsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
