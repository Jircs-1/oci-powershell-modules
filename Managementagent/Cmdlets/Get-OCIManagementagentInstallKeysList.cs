/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200202
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.ManagementagentService.Requests;
using Oci.ManagementagentService.Responses;
using Oci.ManagementagentService.Models;

namespace Oci.ManagementagentService.Cmdlets
{
    [Cmdlet("Get", "OCIManagementagentInstallKeysList")]
    [OutputType(new System.Type[] { typeof(Oci.ManagementagentService.Models.ManagementAgentInstallKeySummary), typeof(Oci.ManagementagentService.Responses.ListManagementAgentInstallKeysResponse) })]
    public class GetOCIManagementagentInstallKeysList : OCIManagementAgentCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment to which a request will be scoped.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"if set to true then it fetches resources for all compartments where user has access to else only on the compartment specified.")]
        public System.Nullable<bool> CompartmentIdInSubtree { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Value of this is always ""ACCESSIBLE"" and any other value is not supported.")]
        public string AccessLevel { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter to return only Management Agents in the particular lifecycle state.")]
        public System.Nullable<Oci.ManagementagentService.Models.LifecycleStates> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The display name for which the Key needs to be listed.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.ManagementagentService.Requests.ListManagementAgentInstallKeysRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. Default order for displayName is ascending. If no value is specified timeCreated is default.")]
        public System.Nullable<Oci.ManagementagentService.Requests.ListManagementAgentInstallKeysRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListManagementAgentInstallKeysRequest request;

            try
            {
                request = new ListManagementAgentInstallKeysRequest
                {
                    CompartmentId = CompartmentId,
                    CompartmentIdInSubtree = CompartmentIdInSubtree,
                    AccessLevel = AccessLevel,
                    LifecycleState = LifecycleState,
                    DisplayName = DisplayName,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListManagementAgentInstallKeysResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.Items, true);
                }
                if(!ParameterSetName.Equals(AllPageSet) && response.OpcNextPage != null)
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
            IEnumerable<ListManagementAgentInstallKeysResponse> DefaultRequest(ListManagementAgentInstallKeysRequest request) => Enumerable.Repeat(client.ListManagementAgentInstallKeys(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListManagementAgentInstallKeysResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListManagementAgentInstallKeysResponse response;
        private delegate IEnumerable<ListManagementAgentInstallKeysResponse> RequestDelegate(ListManagementAgentInstallKeysRequest request);
        private const string AllPageSet = "AllPages";
    }
}
