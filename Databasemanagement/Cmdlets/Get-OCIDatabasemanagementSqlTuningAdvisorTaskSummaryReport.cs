/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20201101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
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
    [Cmdlet("Get", "OCIDatabasemanagementSqlTuningAdvisorTaskSummaryReport")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemanagementService.Models.SqlTuningAdvisorTaskSummaryReport), typeof(Oci.DatabasemanagementService.Responses.GetSqlTuningAdvisorTaskSummaryReportResponse) })]
    public class GetOCIDatabasemanagementSqlTuningAdvisorTaskSummaryReport : OCISqlTuningCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the Managed Database.")]
        public string ManagedDatabaseId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The SQL tuning task identifier. This is not the [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm).")]
        public System.Nullable<long> SqlTuningAdvisorTaskId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"How far back the API will search for begin and end exec id. Unused if neither exec ids nor time filter query params are supplied. This is applicable only for Auto SQL Tuning tasks.")]
        public System.Nullable<Oci.DatabasemanagementService.Requests.GetSqlTuningAdvisorTaskSummaryReportRequest.SearchPeriodEnum> SearchPeriod { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional greater than or equal to query parameter to filter the timestamp. This is applicable only for Auto SQL Tuning tasks.")]
        public System.Nullable<System.DateTime> TimeGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional less than or equal to query parameter to filter the timestamp. This is applicable only for Auto SQL Tuning tasks.")]
        public System.Nullable<System.DateTime> TimeLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional greater than or equal to filter on the execution ID related to a specific SQL Tuning Advisor task. This is applicable only for Auto SQL Tuning tasks.")]
        public System.Nullable<long> BeginExecIdGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional less than or equal to query parameter to filter on the execution ID related to a specific SQL Tuning Advisor task. This is applicable only for Auto SQL Tuning tasks.")]
        public System.Nullable<long> EndExecIdLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetSqlTuningAdvisorTaskSummaryReportRequest request;

            try
            {
                request = new GetSqlTuningAdvisorTaskSummaryReportRequest
                {
                    ManagedDatabaseId = ManagedDatabaseId,
                    SqlTuningAdvisorTaskId = SqlTuningAdvisorTaskId,
                    SearchPeriod = SearchPeriod,
                    TimeGreaterThanOrEqualTo = TimeGreaterThanOrEqualTo,
                    TimeLessThanOrEqualTo = TimeLessThanOrEqualTo,
                    BeginExecIdGreaterThanOrEqualTo = BeginExecIdGreaterThanOrEqualTo,
                    EndExecIdLessThanOrEqualTo = EndExecIdLessThanOrEqualTo,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetSqlTuningAdvisorTaskSummaryReport(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SqlTuningAdvisorTaskSummaryReport);
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

        private GetSqlTuningAdvisorTaskSummaryReportResponse response;
    }
}
