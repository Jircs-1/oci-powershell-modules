/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 0.0.1
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.AnnouncementsService.Requests;
using Oci.AnnouncementsService.Responses;
using Oci.AnnouncementsService.Models;
using Oci.Common.Model;

namespace Oci.AnnouncementsService.Cmdlets
{
    [Cmdlet("Get", "OCIAnnouncementsserviceAnnouncementsPreference")]
    [OutputType(new System.Type[] { typeof(Oci.AnnouncementsService.Models.AnnouncementsPreferences), typeof(Oci.AnnouncementsService.Responses.GetAnnouncementsPreferenceResponse) })]
    public class GetOCIAnnouncementsserviceAnnouncementsPreference : OCIAnnouncementsPreferencesCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the preference.")]
        public string PreferenceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the complete request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetAnnouncementsPreferenceRequest request;

            try
            {
                request = new GetAnnouncementsPreferenceRequest
                {
                    PreferenceId = PreferenceId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetAnnouncementsPreference(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AnnouncementsPreferences);
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

        private GetAnnouncementsPreferenceResponse response;
    }
}
