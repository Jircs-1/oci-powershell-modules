/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20180115
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DnsService.Requests;
using Oci.DnsService.Responses;
using Oci.DnsService.Models;
using Oci.Common.Model;

namespace Oci.DnsService.Cmdlets
{
    [Cmdlet("New", "OCIDnsZoneFromZoneFile")]
    [OutputType(new System.Type[] { typeof(Oci.DnsService.Models.Zone), typeof(Oci.DnsService.Responses.CreateZoneFromZoneFileResponse) })]
    public class NewOCIDnsZoneFromZoneFile : OCIDnsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment the resource belongs to.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The zone file contents.", ParameterSetName = FromStreamSet)]
        public System.IO.Stream CreateZoneFromZoneFileDetails { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Use this parameter to provide the file location from where the input stream to be read. The zone file contents.", ParameterSetName = FromFileSet)]
        public String CreateZoneFromZoneFileDetailsFromFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies to operate only on resources that have a matching DNS scope.")]
        public System.Nullable<Oci.DnsService.Models.Scope> Scope { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the view the resource is associated with.")]
        public string ViewId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateZoneFromZoneFileRequest request;

            if (ParameterSetName.Equals(FromFileSet))
            {
                CreateZoneFromZoneFileDetails = System.IO.File.OpenRead(GetAbsoluteFilePath(CreateZoneFromZoneFileDetailsFromFile));
            }
            

            try
            {
                request = new CreateZoneFromZoneFileRequest
                {
                    CompartmentId = CompartmentId,
                    CreateZoneFromZoneFileDetails = CreateZoneFromZoneFileDetails,
                    OpcRequestId = OpcRequestId,
                    Scope = Scope,
                    ViewId = ViewId
                };

                response = client.CreateZoneFromZoneFile(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Zone);
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

        private CreateZoneFromZoneFileResponse response;
        private const string FromFileSet = "FromFile";
        private const string FromStreamSet = "FromStream";
    }
}
