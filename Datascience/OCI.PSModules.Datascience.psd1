#
# Module manifest for module 'OCI.PSModules.Datascience'
#
# Generated by: Oracle Cloud Infrastructure
#
#

@{

# Script module or binary module file associated with this manifest.
RootModule = 'assemblies/OCI.PSModules.Datascience.dll'

# Version number of this module.
ModuleVersion = '47.0.0'

# Supported PSEditions
CompatiblePSEditions = 'Core'

# ID used to uniquely identify this module
GUID = 'e310e88b-80a4-4419-8054-2984936bf580'

# Author of this module
Author = 'Oracle Cloud Infrastructure'

# Company or vendor of this module
CompanyName = 'Oracle Corporation'

# Copyright statement for this module
Copyright = '(c) Oracle Cloud Infrastructure. All rights reserved.'

# Description of the functionality provided by this module
Description = 'This modules provides Cmdlets for OCI Datascience Service'

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
RequiredModules = @(@{ModuleName = 'OCI.PSModules.Common'; GUID = 'b3061a0d-375b-4099-ae76-f92fb3cdcdae'; RequiredVersion = '47.0.0'; })

# Assemblies that must be loaded prior to importing this module
RequiredAssemblies = 'assemblies/OCI.DotNetSDK.Datascience.dll'

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
CmdletsToExport = 'Enable-OCIDatascienceModel', 
               'Enable-OCIDatascienceModelDeployment', 
               'Enable-OCIDatascienceNotebookSession', 
               'Export-OCIDatascienceModelArtifact', 
               'Get-OCIDatascienceFastLaunchJobConfigsList', 
               'Get-OCIDatascienceJob', 'Get-OCIDatascienceJobArtifactContent', 
               'Get-OCIDatascienceJobRun', 'Get-OCIDatascienceJobRunsList', 
               'Get-OCIDatascienceJobShapesList', 'Get-OCIDatascienceJobsList', 
               'Get-OCIDatascienceModel', 'Get-OCIDatascienceModelArtifactContent', 
               'Get-OCIDatascienceModelDeployment', 
               'Get-OCIDatascienceModelDeploymentShapesList', 
               'Get-OCIDatascienceModelDeploymentsList', 
               'Get-OCIDatascienceModelProvenance', 'Get-OCIDatascienceModelsList', 
               'Get-OCIDatascienceNotebookSession', 
               'Get-OCIDatascienceNotebookSessionShapesList', 
               'Get-OCIDatascienceNotebookSessionsList', 
               'Get-OCIDatascienceProject', 'Get-OCIDatascienceProjectsList', 
               'Get-OCIDatascienceWorkRequest', 
               'Get-OCIDatascienceWorkRequestErrorsList', 
               'Get-OCIDatascienceWorkRequestLogsList', 
               'Get-OCIDatascienceWorkRequestsList', 
               'Import-OCIDatascienceModelArtifact', 
               'Invoke-OCIDatascienceDeactivateModel', 
               'Invoke-OCIDatascienceDeactivateModelDeployment', 
               'Invoke-OCIDatascienceDeactivateNotebookSession', 
               'Invoke-OCIDatascienceHeadJobArtifact', 
               'Invoke-OCIDatascienceHeadModelArtifact', 
               'Move-OCIDatascienceJobCompartment', 
               'Move-OCIDatascienceJobRunCompartment', 
               'Move-OCIDatascienceModelCompartment', 
               'Move-OCIDatascienceModelDeploymentCompartment', 
               'Move-OCIDatascienceNotebookSessionCompartment', 
               'Move-OCIDatascienceProjectCompartment', 'New-OCIDatascienceJob', 
               'New-OCIDatascienceJobArtifact', 'New-OCIDatascienceJobRun', 
               'New-OCIDatascienceModel', 'New-OCIDatascienceModelArtifact', 
               'New-OCIDatascienceModelDeployment', 
               'New-OCIDatascienceModelProvenance', 
               'New-OCIDatascienceNotebookSession', 'New-OCIDatascienceProject', 
               'Remove-OCIDatascienceJob', 'Remove-OCIDatascienceJobRun', 
               'Remove-OCIDatascienceModel', 
               'Remove-OCIDatascienceModelDeployment', 
               'Remove-OCIDatascienceNotebookSession', 
               'Remove-OCIDatascienceProject', 'Stop-OCIDatascienceJobRun', 
               'Stop-OCIDatascienceWorkRequest', 'Update-OCIDatascienceJob', 
               'Update-OCIDatascienceJobRun', 'Update-OCIDatascienceModel', 
               'Update-OCIDatascienceModelDeployment', 
               'Update-OCIDatascienceModelProvenance', 
               'Update-OCIDatascienceNotebookSession', 
               'Update-OCIDatascienceProject'

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
        Tags = 'PSEdition_Core','Windows','Linux','macOS','Oracle','OCI','Cloud','OracleCloudInfrastructure','Datascience'

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

