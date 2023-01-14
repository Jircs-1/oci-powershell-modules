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
    [Cmdlet("Update", "OCIVirtualNetworkLocalPeeringGateway")]
    [OutputType(new System.Type[] { typeof(Oci.CoreService.Models.LocalPeeringGateway), typeof(Oci.CoreService.Responses.UpdateLocalPeeringGatewayResponse) })]
    public class UpdateOCIVirtualNetworkLocalPeeringGateway : OCIVirtualNetworkCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the local peering gateway.")]
        public string LocalPeeringGatewayId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details object for updating a local peering gateway.")]
        public UpdateLocalPeeringGatewayDetails UpdateLocalPeeringGatewayDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateLocalPeeringGatewayRequest request;

            try
            {
                request = new UpdateLocalPeeringGatewayRequest
                {
                    LocalPeeringGatewayId = LocalPeeringGatewayId,
                    UpdateLocalPeeringGatewayDetails = UpdateLocalPeeringGatewayDetails,
                    IfMatch = IfMatch
                };

                response = client.UpdateLocalPeeringGateway(request).GetAwaiter().GetResult();
                WriteOutput(response, response.LocalPeeringGateway);
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

        private UpdateLocalPeeringGatewayResponse response;
    }
}
