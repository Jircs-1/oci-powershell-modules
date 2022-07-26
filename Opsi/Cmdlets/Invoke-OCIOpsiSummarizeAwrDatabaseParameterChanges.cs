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
    [Cmdlet("Invoke", "OCIOpsiSummarizeAwrDatabaseParameterChanges")]
    [OutputType(new System.Type[] { typeof(Oci.OpsiService.Models.AwrDatabaseParameterChangeCollection), typeof(Oci.OpsiService.Responses.SummarizeAwrDatabaseParameterChangesResponse) })]
    public class InvokeOCIOpsiSummarizeAwrDatabaseParameterChanges : OCIOperationsInsightsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Awr Hub identifier")]
        public string AwrHubId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The internal ID of the database. The internal ID of the database is not the [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm). It can be retrieved from the following endpoint: /awrHubs/{awrHubId}/awrDatabases")]
        public string AwrSourceDatabaseIdentifier { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The required single value query parameter to filter the entity name.")]
        public string Name { get; set; }

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

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/Content/API/Concepts/usingapi.htm#nine). Example: `50`")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The option to sort the AWR database parameter change history data.")]
        public System.Nullable<Oci.OpsiService.Requests.SummarizeAwrDatabaseParameterChangesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.OpsiService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeAwrDatabaseParameterChangesRequest request;

            try
            {
                request = new SummarizeAwrDatabaseParameterChangesRequest
                {
                    AwrHubId = AwrHubId,
                    AwrSourceDatabaseIdentifier = AwrSourceDatabaseIdentifier,
                    Name = Name,
                    InstanceNumber = InstanceNumber,
                    BeginSnapshotIdentifierGreaterThanOrEqualTo = BeginSnapshotIdentifierGreaterThanOrEqualTo,
                    EndSnapshotIdentifierLessThanOrEqualTo = EndSnapshotIdentifierLessThanOrEqualTo,
                    TimeGreaterThanOrEqualTo = TimeGreaterThanOrEqualTo,
                    TimeLessThanOrEqualTo = TimeLessThanOrEqualTo,
                    Page = Page,
                    Limit = Limit,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    OpcRequestId = OpcRequestId
                };

                response = client.SummarizeAwrDatabaseParameterChanges(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AwrDatabaseParameterChangeCollection);
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

        private SummarizeAwrDatabaseParameterChangesResponse response;
    }
}
