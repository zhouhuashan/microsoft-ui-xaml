robocopy %HELIX_CORRELATION_PAYLOAD% . /s

REM powershell -ExecutionPolicy Bypass Get-Process
REM powershell -ExecutionPolicy Bypass Get-AppXPackage -AllUsers

REM Listdlls.exe /accepteula

REM handle.exe /accepteula AppxBlockMap.xml


REM set retries=3
REM :loop
REM te MUXControls.Test.dll MUXControlsTestApp.appx /unicodeOutput:false /testtimeout:0:10 /name:*MUXControls.InteractionTests.SplitButtonTests.ToggleTest
REM if %errorlevel%==0 goto done
REM if "%retries%"=="0" goto done
REM set /a retries= %retries% - 1
REM timeout 5
REM goto loop
REM :done




te MUXControls.Test.dll MUXControlsTestApp.appx /enablewttlogging /unicodeOutput:false /sessionTimeout:0:15 /testtimeout:0:10 %*
type te.wtl
cd scripts
powershell -ExecutionPolicy Bypass .\ConvertWttLogToXUnit.ps1 ..\te.wtl ..\testResults.xml %testnameprefix%
cd ..
type testResults.xml