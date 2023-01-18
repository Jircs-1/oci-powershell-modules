/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20191001
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OspgatewayService.Requests;
using Oci.OspgatewayService.Responses;
using Oci.OspgatewayService.Models;
using Oci.Common.Model;

namespace Oci.OspgatewayService.Cmdlets
{
    /*
     * As per https://github.com/PowerShell/PowerShell/issues/11143, this cmdlet is marked with a default parameter set for proper resolution of the invoked parameter set.
     * Parameter set "Default" contains all the parameters that are defined in this class(including base classes) and are not explicitly tagged with a ParameterSetName.
     */
    [Cmdlet("Invoke", "OCIOspgatewayDownloadPdfContent", DefaultParameterSetName = Default)]
    [OutputType(new System.Type[] { typeof(System.IO.Stream), typeof(void), typeof(Oci.OspgatewayService.Responses.DownloadPdfContentResponse) })]
    public class InvokeOCIOspgatewayDownloadPdfContent : OCIInvoiceServiceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The home region's public name of the logged in user.")]
        public string OspHomeRegion { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The identifier of the invoice.")]
        public string InternalInvoiceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Path to the output file.", ParameterSetName = WriteToFileSet)]
        public string OutputFile { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Output the complete response returned by the API Operation. Using this switch will make this Cmdlet output an object containing response headers in-addition to an optional response body.", ParameterSetName = FullResponseSet)]
        public override SwitchParameter FullResponse { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            DownloadPdfContentRequest request;

            try
            {
                request = new DownloadPdfContentRequest
                {
                    OspHomeRegion = OspHomeRegion,
                    CompartmentId = CompartmentId,
                    InternalInvoiceId = InternalInvoiceId,
                    OpcRequestId = OpcRequestId
                };

                response = client.DownloadPdfContent(request).GetAwaiter().GetResult();
                HandleOutput();
                
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

        private void HandleOutput()
        {
            if (ParameterSetName.Equals(WriteToFileSet))
            {
                WriteToOutputFile(OutputFile, response.InputStream);
            }
            else
            {
                WriteOutput(response, response.InputStream);
            }
        }

        private DownloadPdfContentResponse response;
        private const string Default = "Default";
        private const string WriteToFileSet = "WriteToFile";
        private const string FullResponseSet = "FullResponse";
    }
}
