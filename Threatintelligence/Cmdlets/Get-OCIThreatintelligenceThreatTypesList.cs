/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220901
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.ThreatintelligenceService.Requests;
using Oci.ThreatintelligenceService.Responses;
using Oci.ThreatintelligenceService.Models;
using Oci.Common.Model;

namespace Oci.ThreatintelligenceService.Cmdlets
{
    [Cmdlet("Get", "OCIThreatintelligenceThreatTypesList")]
    [OutputType(new System.Type[] { typeof(Oci.ThreatintelligenceService.Models.ThreatTypesCollection), typeof(Oci.ThreatintelligenceService.Responses.ListThreatTypesResponse) })]
    public class GetOCIThreatintelligenceThreatTypesList : OCIThreatintelCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the tenancy (root compartment) that is used to filter results.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from the `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.ThreatintelligenceService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListThreatTypesRequest request;

            try
            {
                request = new ListThreatTypesRequest
                {
                    CompartmentId = CompartmentId,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListThreatTypesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.ThreatTypesCollection, true);
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
            IEnumerable<ListThreatTypesResponse> DefaultRequest(ListThreatTypesRequest request) => Enumerable.Repeat(client.ListThreatTypes(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListThreatTypesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListThreatTypesResponse response;
        private delegate IEnumerable<ListThreatTypesResponse> RequestDelegate(ListThreatTypesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
