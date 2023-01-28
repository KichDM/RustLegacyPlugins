@echo off
set _lumaemu="%USERPROFILE%\AppData\Local\LumaEmu"
if not exist %_lumaemu% MKDIR %_lumaemu%
chcp 65001
cls
:restart
color 0A
echo %time% RUST Server Started.
rust_server.exe -batchmode -cheatpunch -datadir "serverdata/"
timeout /T 5
goto restart