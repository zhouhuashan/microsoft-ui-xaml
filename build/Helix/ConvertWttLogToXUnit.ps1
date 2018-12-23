Param(
    [Parameter(Mandatory = $true)] 
    [string]$WttInputPath,

    [Parameter(Mandatory = $true)] 
    [string]$XUnitOutputPath,

    [Parameter(Mandatory = $true)] 
    [string]$testNamePrefix
)

Add-Type -Language CSharp -ReferencedAssemblies System.Xml,System.Xml.Linq (Get-Content .\ConvertWttLogToXUnit.cs -Raw)

[HelixTestHelpers.TestResultParser]::ConvertWttLogToXUnitLog($WttInputPath, $XUnitOutputPath, $testNamePrefix)