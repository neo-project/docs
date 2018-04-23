---
typora-root-url: ..\..
---

### Paano gamitin ang Java para magsulat ng isang NEO smart na kontrata

Ang mga smart na kontrata ay sinusulat gamit ang mga mataas na lebel na lengguwahe kagaya ng Java, C#, Python, Kotlin (at iba pa...) at kinukompayl para maging AVM (ang Virtual Machine bytecode ng Neo) para mapatakbo ito sa Neo network.

Kami ay kasalukuyang nagrerekomenda na gumamit ng C# para gumawa ng mga smart na kontrata. Ang Java compiler ay ginagawa pa rin hanggang sa ngayon pero ang kasalukuyang bersyon (neoj) ay maari nang makapagtakbo ng mga basic na method.

Ang seksyon na ito ay naglalaman ng isang tutoryal na gagabay sa iyo sa pagkonpigyura ng Java development environment para sa mga NEO smart na kontrata. Ito rin ay magbibigay ng ideya kong papaano gumawa ng isang smart na kontratang proyekto at paano ito i-kompayl.

Mga Paalala: Ang proseso ay naglalaman ng mga sumusunod na mga hakbang:
1. Sumulat ng Java na code (.java) para sa mga class na umi-extend sa FunctionCode o VerificationCode na parte sa Neo Framework Library (JAR)
2. Gumamit ng normal na Java compiler para i-kompayl ang code para maging Java bytecode (.class)
3. I-build ang neoj (C#) na compiler na kino-convert ang JVM na code para maging AVM na code (neoj.exe sa Windows)
4. Gamitin ang neoj para i-kompayl ang iyong .class na file (.avm)
5. I-downloand ang Node GUI ng Neo para kumonekta sa Testnet na network ng Neo.
6. I-deploy ang iyong .avm na script para i-publish ang smart na kontrata sa network
7. I-invoke ang iyong .avm na script para patakbuhin ang iyong smart na kontrata

### Mga Detalyadong Instruksyon

## Mga Tool

Ang pinakaepisyenteng pamamaraan para magawa ang mga sumusunod na mga hakbang ay ang pagdownload at pagkompayl ng lahat ng kagamitan na kakailanganin mo:

1. I-download ang Node GUI ng Neo. Sa pagkakasulat nito, inirerekomenda na gumamit ka ng BETA developer GUI dahil mayroon itong mga ekstrang debugging feature na nagpapadali ng lahat. [CoZ NEO GUI](https://github.com/CityOfZion/neo-gui-developer). Ito ay mayroong mga default preset sa Testnet at kinakailangan mong maghintay (hanggang sa ilang oras) para ito ay mag-sync ng lubos.
2. I-download ang Neo Framework Library JAR. Nandito ang kasalukuyang pinakabago na bersyon: [org.neo.smartcontract.framework JAR](https://github.com/CityOfZion/neo-java-sdk/blob/master/target/org.neo.smartcontract.framework.jar)
3. Mag-download ng isang IDE para sa Java (opsyonal ito pero rinrekomenda), e.g. IntelliJ o Eclipse.
4. Mag-download ng isang IDE para sa C# - sa kasalukuyan, ang neoj compiler ay kinakailangang likhain ng mano-mano dahil ito ay hindi naka wide distribution release na format.

## Mga Development Tool

### 1. Visual Studio 2017

Kong ikaw ay naka-install na ng Visual Studio 2017 sa iyong kompyuter at naka-check sa .NET Cross-Platform Development sa panahon na nag-iinstall, pwede mong laktawan ang seksyon na ito.

Pag-download at pag-install:

[Ang address para i-download ang Visual Studio](https://www.visualstudio.com/products/visual-studio-community-vs)

Napakasimple lang ng proseso sa pag-install, sundin lang ang bawat hakbang sa mga operation prompt, dapat mong tandaan na kinakailangan mong e-check ang pag-install ng `.NET Core cross-platform development`, dahil kong hindi, hindi mo maaaring buksan ang neo-vm na proyekto na nasa ikatlong hakbang. Ang pag-install ay tumatagal ng halos sampung minuto o hanggang sa isang oras.

![pag-install sa net core cross-platform development kagamitanet](/assets/install_core_cross_platform_development_kagamitanet.png)

### 2. neo-compiler

Mga hakbang sa pag-install at pag-konpigyura:

I-download ang [neo-compiler](https://github.com/neo-project/neo-compiler) na proyekto sa Github, buksan ang solusyon gamit ang Visual Studio 2017, at i-publish ang neoj na proyekto.

I-publish ang neoj compiler (na kino-convert ang Java bytecode para maging AVM bytecode).

![i-publish ang NEO compiler neoj](/assets/publish_neo_compiler_neoj.png)

![publish at mga profile setting](/assets/publish_and_profile_settings.png)

Pagkatapos na magtagumpay ang pag-release, ang neoj.exe na file ay mabubuo sa `bin\Release\PublishOutput`.

Kinakailangan na natin ngayong idagdag ang direktoryong ito sa ating execution path. Ang PATH ay isang system variable na ginagamit ng iyong operating system para matagpuan ang mga kinakailangang mga executable galing sa command line o Terminal window.

**Windows 10 at Windows 8:**

  Sa Search, maghanap ng at pagkatapos pumili: System (Control Panel)
  I-click ang Advanced system settings na link.  
  I-click ang Environment Variables. Sa seksyon na System Variables, hanapin ang Path environment variable at piliin ito. I-click ang Edit. Kung wala ang PATH environment variable, i-click ang New.
  Sa Edit System Variable (o New System Variable) na window, itukoy ang value ng Path environment variable. I-click ang OK. Isara ang lahat ng natitirang mga window sa pamamagitan ng pag-click ng OK.

**Windows 7:**

  Galing sa desktop, i-right click ang Computer icon.
  Piliin ang Properties galing sa context menu.
  I-click ang Advanced system settings na link.
  I-click ang Environment Variables. Sa seskyon na System variables, hanapin ang PATH environment variable at piliin ito. I-click ang Edit. Kung wala ang PATH environment variable, i-click ang New.
  Sa Edit System Variable (o New System Variable) na window, itukoy ang value ng PATH environment variable. I-click ang OK. Isara ang lahat ng natitirang mga window sa pamamagitan ng pag-click ng OK.

![i-edit ang mga environmental variable](/assets/edit_environmental_variables.png)

Ngayon patakbuhin ang Command o Powershell, at i-enter ang neoj.exe. Kung wala error at ang output ay nagpapakita ng numero ng bersyon (kagyaa ng pinapakita) ang pag-konpigyura ng environment variable ay naging matagumpay.

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)


TANDAAN. Ang mga gumagamit ng Windows 7 SP1 ay maaring maka-enkwentro ng error na "Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". Ang kinakailangang 'api-ms-win-core-console-l2-1-0.dll' na file ay matatagpuan lamang sa Windows 8 o mas bago pa na mga bersyon. Ang error na ito ay maaring maresolba sa pamamagitan ng pagkuha na kopya ng 'api-ms-win-core-console-l2-1-0.dll' at paglagay nito sa direktoryo na C:\Windows\System32. Ang dll ay maaring makita sa maraming mga lugar sa iyong sistema (maghanap sa iyong kompyuter at kopyahi o i-paste ito sa loob ng \System32), pero pwede rin itong hanapin online.

## Paggawa ng Proyekto

Pagkatapos matapos ang instolasyon sa itaas, pwede ka nang bumuo ng isang Java na proyekto (e.g. gamit ang Eclipse o IntelliJ).

Kinakailangan mong ikompayl ang .jar package ng smart na kontrata na galing sa neo java devpack na proyekto  ([neo-devpack-java](https://github.com/neo-project/neo-devpack-java)) at idagdag ito bilang eksternal na library.


## Pagkompayl ng Proyekto

Ang lahat ay handa na ngayon para madagdag ang entry method na tutukoy sa smart na kontrata:

```Java
import org.neo.smartcontract.framework.SmartContract;
import org.neo.smartcontract.framework.services.neo.Storage;

public class HelloWorld extends SmartContract {

    public static byte[] Main(String[] args){
        Storage.put(Storage.currentContext(), "Pagbati para sa Mundo", "Hello Mundo!");
        return Storage.get(Storage.currentContext(),"Pagbati para sa Mundo");
    }

}
```

I-build ang proyekto na kung saan ay magbibigay sa iyo ng `HelloWorld.class` sa iyong out na folder. 

Ngayon habang ginagamit ang neoj, patakbuhin ang cmd.exe at i-execute ang:
> neoj.exe HelloWorld.class

Kung matagumpay, ito ay gagawa ng HelloWorld.avm na kung saan ikaw ay maari nang gumamit ng bytecode na smart na kontrata.

Para sa karagdagang impormasyon at para matanaw ang mga gumaganang Java na halimbawa, pakisangguni dito: [Mga Halimbawa sa Java](https://github.com/neo-project/examples-java)

## Pag-deploy ng mga smart na kontrata

Ngayon na nandito kana sa bahaging ito, ang mga instruksyon ay pareho lang kahit na ano pa na lengguwahe ang ginamit mo para isulat ang mga smart na kontrata. Sundin ang tutoryal na ito: [Pag-deploy ng isang lock na kontrata](http://docs.neo.org/en-us/sc/tutorial/Lock2.html)