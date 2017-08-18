# Creación de una blockchain privada en CentOS

Para implementar una blockchain privada NEO se necesitan un mínimo de cuatro servidores/nodos para llegar a un consenso. Cada servidor corresponde a nodo consenso y dispone de un monedero dedicado.

## Laboratorio de pruebas

|  **Nombre**        | **Dirección IP/DNS** | **Sistema operativo** | **Observaciones**
| -------------- | ---------------- | ----------------- |--------------|
| **privatechain1**  | privatechain1.neolab.local  | CentOS 7.3 | neo-cli - privatechain1.db3 |
| **privatechain2**  | privatechain2.neolab.local  | CentOS 7.3 | neo-cli - privatechain2.db3 |
| **privatechain3**  | privatechain3.neolab.local  | CentOS 7.3 | neo-cli - privatechain3.db3 |
| **privatechain4**  | privatechain4.neolab.local  | CentOS 7.3 | neo-cli - privatechain4.db3 |
| **neoscan**  | neoscan.neolab.local        | Ubuntu 16.04.2 LTS        |Opcional| 
| **pc**  | pc.neolab.local        | NEO-gui / Visual Studio |Opcional|

## 1. Configuracion de las máquinas virtuales

Para fines demostrativos, he creado cuatro servidores virtuales en Azure, el tamaño es `Standard_DS1 v2` (1 core, con 3.5 GB RAM). Puedes desplegar la blockchain privada en una LAN o en máquinas virtuales.

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_1.png">

> [!IMPORTANT] 
>Despues de crear las máquinas virtuales abre los puertos 10331-10334 en el firewall de CentOS `firewalld` y establece nuevas reglas de entrada para los puertos 10331-10334.


> [!NOTE]
> Si creas una maquina virtual en un entorno cloud, logeate en el panel de administración de la máquinas virtuales y configura los grupos de seguridad.

> En Azure la configuración es: `network interface` `network security group` `inbound security rules` `add` y añade los puertos 10331-10334.
><img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_2.png">

Una vez que las máquina virtual han sido creadas anota las direcciones IP para su uso posterior.

## 2. Instalación de un nodo NEO

El proceso de instalación es el siguiente. También lo puedes consultar [aquí](setup.md)

**Instalación de .NET Core**

```
sudo yum update
sudo yum install epel-release unzip wget

sudo yum install leveldb-devel libunwind libicu -y
sudo curl -sSL -o dotnet.tar.gz https://aka.ms/dotnet-sdk-2.0.0-linux-x64
sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
sudo ln -s /opt/dotnet/dotnet /usr/local/bin
```

**Instalación de NEO-cli**

```
sudo wget https://github.com/neo-project/neo-cli/releases/download/v2.1.0/neo-cli-centos.7-x64.zip
sudo mkdir -p /opt/neo-cli && sudo unzip neo-cli-centos.7-x64.zip -d /opt/neo-cli
cd /opt/neo-cli/neo
sudo dotnet neo-cli.dll
```


## 3. Crear monederos

Primero hemos creados cuatro ficheros de monedero llamados `privatechain1.db3 - privatechain4.db3.` Este paso puede ser creado tanto con la versión de PC `NEO-gui` como con la versión de línea de comandos `NEO-cli`. La siguiente imagen es usando el cliente `NEO-cli`.

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_3.png">

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
      "022cfe44e226442dfaf36b76e2e509edb3081eba24b5c32d2ce5c3cf258fb82ccb",
      "030ef9639e72b8969c56149c75aeb744a8fcdeddada49902f6681bdfad3a75b5e9",
      "024aa242347f7cd0ac999fb9af765934f4a0462f77282622599f5ae7164d3b3387",
      "035663e6e124543c9a12e7b78f74b4abfb225d141bc6cf42637a055d40e7cd3b4d"
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

Una vez sustituido el fichero de configuración en los cuatro nodos, introduce los siguiente comandos para ejecutar el cliente CLI, abrir el monedero y ejecutar el conseso. Revisa la línea de comandos aquí [CLI Command Reference](cli.md).

A modo de ejemplo en el nodo1:

Arrancar el cliente:<br>
:point_right:`dotnet neo-cli.dll`

Abrir el monedero:<br>
:point_right:`open wallet privatechain1.db3`

Ejecutar consenso:<br>
:point_right:`start consensus`

## Ejecución paso a paso en los cuatro nodos

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_4.png">
<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_5.png">
<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_6.png">
<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_7.png">

Si la operación anterior se ha ejecutado de forma correcta el proceso consenso se ejecutará en los cuatro nodos, tal y como se muestra en la imagen.

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_8.png">


## 5. Extraer NEO y NeoGas

Instala la versión cliente PC `NEO-gui` y modifica el fichero de configuración `protocol.json` con los paramentros del paso 4 para conectar a la blockchain privada.

Ejecuta el cliente PC; Para comprobar que nos hemos conectado correctamente a la blockchain privada en la parte inferior izquierda el tamaño de bloque `Height` no es cero y el número conexiones `Connected` corresponde al numero de nodos en nuestra blockchain privada, en nuestro ejemplo 4 nodos.

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_10.png">

Abre el fichero del monedero `privatechain1.db3` click derecho sobre la dirección y click en `Create Contract Add.` y click en `Multi-Signature.` 

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_11.png">

Introduce las cuatro claves publicas apuntadas en el paso 4. Para eso, introduce la clave y pulsa el simbolo `[+]` **Una vez introducida las 4 claves publicas**, modifica el parametro número mínimo de firmas `Min.Sig.Num` a 3, siendo `(número de nodos consensos/2 + 1)`, tal y como se muestra en la imagen.

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_12.png">

>[!IMPORTANT]
> Debe hacer la misma operación anterior en los 4 monederos: crear un cuenta contrato multi-firma y añadir las 4 claves 
> publicas.

**Paso a paso:** 

 * Abrir el monedero `privatechain2.db3` click en `Create Contract Add` click en `Multi-Signature` y añade las 4 claves publicas.
 * Abrir el monedero `privatechain3.db3` click en `Create Contract Add` click en `Multi-Signature` y añade las 4 claves publicas.
 * Abrir el monedero `privatechain4.db3` click en `Create Contract Add` click en `Multi-Signature` y añade las 4 claves publicas.

Una vez introducidas las claves publicas, abre nuevamente el monedero `privatechain1.db3` y recrea los indices, click en la barra del menu `Wallet` y click en `Rebuild Index`. 

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_13.png">

Una vez recreados los índices aparecerá la dirección de contrato con 100 millones de NEOs.

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_14.png">

Una vez realizado el paso anterior debemos transferir los NEO de la dirección de contrato a la dirección normal. Para eso, abre cualquiera de los cuatro monederos. (En mi ejemplo, abriré el primer monedero `privatechain1.db3`)

Click en la barra del menu `Transaction` y click en `Transfer` e introduce la dirección de la cuenta estandard para transferir los 100 millones de NEOs a esa dirección. Click en OK.

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_15.png">

El sistema mostrará el siguiente mensaje `Transaction initiated, but the signature is incompleted`. 

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_16.png">

Copia el codigo. Click en `Copy` y abre otro monedero distinto, en mi ejemplo el fichero `privatechain2.db3`, click en la barra del menu `Transaction` y click en `Signature`

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_17.png">

Pega el codigo que anteriormente has copiado. Click `Signature` y vuelte a copiar el codigo de salida `Output`, click en `Copy`

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_18.png">

Nuevamente abre otro monedero distinto, en mi ejemplo el fichero `privatechain3.db3`, click en la barra del menu `Transaction` y click en `Signature` y pega el codigo anteriormente copiado y click en `Signature`. En este momento aparecerá un botón `Broadcast` que significa que la transación se ha completado (Se ha alcanzado el número mínimo de firmas requerido para el contrato). En este momento la transación puede ser emitida. Click en `Broadcast`. 

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_19.png">

La operación puede tardar unos 15 segundos para ver la tranferencia realizada. Una vez esperado ese tiempo abre el fichero del monedero `privatechain1.db3` para ver las monedas recibidas en la cuenta normal.

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_20.png">

La operación para extraer los NeoGas es similar. Abre el primer fichero monedero `privatechain1.db3` y click en el barra de `Advanced` y click en `NeoGas Claim`,

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_21.png">

Click en `Claim All`

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_22.png">

Una vez pulsado del botón `Claim All`. Nos aparecerá el siguiente mensaje:

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_23.png">

La operación es similar a la de transferir NEOs. Copia el codigo de firma incompleta, abre el fichero del segundo monedero `privatechain2.db3` click en la barra de menu y click en `Transaction` y `Signature` y pega el codigo anteriormente copiado.
Una vez copiado, copia el codigo de salida `Output`. Abre otro monedero, en mi caso `privatechain3.db3` click en la barra del menu `Transaction` y click en `Signature` y pega el codigo anteriormente copiado y click en `Signature`.

Una vez copiado aparecerá el botón de Broadcast `Broadcast` y la transación puede ser emitida. Click en `Broadcast`.

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_24.png">

La operación puede tardar unos 15 segundos para ver la tranferencia realizada. Una vez esperado ese tiempo abre el fichero del monedero `privatechain1.db3` y recrea los indices del monedero.

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_25.png">

Una vez recreado los indices veremos los NeoGas.

<img style="vertical-align: middle" src="assets/privatechain-centos/privatechain_26.png">

