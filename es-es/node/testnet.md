# La red de pruebas (TestNet)

La red de pruebas está diseñada para el desarrollo. Probar el sistema en la red de pruebas tiene una tarifa de NeoGas (no NeoGas reales). Los NEOs y los NeoGas de la red de pruebas puede ser proporcionados sin cargo alguno en la siguiente Web. https://www.neo.org/Testnet/Create


Todos los bloques de datos de la red de pruebas son independiente de la red principal (MainNet). Si desarrollas un contrato inteligente simple o intentas registrar activos, la red de pruebas deberia ser suficiente. Una vez finalizadas las pruebas, el desarrollo puede ser movido a red principal.

## Caracteristicas de la red de pruebas

1. Registro y distribución de activos, ejecución de contratos, etc. No consume dinero real.
2. Global, desplegado en Internet.
3. Probar la red, transacciones y otra información visible desde el explorador de bloques.
4. Los contratos inteligentes desarrollados en el entorno de pruebas pueden ser utilizados desde cualquier parte del mundo.
5. La red de pruebas no puede ser usada para aplicaciones comerciales.

## Descargar el cliente

El cliente para la red de pruebas es el mismo que se usa para la red principal. Modificando los ficheros de configuración del cliente podemos cambiar de la red de pruebas a la red principal.

Referencia: [introducción de un nodo NEO](introduction.md).

|      | NEO-gui                       | NEO-cli                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Releases | [official website](https://www.neo.org/download) or [GitHub](https://github.com/neo-project/neo-gui/releases/) | [GitHub](https://github.com/neo-project/neo-cli/releases/) |
Source code | [GitHub](https://github.com/neo-project/neo-gui/) | [GitHub](https://github.com/neo-project/neo-cli/) |

## Configurar el cliente para la red de pruebas

1. Si usas el cliente GUI `NEO-gui` dentro de la carpeta donde se encuentra el ejecutable copia el contenido de
`protocol.testnet.json` en `protocol.json` tal y como se muestra en la imagen.
 
  <img style="vertical-align: middle" src="/assets/testnet_1_v2.png">

2. Y el contenido de `config.testnet.json` en `config.json`

  <img style="vertical-align: middle" src="/assets/testnet_2_v2.png">


> [!NOTE]
> Si usas el cliente CLI (NEO-cli) se debe copiar el contenido del fichero **config.testnet.json** en **config.json**.

# Solicitar NEO y NeoGas en la red de pruebas (Testnet)

1. Sigue los pasos anteriores para configurar el cliente (ya sea el cliente NEO-cli o NEO-gui) para conectarse a la red de pruebas. Esto es, copiando el contenido de `procotol.testnet.json` en  `protocol.json` y el contenido del fichero `config.testnet.json` en `config.json`

2. Arranca el cliente (en nuestro ejemplo el cliente NEO-gui) y asegúrate de que esté totalmente sincronizado.
 <img style="vertical-align: middle" src="/assets/gui_1.png">
 
3. Crea un monedero. Click en `Wallet`, click en `New Wallet Database`. Una vez pulsado aparecerá la ventana `New Wallet` y click en `Browser`.

4. Introduce la conseña en `Password` y repitela en `Re-Password` y click en `Confirm`. Una vez pulsado `Confirm` el monedero creará por defecto una cuenta estandard.

5. Una vez creado el monedero nos creará una cuenta estandard. Click con el botón-derecho del raton sobre la cuenta estándar y click en `View Private Key` y copiamos la clave pública, tal y como se muestra en la imagen:

  <img style="vertical-align: middle" src="/assets/testnet_3.png">
  
6. Dirígete a la siguiente dirección para solicitar los NEO/NeoGas, [NEO Developer](https://neo.org/testNet/create)

7. Rellena el formulario. El en apartado `Reason for Application` explica con detalles el proyecto que quieres realizar, así como la página web y el documento técnico, además de los NEO y NeoGas que necesitas para el proyecto.

8. En el apartado `Neo Public Key` introduce la clave pública.

 <img style="vertical-align: middle" src="/assets/testnet_4.png">
 
9. Una vez completado, click en `Submit Application`

10. Al cabo de unos días, si la aplicación ha sido aprobada por el equipo de NEO recibirás un correo electrónico con la cuenta contrato asignada y una clave pública. Esa clave pública la usaremos para crear una cuenta contrato a partir de nuestra cuenta estándar. 

Para eso:

 * Click con el botón derecho sobre la cuenta estándard, click en `Create Contract Add` y click en `Multisignature`.
 
 <img style="vertical-align: middle" src="/assets/testnet_5.png">
 
 * En el apartado `Pub.Key list` añadirmos las dos claves publicas, la que nos ha enviado NEO y la nuestra. En el `Min.Sig.Num` indicamos `1` y click en `Confirm`
 
 <img style="vertical-align: middle" src="/assets/testnet_6.png">
 
 * Una vez confirmada y **al cabo de 5 minutos** veremos el NEO y NeoGas que hemos solicitado.
 
  <img style="vertical-align: middle" src="/assets/testnet_7.png">
  
  11. Ahora puedes hacer una transferencia de los NEO y NeoGas de la cuenta contrato a la cuenta estándar. 

