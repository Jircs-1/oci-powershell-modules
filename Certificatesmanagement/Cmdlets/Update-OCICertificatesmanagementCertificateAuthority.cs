/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210224
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CertificatesmanagementService.Requests;
using Oci.CertificatesmanagementService.Responses;
using Oci.CertificatesmanagementService.Models;

namespace Oci.CertificatesmanagementService.Cmdlets
{
    [Cmdlet("Update", "OCICertificatesmanagementCertificateAuthority")]
    [OutputType(new System.Type[] { typeof(Oci.CertificatesmanagementService.Models.CertificateAuthority), typeof(Oci.CertificatesmanagementService.Responses.UpdateCertificateAuthorityResponse) })]
    public class UpdateOCICertificatesmanagementCertificateAuthority : OCICertificatesManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the certificate authority (CA).")]
        public string CertificateAuthorityId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details of the request to update a CA.")]
        public UpdateCertificateAuthorityDetails UpdateCertificateAuthorityDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If provided, the returned request ID will include this value. Otherwise, a random request ID will be generated by the service.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateCertificateAuthorityRequest request;

            try
            {
                request = new UpdateCertificateAuthorityRequest
                {
                    CertificateAuthorityId = CertificateAuthorityId,
                    UpdateCertificateAuthorityDetails = UpdateCertificateAuthorityDetails,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.UpdateCertificateAuthority(request).GetAwaiter().GetResult();
                WriteOutput(response, response.CertificateAuthority);
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

        private UpdateCertificateAuthorityResponse response;
    }
}