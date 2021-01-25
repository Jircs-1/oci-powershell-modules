/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.CoreService.Requests;
using Oci.CoreService.Responses;
using Oci.CoreService.Models;

namespace Oci.CoreService.Cmdlets
{
    [Cmdlet("Get", "OCIVirtualNetworkVirtualCircuitBandwidthShapesList")]
    [OutputType(new System.Type[] { typeof(Oci.CoreService.Models.VirtualCircuitBandwidthShape), typeof(Oci.CoreService.Responses.ListVirtualCircuitBandwidthShapesResponse) })]
    public class GetOCIVirtualNetworkVirtualCircuitBandwidthShapesList : OCIVirtualNetworkCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).

Example: `50`", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListVirtualCircuitBandwidthShapesRequest request;

            try
            {
                request = new ListVirtualCircuitBandwidthShapesRequest
                {
                    CompartmentId = CompartmentId,
                    Limit = Limit,
                    Page = Page
                };
                IEnumerable<ListVirtualCircuitBandwidthShapesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.Items, true);
                }
                if(!ParameterSetName.Equals(AllPageSet) && response.OpcNextPage != null)
                {
                    WriteWarning("This operation supports pagination and not all resources were returned.  Re-run using the -all option to auto paginate and list all resources.");
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
            IEnumerable<ListVirtualCircuitBandwidthShapesResponse> DefaultRequest(ListVirtualCircuitBandwidthShapesRequest request) => Enumerable.Repeat(client.ListVirtualCircuitBandwidthShapes(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListVirtualCircuitBandwidthShapesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListVirtualCircuitBandwidthShapesResponse response;
        private delegate IEnumerable<ListVirtualCircuitBandwidthShapesResponse> RequestDelegate(ListVirtualCircuitBandwidthShapesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
