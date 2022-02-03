# UnitySpeechRecSDK
This is an SDK which can show a way for developers to use voice inputs as command for a software in unity

Unity version : 2020.3.15

Requirements for Speech recognition system SDK 
-	Windows machine (Have not been tested on Mac or Linux OS)
-	4GB RAM (Recommended)
-	Windows 10 SDK extension for Visual Studio

            - Open Visual studio Installer
            - Modify (If you already have installed visual studio), or
            - Install if you haven't already
            - then search for windows 10 SDK or 11 SDK then install to you IDE            
-	Working microphone on computer
-	Allowing Unity projects to access microphone.

            Edit -> Project Settings -> Player -> Publishing Settings -> Capabilities -> Check on Microphone

# Build Settings
Platform - PC, Mac, Linux Standalone

Target Platform - Windows

Compression Method - Default

# Player Settings - > Other settings
Configuration

Scripting Backend - Mono

API compatibility Level - .NET Standard 2.0

Active Input Handling - Input Manager (Old)

