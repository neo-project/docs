# Consensus

## 1 - Gebruikte Termen

* **Proof of Stake** `PoS` - Een type algoritme waarbij gebruik wordt gemaakt van netwerk-consensus om om te gaan met fouttolerantie.

* **Proof of Work** `PoW` - Een type algoritme dat rekenkracht gebruikt om om te gaan met fouttolerantie.

* **Byzantine Fault** `BF` - Een fout waarbij een node functioneel blijft, maar op een onoprechte manier functioneert.

* **Delegated Byzantine Fault Tolerance** `DBFT` - Een consensus-algoritme, geïmplementeerd in de NEO blockchain, om gegarandeerd om te kunnen gaan met fouten.

* **View** `v` - De dataset welke wordt gebruikt tijdens consensus-activiteit in NEO `DBFT`.


## 2 - Rollen
**In het NEO consensus-algoritme worden Consensus Nodes verkozen door NEO-bezitters. Deze stemmen op de validiteit van transacties. Deze nodes worden soms ook 'Bookkeepers (boekhouders)' genoemd. Vanaf dit punt zullen ze worden genoemd als Consensus Nodes**.

  - <img style="vertical-align: middle" src="/assets/nNode.png" width="25"> **Consensus Node** - Deze node dingt mee in de consensus-activiteit. Tijdens consensus-activiteit wiselen consensus-nodes de volgende twee rollen af:
  - <img style="vertical-align: middle" src="/assets/speakerNode.png" width="25"> **Speaker (spreker)** `(Eén)` - De **Speaker** is verantwoordelijk voor het doorgeven van een block-voorstel aan het systeem.
  - <img style="vertical-align: middle" src="/assets/cNode.png" width="25"> **Delegate (afgevaardigde)** `(Meerdere)` - **Delegates** zijn verantwoordelijk voor het bereiken van een consensus m.b.t. de transactie.  
  
  
## 3 - Introductie

Een van de fundamentele verschillen tussen blockchains is hoe ze fouttolerantie (*fault tolerance*) kunnen garanderen bij defecte, niet-eerlijke activiteit op het netwerk.

Traditionele methodes gebruiken PoW en kunnen dit verschaffen zolang de meerderheid van de rekenkracht van het netwerk eerlijk is. Echter, door de rekenkracht-gerichte opbouw van dit model kan het mechanisme zeer inefficiënt zijn (rekenkracht kost energie en vereist geavanceerde hardware). Deze afhankelijkheid stelt een PoW-netwerk bloot aan een aantal limitaties, waarvan de voornaamste de kost van opschalen is.

NEO implementeert een Delegated Byzantine Fault Tolerance consensus-algoritme dat gebruik maakt van enkele PoS-achtige kenmerken (NEO-bezitters stemmen op **Consensus Nodes**), welke het netwerk beschermen van Byzantine faults terwijl ze gebruik maken van minimale middelen, maar zonder sommige van de problemen van PoS. Deze oplossing richt zich op de prestatie- en schalingsproblemen die worden geassocieerd met huidige blockchain-implementaties, zonder dat dit ten koste gaat van de fouttolerantie.


## 4 - Theorie

Het *Byzantine Generals Problem* is een klassiek probleem in gedistribueerde berekeningen. Het probleem definieert een aantal **Delegates** die gezamenlijk een consensus moeten bereiken over het resultaat van de aanvraag van een **Speaker**. In dit systeem moet voorzichtig worden gehandeld; het is mogelijk dat de **Speaker** oneerlijk is, of een of meer van de **Delegates**. Als een node oneerlijk is, kan deze inconsistente berichten sturen naar alle ontvangers. Dit wordt gezien als de meest desastreuze situatie. Als oplossing moeten de **Delegates** bepalen of de **Speaker** eerlijk is en wat de aanvraag was voor de totale groep.

Om te demonstreren hoe DBFT werkt, richt dit deel zich voornamelijk op het onderbouwen van de 66,66% consensus-ratio die wordt gebruikt in Sectie 5. Onthoud hierbij dat een 'oneerlijke' node niet per se bewust oneerlijk is; het is mogelijk dat de node simpelweg niet functioneert zoals men dat wil.

Hieronder volgt een aantal scenario's om DBFT te bespreken. In deze voorbeelden wordt aangenomen dat alle nodes het bericht doorsturen dat ze ontvangen van de **Speaker**. Dit komt overeen met het mechanisme van DBFT en is een belangrijk aspect van het systeem. Alleen het verschil tussen een functionerend en niet-functionerend systeem zal worden toegelicht; lees voor een meer uitgebreide uitleg de gebruikte bronnen.


### **Eerlijke Speaker**

  <p align="center"><img src="/assets/n3.png" width="300"><br>
	<b>Figuur 1:</b> Een n = 3 voorbeeld met een oneerlijke <b>Delegate</b>.
  </p>
  
  In **Figuur 1** is sprake van één eerlijke **Delegate** (50%). Beide **Delegates** ontvangen het zelfde bericht van de eerlijke **Speaker**. Aangezien een van de **Delegates** oneerlijk is, kan de eerlijke **Delegate** alleen vaststellen dat er een oneerlijke node is; het is voor de eerlijke **Delegate** echter onmogelijk om te bepalen of de **Speaker** of de **Delegate** eerlijk is. Hierdoor moet de eerlijke **Delegate** zich onthouden van een stem, waardoor de situatie verandert.
  
  <p align="center"><img src="/assets/n4.png" width="400"><br>
    <b>Figuur 2:</b> Een n = 4 voorbeeld met een oneerlijke <b>Delegate</b>.
  </p>
  
  In **Figuur 2** is sprake van twee eerlijke **Delegates** (66%). Alle **Delegates** ontvangen het zelfde bericht van de eerlijke **Speaker** en sturen het resultaat van hun bevestiging samen met het ontvangen bericht naar de andere **Delegates**. Gebaseerd op de consensus van de twee eerlijke **Delegates**, kunnen we vaststellen dat de **Speaker** óf de overgebleven **Delegate** oneerlijk is.
  
  
### **Oneerlijke Speaker** 
  
  <p align="center"><img src="/assets/g3.png" width="300"><br>
    <b>Figuur 3:</b> Een n = 3 voorbeeld met een oneerlijke <b>Speaker</b>.
  </p>
  
  In het geval van de situatie in **Figuur 3**, waar sprake is van een oneerlijke **Speaker**, is de uitkomst van de situatie gelijk aan die in **Figuur 1**; de **Delegates** kunnen niet bepalen welke node oneerlijk is.
  
  <p align="center"><img src="/assets/g4.png" width="400"><br>
    <b>Figuur 4:</b> Een n = 4 voorbeeld met een oneerlijke <b>Speaker</b>.
  </p>
  
  In het geval van de situatie in **Figuur 4** kunnen de blocks die zijn ontvangen door de middelste en rechter node niet bevestigd worden. Hierdoor kiezen de nodes voor een nieuwe **Speaker**, aangezien er dan wel sprake zou zijn van een 66%-meerderheid. Als in dit geval de oneerlijke **Speaker** exact gelijke (maar nog steeds oneerlijke) data naar alle drie de **Delegates** had gestuurd, dan zou deze gevalideerd zijn zonder dat er een nieuwe **Speaker** zou worden aangesteld.
  

## 5 - Praktische Implementatie

De praktische implementatie van DBFT in NEO maakt gebruik van een herhalende consensusmethode die garandeert dat een consensus wordt bereikt. Het presteren van het algoritme hangt af van het deel van eerlijke nodes in het systeem. **Figuur 5** toont het verwachte aantal maal dat het proces moet worden doorlopen om een consensus te bereiken als functie van het deel van de nodes dat oneerlijk is.

**Figuur 5** gaat niet tot onder de 66.66% **Consensus Node**-eerlijkheid. Tussen dit kritische punt en 33% **Consensus Node**-eerlijkheid bevindt zich een 'niemandsland' waar een consensus niet kan worden bereikt. Onder de 33.33% **Consensus Node**-eerlijkheid kunnen de oneerlijke nodes samen een consensus bereiken (ervan uitgaande dat ze samenwerken en dus gelijke valse informatie verspreiden), waardoor het bericht van de oneerlijke nodes als waarheid wordt aangenomen.

<img src="/assets/consensus.iterations.png" width="800">

**Figuur 5:** Monto-Carlo-Simulatie van het DBFT-algoritme dat het aantal herhalingen toont om consensus te bereiken als functie van de eerlijkheid van de nodes. {100 Nodes; 100,000 gesimuleerde blocks met een willekeurige selectie eerlijke nodes}


### 5.1 - Definities

**Binnen het algoritme worden de volgende definities aangehouden:**

  - `t` : de tijd die is toegewezen aan blockgeneratie, gemeten in seconden.
    - Op dit moment: `t = 15 seconden`
  - Deze waarde kan worden gebruikt om grofweg de duur van een herhaling van het algoritme te benaderen, aangezien de consensus-activiteit en -communicatie snel zijn ten opzichte van deze constante.
	
  - `n` : de hoeveelheid actieve **Consensus Nodes**.
  
  - `f` : de ondergrens van defecte **Consensus Nodes** binnnen het systeem. (*de f komt van 'faulty' = defect*)
    - `f = (n - 1) / 3`
    
  - `h` : de blockhoogte op het moment van de consensus-activiteit.
  
  - `i` : de **Consensus Node** index.
  
  - `v` : het beeld van een **Consensus Node**. Het beeld van een node bevat alle verzamelde informatie die de node heeft ontvangen tijdens een ronde van consensus-activiteit. Dit bevat ook de stem (`prepareResponse` of `ChangeView`) die wordt uitgezonden door alle **Delegates**. (*de v komt van 'view' = blik, beeld*)
  
  - `k` : de index van het beeld `v`. Een consensus-activiteit kan meerdere rondes vereisen. Wanneer consensus niet bereikt wordt, neemt `k` met 1 toe en wordt opnieuw geprobeerd tot een consensus te komen.
  
  - `p` : de index van de **Speaker Consensus Node**. Deze berekening rouleert door alle **Consensus Nodes** in het systeem om te voorkomen dat een node als 'dictator' in het systeem kan fungeren.
    - `p = (h - k) mod (n)`
  
  - `s` : de drempelwaarde voor veilige consensus. Onder deze waarde loopt het netwerk gevaar.
  	- `s = ((n - 1) - f)`
	

### 5.2 - Vereisten

**Binnen NEO zijn er drie primaire vereisten voor het behalen van consensus-fouttolerantie:**

1. `s` **Delegates** moeten tot een consensus komen m.b.t. een transactie voordat het block wordt vrijgegeven.

2. Oneerlijke **Consensus Nodes** moeten niet de mogelijkheid hebben de eerlijke nodes te overtuigen van oneerlijke transacties.

3. Op zijn minst `s` **Delegates** moeten in dezelfde status zijn (`h`,`k`) om consensus-activiteit te starten.

	
### 5.3 - Algoritme
**Het algoritme werkt als volgt:**

1. Een **Consensus Node** zendt een transactie met de signatures van de zender uit naar het gehele netwerk.

   <p align="center"><img src="/assets/consensus1.png" width="450"><br>
     <b>Figuur 6:</b> Een <b>Consensus Node</b> ontvangt een transactie en zendt deze uit naar het systeem. 
   </p>
     
2. De **Consensus Nodes** slaan de transactiedata op in de lokale opslag.

3. Het eerste beeld `v` van de consensus-activiteit wordt opgestart.

4. De **Speaker** wordt aangesteld.

  <p align="center"><img src="/assets/consensus2.png" width="450"><br>
		<b>Figuur 7:</b> Een <b>Speaker</b> is aangesteld en het beeld is bepaald.
	</p>
	
  **Wacht** `t` seconden.
	
5. De **Speaker** zendt het voorstel uit:


`<prepareRequest, h, k, p, bloc, [block]sigp>`
	<p align="center"><img src="/assets/consensus3.png" width="450"><br>
		<b>Figuur 8:</b> De <b>Speaker</b> maakt een block-voorstel wat beoordeeld dient te worden door de <b>Delegates</b>.
	</p>
	 
6. De **Delegates** ontvangen het voorstel en bevestigen:

	- Klopt het data-format volgens de regels van het systeem?
	- Is de transactie reeds op de blockchain?
	- Zijn de contract-scripts juist uitgevoerd?
	- Komen er geen dubbele uitgaven in voor?

- **If Validated Proposal Broadcast** (*bij goedkeuren*):
			`<prepareResponse, h, k, i, [block]sigi>`
	
- **If Invalidated Proposal Broadcast** (*bij afkeuren*):
			`<ChangeView, h,k,i,k+1>`
			
<p align="center"><img src="/assets/consensus4.png" width="500"><br>
	<b>Figuur 9:</b> De <b>Delegates</b> beoordelen het block-voorstel en reageren hierop.
</p>

7. Na het ontvangen van `s` aantal 'prepareResponse' uitzendingen, bereikt een **Delegate** een consensus en geeft het een block vrij.

8. De **Delegates** signeren het block als blijk van bevestiging.

<p align="center"><img src="/assets/consensus5.png" width="500"><br>
	<b>Figuur 10:</b> Een consensus is bereikt en de bevestigende <b>Delegates</b> ondertekenen het block, waardoor het in de blockchain wordt vastgelegd.
</p>
  
8. Als een **Consensus Node** een vol block ontvangt, wordt de data van het huidige beeld (`v`) verwijderd en begint een nieuwe ronde van de consensus-activiteit.
	- `k = 0`
 
--- 
  
**Opmerking:**
 
 - Als een node na (![timeout](/assets/consensus.timeout.png) ) seconden nog steeds op 1 beeld zit zonder consensus, dan zendt de node uit: </br>
		`<ChangeView, h,k,i,k+1>`
	
 - Op het moment dat een **Consensus Node** op zijn minst `s` aantal uitzendingen heeft ontvangen die bij het zelfde beeld horen, dan vergroot het de waarde `v` (beeld), waardoor een nieuwe ronde van consensus-activiteit begint.
	

## 6 - Bronnen
1. [A Byzantine Fault Tolerance Algorithm for Blockchain](https://www.neo.org/Files/A8A0E2.pdf)
2. [Practical Byzantine Fault Tolerance](http://pmg.csail.mit.edu/papers/osdi99.pdf)
3. [The Byzantine Generals Problem](https://www.microsoft.com/en-us/research/wp-content/uploads/2016/12/The-Byzantine-Generals-Problem.pdf)

