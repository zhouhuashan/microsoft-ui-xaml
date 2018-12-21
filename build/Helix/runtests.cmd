robocopy %HELIX_CORRELATION_PAYLOAD% . /s
powershell -ExecutionPolicy Bypass Get-Process
powershell -ExecutionPolicy Bypass Get-AppXPackage -AllUsers

Listdlls.exe /accepteula

handle.exe /accepteula AppxBlockMap.xml


set retries=3
:loop
te MUXControls.Test.dll MUXControlsTestApp.appx /unicodeOutput:false /testtimeout:0:10 /name:*MUXControls.InteractionTests.SplitButtonTests.ToggleTest
if %errorlevel%==0 goto done
if "%retries%"=="0" goto done
set /a retries= %retries% - 1
timeout 5
goto loop
:done




te MUXControls.Test.dll MUXControlsTestApp.appx /enablewttlogging /unicodeOutput:false /sessionTimeout:0:15 /testtimeout:0:10 %*
type te.wtl
cd scripts
powershell -ExecutionPolicy Bypass .\ConvertWttLogToXUnit.ps1 ..\te.wtl ..\testResults.xml %testnameprefix%
cd ..
type testResults.xml