@echo off

rust_server.exe -batchmode -cfg cfg/server.cfg -maxplayers 100 -port 29015 -datadir "rust_server_Data/" -nographics
