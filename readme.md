# Internet Explorer Launcher

A way to launch Internet Explorer on Windows 11 (but it should work also on older versions, even if it isn't needed...)

<hr>

First version released!

The pre-built installer can be downloaded by clicking here: <a href="https://github.com/develc/IELauncher/releases/download/v1.0.0/IELauncher-setup.msi"><button>IELauncher-setup.msi</button></a>

The pre-built stand-alone version can be downloaded by clicking here: <a href="https://github.com/develc/IELauncher/releases/download/v1.0.0/IELauncher.exe"><button>IELauncher.exe</button></a>


## Building

### Prerequisites:

* Install Microsoft Visual Studio (I used Community Edition 2022) with the .NET desktop workload
* (*Not needed if building standalone .EXE file*) Install the "Microsoft Visual Studio Installer Projects" extension (Continue without code --> Extensions --> Manage Extensions --> Online --> Search box --> write "Microsoft Visual Studio Installer Projects" --> install)

### To build standalone .EXE:

*  Open the solution file in Visual Studio
* Make sure the IELauncher project is selected in the Solution Explorer window
* Click on Build --> Publish Selection
* Click on Publish
* Click on the link that appears under the Settings section, where it says "Target location"

*You should now be able to run the resulting .EXE file as a standalone program. You can move it around without taking with you all the other files that are in the folder.*

### To build an installable package:

* Open the solution file in Visual Studio
* Right-click on the IELauncher in the Solution Explorer window
* Select "Build"
* Once it has finished, right-click on the IELauncher in the Solution Explorer window
* Select Open folder in File Explorer
* Under File Explorer, navigate under Release, here you'll find 2 files (.exe and .msi)

*Note that setup.exe needs the .msi file to be in the same folder, while the .msi file is indipendent and gets installed by msiexec automatically when double-clicked in Windows File Explorer*

*To uninstall the package, use the Uninstall option in right-click menu of the .msi file, or use the Control Panel/Settings.*
