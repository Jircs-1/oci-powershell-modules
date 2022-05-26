/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200801
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.TenantmanagercontrolplaneService.Requests;
using Oci.TenantmanagercontrolplaneService.Responses;
using Oci.TenantmanagercontrolplaneService.Models;
using Oci.Common.Model;
using Oci.Common.Waiters;

namespace Oci.TenantmanagercontrolplaneService.Cmdlets
{
    [Cmdlet("Get", "OCITenantmanagercontrolplaneOrganization", DefaultParameterSetName = Default)]
    [OutputType(new System.Type[] { typeof(Oci.TenantmanagercontrolplaneService.Models.Organization), typeof(Oci.TenantmanagercontrolplaneService.Responses.GetOrganizationResponse) })]
    public class GetOCITenantmanagercontrolplaneOrganization : OCIOrganizationCmdlet
    {
        
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"OCID of the organization to retrieve.", ParameterSetName = LifecycleStateParamSet)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"OCID of the organization to retrieve.", ParameterSetName = Default)]
        public string OrganizationId { get; set; }

        
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.", ParameterSetName = LifecycleStateParamSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.", ParameterSetName = Default)]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = @"This operation creates, modifies or deletes a resource that has a defined lifecycle state. Specify this option to perform the action and then wait until the resource reaches a given lifecycle state. Multiple states can be specified, returning on the first state.", ParameterSetName = LifecycleStateParamSet)]
        public Oci.TenantmanagercontrolplaneService.Models.Organization.LifecycleStateEnum[] WaitForLifecycleState { get; set; }

        [Parameter(Mandatory = false, HelpMessage = @"Check every WaitIntervalSeconds to see whether the resource has reached a desired state.", ParameterSetName = LifecycleStateParamSet)]
        public int WaitIntervalSeconds { get; set; } = WAIT_INTERVAL_SECONDS;

        [Parameter(Mandatory = false, HelpMessage = @"Maximum number of attempts to be made until the resource reaches a desired state.", ParameterSetName = LifecycleStateParamSet)]
        public int MaxWaitAttempts { get; set; } = MAX_WAITER_ATTEMPTS;

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetOrganizationRequest request;

            try
            {
                request = new GetOrganizationRequest
                {
                    OrganizationId = OrganizationId,
                    OpcRequestId = OpcRequestId
                };

                HandleOutput(request);
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

        private void HandleOutput(GetOrganizationRequest request)
        {
            var waiterConfig = new WaiterConfiguration
            {
                MaxAttempts = MaxWaitAttempts,
                GetNextDelayInSeconds = (_) => WaitIntervalSeconds
            };

            switch (ParameterSetName)
            { 
                case LifecycleStateParamSet:
                    response = client.Waiters.ForOrganization(request, waiterConfig, WaitForLifecycleState).Execute();
                    break;

                case Default:
                    response = client.GetOrganization(request).GetAwaiter().GetResult();
                    break;
            }
            WriteOutput(response, response.Organization);
        }

        private GetOrganizationResponse response;
        private const string LifecycleStateParamSet = "LifecycleStateParamSet";
        private const string Default = "Default";
    }
}
