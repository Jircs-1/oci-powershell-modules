/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200606
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OptimizerService.Requests;
using Oci.OptimizerService.Responses;
using Oci.OptimizerService.Models;

namespace Oci.OptimizerService.Cmdlets
{
    [Cmdlet("Update", "OCIOptimizerProfile")]
    [OutputType(new System.Type[] { typeof(Oci.OptimizerService.Models.Profile), typeof(Oci.OptimizerService.Responses.UpdateProfileResponse) })]
    public class UpdateOCIOptimizerProfile : OCIOptimizerCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique OCID of the profile.")]
        public string ProfileId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The profile information to use for the update.")]
        public UpdateProfileDetails UpdateProfileDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateProfileRequest request;

            try
            {
                request = new UpdateProfileRequest
                {
                    ProfileId = ProfileId,
                    UpdateProfileDetails = UpdateProfileDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateProfile(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Profile);
                FinishProcessing(response);
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

        private UpdateProfileResponse response;
    }
}
