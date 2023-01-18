/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200407
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.GoldengateService.Requests;
using Oci.GoldengateService.Responses;
using Oci.GoldengateService.Models;
using Oci.Common.Model;

namespace Oci.GoldengateService.Cmdlets
{
    [Cmdlet("Get", "OCIGoldengateDeploymentUpgradesList")]
    [OutputType(new System.Type[] { typeof(Oci.GoldengateService.Models.DeploymentUpgradeCollection), typeof(Oci.GoldengateService.Responses.ListDeploymentUpgradesResponse) })]
    public class GetOCIGoldengateDeploymentUpgradesList : OCIGoldenGateCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the deployment in which to list resources.")]
        public string DeploymentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only the resources that match the 'lifecycleState' given.")]
        public System.Nullable<Oci.GoldengateService.Models.LifecycleState> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only the resources that match the entire 'displayName' given.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.GoldengateService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order can be provided. Default order for 'timeCreated' is descending.  Default order for 'displayName' is ascending. If no value is specified timeCreated is the default.")]
        public System.Nullable<Oci.GoldengateService.Requests.ListDeploymentUpgradesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListDeploymentUpgradesRequest request;

            try
            {
                request = new ListDeploymentUpgradesRequest
                {
                    CompartmentId = CompartmentId,
                    DeploymentId = DeploymentId,
                    LifecycleState = LifecycleState,
                    DisplayName = DisplayName,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListDeploymentUpgradesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.DeploymentUpgradeCollection, true);
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
            IEnumerable<ListDeploymentUpgradesResponse> DefaultRequest(ListDeploymentUpgradesRequest request) => Enumerable.Repeat(client.ListDeploymentUpgrades(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListDeploymentUpgradesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListDeploymentUpgradesResponse response;
        private delegate IEnumerable<ListDeploymentUpgradesResponse> RequestDelegate(ListDeploymentUpgradesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
