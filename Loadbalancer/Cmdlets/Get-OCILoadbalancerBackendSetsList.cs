/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20170115
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.LoadbalancerService.Requests;
using Oci.LoadbalancerService.Responses;
using Oci.LoadbalancerService.Models;
using Oci.Common.Model;

namespace Oci.LoadbalancerService.Cmdlets
{
    [Cmdlet("Get", "OCILoadbalancerBackendSetsList")]
    [OutputType(new System.Type[] { typeof(Oci.LoadbalancerService.Models.BackendSet), typeof(Oci.LoadbalancerService.Responses.ListBackendSetsResponse) })]
    public class GetOCILoadbalancerBackendSetsList : OCILoadBalancerCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the load balancer associated with the backend sets to retrieve.")]
        public string LoadBalancerId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the if-match parameter to the value of the ETag for the load balancer. This value can be obtained from a GET or POST response for any resource of that load balancer.

For example, the eTag returned by getListener can be specified as the ifMatch for updateRuleSets.

The resource is updated or deleted only if the ETag you provide matches the resource's current ETag value.

Example: `example-etag`")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListBackendSetsRequest request;

            try
            {
                request = new ListBackendSetsRequest
                {
                    LoadBalancerId = LoadBalancerId,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.ListBackendSets(request).GetAwaiter().GetResult();
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

        private ListBackendSetsResponse response;
    }
}
