# Internet Detect

<p align="center">
  <img src=".github/logo.png" alt="internet-detect logo" width="128" />
</p>

A Windows Forms tool that monitors internet connectivity.

## What it does

It pings a set of well-known hosts (`www.google.com`, `www.yahoo.com`
and `www.boards.ie`) in the background and shows whether the machine is
**Online** or **Offline**. When the connection drops it plays an alarm.

## Tech

- Visual Basic .NET (Windows Forms)
- `ping.exe`

## Building

Open the `.sln` file in Visual Studio and build it. Windows only.

The solution file is `internetdetect.sln`.

## License

Licensed under the Apache License 2.0. See [LICENSE](LICENSE).
