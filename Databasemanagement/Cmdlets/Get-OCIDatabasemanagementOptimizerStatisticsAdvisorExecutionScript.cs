/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20201101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatabasemanagementService.Requests;
using Oci.DatabasemanagementService.Responses;
using Oci.DatabasemanagementService.Models;
using Oci.Common.Model;

namespace Oci.DatabasemanagementService.Cmdlets
{
    [Cmdlet("Get", "OCIDatabasemanagementOptimizerStatisticsAdvisorExecutionScript")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemanagementService.Models.OptimizerStatisticsAdvisorExecutionScript), typeof(Oci.DatabasemanagementService.Responses.GetOptimizerStatisticsAdvisorExecutionScriptResponse) })]
    public class GetOCIDatabasemanagementOptimizerStatisticsAdvisorExecutionScript : OCIDbManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the Managed Database.")]
        public string ManagedDatabaseId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the Optimizer Statistics Advisor execution.")]
        public string ExecutionName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the optimizer statistics collection execution task.")]
        public string TaskName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetOptimizerStatisticsAdvisorExecutionScriptRequest request;

            try
            {
                request = new GetOptimizerStatisticsAdvisorExecutionScriptRequest
                {
                    ManagedDatabaseId = ManagedDatabaseId,
                    ExecutionName = ExecutionName,
                    TaskName = TaskName,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetOptimizerStatisticsAdvisorExecutionScript(request).GetAwaiter().GetResult();
                WriteOutput(response, response.OptimizerStatisticsAdvisorExecutionScript);
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

        private GetOptimizerStatisticsAdvisorExecutionScriptResponse response;
    }
}
