# Internet Explorer Launcher

Launch Internet Explorer on Windows 11

<hr>

Released version 2.0.0


The pre-built installer can be downloaded by clicking here: [IELauncher-setup.msi](https://github.com/ciao1092/IELauncher/releases/download/2.0.0/IELauncher-setup.msi) (614 KB)

The pre-built framework-dependent version can be downloaded by clicking here: [IELauncher.exe](https://github.com/ciao1092/IELauncher/releases/download/2.0.0/IELauncher.exe) (22.3 MB)

The pre-built stand-alone version can be downloaded by clicking here: [IELauncher-sc.exe](https://github.com/ciao1092/IELauncher/releases/download/2.0.0/IELauncher-sc.exe) (206 MB)

<hr>

Released version 1.0.1

The pre-built installer can be downloaded by clicking here: <a href="https://github.com/develc/IELauncher/releases/download/v1.0.1/IELauncher-setup.msi"><button>IELauncher-setup.msi</button></a>

The pre-built stand-alone version can be downloaded by clicking here: <a href="https://github.com/develc/IELauncher/releases/download/v1.0.1/IELauncher.exe"><button>IELauncher.exe</button></a>

<hr>

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
* In the File Explorer window, navigate under Release, here you'll find 2 files (.exe and .msi)

*To uninstall the package, use the Uninstall option in right-click menu of the .msi file, or use the Control Panel/Settings.*
