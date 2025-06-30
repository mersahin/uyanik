# Uyanik - Mouse Jiggler

A simple Windows desktop application that prevents your computer from going to sleep by automatically moving the mouse cursor at regular intervals.

## Features

- **Automatic Mouse Movement**: Moves the mouse cursor horizontally or vertically to simulate user activity
- **Zen Mode**: Vertical mouse movement option for less noticeable jiggling
- **Customizable Interval**: Adjust jiggle frequency from 1 to 60 seconds
- **System Tray Support**: Minimize to system tray for background operation
- **Startup Integration**: Option to start automatically with Windows
- **Minimize on Start**: Option to start minimized to system tray
- **Registry Settings**: Remembers user preferences between sessions

## Requirements

- Windows 10/11
- .NET 6.0 Runtime (included in self-contained executable)

## Installation

1. Download the latest release from the releases page
2. Extract the `Uyanik.exe` file to your desired location
3. Run the executable

## Usage

1. **Start the Application**: Double-click `Uyanik.exe`
2. **Enable Jiggling**: Check the "Jiggling" checkbox to start mouse movement
3. **Choose Mode**: 
   - Normal mode: Horizontal mouse movement
   - Zen mode: Vertical mouse movement (less noticeable)
4. **Adjust Interval**: Use the slider to set jiggle frequency (1-60 seconds)
5. **Minimize to Tray**: Click the menu button to minimize to system tray
6. **Settings**: Click the settings button to access additional options

## Settings

- **Minimize on Start**: Automatically minimize to system tray when application starts
- **Start with Windows**: Automatically start the application when Windows boots

## System Tray

When minimized to system tray:
- Double-click the tray icon to restore the window
- Right-click for context menu options
- Shows balloon tip notification when minimized

## Building from Source

### Prerequisites
- Visual Studio 2022 or later
- .NET 6.0 SDK

### Build Steps
1. Clone the repository
2. Open `uyanik.sln` in Visual Studio
3. Build the solution (Ctrl+Shift+B)
4. The executable will be created in the `bin/Debug/net6.0-windows/win-x64/` directory

### Publish
```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

## Technical Details

- **Framework**: .NET 6.0 Windows Forms
- **Architecture**: x64
- **Dependencies**: Windows Forms, Registry access for settings persistence
- **API Usage**: Windows User32.dll for mouse cursor manipulation

## License

This project is open source and available under the MIT License.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Disclaimer

This application is designed to prevent system sleep by simulating user activity. Use responsibly and in accordance with your organization's policies. 