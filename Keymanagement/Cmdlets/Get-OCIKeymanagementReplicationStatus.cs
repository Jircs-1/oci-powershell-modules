/*
 * NOTE: Generated using OracleSDKGenerator, API Version: release
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.KeymanagementService.Requests;
using Oci.KeymanagementService.Responses;
using Oci.KeymanagementService.Models;
using Oci.Common.Model;

namespace Oci.KeymanagementService.Cmdlets
{
    [Cmdlet("Get", "OCIKeymanagementReplicationStatus")]
    [OutputType(new System.Type[] { typeof(Oci.KeymanagementService.Models.ReplicationStatusDetails), typeof(Oci.KeymanagementService.Responses.GetReplicationStatusResponse) })]
    public class GetOCIKeymanagementReplicationStatus : OCIKmsManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"replicationId associated with an operation on a resource")]
        public string ReplicationId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If provided, the returned request ID will include this value. Otherwise, a random request ID will be generated by the service.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetReplicationStatusRequest request;

            try
            {
                request = new GetReplicationStatusRequest
                {
                    ReplicationId = ReplicationId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetReplicationStatus(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ReplicationStatusDetails);
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

        private GetReplicationStatusResponse response;
    }
}
