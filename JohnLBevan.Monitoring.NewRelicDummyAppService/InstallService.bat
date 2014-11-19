::if you see weird issues, check this is not UTF-8 encoded
::also ensure you run as administrator
prompt $G
pushd %~d0
::pushd C:\projects\JohnLBevan.Monitoring.NewRelicDummyAppService\JohnLBevan.Monitoring.NewRelicDummyAppService\bin\Debug
::uninstall
net stop NewRelicDummyService
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\installutil.exe /u JohnLBevan.Monitoring.NewRelicDummyAppService.exe
::install
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\installutil.exe JohnLBevan.Monitoring.NewRelicDummyAppService.exe
popd
pause