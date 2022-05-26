/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CoreService.Requests;
using Oci.CoreService.Responses;
using Oci.CoreService.Models;
using Oci.Common.Model;

namespace Oci.CoreService.Cmdlets
{
    [Cmdlet("Remove", "OCIVirtualNetworkDrgRouteRules")]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.CoreService.Responses.RemoveDrgRouteRulesResponse) })]
    public class RemoveOCIVirtualNetworkDrgRouteRules : OCIVirtualNetworkCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the DRG route table.")]
        public string DrgRouteTableId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request to remove one or more route rules in the DRG route table.")]
        public RemoveDrgRouteRulesDetails RemoveDrgRouteRulesDetails { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            RemoveDrgRouteRulesRequest request;

            try
            {
                request = new RemoveDrgRouteRulesRequest
                {
                    DrgRouteTableId = DrgRouteTableId,
                    RemoveDrgRouteRulesDetails = RemoveDrgRouteRulesDetails
                };

                response = client.RemoveDrgRouteRules(request).GetAwaiter().GetResult();
                WriteOutput(response);
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

        private RemoveDrgRouteRulesResponse response;
    }
}
