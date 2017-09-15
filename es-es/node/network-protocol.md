# Protocolo de red

NEO tiene una estructura de red punto-a-punto, donde cada nodo se comunica con otro a través del protocolo TCP/IP. En esta estructura existen dos tipos de nodos: Nodos pares y Nodos de validación (en ocasiones referidos como _Bookkeepers_ o nodos consenso). Los Nodos pares pueden transmitir, recibir y transferir transacciones o bloques, mientras que los nodos de validación pueden crear bloques.

El protocolo de red de NEO es muy similar al de Bitcoin, sin embargo, la estructura de datos como la de las transacciones son muy diferentes.

Convención
----------

1. Orden de los Bytes

Todos los tipos enteros de NEO son Little Endian excepto para la dirección IP y el número del puerto, estos dos son Big Endian.

2. Hash

NEO usa dos funciones hash diferentes: SHA256 y RIPEMD160. 

SHA256 se usa para generar un valor hash largo. RIPEMD160 para generar un valor hash corto. Normalmente obtenemos el valor hash de un objeto utilizando la función hash dos veces. Por ejemplo, usamos SHA256 dos veces cuando queremos generar el valor de hash del bloque o de la transacción. Al generar una dirección de contrato, utilizaremos la función SHA256 primero y luego usaremos RIPEMD160.

Además, el bloque también usará una estructura de hash llamada Merkle Tree. Calcula el hash de cada transacción y se combina entre sí, luego realiza el hash de nuevo, repitiendo este proceso hasta que haya sólo un hash raíz (Merkle Root).
 
3. Tipos de longitud variable

   + variant： entero de longitud variable, puede ser codificada para salvar espacio de acuerdo con el valor.

      |Valor|Longitud|Formato|
      |---|---|---|
      |< 0xfd|1|uint8|
      |<= 0xffff|3|0xfd + uint16|
      |<= 0xffffffff|5|0xfe + uint32|
      |> 0xffffffff|9|0xff + uint64|

   + varstr： cadena de longitud variable, compuesto por una variable entera seguida de una cadena. Cadena codificada en formato UTF8.

      |Tamaño|Campo|Tipo de Dato|Descripción|
      |---|---|---|---|
      |?|length|variant|The length of a string in bytes|
      |length|string|uint8[length]|string itself|

   + array： El array consiste en una varibla de longitud entera seguida de una secuencia de elementos.

1. Número de tamaño-fijo

   Datos en NEO como cantidad o precio son número de tamaño-fijo de 64 bits y la precisión decimal es 10<sup>-8</sup>，rango：[-2<sup>63</sup>/10<sup>8</sup>, +2<sup>63</sup>/10<sup>8</sup>)

Tipo de dato
------------

**Blockchain**

  La blockchain es un tipo de estructura lógica donde que está conectada en serie en una lista enlazada (linked list). Se utiliza para almacenar los datos de toda la red, como transacciones o activos.
      
**Block**

   |Tamaño|Campo|Tipo de Dato|Descripción|
   |---|---|---|---|
   |4|Version|uint32|version del bloque, actualmente 0|
   |32|PrevBlock|uint256|valor hash del bloque anterior|
   |32|MerkleRoot|uint256|hash raiz de una lista de transacción|
   |4|Timestamp|uint32|time-stamp|
   |4|Height|uint32|tamaño de bloque|
   |8|Nonce|uint64|número aleatorio|
   |20|NextMiner|uint160|Dirección del contrato del siguiente minero|
   |1|-|uint8|Fijada a valor 1|
   |?|Script|script|Script usado para validar el bloque|
   |?*?|Transactions|tx[]|Lista transacción|

   Cuando se calcula el valor hash del bloque, en lugar de calcular el bloque entero, sólo se calcularán los siete primeros campos de la cabecera del bloque, que son la versión, PrevBlock, MerkleRoot, timestamp, Height, el nonce, NextMiner. Dado que MerkleRoot ya contiene el valor hash de todas las transacciones, la modificación de transacción influirá en el valor hash del bloque.
 
   Estructura de datos de la cabecera del bloque

   |Tamaño|Campo|Tipo de Dato|Descripción|
   |---|---|---|---|
   |4|Version|uint32|version del bloque, actualmente 0|
   |32|PrevBlock|uint256|valor hash del bloque anterior|
   |32|MerkleRoot|uint256|hash raiz de una lista de transacion|
   |4|Timestamp|uint32|time-stamp|
   |4|Height|uint32|tamaño de bloque|
   |8|Nonce|uint64|número aleatorio|
   |20|NextMiner|uint160|Dirección del contrato del siguiente minero|
   |1|-|uint8|Fijada a valor 1|
   |?|Script|script|Script usado para validar el bloque|
   |1|-|uint8|Fijada a valor 0|
 
   El timestamp de cada bloque debe ser posterior al timestamp. Generalmente la diferencia del timestamp de dos bloques es de unos 15 segundos y la imprecisión está permitida. El tamaño del bloque debe ser exactamente igual al tamaño del bloque anterior más 1.

**Transacción**

   |Tamaño|Campo|Tipo de Dato|Descripción|
   |---|---|---|---|
   |1|Type|uint8|tipo de transación|
   |1|Version|uint8|versión Trading, actualmente 0|
   |?|-|-|Datos específicos de los tipos de transacción|
   |?*?|Attributes|tx_attr[]|Funciones adicionales de la transación|
   |34*?|Inputs|tx_in[]|entrada|
   |60*?|Outputs|tx_out[]|salida|
   |?*?|Scripts|script[]|Lista de scripts utilizados para validar la transacción|

   Todos los procesos en el sistema NEO están guardados en transacciones. Existen varios tipos de transacciones:

   |Valor|Nombre|Tarifa del sistema|Descripción|
   |---|---|---|---|
   |0x00|MinerTransaction|0|asigna una tarifa de byte|
   |0x01|IssueTransaction|500\|0|emisión de activos|
   |0x02|ClaimTransaction|0|assignar Neo Gas|
   |0x20|EnrollmentTransaction|1000|inscripción de un validador|
   |0x40|RegisterTransaction|10000|registrar activo|
   |0x80|ContractTransaction|0|Contrato de transacción|
   |0xd0|PublishTransaction|500 * n|(No usable) Transacciones especiales para contratos inteligentes|
   |0xd1|InvocationTransaction|0|Transacciones especiales para la llamada de contratos inteligentes|

Cada tipo de transacción, además del campo público, también tiene su propio campo exclusivo. A continuación se describen estos campos exclusivos en detalle.

   + MinerTransaction
     
   |Tamaño|Campo|Tipo de Dato|Descripción|
   |---|---|---|---|
   |4|Nonce|uint32|numero aleatorio|
  
La primera transacción en cada bloque debe ser MinerTransaction. Se utiliza para recompensar todas tarifas de transacción del bloque actual al validador. El número aleatorio es para evitar colisiones hash.
      
   + IssueTransaction

      No hay especial campo para un issue transaction.

Los gestores de activos pueden crear los activos que se han registrado en la cadena de bloque de NEO a través de IssueTransaction y los han enviado a cualquier dirección. En particular, si los activos que se emiten son NEOs la transacción será enviada gratis.
 
   + ClaimTransaction

      |Tamaño|Campo|Tipo de Dato|Descripción|
      |---|---|---|---|
      |34*?|Claims|tx_in[]|NEOs para la distribución|

   + EnrollmentTransaction

      |Tamaño|Campo|Tipo de Dato|Descripción|
      |---|---|---|---|
      |33|PublicKey|ec_point|clave publica del validador|

      La transacción representa un formulario de inscripción, que indica que el patrocinador de la transacción desea registrarse como validador. La forma de registrarse es: para construir una transacción del tipo EnrollmentTransaction y enviar un depósito a la dirección de la clave pública. La manera de cancelar el registro es: gastar el depósito en la dirección de la clave publica.
      
   + RegisterTransaction

      > [!Note]
      > Ha sido desactivada y reemplazada por Neo.Asset.Create para el contrato inteligente.
      > View [Alternative .NET Smart Contract Framework](../sc/fw/dotnet/Neo/Asset/Create.md)
      > View [Alternative Smart Contract API](../sc/api/Neo.md)

   + ContractTransaction

      No hay atributos especiales para una transacción de contrato. Este es un tipo de transacción muy común ya que permite que un monedero envíe NEO a otro. Los campos de transacción `inputs` y` outputs` serán importantes para esta transacción (por ejemplo, para controlar cuánto NEO será enviado y a qué dirección).

   + PublishTransaction

      > [!Note]
      > Ha sido desactivda y reemplazada por Neo.Contract.Create para el contrato inteligente.
      > Consultar [Alternative .NET Smart Contract Framework](../sc/fw/dotnet/Neo/Contract/Create.md)
      > Consultar [Alternative Smart Contract API](../sc/api/Neo.md)

   + Invocar una transacción

      | Tamaño | Campo | Tipo de dato | Descripción |
      | ---- | ------ | ------- | --------------- |
      | -    | -      | -       | Campos publicos para transaciones       |
      | ?    | Script | uint8[] | Invocar por contrato inteligente     |
      | 8    | Gas    | int64   | Coste en NeoGas necesario para ejecutar un contrato inteligente |
      | -    | -      | -       | Campo publicos para transaciones         |

1. Atributor de una transacción

   | Tamaño | Campo | Tipo de dato | Descripción |
   |---|---|---|---|
   |1|Usage|uint8|uso|
   |0\|1|length|uint8|longitud de dato(Especificos circustancias será omitido)|
   |length|Data|uint8[length]|datos externos|

   A veces la transacción contendrá algunos datos para uso externo, estos datos se colocarán en el campo atributos de la transacción.

   Cada atributo de transacción tiene diferentes usos:

   |Valor|Nombre|Descripción|
   |---|---|---|
   |0x00|ContractHash|valor hash del contrato|
   |0x02-0x03|ECDH02-ECDH03|clave pública intercambio de clave ECDH|
   |0x20|Script|Validación adicional de transacciones|
   |0x30|Vote|Para votar|
   |0x80|CertUrl|dirección url del certificado|
   |0x81|DescriptionUrl|dirección url de la descripción|
   |0x90|Description|breve descripción|
   |0xa1-0xaf|Hash1-Hash15|usado para almacenar valores hash personalizados|
   |0xf0-0xff|Remark-Remark15|notas|

   Para ContractHash, ECDH series, Hash series, la longitud de datos está fijada a 32 bytes y la longitud del campo omitida;
   Para CertUrl, DescriptionUrl, Description, Remark series, la longitud de datos debe estar bien definida, esta longitud no deberá exceder 255;

1. Entrada de la transacción

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |32|PrevHash|uint256|hash de la anterior transación|
   |2|PrevIndex|uint16|indice de la transación anterior|

1. Salida de la transacción

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |32|AssetId|uint256|id del activo|
   |8|Value|int64|valor|
   |20|ScriptHash|uint160|direción del remitente|

   Cada transacción podría tener salidas hasta 65536.

1. Script de validación

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |?|StackScript|uint8[]|codigo script pila|
   |?|RedeemScript|uint8[]|codigo script contracto|

  Script de pila sólo se puede utilizar para las operaciones PUSH, se utiliza para subir firmas en la pila. El intérprete de scripts ejecutará primero el código de comandos de pila y, a continuación, ejecutará el código de comandos de contrato.

En una transacción, el valor hash del código de script de contrato debe ser coherente con la salida de la transacción, que es parte de la validación. En la siguiente sección se detalla el proceso de ejecución en detalle.
 

Mensaje de red
--------------

Todos los mensajes de red usan esta estructura:

|Tamaño|Campo|Tipo de dato|Descripción|
|---|---|---|---|
|4|Magic|uint32|id de protocolo|
|12|Command|char[12]|comando|
|4|length|uint32|longitud de payload|
|4|Checksum|uint32|checksum|
|length|Payload|uint8[length]|contenido del mensajes|

Definición del numero magico:

|Valor|Descripcion|
|---|---|
|0x00746e41|producción|
|0x74746e41|test|

Comando es en formato UTF8, donde la longitud es 12 bytes y la parte que queda se llena con 0
Checksum son los 4 priemros bytes de dos veces el hash SHA256 del payload.

Dependiendo del tipo de ordernes el payload tiene diferente formato, ver a continuación:

1. version

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |4|Version|uint32|version del protocolo, 0 de momento|
   |8|Services|uint64|el servicio que proporciona el nodo es actualmente 1|
   |4|Timestamp|uint32|hora actual|
   |2|Port|uint16|puerto que el servidor está escuchado, 0 si no se usa.|
   |4|Nonce|uint32|usado para distinguir la ip pública del nodo|
   |?|UserAgent|varstr|id del cliente|
   |4|StartHeight|uint32|tamaño de blockchain|
   |1|Relay|bool|recibir o enviar

   Cuando un nodo recibe una petición de conexión, declara su versión inmediatamente. No habrá otra comunicación hasta que ambas partes obtengan versiones entre sí.

1. verack

   Cuando un nodo recibe el mensaje de versión, responde con un 'verack' como respuesta inmediatamente. Este mensaje no tiene payload.

1. getaddr

   Hacer peticiones a un nodo para recibir los nodos activos y así aumentar el numero de conexiones. Este mensaje no tiene payload.

  
1. addr

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |30*?|AddressList|net_addr[]|la dirección de otros nodos en la red|

   Despues de recibir el mensaje getaddr, el nodo devuelve un 'addr message' como respueta y proporciona información sobre los nodos conocidos en la red.
   
    
1. getheaders

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|hash del primer bloque que el nodo solicita|
   |32|HashStop|uint256|hash del último bloque que el nodo solicita|

   Realizar peticiones a un nodo de como máximo 2000 bloques de cabecera que contiene de HashStart hasta HashStop. Para obtener el bloque hash después de eso, necesita volver a enviar el mensaje getheaders. Este mensaje se utiliza para descargar rápidamente la blockchain que no contiene las transacciones.


1. headers

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |?*?|Headers|header[]|cabecera del bloque|

   Después de recibir el mensaje getheaders, el nodo devuelve un mensaje la cabecer del mensajes como respuesta y proporciona información sobre los nodos conocidos en la red.
   
1. getblocks

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|hash del primer bloque que el nodo solicita|
   |32|HashStop|uint256|hash del último bloque que el nodo solicita|

   Realiza peticiones a un nodo para el mensaje inv que comienza desde HashStart hasta HashStop. El número de bloques que comienza desde HashStart a HashStop es de hasta 500. Si desea obtener más bloques de hash tienes que reenviar el mensaje.
   
1. inv

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|data de invetario|

   El nodo puede transmitir la información de objeto que posee mediante este mensaje. El mensaje se puede enviar automáticamente o se puede utilizar para responder a los mensajes getbloks.
   
   La información del objeto está incluida en la lista:
   
   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |4|Type|uint32|tipo de objecto|
   |32|Hash|uint256|hash de objecto|

   Tipo de objetos:

   |Valor|Nombre|Descripción|
   |---|---|---|
   |0x01|TX|transación|
   |0x02|Block|bloque|
   |0xe0|Consensus|data consenso|

1. getdata

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|data de invetario|

   Para solicitar un objeto especificado desde un nodo: Normalmente se envía después de que se recibe el paquete inv y se elimina el elemento conocido.
   
1. block

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |?|Block|block|bloque|

   Enviar un bloque a un nodo para responder al mensaje getdata.

1. tx

   |Tamaño|Campo|Tipo de dato|Descripción|
   |---|---|---|---|
   |?|Transaction|tx|transacción|

   Enviar una transacción a un nodo para responder al mensaje getdata.
   
   |Tamaño|Campo|Tipo de dato|Descripción|
   |----|---------|--------- |----------------- |
   |32 *?|HashStart|uint256[]|nodo conocido como ultimo bloque hash|
   |32|hashStop|uint256|solicite el ultimo bloque hash|
