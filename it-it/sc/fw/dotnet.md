# Struttura Smart Contract .NET

Il .NET Framework è un'encapsulazione dell'API Smart Contract così che i programmatori .NET possano usare direttamente classi, metodi, e proprietà di .NET per interagire con l'API per poter ottenere i dati della blockchain, della memoria e così via.

## Metodi di Livello di Interoperabilità

Il namespace per il livello di interoperabilità è diviso in `Neo.SmartContract.Framework.Services.NEO` e `Neo.SmartContract.Framework.Services.System`. Clicca sui links per maggiori dettagli. 

| Namespace                  | descrizione                              |
| -------------------------- | ---------------------------------------- |
| [Neo](dotnet/neo.md)       | Il namespace di NEO è l'API fornita dalla blockchain NEO, fornisce un modo per accedere ai dati della blockchain e manipolare la memoria persistente. |
| [Sistema](dotnet/system.md) | Il namespace di Sistema è l'API fornita dallo Smart Contract Execution Engine (NeoVM), il quale fornisce accesso all'ambiente d'esecuzione. |

## Struttura dei Metodi

In aggiunta alla chiamata di metodi dal livello di interoperabilità, gli smart contract possono anche chiamare i metodi forniti dalla struttura. Questi metodi si trovano all'interno di `Neo.SmartContract.Framework` e possono essere cancellati direttamente dagli smart contract.

### Metodo Classe SmartContract

La classe `SmartContract` ci fornisce degli algoritmi di hash e metodi di firma.

|                                                        | Nome                                             | Descrizione                                                  |
| ------------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha1(byte[])                                     | Effettua l'hash dei byte in input usando SHA1                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha256(byte[])                                   | Effettua l'hash dei byte in input usando SHA256              |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash160(byte[])                                  | Effettua l'hash dei byte in input usando SHA256, seguito da RIPEMD160 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash256(byte[])                                  | Effettua l'hash dei byte in input doppiamente usando SHA256  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | VerifySignature(byte[] signature, byte[] pubkey) | Verifica la firma usando la data pubkey                      |

### Metodo di Assistenza per il Byte Array

Il metodi seguenti sono metodi di assistenza per array di byte forniti dalla struttura .NET Helper Class.

|                                          | nome                         | Descrizione                              |
| ---------------------------------------- | ---------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Concat(this byte[], byte[])  | Concatena 2 arrays di byte                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Range(this byte[], int, int) | Restituisce una porzione dell'array di byte, parametri: index, count |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Take(this byte[], int)       | Restituisce i byte X più a sinistra dall'array di byte，parametri: count |
