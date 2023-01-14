/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210914
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ServicemanagerproxyService.Requests;
using Oci.ServicemanagerproxyService.Responses;
using Oci.ServicemanagerproxyService.Models;
using Oci.Common.Model;

namespace Oci.ServicemanagerproxyService.Cmdlets
{
    [Cmdlet("Get", "OCIServicemanagerproxyServiceEnvironment")]
    [OutputType(new System.Type[] { typeof(Oci.ServicemanagerproxyService.Models.ServiceEnvironment), typeof(Oci.ServicemanagerproxyService.Responses.GetServiceEnvironmentResponse) })]
    public class GetOCIServicemanagerproxyServiceEnvironment : OCIServiceManagerProxyCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier associated with the service environment.

**Note:** Not an [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm).")]
        public string ServiceEnvironmentId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) for the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetServiceEnvironmentRequest request;

            try
            {
                request = new GetServiceEnvironmentRequest
                {
                    ServiceEnvironmentId = ServiceEnvironmentId,
                    CompartmentId = CompartmentId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetServiceEnvironment(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ServiceEnvironment);
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

        private GetServiceEnvironmentResponse response;
    }
}
