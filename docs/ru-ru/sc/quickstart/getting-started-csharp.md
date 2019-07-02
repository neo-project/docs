---
typora-root-url: ..\..
---

### Как написать смарт-контракт NEO на C# 

В данный момент мы рекомендуем использовать C# для разработки смарт-контрактов (однако мы уже поддерживаем или планируем поддерживать Java, Kotlin, Go, C/C++, Python, JavaScript и другие языки программирования).

В данном разделе вы найдете короткую инструкцию, которая поможет вам настроить среду разработки C# для смарт-контрактов NEO, а также подскажет, как создать и как скомпилировать проект смарт-контракта.  

   > [!Примечание]
   > В настоящий момент все проекты обновлены до версии Visual Studio 2017. Если для разработки смарт-контракта вы хотите использовать Visual Studio 2015, то см. соответствующую информацию в [how to use C # to write NEOs intelligent contract for VS2015](getting-started-2015.md).

## Инструменты разработки


### 1. Visual Studio 2017

Если вы уже установили Visual Studio 2017 на своем компьютере и проверили наличие .NET Cross-Platform Development, то вы можете пропустить данный раздел.

Скачайте и установите:

[Visual Studio download address](https://www.visualstudio.com/products/visual-studio-community-vs)

Процесс установки очень прост: пошагово следуйте указаниям. Не забудьте проверить, установлен ли `.NET Core cross-platform development`, иначе вы не сможете открыть проект neo-vm в шаге 3. Установка занимает около десяти минут (не более одного часа).

![install net core cross-platform development toolset](../../../assets/install_core_cross_platform_development_toolset.png)

### 2. NeoContractPlugin

Откройте Visual Studio 2017, затем откройте `Tools`, кликните по `Extensions and Updates`, кликните по вкладке `Online` в левой части окна, введите «NEO» в строку поиска в верхнем правом углу окна и загрузите `NeoContractPlugin` (на данном этапе необходим доступ к Интернету). 

![download and install NEO smart contract plugin](../../../assets/download_and_install_smart_contract_plugin.png)

### 3. neo-compiler

Этапы установки и настройки:

Скачайте проект [neo-compiler](https://github.com/neo-project/neo-compiler) с Github, откройте проект с помощью Visual Studio 2017 и опубликуйте проект neon.

![publish NEO compiler msil project](../../../assets/publish_neo_compiler_msil_project.png)

![publish and profile settings](../../../assets/publish_and_profile_settings.png)

> [!Примечание]
>
> Если во время публикации neon вы увидите сообщение о том, что файл neon.dll не может быть скопирован, вы можете вручную скопировать файл с тем же именем из папки верхнего уровня.


После успшной публикации в каталоге `bin\Release\PublishOutput` создастся файл neon.exe.

Теперь необходимо добавить данный каталог в PATH. PATH - это системная переменная, используемая вашей операционной системой для размещения необходимых исполняемых файлов из командной строки или окна терминала.

**Windows 10 и Windows 8**

Найдите в `Поиске`, а затем выберите: `System (Control Panel)`, кликните по ссылке `Advanced system settings`. Кликните по `Environment Variables`. В разделе `System Variables` найдите переменную среды `PATH` и выберите ее. Кликните по `Edit`. Если переменной `PATH` не существует, кликните по `New`. В окне `Edit System Variable` (или `New System Variable`) укажите значение переменной `PATH`. Кликните по `OK`. Закройте оставшиеся окна, нажав `ОК`.

**Windows 7**

Кликните правой кнопкой мыши по иконке `Computer` на рабочем столе. В контекстном меню выберите `Properties`. Кликните по ссылке `Advanced system settings`. Кликните по `Environment Variables`. В разделе `System Variables` найдите переменную среды `PATH` и выберите ее. Кликните по `Edit`. Если переменной `PATH` не существует, кликните по `New`. В окне `Edit System Variable` (или `New System Variable`) укажите значение переменной среды `PATH`. Кликните по `OK`. Закройте оставшиеся окна, нажав `ОК`.

![edit environmental variables](../../../assets/edit_environmental_variables.png)

Теперь запустите `Command` или `PowerShell` и введите `neon.exe`. Если ошибки нет, и в выходных данных указан номер версии (как показано ниже), то настройка переменной среды прошла успешно.

![powershell enviornment variabled updated correctly](../../../assets/powershell_enviornment_variabled_updated_correctly.png)


Примечание. Пользователи Windows 7 SP1 могут столкнуться с ошибкой «Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found"». Необходимый файл api-ms-win-core-console-l2-1-0.dll есть только в Windows 8 или более поздних версиях. Данную ошибку можно устранить, скачав файл api-ms-win-core-console-l2-1-0.dll и поместив его в каталог C:\ Windows\ System32 (dll можно найти также в других папках на вашем компьютере (найдите и скопируйте его в \ System32) или в Интернете).
 
## Создайте проект

После того, как настройка среды проведена успешно, вы можете создать проект NeoContract в Visual Studio 2017.

![new smart contract project](../../../assets/new_smart_contract_project.png)

Как только вы создадите проект, он автоматически сгенерирует файл C#. Класс, который SmartContract наследует по умолчанию, показан ниже:

![smart contract function code](../../../assets/smart_contract_function_code.png)


## Скомпилируйте проект

Теперь все готово для добавления метода Main(), который определяет смарт-контракт:

```c#
public class Contract1 : SmartContract
{
    public static void Main() // Note that the main method is capitalized
    {
        
    }
}
```
После успешной компиляции вы увидите в каталоге `bin/Debug` файл `SmartContract1.avm`. Это скомпилированный смарт-контракт NEO.

![compile smart contract](../../../assets/compile_smart_contract.png)

Настройка среды разработки смарт-контрактов NEO завершена.

