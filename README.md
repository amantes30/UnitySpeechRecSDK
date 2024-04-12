# UnitySpeechRecSDK
This SDK can be used as a skeleton for starting a Unity porject that requires voice inputs.

Unity version : 2022.3.17f1

System Requirements 
-	Windows machine (Have not been tested on Mac or Linux OS)
-	4GB RAM (Recommended)
-	Windows 10 SDK extension for Visual Studio
  
            - Open Visual studio Installer
            - Modify (If you already have installed visual studio), or
            - Install if you haven't already
            - Search for Windows 10 SDK (or 11 SDK) then install to your IDE            
-	Working microphone
-	Allowing Unity access to microphone. You can do this by opening up your project;

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
# Common Error
In some case the VoiceMove.cs script might be blank, this indicates the packages haven’t been loaded properly. Solution: 

            Project Window -> Right click -> select Reimport All. 
Unity will close and reopen.

# Setup
            1. Open/Create Scene
            2. Add Voice Listener prefab to scene
            3. Make sure
                        1. Every interactable object is under one parent object
                        2. Every pickable object has tag "Pickabe".
                        3. Human object has tag "Player".
            4. Drag parent object to the Environemnt Variable in Voice Listener objects Voice listener component.
            5. Finally run your Project
# Good Luck! 🫡 Feel free to contact me if you encouter any errors.
