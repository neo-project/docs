# Migration from Neo Legacy to Neo N3

This tutorial is intended to guide exchange developers in migrating the global assets NEO/GAS/nNEO/cGAS on the Neo Legacy chain to the Neo N3 chain via transfer transactions.

## Migration process flow

1. On Neo Legacy side, the user sends a transfer transaction (Invocation Transaction/Contracttransaction) to the specific address `ANeo2toNeo3MigrationAddressxwPB2Hz` (`AJ36ZCpMhiHYMdMAUaP7i1i9pJz4jMdiQV` for test net) placing the N3 standard address in `attribute` of the transaction using the key **Remark14**. 

   The code demos in multi-languages are provided for your reference: [Demos](https://github.com/neo-ngd/sdkDemo)

   > [!Caution]
   >
   > Before sending the transaction, ensure that your transaction meets all the following requirements, otherwise it would not be processed and your assets sent out would be lost!
   >
   > - The N3 address in the transaction is valid and only one Remark14 in `attribute`.
   > - For migration asset amount equal to or more than 10 NEO or 20 GAS it is free. If you are migrating less than that amount, you have to attach **1 GAS as network fee**. 
   > - One transaction can only include one kind of asset for migration except GAS for network fee payment. 

   > [!Note]
   >
   > Migrating the decimal part of nNEO is not supported. The migration amount will be rounded down when distributing nNEO on N3 blockchain. 

2. We will scan all the Neo legacy transactions sent to the specific address and sends the corresponding amount of NEO/GAS token to the N3 address at regular intervals (up to one business day) only if the transaction is valid.

## See also

- [Asset Contract Hashes](https://github.com/neo-ngd/sdkDemo/blob/master/contracthash.md)
- [Guideline on Migration Page](migration-guide.md)
