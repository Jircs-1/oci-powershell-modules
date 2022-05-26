/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210224
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.CertificatesmanagementService.Requests;
using Oci.CertificatesmanagementService.Responses;
using Oci.CertificatesmanagementService.Models;
using Oci.Common.Model;

namespace Oci.CertificatesmanagementService.Cmdlets
{
    [Cmdlet("Get", "OCICertificatesmanagementCertificateAuthoritiesList")]
    [OutputType(new System.Type[] { typeof(Oci.CertificatesmanagementService.Models.CertificateAuthorityCollection), typeof(Oci.CertificatesmanagementService.Responses.ListCertificateAuthoritiesResponse) })]
    public class GetOCICertificatesmanagementCertificateAuthoritiesList : OCICertificatesManagementCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If provided, the returned request ID will include this value. Otherwise, a random request ID will be generated by the service.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter that returns only resources that match the given compartment OCID.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter that returns only resources that match the given lifecycle state. The state value is case-insensitive.")]
        public System.Nullable<Oci.CertificatesmanagementService.Requests.ListCertificateAuthoritiesRequest.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter that returns only resources that match the specified name.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the certificate authority (CA). If the parameter is set to null, the service lists all CAs.")]
        public string IssuerCertificateAuthorityId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the certificate authority (CA). If the parameter is set to null, the service lists all CAs.")]
        public string CertificateAuthorityId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. You can specify only one sort order. The default order for `EXPIRATIONDATE` and 'TIMECREATED' is descending. The default order for `NAME` is ascending.")]
        public System.Nullable<Oci.CertificatesmanagementService.Requests.ListCertificateAuthoritiesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.CertificatesmanagementService.Requests.ListCertificateAuthoritiesRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return in a paginated ""List"" call.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The value of the `opc-next-page` response header from the previous ""List"" call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListCertificateAuthoritiesRequest request;

            try
            {
                request = new ListCertificateAuthoritiesRequest
                {
                    OpcRequestId = OpcRequestId,
                    CompartmentId = CompartmentId,
                    LifecycleState = LifecycleState,
                    Name = Name,
                    IssuerCertificateAuthorityId = IssuerCertificateAuthorityId,
                    CertificateAuthorityId = CertificateAuthorityId,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    Limit = Limit,
                    Page = Page
                };
                IEnumerable<ListCertificateAuthoritiesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.CertificateAuthorityCollection, true);
                }
                if(!ParameterSetName.Equals(AllPageSet) && !ParameterSetName.Equals(LimitSet) && response.OpcNextPage != null)
                {
                    WriteWarning("This operation supports pagination and not all resources were returned. Re-run using the -All option to auto paginate and list all resources.");
                }
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

        private RequestDelegate GetRequestDelegate()
        {
            IEnumerable<ListCertificateAuthoritiesResponse> DefaultRequest(ListCertificateAuthoritiesRequest request) => Enumerable.Repeat(client.ListCertificateAuthorities(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListCertificateAuthoritiesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListCertificateAuthoritiesResponse response;
        private delegate IEnumerable<ListCertificateAuthoritiesResponse> RequestDelegate(ListCertificateAuthoritiesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
