/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
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
    [Cmdlet("Get", "OCIVirtualNetworkIPSecConnectionTunnelRoutesList")]
    [OutputType(new System.Type[] { typeof(Oci.CoreService.Models.TunnelRouteSummary), typeof(Oci.CoreService.Responses.ListIPSecConnectionTunnelRoutesResponse) })]
    public class GetOCIVirtualNetworkIPSecConnectionTunnelRoutesList : OCIVirtualNetworkCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the IPSec connection.")]
        public string IpscId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the tunnel.")]
        public string TunnelId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).

Example: `50`", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the advertiser of the routes. If set to `ORACLE`, this returns only the routes advertised by Oracle. When set to `CUSTOMER`, this returns only the routes advertised by the CPE.")]
        public System.Nullable<Oci.CoreService.Models.TunnelRouteSummary.AdvertiserEnum> Advertiser { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListIPSecConnectionTunnelRoutesRequest request;

            try
            {
                request = new ListIPSecConnectionTunnelRoutesRequest
                {
                    IpscId = IpscId,
                    TunnelId = TunnelId,
                    Limit = Limit,
                    Page = Page,
                    Advertiser = Advertiser
                };
                IEnumerable<ListIPSecConnectionTunnelRoutesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.Items, true);
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
            IEnumerable<ListIPSecConnectionTunnelRoutesResponse> DefaultRequest(ListIPSecConnectionTunnelRoutesRequest request) => Enumerable.Repeat(client.ListIPSecConnectionTunnelRoutes(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListIPSecConnectionTunnelRoutesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListIPSecConnectionTunnelRoutesResponse response;
        private delegate IEnumerable<ListIPSecConnectionTunnelRoutesResponse> RequestDelegate(ListIPSecConnectionTunnelRoutesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
