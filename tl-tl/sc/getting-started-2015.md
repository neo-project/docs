# Paano gamitin ang C # para magsulat ng NEO smart na kontrata para sa VS2015

Kami ay kasalukuyang nagrerekomenda na gumamit ng C# para mag-program ng mga smart na kontrata (bagamat kami ay sumusuporta o nagpaplanong sumuporta sa Java, Kotlin, Go, C/C + +, Python, Javascript at iba pang mga programming na lengguwahe)

Ang seksyon na ito ay naglalaman ng maikling tutoryal na maggagabay sa iyo para ikonpigyura ang C# development environment para sa mga NEO smart na kontrata at magbibigay sa iyo ng ideya kong papaano gumawa ng isang proyekto ng smart na kontrata at paano ito ikokompayl.

## mga development tool

### 1. Visual Studio 2015

Pamamaraan ng Pag-download at Pag-install:

Kung meron nang naka-install na Visual Studio 2015 (kahit anong bersyon) sa iyong kompyuter, pwede mong laktawan ang seksyon na ito.

Ang Visual Studio 2015 ay wala na sa home ng opisyal na website, pero maari pa rin itong madownload.

Buksan ang [lumang bersyon ng Visual Studio download na pahina](https://www.visualstudio.com/en/vans/vs/older-downloads/) at i-click ang `free to join`

   ![](assets/install_core_cross_platform_development_toolset.jpg)

Gamitin ang iyong sariling Microsoft account para mag-login, itala ang Visual Studio Dev Essentials sa navigation menu, i-click ang `download`

![imahe](assets/2017-05-10_13-47-10.jpg)

Sa search na kahon, itala ang Visual Studio Community 2015 with Update 3, at piliin ang resulta ng paghahanap sa tamang bersyon, lengguwahe, etc., i-click ang kanang bahagi ng `download` na pindutan.

![imahe](assets/2017-05-10_13-45-48.jpg)

Ang pamamaraan ng pag-install at ang general na software ay kapareho lang, ang proseso ng pag-install na hindi kinakailangan ang pagpili ng mga karagdagang mga feature, ang core na parte ng VS2015 lamang ang pwede ma-install

![imahe](assets/2017-05-10_9-48-54.jpg)

### 2. Ang NET Core tools Preview 2 para sa Visual Studio 2015

Pamamaraan ng Pag-download at Pag-install:

Buksan ang [.Net Core download na pahina](https://www.microsoft.com/net/download/core)

I-download at i-install ang NET Core tools Preview 2 para sa Visual Studio 2015

![imahe](assets/2017-05-10_15-38-46.jpg)

### 3. NeoContractPlugin

Pamamaraan ng pag-install:

Buksan ang Visual Studio 2015, buksan ang tool, na-extend at na-update, i-click ang nasa kaliwa para sa online search para sa NEO instolasyon, Neo.SmartContract

![imahe](assets/2017-05-10_15-50-48.jpg)

### 4. neo-compiler

Pamamaraan ng Pag-install at pag-konpigyura:

I-download ang [neo-compiler](https://github.com/neo-project/neo-compiler) na proyekto sa Github, buksan ang solusyon gamit ang Visual Studio 2015, ikompayl ang neon project,

![imahe](assets/2017-05-10_18-22-39.jpg)

Pagkatapos na makompleto ang pagkompayl, ang neon.exe na file ay mabubuo sa `bin\Debug\netcoreapp1.0\win10-x64`
   > [!Tandaan]
   > Kung ang iyong kompyuter ay gumagamit ng 32-bit na operating system, kinakailangan mong baguhin ang win10-x64 sa project.json file sa win10-x86.

Kinakailangan mo na ngayong magdagdag ng isang landas, para ang kahit na anong lokasyon ay makaka-akses sa programma. Para idagdag ang path na pamamaraan, buksan ang mga computer properties (o buksan ang control panel, system and security, system), buksan ang advanced system settings, piliin ang Advanced tab, i-click ang environment variable na pindutan, tulad ng ipinapakita sa Pigyur

![imahe](assets/2017-05-10_18-37-05.jpg)

Tapos, piliin ang Path at i-click ang `Edit '

![imahe](assets/2017-05-10_18-46-05.jpg)

Sa pop-up window, i-click ang "New" input neon.exe kung saan ang direktoryo, i-click ang `OK`, `OK`

![imahe](assets/2017-05-10_18-48-11.jpg)

Idagdag ang path, patakbuhin ang cmd test, i-enter ang neon.exe, walang error, ang resulta na pinapakita sa pigyur ay nagpapakita na naging matagumpay ang pagkonpigyura

![imahe](assets/2017-05-10_18-52-10.jpg)

## Paglikha ng proyekto

Pagkatapos ng matagumpay na apat-na-hakbang na pag-install sa itaas, pwede ka nang lumikha nga isang proyekto na NEO smart na kontrata sa Visual Studio 2015.

![imahe](assets/2017-05-10_16-08-48.jpg)

Ito ay awtomatikong bubuo ng isang C# na file, ang default na class ay iinherit galing sa FunctionCode, na pinapakita sa sumusunod:

![imahe](assets/2017-05-10_16-25-09.jpg)

- Tandaan: kung ang sumusunod na imahe ay lalabas, ang proyoketo na nasa Neo.SmartContract.Framework ay hindi na-irestore ng maayos, pwede mong i-restore ang Nuget package sa susunod na pamamaraan (ang proseso na walang networking)

![imahe](assets/2017-05-10_16-27-40.jpg)

Sa Solution Explorer, piliin ang solusyon, i-right click, at i-click ang `Restore NuGet Package`

![imahe](assets/2017-05-10_16-28-39.jpg)

Pagkatapos, buksan ang project reference, i-click ang `Neo.SmartContract.Framework`. May ilang mga kaso pa ding hindi maka-restore sa Nuget package, paano ito? Paki-restart ang Visual Studio 2015 o subukang magbuo nga soluson ng direkta.

![imahe](assets/2017-05-10_16-31-55.jpg)

## Ikompayl ang proyekto

Ang lahat ay handa na para magdagdag ng entry na pamamaraan sa proyekto:

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Tandaan na ang main na method ay dapat i-capitalize
    {
        
    }
}
```
Pagkatapos nitong makompayl, makikita mo ang nabuong `SmartContract1.avm` file sa `bin/Debug` na direktoryo, na kung saan ito ang file na nabuo ng NEO smart na kontrata.

![imahe](/assets/compile_smart_contract.jpg)


!Tandaan:
   Kung ikaw ay nakabuo, walang awtput ng mga resulta ng map, hindi ito mahalaga, pwede ka ring direktang magtala ng command para i-kompayl ang dll avm na file

   Buksan ang command prompt, pumunta sa Debug na direktoryo, itala ang sumusunod na highlight (SmartContract1.dll ang pangalan nga dll na nabuo sa pamamagitan ng nakaraang hakbang).
```
	> C: \ ... \ bin \ Debug> `./neon SmartContract1.dll`
	>
	> Neo.Compiler.MSIL console app v1.6.4.2
	>   
	> Find function entry point: System.Void SmartContract1.Contract1 :: Main ()
	>   
	> Convert succ
	>   
 	> Write: SmartContract1.avm
 	>
 	> SUCC
  	>
	> C: \ ... \ bin \ Debug>
```

Ngayon na nakompleto mo na ang pagkonpigyura ng development environment para sa smart na kontrata, pakipunta sa [Art Experiment na Gabay para sa Tomids](tutorial.md)
