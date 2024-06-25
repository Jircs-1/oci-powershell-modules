/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20230518
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatabasemigrationService.Requests;
using Oci.DatabasemigrationService.Responses;
using Oci.DatabasemigrationService.Models;
using Oci.Common.Model;

namespace Oci.DatabasemigrationService.Cmdlets
{
    [Cmdlet("Get", "OCIDatabasemigrationAdvisorReport")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemigrationService.Models.AdvisorReport), typeof(Oci.DatabasemigrationService.Responses.GetAdvisorReportResponse) })]
    public class GetOCIDatabasemigrationAdvisorReport : OCIDatabaseMigrationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the job")]
        public string JobId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetAdvisorReportRequest request;

            try
            {
                request = new GetAdvisorReportRequest
                {
                    JobId = JobId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetAdvisorReport(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AdvisorReport);
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

        private GetAdvisorReportResponse response;
    }
}
