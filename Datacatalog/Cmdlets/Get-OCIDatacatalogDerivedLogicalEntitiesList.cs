/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190325
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatacatalogService.Requests;
using Oci.DatacatalogService.Responses;
using Oci.DatacatalogService.Models;
using Oci.Common.Model;

namespace Oci.DatacatalogService.Cmdlets
{
    [Cmdlet("Get", "OCIDatacatalogDerivedLogicalEntitiesList")]
    [OutputType(new System.Type[] { typeof(Oci.DatacatalogService.Models.EntityCollection), typeof(Oci.DatacatalogService.Responses.ListDerivedLogicalEntitiesResponse) })]
    public class GetOCIDatacatalogDerivedLogicalEntitiesList : OCIDataCatalogCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique catalog identifier.")]
        public string CatalogId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique pattern key.")]
        public string PatternKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match display name pattern given. The match is not case sensitive. For Example : /folders?displayNameContains=Cu.* The above would match all folders with display name that starts with ""Cu"" or has the pattern ""Cu"" anywhere in between.")]
        public string DisplayNameContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for TIMECREATED is descending. Default order for DISPLAYNAME is ascending. If no value is specified TIMECREATED is default.")]
        public System.Nullable<Oci.DatacatalogService.Requests.ListDerivedLogicalEntitiesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.DatacatalogService.Requests.ListDerivedLogicalEntitiesRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListDerivedLogicalEntitiesRequest request;

            try
            {
                request = new ListDerivedLogicalEntitiesRequest
                {
                    CatalogId = CatalogId,
                    PatternKey = PatternKey,
                    DisplayNameContains = DisplayNameContains,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.ListDerivedLogicalEntities(request).GetAwaiter().GetResult();
                WriteOutput(response, response.EntityCollection);
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

        private ListDerivedLogicalEntitiesResponse response;
    }
}
