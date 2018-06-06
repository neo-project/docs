# Publishing from NEO-CLI Source 

You can download and compile the Neo-CLI source directly from Github.

## Setting up NEO-CLI on Windows / Linux

### Installing required files

1. Install one of the following depending on your system: 
   - For  **Linux (ubuntu 17.10)**, install [.NET Core Runtime](https://www.microsoft.com/net/download/linux).
   - For **Windows 7** and **Windows 10**, install [.NET Core](<https://www.microsoft.com/net/download/windows>) and [.NET Framework](https://www.microsoft.com/net/download/windows).

2. Git clone NEO-CLI source code from [Github](https://github.com/neo-project/neo-cli.git) or using the following command:

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```

3. Install levelDB:

   - On Windows systems, copy [NEO version of LevelDB](https://github.com/neo-project/leveldb) and place under the neo-cli folder.
   - On Linux system, run the following command:

   ```
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev
   ```

### Building the executable file

Run the following command in the command line:

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

## Setting up NEO-CLI on macOS

### Installing required files

1. Git clone NEO-CLI source code from [Github](https://github.com/neo-project/neo-cli.git) or using the following command:

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```

2. Git clone the altered neo dependency using rocksdb.

   ```
   $ git clone -b rocksdb-proxy https://github.com/ixje/neo.git
   ```

3. Install rocksdb using Homebrew.

   ```
   $ brew install rocksdb
   ```

4. Install [Visual Studio for Mac](https://www.visualstudio.com/vs/mac/).

### Managing to compile

1. Open the folder `neo-cli` and launch `neo-cli.sln` in Visual Studio
2. Right click on neo-cli's solution folder `neo-cli (master)` and `Add` > `Add Existing Project...`
3. Navigate to the `neo` folder to find and choose `neo.csproj` inside another `neo` folder
4. Right click on neo-cli's project Dependencies folder and choose `Edit References...`
5. Click the checkmark on `neo` and press `ok`
6. Click the `Project` menu bar to `Restore NuGet Packages` and `Update NuGet Packages`
7. Click the `Build` menu bar to `Rebuild All` just in case of errors

### Building the executable file

Run the following in the command line:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r osx-x64
```

## Starting the NEO node

1. Navigate to the directory where the compiled files are stored:
   `$ cd neo-cli/bin/Release/netcoreapp2.0/osx-x64/publish`
   **This path may be different depending on user configuration*
2. To run NEO-CLI type the command `$ dotnet neo-cli.dll`
   **Consider moving the `publish` directory to an easier place to access*
