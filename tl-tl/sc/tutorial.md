# Tutoryal para sa NEO smart contract

Pagkatapos basahin ang mga nakaraang mga tutoryal, dapat mo na ngayong magamit ang C# sa loob ng Visual Studio 2015 o 2017 para lumikha ng isang smart contract na proyekto. Dito, tatalakayin natin kong paano ini-eksekyut ang mga smart contract sa NeoVM (Neo Virtual Machine).

## Mga nagpapasimula ng smart contract

Mayroong dalawang paraan para umpisahan ang mga smart contract:

1. Contract User Awtentikasyon: Dito ang mga smart contract ay isang kontrata na account. Kung ang user ay hihiling na gumamit ng kontrata na account sa isang asset, ito ay magpapasimula sa smart contract.

2. Mano-manong pagtawag sa isang smart contract: Dito, ang user ay magpapadala ng isang transaksyon (Invocation Transaction) para simulan ang implementasyon ng isang smart contract.

## NeoVM

Ang NeoVM ay isang bertuwal na makina na umi-eksekyut ng NEO smart contract na code. Ang pinag-uusapan natin ay tungkol sa limitadong konsepto ng bertuwal na makina, hindi tungkol sa mga operating system o mga program na nakakasimyuleyt nito tulad ng VMware o Hyper-V.

Halimbawa, sa Java JVM o .NET CLR, ang mga source code ay i-cocompile sa nauugnay na bytecode at ipapagana sa nararapat na bertuwal na makina. Ang JVM o CLR ay magpapatakbo ng bytecode, na kaparehas lang sa pagpapatakbo ng mga instruksyon sa isang pisikal na makina. Kapansin-pansin, na ang nararapat na binary na instruksyon ay pinapatakbo pa rin sa pisikal na makina. Ang pisikal na makina ay kukuha ng mga instruksyon galing sa memorya, ililipat ito patungo sa CPU gamit ang bus, tapos idedecode, i-eeksekyut, at itatabi ang resulta.

### Ang arkitektura ng bertuwal na makina

   ![](../../assets/neo-vm.jpg)

Ang dayagram sa itaas ay ang arkitektura ng sistema ng Neo Virtual Machine (NeoVM), kung saan ang pag-deploy sa loob ng dashed na kahon ay ang core ng bertuwal na makina.

#### Execution engine

Ang berde na nasa kaliwa ay ang Virtual Machine execution engine (ang katumbas ng CPU). Ito ay maaaring mag-eksekyut ng mga karaniwang instruksyon tulad ng flow na kontrol, mga stack na operasyon, mga bit na operasyon, mga aritmetika na operasyon, mga lohikal na operasyon, mga kriptograpik na method, at iba pa. Ito ay maaari ring makipag-ugnayan sa Interoperable service na layer (na inilalarawan sa ibaba) sa pamamagitan ng mga pagtawag sa sistema.

#### Evaluation stack

An gitnang bahagi na kulay-abo ng bertuwal na makina ay ang Evaluation Stack (ito ay ang katumbas ng memorya). Sa mga araw na ito, mayroong dalawang pamamaraan upang makamit ang bertuwal na makina 1) batay sa stack at 2) batay sa register. Ang dalawang paraan na ito ay mayroong kanikanilang mga benepisyo at limitasyon, at ang dalawang ito ay may kanikanilang magagandang mga halimbawa ng implementasyon. Mayroong mga batay sa stack na mga bertuwal na makina kagaya ng JVM, CPython, at ang .NET CLR. Sa kabilang banda, mayroon ding mga batay sa register na mga VM, tulad ng Dalvik at Lua5.0. Ang mga batay sa stack na bertuwal na makina ay mayroong computing stack na konsepto na nagpapahintulot sa mga bertuwal na makina na uminter-ak ng direkta sa stack (Evaluation Stack) kung gumagawa ng mga tunay na operasyon.

Dahil ang default na aksyon ng isang batay sa stack na VM ay ang pagkuha ng datos galing sa operand na stack, hindi na kailangang tumokoy ng isang operand. Ihambing ito, halimnbawa, sa susunod na x86 na assembly `"ADD EAX, EBX"`. Ang operasyon ay nangangailangan sa iyo na itukoy ang mga source operand at ang destinasyon ng resulta. Ang mga instrukyon ng batay sa stack na bertuwal na makina ay hindi kailangang magtukoy ng mga parametero na ito. Halimbawa, ang adisyon ng isang simpleng "ADD" na operasyon ay ipapatakbo ng direkta sa operand na stack. Ang datos ay pwede ilalabas ng direkta at ang resulta ay itatabi sa itaas ng stack.

#### Interoperable service na layer

Ang kanang bahagi na kulay asul ay ang interoperable service na layer ng bertuwal na makina (ito ay katumbas ng mga periperal). Sa ngayon, ang interoperable service na layer ay nagbibigay ng ilang mga API para makuha ang chain-chain na datos ng mga smart contract. Ito ay pwede kumuha ng bloke na impormasyon, transaksiyon na impormasyon, kontrata na impormasyon, asset na impormasyon, at iba pa.

Sa karagdagan, ang interoperable service na layer ay nagbibigay din ng hindi nawawalang area na matatabihan ng bawat isang kontrata. Ang bawat isang kontrata ay opsyonal na gagawin gamit ang pribadong storage, kung saan ito ay may key-value object na kaanyuan na dinitermina ng bagay na tinatawag ng kontrata sa halip ng konteksto ng hindi nawawalang store. Ang tumatawag ay kailangang pumasa ng kanilang sariling storage na konteksto patungo sa tinatawagan (para ikumpleto ang awtorisasyon) bago makagawa ng mga pagbasa at pagsulat na mga operasyon ang tumatawag.

### Charge mode

Ang isang smart contract ay maaring iprogram para sumingil ng bayad na hinahati sa mga gastos sa pagdeploy at gastos sa pag-eksekyut.

Ang mga gastos sa pagdeploy ay ang kinakailangang bayad ng isang debeloper para magdeploy ng isang smart contract sa block chain (kasalukuyang 500 GAS). Ang gastos ng eksekyusyon ay ang bayad ng isang user para i-eksekyut ang isang smart contract. Ang lahat ng operasyon ay mayroong mga gastos, na ang karamihan ay nagdedefault sa 0.001 GAS. Ang unang 10 GAS ay libre. Para unahin sa pagproproseso, manomanong itaas ang bayad para sa pag-eeksekyut. Para sa iba pang impormasyon tungkol sa mga bayad sa smart contract, bumasa [dito](systemfees.md#smart-contract-fees).

## Isang simpleng smart contract

Narito ang ilang mga simpleng smart contract:

```c#
public static bool Main ()
{
    return true;
}
```

Dito ang isinasauli na halaga ng kontrata ay parating true, nagpapahiwatig na kahit sino ay pwedeng gumastos ng contract address ng mga asset (pwedeng isipin na pera).

Ang NEO wallet na client ay mayroong punsyon para tumanggal ng isang asset. Kung tatanggal ka nang asset, ang asset ay ipapadala patungo sa tinukoy na address na nagrerepresenta sa nagawang address ng nasa itaas na mataliong kontrata. Kahit sino ay pwedeng gumastos ng asset na nasa address. Ang mga asset na nasa address ay mga asset na hindi gusto ng iba.

```c#
public static bool Main ()
{
    return false
}
```

Ang isinasauli na halaga ng kontrata ay parating `false`, nagpapahiwating na ang mga asset ng kontratang ito ay hindi pwedeng gamitin (ito ay maaring interpretahin na sinusunog o ginigiba ang isang asset). Ang ganitong kontrata, halimbawa, ay maaring gamitin para sa mga share ng isang kompanya na itinanggal o kinansela.

Para sa mga halimbawa, pakitingnan ang:

[Hello World](tutorial/HelloWorld.md)

[Lock (lock)](tutorial/lock.md)

[Domain (Domain Name System)](tutorial/Domain.md)
