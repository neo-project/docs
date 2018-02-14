# Isang Byzantine na Algoritmo ng toleransiya ng kamalian para sa Blockchain 

Erik Zhang

erik@vcage.com 

## Abstrakto

​Ang artikulong ito ay iminumungkahi ang isang pinahusay na  Byzantine na toleransiya sa kamalian na algoritmo, na binagay para sa sistemang blockchain. Gayundin, sa sistemang ito, ang mga mensahe ay sumailalim sa pagkawala, pagkasira, pagkawalang-kilos, at pag-uulit. Ganun din, ang pagkaka-ayos ng pag-papadala ay hindi kailangan na naaalinsunod sa pagkakaayos ng pagtanggap ng mga mensahe. Ang mga aktibidad ng mga noda ay maaring maging arbitraryo, sila ay pwedeng sumali at umalis sa network sa kahit na anong panahon; sila din ay pwedeng magbasura at pumeke ng impormasyon o sadyang titigil lang sa pagtatrabaho. Artipisyal o hindi artipisyal na pagkakamali ay pwede rin mangyari. Ang ating algoritmo ay nagbibigay din ng 𝑓 = ⌊ (𝑛−1) / 3 ⌋ na toleransiya ng kamalian sa sistemang konsensus na binubuo ng n noda. Ang kapasidad ng toleransiya nito ay sumasaklaw ng seguridad at sa abilidad na pwedeng gamitin na angkop sa kahit na anong na anumang sinasaklawang network. 

## Buod 

Ang blockchain ay isang desentralisadong pagbabahagi ng sistema ng pagtatala. Ito ay pwedeng gamitin sa pagrerehistro o pag-iisyu ng makabagong digital na mga bagay na may halaga, mga sertipikong ikaw ay nagmamay-ari ng mga ari-arian, kreditong mga puntos at iba pa. Ito ay nagbibigay-daan din sa paglipat, pagbayad, at mga transaksyong tao-sa-taong pamamaraan. Ang teknolohiya ng blockchain ay orihinal na iminungkahi ni Satoshi Nakamoto sa paraan ng listahan ng liham na kriptograpiya, halimbawa, ang Bitcoin. Mula noon, sandamakmak na mga aplikasyon na batay sa blockchain ang lumitaw, tulad ng sistemang e-cash, palitan ng mga stock equity at ang mga sistemang smart na kontrata.

Ang sistemang blockchain ay may kalamangan kesa sa tradisyunal na sentralisadong systema ng pagtatala dahil sa ito'y bukas ,sistemang kailan man ay hindi mababago at may kontra sa maramihang paggasta na mga karakter, at ito din ay hindi umaasa sa kahit na anumang ikatlong partid  na mapagkakatiwalaan.

Gayunpaman, kayagaya sa ibang sistema ng pagbabahagi, ang mga sistemang blockchain ay hinahamon ng paghinda sa bilis ng network, mga kamalian sa transmisyon, mga softwer bugs, mga butas sa seguridad at ang mga banta ng black-hat hacker. Bukod pa rito, ang  desentralisadong katangian ay nagpapahiwatig na walang kalahok sa sistema ang mapagkakatiwalaan. May mga malisyong mga noda ang posibleng lumabas, gayundin ang pagkakaiba nga mga datos buhat ng mga magkakasalungat na mga interes.

Para malabanan ang mga potensyal na kamalian, ang sistemang blockchain ay nangangailangan ng mabisang mekanismong pangkonsensus upang matiyak na ang bawat noda ay may kopya ng mga kilalang bersyon ng kabuuang pagtatala. Mekanismong tadisyunal na toleransiya ng kamalian na hinggil sa ilang problema ay hindi maaaring may ganap na kakayahang harapin ang isyu na ang sistemang blockchain at pamamahagi na hinaharap nito. isang unibersal na toleransiya ng kamalian na solusyong panglunas ang kinakailangan.

mekanismong pruweba-ng-trabaho[1], inempleyo ng Bitcoin, bagkus ay tinatalakay nito ang isyu ng may katalinuhan. Ngunit ito ay sadyang may kamahalan talaga, halimbawa, mahal na presyo ng kuryenteng bayarin at mataas na konsampsyon ng enerhiya. Dagdag pa rito, dahil sa presensya ni Bitcoin, ang mga bagong blockchain ay kailangang maghanap ng ibang hashing na mga algoritmo, ng sa ganun ay maiwasan ang komputisyunal sa pag-atake sa kanila. halimbawa, inadopt ni Litcoin ang SCRYPT, kesa sa SHA256 ni Bitcoin.

Ang mekanismong Byzantine na toleransiya ng kamalian ay isang unibersal na solusyon for sa mga sistemang nababahagi[5]. Sa artikulong ito, batay sa Practical Byzantine Fault Tolerance (PBFT)[3] na iminungkahi nila Castro at Liskov noong 1999, isang pinabuting Algoritmo ng Byzantine na toleransiya ng kamalian ang iminungkahi para sa sistemang blockchain。 

## Modelo ng Sistema 

Ang blockchain ay isang sistema ng ipinamahaging pagtatala na kung saan ang mga partisipante ay kumokonekta sa bawat isa sa paraan ng tao-sa-tao na network. Lahat ng mensahe na nakaloob dito ay ipapadala sa pamamagitan ng pagpapahayag. May dalawang uri ng mga tungkulin ang pumiiral: Ordinaryong noda at noda ng bookkeeping. ang mga ordinaryong noda ay ginagamit ang sistema upang makalipat at makipag-palitan, pagtanggap ng mga datos sa talaan; habang ang noda ng bookkeeping ay nagbibigay ng serbisyong akawnting sa pangkalahatang netwok at pinapanatili ang talaan. 

Gayunpaman, sa sistemang ito,ang mga mensahe ay sumailalim sa pagkawala, pagkasira, pagkawalang-kilos, at pag-uulit. Ganun din, ang pagkaka-ayos ng pag-papadala ay hindi kailangan na naaalinsunod sa pagkakaayos ng pagtanggap ng mga mensahe. Ang mga aktibidad ng mga noda ay maaring maging arbitraryo, sila ay pwedeng sumali at umalis sa network sa kahit na anong panahon; sila din ay pwedeng magbasura at pumeke ng impormasyon o sadyang titigil lang sa pagtatrabaho. Artipisyal o hindi aryipisyal na mga glitches ay pwede din mangyari.

Itegridad at pagiging tunay ng mga transmisyon ng impormasyon ay natitiyak sa pamamagitan ng kriptograpiya habang ang nagpapadala ay kailangang maglagay ng lagda sa halaga ng hash ng mensaheng pinadala. Dito ay binibigyan nating ng kahulugan na ang 〈𝑚〉<sub>𝜎𝑖</sub> mensaheng m’s digital na lagda galing sa i na noda, habang ang D(m) ay ang halaga ng hash ng mensaheng m. Kahit walang espesyal na paglilinaw, lahat ng lagda na tinutukoy sa artikulong ito ay mga lagda sa halaga hash ng mensahe.

## Ang Algoritmp

​Ang ating algoritmo tinitiyak ang segurida at at abilidad na itoy pwedeng gamitin. Dahil sa mga maling noda sa konsensus ng paggawa ng hindi hihigit sa ⌊ (𝑛−1) / 3 ⌋ , ang panksyonalidad at katatagan ng sistema ay masisigurado. Sa loob nito, 𝑛 = |𝑅| ay nagmumungkahi na ang lahat ng kabuuang bilang ng noda na kasali sa paggagawa ng konsesus habang ang R ay ang ibig sabihin ay pangkat ng mga noda ng konsensus. Bigay ang 𝑓 = ⌊ (𝑛−1) / 3 ⌋ , f ay ang tumatayong kahulugan para sa pinakamataas na bilang ng mga maling noda na pwede sa sistema. Sa katunayan, ang kabuuang talaan ay binabantayan at iniingatan ng mga noda na bookkeeping habang ang mga ordinaryong noda ay hindi sumasali sa paggagawa ng konsensus. Ito ay para ipakita ang pangkalahatang pamamaraan ng paggawa ng konsensus.

Lahat ng mga nodang para sa konsensus ay kailangang magpanatili ng talahanayang pang-estado para itala ang kasalukuyang estado ng konsensus. Ang set ng datos na ginamit para sa konsensus mula sa simula hanggang sa walas nito ay tinatawag na View. Kung ang konsensus hindi maabot ng kasalukuyang View, ang pagbabago ng View Change ang kinakailangan. Tutukuyin namin ang bawat isang View na may bilang v, na magsisimula sa 0 at ito ay maaaring madagdagan hanggang sa makamit ang konsensus.

​Tinutukoy namin ang bawat isang noda ng isang konsensus gamit ang isang numero, nagsisimula sa 0, ang huling noda ay may bilang na n − 1. sa bawat pag-ikot ng paggawa ng konsensus, may isang noda na gaganap bilang tagapagsalita ng bahay habang ang ibang mga noda ay maglalaro bilang mga kongressman. Ang numero ng tagapagsalita na p ay matutukoy sa pamamagitan ng sumusunod na algoritmo: Gayung din ang kasalukuyang taas ng bloke ay h, tapos ang 𝑝 = (ℎ − 𝑣) 𝑚𝑜𝑑 𝑛, ang halaga ni p ay magiging  0 ≤ 𝑝 < 𝑛 .

​Isang bagong bloke ang mabubuo sa bawat pag-ikot ng konsensus, na hindi bababa sa 𝑛 − 𝑓 na mga lagda galing sa mga noda ng bookkeeping. sa panahon ng pagkakabuo ng bloke, isang bagong pag-ikot ng paggawa ng knsensus ang magsisimula, na-irereset sa v=0.

###  Pangkalahatang Pamamaraan 

Itakda ang mga agwat ng oras ng paggawa ng bloke sa t, sa ilalim ng mga normal na pangyayari, ang algoritmo ay magpapatupad ng sumusunod na pamamaraan：

1) Ang pagpapahayag ng transaktsyon na datos ng noda sa panghalahatang network , na nakalakip ang lagda ng nagpadala;

2) Lahat ng mga noda na bookkeeping ay nagmomonitor ng mga datos ng transaksyon na namamahayag ng malaya at itinatago ang mga datos sa kanyang sariling memorya ayon sa pagkakabanggit; 

3) Pagkatapos ng oras t, ang tagapagsalita ay magpapadala ng 〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑞𝑢𝑒𝑠𝑡,ℎ,𝑣,𝑝,𝑏𝑙𝑜𝑐𝑘,〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑝</sub>〉； 

4) Matapos matanggap ang lahat ng  iminumungkahi, ang mga kongressman i ay magpapadala ng 〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑠𝑝𝑜𝑛𝑠𝑒,ℎ,𝑣,𝑖,〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑖</sub>〉 ;

​5) Kahit na anumang noda, sa panahon ng pagtanggap ng hindi bababa sa 𝑛 − 𝑓  〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑖</sub>, ay aabot sa isang konsensus at maglalathala ng isang buong bloke;

6) Kahit na anumang noda, matapos matanggap ang buong bloke, ay buburahin ang transaksyon nasa katanungan na galing sa kanyang memorya at magsisimula ng panibagong pag-ikot para sa konsensus;

Kinakailangan na, sa lahat ng mga noda ng konsensus, at hindi bababa sa  𝑛 − 𝑓 ng mga noda ang nasa orihinal na estado. Ito ay para sabihinna para sa laht ng nodang i, ang taas ng blokeng h and bilang ng View na v ay magkapareha. Ito ay hindi mahirap, pagkakapareho-pareho ng h ay maabot sa paraang ng  pagsisingkronisa ng mga bloke habang ang pagkakapare-pareha ng  v ay maaabot sa paraan ng pagbabago ng View. Ang pagsisingkronisa ng bloke ay hindi  sakop sa artikulong ito. Para sa pagbabago ng view, tingnan ang susunod na seksyon.

Ang mga noda, matapos mamonitor ang pagpapahayag at pagtatanggap ng mga iminumungkahi, ang magpapatunay ng mga transaksyon. Hindi sila pwedeng sumulat ng illegal na transaksyon sa memorya nang sa huli ay mailantad. Kung ang illegal na transaksyon ay nakapaloob sa iminumungkahi , ang ikot ng konsensus na iyon ay iaabandona at ang pagbabago sa View ay magsisimula agad. Ang pamamaraan ng pagpapatunay ang mga sumusunod:

1) Is the data format of the transaction consistent with the system rules? If no, the transaction is ruled illegal;

2) Is the transaction already in the blockchain? If yes, the transaction is ruled illegal;

3) Are all the contract scripts of the transaction correctly executed? If no, the transaction is ruled illegal;

4) Is there multiple-spend in the transaction? If yes, the transaction is ruled illegal;

5) If the transaction had not been ruled illegal in the above procedures, it will be ruled legal;

### View Change 

If, after 2<sup>𝑣+1</sup> ⋅ 𝑡 time interval, the nodes i cannot reach a consensus or should they receive proposals that contain illegal transactions, the View Change will take place: 

1) Given k=1, 𝑣<sub>𝑘</sub> = 𝑣 + 𝑘 ;

2) Nodes i send View Change request 〈𝐶ℎ𝑎𝑛𝑔𝑒𝑉𝑖𝑒𝑤,ℎ,𝑣,𝑖,𝑣<sub>𝑘</sub>〉 ;

3) Once any node receives at least 𝑛 − 𝑓  same v<sub>k</sub> from different i, the View Change is
completed. Set 𝑣 = 𝑣<sub>𝑘</sub> and the consensus making begins;

4) If, after 2<sup>𝑣+1</sup> ⋅ 𝑡 time interval, the View Change is not completed, the k will increase and back to step 2);

With the k increasing, the overtime waiting time will increase exponentially, so frequent View Change will be avoided and nodes are urged to reach consistency over v.

Before the completion of View Change, the original View v is still valid, so unnecessary View Change caused by occasional network latency can be avoided. 

### Flow Chart

![](~/assets/consensus_flowchart.jpg)

## Fault Tolerance Capacity 

​Our algorithm provides 𝑓 = ⌊ (𝑛−1) / 3 ⌋ fault tolerance to a consensus system that comprises n nodes. This tolerance capacity includes security and usability and is suite for any network environment.

Request data from nodes contain sender signatures, so malicious bookkeeping nodes cannot falsify requests. Instead, they will try to reverse the system status back to the past, forcing the system to fork.

Hypothetically, in the network environment of the system, consensus nodes are divided into 3 parts: 𝑅 = 𝑅1 ∪ 𝑅2 ∪ 𝐹 , and 𝑅1 ∩ 𝑅2 = ∅ , 𝑅1 ∩ 𝐹 = ∅ ，𝑅2 ∩ 𝐹 = ∅ . Also hypothetically,
both R1 and R2 are honest bookkeeping nodes in an information silo that they can only communicate with nodes in their set; F are all malicious nodes in coordination; moreover, the network condition of F allows them to communicate with any node, including R1 and R2.
If F wishes to fork the system, they have to reach consensus with R1 and publish blocks, and
then reach a second consensus without informing the R2, revoking the consensus with R1.
​To reach this, it is necessary that |𝑅1| + |𝐹| ≥ 𝑛 − 𝑓 and |𝑅2| + |𝐹| ≥ 𝑛 − 𝑓 .
In the worst case scenario, |𝐹| = 𝑓​ , i.e. the number of malicious nodes is at the maximum that the system could tolerate the aforementioned relation becomes |𝑅1| ≥ 𝑛 − 2𝑓​ and ​|𝑅2| ≥ 𝑛 − 2𝑓. Added together, |𝑅1| + |𝑅2| ≥ 2𝑛 − 4𝑓​, which could be simplified as ​𝑛 ≤ 3𝑓. Given that 𝑓 = ⌊ (𝑛−1) / 3 ⌋, which contradicts with the former, it can be proven that the system cannot be forked within the tolerance range. 

## Reference 

[1] Nakamoto S. Bitcoin: A peer-to-peer electronic cash system[J]. 2008. 

[2] Lamport L, Shostak R, Pease M. The Byzantine generals problem[J]. ACM Transactions on Programming Languages and Systems (TOPLAS), 1982, 4(3): 382-401. 

[3] Castro M, Liskov B. Practical Byzantine fault tolerance[C]//OSDI. 1999, 99: 173 186.

[4] Bracha G, Toueg S. Asynchronous consensus and broadcast protocols[J]. Journal of the ACM (JACM), 1985, 32(4): 824-840. 

[5] 范捷, 易乐天, 舒继武. 拜占庭系统技术研究综述[J]. 软件学报, 2013, 6: 012. 

