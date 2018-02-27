---
typora-root-url: ..\..
---

### Paano gamitin ang C# para magsulat ng isang NEO smart na kontrata

Kami ay kasalukuyang nagrerekomenda na gumamit ng C# para mag-program ng mga smart na kontrata (bagamat kami ay sumusuporta o nagplaplano na susuporta sa Java, Kotlin, Go, C/C + +, Python, Javascript at iba pang mga programming na lengguwahe)

Ang seksyon na ito ay naglalaman ng maikling tutoryal na maggagabay sa iyo para ikonpigyura ang C# development environment para sa mga NEO smart na kontrata at magbibigay sa iyo ng ideya kong papaano gumawa ng isang proyekto ng smart na kontrata at paano ito ikokompayl.

   > [!Tandaan]
   > Sa kasalukuyan, ang lahat ng mga proyekto ay nai-upgrade na sa Visual Studio 2017 na bersyon. Kung gusto mong gamitin ang Visual Studio 2015 para gumawa ng mga matalinong kontrata, tumanaw sa [Paano gamitin ang C # para magsulat ng NEO smart na kontrata para sa VS2015](getting-started-2015.md).

## Mga Development Tool

### 1. Visual Studio 2017

Kung mayroon ka nang naka-install na Visual Studio 2017 sa iyong kompyuter at na-check ang .NET Cross-Platform Development noong nag-iinstall pa, pwede mong laktawan ang seksyon na ito.

Pag-download at pag-install:

[Ang address para ma-download ang Visual Studio](https://www.visualstudio.com/products/visual-studio-community-vs)

Ang proseso nag pag-install ay napakasimple, kailangan mo lang sundin ang bawat hakbang ng mga operation prompt. Kailangan mong tandaan na kinakailangan mong itsek ang instalasyon ng `.NET Core cross-platform development`, kung hindi hindi ka makakabukas ng neo-vm na proyekto sa ikatlong hakbang. Ang instalasyon ay magtagagal ng mga sampung minuto o hanggang sa isang oras.

![i-install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. NeoContractPlugin

Pamamaraan ng pag-install:

Buksan ang Visual Studio 2017, buksan ang Tools, i-click ang Extensions and Updates, i-click ang Online na tab na nasa kaliwang bahagi ng window, hanapin ang NEO sa search na kahon na nasa itaas na kanang sulok ng window, i-download ang NeoContractPlugin (ang hakbang na ito ay nangangailangan ng akses sa internet).

![i-download at i-install ang NEO smart contract plugin](/assets/download_and_install_smart_contract_plugin.png)

### 3. neo-compiler

Mga hakbang sa pag-install at pag-konpigyura:

I-download ang [neo-compiler](https://github.com/neo-project/neo-compiler) na proyekto sa Github, buksan ang solusyon gamit ang Visual Studio 2017, at i-publish ang neon project.

![i-publish ang NEO compiler msil na proyekto](/assets/publish_neo_compiler_msil_project.png)

![publish at profile na mga setting](/assets/publish_and_profile_settings.png)

> [!Tandaan]
>
> Sa panahon na pina-publish ang neon, kung ikaw ay prinompt na ang neon.dll ay hindi pwede makopya, pwede mong i-manu-manong kopyahin ang file na mayroong kaparehong pangalan ng upper-layer na folder.

Pagkatapos ng matagumpay na pag-release, ang neon.exe na file ay mabubuo sa `bin\Release\PublishOutput`.

Kinakailangan na natin ngayong idagdag ito sa direktoryo ng iyong execution path. Ang PATH ay ang variable ng sistema na ginagmit ng iyong operating system para matagpuan ang mga kinakailangang mga executable galing sa command line o Terminal window.

**Windows 10 and Windows 8:**

  Sa Search, hanapin ang at pagkatapos pumili: System (Control Panel)
  I-click ang Advanced system settings na link.
  I-click ang Environment Variables. Sa seksyon na System Variables, hanapin ang PATH environment variable at piliin ito. I-click ang Edit. Kung walang PATH environment variable, i-click ang New.
  Sa Edit System Variable (o New System Variable) na window, itukoy ang halaga ng PATH environment na variable. I-click ang OK. Isara ang lahat ng mga window sa pamamagitan ng pag-click ng OK.

**Windows 7:**

  Galing sa desktop, i-right click ang Computer icon.
  Piliin ang Properties na nasa sa context menu.
  I-click ang Advanced system settings na link.
  I-click ang Environment Variables. Sa seksyon na System Variables, hanapin ang Path environment variable at piliin ito. I-click ang Edit. Kung wala ang PATH environment variable, i-click ang New.
  Sa Edit System Variable (o sa New System Variable) na window, itukoy ang halaga ng PATH environment variable. I-click ang OK. Isara ang lahat ng mga natitirang window sa pamamagitan ng pag-click ng OK.

![i-edit ang mga environmental variable](/assets/edit_environmental_variables.png)

Ngayon, patakbuhin ang Command o PowerShell, at itala ang neon.exe. Kung wala error na nangyari at ang numero ng bersyon ang pinapakita, ang environment variable ay matagumpay na nakonpigyura.

![powershell enviornment variable ay naiupdate ng tama](/assets/powershell_enviornment_variabled_updated_correctly.png)


TANDAAN. Ang mga Windows7 SP1 na mga user ay maaring makatagpo ng error na "Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". Ang required na 'api-ms-win-core-console-l2-1-0.dll' file ay matatagpuan lamang sa Windows 8 o mas higit pa na mga bersyon. Ang error na ito ay pwedeng maresolba sa pamamagitan ng pagkuha ng kopya ng 'api-ms-win-core-console-l2-1-0.dll' at pag lagay nito sa direktoryo na C:\Windows\System32. Ang dll ay maaring makita sa ibang mga folder sa iyong kompyuter (hanapin ito, at ikopya sa \System32), o hanapin ito online.

## Paggawa ng proyekto

Pagkatapos ng matagumpay na pagkonpigyura ng instalasyon sa itaas, pwede ka nang gumawa ng isang NeoContract na proyekto sa Visual Studio 2017.

![bagong smart contract na proyekto](/assets/new_smart_contract_project.png)

Pagkatapos mong gumawa ng isang proyekto, ito ay awtomatikong gagawa ng isang C# na file. Ang default na class ay mag-iinherita ng SmartContract ay ipapakita sa sumusunod:

![smart contract function code](/assets/smart_contract_function_code.png)


## Ikompayl ang Proyekto

Ang lahat ay handa na para magdagdag ng entry na method na magdedefine sa smart na kontrata:

```c#
public class Contract1 : SmartContract
{
    public static void Main() // Tandaan na ang Main na method ay kina-capitalize
    {
        
    }
}
```

Pagkatapos mong ikompayl ito, makikita mo ang `SmartContract1.avm` sa loob ng `bin/Debug` na direktoryo, kung saan ang file na ito ang nabubuo bilang Neo smart na kontrata.

![ikompayl ang smart na kontrata](/assets/compile_smart_contract.png)

Ngayon na natapos mo nang i-konpigyura ang NEO smart contract development environment, pakipunta na sa [tutoryal para sa NEO smart na kontrata](tutorial.md)
