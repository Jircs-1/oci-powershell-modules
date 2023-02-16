/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.AianomalydetectionService.Requests;
using Oci.AianomalydetectionService.Responses;
using Oci.AianomalydetectionService.Models;
using Oci.Common.Model;

namespace Oci.AianomalydetectionService.Cmdlets
{
    [Cmdlet("Get", "OCIAianomalydetectionDetectAnomalyJobsList")]
    [OutputType(new System.Type[] { typeof(Oci.AianomalydetectionService.Models.DetectAnomalyJobCollection), typeof(Oci.AianomalydetectionService.Responses.ListDetectAnomalyJobsResponse) })]
    public class GetOCIAianomalydetectionDetectAnomalyJobsList : OCIAnomalyDetectionCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the trained model for which to list the resources.")]
        public string ModelId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the project for which to list the objects.")]
        public string ProjectId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Async Job identifier")]
        public string DetectAnomalyJobId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"<b>Filter</b> results by the specified lifecycle state. Must be a valid state for the resource type.")]
        public System.Nullable<Oci.AianomalydetectionService.Models.DetectAnomalyJob.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the entire display name given.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.AianomalydetectionService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. Default order for displayName is ascending. If no value is specified timeCreated is default.")]
        public System.Nullable<Oci.AianomalydetectionService.Requests.ListDetectAnomalyJobsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListDetectAnomalyJobsRequest request;

            try
            {
                request = new ListDetectAnomalyJobsRequest
                {
                    CompartmentId = CompartmentId,
                    ModelId = ModelId,
                    ProjectId = ProjectId,
                    DetectAnomalyJobId = DetectAnomalyJobId,
                    LifecycleState = LifecycleState,
                    DisplayName = DisplayName,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListDetectAnomalyJobsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.DetectAnomalyJobCollection, true);
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
            IEnumerable<ListDetectAnomalyJobsResponse> DefaultRequest(ListDetectAnomalyJobsRequest request) => Enumerable.Repeat(client.ListDetectAnomalyJobs(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListDetectAnomalyJobsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListDetectAnomalyJobsResponse response;
        private delegate IEnumerable<ListDetectAnomalyJobsResponse> RequestDelegate(ListDetectAnomalyJobsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
