# Как написать смарт-контракт на C# в ubuntu

Чтобы написать смарт-контракт на C# в ubuntu, необходимо выполнить следующие действия:

1. Создать проект библиотеки, написать код и добавить библиотеку вашего смарт-контракта.
2. Выполнить `neo-compiler/neon` , чтобы собрать компилятор.
3. Запустить `neon`, чтобы сгенерировать файл .avm. 

## Создайте проект смарт-контракта

1. В командной строке dotnet создайте проект библиотеки классов:

   ```c#
   mkdir NeoContractDemo
   cd ./NeoContractDemo/
   dotnet new classlib
   rm ./Class1.cs
   vim NeoContractDemo.cs
   ```

   ![](../../../assets/create_neo_contract.png)

2. В NeoContractDemo.cs вставьте следующий код, а затем нажмите `ESC`+`wq!`.

   ```c#
   using Neo.SmartContract.Framework;
   using Neo.SmartContract.Framework.Services.Neo;

   public class NeoContractDemo: SmartContract
   {
       public static bool Main()
       {
           return true;
       }
   }
   ```

3. Добавьте ссылку на фреймворк смарт-контракта:

   ```
   dotnet add package Neo.SmartContract.Framework --version 2.5.4
   ```

   ![](../../../assets/neo_addpackage.png)

4. Скомпилируйте проект смарт-контракта：

   ```
   dotnet publish -o ../testlib
   ```

   ![](../../../assets/build_neo_contract_project.png)

## Соберите компилятор

    cd ..
    git clone https://github.com/neo-project/neo-compiler.git
    cd  ./neo-compiler/neon
    dotnet publish -o ../../testlib

![](../../../assets/build_neo_neoa.png)

## Сгенерируйте файл .avm

    cd ../../testlib
    dotnet neon.dll NeoContractDemo.dll
    mkdir ../output
    cp NeoContractDemo.avm ../output/NeoContractDemo.avm

![](../../../assets/neo_contract_build_avm.png)

Полный скрипт вышеописанной инструкции см. https://raw.githubusercontent.com/hunjixin/NeoContractBuildScriptOnUbuntu/master/SmartContract.sh
