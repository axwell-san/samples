@ECHO. & ECHO ---NUGET RESTORE--- 
@%~dp0nuget\nuget.exe restore %~dp0GoogleTests.sln 
@ECHO. & ECHO ---BUILD--- 
@"c:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" %~dp0GoogleTests.sln 
@ECHO. & ECHO ---RUN NUNIT TESTS---
@%~dp0\packages\NUnit.ConsoleRunner.3.10.0\tools\nunit3-console.exe %~dp0\GoogleTests\bin\Debug\GoogleTests.dll
@ECHO. & ECHO ---CREATE REPORT---
@%~dp0\Binaries\ReportUnit.exe "TestResult.xml" "NUnitTestResult.html"
@ECHO. & ECHO ---RUN SPECFLOW TESTS---
@%~dp0\packages\NUnit.ConsoleRunner.3.10.0\tools\nunit3-console.exe %~dp0\GoogleTestsSpecFlow\bin\Debug\GoogleTestsSpecFlow.dll
@ECHO. & ECHO ---CREATE REPORT---
@%~dp0\Binaries\ReportUnit.exe "TestResult.xml" "SpecFlowTestResult.html"
@ECHO. & pause
