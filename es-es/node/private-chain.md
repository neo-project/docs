# Creación de una Blockchain Privada

Para implementar una blockchain privada NEO se necesitan un mínimo de cuatro servidores/nodos para llegar a un consenso. Cada servidor corresponde a nodo consenso y dispone de un monedero dedicado.

## Laboratorio de pruebas

|  **Nombre**        | **Dirección IP/DNS** |  **Observaciones** |
| -------------- | ---------------- | ----------------- |
| **privatechain1**  | privatechain1.neolab.local  | neo-cli - privatechain1.db3 |
| **privatechain2**  | privatechain2.neolab.local  | neo-cli - privatechain2.db3 |
| **privatechain3**  | privatechain3.neolab.local  | neo-cli - privatechain3.db3 |
| **privatechain4**  | privatechain4.neolab.local  | neo-cli - privatechain4.db3 |
| **pc**  | pc.neolab.local        | NEO-gui / Visual Studio |Opcional|

## 1. Configuracion de las máquinas virtuales

> [!IMPORTANT] 
>Despues de crear el entorno abre los puertos 10331-10334 y para establece nuevas reglas para acceder a los puertos 10331-10334.

Una vez que las máquina virtual han sido creadas anota las direcciones IP para su uso posterior.

## 2. Instalación de un nodo NEO

El proceso de instalación de un nodo NEO ha sido descrito anteriormente. Por favor, consulta las instrucciones de instalación [Setup](setup.md).

## 3. Crear monederos

Primero hemos creados cuatro ficheros de monedero llamados `privatechain1.db3 - privatechain4.db3.` Este paso puede ser creado tanto con la versión de PC `NEO-gui` como con la versión de línea de comandos `NEO-cli`. La siguiente imagen es usando el cliente `NEO-cli`.

<img style="vertical-align: middle" src="/assets/privatechain_3.png">

Una vez que los monederos han sido creados y su correspondiente clave publica guardada, cópiala en el portapapeles o guárdala en un fichero txt, o usa el comando `list key` vía [CLI Command](cli.md)

A continuación, copia los cuatro monederos en los directorios donde se encuentra el cliente CLI `Neo-cli` de cada una de las máquinas virtuales 


## 4. Modificar los ficheros de configuració de los nodos

  Accede al directorio donde se encuenta el cliente CLI y modifica el fichero `protocol.json` con los siguientes parametros. 
  
  Primero modifica el valor de `Magic`. El valor `Magic` se usa para identificar el origen de la red del mensaje, al especificar el mismo valor `Magic` nos aseguramos que los mensajes se reciben en la misma red y no se envian a otra distinta.

> [!NOTE]
> El tipo de Magic es uint, el valor a introducir debe ser del rango. [0 - 4294967295].

  Modifica el valor `StandbyValidators`. Hay que introducir las 4 claves publicas anotadas en el paso 3.
  Finalmente mofificar el valor `SeedList`, introduce las direcciones IPs de los nodos, el número de puerto se mantiene sin cambios.
  
  A modo de ejemplo, nuestra configuración es la siguiente:
  
```json
{
  "ProtocolConfiguration": {
    "Magic": 12345678,
    "AddressVersion": 23,
    "StandbyValidators": [
      "0371568c58c85e7c1237f0b8ca029139ac0ce97bbb11eeb67bb9e3b6fbfc0182df",
      "03ebdefbc19cff99e8a87e7303ec0ff67ea6b1fa1766c6770e4128526c9803ecd4",
      "039b1c1f9120ed823cf5f7207eb0ed50c2ef6cc4b3a6ea0e0073f6ed7410ee5151",
      "03156d1c0e315d63d400c695261d169c881f550e7a17757963489ecc30d4fa5604"
      ],
    "SeedList": [
      "privatechain1.neolab.local:10333",
      "privatechain2.neolab.local:10333",
      "privatechain3.neolab.local:10333",
      "privatechain4.neolab.local:10333"
      ],
    "SystemFee": {
      "EnrollmentTransaction": 1000,
      "IssueTransaction": 500,
      "PublishTransaction": 500,
      "RegisterTransaction": 10000
    }
  }
}

```

El valor `SystemList` es la tarifa del sistema. La tarifa se paga en NeoGas. Puede establecer la tarifa de tu blockchain privada modificando esos valores.

> [!IMPORTANT] Una vez modificado el fichero **protocol.json** sustitúyelo en los 4 nodos, en el directorio donde se encuentra 
> el cliente NEO-cli

> [!TIP]
> Antes de ejecutar **por primera vez** la blockchain privada asegúrate que eliminar, si existe, la carpeta "Chain" y el fichero "peers.dat"

Una vez sustituido el fichero de configuración en los cuatro nodos, introduce los siguiente comandos para ejecutar el cliente CLI, abrir el monedero y ejecutar el conseso. Revisa la línea de comandos aquí [CLI Command Reference](cli.md).

A modo de ejemplo en el nodo1:

Arrancar el cliente:<br>
:point_right:`dotnet neo-cli.dll`

Abrir el monedero:<br>
:point_right:`open wallet privatechain1.db3`

Ejecutar consenso:<br>
:point_right:`start consensus`

## Ejecución paso a paso en los cuatro nodos

<img style="vertical-align: middle" src="assets/privatechain/privatechain_4.png">
<img style="vertical-align: middle" src="assets/privatechain/privatechain_5.png">
<img style="vertical-align: middle" src="assets/privatechain/privatechain_6.png">
<img style="vertical-align: middle" src="assets/privatechain/privatechain_7.png">

Si la operación anterior se ha ejecutado de forma correcta el proceso consenso se ejecutará en los cuatro nodos, tal y como se muestra en la imagen.

<img style="vertical-align: middle" src="/assets/privatechain_8.png">

En la siguiente imagen se muestra como 1 nodo han sido apagado y todavia se consigue consenso:

<img style="vertical-align: middle" src="/assets/privatechain_9.png">

## 5. Extraer NEO y NeoGas

Instala la versión cliente PC `NEO-gui` y modifica el fichero de configuración `protocol.json` con los paramentros del paso 4 para conectar a la blockchain privada.

Ejecuta el cliente PC; Para comprobar que nos hemos conectado correctamente a la blockchain privada en la parte inferior izquierda el tamaño de bloque `Height` no es cero y el número conexiones `Connected` corresponde al numero de nodos en nuestra blockchain privada, en nuestro ejemplo 4 nodos.

<img style="vertical-align: middle" src="assets/privatechain/privatechain_10.png">

Abre el fichero del monedero `privatechain1.db3` click derecho sobre la dirección y click en `Create Contract Add.` y click en `Multi-Signature.` 

<img style="vertical-align: middle" src="assets/privatechain/privatechain_11.png">

Introduce las cuatro claves publicas apuntadas en el paso 4. Para eso, introduce la clave y pulsa el simbolo `[+]` **Una vez introducida las 4 claves publicas**, modifica el parametro número mínimo de firmas `Min.Sig.Num` a 3, siendo `(número de nodos consensos/2 + 1)`, tal y como se muestra en la imagen.

<img style="vertical-align: middle" src="/assets/privatechain_12.png">

>[!IMPORTANT]
> Debe hacer la misma operación anterior en los 4 monederos: crear un cuenta contrato multi-firma y añadir las 4 claves 
> publicas.

**Paso a paso:** 

 * Abrir el monedero `privatechain2.db3` click en `Create Contract Add` click en `Multi-Signature` y añade las 4 claves publicas.
 * Abrir el monedero `privatechain3.db3` click en `Create Contract Add` click en `Multi-Signature` y añade las 4 claves publicas.
 * Abrir el monedero `privatechain4.db3` click en `Create Contract Add` click en `Multi-Signature` y añade las 4 claves publicas

Una vez introducidas las claves publicas, abre nuevamente el monedero `privatechain1.db3` y recrea los indices, click en la barra del menu `Wallet` y click en `Rebuild Index`. 

<img style="vertical-align: middle" src="assets/privatechain/privatechain_13.png">

Una vez recreados los índices aparecerá la dirección de contrato con 100 millones de NEOs.

<img style="vertical-align: middle" src="/assets/privatechain_14.png">

Una vez realizado el paso anterior debemos transferir los NEO de la dirección de contrato a la dirección normal. Para eso, abre cualquiera de los cuatro monederos. (En mi ejemplo, abriré el primer monedero `privatechain1.db3`)

Click en la barra del menu `Transaction` y click en `Transfer` e introduce la dirección de la cuenta estandard para transferir los 100 millones de NEOs a esa dirección. Click en OK.

<img style="vertical-align: middle" src="assets/privatechain/privatechain_15.png">

El sistema mostrará el siguiente mensaje `Transaction initiated, but the signature is incompleted`. 

<img style="vertical-align: middle" src="assets/privatechain/privatechain_16.png">

Copia el codigo. Click en `Copy` y abre otro monedero distinto, en mi ejemplo el fichero `privatechain2.db3`, click en la barra del menu `Transaction` y click en `Signature`

<img style="vertical-align: middle" src="assets/privatechain/privatechain_17.png">

Pega el codigo que anteriormente has copiado. Click `Signature` y vuelte a copiar el codigo de salida `Output`, click en `Copy`

<img style="vertical-align: middle" src="assets/privatechain/privatechain_18.png">

Nuevamente abre otro monedero distinto, en mi ejemplo el fichero `privatechain3.db3`, click en la barra del menu `Transaction` y click en `Signature` y pega el codigo anteriormente copiado y click en `Signature`. En este momento aparecerá un botón `Broadcast` que significa que la transación se ha completado (Se ha alcanzado el número mínimo de firmas requerido para el contrato). En este momento la transación puede ser emitida. Click en `Broadcast`. 

<img style="vertical-align: middle" src="assets/privatechain/privatechain_19.png">

La operación puede tardar unos 15 segundos para ver la tranferencia realizada. Una vez esperado ese tiempo abre el fichero del monedero `privatechain1.db3` para ver las monedas recibidas en la cuenta normal.

<img style="vertical-align: middle" src="/assets/privatechain_20.png">

La operación para extraer los NeoGas es similar. Abre el primer fichero monedero `privatechain1.db3` y click en el barra de `Advanced` y click en `NeoGas Claim`,

<img style="vertical-align: middle" src="/assets/privatechain_21.png">

Click en `Claim All`

<img style="vertical-align: middle" src="assets/privatechain/privatechain_22.png">

Una vez pulsado del botón `Claim All`. Nos aparecerá el siguiente mensaje:

<img style="vertical-align: middle" src="assets/privatechain/privatechain_23.png">

La operación es similar a la de transferir NEOs. Copia el codigo de firma incompleta, abre el fichero del segundo monedero `privatechain2.db3` click en la barra de menu y click en `Transaction` y `Signature` y pega el codigo anteriormente copiado.
Una vez copiado, copia el codigo de salida `Output`. Abre otro monedero, en mi caso `privatechain3.db3` click en la barra del menu `Transaction` y click en `Signature` y pega el codigo anteriormente copiado y click en `Signature`.

Una vez copiado aparecerá el botón de Broadcast `Broadcast` y la transación puede ser emitida. Click en `Broadcast`.

<img style="vertical-align: middle" src="assets/privatechain/privatechain_24.png">

La operación puede tardar unos 15 segundos para ver la tranferencia realizada. Una vez esperado ese tiempo abre el fichero del monedero `privatechain1.db3` y recrea los indices del monedero.

<img style="vertical-align: middle" src="assets/privatechain/privatechain_25.png">

Una vez recreado los indices veremos los NeoGas.

<img style="vertical-align: middle" src="/assets/privatechain_26.png">

