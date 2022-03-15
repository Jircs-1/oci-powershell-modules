/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210929
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DatabasemigrationService.Requests;
using Oci.DatabasemigrationService.Responses;
using Oci.DatabasemigrationService.Models;

namespace Oci.DatabasemigrationService.Cmdlets
{
    [Cmdlet("Get", "OCIDatabasemigrationExcludedObjectsList")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemigrationService.Models.ExcludedObjectSummaryCollection), typeof(Oci.DatabasemigrationService.Responses.ListExcludedObjectsResponse) })]
    public class GetOCIDatabasemigrationExcludedObjectsList : OCIDatabaseMigrationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the job")]
        public string JobId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.DatabasemigrationService.Models.SortOrders> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for reasonCategory is ascending. If no value is specified reasonCategory is default.")]
        public System.Nullable<Oci.DatabasemigrationService.Requests.ListExcludedObjectsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Excluded object type.")]
        public string Type { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Excluded object owner")]
        public string Owner { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Excluded object name")]
        public string Object { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Excluded object owner which contains provided value.")]
        public string OwnerContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Excluded object name which contains provided value.")]
        public string ObjectContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Reason category for the excluded object")]
        public System.Nullable<Oci.DatabasemigrationService.Models.ReasonKeywords> ReasonCategory { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Exclude object rule that matches the excluded object, if applicable.")]
        public string SourceRule { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListExcludedObjectsRequest request;

            try
            {
                request = new ListExcludedObjectsRequest
                {
                    JobId = JobId,
                    OpcRequestId = OpcRequestId,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    Type = Type,
                    Owner = Owner,
                    Object = Object,
                    OwnerContains = OwnerContains,
                    ObjectContains = ObjectContains,
                    ReasonCategory = ReasonCategory,
                    SourceRule = SourceRule
                };
                IEnumerable<ListExcludedObjectsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.ExcludedObjectSummaryCollection, true);
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
            IEnumerable<ListExcludedObjectsResponse> DefaultRequest(ListExcludedObjectsRequest request) => Enumerable.Repeat(client.ListExcludedObjects(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListExcludedObjectsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListExcludedObjectsResponse response;
        private delegate IEnumerable<ListExcludedObjectsResponse> RequestDelegate(ListExcludedObjectsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}