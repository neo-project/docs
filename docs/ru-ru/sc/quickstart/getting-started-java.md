---
typora-root-url: ..\..
---

# Как написать смарт-контракт NEO на Java 

Для написания смарт-контрактов используют высокоуровневые языки, такие как Java, C#, Python, Kotlin (и другие). Смарт-контракты необходимо компилировать в AVM (байт-код виртуальной машины Neo) для того, чтобы их можно было выполнить в сети Neo.

В настоящий момент для разработки смарт-контрактов мы рекомендуем использовать C#. Компилятор для Java все еще находится в стадии разработки, но текущая версия (neoj) уже может работать с базовыми методами.

Данный раздел содержит инструкцию, которая поможет вам настроить среду разработки Java для смарт-контрактов NEO. Она также даст вам представление о том, как создать и как скомпилировать проект смарт-контракта.

Этот процесс состоит из следующих этапов:
1. Написать код (.java) для классов, которые наследуют FunctionCode или VerificationCode, являющиеся частью Neo Framework Library (JAR);
2. Использовать обычный компилятор Java для компиляции кода в байт-код Java (.class);
3. Собрать компилятор neoj (C#), который преобразует код JVM в код AVM (neoj.exe в Windows);
4. Использовать neoj для компиляции файла .class (.avm);
5. Скачать Neo's Node GUI, чтобы подсоединиться к тестовой сети Neo (Testnet); 
6. Развернуть скрипт .avm, чтобы опубликовать смарт-контракт в сеть;
7. Вызвать скрипт .avm, чтобы выполнить смарт-контракт.

### Подробные инструкции

## Инструкции

Самый эффективный способ выполнить шаги, перечисленные выше,  – это загрузить и скомпилировать инструменты, которые понадобятся вам в дальнейшем:

1. Скачайте Neo's Node GUI. Во время написания смарт-контракта рекомендуем вам использовать BETA GUI для разработчиков, поскольку он обладает некоторыми дополнительными функциями отладки, которые будут вам полезны: [CoZ NEO GUI](https://github.com/CityOfZion/neo-gui-developer). Он имеет стандартные начальные установки для Testnet, поэтому вам придется подождать какое-то время (до нескольких часов), пока он полностью не синхронизируется.
2. Скачайте Neo Framework Library JAR. Последнюю версию см. здесь: [org.neo.smartcontract.framework JAR](https://github.com/CityOfZion/neo-java-sdk/blob/master/target/org.neo.smartcontract.framework.jar)
3. Мы рекомендуем скачать IDE для Java (опционально), например, IntelliJ или Eclipse.
4. (только для Windows) Скачайте IDE для C#. В настоящий момент компилятор neoj необходимо собирать вручную. Рекомендуем использовать бесплатный Visual Studio 2017.


> [!Примечание]
>
> Если вы используете Eclipse, то вам необходимо установить плагин maven. Проверьте, что версия JDK такая же, как в pom.xml. 

## Инструменты разработки


#### Visual Studio 2017 (Windows и Mac)

Если вы уже установили Visual Studio 2017 на своем компьютере и проверили .NET Cross-Platform Development во время установки, вы можете пропустить этот раздел.

Скачайте и установите:

[Visual Studio download address](https://www.visualstudio.com/products/visual-studio-community-vs)

Процесс установки очень прост: пошагово следуйте инструкциям. Не забудьте проверить, установлен ли `.NET Core cross-platform development`, иначе вы не сможете открыть проект neo-vm в шаге 3. Установка занимает около десяти минут (не более одного часа).

![](../../../assets/install_core_cross_platform_development_toolset.png)

### neo-compiler

Этапы установки и настройки:

**Windows:**
Скачайте проект [neo-compiler](https://github.com/neo-project/neo-compiler) с Github, откройте решение с помощью Visual Studio 2017 и опубликуйте проект neoj.

Соберите компилятор neoj, который конвертирует байт-код Java в байт-код AVM.

![publish NEO compiler neoj](../../../assets/publish_neo_compiler_neoj.png)

![publish and profile settings](../../../assets/publish_and_profile_settings.png)

После того, как сборка прошла успешно, в `bin\Release\PublishOutput` генерируется файл neoj.exe.

**Linux и Mac OS:**

Поскольку в коде Visual Studio для Linux и Mac нет функции “publish”, необходимо выполнить это действие вручную. Удостоверьтесь в том, что вы установили dotnet.

[dotnet for Linux](https://docs.microsoft.com/en-us/dotnet/core/linux-prerequisites?tabs=netcore2x#install-net-core-for-ubuntu-1404-ubuntu-1604-ubuntu-1610--linux-mint-17-linux-mint-18-64-bit)

[dotnet for Mac OS](https://docs.microsoft.com/en-us/dotnet/core/macos-prerequisites?tabs=netcore2x#supported-macos-versions)

Скачайте проект [neo-compiler](https://github.com/neo-project/neo-compiler) c Github.

```
cd neo-compiler/neoj
dotnet build
```
Примечание: На данном этапе, после того, как была запущена команда создания, вы можете получить следующую ошибку:
`It was not possible to find any compatible framework version
 The specified framework 'Microsoft.NETCore.App', version '1.0.4' was not found.`

Если это так, откройте neoj.csproj и замените тег RuntimeFrameworkVersion на вашу версию dotnet.

Например, `<RuntimeFrameworkVersion>2.0.5</RuntimeFrameworkVersion>`

Теперь необходимо добавить этот каталог в переменную PATH. PATH - это системная переменная, используемая вашей операционной системой для размещения необходимых исполняемых файлов из командной строки или окна терминала.

**Windows 10 и Windows 8:**

Найдите в `Поиске`, а затем выберите: `System (Control Panel)`, кликните по ссылке `Advanced system settings`. Кликните по `Environment Variables`. В разделе `System Variables` найдите переменную среды `PATH` и выберите ее. Кликните по `Edit`. Если переменной `PATH` не существует, кликните по `New`. В окне `Edit System Variable` (или `New System Variable`) укажите значение переменной `PATH`. Кликните по `OK`. Закройте оставшиеся окна, нажав `ОК`.

**Windows 7:**

Кликните правой кнопкой мыши по иконке `Computer` на рабочем столе. В контекстном меню выберите `Properties`. Кликните по ссылке `Advanced system settings`. Кликните по `Environment Variables`. В разделе `System Variables` найдите переменную среды `PATH` и выберите ее. Кликните по `Edit`. Если переменной `PATH` не существует, кликните по `New`. В окне `Edit System Variable` (или `New System Variable`) укажите значение переменной среды `PATH`. Кликните по `OK`. Закройте оставшиеся окна, нажав `ОК`.

![edit environmental variables](../../../assets/edit_environmental_variables.png)

Теперь запустите `Command` или `PowerShell` и введите `neon.exe`. Если ошибки нет, и в выходных данных указан номер версии (как показано ниже), то настройка переменной среды прошла успешно.

![powershell enviornment variabled updated correctly](../../../assets/powershell_enviornment_variabled_updated_correctly.png)


**Linux**

Добавьте это к вашему ~/.profile или файлу ~/.bashrc:

`export PATH=$PATH:/path/to/neo-compiler`

затем выполните `source ~/.profile` или `source ~/.bashrc`

## Создайте проект

После того, как установка завершена, вы можете создать проект Java (используя, например, Eclipse или IntelliJ).

1. Скомпилируйте пакет .jar смарт-контракта из проекта ([neo-devpack-java](https://github.com/neo-project/neo-devpack-java)) и добавьте его как внешнюю библиотеку.
2. Экспортируйте пакет `org.neo.smartcontract.framework` как .jar пакет  `org.neo.smartcontract.framework.jar` и поместите его в каталог  `..\neoj\bin\Release\netcoreapp1.1\win10-x64\publish\`.

   ![](../../../assets/JavaFrameworkjar-1.jpg)

   ![](../../../assets/JavaFrameworkjar-2.jpg)

   ![](../../../assets/JavaFrameworkjar-3.jpg)

3. Создайте класс, например, Go.java и вставьте следующий код в файл класса.

   ```java
   import org.neo.smartcontract.framework.SmartContract;
   
   public class Go extends SmartContract{
   	public static void Main(byte[] signature)
   	{
   		
   	}
   }
   ```


## Скомпилируйте проект Java

Теперь все готово для добавления метода Main(), который определяет смарт-контракт:


```Java
import org.neo.smartcontract.framework.SmartContract;
import org.neo.smartcontract.framework.services.neo.Storage;

public class HelloWorld extends SmartContract {

    public static byte[] Main(String[] args){
        Storage.put(Storage.currentContext(), "Greeting to the World", "Hello World!");
        return Storage.get(Storage.currentContext(),"Greeting to the World");
    }

}
```

Создайте проект, который добавит `HelloWorld.class` в папку out.

Кроме того, вы можете создать проект с помощью командной строки в операционной системе Mac.


**Mac OS:**

`cd /path/to/HelloWorld/project`

`javac -cp /path/to/org.neo.smartcontract.framework.jar HelloWorld.java`

Теперь `HelloWorld.class` должен быть в том же каталоге, что и `HelloWorld.java`.

## Скомпилируйте HelloWorld.class в HelloWorld.avm

**Windows:**

Затем запустите `cmd.exe` и выполните следующее, используя neoj:
> neoj.exe HelloWorld.class

**Linux:**

Скопируйте jar в папку dotnet. Например:

`sudo cp org.neo.smartcontract.framework.jar /usr/share/dotnet`

а затем вызовите

> dotnet run HelloWorld.class

**Mac OS:**

Скопируйте jar в папку neoj компилятора neo (neo –compiler). Например:

`sudo cp org.neo.smartcontract.framework.jar /path/to/neo-compiler/neoj`

Скопируйте HelloWorld.class в папку neoj. Например: 
`sudo cp HelloWorld.class /path/to/neo-compiler/neoj`

Затем из папки neoj вызовите

> dotnet run HelloWorld.class


Если все пройдет успешно, то будет создан `HelloWorld.avm`, который вы сможете использовать теперь как байт-код смарт-контракта.


Дополнительную информацию и примеры с использованием Java см. здесь: [Java Examples](https://github.com/neo-project/examples-java)

## Выполните развертывание смарт-контрактов 

Когда вы находитесь на данном этапе, следуйте соответствующим указаниям для других языков (независимо от того, на каком языке написан ваш смарт-контракт). См. инструкцию: [Deploy a lock contract](../tutorial/Lock2.md)