# Namespace Neo

El namespace `Neo` es la API proporcionada por la blockchain de Neo, esta facilita el acceso a los datos de la blockchain y la manipulación del almacenamiento persistente. Estas APIs están divididas en dos categorías:

  * API de sólo lectura: Los procedimientos de contrato pueden acceder a través de la API a toda la información de la cadena de bloques, incluyendo los bloques, transacciones, activos así como sus respectivos campos.

  * API de lectura/escritura. A través de estas APIs los contratos inteligentes pueden modificar el estado de los contratos, así como la lectura y escritura en áreas del almacenamiento persistente.

Nota: Las etiquetas `nueva` y `obsoleta` indican los cambios realizados en la versión 2.0 en relación a la 1.6.

## API de sólo lectura

Consulta de datos desde la API de la **Blockchain**:

| API | Descripción |
| ----------------------------------- | -------------------- |
| Neo.Blockchain.GetHeight | Obtiene el tamaño del bloque actual. |
| Neo.Blockchain.GetHeader | Busca la cabecera del bloque por su tamaño o su hash. |
| Neo.Blockchain.GetBlock | Busca bloques por su tamaño o su hash. |
| Neo.Blockchain.GetTransaction | Busca transaciones vía ID de transacción. |
| Neo.Blockchain.GetAccount | Obtiene una cuenta basada en el hash del script del contrato. |
| Neo.Blockchain.GetValidators | `nueva` Obtiene la clave pública de la persona de consenso. |
| Neo.Blockchain.GetAsset | Busca activos basados en un id. de activo. |
| Neo.Blockchain.GetContract | `nueva` Obtiene el contenido del contrato basado en un hash de contrato. |

API de la clase **Block**:

| API | Descripción |
| ----------------------------------- | -------------------------- |
| Neo.Header.GetHash | Obtiene el hash del bloque. |
| Neo.Header.GetVersion | Obtiene el número de versión del bloque. |
| Neo.Header.GetPrevHash | Obtiene el hash del bloque previo. |
| Neo.Header.GetMerkleRoot | Obtiene la raíz del árbol Merkle para todas las transacciones de ese bloque. |
| Neo.Header.GetTimestamp | Obtiene el timestamp del bloque.
| Neo.Header.GetConsensusData | Obtiene los datos de consenso del bloque. (consensus node-generated pseudo-random number) |
| Neo.Header.GetNextConsensus | Obtiene el valor hash para el siguiente contrato. |
| Neo.Block.GetTransactionCount | Obtiene el número de transacciones del bloque actual. |
| Neo.Block.GetTransactions | Obtiene todas las transacciones del bloque actual. |
| Neo.Block.GetTransaction | Obtiene la transacción especificada en el bloque actual. |

API de la clase **Transaction:**

| API | Descripción |
| ----------------------------------- | ---------------------------------------- |
| Neo.Transaction.GetHash | Obtiene el hash para la transacción actual.
| Neo.Transaction.GetType | Obtiene el tipo de la transacción actual. |
| Neo.Enrollment.GetPublicKey | `obsoleta` reemplazada por `Neo.Blockchain.GetValidators`. |
| Neo.Transaction.GetAttributes | Consulta todas las propiedades de la transacción actual. |
| Neo.Transaction.GetInputs | Consulta todas las transacciones para la transacción actual. |
| Neo.Transaction.GetOutputs | Consulta todas las salidas de la transacción actual. |
| Neo.Transaction.GetReferences | Consulta la transacción de salida referenciada por todas las entradas de la transacción actual. |
| Neo.Attribute.GetUsage | Obtiene datos adicionales de la transación. |
| Neo.Attribute.GetData | Obtiene datos adicionales de la transación. |
| Neo.Input.GetHash | La transación que hace referencia en la transación. |
| Neo.Input.GetIndex | Índice de la transacción referenciada en su lista de transacciones de salida. |
| Neo.Output.GetAssetId | Obtiene el ID del activo. |
| Neo.Output.GetValue | Obtiene el hash del script. |
| Neo.Output.GetScriptHash | Obtiene el total de la transacción. |

API de la clase **Account:**

| API | Descripción |
| ------------------------------- | ------------------ |
| Neo.Account.GetScriptHash | Obtiene el hash del script de la cuenta del contrato. |
| Neo.Account.GetVotes | Permite a terceros ver la información de votación para la cuenta del contrato. |
| Neo.Account.GetBalance | Obtiene el importe del activo de la cuenta dado un ID de activo. |

API de la clase **Asset:**

| API | Descripción |
| ---------------------------- | ------------------------------------- |
| Neo.Asset.GetAssetId | Obtiene el ID del activo. |
| Neo.Asset.GetAssetType | Obtiene la categoría del activo. |
| Neo.Asset.GetAmount | Obtiene el importe total del activo. |
| Neo.Asset.GetAvailable | Obtiene la cantidad de activo que ha sido emitido. |
| Neo.Asset.GetPrecision | Obtiene la precisión del activo (número mínimo de divisiones), el número de decimales después de la coma. |
| Neo.Asset.GetOwner | Obtiene el propietario del activo. (clave pública) |
| Neo.Asset.GetAdmin | Obtiene el administrador (dirección del contrato) del activo y el derecho a modificar sus atributos. (como el total, nombre, etc.) |
| Neo.Asset.GetIssuer | Obtiene el emisor (dirección del contrato) del activo y el derecho a emitir el activo. |

API de la clase **Contract:**

| API | Descripción |
| ---------------------------- | -------- |
| Neo.Contract.GetScript | Obtiene el script para el contrato. |

API de la clase **Storage:**

| API | Descripción |
| ---------------------------- | ------------------------------- |
| Neo.Storage.GetContext | `nueva` Obtiene el contexto de almacenamiento actual. |
| Neo.Storage.Get | operación de consulta en el área de almacenamiento persistente, obtiene el valor correspondiente a una consulta por su clave. |

## API de lectura/escritura

Este tipo de API modifica el estado del contrato inteligente.

| API | Descripción |
| -------------------------------------- | -------------------------------- |
| Neo.Blockchain.RegisterValidator | `nueva` Registrarse como contador. |
| Neo.Blockchain.CreateAsset | `nuevo` Registrar un activo. |
| Neo.Blockchain.CreateContract | `nuevo` Anuncia un contrato inteligente. |
| Neo.Account.SetVotes | Estable votos para la cuenta contrato a otras personas. |
| Neo.Asset.Renew | `nuevo` Renovación de activo. |
| Neo.Contract.Destroy | `nuevo` Destruye el contrato. |
| Neo.Storage.Put | Operación de inserción, inserta datos del tipo clave-valor dentro del área de almacenamiento persistente. |
| Neo.Storage.Delete | Operación de eliminación, elimina del área de almacenamiento persistente un valor dada su clave. |
