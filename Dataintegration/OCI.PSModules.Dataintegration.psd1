#
# Module manifest for module 'OCI.PSModules.Dataintegration'
#
# Generated by: Oracle Cloud Infrastructure
#
#

@{

# Script module or binary module file associated with this manifest.
RootModule = 'assemblies/OCI.PSModules.Dataintegration.dll'

# Version number of this module.
ModuleVersion = '83.0.0'

# Supported PSEditions
CompatiblePSEditions = 'Core'

# ID used to uniquely identify this module
GUID = '769e2e00-1fe3-46af-a9e9-c24a01403239'

# Author of this module
Author = 'Oracle Cloud Infrastructure'

# Company or vendor of this module
CompanyName = 'Oracle Corporation'

# Copyright statement for this module
Copyright = '(c) Oracle Cloud Infrastructure. All rights reserved.'

# Description of the functionality provided by this module
Description = 'This modules provides Cmdlets for OCI Dataintegration Service'

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
RequiredModules = @(@{ModuleName = 'OCI.PSModules.Common'; GUID = 'b3061a0d-375b-4099-ae76-f92fb3cdcdae'; RequiredVersion = '83.0.0'; })

# Assemblies that must be loaded prior to importing this module
RequiredAssemblies = 'assemblies/OCI.DotNetSDK.Dataintegration.dll'

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
CmdletsToExport = 'Get-OCIDataintegrationApplication', 
               'Get-OCIDataintegrationApplicationDetailedDescription', 
               'Get-OCIDataintegrationApplicationsList', 
               'Get-OCIDataintegrationCompositeState', 
               'Get-OCIDataintegrationConnection', 
               'Get-OCIDataintegrationConnectionsList', 
               'Get-OCIDataintegrationConnectionValidation', 
               'Get-OCIDataintegrationConnectionValidationsList', 
               'Get-OCIDataintegrationCopyObjectRequest', 
               'Get-OCIDataintegrationCopyObjectRequestsList', 
               'Get-OCIDataintegrationCountStatistic', 
               'Get-OCIDataintegrationDataAsset', 
               'Get-OCIDataintegrationDataAssetsList', 
               'Get-OCIDataintegrationDataEntitiesList', 
               'Get-OCIDataintegrationDataEntity', 
               'Get-OCIDataintegrationDataFlow', 
               'Get-OCIDataintegrationDataFlowsList', 
               'Get-OCIDataintegrationDataFlowValidation', 
               'Get-OCIDataintegrationDataFlowValidationsList', 
               'Get-OCIDataintegrationDependentObject', 
               'Get-OCIDataintegrationDependentObjectsList', 
               'Get-OCIDataintegrationDisApplication', 
               'Get-OCIDataintegrationDisApplicationDetailedDescription', 
               'Get-OCIDataintegrationDisApplicationsList', 
               'Get-OCIDataintegrationDisApplicationTaskRunLineagesList', 
               'Get-OCIDataintegrationExportRequest', 
               'Get-OCIDataintegrationExportRequestsList', 
               'Get-OCIDataintegrationExternalPublication', 
               'Get-OCIDataintegrationExternalPublicationsList', 
               'Get-OCIDataintegrationExternalPublicationValidation', 
               'Get-OCIDataintegrationExternalPublicationValidationsList', 
               'Get-OCIDataintegrationFolder', 'Get-OCIDataintegrationFoldersList', 
               'Get-OCIDataintegrationFunctionLibrariesList', 
               'Get-OCIDataintegrationFunctionLibrary', 
               'Get-OCIDataintegrationImportRequest', 
               'Get-OCIDataintegrationImportRequestsList', 
               'Get-OCIDataintegrationPatch', 
               'Get-OCIDataintegrationPatchChangesList', 
               'Get-OCIDataintegrationPatchesList', 
               'Get-OCIDataintegrationPipeline', 
               'Get-OCIDataintegrationPipelinesList', 
               'Get-OCIDataintegrationPipelineValidation', 
               'Get-OCIDataintegrationPipelineValidationsList', 
               'Get-OCIDataintegrationProject', 
               'Get-OCIDataintegrationProjectsList', 
               'Get-OCIDataintegrationPublishedObject', 
               'Get-OCIDataintegrationPublishedObjectsList', 
               'Get-OCIDataintegrationReference', 
               'Get-OCIDataintegrationReferencesList', 
               'Get-OCIDataintegrationRuntimeOperator', 
               'Get-OCIDataintegrationRuntimeOperatorsList', 
               'Get-OCIDataintegrationRuntimePipeline', 
               'Get-OCIDataintegrationRuntimePipelinesList', 
               'Get-OCIDataintegrationSchedule', 
               'Get-OCIDataintegrationSchedulesList', 
               'Get-OCIDataintegrationSchema', 'Get-OCIDataintegrationSchemasList', 
               'Get-OCIDataintegrationTask', 'Get-OCIDataintegrationTaskRun', 
               'Get-OCIDataintegrationTaskRunLineagesList', 
               'Get-OCIDataintegrationTaskRunLogsList', 
               'Get-OCIDataintegrationTaskRunsList', 
               'Get-OCIDataintegrationTaskSchedule', 
               'Get-OCIDataintegrationTaskSchedulesList', 
               'Get-OCIDataintegrationTasksList', 
               'Get-OCIDataintegrationTaskValidation', 
               'Get-OCIDataintegrationTaskValidationsList', 
               'Get-OCIDataintegrationTemplate', 
               'Get-OCIDataintegrationTemplatesList', 
               'Get-OCIDataintegrationUserDefinedFunction', 
               'Get-OCIDataintegrationUserDefinedFunctionsList', 
               'Get-OCIDataintegrationUserDefinedFunctionValidation', 
               'Get-OCIDataintegrationUserDefinedFunctionValidationsList', 
               'Get-OCIDataintegrationWorkRequest', 
               'Get-OCIDataintegrationWorkRequestErrorsList', 
               'Get-OCIDataintegrationWorkRequestLogsList', 
               'Get-OCIDataintegrationWorkRequestsList', 
               'Get-OCIDataintegrationWorkspace', 
               'Get-OCIDataintegrationWorkspacesList', 
               'Move-OCIDataintegrationCompartment', 
               'Move-OCIDataintegrationDisApplicationCompartment', 
               'New-OCIDataintegrationApplication', 
               'New-OCIDataintegrationApplicationDetailedDescription', 
               'New-OCIDataintegrationConnection', 
               'New-OCIDataintegrationConnectionValidation', 
               'New-OCIDataintegrationCopyObjectRequest', 
               'New-OCIDataintegrationDataAsset', 'New-OCIDataintegrationDataFlow', 
               'New-OCIDataintegrationDataFlowValidation', 
               'New-OCIDataintegrationDisApplication', 
               'New-OCIDataintegrationDisApplicationDetailedDescription', 
               'New-OCIDataintegrationEntityShape', 
               'New-OCIDataintegrationExportRequest', 
               'New-OCIDataintegrationExternalPublication', 
               'New-OCIDataintegrationExternalPublicationValidation', 
               'New-OCIDataintegrationFolder', 
               'New-OCIDataintegrationFunctionLibrary', 
               'New-OCIDataintegrationImportRequest', 
               'New-OCIDataintegrationPatch', 'New-OCIDataintegrationPipeline', 
               'New-OCIDataintegrationPipelineValidation', 
               'New-OCIDataintegrationProject', 'New-OCIDataintegrationSchedule', 
               'New-OCIDataintegrationTask', 'New-OCIDataintegrationTaskRun', 
               'New-OCIDataintegrationTaskSchedule', 
               'New-OCIDataintegrationTaskValidation', 
               'New-OCIDataintegrationUserDefinedFunction', 
               'New-OCIDataintegrationUserDefinedFunctionValidation', 
               'New-OCIDataintegrationWorkspace', 
               'Remove-OCIDataintegrationApplication', 
               'Remove-OCIDataintegrationApplicationDetailedDescription', 
               'Remove-OCIDataintegrationConnection', 
               'Remove-OCIDataintegrationConnectionValidation', 
               'Remove-OCIDataintegrationCopyObjectRequest', 
               'Remove-OCIDataintegrationDataAsset', 
               'Remove-OCIDataintegrationDataFlow', 
               'Remove-OCIDataintegrationDataFlowValidation', 
               'Remove-OCIDataintegrationDisApplication', 
               'Remove-OCIDataintegrationDisApplicationDetailedDescription', 
               'Remove-OCIDataintegrationExportRequest', 
               'Remove-OCIDataintegrationExternalPublication', 
               'Remove-OCIDataintegrationExternalPublicationValidation', 
               'Remove-OCIDataintegrationFolder', 
               'Remove-OCIDataintegrationFunctionLibrary', 
               'Remove-OCIDataintegrationImportRequest', 
               'Remove-OCIDataintegrationPatch', 
               'Remove-OCIDataintegrationPipeline', 
               'Remove-OCIDataintegrationPipelineValidation', 
               'Remove-OCIDataintegrationProject', 
               'Remove-OCIDataintegrationSchedule', 
               'Remove-OCIDataintegrationTask', 'Remove-OCIDataintegrationTaskRun', 
               'Remove-OCIDataintegrationTaskSchedule', 
               'Remove-OCIDataintegrationTaskValidation', 
               'Remove-OCIDataintegrationUserDefinedFunction', 
               'Remove-OCIDataintegrationUserDefinedFunctionValidation', 
               'Remove-OCIDataintegrationWorkspace', 
               'Start-OCIDataintegrationWorkspace', 
               'Stop-OCIDataintegrationWorkspace', 
               'Update-OCIDataintegrationApplication', 
               'Update-OCIDataintegrationApplicationDetailedDescription', 
               'Update-OCIDataintegrationConnection', 
               'Update-OCIDataintegrationCopyObjectRequest', 
               'Update-OCIDataintegrationDataAsset', 
               'Update-OCIDataintegrationDataFlow', 
               'Update-OCIDataintegrationDisApplication', 
               'Update-OCIDataintegrationDisApplicationDetailedDescription', 
               'Update-OCIDataintegrationExportRequest', 
               'Update-OCIDataintegrationExternalPublication', 
               'Update-OCIDataintegrationFolder', 
               'Update-OCIDataintegrationFunctionLibrary', 
               'Update-OCIDataintegrationImportRequest', 
               'Update-OCIDataintegrationPipeline', 
               'Update-OCIDataintegrationProject', 
               'Update-OCIDataintegrationReference', 
               'Update-OCIDataintegrationSchedule', 
               'Update-OCIDataintegrationTask', 'Update-OCIDataintegrationTaskRun', 
               'Update-OCIDataintegrationTaskSchedule', 
               'Update-OCIDataintegrationUserDefinedFunction', 
               'Update-OCIDataintegrationWorkspace'

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
        Tags = 'PSEdition_Core','Windows','Linux','macOS','Oracle','OCI','Cloud','OracleCloudInfrastructure','Dataintegration'

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

