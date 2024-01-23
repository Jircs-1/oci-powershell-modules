/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220915
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.PsqlService.Requests;
using Oci.PsqlService.Responses;
using Oci.PsqlService.Models;
using Oci.Common.Model;

namespace Oci.PsqlService.Cmdlets
{
    [Cmdlet("Get", "OCIPsqlConnectionDetails")]
    [OutputType(new System.Type[] { typeof(Oci.PsqlService.Models.ConnectionDetails), typeof(Oci.PsqlService.Responses.GetConnectionDetailsResponse) })]
    public class GetOCIPsqlConnectionDetails : OCIPostgresqlCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"A unique identifier for the database system.")]
        public string DbSystemId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetConnectionDetailsRequest request;

            try
            {
                request = new GetConnectionDetailsRequest
                {
                    DbSystemId = DbSystemId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetConnectionDetails(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ConnectionDetails);
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

        private GetConnectionDetailsResponse response;
    }
}