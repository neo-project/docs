# NEO White Paper 1.1

**El documento está siendo editado** y lo completaremos lo antes posible. Puedes ver otros documentos en [GitHub](https://github.com/neo-project/neo/wiki) or visitar la [web oficial](http://www.neo.org).

Es un proyecto de codigo abierto. Puedes contribuir al desarrollo de la documentación en [github.com/neo-project/docs](https://github.com/neo-project/docs). Gracias por tu ayuda.

--------

## Información general sobre NEO

### NEO y blockchains

#### ¿Qué es NEO?

NEO es una plataforma de activos inteligentes y el primer proyecto de cadena de bloques público de código abierto en China. Los activos inteligentes es una combinación de contratos inteligentes y activos digitales en la cadena de bloques, lo que hace que el registro, la distribución y el comercio de los activos digitales sean más inteligentes.

* Los activos digitales son activos almacenados en forma de datos electrónicos con tecnología de cadena de bloques para obtener características como la descentralización, la confiabilidad, la trazabilidad y la transparencia. La cadena de bloques NEO soporta una variedad de activos digitales, lo que permite a los usuarios registrar, distribuir, intercambiar libremente y distribuir los activos. Los certificados digitales pueden resolver la cuestión de la confianza en la cadena de bloques. A través de los certificados digitales, los activos emitidos por los usuarios también pueden disfrutar de la protección de la ley. En escenarios empresariales con lógica compleja, los usuarios pueden utilizar los contratos inteligentes para mejorar la funcionalidad de los activos o crear una lógica empresarial independiente de los activos.

* El contrato inteligente fue propuesto por primera vez por el criptólogo Nick Szabo en 1993 y tiene casi la misma edad que la Internet. Según la definición de Szabo: Cuando se cumple una condición preprogramada, el contrato inteligente ejecuta los términos contractuales correspondientes. La tecnología de cadena de bloques nos proporciona un sistema descentralizado, inmutable, altamente confiable en el que los contratos inteligentes son muy útiles. NEO tiene las capacidades de contrato inteligentes completas de Turing, que se ejecutan en la máquina virtual de NEO (neo-vm) y tiene muchas ventajas como ser determinista, tener terminación, permitir el control de recursos, la concurrencia, la fragmentación y la escalabilidad.

NEO combina una gama de tecnologías tales como redes punto a punto, tolerancia a los fallos bizantinos, certificados digitales, contratos inteligentes, transacciones superconductoras y protocolos de interoperabilidad entre cadenas, lo que te permite gestionar tus activos inteligentes de forma rápida, eficiente, segura y legal.


#### ¿Qué es una cadena de bloques?

El término cadena de bloques se originó con la Bitcoin. En su documento sobre la bitcoin, Satoshi Nakamoto propuso el término cadena de bloques mientras que en su siguiente versión del programa Bitcoin original, la carpeta que mantenía los registros de transacciones se llamaba _blockchain_. Originalmente, la cadena de bloques simplemente se refería a los datos históricos de transacciones. La mayoría de las criptomonedas posteriores llamaron también su carpeta de transacciones como _blockchain_, por lo que este término comenzó a referirse a los datos de transacciones históricas de las criptomonedas.

Desde 2015 los principales actores financieros han comenzado a estudiar sistemas como Bitcoin, Ethereum y Ripple. Estas instituciones financieras han tomado una visión separada con base en la tecnología subyacente y el negocio de nivel superior de sistemas como Bitcoin. Han estado llamando a la combinación de estas tecnologías subyacentes _tecnología blockchain_. Blockchain es la combinación de criptografía, la topología de red, algoritmo de consenso y la teoría de juegos. Con módulos técnicos como Prueba de Funcionamiento, Prueba de Participación, Contrato Inteligente, Red de Iluminación (Lighting Network) y Cadena Lateral (Side Chain).



#### Los principios de Blockchain

Creemos que lo que constituye el núcleo de la blockchain es cómo lograr un **consenso distribuido** - es decir, en ausencia de un organismo central o una red con múltiples centros, cómo cada nodo procesa todas las transacciones que ocurren dentro de la red para alcanzar un consenso común. Este consenso incluye elementos como el contenido, la validez y el orden cronológico de las transacciones.

* **Alcanzar efectivamente un consenso distribuido de las transacciones usando la firma digital de los contenidos**

En el sistema tradicional de papel, el contenido de la transacción (instrucciones de transacción) y la información de autenticación (firma y sello) se almacenan por separado. Por ejemplo, en los retiros bancarios, los formularios de solicitud firmados por el usuario y los registros de transacciones se almacenan por separado. De esta manera, es difícil para personas fuera del banco verificar la autenticidad de estas transacciones.

La blockchain enlaza y almacena el contenido de transacción y la información de autenticación juntos. Cada nodo no requiere una organización central sino que realiza las autenticaciones mismas para verificar la integridad de la instrucción de transacción (sin alteración) y la validez (el firmante tiene la autoridad) con base en firmas digitales, logrando así el consenso distribuido sobre el contenido y la validez de la transacción.

* **Alcanzar un consenso distribuido en el ámbito de los negocios a través de un mecanismo de consenso**

Debido a la alta latencia de la red en las redes punto a punto, el orden de las transacciones observadas por cada nodo puede ser inconsistente. Por lo tanto, el sistema de cadena de bloques debe contemplar un mecanismo para acordar el orden de las transacciones que se produzcan dentro de un cierto período de tiempo. Este algoritmo para el orden de los negocios en una ventana de tiempo se llama un _mecanismo de consenso_. Los mecanismos comunes de consenso incluyen:

      * Prueba de Funcionamiento: Bitcoin, Ethereum (ahora)
      * Prueba de Participación: PeerCoin, NXT, Ethereum (futuro)
      * Prueba Delegada de Participación: BitShares, Crypti, Lisk
      * UNL / Porción de la Audiencia: Ripple, Stellar
      * Tolerancia a los Fallos Bizantinos (Byzantine Fault Tolerance): NEO, Hyperledger Fabric

* **Alcanzar el consenso distribuido respecto a los datos históricos a través de algoritmos de hashing**

El sistema de cadena de bloques construye típicamente una estructura de cadena haciendo referencia al valor de hash del bloque anterior para conseguir un efecto similar a "una costura." Cualquier manipulación en una única transacción resultará un error en la firma digital vinculada; cualquier alteración en el orden de la transacción causará un cambio en el valor de hash del bloque, haciendo que el "bloque" falle. Por lo tanto, ningún nodo debe valerse de una organización central para verificar la validez de todas las transacciones históricas con el fin de llegar a un consenso.

* **Alcanzar un consenso distribuido sobre los resultados del “contrato inteligente"**

Nick Szabo presentó el concepto de Contrato Inteligente en 1993, mucho antes de la aparición de las cadenas de bloques. El sistema de escritura de Bitcoin fue la primera realización básica del concepto. Ethereum se basó en ella para lograr una plataforma de contrato inteligente más completa y flexible. Además, Hyperledger también ha implementado un contrato inteligente basado en contenedores (que se conoce como chaincode).

Creemos que los contratos inteligentes en la cadena de bloques están a punto de llegar a otro consenso distribuido de resultados calculados usando datos afirmados como entradas tales como el contenido de la transacción, la validez, la orden, el historial y así sucesivamente.

Además de los detalles de consenso anteriores, la tecnología de cadenas de bloque incluye también la red de iluminación (lightning network), la cadena lateral, las transacciones de cadena cruzada, la dirección oculta (Stealth Address), las transacciones confidenciales, etc., y no se limita solamente a la tecnología de consenso distribuido.

### Objetivos de Diseño

La misión de NEO es "Activos Digitales para Todos." Bitcoin y otras cadenas de bloques esperan constituir una alternativa paralela al sistema financiero del mundo real. NEO quiere construir un sistema financiero que pueda salvar la brecha con los activos del mundo real. Al mismo tiempo, el público objetivo de NEO se compone de usuarios de Internet, no solo liberales, geeks y desarrolladores. Para lograr esta visión, NEO necesita utilizar diferentes diseños en el nivel de base.

#### Cumplimiento con el Mundo físico

* **Reemplazar el token con un contrato electrónico**

La práctica de digitalizar activos en el mundo de la cadena de bloques se llama "tokenización." Es decir, el usuario emite un valor personalizado, o un token, y declara que los valores o tokens representan un activo. Luego este token puede ser intercambiado y comercializado de forma similar a una Bitcoin.

Sin embargo, hay muchos defectos en la legalización de un token. La circulación de un token es similar a una transferencia - el token puede ser transferido del remitente al destinatario sin el consentimiento del destinatario. Esta circulación solo es apta para activos simples y sin obligaciones (como el dinero), y no es aplicable al patrimonio, los siniestros y otros activos con derechos y obligaciones complejos. En NEO, para completar la transferencia de activos mediante contratos electrónicos, en la mayoría de los casos se requerirá que el remitente y el destinatario firmen con sus respectivas claves privadas. En algunos casos, los emisores de activos están obligados a participar en la firma. El uso de contratos electrónicos para registrar la transferencia de activos en la cadena de bloque de NEO es simplemente otra forma de transferir activos fuera de línea y no crea ninguna nueva relación legal, resolviendo los defectos legales de la tokenización.

* **Autenticación de la Cuenta**

La información de identidad de nombre real es la base de un gran número de activos del mundo real. En la mayoría de los casos, el contrato legal (contrato jurídicamente vinculante) también requiere una firma real. Cuando las condiciones legales de los participantes de intercambio o de transacción tienen requisitos de nombre real, el usuario debe tener la capacidad de probar su verdadera identidad. Al mismo tiempo, la divulgación de dicha información debe ser controlada por el usuario. Un tercero fuera de la transacción no debe recibir la información sobre la identidad del usuario. Al mismo tiempo, la autenticación de identidad es solo una opción, no obligatoria. Si los participantes de la transacción no requieren los nombres reales de los demás, los usuarios no necesitan autenticarse.

NEO utiliza certificados digitales para implementar la autenticación de usuarios. Los usuarios (particulares u organizaciones) pueden solicitar un certificado digital de la autoridad de certificación (AC) para probar la correspondencia entre la clave pública y la identidad que controlan. NEO no especifica una AC, sino que los participantes de la transacción eligen una AC por sí mismos. Por ejemplo, un usuario chino puede elegir cualquiera de las 38 agencias de AC certificadas por el Ministerio de Industria e Información, o puede elegir una empresa que esté registrada en el intercambio para que sea la AC que verifique y distribuya el certificado.

A diferencia del esquema de implementación de certificados digitales X.509, NEO planea utilizar la cadena de bloques para mantener la lista de revocación de certificados y formar gradualmente un conjunto de sistemas de certificados digitales y esquemas de autenticación de identidad basados en la tecnología de cadena de bloques.

#### Satisfacer las necesidades de las transacciones financieras

* **No romper con la facturación determinística**

Creemos que el mecanismo de consenso existente de la cadena de bloques se puede dividir en dos categorías: "contabilidad única" y "contabilidad conjunta".

Bitcoin, Ethereum, BitShares, etc. utilizan el modelo de "contabilidad única." En el modelo de "contabilidad única", un solo nodo que cumple con ciertas reglas (como el poder, el interés, la votación) es capaz de completar un solo bloque de trabajo de contabilidad. Los otros nodos expresan el reconocimiento del bloque añadiendo un nuevo bloque después de este bloque. La acción de añadir bloques equivale a votar por el historial. Cuando se produce la bifurcación, la historia con más votos (cadena más larga), se convierte en el consenso.

La confirmación de la transacción bajo el modelo de "contabilidad única" es una función probabilística. Por ejemplo, la probabilidad de que una transacción (una transacción se incluya en un bloque) se convierta en un consenso histórico es del 98%, y la probabilidad de convertirse en un consenso histórico después de dos confirmaciones (incluida la transacción de los bloques se añaden después de un bloque) es 99%, mientras que después de seis confirmaciones pueden ser 99.999999%. Pero teóricamente, hay una pequeña posibilidad de fracaso, incluso después de diez mil bloques. Bitcoin y otras cadenas de bloques resuelven el problema mediante la adición de un control manual que corrige la historia, para evitar casos extremos.

Si el modelo de "contabilidad única" es acordado por medio de post-transacciones de voto (bloques adicionales), el modelo de contabilidad conjunta genera un nodo de facturación determinista mediante resolución previa, evitando así la votación posterior al evento y obteniendo certeza. En la cadena pública, esta decisión previa puede ser un voto en cadena. Después de seleccionar un grupo de nodos de facturación (billing), cada nuevo bloque es firmado por estos nodos de facturación. De esta manera, el modelo de "voto posterior, probabilidad de confirmación aumenta con votos" se cambia al modelo de "vota primero, la confirmación es final", y se obtiene la finalidad de transacción ideal (finalidad).

El voto posterior (bloques adicionales) en el modelo de "contabilidad única" es un voto sobre el contenido del bloque en lugar del constructor del bloque, por lo que es adecuado para la cadena pública sin información sobre la identidad. Sin embargo, bajo este modelo, la confirmación final es más débil y no es apta para las transacciones financieras. El modelo de contabilidad conjunta debe introducir un fideicomiso débil en el nodo de facturación, es decir, se cree que no habrá un gran número (por lo general 1/3 o más) del nodo de facturación en colusión. Entonces es necesario comprender la identidad del controlador de estos nodos de facturación para que: en primer lugar, se pueda determinar la reputación y la capacidad técnica y, en segundo lugar, si se produce la colusión, se pueda utilizar la evidencia criptográfica para el seguimiento. Por lo que la contabilidad conjunta es adecuada para la cadena pública y la cadena de afiliados / privado con información de identidad.

Se cree generalmente que el modelo de "contabilidad única" es más utilizable, es decir, que puede seguir funcionando cuando se produce una división de red (como la conexión a Internet de un país con otro país). Pero esta usabilidad solo es aplicable a nodos que siguen una cadena más larga. Cuando se restaura la partición de red, el historial del nodo que sigue a la cadena más corta es reescrito por la cadena larga. Para un nodo que sigue una cadena más corta, esta es una usabilidad ilusoria que se crea sacrificando consistencia.

Se puede decir que el modelo de "contabilidad única" ha elegido el anonimato, para no tener necesidad de ningún nodo de confianza, pero a expensas de la consistencia y la finalidad; el modelo de contabilidad conjunta eligió consistencia y finalidad, pero la identidad de los nodos de facturación es necesaria para obtener confianza débil de los otros nodos.

* **Uso de moneda fiduciaria (fiat) como divisa**

Hay tres funciones principales del dinero: medio de intercambio, unidades de contabilidad y almacenamiento de valor. La Bitcoin y otras monedas digitales encriptados son un buen medio de intercambio, los usuarios pueden, a través de la Bitcoin, participar es la circulación global del valor. Sin embargo, la inelasticidad general de los activos digitales cifrados conlleva una alta volatilidad, por lo que no se realiza la función de una moneda completa, en lo que respecta a la unidad de contabilidad y al almacenamiento de valor. BitShares, Nubits y otros sistemas están intentando diseñar una moneda digital cifrada estable que esté anclada a la moneda fiduciaria, pero no han tenido mucho éxito y tiene un rango estrecho de aplicaciones.

NEO usará moneda fiduciaria como su moneda interna.

* **División del nodo y especialización**

En el diseño original de la Bitcoin original está la horizontalidad. Todos los nodos están involucrados en: la contabilidad (mining), el almacenamiento de datos históricos completos, la difusión de las transacciones. No hay división del trabajo. Sin embargo, en la práctica, lentamente aparecieron las especializaciones en Bitcoin. La contabilidad (mining) evolucionó a partir de la idea de "una CPU un voto" al uso de GPU, FPGA (del inglés ready-made programmable gate array) y ASIC (ASIC) de la máquina de mining. En la actualidad, los diferentes dispositivos de los dispositivos informáticos ASIC no pueden realizar el minado de forma económica. El nodo de la contabilidad se ha especializado totalmente.

Los datos históricos de los últimos siete años que ascienden a decenas de GBs también se han convertido en una carga de almacenamiento. Muchos usuarios comunes ya no están dispuestos a almacenar los datos históricos completos de todo el nodo, sino que en su lugar utilizan la cartera web, la cadena de cartera y así sucesivamente. A pesar de las diversas solicitudes para ejecutar todo el nodo, el número de nodos sigue disminuyendo.

En NEO, nuestro objetivo de diseño es hacer que todo el sistema tenga una clara división del trabajo. El nodo de contabilidad tiene el rol más importante de la cadena de bloque de NEO, asignado por los titulares de AntShare a la producción de bloques y para llegar a un consenso común. Los nodos completos conforman la parte principal de la red de cadenas de bloques de AntShare, que suelen operar en las empresas que prestan servicios externos. Estos nodos guardan los datos históricos completos, escuchan y transmiten transacciones. Los usuarios comunes ejecutan nodos ligeros o actúan como clientes. Los usuarios comunes, a través del navegador o la aplicación móvil, pueden acceder al eco-sistema de los proveedores de servicios AntShare, solo para sincronizar y guardar sus propios datos. Dado que la cadena de bloques de NEO utiliza un sistema de contabilidad conjunta débil basado en la confianza, cada bloque contiene la firma digital del nodo de facturación (billing node). Los usuarios comunes pueden comprobar el bloque actual sin descargar los datos históricos completos. Creemos que este modelo es propicio para la realización de "activos digitales para todos," la visión de NEO.

Cabe señalar que la confianza débil no es la confianza de un solo nodo de contabilidad, sino que confía en que el grupo de nodos no colisionará; esto no es confiar en un cuerpo centralizado cambiante, sino más bien, una forma descentralizada de votar independientemente a quién confiar.

#### Diseño de una arquitectura altamente escalable

* **Baja latencia, alto rendimiento, conectable**

La escalabilidad es un factor importante en la lucha entre la tecnología de cadena de bloques y los métodos tradicionales. Con el fin de alcanzar los objetivos de diseño de anti-auditoría y sin confianza, Bitcoin escogió la Prueba de Funcionamiento (PoW) como su mecanismo de consenso. Sin embargo, esto también trajo alta latencia, problemas de bajo rendimiento. NEO utiliza un mecanismo de consenso que depende de una confianza débil y también crea nodos de contabilidad especializados, lo que garantiza una baja latencia y un alto rendimiento. El mecanismo de consenso del NEO garantiza en gran medida, la lista de nodos profesionales de contabilidad, logrando así la baja latencia y un alto rendimiento.

En la actualidad, el tiempo de bloque de NEO se limita manualmente a 15 segundos. En el futuro, cuando la latencia entre los nodos de facturación sea lo suficientemente baja, se espera que la mayoría de los bloques se completen en 1 segundo. Con unos 100 Mbit/s de ancho de banda y hardware especializado para el cálculo criptográfico, NEO es capaz de manejar miles de miles de transacciones por segundo.

Además, NEO está diseñado para ser modular. Los usuarios pueden cambiar el mecanismo de consenso, el algoritmo ECC / hash, el protocolo de red P2P y otros módulos. Al mismo tiempo, al ver a NEO como un derecho de voto en una organización, NEO puede transformarse fácilmente en una cadena privada o empresarial. Las organizaciones empresariales pueden llevar a cabo pruebas de concepto en la cadena pública de NEO y, si es necesario, migrar rápidamente al modelo de cadena privada / empresarial; por el contrario, las empresas pueden comenzar a utilizar NEO en una cadena privada y si es necesario, migrar rápidamente a la cadena pública sin repercusiones.

* **Diseño jerárquico y transacciones súperconductoras**

Con el fin de soportar una variedad de activos, transacciones de múltiples tipos al mismo tiempo para lograr una buena escalabilidad, es esencial el diseño en capas. Ripple, BitShares, NXT, etc todas son cadenas de bloques con funcionalidad descentralizada, pero sin diseño de capas. La cadena de bloques en sí actúa como el libro mayor y adaptador de las transacciones. En dicha cadena de bloques se registran las órdenes pendientes, las órdenes de retirada, las operaciones de coincidencia y otras operaciones. Este diseño tiene muchos inconvenientes:

   * Los pedidos pendientes y las órdenes de retiro deben esperar la confirmación de bloque, este gran retraso genera una mala experiencia como resultado.

   * Los pedidos pendientes y las órdenes de retiro deben pagar las tarifas de transacción y también aumentar el almacenamiento y el consumo de ancho de banda.

   * Debido a que existe en un intercambio, el orden de las transacciones se vuelve extremadamente importante. Al alinear el libro de pedidos y la coincidencia de transacciones en el nivel de la cadena de bloques, el nodo de contabilidad recibe una potencia mayor. El nodo de contabilidad puede ordenar el intercambio, elegir, y tener la capacidad de ejecución frontal de acuerdo con sus deseos.

Aunque NEO apoya el intercambio de activos en la cadena, la cadena de bloques en sí misma no proporciona la funcionalidad de la cartera de pedidos y la compatibilidad de los pedidos. La cadena solo es responsable de la ejecución y liquidación de la transacción. Nuestro diseño jerárquico coloca el libro de pedidos y la función de coincidencia en la segunda capa, a través de un mecanismo denominado "superconductores" para lograr una función de transacción completa.

Bajo la transacción superconductora, las dos partes no necesitan alojar la propiedad en un intermediario (intercambio tradicional). Los usuarios solo necesitan enviar para el intercambio una orden firmada con sus claves privadas. Después de que el intercambio coincide con las órdenes del comprador y vendedor y las transacciones de difusión, la transacción se completa. De principio a fin, la propiedad no sale del control del usuario, poniendo fin al riesgo moral tradicional. El intercambio bajo el mecanismo de comercio superconductor solo desempeña el papel de la coincidencia de información.

En el mecanismo de comercio con súperconductores, dado que el usuario tiene un control absoluto, puede tomar la iniciativa de duplicar el pedido para que no se pueda resolver. Este problema puede ser resuelto a través del intercambio de la lista negra del usuario como una forma de castigo y disuasión.

### Aplicaciones

#### Recolección de fondos e intercambio equivalente

La cadena de bloques de NEO puede utilizarse para la recolección de fondos. La empresa que recauda fondos puede pasar por diversas plataformas de recaudación de fondos para completarla, pero puede utilizar la inmutabilidad de la cadena de bloques de NEO para hacer públicos sus documentos. Después de la recaudación, la empresa puede utilizar NEO para distribuir las acciones a un gran número de inversores, evitando los engorrosos instrumentos de papel y la mano de obra fuera de línea. A través de la cuota en la cadena de un activo líquido, el usuario puede realizar las transacciones de capital punto a punto a través de NEO. Los intercambios comerciales que cumplan también pueden utilizar NEO, proporcionando a las empresas no cotizadas servicios de negociación de acciones. A través de NEO, las empresas en fase de puesta en marcha pueden obtener valoraciones de mercado, liquidez de capital, los usuarios obtienen acceso al mecanismo de salida para resolver los difíciles problemas de salir de una recaudación de fondos.

Además, NEO también puede facilitar la gestión de la cantidad de dinero recaudado a través de estas campañas. En los últimos años, los países han introducido las leyes y reglamentos pertinentes a la recaudación de fondos. Estas leyes y regulaciones tienden a restringir a los inversionistas en cuanto a la elegibilidad, la inversión y otras provisiones específicas. Por ejemplo, el Título III de la Ley de Empleo, que entró en vigor en abril de 2016, prevé un máximo de 100.000 dólares para la participación de inversión anual máxima de un inversionista individual. A través de NEO se puede facilitar la regulación de la cantidad total de control limitado.


#### Participaciones de los empledos y gestión de la estructura de capital

Las empresas que utilizan el plan de propiedad de acciones para empleados (ESOP, por sus siglas en inglés) y que necesitan la administración de la tabla de límite máximo pueden utilizar NEO para llevar a cabo la administración de las acciones. Algunas de las compañías en los Estados Unidos ya han comprado un proveedor de servicios céntrico como eShares para llevar a cabo la gestión electrónica del sistema, pero el sistema centralizado tiene muchos inconvenientes. Por ejemplo, eShares es un único punto de fallo. Si el servicio eShares está inactivo o en lista negra, entonces está en juego la información de capital de las compañías que utilizan eShares.

La tecnología basada en bloques es más económica y más segura que un sistema central. No hay un único punto de fallo, por lo que las empresas que la utilizan no tienen de qué preocuparse. La función del contrato inteligente proporciona a la empresa flexibilidad para transferir el control o la propiedad. La empresa puede limitar el capital para que sea mantenido solo por los empleados y los inversores designados, puede establecer la flexibilidad para permitir la transferencia de acciones o la proporción de las transacciones. Por ejemplo, puede configurarse para permitir a los empleados transferir hasta el 10% de sus propias acciones cada año.

En la actualidad, la solución para las empresas de consultoría que ofrecen soluciones ESOP se logra a través de instrumentos de papel. A través de NEO, estas firmas de consultoría pueden ofrecer a los clientes una poderosa herramienta para administrar digitalmente la propiedad.


#### Préstamos personales

La plataforma de préstamos P2P utilizando NEO puede resolver muchos problemas existentes, tales como la opacidad de la información, la información incompleta, la liquidez de la deuda y así sucesivamente.

En primer lugar, el modelo existente de la base de datos de la plataforma de préstamo P2P interna es la única fuente de reclamaciones del acreedor, en caso de manipulación de hackers, corrupción de los datos, colapso de la plataforma y otros eventos, es difícil que los acreedores prueben su caso. En el 2015-2016, la ola de colapsos de la plataforma líder de préstamos P2P en China expuso este riesgo. Una vez que los acreedores descubren que las plataformas no están disponibles, se ven en la situación en la que son incapaces de demostrar sus reclamaciones.

En segundo lugar, la plataforma de préstamo P2P para el límite de crédito del prestatario a menudo se limita a la propia plataforma. Por ejemplo, una plataforma, a través del proceso de crédito, descubre que la capacidad de reembolso del prestatario de 100.000 yuanes, entonces el límite de crédito del prestatario en la plataforma es de 10 millones. Pero esto no puede evitar que el prestatario en la plataforma n obtenga préstamos, alcanzando n veces los 10 millones de deuda. La función de libro mayor de la cadena de bloques NEO permite a las plataformas de préstamo P2P compartir la línea de crédito del prestatario. Esto es similar a cómo NEO se puede utilizar para controlar la cantidad de acciones que un inversionista puede comprar.

Por último, mediante el uso de NEO para registrar las solicitudes de préstamos P2P, las reclamaciones se convierten en transferibles, colaterales e incluso programables. Los derechos de los acreedores no solo pueden transferirse dentro de la plataforma, sino también a través de plataformas, aumentando su liquidez. Con los derechos de los acreedores volviéndose transferibles, las deudas a largo plazo se vuelven más atractivas. Los usuarios compran deuda a largo plazo sin preocupaciones, disfrutan de altas tasas de interés, sin miedo a las emergencias. A través de la función de transferencia de NEO, los bonos a largo plazo pueden ser descontados o hipotecados.

Además, el uso de NEO para gestionar el patrimonio de las empresas permite incluso utilizar el NEO para hipotecar acciones o emitir bonos corporativos.

#### Gestión de puntos

Las aerolíneas, operadores, bancos, restaurantes y muchas otras instituciones comerciales emiten sus propios puntos. A través de un sistema puntual, las empresas fomentan la retención de los usuarios y el consumo múltiple.

La base de datos de las organizaciones emisoras son silos de datos (silo de información). La organización A no puede obtener información del sistema de puntos de otra organización de ninguna manera sin confianza, por lo que es difícil lograr la interoperabilidad de los puntos entre los dos. La distribución de puntos a través de la cadena de bloques de NEO puede ser revelada de forma transparente y es accesible de forma confiable por cualquier persona, limitando los poderes al emisor. Las necesidades de intercambio del usuario y las ganancias del fabricante del mercado conformarán una variedad de puntos en el mercado comercial, activando así el potencial oculto en este sistema.


#### Finanzas de la cadena de suministros

Las finanzas de la cadena de suministro abarcan una amplia gama de modelos de negocio y vínculos, desde la producción, el financiamiento del comercio, los recibos de almacén, el financiamiento de cuentas por cobrar a la cadena de suministro de facturas corporativas, financiamiento de crédito corporativo y otros vínculos de negocios financieros. Con base en la tecnología de cadena de bloques para proveer una plataforma de registro de la información comercial distribuida y sin alteraciones, se puede participar en la certificación, la verificación de transacciones y la verificación de marcas de tiempo, la solicitud de financiamiento bancario, los materiales de financiamiento corporativo y otros enlaces para proporcionar una solución verdadera y efectiva y de bajo costo , mejorando así la eficacia general de las finanzas de la cadena de suministro.


#### Otros

Las funciones de activos digitales también se pueden utilizar para distribuir acciones, pruebas financieras, etc.; las confirmaciones digitales pueden utilizarse como recibos, acuerdos; las funciones de descentralización pueden utilizarse para intercambios de mercancías a gran escala, y los intercambios de divisas.

### Estatus Legal

(Para ser revisado)

NEO no tiene un pago universal en términos de una moneda original. NEO no es una especie de moneda digital, sino un acuerdo en cadena de bloques, [Editar: esto es confuso: porque no hay disputa monetaria legal, no hay cinco ministerios "en la prevención de notificación de riesgos de la bitcoin" que se refiere a la moneda virtual, con bancos, agencias de pago].

Los usuarios individuales y las organizaciones pueden ser certificados por el organismo de certificación autorizado por el gobierno. El registro del patrimonio en la cadena es firmado electrónicamente por una empresa certificada con un nombre real. La cesión y negociación de las acciones son realizadas por el cedente, el cesionario y la sociedad. Antes de la firma de las tres partes, la Compañía tiene la obligación de asegurar que la transferencia y la transacción de las acciones estén en consonancia con las disposiciones de la Ley de Sociedades Anónimas, que se requieren para obtener el consentimiento original de los accionistas originales, el derecho de los accionistas originales a la suscripción y la limitación del número de accionistas. La naturaleza de la transferencia de capital y la transacción es un contrato electrónico en el que las partes están involucradas en firmas electrónicas.

NEO ha incorporado KYC (identidad de usuario) y AML (anti-lavado de dinero). Pagos a terceros, bancos y otras instituciones financieras pueden ser utilizados para cumplir con el acuerdo. Teniendo en cuenta la posibilidad de perder la clave, NEO también diseñó un mecanismo para la recuperación de activos - si inmediatamente perdiste una dirección de la clave privada correspondiente, todavía puedes recuperar los activos sin la ayuda de un tercero.


## Modelo económico

### Activos y tasas del sistema

Existen dos activos integrados en el sistema: NEO y GAS. NEO representa la propiedad de la cadena de bloque, que se utiliza para la contabilidad electoral, para obtener GAS, etc. Las GAS representan el derecho de usar la cadena de bloque, y se utilizan para pagar los honorarios de varios sistemas en la cadena.

#### Coste del sistema

Escribir datos en la cadena de bloqueos requiere el pago de una pequeña cantidad de GAS como costo del sistema, que se divide en dos categorías:

  **La cuota de contabilidad (bookkeeping) cobrada por el contador**
  
  Cuando se escribe una transacción en la cadena de bloques, la transacción generalmente requiere algunas GASs como
  tasa por la cuenta. La comisión contable es cargada por el contador para subsidiar el almacenamiento, el ancho de banda 
  y el gasto del nodo de contabilidad. 
  
  Si la tasa se cobra, y cuánto se cobra, es determinado por los contadores. Una transacción puede ser libre, siempre y
  cuando más de 2/3 de los contadores están dispuestos a escribir la transacción. Por lo tanto, las organizaciones que
  utilizan NEO masivamente pueden pagar a los bookkeepers con _currency offchain_, reduciendo la necesidad de
  pagar con GAS.
  
  **Cargos adicionales para los titulares de NEO**

  Los cargos por servicios adicionales se refieren al costo de usar la cadena de bloques de NEO para completar 
  ciertas funciones avanzadas y se pagan con GAS. Los tipos de transacciones que actualmente requieren cargos 
  por servicios adicionales son: la creación de activos, el registro de candidatos. Se requerirán tasas adicionales 
  para actualizaciones futuras, tales como cambios de activos, cancelaciones de activos y congelación de activos.

  Los cargos por servicios adicionales se registrarán de acuerdo con la proporción de NEO mantenida inmediatamente en 
  la dirección de los titulares de NEO. Los titulares de NEO pueden reclamar las monedas registradas a 
  sus nombres en cualquier momento.


#### NEO

NEO, abreviado como ANS.

Un total de 100 millones de NEO, que representan la propiedad de la cadena. 100 millones se crearán en el Bloque Génesis y se distribuirán en consecuencia. El importe total de las acciones de NEO es constante en 100 millones y no puede aumentarse. La unidad más pequeña de NEO es 1 NEO y no se puede dividir.

El principal uso de las acciones de NEO:

* Voto para elegir al contador.
* Obtener GAS generadas por nuevos bloques.
* Obtener cargos de servicio adicionales para GAS.
* Votar para decidir el asunto de la cadena de bloques de NEO.

#### GAS

Un total de 100 millones de GAS se producirá, representando el derecho a utilizar la cadena. La GAS se generará con la formación de cada nuevo bloque, de acuerdo con una tasa decreciente de generación, que llevará alrededor de 22 años para que la cantidad de GAS crezca de 9 a 100 millones.

El objetivo principal de las GAS son:

* Pagar los honorarios de pago de la cadena de bloques de NEO.
* Pagar una tarifa de servicio adicional para la cadena de la pequeña área del bloque.
* Como depósito para el depósito del candidato.

### Asignación y distribución

#### El mecanismo de distribución de NEO

Se creó el 100% del total de acciones de NEO en la creación de un bloque. Antes de la creación de NEO, el equipo estableció ciertas reglas sobre la distribución de las acciones de NEO.

Alrededor del 10% de las acciones de NEO fueron asignadas a los primeros partidarios de NEO en junio de 2014, ganando 600.000$ en fondos semilla. De los cuales 400.000 yuanes por un número de individuos después de una valoración general de 5 millones de inversión y 200.000 yuanes por las instituciones de capital de riesgo Ra Li capital después de una valoración general de 10 millones de yuanes de la inversión. Los contribuyentes individuales también proporcionan todo tipo de apoyo a tiempo completo o a tiempo parcial sin cargo alguno.

Aproximadamente el 17% de las acciones de NEO se completaron en octubre de 2015 para ICO 1 y se asignaron a los participantes, con una ganancia de más de 2.100 bits. De los cuales unos 1.200 bitocoins provienen de inversores individuales y unos 900 son de un único inversor institucional.

Aproximadamente el 23% de las NEO se asignarán a los participantes en el ICO 2 lanzado en agosto de 2016. El ICO no establece el precio ni el techo, sino el diseño del mecanismo de retorno, ver las reglas de la OIC.

El 50% restante de las acciones de NEO retenidas por el equipo de NEO, estará en la red de NEO después del uso del contrato inteligente de NEO bloqueado por 1 año. El período de bloqueo es de 1 año, esta parte de NEO se utilizará para mantener el desarrollo a largo plazo de NEO.

Los primeros partidarios, los participantes del ICO 1 y las acciones de NEO asignadas a los participantes del ICO 2 estarán disponibles inmediatamente después de la operación de la cadena de bloque (small-ants blockchain). Se espera que la cadena de bloques de pequeñas (small nest) se ejecute en el cuarto trimestre de 2016.

#### El mecanismo de lanzamiento de NEO

Las GAS se producen con la generación de cada nuevo bloque. La cantidad inicial de GAS es cero y crecerá hasta el límite total de 100 millones después de aproximadamente 22 años. El intervalo entre cada bloque de NEO es de unos 15 segundos, aproximadamente 2 millones de bloques se generan en un año.

En el primer año (Bloque No. 0 - No. 2,000,000), cada bloque generará 8 ANC; en el segundo año (Bloque No. 2.000.000 - 
No. 4.000.000), cada bloque generará 7 ANC; la cantidad de ANC generado disminuye en 1 cada año hasta el año 8 donde cada bloque genera solo 1 ANC. A partir de entonces, la tasa se mantiene constante hasta alrededor de 22 años en el bloque de 44 millones, la cantidad total de ANC alcanza los 100 millones, momento en el que dejarán de generarse ANC.

Según esta curva, el 16% de las ANC se creará en el primer año, el 52% se creará al final del cuarto año, el 72% de las ANC al final del octavo año.

Las ANC se distribuirán proporcionalmente a las direcciones ANS correspondientes. Los titulares de AntShare pueden reclamar estas ANC en cualquier momento. Por ejemplo, si alguien tiene el 1% de la red completa, el usuario podrá obtener 8/100 = 0.08 GAS por bloque por aproximadamente 460.8 GAS al día.


## Arquitectura de la tecnología

### Usuario

#### Clave privada, clave pública

Clave privada: un hash de 256 bits generado por el usuario que debe guardarse y no exponerse. La clave privada es la prueba de propiedad de la cuenta de usuario y la propiedad del activo en la cuenta.

Clave pública: Cada clave privada viene con una clave pública coincidente. Las claves públicas en NEO son generadas por la clave privada a través del algoritmo de curva ECC (Elliptic Curve Cryptography). Los algoritmos utilizado por NEO son secp256r1 y SM2 (algoritmo criptográfico comercial chino).


#### Script, direcciones

Script: NEO utiliza un sistema de secuencias de comandos OP_CODE similar al de Bitcoin. El OP_CODE en NEO es un conjunto completo de instrucciones Turing. Por ejemplo, los siguientes dos scripts se pueden utilizar para verificar las firmas múltiples:

```
OP_M (public key list) OP_N OP_CHECKMULTYSIG
```

```
OP_PUSHBYTES M (public key list) OP_PUSHBYTES N OP_CHECKMULTYSIG
```

Direcciones: La dirección es el valor hash del script. La forma de la dirección es la siguiente:

```
AM2Y8aSWh3LTwQBoZCNSVNCF9eqVt2vmVX (secp256r1 / SHA256 algorithm)
SSYfWvN36FsWejmGXyhBtP5iKq9EGuaEPr (SM2 / SM3 algorithm)
```
El algoritmo hash soportado por el NEO es SHA256 y SM3 (algoritmo de contraseña comercial chino).

#### Cuenta y dirección de la cuenta

#### Account and account address

Una cuenta es una combinación de un número de (1-16) claves públicas. La cuenta más básica consiste en una clave pública cuya dirección de cuenta es su dirección de multi-firma 1-de-1.

En diseños más avanzados, la cuenta puede estar compuesta por dos claves públicas, generadas por la dirección 2-de-2 de varias firmas para la dirección de la cuenta. De las dos claves públicas, la que tiene el valor menor se convierte en la clave de pago, la más grande se convierte en la clave de consulta. La clave privada de consulta permite al usuario leer el saldo del activo y la información histórica de la transacción que puede controlar la cuenta. La coexistencia de ambas claves privadas le da al usuario un control completo sobre todos los activos de la cuenta. Combinado con el sistema de direcciones de NEO, los usuarios pueden proporcionar al mundo exterior una dirección fija como punto de entrada sin sacrificar su privacidad.

En la cartera del cliente, las claves privadas se utilizan para funciones independientes. La interfaz será similar a la banca en línea, utilizando una clave privada para iniciar sesión y usar la clave privada de pago para confirmar las transacciones.


#### Autenticación

El usuario (persona u organización) puede solicitar la autenticación de identidad a la autoridad de certificación AC para proporcionar información de identidad verdadera a otros participantes de la transacción. Al solicitar la autenticación, el usuario proporciona a la AC la clave pública y los documentos de identidad firmados con la clave privada correspondiente. Después de la verificación, la AC emite un certificado digital al usuario, que está firmado por la AC, que contiene la clave pública del usuario y la información de identidad. El certificado digital demuestra la correspondencia uno a uno entre la clave pública y la identidad del usuario.

Cuando un usuario utiliza NEO, la transacción se firma con la clave privada correspondiente a la clave pública. La firma está de acuerdo con la definición de "firma electrónica fiable" en la "Ley de Firma Electrónica" de China y es jurídicamente vinculante.

#### Protección de la Privacidad

Hay algunas contradicciones dentro de la cadena de bloques en cuanto a la necesidad de apertura y privacidad, pero a través de algunas técnicas de criptografía, podemos resolver el problema de protección de la privacidad.

El esquema de protección de privacidad de NEO combina la dirección para ocultar firmas múltiples, la adición de cifrado homomórfico y otras técnicas líderes de criptografía. Aparte de los participantes directos de la transacción, otros terceros pueden verificar la validez de la transacción, pero no pueden conocer la identidad del participante ni el monto de la transacción.

Los datos de la transacción bajo múltiples firmas siguen estando disponibles públicamente, pero no hay ninguna capacidad de enlace analítica entre cada transacción. Incluso si la misma persona te envió una serie de transacciones, estas transacciones se dispersarán a través de una serie de direcciones no relacionadas, nadie más que tú será capaz de descubrir o demostrar que estas direcciones te pertenecen. NEO se basa en el trabajo realizado en BIP63 y agrega la funcionalidad de direccionamiento multi-sig y stealth, creando una función de dirección sigilosa multi-sig. Esto se explicará en detalle en otro artículo.

Las direcciones ocultas de varias firmas pueden incluir las identidades del usuario pero no pueden proteger las cantidades de transacción. NEO utiliza medios de cifrado homomórficos aditivos para ocultar la cantidad de la transacción, pero permite a los nodos de la red verificar la validez de la transacción. Los otros nodos de la red pueden verificar que el saldo del activo en toda la red no se modifica después de que se complete la transacción de un activo, comprobando así la validez de la transacción sin conocer el monto de la transacción específica.

### Activos

Los activos del bloque NEO pueden dividirse en activos del sistema y activos emitidos por los usuarios. Los activos del sistema representan los derechos en el acuerdo de NEO. Los activos del usuario representan los derechos de los activos fuera de la cadena de bloques de NEO.

#### Activos del sistema

Los activos del sistema incluyen NEO y las GAS. NEO representa la propiedad del sistema, las GAS representan el derecho a utilizar el sistema. La forma específica de NEO y las GAS se ha descrito en el capítulo "(b) el modelo económico" y no se repetirá.

#### Activos emitidos por el usuario

Cualquier usuario puede emitir activos. Los activos se crean y distribuyen en dos pasos. Después de la creación, los activos se registran en la cadena de bloques pero en realidad no se generan en ninguna dirección; después de la distribución, los activos entran realmente en la dirección.

Moneda: El acuerdo blockchain de NEO introduce la moneda externa en forma de gateway. La transferencia de moneda no requiere una firma de destinatario.

Activos de renta variable: Los activos de renta variable se utilizan como acciones de una empresa representativa (o acciones de la sociedad anónima) para emitir activos. La transferencia o transacción de un activo de capital requiere la firma del receptor.

Activos de Derechos del acreedor: Los derechos del acreedor se usan como pasivos monetarios que representan a individuos u organizaciones.

Otros activos: otros tipos de activos, activos que los fundadores pueden personalizar.

### Comercio

Una transacción es un asunto que invoca o cambia los derechos de cualquier activo de la cadena. Existen varios tipos de transacciones diseñadas en el sistema, cada una de las cuales contiene una lista de entradas, una lista de resultados, una lista de firmas y datos específicos relacionados con el tipo de transacción.

#### Transacciones relacionadas con activos

Creación de activos: se utiliza para crear un nuevo usuario para emitir activos. El usuario puede definir el tipo, nombre, total, etc. del activo y especificar la cuenta de administrador del activo. La creación de activos requiere el consumo de un cierto número de comprobantes de registro así como un cargo por servicio adicional.

Distribución de Activos: Dentro del límite del monto total fijado por el creador del activo, el activo se crea en la dirección especificada por el emisor. La asignación de activos puede completarse en una toma o en lotes.

Cambio de activos, cancelación, congelación: aún no se admite, se admitirá en futuras versiones.

#### Transacciones relacionadas con la transferencia de activos

Contrato: Especifica a todos los participantes de la transacción y determina si se requiere que confirmen su aceptación en función del tipo de activo involucrado en la transacción. El destinatario puede elegir entre aceptar (firmar) o rechazar (ignorar) el contrato.

Transacciones comisionadas: no especifica al destinatario, sino que especifica a un agente. El agente es responsable de hacer coincidir a los destinatarios. Las "transacciones superconductoras" se realizan mediante dichos métodos. La estructura de transacción de la transacción superconductora es la siguiente:

```c#
public class Order // order
{
    public UInt256 AssetId; // Asset
    public UInt256 ValueAssetId; // Unit Price
    public UInt160 Agent; // agent
    public Fixed8 Amount; // Total amount of transactions
    public fixed8 Price; // transaction price
    public UInt160 Client; // client
    public transactionInput[] Inputs; // transaction input
    public byte[][] Scripts; // signature list
}
```

#### Transacciones relacionadas con la contabilidad

Inscripción, retiro del Candidato: El usuario que desee registrarse como candidato contador debe pagar una tarifa de servicio adicional y, al mismo tiempo, congelar un vale registrado en la dirección de la cuenta. Los candidatos pueden usar los cupones congelados en cualquier momento, pero si es así, serán descalificados y necesitarán volver a registrarse como candidatos. El usuario debe estar preparado para participar en la contabilidad antes de registrarse como candidato. Los candidatos pueden ser elegidos como cuentas oficiales en cualquier momento.

Cuenta electoral: véase el mecanismo contable

#### Tarifas de transacción

Los costos de transacción se dividen en comisiones de contabilidad y cargos por servicios adicionales, que se pagan en GAS. Se especifican en el capítulo del "modelo económico", no se repetirán.

### Mecanismo de contabilidad

#### Cadena de bloques

NEO utiliza una cadena similar a Bitcoin para registrar datos.

La cadena de bloques puede imaginarse como un libro, y cada bloque es una página de cuentas en el libro. Cada página contiene las transacciones de un período de tiempo preestablecido. La cadena de bloques de NEO genera un bloque cada 15 segundos. El nuevo bloque se une al bloque anterior y forma una estructura de cadena. Cada bloque contiene la información de la transacción que se produce dentro de 15 segundos, así como la demás información necesaria de recuperación y verificación.

La estructura de datos de bloques del bloque de hormigas pequeñas se muestra como sigue:


```c#
public class Block // block
{
     public uint Version; // version
     public UInt256 PrevBlock; // linked block
     public UInt256 MerkleRoot; // The hash value of the transaction list
     public uint Timestamp; // timestamp
     public uint Bits; // keep fields
     public ulong nonce; // random number
     public UInt160 NextMiner; // next block
}
```

Para más información del mecanimso de consenso, consultar [Consenso](https://www.neo.org/Files/66c6773b.pdf)
