@echo off
set _logs=serverdata\logs\
if not exist %_logs% MKDIR %_logs%
set _lumaemu="%USERPROFILE%\AppData\Local\LumaEmu"
if not exist %_lumaemu% MKDIR %_lumaemu%
chcp 65001
color 0F
cls
:restart
for /f "tokens=1-4 delims=/." %%a in ("%DATE%") do (set _date=%%c-%%b-%%a)
for /f "tokens=1-3 delims=,:" %%a in ("%TIME%") do (set _time=%%a%%b%%c)
rust_server.exe -batchmode -cheatpunch -datadir "serverdata/" -oxidedir "serverdata/oxide" -logfile "%_logs%output_%_date: =0%.%_time: =0%.txt"
timeout /T 5
for /f "tokens=1-4 delims=/." %%a in ("%DATE%") do (set _date=%%a-%%b-%%c)
for /f "tokens=1-2 delims=,:" %%a in ("%TIME%") do (set _time=%%a:%%b)
echo :::::::::::::::::::::::::::::::::::::::::::::::::
echo :: The server was restarted - %_date% %_time% ::
echo :::::::::::::::::::::::::::::::::::::::::::::::::
goto restart