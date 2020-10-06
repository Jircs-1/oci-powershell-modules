/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.Common.Retry;
using Oci.EventsService;

namespace Oci.EventsService.Cmdlets
{
    public abstract class OCIEventsCmdlet : Oci.PSModules.Common.Cmdlets.OCICmdlet
    { 

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            try
            {
                bool noretry = AvoidRetry();
                WriteDebug($"Retry strategy : {!noretry}");
                retryConfig = (noretry) ? null : new RetryConfiguration();
            }
            catch (Exception ex)
            {
                TerminatingErrorDuringExecution(ex);
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
                client?.Dispose();
                int timeout = GetPreferredTimeout();
                WriteDebug($"Cmdlet Timeout : {timeout} milliseconds.");
                client = new EventsClient(AuthProvider, new Oci.Common.ClientConfiguration
                {
                    RetryConfiguration = retryConfig,
                    TimeoutMillis = timeout,
                    ClientUserAgent = PSUserAgent
                });
                string region = GetPreferredRegion();
                if (region != null)
                {
                    WriteDebug("Choosing Region:" + region);
                    client.SetRegion(region);
                }
                if (Endpoint != null)
                {
                    WriteDebug("Choosing Endpoint:" + Endpoint);
                    client.SetEndpoint(Endpoint);
                }
            }
            catch (Exception ex)
            {
                TerminatingErrorDuringExecution(ex);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            client.Dispose();
        }

        protected override void TerminatingErrorDuringExecution(Exception ex)
        {
            client?.Dispose();
            base.TerminatingErrorDuringExecution(ex);
        }

        protected EventsClient client;
        private RetryConfiguration retryConfig;
    }
}