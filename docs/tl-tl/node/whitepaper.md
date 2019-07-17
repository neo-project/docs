# Isang Byzantine na Algoritmo ng toleransiya ng kamalian para sa Blockchain 

Erik Zhang

erik@vcage.com 

## Abstrakto

​Ang artikulong ito ay nagmumungkahi ng isang pinahusay na Byzantine na toleransiya sa kamalian na algoritmo, na binagay para sa sistemang blockchain. Gayundin, sa sistemang ito, ang mga mensahe ay sumailalim sa pagkawala, pagkasira, pagkawalang-kilos, at pag-uulit. Ganun din, ang pagkaka-ayos ng pag-papadala ay hindi kailangan na naaalinsunod sa pagkakaayos ng pagtanggap ng mga mensahe. Ang mga aktibidad ng mga node ay maaring maging arbitraryo, sila ay pwedeng sumali at umalis sa network sa kahit na anong panahon; sila din ay pwedeng magbasura at pumeke ng impormasyon o sadyang titigil lang sa pagtatrabaho. Artipisyal o hindi artipisyal na pagkakamali ay pwede rin mangyari. Ang ating algoritmo ay nagbibigay din ng 𝑓 = ⌊ (𝑛−1) / 3 ⌋ na toleransiya ng kamalian sa sistemang konsensus na binubuo ng n node. Ang kapasidad ng toleransiya nito ay sumasaklaw ng seguridad at sa abilidad na pwedeng gamitin na angkop sa kahit na anong na anumang sinasaklawang network. 

## Buod 

Ang blockchain ay isang desentralisadong pagbabahagi ng sistema ng pagtatala. Ito ay pwedeng gamitin sa pagrerehistro o pag-iisyu ng makabagong digital na mga bagay na may halaga, mga sertipikong ikaw ay nagmamay-ari ng mga ari-arian, kreditong mga puntos at iba pa. Ito ay nagbibigay-daan din sa paglipat, pagbayad, at mga transaksyong tao-sa-taong pamamaraan. Ang teknolohiya ng blockchain ay orihinal na iminungkahi ni Satoshi Nakamoto sa paraan ng listahan ng liham na kriptograpiya, halimbawa, ang Bitcoin. Mula noon, sandamakmak na mga aplikasyon na batay sa blockchain ang lumitaw, tulad ng sistemang e-cash, palitan ng mga equity ng stock at ang mga sistemang Smart na Kontrata.

Ang sistemang blockchain ay may kalamangan kesa sa tradisyunal na sentralisadong systema ng pagtatala dahil sa ito'y bukas, sistemang kailan man ay hindi mababago at may kontra sa maramihang paggasta na mga karakter, at ito din ay hindi umaasa sa kahit na anumang ikatlong partido  na mapagkakatiwalaan.

Gayunpaman, kayagaya sa ibang sistema ng pagbabahagi, ang mga sistemang blockchain ay hinahamon ng paghinda sa bilis ng network, mga kamalian sa transmisyon, mga software bugs, mga butas sa seguridad at ang mga banta ng black-hat hacker. Bukod pa rito, ang  desentralisadong katangian ay nagpapahiwatig na walang kalahok sa sistema ang mapagkakatiwalaan. May mga malisyong mga node ang posibleng lumabas, gayundin ang pagkakaiba nga mga datos buhat ng mga magkakasalungat na mga interes.

Para malabanan ang mga potensyal na kamalian, ang sistemang blockchain ay nangangailangan ng mabisang mekanismong pangkonsensus upang matiyak na ang bawat node ay may kopya ng mga kilalang bersyon ng kabuuang pagtatala.Ang tradisyunal na Mekanismo na toleransiya ng kamalian na hinggil sa ilang problema ay hindi maaaring may ganap na kakayahang harapin ang isyu na ang sistemang blockchain at pamamahagi na hinaharap nito. isang unibersal na toleransiya ng kamalian na solusyong panglunas ang kinakailangan.

mekanismong pruweba-ng-trabaho[1], inempleyo ng Bitcoin, bagkus ay tinatalakay nito ang isyu ng may katalinuhan. Ngunit ito ay sadyang may kamahalan talaga, halimbawa, mahal na presyo ng kuryenteng bayarin at mataas na paggamit ng enerhiya. Dagdag pa rito, dahil sa presensya ni Bitcoin, ang mga bagong blockchain ay kailangang maghanap ng ibang hashing na mga algoritmo, ng sa ganun ay maiwasan ang kompyutisyunal na pag-atake sa kanila. halimbawa, inadopt ni Litcoin ang SCRYPT, kesa sa SHA256 ni Bitcoin.

Ang mekanismong Byzantine na toleransiya ng kamalian ay isang unibersal na solusyon for sa mga sistemang nababahagi[5]. Sa artikulong ito, batay sa Practical Byzantine Fault Tolerance (PBFT)[3] na iminungkahi nila Castro at Liskov noong 1999, isang pinabuting Algoritmo ng Byzantine na toleransiya ng kamalian ang iminungkahi para sa sistemang blockchain。 

## Modelo ng Sistema 

Ang blockchain ay isang sistema ng ipinamahaging pagtatala na kung saan ang mga partisipante ay kumokonekta sa bawat isa sa paraan ng tao-sa-tao na network. Lahat ng mensahe na nakaloob dito ay ipapadala sa pamamagitan ng pagpapahayag. May dalawang uri ng mga tungkulin ang pumiiral: Ordinaryong node at node ng bookkeeping. ang mga ordinaryong node ay ginagamit ang sistema upang makalipat at makipag-palitan, pagtanggap ng mga datos sa talaan; habang ang node ng bookkeeping ay nagbibigay ng serbisyong akawnting sa pangkalahatang network at pinapanatili ang talaan. 

Gayunpaman, sa sistemang ito, ang mga mensahe ay sumailalim sa pagkawala, pagkasira, pagkawalang-kilos, at pag-uulit. Ganun din, ang pagkaka-ayos ng pag-papadala ay hindi kailangan na naaalinsunod sa pagkakaayos ng pagtanggap ng mga mensahe. Ang mga aktibidad ng mga node ay maaring maging arbitraryo, sila ay pwedeng sumali at umalis sa network sa kahit na anong panahon; sila din ay pwedeng magbasura at pumeke ng impormasyon o sadyang titigil lang sa pagtatrabaho. Artipisyal o hindi aryipisyal na mga glitches ay pwede din mangyari.

Ang Integridad at Pagpapatunay ng transmisyon ng impormasyon ay natitiyak sa pamamagitan ng kriptograpiya habang ang nagpapadala ay kailangang maglagay ng lagda sa halaga ng hash ng mensaheng pinadala. Dito ay binibigyan nating ng kahulugan na ang 〈𝑚〉<sub>𝜎𝑖</sub> mensaheng m’s digital na lagda galing sa i na node, habang ang D(m) ay ang halaga ng hash ng mensaheng m. Kahit walang espesyal na paglilinaw, lahat ng lagda na tinutukoy sa artikulong ito ay mga lagda sa halaga hash ng mensahe.

## Ang Algoritmp

Ang ating algoritmo ay nagtitiyak sa seguridad at pati na rin sa abilidad na ito'y pwedeng gamitin. Dahil sa mga maling node sa konsensus ng paggawa ng hindi hihigit sa ⌊ (𝑛−1) / 3 ⌋ , ang panksyonalidad at katatagan ng sistema ay masisiguro. Sa loob nito, 𝑛 = |𝑅| ay nagmumungkahi na ang lahat ng kabuuang bilang ng node na kasali sa paggagawa ng konsesus habang ang R ay ang ibig sabihin ay pangkat ng mga node ng konsensus. Bigay ang 𝑓 = ⌊ (𝑛−1) / 3 ⌋ , f ay ang tumatayong kahulugan para sa pinakamataas na bilang ng mga maling node na pwede sa sistema. Sa katunayan, ang kabuuang talaan ay binabantayan at iniingatan ng mga node na bookkeeping habang ang mga ordinaryong node ay hindi sumasali sa paggagawa ng konsensus. Ito ay para ipakita ang pangkalahatang pamamaraan ng paggawa ng konsensus.

Lahat ng mga node na para sa konsensus ay kailangang magpanatili ng talahanayang pang-estado para itala ang kasalukuyang estado ng konsensus. Ang grupo ng datos na ginamit para sa konsensus mula sa simula hanggang sa walas nito ay tinatawag na View. Kung ang konsensus hindi maabot ng kasalukuyang View, ang pagbabago ng View Change ang kinakailangan. Tutukuyin namin ang bawat isang View na may bilang v, na magsisimula sa 0 at ito ay maaaring madagdagan hanggang sa makamit ang konsensus.

​Tinutukoy namin ang bawat isang node ng isang konsensus gamit ang isang numero, nagsisimula sa 0, ang huling node ay may bilang na n − 1. sa bawat pag-ikot ng paggawa ng konsensus, may isang node na gaganap bilang tagapagsalita ng bahay habang ang ibang mga node ay maglalaro bilang mga kongressman. Ang numero ng tagapagsalita na p ay matutukoy sa pamamagitan ng sumusunod na algoritmo: Gayung din ang kasalukuyang taas ng bloke ay h, tapos ang 𝑝 = (ℎ − 𝑣) 𝑚𝑜𝑑 𝑛, ang halaga ni p ay magiging  0 ≤ 𝑝 < 𝑛 .

​Isang bagong bloke ang mabubuo sa bawat pag-ikot ng konsensus, na hindi bababa sa 𝑛 − 𝑓 na mga lagda galing sa mga node ng bookkeeping. sa panahon ng pagkakabuo ng bloke, isang bagong pag-ikot ng paggawa ng knsensus ang magsisimula, na-irereset sa v=0.

###  Pangkalahatang Pamamaraan 

Itakda ang mga agwat ng oras ng paggawa ng bloke bilang t, sa ilalim ng mga normal na pangyayari, ang algoritmo ay magpapatupad ng sumusunod na pamamaraan：

1) Ang pagpapahayag ng transaktsyon na datos ng node sa panghalahatang network , na nakalakip ang lagda ng nagpadala;

2) Lahat ng mga node ng bookkeeping ay nagsusubaybay sa mga datos ng transaksyon na namamahayag ng malaya at itinatago ang mga datos sa kanyang sariling memorya ayon sa pagkakabanggit; 

3) Pagkatapos ng oras t, ang tagapagsalita ay magpapadala ng 〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑞𝑢𝑒𝑠𝑡,ℎ,𝑣,𝑝,𝑏𝑙𝑜𝑐𝑘,〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑝</sub>〉； 

4) Matapos matanggap ang lahat ng  iminumungkahi, ang mga kongressman i ay magpapadala ng 〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑠𝑝𝑜𝑛𝑠𝑒,ℎ,𝑣,𝑖,〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑖</sub>〉 ;

​5) Kahit na anumang node, sa panahon ng pagtanggap ng hindi bababa sa 𝑛 − 𝑓  〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑖</sub>, ay aabot sa isang konsensus at maglalathala ng isang buong bloke;

6) Kahit na anumang node, matapos matanggap ang buong bloke, ay buburahin ang transaksyong nasa katanungan na galing sa kanyang memorya at magsisimula ng panibagong pag-ikot para sa konsensus;

Kinakailangan na, sa lahat ng mga node ng konsensus, at hindi bababa sa  𝑛 − 𝑓 ng mga node ang nasa orihinal na estado. Ito ay para sabihin na para sa lahat ng node na i, ang taas ng blokeng h at bilang ng View na v ay magkapareha. Ito ay hindi mahirap, ang pagkakapareho-pareho ng h ay maabot sa paraan ng pagsisingkronisa ng mga bloke habang ang pagkakapare-pareha ng v naman ay maaabot sa paraan ng pagbabago ng View. Ang pagsisingkronisa ng bloke ay hindi sakop sa artikulong ito. Para sa pagbabago ng view, tingnan ang susunod na seksyon.

Ang mga node, matapos mamonitor ang pagpapahayag at pagtatanggap ng mga mungkahi, ang magpapatunay ng mga transaksyon. Hindi sila pwedeng sumulat ng bawal na transaksyon sa memorya kung sa huli ay mailantad na. Kung ang bawal na transaksyon ay nakapaloob sa iminumungkahi, ang ikot ng konsensus na iyon ay iaabandona at ang pagbabago sa View ay magsisimula agad. Ang pamamaraan ng pagpapatunay ay ang mga sumusunod:

1) Ang pormat ba ng datos ng transaksyon ay naaayon sa patakaran ng sistema? Kung hindi, ang transaksyon ay pinasiyahang bawal;

2) Ang transakyon ba ay nasa blockchain na? Kung oo, ang transaksyon ay pinasiyahang bawal;

3) Ang lahat ba ng iskrip ng kontrata ng transaksyon ay maayos na naipatupad? Kung hindi, ang transaksyon ay pinasiyahang bawal;

4) May maramihang paggasta sa transakyon? in the transaction? Kung oo, ang transaksyon ay pinasiyahang bawal;

5) Kung ang transaksyon ay hindi pinasiyahang bawal sa mga nabanggit na pamamaraan sa itaas, Ito ay ipinasyang legal;

### View Change 

Kung, matapos ng 2<sup>𝑣+1</sup> ⋅ 𝑡 na pagitan ng oras, ang mga node i ay hindi makakaabot ng konsensus o kaya naman ay mabigyan ng mga panukala ng naglalaman ng bawal na mga transaksyon, ang View Change ang kukuha sa pwesto: 

1) kung may k=1, 𝑣<sub>𝑘</sub> = 𝑣 + 𝑘 ;

2) Ang mga node ng i ay nagpadala ng kahilingan na View Change 〈𝐶ℎ𝑎𝑛𝑔𝑒𝑉𝑖𝑒𝑤,ℎ,𝑣,𝑖,𝑣<sub>𝑘</sub>〉 ;

3) Sa puntong ang node ay nakatanggap ng hindi bababa sa 𝑛 − 𝑓  kagaya sa v<sub>k</sub> sa ibang i, ang View Change ay tapos na. I-set ang 𝑣 = 𝑣<sub>𝑘</sub> at ang paggawa ng konsensus ay magsisimula na;

4) Kung, matapos ang 2<sup>𝑣+1</sup> ⋅ 𝑡 na pagitan ng oras, ang View Change ay hindi natapos, ang k ay magdaragdag at babalik sa ikalawang hakbang;

Sa patuloy na pagtaas ng k, ang overtaym na oras ng paghihintay ay tataas sa paraang exponensyal, kaya ang malagiang View Change ay maiiwasan at ang mga node ay hinihimok na maabot ang walang pagbago sa ilalim ng v.

Bago matapos ang View Change, ang orihinal na View v ay mabisa pa rin, para ang di kailangan na View Change na sanhi ng okasyon na pagbagal ng network ay maiiwasan. 

### Tsart ng daloy

![](~/assets/consensus_flowchart.jpg)

## Kapasidad ng Toleransiya ng Kamalian 

​Ang ating algoritmo ay nagbibigay ng 𝑓 = ⌊ (𝑛−1) / 3 ⌋  na toleransiya ng kamalian sa isang sistema ng konsensus na binubuo ng mga n na node. Ang kapasidad ng toleransiya ay naglalaman ng seguridad at abilidad na ito ay pwede gamitin na nababagay sa kahit anong mang network na kaapaligiran.

Ang mga kahilingan ng mga node sa datos ay naglalaman ng lagda ng nagpadala, nang sa ganun ay ang mga malisyosong node ng bookkeeping ay hindi makakapalsipika ng kahilingan. Sa halip, sila ay magtatangka na baliktarin ang estado ng sistema pabalik sa nakaraan, na pwersahang i-form ang sistema.

Gayunpaman, sa kapaligiran ng network ng sistema, ang mga node ng konsensus aay nakahati sa tatlong parte: 𝑅 = 𝑅1 ∪ 𝑅2 ∪ 𝐹 , at 𝑅1 ∩ 𝑅2 = ∅ , 𝑅1 ∩ 𝐹 = ∅ ，𝑅2 ∩ 𝐹 = ∅ . Gayunpaman din,
kapwa R1 at R2 ay mapagkakatiwalaan na mga node ng bookkeeping sa imbakan ng impormasyon na sila lang ang pwedeng makipag-usap sa mga node ng kanilang pangkat; Ang F ay mga malisyosong node sa koordinasyon; bukod dito, ang kondisyong ng network ng F ay nagpapahintulot sa kanila na makipag-usap sa kahit na anong node, kasaali ang R1 at R2.
Kung si F ay nagnanais na i-fork ang sistema, sila ay kailangan na umabot sa konsensus kasama ang R1 at maglathala ng mga bloke, at pagkatapos ay maabot ang pangalawaang konsensus ng hindi ipinapaalam kay R2, na pinapawalang bisa ang konsensus kasama ang R1.
​Para maabot ito, kailangan ay |𝑅1| + |𝐹| ≥ 𝑛 − 𝑓 at |𝑅2| + |𝐹| ≥ 𝑛 − 𝑓 .
Sa di inaasahang pagkakataon, |𝐹| = 𝑓​ , e.g. ang bilang ng mga malisyosong node ay nasa pinakasukdulan sa ang sistema ay di na kayang tiisin ang nasabing relasyon ay magiging |𝑅1| ≥ 𝑛 − 2𝑓​ at ​|𝑅2| ≥ 𝑛 − 2𝑓. Pagsamahin ang dalawa, |𝑅1| + |𝑅2| ≥ 2𝑛 − 4𝑓​, na pwedeng mapadali kagaya ng ​𝑛 ≤ 3𝑓. Kung ang binigay ay 𝑓 = ⌊ (𝑛−1) / 3 ⌋, na sumasalungat sa dati, ito ay mapapatunayan na ang sistema ay hindi pwedeng i-form forked sa loob ng saklaw ng toleransiya. 

## Reperensiya 

[1] Nakamoto S. Bitcoin: tao-sa-tao na na de koryenteng sistema ng pera[J]. 2008. 

[2] Lamport L, Shostak R, Pease M. Ang problema sa mga heneral ng Byzantine[J]. ACM na mga Transkasyon sa mga Lenggwaheng para sa Pag-program at mga Sistema(TOPLAS), 1982, 4(3): 382-401. 

[3] Castro M, Liskov B. Praktikal na Byzantine na toleransiya ng kamalian[C]//OSDI. 1999, 99: 173 186.

[4] Bracha G, Toueg S. protokol ng pamamahayag at hindi sabay na konsensus[J]. Pahayagan ng ACM (JACM), 1985, 32(4): 824-840. 

[5] 范捷, 易乐天, 舒继武. 拜占庭系统技术研究综述[J]. 软件学报, 2013, 6: 012. 

