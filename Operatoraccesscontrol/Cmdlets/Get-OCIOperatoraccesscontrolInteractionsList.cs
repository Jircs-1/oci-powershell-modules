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
using Oci.OperatoraccesscontrolService.Requests;
using Oci.OperatoraccesscontrolService.Responses;
using Oci.OperatoraccesscontrolService.Models;
using Oci.Common.Model;

namespace Oci.OperatoraccesscontrolService.Cmdlets
{
    [Cmdlet("Get", "OCIOperatoraccesscontrolInteractionsList")]
    [OutputType(new System.Type[] { typeof(Oci.OperatoraccesscontrolService.Models.InteractionCollection), typeof(Oci.OperatoraccesscontrolService.Responses.ListInteractionsResponse) })]
    public class GetOCIOperatoraccesscontrolInteractionsList : OCIAccessRequestsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"unique AccessRequest identifier")]
        public string AccessRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListInteractionsRequest request;

            try
            {
                request = new ListInteractionsRequest
                {
                    AccessRequestId = AccessRequestId,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListInteractionsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.InteractionCollection, true);
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
            IEnumerable<ListInteractionsResponse> DefaultRequest(ListInteractionsRequest request) => Enumerable.Repeat(client.ListInteractions(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListInteractionsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListInteractionsResponse response;
        private delegate IEnumerable<ListInteractionsResponse> RequestDelegate(ListInteractionsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
