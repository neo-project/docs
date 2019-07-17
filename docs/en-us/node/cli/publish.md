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

1. Git clone [NEO-CLI](https://github.com/neo-project/neo-cli.git) and [NEO-CORE](https://github.com/neo-project/neo.git) source code from Github or using the following commands:

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   $ git clone https://github.com/neo-project/neo.git
   ```
2. Download the LevelDB to RocksDB patch file into the core project folder.
   
   ```
   $ wget --directory-prefix=neo https://gist.githubusercontent.com/ixje/359fbffa62eddbbf2b9ca716bf958487/raw/f402fb76edb2767c22e5d65847347bf8dae6d7bd/0001-convert-leveldb-to-rocksdb.patch
   ```

3. Install RocksDB using Homebrew.

   ```
   $ brew install rocksdb
   ```

4. Install [Visual Studio for Mac](https://www.visualstudio.com/vs/mac/).

### Setting up project code
The NEO project is under constant development. As a result we have to make sure we checkout compatible `NEO-CLI` and `NEO-CORE` versions.

1. Open a terminal and navigate to the `neo-cli` project folder
2. Use `git tag` to view a list of available versions and checkout the version you like e.g. `git checkout tags/v2.9.4`
3. Navigate to the `neo` core project folder (where the patch file is located) and repeat step 2. Make sure you checkout compatible versions!
4. Apply the patch that changes the LevelDB wrapper to use RocksDB

   ```
   $ git apply 0001-convert-leveldb-to-rocksdb.patch
   ```

### Setting up Visual Studio

1. Open the `neo-cli` folder and launch `neo-cli.sln` in Visual Studio
2. Right click on neo-cli's solution folder `neo-cli` and `Add` > `Add Existing Project...`
3. Navigate to the `neo` folder and choose `neo.csproj` (located inside the sub folder `neo`)
4. Right click on neo-cli's project `Dependencies` folder and choose `Edit References...`
5. Click the checkmark on `neo` and press `ok`
6. Click the `Project` menu bar and choose `Restore NuGet Packages`, once done choose `Update NuGet Packages`
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
