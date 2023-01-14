/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210731
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DashboardService.Requests;
using Oci.DashboardService.Responses;
using Oci.DashboardService.Models;
using Oci.Common.Model;

namespace Oci.DashboardService.Cmdlets
{
    [Cmdlet("Remove", "OCIDashboardserviceDashboardGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.DashboardService.Responses.DeleteDashboardGroupResponse) })]
    public class RemoveOCIDashboardserviceDashboardGroup : OCIDashboardGroupCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the dashboard group.")]
        public string DashboardGroupId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"To identify if the call is cross-regional. In CRUD calls for a resource, to identify that the call originates from different region, set the `CrossRegionIdentifierHeader` parameter to a region name (ex - `US-ASHBURN-1`) The call will be served from a Replicated bucket. For same-region calls, the value is unassigned.")]
        public string OpcCrossRegion { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Ignore confirmation and force the Cmdlet to complete action.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmDelete("OCIDashboardserviceDashboardGroup", "Remove"))
            {
               return;
            }

            DeleteDashboardGroupRequest request;

            try
            {
                request = new DeleteDashboardGroupRequest
                {
                    DashboardGroupId = DashboardGroupId,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId,
                    OpcCrossRegion = OpcCrossRegion
                };

                response = client.DeleteDashboardGroup(request).GetAwaiter().GetResult();
                WriteOutput(response);
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

        private DeleteDashboardGroupResponse response;
    }
}
