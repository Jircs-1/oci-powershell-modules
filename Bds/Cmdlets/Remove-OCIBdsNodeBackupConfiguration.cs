/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190531
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.BdsService.Requests;
using Oci.BdsService.Responses;
using Oci.BdsService.Models;
using Oci.Common.Model;

namespace Oci.BdsService.Cmdlets
{
    [Cmdlet("Remove", "OCIBdsNodeBackupConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(new System.Type[] { typeof(Oci.PSModules.Common.Cmdlets.WorkRequest), typeof(Oci.BdsService.Responses.DeleteNodeBackupConfigurationResponse) })]
    public class RemoveOCIBdsNodeBackupConfiguration : OCIBdsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the cluster.")]
        public string BdsInstanceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier of the NodeBackupConfiguration.")]
        public string NodeBackupConfigurationId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Ignore confirmation and force the Cmdlet to complete action.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmDelete("OCIBdsNodeBackupConfiguration", "Remove"))
            {
               return;
            }

            DeleteNodeBackupConfigurationRequest request;

            try
            {
                request = new DeleteNodeBackupConfigurationRequest
                {
                    BdsInstanceId = BdsInstanceId,
                    NodeBackupConfigurationId = NodeBackupConfigurationId,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.DeleteNodeBackupConfiguration(request).GetAwaiter().GetResult();
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

        private DeleteNodeBackupConfigurationResponse response;
    }
}
