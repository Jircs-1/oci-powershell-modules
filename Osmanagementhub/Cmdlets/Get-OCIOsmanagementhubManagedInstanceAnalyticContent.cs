/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220901
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OsmanagementhubService.Requests;
using Oci.OsmanagementhubService.Responses;
using Oci.OsmanagementhubService.Models;
using Oci.Common.Model;

namespace Oci.OsmanagementhubService.Cmdlets
{
    /*
     * As per https://github.com/PowerShell/PowerShell/issues/11143, this cmdlet is marked with a default parameter set for proper resolution of the invoked parameter set.
     * Parameter set "Default" contains all the parameters that are defined in this class(including base classes) and are not explicitly tagged with a ParameterSetName.
     */
    [Cmdlet("Get", "OCIOsmanagementhubManagedInstanceAnalyticContent", DefaultParameterSetName = Default)]
    [OutputType(new System.Type[] { typeof(System.IO.Stream), typeof(void), typeof(Oci.OsmanagementhubService.Responses.GetManagedInstanceAnalyticContentResponse) })]
    public class GetOCIOsmanagementhubManagedInstanceAnalyticContent : OCIReportingManagedInstanceCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This compartmentId is used to list managed instances within a compartment. Or serve as an additional filter to restrict only managed instances with in certain compartment if other filter presents.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the managed instance group for which to list resources.")]
        public string ManagedInstanceGroupId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the lifecycle environment.")]
        public string LifecycleEnvironmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the lifecycle stage for which to list resources.")]
        public string LifecycleStageId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only instances whose managed instance status matches the given status.")]
        public System.Collections.Generic.List<Oci.OsmanagementhubService.Models.ManagedInstanceStatus> Status { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return resources that match the given display names.")]
        public System.Collections.Generic.List<string> DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return resources that may partially match the given display name.")]
        public string DisplayNameContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter instances by Location. Used when report target type is compartment or group.")]
        public System.Nullable<Oci.OsmanagementhubService.Models.ManagedInstanceLocation> InstanceLocation { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return instances with number of available security updates equals to the number specified.")]
        public System.Nullable<int> SecurityUpdatesAvailableEqualsTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return instances with number of available bug updates equals to the number specified.")]
        public System.Nullable<int> BugUpdatesAvailableEqualsTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return instances with number of available security updates greater than the number specified.")]
        public System.Nullable<int> SecurityUpdatesAvailableGreaterThan { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return instances with number of available bug updates greater than the number specified.")]
        public System.Nullable<int> BugUpdatesAvailableGreaterThan { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Path to the output file.", ParameterSetName = WriteToFileSet)]
        public string OutputFile { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Output the complete response returned by the API Operation. Using this switch will make this Cmdlet output an object containing response headers in-addition to an optional response body.", ParameterSetName = FullResponseSet)]
        public override SwitchParameter FullResponse { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetManagedInstanceAnalyticContentRequest request;

            try
            {
                request = new GetManagedInstanceAnalyticContentRequest
                {
                    CompartmentId = CompartmentId,
                    ManagedInstanceGroupId = ManagedInstanceGroupId,
                    LifecycleEnvironmentId = LifecycleEnvironmentId,
                    LifecycleStageId = LifecycleStageId,
                    Status = Status,
                    DisplayName = DisplayName,
                    DisplayNameContains = DisplayNameContains,
                    InstanceLocation = InstanceLocation,
                    SecurityUpdatesAvailableEqualsTo = SecurityUpdatesAvailableEqualsTo,
                    BugUpdatesAvailableEqualsTo = BugUpdatesAvailableEqualsTo,
                    SecurityUpdatesAvailableGreaterThan = SecurityUpdatesAvailableGreaterThan,
                    BugUpdatesAvailableGreaterThan = BugUpdatesAvailableGreaterThan,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetManagedInstanceAnalyticContent(request).GetAwaiter().GetResult();
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

        private GetManagedInstanceAnalyticContentResponse response;
        private const string Default = "Default";
        private const string WriteToFileSet = "WriteToFile";
        private const string FullResponseSet = "FullResponse";
    }
}