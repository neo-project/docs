# Pag-install at pag-deploy sa node ng NEO

Ang artikulo na nasa itaas ay inilalarawan ang dalawang kliyente para sa mga node sa network ng NEO. Ang isa ay [Neo-CLI](https://github.com/neo-project/neo-cli/releases) (ang command line client - ginagamit para sa developer), at ang iba ay [Neo-GUI](https://github.com/neo-project/neo-gui/releases) (ang graphical interface client - para sa advanced na user)

Ang node ng konsensus sa pag-deploy ay gumagamit ng `Neo-CLI`, isang cross-platform na programa na tumatakbo sa Windows, Linux at Docker.

|                                   | Neo-CLI |
| --------------------------------- | ----------------- |
| Windows 7 SP1 x64                 | ✅                 |
| Windows Server 2008 R2 SP1        | ✅                 |
| Red Hat Enterprise Linux 7 Server | ✅                 |
| Ubuntu 14.04, 16.04, 16.10        | ✅                 |
| Debian 8                          | ✅                 |
| Fedora 23, 24                     | ✅                 |
| CentOS 7.1 & Oracle Linux 7.1     | ✅                 |
| openSUSE 13.2, 42.1               | ✅                 |
| Docker                            | ✅                 |

> [!Paalala]
> Sa kasalukuyan, ang mga node ng NEO ay hindi gumagana ng maayos sa ilalim ng Mac OS. Sa hinaharap ay magkakaroon ng suporta para sa Mac OS, maghintay lamang para sa mga karagdagang update.

## Patakbuhin ang environment

Sa pagpapatakbo ng isang node ng NEO ay kinakailangan na mag-install ng [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime), bersyon 1.0.1 o higit pa.

### Paraan ng pag-install sa sistema ng Windows

Sa sistem ng Windows, ang pag-iinstall ng . NET Core ay napakadali, maaari mong direktang i-download at patakbuhin.

### Paraan ng pag-install sa sistema ng Linux

Ang sumusunod ay nagpapakita kung paano na-install ang .NET Core sa serber ng Red Hat Enterprise Linux 7:

> [!Paalala]
> Para sa mga ibang distribusyon sa paraan ng pag-install ng Linux kernel, maaaring tukuyin sa [.NET Core installation tutorial](https://www.snetnet/core#linuxredhat)


```
subscription-manager repos --enable = rhel-7-server-dotnet-rpms
yum install scl-utils
```

```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

Pagkatapos makompleto ang pag-install, maaari mong patakbuhin ang sumusunod na command para masuri kung ang .NET Core environment ay matagumpay na na-install.

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

Kung nakikita mo ang kahuli-hulihang awtput na "Hello World!", Ang .Net Core ay matagumpay na na-install.


### Pag-install ng node ng NEO

1. I-download ang pakete na [Neo-CLI](https://github.com/neo-project/neo-cli/releases) sa Github at i-unzip ito.

> [!Paalala]
> Kung susubukan mong i-download at i-compile ang source ng NEO-CLI direkta sa Github, makikita mo na ang `dotnet neo-cli.dll` ay hindi wasto ang pagka-run matapos mag-compile, at kailangan mong kopyahin ang libleveldb.dll at sqlite3.dll sa parehong direktoryo bilang neo-cli.dll sa ilalim. Maaaring ma-download ang dalawang file na ito sa unang hakbang ng pakete.

2. Sa Linux, i-install ang mga pakete ng LevelDB at SQLite3 dev. E.g. sa Ubuntu:

```
sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sa Windows, gamitin ang [Neo version of LevelDB](https://github.com/neo-project/leveldb).

3. Buksan ang command line, mag-navigate sa direktoryo ng program, ipasok ang sumusunod na code upang simulan ang node ng NEO.

```
dotnet neo-cli.dll
```

Nagbibigay ang Neo-CLI ng isang hanay ng mga API para sa panlabas na pag-akses. Kung gusto mong simulan ang node habang binubuksan ang API, maaari mong patakbuhin ang sumusunod na code.
```
dotnet neo-cli.dll /rpc
```
4. Kung gusto mong mapasok ng panlabas na programa ang node kailangan buksan ng API ang port ng firewall: 10331-10334, 20331-20334
