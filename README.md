# UninstallX 🚀
Application Management Solution Tailored to those that find Control Panel to be Bloated/Distracting.

<p align="center">
  <img src="https://i.ibb.co/zhQSfSJ1/Uninstall-X-Banner.png" alt="UninstallX Banner">
</p>

> **Minimalist Application Uninstaller for Power Users**
> Developed by CyberWatch, for efficient and clear application management.

[![GitHub License](https://img.shields.io/badge/License-GPL-blue.svg)](https://opensource.org/license/gpl-3-0)
[![Build Status](https://img.shields.io/badge/.NET-4.8-blueviolet.svg)]()
[![Platform](https://img.shields.io/badge/Platform-Windows_10%20%7C%20Windows_11-0078d7.svg)]()

## 🎯 Focus on What Matters: Clean Uninstalls

UninstallX is made possible by CyberWatch for users who demand a straightforward and efficient way to remove applications. Ditch the rusty, dusty control panel and confusing yet useless applications. This tool provides a clean, focused experience for precise application management.

![Application Screenshot](https://cyberwatch.cc/media/UninstallX.gif)

## ✨ Key Features

-   **Open Sourced:**
    * Don't worry about malware, or any hidden threats! We've open sourced this application so you don't have to worry (Feel Free to Learn and Contribute!)
-   **Clean and Minimalist Interface:**
    * Say goodbye to unnecessary clutter. UninstallX offers a streamlined UI for quick and easy navigation.
-   **Efficient Application Listing:**
    * Quickly scan and display installed applications with minimal overhead.
-   **Simplified Uninstallation Process:**
    * Initiate uninstalls with a single click, focusing on speed and efficiency.
-   **Lightweight and Fast:**
    * Designed for performance, UninstallX consumes minimal system resources.
-   **Portable Option:**
    * Future options for portable executable, that requires no install.

## 🔧 Installation Instructions

**Prerequisites**

* Windows 10 or Windows 11 (or any other personal flavor of Microsoft Spyware)
* Visual Studio 2022 (Preferred)
* .NET 9 Runtime & SDK (SDK is only needed if you want to build your own executable)
* Administrator Privileges (Recommended)

```powershell
# Clone the repository
git clone https://github.com/CyberWatch/UninstallX.git

# Navigate to the project directory
cd UninstallX

# install the necessary VS2022 v9 SDk & Runtime
winget install Microsoft.DotNet.Runtime.9 && winget install Microsoft.DotNet.SDK.9

# Clean & Build the solution
start devenv UninstallX.sln

# Navigate to the Release directory
cd \bin\Release\

# Launch the executable
start UninstallX.exe
