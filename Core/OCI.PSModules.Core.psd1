#
# Module manifest for module 'OCI.PSModules.Core'
#
# Generated by: Oracle Cloud Infrastructure
#
#

@{

# Script module or binary module file associated with this manifest.
RootModule = 'assemblies/OCI.PSModules.Core.dll'

# Version number of this module.
ModuleVersion = '40.0.0'

# Supported PSEditions
CompatiblePSEditions = 'Core'

# ID used to uniquely identify this module
GUID = '6da66bae-1e88-4a00-9740-811ccd4999c8'

# Author of this module
Author = 'Oracle Cloud Infrastructure'

# Company or vendor of this module
CompanyName = 'Oracle Corporation'

# Copyright statement for this module
Copyright = '(c) Oracle Cloud Infrastructure. All rights reserved.'

# Description of the functionality provided by this module
Description = 'This modules provides Cmdlets for OCI Core Service'

# Minimum version of the PowerShell engine required by this module
PowerShellVersion = '6.0'

# Name of the PowerShell host required by this module
# PowerShellHostName = ''

# Minimum version of the PowerShell host required by this module
# PowerShellHostVersion = ''

# Minimum version of Microsoft .NET Framework required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
# DotNetFrameworkVersion = ''

# Minimum version of the common language runtime (CLR) required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
# ClrVersion = ''

# Processor architecture (None, X86, Amd64) required by this module
# ProcessorArchitecture = ''

# Modules that must be imported into the global environment prior to importing this module
RequiredModules = @(@{ModuleName = 'OCI.PSModules.Common'; GUID = 'b3061a0d-375b-4099-ae76-f92fb3cdcdae'; RequiredVersion = '40.0.0'; })

# Assemblies that must be loaded prior to importing this module
RequiredAssemblies = 'assemblies/OCI.DotNetSDK.Core.dll'

# Script files (.ps1) that are run in the caller's environment prior to importing this module.
# ScriptsToProcess = @()

# Type files (.ps1xml) to be loaded when importing this module
# TypesToProcess = @()

# Format files (.ps1xml) to be loaded when importing this module
# FormatsToProcess = @()

# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
# NestedModules = @()

# Functions to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no functions to export.
FunctionsToExport = '*'

# Cmdlets to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no cmdlets to export.
CmdletsToExport = 'Add-OCIComputeImageShapeCompatibilityEntry', 
               'Add-OCIVirtualNetworkDrgRouteDistributionStatements', 
               'Add-OCIVirtualNetworkDrgRouteRules', 
               'Add-OCIVirtualNetworkIpv6SubnetCidr', 
               'Add-OCIVirtualNetworkIpv6VcnCidr', 
               'Add-OCIVirtualNetworkNetworkSecurityGroupSecurityRules', 
               'Add-OCIVirtualNetworkPublicIpPoolCapacity', 
               'Add-OCIVirtualNetworkVcnCidr', 
               'Confirm-OCIVirtualNetworkByoipRange', 
               'Connect-OCIVirtualNetworkLocalPeeringGateways', 
               'Connect-OCIVirtualNetworkRemotePeeringConnections', 
               'Copy-OCIBlockstorageBootVolumeBackup', 
               'Copy-OCIBlockstorageVolumeBackup', 
               'Copy-OCIBlockstorageVolumeGroupBackup', 
               'DisMount-OCIComputeBootVolume', 
               'DisMount-OCIComputeManagementInstancePoolInstance', 
               'DisMount-OCIComputeManagementLoadBalancer', 
               'DisMount-OCIComputeVnic', 'DisMount-OCIComputeVolume', 
               'DisMount-OCIVirtualNetworkServiceId', 
               'Edit-OCIVirtualNetworkVcnCidr', 'Export-OCIComputeImage', 
               'Get-OCIBlockstorageBlockVolumeReplica', 
               'Get-OCIBlockstorageBlockVolumeReplicasList', 
               'Get-OCIBlockstorageBootVolume', 
               'Get-OCIBlockstorageBootVolumeBackup', 
               'Get-OCIBlockstorageBootVolumeBackupsList', 
               'Get-OCIBlockstorageBootVolumeKmsKey', 
               'Get-OCIBlockstorageBootVolumeReplica', 
               'Get-OCIBlockstorageBootVolumeReplicasList', 
               'Get-OCIBlockstorageBootVolumesList', 'Get-OCIBlockstorageVolume', 
               'Get-OCIBlockstorageVolumeBackup', 
               'Get-OCIBlockstorageVolumeBackupPoliciesList', 
               'Get-OCIBlockstorageVolumeBackupPolicy', 
               'Get-OCIBlockstorageVolumeBackupPolicyAssetAssignment', 
               'Get-OCIBlockstorageVolumeBackupPolicyAssignment', 
               'Get-OCIBlockstorageVolumeBackupsList', 
               'Get-OCIBlockstorageVolumeGroup', 
               'Get-OCIBlockstorageVolumeGroupBackup', 
               'Get-OCIBlockstorageVolumeGroupBackupsList', 
               'Get-OCIBlockstorageVolumeGroupReplica', 
               'Get-OCIBlockstorageVolumeGroupReplicasList', 
               'Get-OCIBlockstorageVolumeGroupsList', 
               'Get-OCIBlockstorageVolumeKmsKey', 'Get-OCIBlockstorageVolumesList', 
               'Get-OCIComputeAppCatalogListing', 
               'Get-OCIComputeAppCatalogListingAgreements', 
               'Get-OCIComputeAppCatalogListingResourceVersion', 
               'Get-OCIComputeAppCatalogListingResourceVersionsList', 
               'Get-OCIComputeAppCatalogListingsList', 
               'Get-OCIComputeAppCatalogSubscriptionsList', 
               'Get-OCIComputeBootVolumeAttachment', 
               'Get-OCIComputeBootVolumeAttachmentsList', 
               'Get-OCIComputeCapacityReservation', 
               'Get-OCIComputeCapacityReservationInstanceShapesList', 
               'Get-OCIComputeCapacityReservationInstancesList', 
               'Get-OCIComputeCapacityReservationsList', 
               'Get-OCIComputeConsoleHistoriesList', 
               'Get-OCIComputeConsoleHistory', 
               'Get-OCIComputeConsoleHistoryContent', 
               'Get-OCIComputeDedicatedVmHost', 
               'Get-OCIComputeDedicatedVmHostInstanceShapesList', 
               'Get-OCIComputeDedicatedVmHostInstancesList', 
               'Get-OCIComputeDedicatedVmHostShapesList', 
               'Get-OCIComputeDedicatedVmHostsList', 
               'Get-OCIComputeGlobalImageCapabilitySchema', 
               'Get-OCIComputeGlobalImageCapabilitySchemasList', 
               'Get-OCIComputeGlobalImageCapabilitySchemaVersion', 
               'Get-OCIComputeGlobalImageCapabilitySchemaVersionsList', 
               'Get-OCIComputeImage', 'Get-OCIComputeImageCapabilitySchema', 
               'Get-OCIComputeImageCapabilitySchemasList', 
               'Get-OCIComputeImageShapeCompatibilityEntriesList', 
               'Get-OCIComputeImageShapeCompatibilityEntry', 
               'Get-OCIComputeImagesList', 'Get-OCIComputeInstance', 
               'Get-OCIComputeInstanceConsoleConnection', 
               'Get-OCIComputeInstanceConsoleConnectionsList', 
               'Get-OCIComputeInstanceDevicesList', 
               'Get-OCIComputeInstanceMaintenanceReboot', 
               'Get-OCIComputeInstancesList', 
               'Get-OCIComputeManagementClusterNetwork', 
               'Get-OCIComputeManagementClusterNetworkInstancesList', 
               'Get-OCIComputeManagementClusterNetworksList', 
               'Get-OCIComputeManagementInstanceConfiguration', 
               'Get-OCIComputeManagementInstanceConfigurationsList', 
               'Get-OCIComputeManagementInstancePool', 
               'Get-OCIComputeManagementInstancePoolInstance', 
               'Get-OCIComputeManagementInstancePoolInstancesList', 
               'Get-OCIComputeManagementInstancePoolLoadBalancerAttachment', 
               'Get-OCIComputeManagementInstancePoolsList', 
               'Get-OCIComputeMeasuredBootReport', 'Get-OCIComputeShapesList', 
               'Get-OCIComputeVnicAttachment', 'Get-OCIComputeVnicAttachmentsList', 
               'Get-OCIComputeVolumeAttachment', 
               'Get-OCIComputeVolumeAttachmentsList', 
               'Get-OCIComputeWindowsInstanceInitialCredentials', 
               'Get-OCIVirtualNetworkAllDrgAttachments', 
               'Get-OCIVirtualNetworkAllowedIkeIPSecParameters', 
               'Get-OCIVirtualNetworkAllowedPeerRegionsForRemotePeeringList', 
               'Get-OCIVirtualNetworkByoipAllocatedRangesList', 
               'Get-OCIVirtualNetworkByoipRange', 
               'Get-OCIVirtualNetworkByoipRangesList', 
               'Get-OCIVirtualNetworkCaptureFilter', 
               'Get-OCIVirtualNetworkCaptureFiltersList', 
               'Get-OCIVirtualNetworkCpe', 
               'Get-OCIVirtualNetworkCpeDeviceConfigContent', 
               'Get-OCIVirtualNetworkCpeDeviceShape', 
               'Get-OCIVirtualNetworkCpeDeviceShapesList', 
               'Get-OCIVirtualNetworkCpesList', 
               'Get-OCIVirtualNetworkCrossConnect', 
               'Get-OCIVirtualNetworkCrossConnectGroup', 
               'Get-OCIVirtualNetworkCrossConnectGroupsList', 
               'Get-OCIVirtualNetworkCrossConnectLetterOfAuthority', 
               'Get-OCIVirtualNetworkCrossConnectLocationsList', 
               'Get-OCIVirtualNetworkCrossConnectMappingsList', 
               'Get-OCIVirtualNetworkCrossconnectPortSpeedShapesList', 
               'Get-OCIVirtualNetworkCrossConnectsList', 
               'Get-OCIVirtualNetworkCrossConnectStatus', 
               'Get-OCIVirtualNetworkDhcpOptions', 
               'Get-OCIVirtualNetworkDhcpOptionsList', 'Get-OCIVirtualNetworkDrg', 
               'Get-OCIVirtualNetworkDrgAttachment', 
               'Get-OCIVirtualNetworkDrgAttachmentsList', 
               'Get-OCIVirtualNetworkDrgRedundancyStatus', 
               'Get-OCIVirtualNetworkDrgRouteDistribution', 
               'Get-OCIVirtualNetworkDrgRouteDistributionsList', 
               'Get-OCIVirtualNetworkDrgRouteDistributionStatementsList', 
               'Get-OCIVirtualNetworkDrgRouteRulesList', 
               'Get-OCIVirtualNetworkDrgRouteTable', 
               'Get-OCIVirtualNetworkDrgRouteTablesList', 
               'Get-OCIVirtualNetworkDrgsList', 
               'Get-OCIVirtualNetworkFastConnectProviderService', 
               'Get-OCIVirtualNetworkFastConnectProviderServiceKey', 
               'Get-OCIVirtualNetworkFastConnectProviderServicesList', 
               'Get-OCIVirtualNetworkFastConnectProviderVirtualCircuitBandwidthShapesList', 
               'Get-OCIVirtualNetworkInternetGateway', 
               'Get-OCIVirtualNetworkInternetGatewaysList', 
               'Get-OCIVirtualNetworkIPSecConnection', 
               'Get-OCIVirtualNetworkIPSecConnectionDeviceConfig', 
               'Get-OCIVirtualNetworkIPSecConnectionDeviceStatus', 
               'Get-OCIVirtualNetworkIPSecConnectionsList', 
               'Get-OCIVirtualNetworkIPSecConnectionTunnel', 
               'Get-OCIVirtualNetworkIPSecConnectionTunnelError', 
               'Get-OCIVirtualNetworkIPSecConnectionTunnelRoutesList', 
               'Get-OCIVirtualNetworkIPSecConnectionTunnelSecurityAssociationsList', 
               'Get-OCIVirtualNetworkIPSecConnectionTunnelSharedSecret', 
               'Get-OCIVirtualNetworkIPSecConnectionTunnelsList', 
               'Get-OCIVirtualNetworkIpsecCpeDeviceConfigContent', 
               'Get-OCIVirtualNetworkIpv6', 'Get-OCIVirtualNetworkIpv6sList', 
               'Get-OCIVirtualNetworkLocalPeeringGateway', 
               'Get-OCIVirtualNetworkLocalPeeringGatewaysList', 
               'Get-OCIVirtualNetworkNatGateway', 
               'Get-OCIVirtualNetworkNatGatewaysList', 
               'Get-OCIVirtualNetworkNetworkingTopology', 
               'Get-OCIVirtualNetworkNetworkSecurityGroup', 
               'Get-OCIVirtualNetworkNetworkSecurityGroupSecurityRulesList', 
               'Get-OCIVirtualNetworkNetworkSecurityGroupsList', 
               'Get-OCIVirtualNetworkNetworkSecurityGroupVnicsList', 
               'Get-OCIVirtualNetworkPrivateIp', 
               'Get-OCIVirtualNetworkPrivateIpsList', 
               'Get-OCIVirtualNetworkPublicIp', 
               'Get-OCIVirtualNetworkPublicIpByIpAddress', 
               'Get-OCIVirtualNetworkPublicIpByPrivateIpId', 
               'Get-OCIVirtualNetworkPublicIpPool', 
               'Get-OCIVirtualNetworkPublicIpPoolsList', 
               'Get-OCIVirtualNetworkPublicIpsList', 
               'Get-OCIVirtualNetworkRemotePeeringConnection', 
               'Get-OCIVirtualNetworkRemotePeeringConnectionsList', 
               'Get-OCIVirtualNetworkRouteTable', 
               'Get-OCIVirtualNetworkRouteTablesList', 
               'Get-OCIVirtualNetworkSecurityList', 
               'Get-OCIVirtualNetworkSecurityListsList', 
               'Get-OCIVirtualNetworkService', 
               'Get-OCIVirtualNetworkServiceGateway', 
               'Get-OCIVirtualNetworkServiceGatewaysList', 
               'Get-OCIVirtualNetworkServicesList', 'Get-OCIVirtualNetworkSubnet', 
               'Get-OCIVirtualNetworkSubnetsList', 
               'Get-OCIVirtualNetworkSubnetTopology', 
               'Get-OCIVirtualNetworkTunnelCpeDeviceConfig', 
               'Get-OCIVirtualNetworkTunnelCpeDeviceConfigContent', 
               'Get-OCIVirtualNetworkUpgradeStatus', 'Get-OCIVirtualNetworkVcn', 
               'Get-OCIVirtualNetworkVcnDnsResolverAssociation', 
               'Get-OCIVirtualNetworkVcnsList', 'Get-OCIVirtualNetworkVcnTopology', 
               'Get-OCIVirtualNetworkVirtualCircuit', 
               'Get-OCIVirtualNetworkVirtualCircuitBandwidthShapesList', 
               'Get-OCIVirtualNetworkVirtualCircuitPublicPrefixesList', 
               'Get-OCIVirtualNetworkVirtualCircuitsList', 
               'Get-OCIVirtualNetworkVlan', 'Get-OCIVirtualNetworkVlansList', 
               'Get-OCIVirtualNetworkVnic', 'Get-OCIVirtualNetworkVtap', 
               'Get-OCIVirtualNetworkVtapsList', 'Invoke-OCIComputeInstanceAction', 
               'Invoke-OCIComputeManagementLaunchInstanceConfiguration', 
               'Invoke-OCIComputeManagementSoftresetInstancePool', 
               'Invoke-OCIComputeManagementTerminateClusterNetwork', 
               'Invoke-OCIComputeManagementTerminateInstancePool', 
               'Invoke-OCIComputeTerminateInstance', 
               'Invoke-OCIVirtualNetworkAdvertiseByoipRange', 
               'Invoke-OCIVirtualNetworkBulkAddVirtualCircuitPublicPrefixes', 
               'Invoke-OCIVirtualNetworkBulkDeleteVirtualCircuitPublicPrefixes', 
               'Invoke-OCIVirtualNetworkUpgradeDrg', 
               'Invoke-OCIVirtualNetworkWithdrawByoipRange', 
               'Mount-OCIComputeBootVolume', 
               'Mount-OCIComputeManagementInstancePoolInstance', 
               'Mount-OCIComputeManagementLoadBalancer', 'Mount-OCIComputeVnic', 
               'Mount-OCIComputeVolume', 'Mount-OCIVirtualNetworkServiceId', 
               'Move-OCIBlockstorageBootVolumeBackupCompartment', 
               'Move-OCIBlockstorageBootVolumeCompartment', 
               'Move-OCIBlockstorageVolumeBackupCompartment', 
               'Move-OCIBlockstorageVolumeCompartment', 
               'Move-OCIBlockstorageVolumeGroupBackupCompartment', 
               'Move-OCIBlockstorageVolumeGroupCompartment', 
               'Move-OCIComputeCapacityReservationCompartment', 
               'Move-OCIComputeDedicatedVmHostCompartment', 
               'Move-OCIComputeImageCapabilitySchemaCompartment', 
               'Move-OCIComputeImageCompartment', 
               'Move-OCIComputeInstanceCompartment', 
               'Move-OCIComputeManagementClusterNetworkCompartment', 
               'Move-OCIComputeManagementInstanceConfigurationCompartment', 
               'Move-OCIComputeManagementInstancePoolCompartment', 
               'Move-OCIVirtualNetworkByoipRangeCompartment', 
               'Move-OCIVirtualNetworkCaptureFilterCompartment', 
               'Move-OCIVirtualNetworkCpeCompartment', 
               'Move-OCIVirtualNetworkCrossConnectCompartment', 
               'Move-OCIVirtualNetworkCrossConnectGroupCompartment', 
               'Move-OCIVirtualNetworkDhcpOptionsCompartment', 
               'Move-OCIVirtualNetworkDrgCompartment', 
               'Move-OCIVirtualNetworkInternetGatewayCompartment', 
               'Move-OCIVirtualNetworkIPSecConnectionCompartment', 
               'Move-OCIVirtualNetworkLocalPeeringGatewayCompartment', 
               'Move-OCIVirtualNetworkNatGatewayCompartment', 
               'Move-OCIVirtualNetworkNetworkSecurityGroupCompartment', 
               'Move-OCIVirtualNetworkPublicIpCompartment', 
               'Move-OCIVirtualNetworkPublicIpPoolCompartment', 
               'Move-OCIVirtualNetworkRemotePeeringConnectionCompartment', 
               'Move-OCIVirtualNetworkRouteTableCompartment', 
               'Move-OCIVirtualNetworkSecurityListCompartment', 
               'Move-OCIVirtualNetworkServiceGatewayCompartment', 
               'Move-OCIVirtualNetworkSubnetCompartment', 
               'Move-OCIVirtualNetworkVcnCompartment', 
               'Move-OCIVirtualNetworkVirtualCircuitCompartment', 
               'Move-OCIVirtualNetworkVlanCompartment', 
               'Move-OCIVirtualNetworkVtapCompartment', 
               'New-OCIBlockstorageBootVolume', 
               'New-OCIBlockstorageBootVolumeBackup', 'New-OCIBlockstorageVolume', 
               'New-OCIBlockstorageVolumeBackup', 
               'New-OCIBlockstorageVolumeBackupPolicy', 
               'New-OCIBlockstorageVolumeBackupPolicyAssignment', 
               'New-OCIBlockstorageVolumeGroup', 
               'New-OCIBlockstorageVolumeGroupBackup', 
               'New-OCIComputeAppCatalogSubscription', 
               'New-OCIComputeCapacityReservation', 
               'New-OCIComputeDedicatedVmHost', 'New-OCIComputeImage', 
               'New-OCIComputeImageCapabilitySchema', 'New-OCIComputeInstance', 
               'New-OCIComputeInstanceConsoleConnection', 
               'New-OCIComputeManagementClusterNetwork', 
               'New-OCIComputeManagementInstanceConfiguration', 
               'New-OCIComputeManagementInstancePool', 
               'New-OCIVirtualNetworkByoipRange', 
               'New-OCIVirtualNetworkCaptureFilter', 'New-OCIVirtualNetworkCpe', 
               'New-OCIVirtualNetworkCrossConnect', 
               'New-OCIVirtualNetworkCrossConnectGroup', 
               'New-OCIVirtualNetworkDhcpOptions', 'New-OCIVirtualNetworkDrg', 
               'New-OCIVirtualNetworkDrgAttachment', 
               'New-OCIVirtualNetworkDrgRouteDistribution', 
               'New-OCIVirtualNetworkDrgRouteTable', 
               'New-OCIVirtualNetworkInternetGateway', 
               'New-OCIVirtualNetworkIPSecConnection', 'New-OCIVirtualNetworkIpv6', 
               'New-OCIVirtualNetworkLocalPeeringGateway', 
               'New-OCIVirtualNetworkNatGateway', 
               'New-OCIVirtualNetworkNetworkSecurityGroup', 
               'New-OCIVirtualNetworkPrivateIp', 'New-OCIVirtualNetworkPublicIp', 
               'New-OCIVirtualNetworkPublicIpPool', 
               'New-OCIVirtualNetworkRemotePeeringConnection', 
               'New-OCIVirtualNetworkRouteTable', 
               'New-OCIVirtualNetworkSecurityList', 
               'New-OCIVirtualNetworkServiceGateway', 
               'New-OCIVirtualNetworkSubnet', 'New-OCIVirtualNetworkVcn', 
               'New-OCIVirtualNetworkVirtualCircuit', 'New-OCIVirtualNetworkVlan', 
               'New-OCIVirtualNetworkVtap', 
               'Receive-OCIComputeShieldedIntegrityPolicy', 
               'Remove-OCIBlockstorageBootVolume', 
               'Remove-OCIBlockstorageBootVolumeBackup', 
               'Remove-OCIBlockstorageBootVolumeKmsKey', 
               'Remove-OCIBlockstorageVolume', 
               'Remove-OCIBlockstorageVolumeBackup', 
               'Remove-OCIBlockstorageVolumeBackupPolicy', 
               'Remove-OCIBlockstorageVolumeBackupPolicyAssignment', 
               'Remove-OCIBlockstorageVolumeGroup', 
               'Remove-OCIBlockstorageVolumeGroupBackup', 
               'Remove-OCIBlockstorageVolumeKmsKey', 
               'Remove-OCIComputeAppCatalogSubscription', 
               'Remove-OCIComputeCapacityReservation', 
               'Remove-OCIComputeConsoleHistory', 
               'Remove-OCIComputeDedicatedVmHost', 'Remove-OCIComputeImage', 
               'Remove-OCIComputeImageCapabilitySchema', 
               'Remove-OCIComputeImageShapeCompatibilityEntry', 
               'Remove-OCIComputeInstanceConsoleConnection', 
               'Remove-OCIComputeManagementInstanceConfiguration', 
               'Remove-OCIVirtualNetworkByoipRange', 
               'Remove-OCIVirtualNetworkCaptureFilter', 
               'Remove-OCIVirtualNetworkCpe', 
               'Remove-OCIVirtualNetworkCrossConnect', 
               'Remove-OCIVirtualNetworkCrossConnectGroup', 
               'Remove-OCIVirtualNetworkDhcpOptions', 
               'Remove-OCIVirtualNetworkDrg', 
               'Remove-OCIVirtualNetworkDrgAttachment', 
               'Remove-OCIVirtualNetworkDrgRouteDistribution', 
               'Remove-OCIVirtualNetworkDrgRouteDistributionStatements', 
               'Remove-OCIVirtualNetworkDrgRouteRules', 
               'Remove-OCIVirtualNetworkDrgRouteTable', 
               'Remove-OCIVirtualNetworkExportDrgRouteDistribution', 
               'Remove-OCIVirtualNetworkImportDrgRouteDistribution', 
               'Remove-OCIVirtualNetworkInternetGateway', 
               'Remove-OCIVirtualNetworkIPSecConnection', 
               'Remove-OCIVirtualNetworkIpv6', 
               'Remove-OCIVirtualNetworkIpv6SubnetCidr', 
               'Remove-OCIVirtualNetworkIpv6VcnCidr', 
               'Remove-OCIVirtualNetworkLocalPeeringGateway', 
               'Remove-OCIVirtualNetworkNatGateway', 
               'Remove-OCIVirtualNetworkNetworkSecurityGroup', 
               'Remove-OCIVirtualNetworkNetworkSecurityGroupSecurityRules', 
               'Remove-OCIVirtualNetworkPrivateIp', 
               'Remove-OCIVirtualNetworkPublicIp', 
               'Remove-OCIVirtualNetworkPublicIpPool', 
               'Remove-OCIVirtualNetworkPublicIpPoolCapacity', 
               'Remove-OCIVirtualNetworkRemotePeeringConnection', 
               'Remove-OCIVirtualNetworkRouteTable', 
               'Remove-OCIVirtualNetworkSecurityList', 
               'Remove-OCIVirtualNetworkServiceGateway', 
               'Remove-OCIVirtualNetworkSubnet', 'Remove-OCIVirtualNetworkVcn', 
               'Remove-OCIVirtualNetworkVcnCidr', 
               'Remove-OCIVirtualNetworkVirtualCircuit', 
               'Remove-OCIVirtualNetworkVlan', 'Remove-OCIVirtualNetworkVtap', 
               'Reset-OCIComputeManagementInstancePool', 
               'Save-OCIComputeConsoleHistory', 
               'Start-OCIComputeManagementInstancePool', 
               'Stop-OCIComputeManagementInstancePool', 
               'Update-OCIBlockstorageBootVolume', 
               'Update-OCIBlockstorageBootVolumeBackup', 
               'Update-OCIBlockstorageBootVolumeKmsKey', 
               'Update-OCIBlockstorageVolume', 
               'Update-OCIBlockstorageVolumeBackup', 
               'Update-OCIBlockstorageVolumeBackupPolicy', 
               'Update-OCIBlockstorageVolumeGroup', 
               'Update-OCIBlockstorageVolumeGroupBackup', 
               'Update-OCIBlockstorageVolumeKmsKey', 
               'Update-OCIComputeCapacityReservation', 
               'Update-OCIComputeConsoleHistory', 
               'Update-OCIComputeDedicatedVmHost', 'Update-OCIComputeImage', 
               'Update-OCIComputeImageCapabilitySchema', 
               'Update-OCIComputeInstance', 
               'Update-OCIComputeInstanceConsoleConnection', 
               'Update-OCIComputeManagementClusterNetwork', 
               'Update-OCIComputeManagementInstanceConfiguration', 
               'Update-OCIComputeManagementInstancePool', 
               'Update-OCIComputeVolumeAttachment', 
               'Update-OCIVirtualNetworkByoipRange', 
               'Update-OCIVirtualNetworkCaptureFilter', 
               'Update-OCIVirtualNetworkCpe', 
               'Update-OCIVirtualNetworkCrossConnect', 
               'Update-OCIVirtualNetworkCrossConnectGroup', 
               'Update-OCIVirtualNetworkDhcpOptions', 
               'Update-OCIVirtualNetworkDrg', 
               'Update-OCIVirtualNetworkDrgAttachment', 
               'Update-OCIVirtualNetworkDrgRouteDistribution', 
               'Update-OCIVirtualNetworkDrgRouteDistributionStatements', 
               'Update-OCIVirtualNetworkDrgRouteRules', 
               'Update-OCIVirtualNetworkDrgRouteTable', 
               'Update-OCIVirtualNetworkInternetGateway', 
               'Update-OCIVirtualNetworkIPSecConnection', 
               'Update-OCIVirtualNetworkIPSecConnectionTunnel', 
               'Update-OCIVirtualNetworkIPSecConnectionTunnelSharedSecret', 
               'Update-OCIVirtualNetworkIpv6', 
               'Update-OCIVirtualNetworkLocalPeeringGateway', 
               'Update-OCIVirtualNetworkNatGateway', 
               'Update-OCIVirtualNetworkNetworkSecurityGroup', 
               'Update-OCIVirtualNetworkNetworkSecurityGroupSecurityRules', 
               'Update-OCIVirtualNetworkPrivateIp', 
               'Update-OCIVirtualNetworkPublicIp', 
               'Update-OCIVirtualNetworkPublicIpPool', 
               'Update-OCIVirtualNetworkRemotePeeringConnection', 
               'Update-OCIVirtualNetworkRouteTable', 
               'Update-OCIVirtualNetworkSecurityList', 
               'Update-OCIVirtualNetworkServiceGateway', 
               'Update-OCIVirtualNetworkSubnet', 
               'Update-OCIVirtualNetworkTunnelCpeDeviceConfig', 
               'Update-OCIVirtualNetworkVcn', 
               'Update-OCIVirtualNetworkVirtualCircuit', 
               'Update-OCIVirtualNetworkVlan', 'Update-OCIVirtualNetworkVnic', 
               'Update-OCIVirtualNetworkVtap'

# Variables to export from this module
VariablesToExport = '*'

# Aliases to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no aliases to export.
AliasesToExport = '*'

# DSC resources to export from this module
# DscResourcesToExport = @()

# List of all modules packaged with this module
# ModuleList = @()

# List of all files packaged with this module
# FileList = @()

# Private data to pass to the module specified in RootModule/ModuleToProcess. This may also contain a PSData hashtable with additional module metadata used by PowerShell.
PrivateData = @{

    PSData = @{

        # Tags applied to this module. These help with module discovery in online galleries.
        Tags = 'PSEdition_Core','Windows','Linux','macOS','Oracle','OCI','Cloud','OracleCloudInfrastructure','Core'

        # A URL to the license for this module.
        LicenseUri = 'https://github.com/oracle/oci-powershell-modules/blob/master/LICENSE.txt'

        # A URL to the main website for this project.
        ProjectUri = 'https://github.com/oracle/oci-powershell-modules/'

        # A URL to an icon representing this module.
        IconUri = 'https://github.com/oracle/oci-powershell-modules/blob/master/icon.png'

        # ReleaseNotes of this module
        ReleaseNotes = 'https://github.com/oracle/oci-powershell-modules/blob/master/CHANGELOG.md'

        # Prerelease string of this module
        # Prerelease = ''

        # Flag to indicate whether the module requires explicit user acceptance for install/update/save
        # RequireLicenseAcceptance = $false

        # External dependent modules of this module
        # ExternalModuleDependencies = @()

    } # End of PSData hashtable

 } # End of PrivateData hashtable

# HelpInfo URI of this module
# HelpInfoURI = ''

# Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
# DefaultCommandPrefix = ''

}

