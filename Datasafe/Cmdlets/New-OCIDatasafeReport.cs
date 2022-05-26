/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatasafeService.Requests;
using Oci.DatasafeService.Responses;
using Oci.DatasafeService.Models;
using Oci.Common.Model;

namespace Oci.DatasafeService.Cmdlets
{
    [Cmdlet("New", "OCIDatasafeReport")]
    [OutputType(new System.Type[] { typeof(Oci.PSModules.Common.Cmdlets.WorkRequest), typeof(Oci.DatasafeService.Responses.GenerateReportResponse) })]
    public class NewOCIDatasafeReport : OCIDataSafeCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique report definition identifier")]
        public string ReportDefinitionId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details for report generation. It contains details such as PDF/XLS and filter parameters like audit event time limits, number of rows and target databases etc")]
        public GenerateReportDetails GenerateReportDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the if-match parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The scimQuery query parameter accepts filter expressions that use the syntax described in Section 3.2.2.2 of the System for Cross-Domain Identity Management (SCIM) specification, which is available at [RFC3339](https://tools.ietf.org/html/draft-ietf-scim-api-12). In SCIM filtering expressions, text, date, and time values must be enclosed in quotation marks, with date and time values using ISO-8601 format. (Numeric and boolean values should not be quoted.)

**Example:** query=(dateGenerated ge '2021-12-18T01-00-26') and (ilmTarget eq 'dscs-target')")]
        public string ScimQuery { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GenerateReportRequest request;

            try
            {
                request = new GenerateReportRequest
                {
                    ReportDefinitionId = ReportDefinitionId,
                    GenerateReportDetails = GenerateReportDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken,
                    ScimQuery = ScimQuery
                };

                response = client.GenerateReport(request).GetAwaiter().GetResult();
                WriteOutput(response, CreateWorkRequestObject(response.OpcWorkRequestId));
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

        private GenerateReportResponse response;
    }
}
