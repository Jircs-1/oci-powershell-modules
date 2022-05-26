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
using Oci.DatabaseService.Requests;
using Oci.DatabaseService.Responses;
using Oci.DatabaseService.Models;
using Oci.Common.Model;

namespace Oci.DatabaseService.Cmdlets
{
    [Cmdlet("Get", "OCIDatabaseDbVersionsList")]
    [OutputType(new System.Type[] { typeof(Oci.DatabaseService.Models.DbVersionSummary), typeof(Oci.DatabaseService.Responses.ListDbVersionsResponse) })]
    public class GetOCIDatabaseDbVersionsList : OCIDatabaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The compartment [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm).")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return per page.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The pagination token to continue listing from.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"If provided, filters the results to the set of database versions which are supported for the given shape.")]
        public string DbSystemShape { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The DB system [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm). If provided, filters the results to the set of database versions which are supported for the DB system.")]
        public string DbSystemId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The DB system storage management option. Used to list database versions available for that storage manager. Valid values are `ASM` and `LVM`. * ASM specifies Oracle Automatic Storage Management * LVM specifies logical volume manager, sometimes called logical disk manager.")]
        public System.Nullable<Oci.DatabaseService.Models.DbSystemOptions.StorageManagementEnum> StorageManagement { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"If provided, filters the results to the set of database versions which are supported for Upgrade.")]
        public System.Nullable<bool> IsUpgradeSupported { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"If true, filters the results to the set of Oracle Database versions that are supported for OCI database software images.")]
        public System.Nullable<bool> IsDatabaseSoftwareImageSupported { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListDbVersionsRequest request;

            try
            {
                request = new ListDbVersionsRequest
                {
                    CompartmentId = CompartmentId,
                    Limit = Limit,
                    Page = Page,
                    DbSystemShape = DbSystemShape,
                    DbSystemId = DbSystemId,
                    StorageManagement = StorageManagement,
                    IsUpgradeSupported = IsUpgradeSupported,
                    IsDatabaseSoftwareImageSupported = IsDatabaseSoftwareImageSupported
                };
                IEnumerable<ListDbVersionsResponse> responses = GetRequestDelegate().Invoke(request);
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
            IEnumerable<ListDbVersionsResponse> DefaultRequest(ListDbVersionsRequest request) => Enumerable.Repeat(client.ListDbVersions(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListDbVersionsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListDbVersionsResponse response;
        private delegate IEnumerable<ListDbVersionsResponse> RequestDelegate(ListDbVersionsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
