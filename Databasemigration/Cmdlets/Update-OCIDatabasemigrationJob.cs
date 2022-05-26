/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210929
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
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
    [Cmdlet("Update", "OCIDatabasemigrationJob")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemigrationService.Models.Job), typeof(Oci.DatabasemigrationService.Responses.UpdateJobResponse) })]
    public class UpdateOCIDatabasemigrationJob : OCIDatabaseMigrationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the job")]
        public string JobId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Migration Job properties.")]
        public UpdateJobDetails UpdateJobDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateJobRequest request;

            try
            {
                request = new UpdateJobRequest
                {
                    JobId = JobId,
                    UpdateJobDetails = UpdateJobDetails,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.UpdateJob(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Job);
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

        private UpdateJobResponse response;
    }
}
