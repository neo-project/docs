# NEO SDK

Вы можете использовать NEO SDK для разработки различных приложений на базе NEO, например, клиента кошелька, игр и т. д. Благодаря Neo SDK ваш проект будет функционировать в существующей среде, не обращаясь к NeoVM. Информацию о том, как разрабатывать в NeoVM, см. [Smart Contract](../../sc/introduction.md). 

В последующих разделах использована версия NEO SDK 2.9.0. Для разработки приложений в Visual Studio 2017 проще воспользоваться NEO SDK.

## Загрузка

1. Создайте new project (новый проект) в Visual Studio 2017.
2. В Solution Explorer щелкните правой кнопкой мыши по project name и выберите Manage NuGet Packages
3. Выберите вкладку Browse и найдите NEO, а затем выберите в списке Neo package и Install.

Также вы можете скачать [NuGet package](https://www.nuget.org/packages/Neo/2.7.1) и установить его вручную.

## Состав проекта 

Полный NEO SDK состоит из следующего：

**Основные проекты NEO SDK：**

NEO：https://github.com/neo-project/neo

NeoVM：https://github.com/neo-project/neo-vm

**Зависимости NEO SDK**

.NETFramework 4.7

​	Microsoft.AspNetCore.Server.Kestrel (>= 2.0.0) 

​	Microsoft.AspNetCore.Server.Kestrel.Https (>= 2.0.0) 

​	Microsoft.AspNetCore.WebSockets (>= 2.0.0) 

​	Microsoft.EntityFrameworkCore.Sqlite (>= 2.0.0) 

​	Microsoft.Extensions.Configuration.Json (>= 2.0.0) 

​	Replicon.Cryptography.SCrypt (>= 1.1.6.13) 

.NETStandard 2.0

​	Microsoft.AspNetCore.Server.Kestrel (>= 2.0.0) 

​	Microsoft.AspNetCore.Server.Kestrel.Https (>= 2.0.0) 

​	Microsoft.AspNetCore.WebSockets (>= 2.0.0) 

​	Microsoft.EntityFrameworkCore.Sqlite (>= 2.0.0) 

​	Microsoft.Extensions.Configuration.Json (>= 2.0.0) 
