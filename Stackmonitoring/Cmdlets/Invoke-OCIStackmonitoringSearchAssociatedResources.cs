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
    [Cmdlet("Invoke", "OCIStackmonitoringSearchAssociatedResources")]
    [OutputType(new System.Type[] { typeof(Oci.StackmonitoringService.Models.AssociatedResourcesCollection), typeof(Oci.StackmonitoringService.Responses.SearchAssociatedResourcesResponse) })]
    public class InvokeOCIStackmonitoringSearchAssociatedResources : OCIStackMonitoringCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Search Criteria for the listing the monitored resources for given type and compartmentId.")]
        public SearchAssociatedResourcesDetails SearchAssociatedResourcesDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Partial response refers to an optimization technique offered by the RESTful web APIs, to return only the information (fields) required by the client. In this mechanism, the client sends the required field names as the query parameters for an API to the server, and the server trims down the default response content by removing the fields that are not required by the client. The parameter controls which fields to return and should be a query string parameter called ""fields"" of an array type, provide the values as enums, and use collectionFormat.")]
        public System.Collections.Generic.List<string> Fields { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Partial response refers to an optimization technique offered by the RESTful web APIs, to return all the information except the fields requested to be excluded (excludeFields) by the client. In this mechanism, the client sends the exclude field names as the query parameters for an API to the server, and the server trims down the default response content by removing the fields that are not required by the client. The parameter controls which fields to exlude and to return and should be a query string parameter called ""excludeFields"" of an array type, provide the values as enums, and use collectionFormat.")]
        public System.Collections.Generic.List<string> ExcludeFields { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SearchAssociatedResourcesRequest request;

            try
            {
                request = new SearchAssociatedResourcesRequest
                {
                    SearchAssociatedResourcesDetails = SearchAssociatedResourcesDetails,
                    Fields = Fields,
                    ExcludeFields = ExcludeFields,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken,
                    IfMatch = IfMatch,
                    Limit = Limit,
                    Page = Page
                };

                response = client.SearchAssociatedResources(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AssociatedResourcesCollection);
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

        private SearchAssociatedResourcesResponse response;
    }
}
