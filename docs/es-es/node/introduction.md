# Introducción NEO

Los nodos completos son los nodos que guardan toda la información de la blockchain. Están conectados a la blockchain a través de una red P2P (punto-a-punto). En la red blockchain todos los nodos son iguales, estos actúan tanto como cliente como servidor.
Existen dos clientes para interactuar con los nodos completos. El primero de ellos, el cliente PC, es para usuarios normales, dispone de una interfaz gráfica y proporciona todas las funciones cliente. A este cliente lo llamamos `NEO-gui.`

El otro cliente, el cliente CLI, está pensado para desarrolladores. Dispone de una interfaz de línea de comandos y proporciona una API externa para la mayoría de las funciones monedero. Este cliente también ayuda a los otros nodos a alcanzar consenso dentro de la red y también está involucrado en la generación de nuevos bloques. A este cliente lo llamamos `NEO-cli`



## Direcciones donde descargar los clientes

|      | NEO-gui                        | NEO-cli                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Releases | [Official website](https://www.neo.org/download) or [GitHub](https://github.com/neo-project/neo-gui/releases) | [GitHub](https://github.com/neo-project/neo-cli/releases/) |
Source code | [GitHub](https://github.com/neo-project/neo-gui/) | [GitHub](https://github.com/neo-project/neo-cli/) |

## Comparativa de funciones entre el cliente NEO-gui y NEO-cli

|           | NEO-gui  | NEO-cli  |
| --------- | ---- | ---- |
| Interfaz gráfica. | ✅    |      |
| Interfaz línea de comandos. |      | ✅    |
| Crear monedero. | ✅    | ✅    |
| Abrir monedero. | ✅    | ✅  |
| Reconstruir índices monedero.  | ✅    | ✅    |
| Mostrar todas las parejas de claves. | ✅    | ✅    |
| Importar/Exportar pareja de claves. | ✅    | ✅    |
| Mostrar todas las direcciones. | ✅    | ✅    |
| Mostrar todos los activos. | ✅    | ✅    |
| Crear dirección | ✅    | ✅    |
| Transferir. | ✅    | ✅    |
| Realizar transacciones (intercambiar activos).  | ✅    |      |
| Crear un contrato firma multipartidista. | ✅    |      |
| Crear un contrato inteligente personalizado. | ✅    |      |
| Firmar. | ✅    |      |
| Elección nodo consenso. | ✅    |      |
| Mostrar NeoGas. | ✅    | ✅     |
| Reclamar NeoGas. | ✅    | ✅     |
| Votar. | ✅    |      |
| Registrar activo.  | ✅    |      |
| Distribución de activos. | ✅    |      |
| Extracción de activos. | ✅    |      |
| Generación de direcciones por lote.  |      | ✅    |
| JSON-RPC. |      | ✅    |
| Participar en el consenso de bloques |      | ✅    |

## Descripción de puertos

Si quieres que un programa externo acceda a la API de los nodos, requiere que habrás los puertos de comunicación. A continuación los puertos que deben ser abiertos o abrirlos bajo demanda.


|                    | Red principal (MainNet) | Red de pruebas (TestNet) |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |

Para más información, consultar [red de pruebas](testnet.md).
