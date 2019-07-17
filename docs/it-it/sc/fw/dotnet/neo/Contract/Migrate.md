#  Metodo (byte[], byte[], byte, bool, string, string, string, string, string) Contract.Migrate

Migrare/rinnovare smart contract. Questo metodo è simile a `Contract.Create`, l'unica differenza è che questo metodo aggiunge la logica per la migrazione dell'archivio persistente privato. Quando viene eseguito, questo metodo migrerà tutti i **dati esistenti** dall'archivio permanente al nuovo contratto.

Se il contratto non utilizza l'archivio persistente, `Contract.Migrate` è funzionalmente lo stesso di `Contract.Create`.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Contract Migrate(byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string version, string author, string email, string description)
```

Parametri:

script: Il bytecode del contratto come un array di byte.

parameter_list: Elenco dei parametri come un array di byte. Fare riferimento a [Parametri Smart Contract e Valori Restituiti](../../../../tutorial/Parameter.md).

return_type: Restituisce il tipo come un byte. Fare riferimento a [Parametri Smart Contract e Valori Restituiti](../../../../tutorial/Parameter.md).

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
    public static void Main(byte[] signature)
    {
        if(VerifySignature(new byte[] { 2, 133, 234, 182, 95, 74, 1, 38, 228, 184, 91, 78, 93, 139, 126, 48, 58, 255, 126, 251, 54, 13, 89, 95, 46, 49, 137, 187, 144, 72, 122, 213, 170 }, signature))
          {
                    //This is the scripthash of the new contract
        byte[] script = new byte[] { 116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 0, 148, 140, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 108, 118, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 108, 117, 102 }; 
      
        byte[] parameter_list = { 2, 2 };
        byte return_type = 2;
        bool need_storage = true;
        string name = "AdditionContractExample";
        string version = "1";
        string author = "chris";
        string email = "chris@neo.org";
        string description = "DescriptionHere";
      
        Contract.Migrate(script, parameter_list, return_type, need_storage, name, version, author, email, description);
          }

    }
}
```



[Indietro](../Contract.md)
