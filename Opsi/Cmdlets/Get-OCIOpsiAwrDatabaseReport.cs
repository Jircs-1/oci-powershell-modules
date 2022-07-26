/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OpsiService.Requests;
using Oci.OpsiService.Responses;
using Oci.OpsiService.Models;
using Oci.Common.Model;

namespace Oci.OpsiService.Cmdlets
{
    [Cmdlet("Get", "OCIOpsiAwrDatabaseReport")]
    [OutputType(new System.Type[] { typeof(Oci.OpsiService.Models.AwrDatabaseReport), typeof(Oci.OpsiService.Responses.GetAwrDatabaseReportResponse) })]
    public class GetOCIOpsiAwrDatabaseReport : OCIOperationsInsightsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Awr Hub identifier")]
        public string AwrHubId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The internal ID of the database. The internal ID of the database is not the [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm). It can be retrieved from the following endpoint: /awrHubs/{awrHubId}/awrDatabases")]
        public string AwrSourceDatabaseIdentifier { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional single value query parameter to filter by database instance number.")]
        public string InstanceNumber { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional greater than or equal to filter on the snapshot ID.")]
        public System.Nullable<int> BeginSnapshotIdentifierGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional less than or equal to query parameter to filter the snapshot Identifier.")]
        public System.Nullable<int> EndSnapshotIdentifierLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional greater than or equal to query parameter to filter the timestamp. The timestamp format to be followed is: YYYY-MM-DDTHH:MM:SSZ, example 2020-12-03T19:00:53Z")]
        public System.Nullable<System.DateTime> TimeGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional less than or equal to query parameter to filter the timestamp. The timestamp format to be followed is: YYYY-MM-DDTHH:MM:SSZ, example 2020-12-03T19:00:53Z")]
        public System.Nullable<System.DateTime> TimeLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The query parameter to filter the AWR report types.")]
        public System.Nullable<Oci.OpsiService.Requests.GetAwrDatabaseReportRequest.ReportTypeEnum> ReportType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The format of the AWR report.")]
        public System.Nullable<Oci.OpsiService.Requests.GetAwrDatabaseReportRequest.ReportFormatEnum> ReportFormat { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetAwrDatabaseReportRequest request;

            try
            {
                request = new GetAwrDatabaseReportRequest
                {
                    AwrHubId = AwrHubId,
                    AwrSourceDatabaseIdentifier = AwrSourceDatabaseIdentifier,
                    InstanceNumber = InstanceNumber,
                    BeginSnapshotIdentifierGreaterThanOrEqualTo = BeginSnapshotIdentifierGreaterThanOrEqualTo,
                    EndSnapshotIdentifierLessThanOrEqualTo = EndSnapshotIdentifierLessThanOrEqualTo,
                    TimeGreaterThanOrEqualTo = TimeGreaterThanOrEqualTo,
                    TimeLessThanOrEqualTo = TimeLessThanOrEqualTo,
                    ReportType = ReportType,
                    ReportFormat = ReportFormat,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetAwrDatabaseReport(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AwrDatabaseReport);
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

        private GetAwrDatabaseReportResponse response;
    }
}
