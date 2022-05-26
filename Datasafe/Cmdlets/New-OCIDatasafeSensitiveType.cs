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
    [Cmdlet("New", "OCIDatasafeSensitiveType")]
    [OutputType(new System.Type[] { typeof(Oci.DatasafeService.Models.SensitiveType), typeof(Oci.DatasafeService.Responses.CreateSensitiveTypeResponse) })]
    public class NewOCIDatasafeSensitiveType : OCIDataSafeCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details to create a new sensitive type. This parameter also accepts subtypes <Oci.DatasafeService.Models.CreateSensitiveCategoryDetails>, <Oci.DatasafeService.Models.CreateSensitiveTypePatternDetails> of type <Oci.DatasafeService.Models.CreateSensitiveTypeDetails>.")]
        public CreateSensitiveTypeDetails CreateSensitiveTypeDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateSensitiveTypeRequest request;

            try
            {
                request = new CreateSensitiveTypeRequest
                {
                    CreateSensitiveTypeDetails = CreateSensitiveTypeDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateSensitiveType(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SensitiveType);
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

        private CreateSensitiveTypeResponse response;
    }
}
