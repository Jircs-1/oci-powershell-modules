/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210330
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.AppmgmtcontrolService.Requests;
using Oci.AppmgmtcontrolService.Responses;
using Oci.AppmgmtcontrolService.Models;
using Oci.Common.Model;

namespace Oci.AppmgmtcontrolService.Cmdlets
{
    [Cmdlet("Get", "OCIAppmgmtcontrolWorkRequestLogsList")]
    [OutputType(new System.Type[] { typeof(Oci.AppmgmtcontrolService.Models.WorkRequestLogEntryCollection), typeof(Oci.AppmgmtcontrolService.Responses.ListWorkRequestLogsResponse) })]
    public class GetOCIAppmgmtcontrolWorkRequestLogsList : OCIAppmgmtControlCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the asynchronous request.")]
        public string WorkRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListWorkRequestLogsRequest request;

            try
            {
                request = new ListWorkRequestLogsRequest
                {
                    WorkRequestId = WorkRequestId,
                    OpcRequestId = OpcRequestId,
                    Page = Page,
                    Limit = Limit
                };
                IEnumerable<ListWorkRequestLogsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.WorkRequestLogEntryCollection, true);
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
            IEnumerable<ListWorkRequestLogsResponse> DefaultRequest(ListWorkRequestLogsRequest request) => Enumerable.Repeat(client.ListWorkRequestLogs(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListWorkRequestLogsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListWorkRequestLogsResponse response;
        private delegate IEnumerable<ListWorkRequestLogsResponse> RequestDelegate(ListWorkRequestLogsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
