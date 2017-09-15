# Referencia de la línea de comandos (CLI)

Desde la línea de comandos, ir al directorio donde se encuentra el cliente `NEO-cli` e introduce el siguiente comando:

`dotnet neo-cli.dll`


<img style="vertical-align: middle" src="assets/cli/cli_1.png">

> [!Note] Para ejecutar el cliente CLI `NEO-cli` requiere la instalación de [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime),  **versión 1.1.2** o superior.

Una vez ejecutado aparecerá el interprete de comandos de NEO, desde aquí puedes manipular el monedero con comandos permitiendote: crear o abrir un monedero, importar o exportar la clave privada, tranferir, reclamar gas, comenzar un consenso, etc.

Exploraremos primero los distintos comandos disponibles en la línea de comandos. Introduce `help` seguido de enter y aparecerá la siguiente lista:

<img style="vertical-align: middle" src="/assets/cli_2.png">

Los paréntesis `<>` es el parámetro. <br>
Los corchetes `[]` son parámetros opcionales. <br>
El símbolo `|` es información a completar de cualquier tipo. <br>
El signo igual `=` indica el valor por defecto cuando se ejecuta el comando sin parámetros. <br>

A continuación una descripción de todos los comandos:

## 1. Intrucciones de la consola

| Comando      | Descripción de la función      |
| ------- | --------- |
| version | Muestra la versión actual. 
| help    | Menu de ayuda.      |
| clear   | Borra pantalla.      |
| exit    | Sale del prorama.      |

## 2. Operaciones del monedero

Comando | Descripción de la función | Comentario |
| ---------------------------------------- | -------------------------------- | ------ |
| create wallet \<path> | Crea el fichero del monedero. |
| open wallet \<path> | Abre el fichero del monedero. |
| update wallet <path> | Actualiza el monedero |
| rebuild wallet index | Reconstruye los índices del monedero. | Necesita abrir el monedero. |
| list address | Lista todas las cuentas del monedero. | | Necesita abrir el monedero. |
| list asset | Lista todos los activos del monedero. | Necesita abrir el monedero. |
| list key | Lista todas las claves publicas del monedero. | Necesita abrir el monedero. |
| show utxo [id|alias] | Lista las transacciones en función del id o del alias | Necesita abrir el monedero.
| show gas | Muestra el NeoGas. | Necesita abrir el monedero. |
| claim gas | Reclama el NeoGas disponible. | Necesita abrir el monedero. |
| create address [n = 1] | Crea una dirección/Crea direcciones de forma automática. | Necesita abrir el monedero. |
| import key \<wif\|path> | Importa la clave privada/importa claves privadas de forma masiva. | Necesita abrir el monedero. |
| export key \[address] [path] | Exporta la clave privada. | Necesita abrir el monedero. |
| send \<id\|alias|all> \<address> \<value> [fee=0]| Transfiere a la dirección especificada o a todas las direcciones. | Necesita abrir el monedero. |

Los siguientes comandos se explican en detalle:

**Crea el fichero del monedero**

:point_right: `create wallet`

`neo> create wallet mywallet` <br>
`password:******` <br>
`password:******` <br>
`address: AX9wfdHGDb2Q8Q4FKoEAa6xn2AG6VGx3Tf` <br>
 `pubkey: 03fa5ef0f098482b54bb151a13eedd439d026e5ce3c324c850fa5efd207f314833` <br>
 
 **Abre el fichero monedero**

:point_right: `open wallet`

`neo> open wallet mywallet` <br>
`password:******` <br>

**Actualiza el fichero del monedero**

:point_right: `update wallet <path>`

`neo>upgrade wallet cli.db3`<br>
`Wallet file upgrade complete. Old file has been auto-saved at: cli.old.db3`<br>


**Recontruye los indices del fichero del monedero**
 
:point_right: `rebuild index`

Reconstruye los índices del monedero. ¿Por qué es necesario reconstruir los indices del monedero?

Hay un campo en el monedero que guarda el tamaño de bloque actual sincronizado. Por cada nuevo bloque, el monedero sincroniza los bloques y actualiza los activos y las transacciones. Supongamos que el actual tamaño del bloque guardado es 100, ejecutamos el comando `import key` para importar una clave privada, el monedero calculará tus activos desde el tamaño de bloque 100. Si la dirección importada tenia transacciones cuando el tamaño del bloque era menor de 100, las transacciones y sus correspondientes bloques no quedarán reflejados en el monedero, por lo que el índice del monedero debe reconstruirse forzando al monedero a calcular los activos y transacciones desde el tamaño de bloque 0.

Un monedero nuevo no necesita recontruir los indices, sólo hay que recontruir los indices cuando se importa una clave privada.

**Crea una dirección**

:point_right: `create address [n = 1]`

`neo> create address`<br>
`[1/1]`<br>
`export addresses to address.txt`<br>

`neo> create address 10`<br>
`[10/10]`<br>
`export addresses to address.txt`<br>

Puedes crear una dirección y también puedes crear muchas direcciones de forma masiva introduciendo el número de direcciones.
Por ejemplo, introduciendo 10 para crear 10 nuevas direcciones; La creación de direcciones de forma masiva son automáticamente exportadas en el fichero `address.txt`

**Exporta la clave pública**

:point_right: `export key [address] [path]`

Puedes especificar la dirección a la que quieres exportar su clave probada. También puedes especificar el fichero donde quieres exportarla. Esta operación requiere introducir la contraseña del monedero.

`neo> export key AUPVb4rPh93Luz4VRMtebJpwzTMe3gKkKm `<br>
`password:******` <br>
`L52XY7VDzvoP5298nQrTvHRL8nzof6NjG89F2ujRwUw3y95Hc4Qb` <br>

`ant>export key AUPVb4rPh93Luz4VRMtebJpwzTMe3gKkKm myprivatekey.txt`<br>
`password:******` <br>

**Importa la clave privada**

:point_right: `import key <wif | path>`

Cuando se importa una clave privada puedes especificar la clave privada o importarla desde un archivo.

`neo> import key L52XY7VDzvoP5298nQrTvHRL8nzof6NjG89F2ujRwUw3y95Hc4Qb`<br>
`address: AUPVb4rPh93Luz4VRMtebJpwzTMe3gKkKm`<br>
`pubkey: 02d36afd7246d4a81db3176b4de4bc2794765b32ea70704bb5741d7ae2be055c0d`<br>

`neo> import key myprivatekey.txt` <br>
`[1/1]` <br>

Si se especifica un fichero, el fichero debe estar en formato de clave privada. Ver la salida en un fichero del comando `export key.`

**Muestra el NeoGas disponible**

:point_right: `show gas`

`neo> show gas`<br>
`unavailable: 0.12542` <br>
` available: 0.146789` <br>

**Reclama NeoGas**

:point_right: `claim gas` <br>
`Tranaction Suceeded: 7e6230add40ff61ba978bbacad8054e96caf709e2793b8a83db84c86e7ae7ee1`

**Muestra las transacciones UTXO en función del id o alias de una transacción**

:point_right: `show utxo [id|alias]` <br>

`neo>show utxo neo`<br>
`8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f:2`<br>
`total: 1 UTXOs`<br>
`neo>show utxo gas`<br>
`8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f:1`<br>
`total: 1 UTXOs`<br>
`neo>show utxo 025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4`<br>
`8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f:0`<br>
`total: 1 UTXOs`<br>


**Transfiere a la dirección especificada o a todas las direcciones del monedero**

:point_right: `send <id | alias | all> <address> <value> [fee = 0]`

Para transferir hay un total de cuatro paramentos: El primer parámetro es el id. de activo, el segundo parámetro es la dirección de pago, el tercer parámetro es la cantidad a transferir y el cuarto parámetro es la tarifa. (Este parámetro se puede dejar en blanco, por defecto es 0). <br><br>

Los id de activos propios del sistema son:
- NEO: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b <br>
- NEOGas: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

Para poder tranferir hay que introducir la contraseña del monedero. Por ejemplo, para enviar 100 NEO a la dirección `AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b` el comando es el siguiente:

`send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100`

Si no estas seguro del ID del activo, ejecuta el comando `list asset` para mostrar la lista de todos los activos del monedero.


## 3. Ver la información del nodo

Comando | Descripción de la función  |
| ---------- | ----------------------- |
`show state` | Muestra el estado de la sincronización de la blockchain. |
`show node` | Muestra los puertos y los nodos conectados. |
`show pool` | Muestra las transacciones en el pool de memoria. |



## 4. Comandos avanzados

Comando  | Descripción de la función |
| --------------- | ---- |
`start consensus` | Inicia consenso.
Para iniciar un consenso el monedero tiene que tener autoridad consenso, la autoridad de consenso en la red principal (MainNet) se obtiene a través de voto. Si se despliega una blockchain privada, la claves publicas se pueden configurar en el fichero `protocol.json`. Consulta la creación de blockchain privadas aqui [Private chain](private-chain.md)
`export blocks [path=chain.acc]` | Exporta los bloques a un fichero de salida |
`refresh policy` | Refresca la política.
