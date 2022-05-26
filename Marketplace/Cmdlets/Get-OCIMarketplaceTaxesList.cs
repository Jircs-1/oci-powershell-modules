/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181001
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.MarketplaceService.Requests;
using Oci.MarketplaceService.Responses;
using Oci.MarketplaceService.Models;
using Oci.Common.Model;

namespace Oci.MarketplaceService.Cmdlets
{
    [Cmdlet("Get", "OCIMarketplaceTaxesList")]
    [OutputType(new System.Type[] { typeof(Oci.MarketplaceService.Models.TaxSummary), typeof(Oci.MarketplaceService.Responses.ListTaxesResponse) })]
    public class GetOCIMarketplaceTaxesList : OCIMarketplaceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier for the listing.")]
        public string ListingId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier for the compartment.")]
        public string CompartmentId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListTaxesRequest request;

            try
            {
                request = new ListTaxesRequest
                {
                    ListingId = ListingId,
                    OpcRequestId = OpcRequestId,
                    CompartmentId = CompartmentId
                };

                response = client.ListTaxes(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Items, true);
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

        private ListTaxesResponse response;
    }
}
