/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190325
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatacatalogService.Requests;
using Oci.DatacatalogService.Responses;
using Oci.DatacatalogService.Models;
using Oci.Common.Model;
using Oci.Common.Waiters;

namespace Oci.DatacatalogService.Cmdlets
{
    [Cmdlet("Get", "OCIDatacatalogJobDefinition", DefaultParameterSetName = Default)]
    [OutputType(new System.Type[] { typeof(Oci.DatacatalogService.Models.JobDefinition), typeof(Oci.DatacatalogService.Responses.GetJobDefinitionResponse) })]
    public class GetOCIDatacatalogJobDefinition : OCIDataCatalogCmdlet
    {
        
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique catalog identifier.", ParameterSetName = LifecycleStateParamSet)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique catalog identifier.", ParameterSetName = Default)]
        public string CatalogId { get; set; }

        
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique job definition key.", ParameterSetName = LifecycleStateParamSet)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique job definition key.", ParameterSetName = Default)]
        public string JobDefinitionKey { get; set; }

        
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the fields to return in a job definition response.", ParameterSetName = LifecycleStateParamSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the fields to return in a job definition response.", ParameterSetName = Default)]
        public System.Collections.Generic.List<Oci.DatacatalogService.Requests.GetJobDefinitionRequest.FieldsEnum> Fields { get; set; }

        
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.", ParameterSetName = LifecycleStateParamSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.", ParameterSetName = Default)]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = @"This operation creates, modifies or deletes a resource that has a defined lifecycle state. Specify this option to perform the action and then wait until the resource reaches a given lifecycle state. Multiple states can be specified, returning on the first state.", ParameterSetName = LifecycleStateParamSet)]
        public Oci.DatacatalogService.Models.LifecycleState[] WaitForLifecycleState { get; set; }

        [Parameter(Mandatory = false, HelpMessage = @"Check every WaitIntervalSeconds to see whether the resource has reached a desired state.", ParameterSetName = LifecycleStateParamSet)]
        public int WaitIntervalSeconds { get; set; } = WAIT_INTERVAL_SECONDS;

        [Parameter(Mandatory = false, HelpMessage = @"Maximum number of attempts to be made until the resource reaches a desired state.", ParameterSetName = LifecycleStateParamSet)]
        public int MaxWaitAttempts { get; set; } = MAX_WAITER_ATTEMPTS;

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetJobDefinitionRequest request;

            try
            {
                request = new GetJobDefinitionRequest
                {
                    CatalogId = CatalogId,
                    JobDefinitionKey = JobDefinitionKey,
                    Fields = Fields,
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

        private void HandleOutput(GetJobDefinitionRequest request)
        {
            var waiterConfig = new WaiterConfiguration
            {
                MaxAttempts = MaxWaitAttempts,
                GetNextDelayInSeconds = (_) => WaitIntervalSeconds
            };

            switch (ParameterSetName)
            { 
                case LifecycleStateParamSet:
                    response = client.Waiters.ForJobDefinition(request, waiterConfig, WaitForLifecycleState).Execute();
                    break;

                case Default:
                    response = client.GetJobDefinition(request).GetAwaiter().GetResult();
                    break;
            }
            WriteOutput(response, response.JobDefinition);
        }

        private GetJobDefinitionResponse response;
        private const string LifecycleStateParamSet = "LifecycleStateParamSet";
        private const string Default = "Default";
    }
}
