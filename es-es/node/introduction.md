# Introducción a los nodos de NEO

Los nodos completos son aquellos que guardan toda la información de la blockchain. Estos están conectados a la blockchain a través de una red P2P. En la red blockchain todos los nodos son iguales, actuando tanto de cliente como de servidor.

Existen dos clientes para interactuar con los nodos. El primero, para usuarios normales, es el cliente para PC el cual dispone de una interfaz gráfica con todas las funciones básicas. A este cliente lo llamamos `NEO-gui.`

El otro cliente está pensado para desarrolladores. Dispone de una interfaz de línea de comandos y proporciona una API externa para la mayoría de las funciones del monedero. Este cliente también ayuda a los otros nodos a alcanzar consenso dentro de la red y también está involucrado en la generación de nuevos bloques. A este cliente lo llamamos `NEO-cli`



## Enlaces desde donde descargar los clientes

|      | NEO-gui                        | NEO-cli                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Distribuciones | [Sitio web oficial](https://www.neo.org/download) o [GitHub](https://github.com/neo-project/neo-gui/releases) | [GitHub](https://github.com/neo-project/neo-cli/releases/) |
Código fuente| [GitHub](https://github.com/neo-project/neo-gui/) | [GitHub](https://github.com/neo-project/neo-cli/) |

## Comparativa de funciones entre el cliente NEO-gui y NEO-cli

|           | NEO-gui  | NEO-cli  |
| --------- | ---- | ---- |
| Interfaz gráfica. | ✅    |      |
| Interfaz línea de comandos. |      | ✅    |
| Crear monedero. | ✅    | ✅    |
| Abrir monedero. | ✅    | ✅  |
| Reconstruir índices del monedero.  | ✅    | ✅    |
| Mostrar todas las parejas de claves. | ✅    | ✅    |
| Importar/Exportar pareja de claves. | ✅    | ✅    |
| Mostrar todas las direcciones. | ✅    | ✅    |
| Mostrar todos los activos. | ✅    | ✅    |
| Crear dirección | ✅    | ✅    |
| Transferir. | ✅    | ✅    |
| Transferencias masivas (en lote)| ✅    | ✅    |
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

Si ser requiere que un programa externo acceda a la API de los nodos es necesario abrir, bien permanentemente o bajo demanda los siguientes puertos.


|                    | Red principal (MainNet) | Red de pruebas (TestNet) |
| ------------------ | ------------ | ------------- |
| JSON-RPC vía HTTPS | 10331        | 20331         |
| JSON-RPC vía HTTP  | 10332        | 20332         |
| P2P vía TCP        | 10333        | 20333         |
| P2P vía WebSocket  | 10334        | 20334         |

Para más información, consultar [red de pruebas](testnet.md).
