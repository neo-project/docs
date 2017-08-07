# Namespace Neo

El namespace Neo es la API proporcionada por la blockchain de NEO. Facilita el acceso a los datos de la blockchain y la manipulación del almacenamiento persistente. Estas APIs están divididas en dos categorías.

1. Bloques de la blockchain. ELos procedimientos de contrato pueden acceder a toda la información de la cadena de bloques, incluyendo los bloques, transacciones, activos así como sus respectivos campos.

2. Area de almacenamiento persistente. Cada contrato desplegado en NEO tiene un espacio de almacenamiento al que sólo se puede acceder desde el propio contrato y puede ser usado para acceder a los datos del contrato.

Nota: Las etiquetas `nueva` y `obsoleta` indican los cambios realizados en la versión 2.0 en relación a la 1.6.

## clase

| | Clase | Descripción |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Account](neo/Account.md)          | Proporciona una forma de consultar el saldo.      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Asset](neo/Asset.md)              | Usada para representar los datos de la estructura de un activo.        |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Block](neo/Block.md)              | La clase que representa un bloque que proporciona una forma de consultar transacciones en el bloque consultado.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Blockchain](neo/Blockchain.md)    | Proporciona un conjunto de métodos para acceder a los datos de la blockchain. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Contract](neo/Contract.md)        | Un contrato que representa un contrato.                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Enrollment](neo/Enrollment.md)    | `nueva` Usada para indicar la estructura de datos de la transacción de registro de un registrante. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Header](neo/Header.md)            | Usada para representar la estructura de datos de un encabezado de bloque.          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Storage](neo/Storage.md)          | Facilita la inserción, consulta y eliminación en el almacenamiento persistente.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [StorageContex](neo/StorageContex.md) | `nueva` La clase usada para representar el contexto del almacenamiento privado.  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [Transaction](neo/Transaction.md)  |  La clase base usada para representar una transacción.           |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionAttribute](neo/TransactionAttribute.md) | La estructura de datos usada para representar una transacción.         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionInput](neo/TransactionInput.md) | La estructura de datos usada para representar una transacción entrante.        |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC29808.jpeg) | [TransactionOutput](neo/TransactionOutput.md) | La estructura de datos usada para representar una transacción saliente. |

## enumeración

|  | Enumeración | Descripción |
| ---------------------------------------- | ---------------------------------------- | ----------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [StorageContex](neo/StorageContex2.md) | `Obsoleta` is used to represent private storage area (" x ") Storage context enumeration
