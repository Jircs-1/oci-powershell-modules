/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ObjectstorageService.Requests;
using Oci.ObjectstorageService.Responses;
using Oci.ObjectstorageService.Models;

namespace Oci.ObjectstorageService.Cmdlets
{
    [Cmdlet("New", "OCIObjectstorageMultipartUpload")]
    [OutputType(new System.Type[] { typeof(Oci.ObjectstorageService.Models.MultipartUpload), typeof(Oci.ObjectstorageService.Responses.CreateMultipartUploadResponse) })]
    public class NewOCIObjectstorageMultipartUpload : OCIObjectStorageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Object Storage namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the bucket. Avoid entering confidential information. Example: `my-new-bucket1`")]
        public string BucketName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request object for creating a multipart upload.")]
        public CreateMultipartUploadDetails CreateMultipartUploadDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The entity tag (ETag) to match with the ETag of an existing resource. If the specified ETag matches the ETag of the existing resource, GET and HEAD requests will return the resource and PUT and POST requests will upload the resource.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The entity tag (ETag) to avoid matching. The only valid value is '*', which indicates that the request should fail if the resource already exists.")]
        public string IfNoneMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcClientRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional header that specifies ""AES256"" as the encryption algorithm. For more information, see [Using Your Own Keys for Server-Side Encryption](https://docs.cloud.oracle.com/Content/Object/Tasks/usingyourencryptionkeys.htm).")]
        public string OpcSseCustomerAlgorithm { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional header that specifies the base64-encoded 256-bit encryption key to use to encrypt or decrypt the data. For more information, see [Using Your Own Keys for Server-Side Encryption](https://docs.cloud.oracle.com/Content/Object/Tasks/usingyourencryptionkeys.htm).")]
        public string OpcSseCustomerKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional header that specifies the base64-encoded SHA256 hash of the encryption key. This value is used to check the integrity of the encryption key. For more information, see [Using Your Own Keys for Server-Side Encryption](https://docs.cloud.oracle.com/Content/Object/Tasks/usingyourencryptionkeys.htm).")]
        public string OpcSseCustomerKeySha256 { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of a master encryption key used to call the Key Management service to generate a data encryption key or to encrypt or decrypt a data encryption key.")]
        public string OpcSseKmsKeyId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateMultipartUploadRequest request;

            try
            {
                request = new CreateMultipartUploadRequest
                {
                    NamespaceName = NamespaceName,
                    BucketName = BucketName,
                    CreateMultipartUploadDetails = CreateMultipartUploadDetails,
                    IfMatch = IfMatch,
                    IfNoneMatch = IfNoneMatch,
                    OpcClientRequestId = OpcClientRequestId,
                    OpcSseCustomerAlgorithm = OpcSseCustomerAlgorithm,
                    OpcSseCustomerKey = OpcSseCustomerKey,
                    OpcSseCustomerKeySha256 = OpcSseCustomerKeySha256,
                    OpcSseKmsKeyId = OpcSseKmsKeyId
                };

                response = client.CreateMultipartUpload(request).GetAwaiter().GetResult();
                WriteOutput(response, response.MultipartUpload);
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

        private CreateMultipartUploadResponse response;
    }
}
