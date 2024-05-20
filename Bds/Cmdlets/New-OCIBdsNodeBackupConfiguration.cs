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
    [Cmdlet("New", "OCIBdsNodeBackupConfiguration")]
    [OutputType(new System.Type[] { typeof(Oci.PSModules.Common.Cmdlets.WorkRequest), typeof(Oci.BdsService.Responses.CreateNodeBackupConfigurationResponse) })]
    public class NewOCIBdsNodeBackupConfiguration : OCIBdsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the cluster.")]
        public string BdsInstanceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details for adding nodeBackupConfiguration to the BDS cluster.")]
        public CreateNodeBackupConfigurationDetails CreateNodeBackupConfigurationDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error, without risk of executing that same action again. Retry tokens expire after 24 hours but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateNodeBackupConfigurationRequest request;

            try
            {
                request = new CreateNodeBackupConfigurationRequest
                {
                    BdsInstanceId = BdsInstanceId,
                    CreateNodeBackupConfigurationDetails = CreateNodeBackupConfigurationDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.CreateNodeBackupConfiguration(request).GetAwaiter().GetResult();
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

        private CreateNodeBackupConfigurationResponse response;
    }
}
