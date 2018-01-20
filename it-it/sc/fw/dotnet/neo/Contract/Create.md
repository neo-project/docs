# Metodo (byte[], byte[], byte, bool, string, string, string, string, string) Contract.Create 

Richiamare questo metodo in uno smart contract pubblicherà un nuovo contratto.

Questo è il rimpiazzo per PublishTransaction nella versione 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Contract CreateContract(byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string version, string author, string email, string description)
```

Parametri:

script: Il bytecode del contratto come un array di byte.

parameter_list: Elenco dei parametri come un array di byte. Fare riferimento a [Parametri di Smart Contract e Valori Restituiti](../../../../tutorial/Parameter.md).

return_type: Restituisce il tipo come un byte. Fare riferimento a [Parametri di Smart Contract e Valori Restituiti](../../../../tutorial/Parameter.md).

need_storage: Se il contratto richiede una memoria persistente, boolean.

name: Il nome del contratto come una stringa.

version: La versione come una stringa.

author: Il nome dell'autore come una stringa.

email: L'email dell'autore come una stringa.

description: La descrizione del contratto come una stringa.

Valore restituito: [Contratto](../Contract.md).

## Esempio

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        //This is the new contract as bytecode
        byte[] script = new byte[] { 116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 0, 148, 140, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 108, 118, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 108, 117, 102 }; 
      
        byte[] parameter_list = { 2, 2 };
        byte return_type = 2;
        bool need_storage = false;
        string name = "AdditionContractExample";
        string version = "1";
        string author = "chris";
        string email = "chris@abc.com";
        string description = "This is an Addition Contract. It takes in 2 inputs, adds them and returns the result.";
      
        Blockchain.CreateContract(script, parameter_list, return_type, need_storage, name, version, author, email, description);
    }
}
```



[Indietro](../Contract.md)
