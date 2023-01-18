/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CoreService.Requests;
using Oci.CoreService.Responses;
using Oci.CoreService.Models;
using Oci.Common.Model;

namespace Oci.CoreService.Cmdlets
{
    [Cmdlet("New", "OCIComputeInstanceConsoleConnection")]
    [OutputType(new System.Type[] { typeof(Oci.CoreService.Models.InstanceConsoleConnection), typeof(Oci.CoreService.Responses.CreateInstanceConsoleConnectionResponse) })]
    public class NewOCIComputeInstanceConsoleConnection : OCIComputeCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request object for creating an InstanceConsoleConnection")]
        public CreateInstanceConsoleConnectionDetails CreateInstanceConsoleConnectionDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (for example, if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateInstanceConsoleConnectionRequest request;

            try
            {
                request = new CreateInstanceConsoleConnectionRequest
                {
                    CreateInstanceConsoleConnectionDetails = CreateInstanceConsoleConnectionDetails,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.CreateInstanceConsoleConnection(request).GetAwaiter().GetResult();
                WriteOutput(response, response.InstanceConsoleConnection);
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

        private CreateInstanceConsoleConnectionResponse response;
    }
}
