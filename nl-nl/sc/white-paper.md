# NeoContract White Paper

## 1. Voorwoord

Smart contracts zijn computer programma's die automatisch de voorwaarden van een voorgeprogrammeerd contract kunnen uitvoeren. Het principe van een smart contract was als eerst bedacht door cryptograaf Nick Szabo in 1994; het idee van smart contracts is net zo oud als het internet. Echter, door gebrek aan een betrouwbare uitvoeringsomgeving zijn smart contracts nog nauwelijks in gebruik.

In 2008 werd Bitcoin vrijgegeven door iemand onder de schuilnaam Satoshi Nakamoto. Hij legde hiermee de grondvesting van de blockchain. In de Bitcoin-blockchain maakt Nakamoto gebruik van programmeertaal om gebruikers meer flexibiliteit te geven in het beheren van eigen accounts en het overmaken van middelen; dit is uiteindelijk de basis geworden voor een op de blockchain-gebaseerd smart contract-systeem.

In 2014 werd Ethereum vrijgegeven door Vitalik Buterin (toentertijd een tiener). Ethereum biedt een op de blockchain-gebaseerd, Turing-complete smart contract-systeem dat gebruikt kan worden om een reeks aan gedecentraliseerde blockchain-applicaties op te zetten.

De NEO blockchain is een platform voor digitaal bezit en applicaties, met daarbij een nieuw smart contract-systeem: NeoContract. Het NEO-platform biedt meerdere functies, zoals mogelijkheid voor digitaal bezit (digital assets) genaamd NeoAsset, en het aanmaken van een digitale identiteit, NeoID, waardoor gebruikers makkelijk kunnen deelnemen aan digitale zaken en niet langer beperkt zijn tot enkel het gebruik van de oorspronkelijke tokens op de blockchain (zoals bij Bitcoin).

Dit artikel zal kenmerken van NeoContract toelichten en niet-technische details uitleggen. Lees voor de technische documentatie [docs.neo.org](https://docs.neo.org).


## 2. Kenmerken

### 2.1 Zekerheid

Als een programma op meerdere computers draait, of op verschillende momenten op één computer, is het gedrag van het programma deterministisch als de zelfde input telkens de zelfde output geeft, en vica versa.

De blockchain is opslag en berekeningen op meerdere computers, waarbij de data in dit gedistribueerde systeem het resultaat is van betrouwbare berekeningen waar niet mee geknoeid kunnen worden. Smart contracts functioneren binnen het multi-node gedistribueerde blockchain-netwerk. Als een smart contract niet deterministisch is, kunnen de resultaten van nodes verschillen. Hierdoor kan een consensus niet worden bereikt en loopt het netwerk vast. Om deze reden is het bij het ontwerpen van een smart contract-systeem van belang om de kans op niet-deterministisch gedrag zo veel mogelijk te beperken.

#### 2.1.1 Tijd

Het lezen van de systeemtijd is een veelvoorkomende functie, welke veel wordt toegepast in bepaalde tijdsgevoelige contractprocedures. Het verkrijgen van de systeemtijd is echter niet deterministisch en het is moeilijk om een gelijke, exacte tijd in een gedistribueerd systeem te krijgen, aangezien de resultaten van de nodes zullen verschillen. NeoContract geeft een block-based system-call die de gehele blockchain als tijdstempel-server behandelt, waarbij de tijdstempel wordt verkregen elke keer dat een nieuw block wordt aangemaakt. Gemiddeld gezien wordt er elke 15 seconden een nieuw block aangemaakt, dus het contract draait grofweg even lang als het vorige block, plus-minus 15 seconden.

#### 2.1.2 Willekeur

Vele smart contract-programma's, zoals gokcontracten of spelletjes, maken gebruik van willekeurige getallen (random numbers). Aangezien random numbers echter ook niet deterministisch zijn, zal een system-call verschillende resultaten opleveren. In een gedistribueerd systeem kan dit op meerdere manieren worden opgelost: allereerst kan een gelijke random seed worden gebruikt voor alle nodes, waardoor de teruggegeven sequentie van de gehele willekeurige functie deterministisch is, maar deze methode maakt het willekeurige getal van tevoren bekend, waardoor deze in de praktijk nutteloos wordt. Een andere methode is om alle nodes samen te laten werken om willekeurige getallen te genereren. Dit kan mogelijk worden gemaakt m.b.v. cryptografische technieken, maar geeft laag vermogen en kost extra rekenkracht. Hiernaast kan er ook sprake zijn van een centrale nummergenerator die de willekeurige getallen genereert en uitzendt, maar het nadeel hiervan is overduidelijk: gebruikers moeten de gecentraliseerde nummergenerator volledig vertrouwen.

Binnen NEO zijn er twee manieren om een willekeurig getal te genereren:

1. Als een block wordt aangemaakt, bereikt de node consensus over een willekeurig getal en vult deze in het 'Nonce'-veld in van het nieuwe block. Contracten kunnen makkelijk het willekeurige getal verkrijgen door naar het 'Nonce'-veld te verwijzen.

2. Het contract-programma kan de hash-waarde van het block als random number generator gebruiken, aangezien de block-hash uit zichzelf tot op zekere hoogte willekeurig is. Hiermee is een matig willekeurig getal te krijgen.

#### 2.1.3 Databron

Als een programma live data verkrijgt, kan het een niet-deterministisch programma worden als de bron van de data niet-deterministische data verschaft. Bijvoorbeeld, bij het gebruiken van verschillende zoekmachines om de top 10 resultaten voor een bepaalde zoekterm te krijgen, kunnen de resultaten verschillen.

NEO levert voor smart contracts twee soorten deterministische databronnen:

1. **Blockchain Ledger**

  De contractprocedure kan alle data op de gehele blockchain gebruiken d.m.v. tussenliggende diensten, inclusief complete blocks, transacties en alle bijbehorende informatievelden. De data op de blocks zijn deterministisch en consistent, waardoor ze betrouwbaar gebruikt kunnen worden door smart contracts.

2. **Contract Opslag**
  
  Elk contract dat wordt geplaatst op het NEO netwerk heeft een eigen opslaggebied waartoe alleen het contract zelf toegang heeft. Het NEO consensus-mechanisme zorgt ervoor dat de opslagstatus van elke node in het netwerk consistent is.
  
Voor situaties waarin toegang tot niet-blockchain-data nodig is, geeft NEO niet een directe manier om toegang te hebben tot deze data. De data die niet op de blockchain staat, moet op de NEO blockchain worden gezet d.m.v. transacties en daaropvolgend vertaald worden tot een van de hierboven vermelde data-bronnen, alvorens smart contracts de data als bron kunnen gebruiken.

#### 2.1.4 Contract Call

Smart contracts in NeoContract kunnen elkaar aanroepen (call), maar kunnen niet recursief aangeroepen worden. Recursie (herhaling) kan binnen een contract wel plaatsvinden, maar het kan niet buiten de grenzen van het huidige contract treden. Daarnaast moet de call-relatie tussen contracten statisch zijn: het doelwitcontract kan niet pas bij het uitvoeren van het programma gespecificeerd worden. Hierdoor is het functioneren van het programma al deterministisch voordat het wordt uitgevoerd en kan de relatie met andere contracten volledig in kaart worden gebracht. Op de basis van dit systeem kunnen meerdere contracten worden gepartitioneerd om parallelle uitvoering mogelijk te maken.

### 2.2 Hoog Prestatievermogen

De uitvoerings-omgeving van een smart contract speelt een belangrijke rol in diens functioneren. Bij het analyseren van het presteren van een uitvoerings-omgeving zijn er twee indicatoren die het belangrijkst zijn:

1. De snelheid waarmee instructies worden uitgevoerd
2. De snelheid waarmee de uitvoerings-omgeving opstart

Voor smart contracts is vaak de omgeving waar het in wordt uitgevoerd belangrijker dan het optimaliseren van de instructies in het smart contract. Smart contracts zijn meer betrokken bij het input/output-deel; de instructies zijn makkelijk te optimaliseren. Echter, elke keer dat een smart contract wordt aangeroepen, moet er wel een nieuwe virtual machine worden opgestart. Daarom is de snelheid van de virtual machine zelf veel belangrijker voor het smart contract-systeem.

NEO maakt gebruik van een lichtgewicht NeoVM (NEO Virtual Machine) als primair uitvoeringscentrum voor smart contracts. Deze start zeer snel op en verbruikt weinig middelen, wat het ideaal maakt voor korte programma's zoals smart contracts. Als gebruik wordt gemaakt van een JIT (live compileerder) voor het cachen van belangrijke smart contracts, kan de efficiëntie van de virtual machines significant worden verhoogd.

### 2.3 Uitbreidbaarheid (Scalability)

#### 2.3.1 Hoge concurrency en dynamische partitioning

Bij het bespreken van de uitbreidbaarheid van een systeem, zijn twee hoofdzaken van belang: de verticale en horizontale uitbreidbaarheid. Verticaal duidt op de optimalisatie van de workflow van het uitvoeren van opdrachten, zodat optimaal gebruik wordt gemaakt van de middelen die beschikbaar zijn (zoals rekenkracht). Verticaal loop je snel tegen grenzen aan, aangezien de rekencapaciteit van een enkel apparaat processen slechts één voor één kan afhandelen. Idealiter wil je een systeem hebben dat het seriële systeem ombouwt tot parallel-werkend systeem (horizontale uitbreiding). Theoretisch gezien is het alleen nodig om de hoeveelheid verbonden apparaten te vergroten om praktisch eindeloze uitbreidbaarheid te behalen. Kan een blockchain programma's parallel uitvoeren?

De blockchain is een gedistribueerde ledger (grootboek) welke een reeks aan data bij houdt, inclusief de regels voor het aanpassen van deze data. Smart contracts worden gebruikt als dragers van deze regels. Blockchains kunnen programma's enkel parallel uitvoeren als meerdere smart contracts parallel (niet-sequentiëel) kunnen worden uitgevoerd. Simpel gezegd: als contracten niet onderling contact hebben, of als ze niet dezelfde data proberen aan te passen op het zelfde moment, is hun uitvoering niet-sequentiëel en kunnen ze tegelijk worden uitgevoerd. Als niet aan deze voorwaarden wordt voldaan, kunnen ze alleen in sequentie worden uitgevoerd en kan het netwerk niet horizontaal uitbreiden.

Aan de hand van de analyse hierboven kan 'onbeperkte uitbreidbaarheid' in smart contract-systemen makkelijk ontworpen worden. Het enige wat nodig is, is een set van simpele regels:

 * **Een smart contract mag alleen de staat van data aanpassen van het contract waar het onder valt**
 * **In een batch transacties (een block) kan een contract slechts éénmaal uitgevoerd worden**

Als resultaat kunnen de smart contracts parallel worden uitgevoerd, aangezien de volgorde niet uitmaakt. Echter, de eerste regel stelt dat contracten niet een beroep kunnen doen op elkaar. Elk contract is dan een geïsoleerd eiland. De tweede regel impliceert dat er slechts één transactie per block kan worden verhandeld als deze is gedistribueerd met een smart contract. Dit staat recht tegenover het oorspronkelijke idee achter smart contracts; van 'slimme contracten' is hier geen sprake meer. We willen niet alleen dat contracten elkaar kunnen oproepen, maar ook dat ze meermaals kunnen worden uitgevoerd in een block.

Gelukkig hebben smart contracts in NEO een statische call-relatie. Dit zorgt ervoor dat het gedrag van het programma van tevoren al te voorspellen is, inclusief call-relaties, voordat het wordt uitgevoerd. Voordat een contract wordt uitgevoerd, moet een contract expliciet aangeven welke contracten waarschijnlijk aangesproken zullen worden, zodat de uitvoeringsomgeving van tevoren al alle mogelijke relaties kan berekenen. Aan de hand van het resultaat van de 'call-tree' van elk contract, worden de smart contracts onderverdeeld in groepen. Contracten kunnen dezelfde data aanpassen en worden binnen een groep sequentiëel uitgevoerd, terwijl meerdere groepen parallel worden uitgevoerd.

#### 2.3.2 Lage graad van koppeling (coupling)

Coupling is de maat van afhankelijk tussen twee of meer entiteiten. NeoContract maakt gebruik van een opzet waarbij de mate van coupling zo laag mogelijk is. Hierdoor kunnen de meeste smart contract functies, nadat ze op de blockchain zijn gezet, makkelijk worden aangepast door middel van API's van services tussen de blockchain en de rest van de wereld.

## 3. Contract Gebruik

### 3.1 Contract Verificatie

In tegenstelling tot het public-key account-systeem van Bitcoin maakt NEO's account systeem gebruik van het contract-account-systeem. Elke account in NEO komt overeen met een verificatiecontract, waarbij de hash-waarde van het verificatiecontract het account-adres is.

Unlike the public-key account system used in Bitcoin, NEO's account system uses the contract account system. Each account in the NEO corresponds to a verification contract, and the hash value of the verification contract, is the account address; The program logic of the verification contract controls the ownership of the account. When transferring from an account, you firstly need to execute the verification contract for that account. A validation contract can accept a set of parameters (usually a digital signature or other criteria), and return a boolean value after verification, indicating the success of the verification to the system.

The user can deploy the verification contract to the blockchain beforehand, or publish the contract content directly in the transaction during the transfer process.

### 3.2 Contract Application

The application contract is triggered by a special transaction, which can access and modify the global state of the system, and the private state of the contract (storage area) at run time. For example, you can create a global digital asset in a contract, vote, save data, and even dynamically create a new contract, when the contract is running.

The execution of the application contract requires charging by instruction. When the transaction fee is consumed, the contract will fail and stop execution, and all state changes will be rolled back. The success of the contract does not affect the validity of the transaction.

### 3.3 Contract Function

The function contract is used to provide some public or commonly used functions, which can be called by other contracts. The smart contract code can be reused, so that developers are able to write increasingly complex business logic. Each function contract, when deployed, can choose to have a private storage area that is either read or written to data in a future contract, achieving state persistence.

The function contract must be pre-deployed to the chain to be invoked, and removed from the chain by a "self-destructing" system function, which will no longer be used and its private storage will be destroyed. The old contract data can be automatically migrated to another subcontract before it is destroyed, using contract migration tools.

## 4. Virtual Machine

### 4.1 Virtual Hardware

NeoVM provides a virtual hardware layer, to support the execution of smart contracts, including:

 * **CPU**

 CPU is responsible for reading and sequentially order the execution of instructions in the contract, according to the function of the instruction flow control, arithmetic operations, logic operations. The future of the CPU function can be extended, with the introduction of JIT (real-time compiler) function, thereby enhancing the efficiency instruction execution. 

 * **Call Stack**

   The call stack is used to hold the context information of the program execution at each function call, so that it can continue to execute in the current context after the function has finished executing and returning.

 * **Calculate Stack**

   All NeoVM run-time data are stored in the calculation stack, when after the implementation of different instructions, the stack will be calculated on the corresponding data elements of the operation. For example, when additional instructions are executed, the two operations participating in the addition are ejected from the calculation stack, and the result of the addition is pushed to the top of the stack. Function call parameters must also be calculated from right to left, according to the order of the stack. After the function is successfully executed, the top of the stack fetch-function returns the value.

 * **Spare Stack**

  When you need to schedule or rearrange elements in the stack, you can temporarily store the elements in the spare stack and retrieve them in the future.

### 4.2 Instruction set

NeoVM provides a set of simple, and practical instructions for building smart contract programs. According to functions, the main categories are as follows:

 * Constant instruction
 * Process control instruction
 * Stack operation instruction
 * String instruction
 * Logic instruction
 * Arithmetic operation instruction
 * Cryptographic instruction
 * Data operation instruction

It is worth noting that the NeoVM instruction set provides a series of cryptographic instructions, such as ECDSA, SHA and other algorithms to optimize the implementation efficiency of cryptographic algorithms in smart contracts. In addition, data manipulation instructions directly support arrays and complex data structures.

### 4.3 Interoperable service layer

The virtual machine where smart contract executes is a sandbox environment, that requires an interoperable service layer, in times when it needs to access data outside of the sandbox or to keep the run-time data persistent. Within the interoperable service layer, NEO contract can open a series of system function and services with the smart contract program, and these contracts can be called and accessed, like ordinary functions. All system functions are being conducted concurrently, so there is no need to worry about scalability.

### 4.4 Debugging Function	

Often, the development of smart contracts is very difficult, due to the lack of good debugging and testing methods. NeoVM provides program debugging support at the virtual machine level, where you can set the breakpoint on the contract code, or single-step, single-process execution. Thanks to the low coupling design between the virtual machine and the blockchain, it is easy to integrate NeoVM directly with various IDEs, to provide a test environment that is consistent with the final production environment.

## 5. High-level language

### 5.1 C#, VB.Net, F#

Developers can use NeoContract for almost any high-level language they are good at. The first batch of supported languages ​​are C #, VB.Net, F #, etc. We provide compilers and plug-ins for these languages, ​​allowing compilation of these high-level language into the instruction set, supported by NeoVM. As the compiler focus on MSIL (Microsoft intermediate language) during compilation, so theoretically, any. Net language can be translated into MSIL language, and become directly supported.

A huge number of developers are proficient in these languages, and the above languages have a very strong integrated development environment. Developers can develop, generate, test and debug, all within Visual Studio, where they are able to take full advantage of the smart contract development templates we provide, to gain a head start.

### 5.2 Java, Kotlin

Java and Kotlin ​​forms the second batch of supported languages, where we provide compilers and IDE plugins for these languages, ​​to help developers use the JVM-based language to develop NEO's Smart Contract applications.

Java is widely used, and Kotlin has recently become the official Google recommended, Android-development language. We believe that supporting these languages will help drastically increase the number of NEO smart contract developers.

### 5.3 Other Languages

Afterwards, NeoContract will add support for other high-level languages, based on the degree of difficulty, in the complier development process. Some of the languages that may be supported, include:

 * C, C++, GO
 * Python, JavaScript

In the future, we will continue to add more high-level language support. Our goal is to see more than 90% of NEO developers developing with NeoContract, without needing to learn a new language, and even possibly transfer existing business system code directly onto the blockchain.

## 6. Service	

### 6.1 Blockchain Ledger

NEO Smart Contracts can obtain complete block data for the NEO blockchain, including complete blocks and transactions, and each of their fields, at runtime, through the system functions provided by the interoperable service. Specifically, you can query these data:

 * Height of the blockchain
 * Block head, current block
 * Transactions
 * Type of transaction, attributes, input, output, etc.

Through these data, you can develop some interesting applications, such as automatic payouts, smart contracts based upon proof of workload.

### 6.2 Digital Assets

Through the interoperable services provided by the digital asset interface, smart contracts not only can query the NEO blockchain on properties and statistics of various digital assets, but also, create new digital assets during its run-time. Digital assets created by smart contracts can be issued, transferred, traded outside of the contract. They are the same as original assets on NEO, and can be managed with any NEO-compatible, wallet software. This specific interface includes:

 * Asset attribute inquiry
 * Asset statistics query
 * Asset life cycle management: create, modify, destroy, etc.
 * Asset management: multi-language name, total change, precision change, changes in the administrator

### 6.3 Persistence

Each smart contract program deployed on the NEO blockchain, will have a private storage area that can only be read and written by the contract itself. Smart contracts have full operational permissions on the data in its own store: can be read, written, modified, deleted. The data is stored in the form of key-value pairs and provides these interfaces:

 * Traverse all the records stored
 * Return to a specific record according to the specified key
 * Modify or write new records according to the specified key
 * Delete the record according to the specified key

In general, a contract can only read and write data from its own store, with one exception: when a contract is invoked, the invoked contract can access the caller's store through a cross-domain request, provided that the caller provides authorization. In addition, for a sub-contract that is dynamically created at the time of contract execution, the parent contract gets instant access to its store.

Cross-domain requests enable NeoContract to implement rich library capabilities, that provide highly scalable data management capabilities for the callers.

## 7. Fees

### 7.1 Deployment Fee

NEO's distributed architecture provides high redundancy of storage capacity, and the use of this capacity is not free. Deploying a smart contract on the NEO network requires a fee, currently fixed at 500GAS, which is collected by the system and recorded as a system gain. Future fees will be adjusted according to the actual operating cost in the system. The smart contract deployed on the blockchain can be used multiple times, until the contract is destroyed by the deployer.

### 7.2 Implementation Fee

NEO provides a credible execution environment for smart contracts, and the execution of contracts requires the consumption of computing resources for each node, therefore users are required to pay for the execution of smart contracts. The fee is determined by the computational resources consumed with each execution, and the unit price is also in GAS. If the implementation of the smart contract fails due to lack of GAS, the cost of consumption will not be returned, and this prevents malicious attacks on the network power consumption.

For most simple contracts, they can be executed for free, so long as the execution costs remain under 10 GAS, thus greatly reducing costs for the user. 

## 8. Application Scenarios

### 8.1 Superconducting Transactions

Digital assets on the blockchain inherently require some form of liquidity and usually point-to-point transactions cannot provide it sufficiently.  Therefore, there is a need for exchanges to provide users with trading services. Digital asset exchanges can be broadly divided into two categories:

1. **Central exchanges:** where the user needs to deposit the digital assets with the exchange, and subsequent place pending orders for trading, on the website
2. **Decentralized exchanges:** where its trading system is built into the blockchain, and the system provides the matching services.

Centralized exchanges can provide very high performance and diversified services, but need to have a strong credit guarantee, otherwise there will be moral hazards; such as misappropriation of user funds, fraud, etc. Comparatively, decentralized exchange has no moral hazard, but the user experience is poor, and there is greater performance bottleneck. Is there a way to combine both solutions and achieve the best of both worlds?

Superconducting transactions is a mechanism that can do this; Users do not need to deposit assets, where they are able to use their own assets on the blockchain in trading. Transaction settlement complete on the blockchain, but the process of matching orders occurs off-chain, by a central exchange that provides matching services. Since the matching is conducted off-chain, its efficiency is like centralized exchanges, but the assets remain under the control of the user. Exchanges uses the user's trading intent to carry out matching services, with no moral hazards involved, such as misappropriation of user funds, fraud, etc.

At present, within the NEO community, development of smart contracts to achieve blockchain superconducting transactions has emerged, such as OTCGO.

### 8.2 Smart Fund

Smart funds based on the blockchain have the benefit of being decentralized, open and transparent, possessing a higher degree of security and freedom as compared to traditional funds. These smart funds are also cross-border and open to investors worldwide, where outstanding projects can be funded with capital from all across the world.

Nest is a NeoContract-based smart fund project, which is very similar to the TheDAO project based on Ethereum, where improved security measures is needed to avoid the mistakes of TheDAO (hackers).

### 8.3 Cross-chain Interoperability

In the foreseeable future, there will be many public chains and thousands of alliance chains or private chains in existence worldwide. These isolated blockchain systems are islands of value and information, which are not interoperable with each other. Through the cross-chain interoperability mechanism, numerous isolated blockchains can be linked, so that the values in different blockchains can be exchanged with each other, to achieve the true value of the Internet.

NeoContract provides support for the implementation of cross-chain interoperability, ensuring consistency within cross-chain asset exchange, cross-chain distributed transactions, and execution of smart contracts on different blockchains.

### 8.4 Oracle Machines

The concept of oracles in folktale lies in the ability of a certain supernatural entity that can answer a particular set of questions. In the blockchain, oracle machines open the door to the outside world for smart contracts, making it possible for smart contracts to use real-world information as a condition for contract execution.

NeoContract does not provide the ability to directly access external data, such as access to resources on the Internet, because this will introduce non-deterministic behavior, resulting in inconsistencies between nodes during contract execution. Implementing the oracle machine in NeoContract requires that external data be sent to the blockchain by a trusted third party, integrating these data feeds as part of the blockchain ledger, thereby eliminating non-determinism.

The credible third party mentioned above, may be a person or institution that is co-trusted by both parties in the contract, or a decentralized data provider that is guaranteed by economic incentives. In this manner, NeoContract can be used in the implementation of such Oracle machines.

### 8.5 Ethereum DAPP

Bitcoin created the era of blockchains and electronic cash, and Ethereum created the era of smart contracts. Ethereum, the pioneers of smart contract on the blockchain, has made great contributions to the design idea, economic model and technological realization of a smart contract system. At the same time, the Ethereum platform has seen many DAPPs (distributed applications), where functionalities including: gambling agreements, digital assets, electronic gold, gaming platform, medical insurance, marriage platform, with widespread use over many industries. In theory, all of these DAPPs can be easily transplanted onto the NeoContract platform, as a NEO application.
