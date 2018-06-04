# Publishing NEO CLI Source 

You can download and compile the Neo-CLI source directly from Github.

## Setting up the environment

Running of an NEO node requires installation of .NET Core Runtime, version 2.0 or above.

For  **Linux (ubuntu 17.10)**, install [.NET Core Runtime](https://www.microsoft.com/net/download/linux).

For **Windows 7** and **Windows 10**, install [.NET Core](<https://www.microsoft.com/net/download/windows>) and [.NET Framework](https://www.microsoft.com/net/download/windows).

For **macOS**, install [.NET Core](https://www.microsoft.com/net/download/macos ).


## Downloading NEO-CLI source

Clone the neo-cli repository from Github: <https://github.com/neo-project/neo-cli.git> 

## Compiling from source

To publish the NEO-CLI source, run the following command:

For **Linux**:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r linux-x64
```

For **Windows 7**:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r win7-x64
```

For **Windows 10**:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r win10-x64
```

For **macOS**:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r osx-x64
```

