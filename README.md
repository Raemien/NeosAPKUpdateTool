# NeosVR APK Updater

This CLI tool aims to restore functionality to Android releases of NeosVR after a recent networking hotfix. Uses [APKTool](https://github.com/iBotPeaches/Apktool) and [Uber APK Signer](https://github.com/patrickfav/uber-apk-signer) to extract, patch and sign the application with updated binaries.

Please note that this tool is not officially supported by Solirax and may break after major codebase changes.

## Requirements
- The latest PC release of NeosVR (avaliable from [Steam](https://store.steampowered.com/app/740250/Neos_VR/)/Neos Launcher)
- The latest Android release of NeosVR ([Patreon-exclusive](https://www.patreon.com/neosvr/))
- [.NET 6.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-6.0.16-windows-x64-installer)
- [Java 8+](https://www.java.com/en/download/)

## Installation
Run the program, specify your `Neos_Data` folder and the APK to patch.
After running the program, install `NeosOculus-patched.apk` using adb/SideQuest.

Tested on Quest 2 with older software revisions. Untested on v51.

## Support
Consider supporting my projects on [Patreon](https://patreon.com/raemien)! <3