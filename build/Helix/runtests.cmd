set
robocopy %HELIX_CORRELATION_PAYLOAD% . /s
dir /b /s
powershell -ExecutionPolicy Bypass Get-Process
powershell -ExecutionPolicy Bypass Get-AppXPackage
te MUXControls.Test.dll MUXControlsTestApp.appx /enablewttlogging /unicodeOutput:false /testtimeout:0:10 %*
type te.wtl
cd scripts
powershell -ExecutionPolicy Bypass .\ConvertWttLogToXUnit.ps1 ..\te.wtl ..\testResults.xml
cd ..
type testResults.xml