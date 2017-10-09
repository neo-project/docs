# NEO smart contract Handleiding

Na het volgen van de voorafgaande tutorials zou je nu in staat moeten zijn een smart contract project aan te maken m.b.v. C# in Visual Studio. Hieronder volgt een uitleg hoe smart contracts worden uitgevoerd door de NeoVM (Neo Virtual Machine).

## Smart contract triggers

Er zijn twee manieren om smart contracts te triggeren:

1. Contract User Authentication: hierbij is het smart contract een contract-account. Wanneer de gebruiker aanvraagt om de contract-account te gebruiken bij een asset, dan wordt het smart-contract getriggerd.

2. Stuur handmatig een transaction call Smart contract: hierbij stuurt de gebruiker een transactie (*Invocation Transaction*) om de implementatie van een smart contract te triggeren.

## Types smart contract

Er zijn twee basis-classes waar smart contracts op gebaseerd kunnen zijn (*inherit*): FunctionCode en VerificationCode.

### Een smart contract gebaseerd op FunctionCode

Een smart contract dat gebaseerd is op FunctionCode kan worden gecompileerd en gedistribueerd naar de blockchain voor gebruik door anderen. Het staat gelijk aan een 'function' in programmeren, welke opgeroepen kan worden door de 'main function' (één van de twee trigger-methodes die hierboven staan beschreven) en door 'other functions' (andere smart contracts die gebaseerd zijn op FunctionCode).

De `entry point` voor de smart contract die gebaseerd is op FunctionCode is de `Main` methode. De waarde van `return` kan `void`, `int` of `byte` zijn. Deze pagina licht bovenstaande code toe.

Hier is een voorbeeldcontract dat gebaseerd is op FunctionCode:

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Let op: de methode met Hoofdletter
    {
        // Het Smart Contract dat gebaseerd is op FunctionCode kan gecompileerd worden en op de blockchain geplaatst worden om door anderen gebruikt te worden
    }
}
```

### Een smart contract gebaseerd op VerificationCode

Een smart contract dat gebaseerd is op VerificationCode kan een contract-adres genereren in de wallet-client. Het smart contract kan worden getriggerd als de gebruiker een asset in het contract-adres wil gebruiken (een transactie).

Als het contract als antwoord `true` geeft, is de bevestiging gelukt en kan de gebruiker de asset uitgeven. Als het contract als antwoord `false` geeft, is de bevestiging mislukt en kan de gebruiker de asset niet spenderen. De mislukte transactie kan niet worden uitgezonden en zal niet worden bevestigd.

Hier is een voorbeeld van een smart contract dat gebaseerd is op VerificationCode. De Verify methode moet als type reactie `bool` hebben.

```c#
public class Contract1: VerificationCode
{
    public static bool Verify () //Hier wordt de return type genoemd (bool)
    {
        return true;
    }
}
```

## NeoVM

**NeoVM** is de virtual machine die de NEO smart contract-code uitvoert. Dit is niet een volledige VM zoals Vmware of Hypter-V, maar een die puur op smart contracts is gericht.

Bijvoorbeeld: in de Java JVM of .NET CLR wordt de broncode gecompileerd tot de bijbehorende bytecode, en vervolgens uitgevoerd op de juiste virtual machine. JVM of CLR voert de bytecode uit, wat lijkt op het uitvoeren van instructies op een fysieke machine (de bijbehorende binaire instructies worden uiteraard nog steeds uitgevoerd op een fysieke machine). De fysieke machine haalt informatie uit de opslag, verplaatst het naar de CPU via de geheugenbus, waarna de data gedecodeerd en uitgevoerd wordt en het resultaat wordt opgeslagen.

### Virtual machine Opbouw

   ![](/assets/neo-vm.jpg)

Het bovenstaande diagram is de systeemarchitectuur van de Neo Virtual Machine (NeoVM), waarbij het middelste omlijnde gebied de kern van de virtual machine is.

#### Execution engine

Het groene gebied aan de linkerkant is de virtual machine execution engine (de 'CPU' van het systeem). Deze voert veelvoorkomende instructies uit zoals flow control, stack operations, bit operations, arithmetische operations, logical operations, cryptographische methodes et cetera. Deze vereist een service layer waarmee interactie kan worden aangegaan (zie hieronder).

#### Evaluation Stack

Het middelste, grijze gedeelte is de virtual machine computing stack (het 'geheugen' van het systeem). Dit kan op basis van de stack of op basis van het register; beide manieren hebben voor- en nadelen. Op de stack-gebaseerde virtual machines kunnen werken met JVM, Python en .NET CLR. Op het register-gebaseerde VM's bestaan ook, zoals Dalvik en Lua5.0. Op de stack-gebaseerde VM's maken het mogelijk om direct aanpassingen te maken in de blockchain tijdens het uitvoeren van opdrachten.

Aangezien de standaard methode is om data vanuit de operand stack uit te voeren, is het niet nodig om een operand te definiëren. Bijvoorbeeld: Normaal gesproken moet je bij x86 assembly "ADD EAX, EBX" aangeven ....... Bij op de stack-gebaseerde VM-instructies is het echter niet nodig deze parameters te specificeren. 

<!--NL: vertaald a.d.h.v. onderstaande stuk, erg gebroken Engels. Kan iemand anders hier wijs uit worden?
    EN: translated from the bit below; it's unclear to me what exactly is meant with this, can someone take a look at this?
The middle part of the gray is the virtual machine computing stack (equivalent to memory), and now the virtual machine to achieve two ways, based on the stack and based on the register, the two ways to achieve their own advantages and disadvantages, but also have the iconic product. Stack-based virtual machines with JVM, CPython, and .Net CLR. Register-based VMs also exist such as Dalvik and Lua5.0. Stack-based virtual machines have a stack stack concept that allows virtual machines to interact directly with the stack when performing real operations.
-
Since the default is to fetch data from the operand stack, there is no need to specify an operand. For example, x86 assembly "ADD EAX, EBX", you need to specify where the operation from the need to take the operation, where the results stored in the implementation. But stack-based virtual machine instructions do not need to specify these parameters. For example, to add a simple operation the default operands are stored in the operand stack, and we can pop out two data directly from the stack to do addition.
-->

#### Interoperable service layer

Het blauwe gedeelte aan de rechterzijde is de interoperable service layer van de VM (de 'randapparatuur' van de VM). Momenteel geeft de interoperable service layer (ISL) enkele API's om de blockchaindata van een smart contract te beheren, welke blockchain-informatie, transactie-informatie, contractinformatie, asset-informatie et cetera kan beheren.

Daarnaast maakt de ISL ook langdurige opslag voor elk contract mogelijk. Elk smart contract kan optioneel worden opgeslagen op eigen opslag door een key en waarde op te slaan. 

<!--NL: ook dit stuk is vaag.
    EN: this part is unclear as well
In addition, the interoperable service layer also provides a persistent storage area for each contract. Each of the smart contracts is optionally created with private storage, which is in the form of a key-value object determined by the callee of the contract, rather than the context of the persistent store. Of course, the caller needs to pass their own storage context to the callee (that is, to complete the authorization), the caller can perform read and write operations.
-->

### Servicekosten

Om een smart contract op de blockchain te plaatsen, moeten er deployment-kosten worden betaald (momenteel 500 GAS). Bij het uitvoeren van de smart contract moet de gebruiker eventueel servicekosten betalen (momenteel gratis).

## Een eenvoudige smart contract

Hieronder volgt de eenvoudige code van het smart contract voor VerificationCode:

```c#
public static bool Verify ()
{
    return true;
}
```

Hier is het resultaat altijd `true`, wat betekent dat iedereen het contract-adres van de assets kan uitgeven (vergelijkbaar met het uitgeven van geld).

<!--NL: idem dito
    EN: this part as well
There is a function of deleting an asset in the client's e-wallet client. When you delete an asset, the asset is sent to a specified address, which is the contract address generated by the above smart contract, and anyone can spend the address In the assets, of course, the address of the assets are other people do not want the assets.
-->
```c#
public static bool Verify ()
{
    return false
}
```

Hier is het resultaat altijd `false`, wat betekent dat de assets van dit contract niet gebruikt kunnen worden, bijvoorbeeld wanneer een hoeveelheid van een asset is vernietigd door een bedrijf.

<!--same
The return value of the contract is always false, indicating that the assets of this contract can not be used (can be understood as burn or destroy an asset), such as which can store some of the shares of the company has been canceled.
-->

Bekijk voor meer voorbeelden:

[Hello World](tutorial/HelloWorld.md)

[Lock (lock)](tutorial/lock.md)

[Domain (Domain Name System)](tutorial/Domain.md)
