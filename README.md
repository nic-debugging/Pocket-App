# Pocket-App

## Overview
Pocket is a useful desktop app for organizing resources for your project or for anything. You can store tabs (URLs) and files together. Filters and sorting options make it easy to organize and find the tab or file you are looking for. 

## Features
Stored files and tabs have a title and image display.

Non-image files will be given a default file icon and folders will be given a default folder icon to differentiate them.
Tabs will display a screenshot of the URL webpage. Some websites such as (reddit.com and chat.openai.com) block this feature.

Filter options
- Tabs
- Files

Sorting options
- Time
- Alphabetical order

## Usage
### Storing tabs
Add and store tabs (URLs) by pasting the URL in text box on top, and click on the "Add tab" button. 

You must click on the Apply button to refresh and displays the newly added tab/file.

#### Suitable URLs
- **Standard HTTP/HTTPS URLs:** URLs that start with `http://` or `https://` and ending with a top-level-domain
- **Working example URL:** https://www.youtube.com/

#### Unsuitable URLs
- **Dynamic or Short-Lived URLs:** URLs that are dynamically generated or expire quickly.
- **Non-HTML Content:** URLs leading to non-HTML resources such as images, videos, or file downloads.
- **Local Files or IP Addresses:** URLs pointing to local files on your machine.

### Storing files
Add and store files or folders by dragging it anywhere on the app and dropping it.

You must click on the Apply button to refresh and displays the newly added tab/file.


### Deleting
Press the red button next to a tab or file to remove.

### Accessing tab or file
Press on the image of the tab or file. This will open the URL in your default browser or open your file.

### Filter and sorting options
Check the checkboxes on the left and click on the Apply button. At least one filter and one sorting option must be selected.

### Customise sorting options
Press on Settings button to reverse or forward the sorting options and have your preferences saved. 

## Offline mode
Not currently supported.
Images of tabs and files will not be loaded. 

## Future features
Sorting options
- Image size (Does not currently work)

Drag and drop multiple files in one go

Working offline mode

## Technologies used

C#, MySQL, Windows Forms, Visual Studio


## Installation

Follow these steps to download and install Pocket App:

1. **Download Dotnet**

   Download Dotnet **8.0** from the 
   [official dotnet site](https://dotnet.microsoft.com/en-us/download)

2. **Download Pocket Installer**

   You can download the latest version of the installer from the following link:

   [Download Pocket App Installer](https://github.com/nic-debugging/Pocket-App/releases/tag/v.2.0.0)

3. **Run the Installer**

   - Navigate to the folder where the installer was downloaded (usually `Downloads`).
   - Double-click on `Pocket_Installer_5.exe` to start the installation process.
   - Follow the on-screen prompts to install Pocket App.

4. **Launch Pocket App**

   - After installation, you will find a `_Pocket` shortcut on your desktop.
   - Double-click the shortcut to open Pocket App.


