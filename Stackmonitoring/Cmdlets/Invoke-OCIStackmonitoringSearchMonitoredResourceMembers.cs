/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210330
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.StackmonitoringService.Requests;
using Oci.StackmonitoringService.Responses;
using Oci.StackmonitoringService.Models;
using Oci.Common.Model;

namespace Oci.StackmonitoringService.Cmdlets
{
    [Cmdlet("Invoke", "OCIStackmonitoringSearchMonitoredResourceMembers")]
    [OutputType(new System.Type[] { typeof(Oci.StackmonitoringService.Models.MonitoredResourceMembersCollection), typeof(Oci.StackmonitoringService.Responses.SearchMonitoredResourceMembersResponse) })]
    public class InvokeOCIStackmonitoringSearchMonitoredResourceMembers : OCIStackMonitoringCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of monitored resource.")]
        public string MonitoredResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Search criteria for the listing the member monitored resources.")]
        public SearchMonitoredResourceMembersDetails SearchMonitoredResourceMembersDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"If this query parameter is specified, the result is sorted by this query parameter value.")]
        public System.Nullable<Oci.StackmonitoringService.Requests.SearchMonitoredResourceMembersRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.StackmonitoringService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SearchMonitoredResourceMembersRequest request;

            try
            {
                request = new SearchMonitoredResourceMembersRequest
                {
                    MonitoredResourceId = MonitoredResourceId,
                    SearchMonitoredResourceMembersDetails = SearchMonitoredResourceMembersDetails,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    Page = Page,
                    Limit = Limit,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.SearchMonitoredResourceMembers(request).GetAwaiter().GetResult();
                WriteOutput(response, response.MonitoredResourceMembersCollection);
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

        private SearchMonitoredResourceMembersResponse response;
    }
}
