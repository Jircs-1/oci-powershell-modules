#
# Module manifest for module 'OCI.PSModules.Goldengate'
#
# Generated by: Oracle Cloud Infrastructure
#
#

@{

# Script module or binary module file associated with this manifest.
RootModule = 'assemblies/OCI.PSModules.Goldengate.dll'

# Version number of this module.
ModuleVersion = '83.3.0'

# Supported PSEditions
CompatiblePSEditions = 'Core'

# ID used to uniquely identify this module
GUID = '342128d9-559b-4b8b-9ce9-d9d50eaf7247'

# Author of this module
Author = 'Oracle Cloud Infrastructure'

# Company or vendor of this module
CompanyName = 'Oracle Corporation'

# Copyright statement for this module
Copyright = '(c) Oracle Cloud Infrastructure. All rights reserved.'

# Description of the functionality provided by this module
Description = 'This modules provides Cmdlets for OCI Goldengate Service'

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
RequiredModules = @(@{ModuleName = 'OCI.PSModules.Common'; GUID = 'b3061a0d-375b-4099-ae76-f92fb3cdcdae'; RequiredVersion = '83.3.0'; })

# Assemblies that must be loaded prior to importing this module
RequiredAssemblies = 'assemblies/OCI.DotNetSDK.Goldengate.dll'

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
CmdletsToExport = 'Copy-OCIGoldengateDeploymentBackup', 
               'Export-OCIGoldengateDeploymentWallet', 
               'Get-OCIGoldengateCertificate', 'Get-OCIGoldengateCertificatesList', 
               'Get-OCIGoldengateConnection', 
               'Get-OCIGoldengateConnectionAssignment', 
               'Get-OCIGoldengateConnectionAssignmentsList', 
               'Get-OCIGoldengateConnectionsList', 
               'Get-OCIGoldengateDatabaseRegistration', 
               'Get-OCIGoldengateDatabaseRegistrationsList', 
               'Get-OCIGoldengateDeployment', 'Get-OCIGoldengateDeploymentBackup', 
               'Get-OCIGoldengateDeploymentBackupsList', 
               'Get-OCIGoldengateDeploymentsList', 
               'Get-OCIGoldengateDeploymentTypesList', 
               'Get-OCIGoldengateDeploymentUpgrade', 
               'Get-OCIGoldengateDeploymentUpgradesList', 
               'Get-OCIGoldengateDeploymentVersionsList', 
               'Get-OCIGoldengateDeploymentWalletsOperationsList', 
               'Get-OCIGoldengateMessagesList', 'Get-OCIGoldengateTrailFilesList', 
               'Get-OCIGoldengateTrailSequencesList', 
               'Get-OCIGoldengateWorkRequest', 
               'Get-OCIGoldengateWorkRequestErrorsList', 
               'Get-OCIGoldengateWorkRequestLogsList', 
               'Get-OCIGoldengateWorkRequestsList', 
               'Import-OCIGoldengateDeploymentWallet', 
               'Invoke-OCIGoldengateCollectDeploymentDiagnostic', 
               'Invoke-OCIGoldengateDeploymentWalletExists', 
               'Invoke-OCIGoldengateRescheduleDeploymentUpgrade', 
               'Invoke-OCIGoldengateRollbackDeploymentUpgrade', 
               'Invoke-OCIGoldengateSnoozeDeploymentUpgrade', 
               'Invoke-OCIGoldengateTestConnectionAssignment', 
               'Invoke-OCIGoldengateUpgradeDeployment', 
               'Invoke-OCIGoldengateUpgradeDeploymentUpgrade', 
               'Move-OCIGoldengateConnectionCompartment', 
               'Move-OCIGoldengateDatabaseRegistrationCompartment', 
               'Move-OCIGoldengateDeploymentBackupCompartment', 
               'Move-OCIGoldengateDeploymentCompartment', 
               'New-OCIGoldengateCertificate', 'New-OCIGoldengateConnection', 
               'New-OCIGoldengateConnectionAssignment', 
               'New-OCIGoldengateDatabaseRegistration', 
               'New-OCIGoldengateDeployment', 'New-OCIGoldengateDeploymentBackup', 
               'Remove-OCIGoldengateCertificate', 'Remove-OCIGoldengateConnection', 
               'Remove-OCIGoldengateConnectionAssignment', 
               'Remove-OCIGoldengateDatabaseRegistration', 
               'Remove-OCIGoldengateDeployment', 
               'Remove-OCIGoldengateDeploymentBackup', 
               'Restore-OCIGoldengateDeployment', 'Start-OCIGoldengateDeployment', 
               'Stop-OCIGoldengateDeployment', 
               'Stop-OCIGoldengateDeploymentBackup', 
               'Stop-OCIGoldengateDeploymentUpgrade', 
               'Stop-OCIGoldengateSnoozeDeploymentUpgrade', 
               'Update-OCIGoldengateConnection', 
               'Update-OCIGoldengateDatabaseRegistration', 
               'Update-OCIGoldengateDeployment', 
               'Update-OCIGoldengateDeploymentBackup'

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
        Tags = 'PSEdition_Core','Windows','Linux','macOS','Oracle','OCI','Cloud','OracleCloudInfrastructure','Goldengate'

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

