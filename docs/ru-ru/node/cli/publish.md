# Публикация из исходного кода NEO-CLI 

Вы можете загрузить и скомпилировать исходный код Neo-CLI напрямую с Github.

## Настройка NEO-CLI в Windows / Linux

### Установка необходимых файлов 

1. В зависимости от вашей системы установите следующее:
   - Для  **Linux (ubuntu 17.10)**, установите [.NET Core Runtime](https://www.microsoft.com/net/download/linux).
   - Для **Windows 7** and **Windows 10**, установите [.NET Core](<https://www.microsoft.com/net/download/windows>) и [.NET Framework](https://www.microsoft.com/net/download/windows).

2. Git clone программный код NEO-CLI из [Github](https://github.com/neo-project/neo-cli.git) или при помощи следующей команды:

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```

3. Установите levelDB:

   - Для систем Windows скопируйте [NEO version of LevelDB](https://github.com/neo-project/leveldb) aи разместите в папке neo-cli.
   - Для системы Linux выполните следующую команду:

   ```
   sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev
   ```

### Построение исполняемого файла

Выполните следующую команду в командной строке:

Для **Linux**:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r linux-x64
```

Для **Windows 7**:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r win7-x64
```

Для **Windows 10**:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r win10-x64
```

## Настройка NEO-CLI в macOS

### Установка необходимых файлов 

1. Git clone программный код NEO-CLI из [Github](https://github.com/neo-project/neo-cli.git) или при помощи следующей команды:

   ```
   $ git clone https://github.com/neo-project/neo-cli.git
   ```

2. Git clone зависимость модифицированного neo, используя rocksdb.

   ```
   $ git clone -b rocksdb-proxy https://github.com/ixje/neo.git
   ```

3. Установите rocksdb, используя Homebrew.

   ```
   $ brew install rocksdb
   ```

4. Установите [Visual Studio for Mac](https://www.visualstudio.com/vs/mac/).

### Компиляция

1. Откройте папку `neo-cli` и запустите `neo-cli.sln` в Visual Studio
2. Щелкните правой кнопкой мыши по solution folder `neo-cli (master)` и `Add` > `Add Existing Project...`
3. Перейдите в папку `neo` и выберите `neo.csproj` внутри другой папки  `neo`
4. Щелкните правой кнопкой мыши по папке project Dependencies (neo-cli) и выберите `Edit References...`
5. Щелкните кнопкой мыши по галочке в `neo` и нажмите `ok`
6. Щелкните кнопкой мыши по строке меню `Project`, чтобы `Restore NuGet Packages` и `Update NuGet Packages`
7. Щелкните кнопкой мыши по строке меню `Build`, чтобы `Rebuild All` в случае возникновения ошибок.

### Создание исполняемого файла 

Введите и выполните следующее в командной строке:

```
cd neo-cli
dotnet restore
dotnet publish -c release -r osx-x64
```

## Запуск узла NEO 

1. Перейдите в каталог, где хранятся скомпилированные файлы:
   `$ cd neo-cli/bin/Release/netcoreapp2.0/osx-x64/publish`
   **Этот путь может отличаться в зависимости от пользовательских настроек*
2. Для выполнения NEO-CLI введите команду `$ dotnet neo-cli.dll`
   **Рассмотрите возможность перемещения каталога `publish` в боле доступное место*
