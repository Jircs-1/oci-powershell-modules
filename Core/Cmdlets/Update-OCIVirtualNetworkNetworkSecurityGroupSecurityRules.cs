/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
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
    [Cmdlet("Update", "OCIVirtualNetworkNetworkSecurityGroupSecurityRules")]
    [OutputType(new System.Type[] { typeof(Oci.CoreService.Models.UpdatedNetworkSecurityGroupSecurityRules), typeof(Oci.CoreService.Responses.UpdateNetworkSecurityGroupSecurityRulesResponse) })]
    public class UpdateOCIVirtualNetworkNetworkSecurityGroupSecurityRules : OCIVirtualNetworkCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the network security group.")]
        public string NetworkSecurityGroupId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request with one or more security rules associated with the network security group that will be updated.")]
        public UpdateNetworkSecurityGroupSecurityRulesDetails UpdateNetworkSecurityGroupSecurityRulesDetails { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateNetworkSecurityGroupSecurityRulesRequest request;

            try
            {
                request = new UpdateNetworkSecurityGroupSecurityRulesRequest
                {
                    NetworkSecurityGroupId = NetworkSecurityGroupId,
                    UpdateNetworkSecurityGroupSecurityRulesDetails = UpdateNetworkSecurityGroupSecurityRulesDetails
                };

                response = client.UpdateNetworkSecurityGroupSecurityRules(request).GetAwaiter().GetResult();
                WriteOutput(response, response.UpdatedNetworkSecurityGroupSecurityRules);
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

        private UpdateNetworkSecurityGroupSecurityRulesResponse response;
    }
}
