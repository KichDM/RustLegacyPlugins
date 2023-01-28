@echo off

rust_server.exe -batchmode -cfg cfg/server.cfg -maxplayers 100 -port 28015 -datadir "rust_server_Data/" -nographics
