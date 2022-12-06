/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210610
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.JmsService.Requests;
using Oci.JmsService.Responses;
using Oci.JmsService.Models;
using Oci.Common.Model;

namespace Oci.JmsService.Cmdlets
{
    [Cmdlet("Invoke", "OCIJmsSummarizeLibraryUsage")]
    [OutputType(new System.Type[] { typeof(Oci.JmsService.Models.LibraryUsageCollection), typeof(Oci.JmsService.Responses.SummarizeLibraryUsageResponse) })]
    public class InvokeOCIJmsSummarizeLibraryUsage : OCIJavaManagementServiceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the Fleet.")]
        public string FleetId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Java server instance key.")]
        public string ServerInstanceKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Fleet-unique identifier of the managed instance.")]
        public string ManagedInstanceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The deployed application key.")]
        public string ApplicationKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The library key.")]
        public string LibraryKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter the list with library name contains the given value.")]
        public string LibraryNameContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The library name.")]
        public string LibraryName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The start of the time period during which resources are searched (formatted according to [RFC3339](https://datatracker.ietf.org/doc/html/rfc3339)).")]
        public System.Nullable<System.DateTime> TimeStart { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The end of the time period during which resources are searched (formatted according to [RFC3339](https://datatracker.ietf.org/doc/html/rfc3339)).")]
        public System.Nullable<System.DateTime> TimeEnd { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. The token is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.JmsService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort libraries.  Only one sort order may be provided. If no value is specified _timeLastSeen_ is default.")]
        public System.Nullable<Oci.JmsService.Models.LibrarySortBy> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeLibraryUsageRequest request;

            try
            {
                request = new SummarizeLibraryUsageRequest
                {
                    FleetId = FleetId,
                    ServerInstanceKey = ServerInstanceKey,
                    ManagedInstanceId = ManagedInstanceId,
                    ApplicationKey = ApplicationKey,
                    LibraryKey = LibraryKey,
                    LibraryNameContains = LibraryNameContains,
                    LibraryName = LibraryName,
                    TimeStart = TimeStart,
                    TimeEnd = TimeEnd,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };

                response = client.SummarizeLibraryUsage(request).GetAwaiter().GetResult();
                WriteOutput(response, response.LibraryUsageCollection);
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

        private SummarizeLibraryUsageResponse response;
    }
}
