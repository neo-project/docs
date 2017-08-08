
# Documento Técnico del NeoContract 

## 1. Prefacio

Los contratos inteligentes se refieren a cualquier programa de computadora que pueda ejecutar automáticamente los términos de su contrato preprogramado. La idea del contrato inteligente fue propuesta por primera vez por el criptógrafo Nick Szabo en 1994, por lo que es tan antigua como la propia Internet. Debido a la falta de un entorno de ejecución fiable, los contratos inteligentes no han sido utilizados ampliamente.

En 2008, un hombre bajo el nombre de Satoshi Nakamoto lanzó Bitcoin, y esbozó los conceptos fundamentales de una cadena de bloques. Dentro de la cadena de bloque Bitcoin, Nakamoto utiliza un conjunto de lenguajes de scripting para ayudar a los usuarios a obtener más flexibilidad en el control de sus cuentas personales y el proceso de transferencia, que finalmente se convirtió en la forma embrionaria de un sistema de contrato inteligente.

En 2014, un adolescente llamado Vitalik Buterin dio a conocer Ethereum, que proporciona un sistema de contrato basado en la cadena, Turing-complete, inteligente que se puede utilizar para crear una variedad de aplicaciones descentralizadas de cadena de bloques.

La cadena de bloques NEO es una plataforma de activos y aplicaciones digitales, que proporciona un nuevo sistema de contrato inteligente, NeoContract. En el núcleo de la plataforma Neo, la red ofrece múltiples funciones como capacidades de activos digitales, NeoAsset e identidad digital, NeoID, permitiendo a los usuarios participar fácilmente en negocios digitales y no se limitan a la simple emisión de fichas nativas en la red de la cadena de bloques.

Este artículo presentará las características del Neo Contract y explorará los detalles no técnicos. Consulta la documentación técnica para obtener detalles técnicos, consulta [aquí](http://docs.neo.org)

## 2. Características
### 2.1 Certeza

Si un programa se ejecuta en equipos diferentes o en diferentes horas en el mismo equipo, el comportamiento del programa es determinista si se garantiza que la misma entrada debe producir la misma salida y viceversa.


La cadena de bloques es un almacenamiento multipartito y un método computacional, donde los datos dentro de este sistema distribuido son el resultado de cálculos fiables, que no pueden ser manipulados. Los contratos inteligentes operan dentro de la red de cadenas de bloques, distribuida en los multi-nodos. Si un contrato inteligente no es determinista, los resultados de los diferentes nodos pueden ser inconsistentes. Como resultado, el consenso entre los nodos no puede ser alcanzado, y la red se estanca. Por lo tanto, en el diseño de un sistema de contrato inteligente, es necesario descartar cualquier factor que pueda conducir a un comportamiento no determinista.

### 2.1.1 Tiempo

La obtención de la hora del sistema es una función del sistema muy común, que puede ser aplicada en gran medida en ciertos procedimientos contractuales sensibles al tiempo. Sin embargo, la obtención del tiempo del sistema es una función del sistema no determinista, y es difícil obtener un tiempo unificado y preciso en un sistema distribuido, ya que los resultados de los diferentes nodos serán inconsistentes. El NeoContract proporciona una llamada de sistema basada en bloques que trata la cadena de bloques por completo, como un servidor de marca de tiempo y obtiene la marca de tiempo cada vez que se genera un bloque nuevo. En promedio, la red NEO genera un bloque nuevo cada 15 segundos, por lo que el contrato se ejecuta aproximadamente al mismo tiempo que el último tiempo de bloque, más o menos 15 segundos.

### 2.1.2 Aleatoriedad

Muchos programas de contratos inteligentes, tales como contratos de juegos de azar y juegos pequeños, utilizan funciones de números aleatorios. Sin embargo, las funciones de números aleatorios son una función típica no determinista, y cada llamada al sistema obtendrá resultados diferentes. En un sistema distribuido, hay muchas maneras de resolver este problema: En primer lugar, la misma semilla aleatoria se puede utilizar para todos los nodos, de modo que la secuencia de retorno de toda la función aleatoria sea determinista, pero este método expone todo el resultado aleatorio por adelantado, reduciendo en gran medida el valor práctico del número aleatorio. Otra posible solución es permitir que todos los nodos se comuniquen de manera colaborativa para generar números aleatorios. Esto puede lograrse utilizando técnicas criptográficas para producir un número aleatorio determinado, pero la desventaja radica en el rendimiento que es muy pobre y la necesidad de una sobrecarga de comunicación adicional. Un proveedor de números aleatorios centralizado puede utilizarse para generar números aleatorios que garantice la coherencia y el rendimiento, pero el inconveniente de este enfoque es obvio; Los usuarios tendrán que confiar incondicionalmente en el proveedor centralizado de números.

Hay dos maneras de generar un número aleatorio en NEO:

1. Cuando se genera cada bloque, el nodo consenso alcanzará un consenso sobre un número aleatorio y lo llenará en el campo Nonce del nuevo bloque. El programa de contrato puede obtener fácilmente el número aleatorio de cualquier bloque, haciendo referencia al campo Nonce; 
2. El programa de contrato puede utilizar el valor hash del bloque como un generador de números aleatorios, porque el valor hash del bloque tiene cierta aleatoriedad que le es inherente. Este método puede usarse para obtener un número aleatorio débil.

#### 2.1.3 Fuente de datos

Si un programa obtiene datos en tiempo de ejecución, puede convertirse en un programa no determinista si el origen de datos proporciona datos que no son determinísticos. Por ejemplo, al utilizar diferentes motores de búsqueda para obtener los 10 primeros resultados de búsqueda de una palabra clave en particular, esto puede producir diferentes resultados, en varios órdenes de clasificación, si se utilizan direcciones IP diferentes.

Para los contratos inteligentes, NEO proporciona dos tipos de fuentes de datos deterministas:

* Libro Mayor de Cadena de Bloques

El procedimiento de contrato puede acceder a todos los datos de toda la cadena de bloques a través de servicios interoperables, incluyendo bloques completos y transacciones, y cada uno de sus campos. Los datos sobre los bloques son deterministas y consistentes, por lo que se puede acceder con seguridad a través de los contratos inteligentes.

* Espacio de almacenamiento de contrato

Cada contrato desplegado en la red NEO, tiene un área de almacenamiento privado a la que solo se puede acceder a través del contrato mismo. El mecanismo de consenso de NEO garantiza la coherencia del estado de almacenamiento, de cada nodo en la red.
Para situaciones en las que se requiere acceso a datos de cadena no bloqueada, NEO no proporciona una forma directa de interactuar con estos datos. Los datos que no sean de una cadena de bloque tendrán que ser transferidos a la cadena de bloques NEO usando transacciones, y posteriormente traducidos a cualquiera de las fuentes de datos antes mencionadas, para ser accesibles a través de los contratos inteligentes.

#### 2.1.4 Llamada de contrato

Los contratos inteligentes en NeoContract tienen la capacidad de llamarse entre sí, pero no se llaman recursivamente. La recursión se puede lograr dentro del contrato, pero no puede cruzar los límites del contrato actual. Además, la relación de llamada entre contratos debe ser estática: no se puede especificar el destino en tiempo de ejecución. Esto permite que el comportamiento del programa sea determinado completamente antes de la ejecución y que su relación de llamada sea definida completamente antes de permitir su ejecución. Con base en esto, varios contratos pueden ser divididos dinámicamente para lograr la ejecución paralela.

### 2.2 Alto rendimiento

El entorno de ejecución de un contrato inteligente desempeña un papel integral en su desempeño. Cuando analizamos el rendimiento de cualquier entorno de ejecución, hay dos indicadores principales que son críticos: 

1. Velocidad de ejecución de la instrucción.
2. Velocidad de arranque del propio entorno de ejecución. 

Para los contratos inteligentes, el entorno de ejecución es a menudo más importante que la velocidad de ejecución de la instrucción. Los contratos inteligentes están más involucrados en la operación IO de la lógica, para determinar las instrucciones, en la que la implementación de estas instrucciones se puede optimizar fácilmente. Cada vez que se llama al contrato inteligente, tiene que iniciar una nueva máquina virtual / contenedor. Por lo tanto, la velocidad de ejecución del propio entorno (inicio de una máquina virtual / contenedor) tiene un impacto importante en el rendimiento del sistema de contrato inteligente.

NEO utiliza una NeoVM ligera (NEO Virtual Machine) como su entorno para la ejecución de contratos inteligentes, que tiene un arranque muy rápido y ocupa muy pocos recursos, perfecto para programas cortos como contratos inteligentes. El uso de la compilación y el almacenamiento en caché de contratos inteligentes de hotspot con JIT (compilador en tiempo real) puede mejorar significativamente la eficiencia de las máquinas virtuales.

### 2.3 Escalabilidad

#### 2.3.1 Alta concurrencia y partición dinámic

Cuando se discute la escalabilidad de un sistema, esto involucra dos áreas principales: la escala vertical y escala horizontal. El escalado vertical se refiere a la optimización del flujo de trabajo de procesamiento, permitiendo al sistema aprovechar al máximo la capacidad del equipo existente. Con este enfoque, los límites del sistema se alcanzan fácilmente, ya que la capacidad de procesamiento en serie se basa en el límite de hardware de un solo dispositivo. Cuando necesitamos escalar el sistema, ¿hay una manera de transformar el sistema en serie en un sistema paralelo? Teóricamente, simplemente habría que aumentar el número de dispositivos, y se podría alcanzar una escalabilidad casi ilimitada. ¿Podríamos conseguir escalamiento ilimitado en redes de cadenas de bloques distribuidas? En otras palabras, ¿puede una cadena de bloques ejecutar programas en paralelo?

La cadena de bloques es un libro distribuido, que registra una variedad de datos de estado, y también las reglas que gobiernan los cambios en el estado de estos datos. Los contratos inteligentes se utilizan como vehículos, para registrar estas reglas. Las cadenas de bloques pueden procesar programas en paralelo, solo si, múltiples contratos inteligentes se pueden ejecutar simultáneamente y de una manera no secuencial. Básicamente, si los contratos no interactúan entre sí, o si el contrato no modifica los mismos datos de estado, al mismo tiempo, su ejecución no es secuencial y se puede ejecutar simultáneamente. De lo contrario, solo puede ejecutarse en serie, siguiendo un orden secuencial, y la red no puede escalar horizontalmente.

Con base en el análisis anterior, podemos diseñar fácilmente un "escalamiento ilimitado" en sistemas de contratos inteligentes. Todo lo que tenemos que hacer es establecer reglas sencillas:

* Un contrato inteligente solo puede modificar el registro del estado del contrato al que pertenece;
* En la misma transacción lote (bloque), un contrato solo se puede ejecutar una vez;

Como resultado, todos los contratos inteligentes pueden procesarse en paralelo ya que el orden secuencial es irrelevante para el resultado. Sin embargo, si un "contrato inteligente solo puede modificar el registro del estado del contrato al que pertenece", implica que el contrato no puede llamarse entre sí. Cada contrato, es una isla aislada; si "En el mismo lote de transacción (bloque), un contrato solo se puede ejecutar una vez", esto implica que un activo digital emitido con un contrato inteligente, solo puede manejar una transacción por bloque. Este es un mundo de diferencia con los objetivos de diseño originales de los contratos "inteligentes," que dejarían entonces de ser "inteligentes." Después de todo, nuestros objetivos de diseño incluyen tanto la llamada mutua entre contratos, como la ejecución múltiple de la misma llamada, en el mismo bloque.

Afortunadamente, los contratos inteligentes en NEO tienen una relación de llamada estática y no se puede especificar el destino de la llamada en tiempo de ejecución. Esto permite que el comportamiento del programa sea determinado completamente antes de la ejecución y que su relación de llamada se defina completamente antes de permitir su ejecución. Exigimos que cada contrato indique explícitamente los contratos que probablemente se invocarán, de modo que el entorno operativo pueda calcular el árbol completo de llamadas antes de ejecutar el procedimiento del contrato y la ejecución de particiones de los contratos, en función del árbol de llamadas. Los contratos que pueden modificar su propio registro de estado, se ejecutan de forma secuencial dentro de la misma partición, con lo que se pueden ejecutar diferentes particiones en paralelo.

#### 2.3.2 Bajo Acoplamiento

El acoplamiento es una medida de la dependencia entre dos o más entidades. El sistema NeoContract utiliza un diseño de bajo acoplamiento bajo, que se ejecuta en el NeoVM y se comunica con los datos de la cadena no bloqueada a través de la capa de servicio interoperable. Como resultado, la mayoría de las actualizaciones a las funciones de los contratos inteligentes se puede lograr mediante el aumento de la API de servicios interoperables.

## 3. Uso del Contrato



### 3.1 Verificación de Contratos

A diferencia del sistema de cuentas de clave pública utilizado en Bitcoin, el sistema de cuentas de NEO utiliza el sistema de cuentas de contrato. Cada cuenta en NEO corresponde a un contrato de verificación y el valor hash del contrato de verificación es la dirección de la cuenta; la lógica del programa del contrato de verificación controla la propiedad de la cuenta. Al transferir desde una cuenta, primero se debe ejecutar el contrato de verificación para esa cuenta. Un contrato de validación puede aceptar un conjunto de parámetros (generalmente una firma digital u otros criterios) y devolver un valor booleano después de la verificación, indicando el éxito de la verificación al sistema.

El usuario puede implementar previamente el contrato de verificación en la cadena de bloques o publicar el contenido del contrato directamente en la transacción durante el proceso de transferencia.

### 3.2 Contrato de Aplicación

El contrato de aplicación se activa mediante una transacción especial, que puede acceder y modificar el estado global del sistema y el estado privado del contrato (área de almacenamiento) en tiempo de ejecución. Por ejemplo, se puede crear un activo digital global en un contrato, votar, guardar datos e incluso crear dinámicamente un nuevo contrato cuando se ejecuta el contrato.
#La ejecución del contrato de aplicación requiere el cobro por instrucción. Cuando la comisión de transacción se consume, el contrato fallará y detendrá la ejecución, y todos los cambios de estado se revertirán. El éxito del contrato no afecta la validez de la transacción.

### 3.3 Contrato de Función 

El contrato de función se utiliza para proporcionar algunas funciones públicas o comúnmente utilizadas, que pueden ser llamadas por otros contratos. El código de contrato inteligente puede reutilizarse, de modo que los desarrolladores puedan escribir una lógica de negocio cada vez más compleja. Cada contrato de función, cuando se implementa, puede elegir tener un área de almacenamiento privado cuyos datos se lean o se escriban en los datos de un contrato futuro, logrando la persistencia del estado.

El contrato de función debe ser pre-desplegado a la cadena a ser invocada y retirado de la cadena por una función "autodestructiva" del sistema, ya que no se utilizará y su almacenamiento privado será destruido. Los datos del contrato anterior se pueden migrar automáticamente a otro subcontrato antes de que ser destruidos, utilizando herramientas de migración de contrato.

## 4. Máquina Virtual 

### 4.1 Hardware virtual

NeoVM proporciona una capa de hardware virtual, para apoyar la ejecución de contratos inteligentes, incluyendo:

**CPU**

El CPU es responsable de leer y ordenar secuencialmente la ejecución de instrucciones en el contrato, de acuerdo con la función del control de flujo de instrucciones, las operaciones aritméticas y las operaciones lógicas. El futuro de la función de la CPU se puede ampliar, con la introducción de la función JIT (compilador en tiempo real), mejorando así la eficiencia de la ejecución de la instrucción.
**Pila de llamadas**

La pila de llamadas se utiliza para contener la información de contexto de la ejecución del programa en cada llamada de función, de modo que pueda continuar ejecutándose en el contexto actual después de que la función haya terminado de ejecutar y devolver.

**Pila de Cálculo**

Todos los datos de tiempo de ejecución de NeoVM se almacenan en la pila de cálculo, cuando después de la implementación de diferentes instrucciones, la pila es calculada en los elementos de datos correspondientes a la operación. Por ejemplo, cuando se ejecutan instrucciones adicionales, las dos operaciones que participan en la adición se expulsan de la pila de cálculo y el resultado de la adición se empuja a la parte superior de la pila. Los parámetros de llamada de función también deben calcularse de derecha a izquierda, según el orden de la pila. Después de que la función se ejecute correctamente, la parte superior de la función de recuperación de la pila devuelve el valor.

**Pila de repuesto**

Cuando se necesita programar o reorganizar elementos en la pila, se puede almacenar temporalmente los elementos en la pila de repuesto y recuperarlos en el futuro.

### 4.2 Conjunto de instrucciones

NeoVM proporciona un conjunto de instrucciones sencillas y prácticas para la construcción de programas de contrato inteligentes. Según las funciones, las principales categorías son las siguientes:

* Instrucción constante.
* Instrucción de control de procesos.
* Instrucciones de funcionamiento de la pila.
* Instrucción de cuerdas.
* Instrucción lógica.
* Instrucción de operación aritmética.
* Instrucción criptográfica.
* Instrucción de operación de datos.

Cabe señalar que el conjunto de instrucciones de NeoVM proporciona una serie de instrucciones criptográficas, como ECDSA, SHA y otros algoritmos para optimizar la eficiencia de implementación de algoritmos criptográficos en contratos inteligentes. Además, las instrucciones de manipulación de datos soportan directamente arreglos y estructuras de datos complejas.

### 4.3 Capa de servicio interoperable

La máquina virtual en la que se ejecuta el contrato inteligente es un entorno limitado que requiere una capa de servicio interoperable en los momentos en los que sea necesario acceder a datos fuera del área de seguridad o mantener los datos de tiempo de ejecución persistentes. Dentro de la capa de servicio interoperable, NEO contract puede abrir una serie de funciones del sistema y los servicios con el programa de contrato inteligente, y estos contratos pueden ser llamados y se puede acceder a ellos, como con las funciones ordinarias. Todas las funciones del sistema se llevan a cabo simultáneamente, por lo que no hay necesidad de preocuparse por la escalabilidad.

### 4.4 Función de depuración

A menudo, el desarrollo de contratos inteligentes es muy difícil, debido a la falta de buenos métodos de depuración y pruebas. NeoV proporciona soporte de depuración de programas a nivel de máquina virtual, donde se puede establecer el punto de interrupción en el código de contrato, o de un solo paso, la ejecución de un solo proceso. Gracias al diseño de bajo acoplamiento entre la máquina virtual y la cadena de bloques, es fácil integrar NeoVM directamente con varios IDE, para proporcionar un entorno de prueba que sea consistente con el entorno de producción final.

## 5. Lenguaje de Alto Nivel

### 5.1 C #, VB.Net, F#
Los desarrolladores pueden usar NeoContract en casi cualquier lenguaje de alto nivel en el que sean buenos. El primer lote de lenguajes soportados es C #, VB.Net, F #, etc. Ofrecemos compiladores y complementos en estos lenguajes de alto nivel en el conjunto de instrucciones, soportado por la NeoVM. Dado que el compilador se enfoca en MSIL (Lenguaje intermedio de Microsoft) durante la compilación, teóricamente, cualquier lenguaje .Net puede ser traducido al lenguaje MSIL, y convertirse en uno soportado directamente.

Un gran número de desarrolladores son proficientes en estos lenguajes, y los lenguajes anteriores tienen un entorno de desarrollo integrado muy fuerte. Los desarrolladores pueden desarrollar, generar, probar y depurar, todo dentro de Visual Studio, donde podrán aprovechar al máximo las plantillas de desarrollo de contratos inteligentes que ofrecemos, para obtener una ventaja.

### 5.2 Java, Kotlin

Java y Kotlin forman el segundo lote de lenguajes soportados, donde proporcionamos compiladores y plugins IDE para estos lenguajes, para ayudar a los desarrolladores a usar el lenguaje basado en JVM para desarrollar las aplicaciones del Contrato Inteligente de NEO.

Java es ampliamente utilizado, y Kotlin se ha convertido recientemente en el oficial recomendado por Google, como lenguaje de desarrollo de Android. Creemos que el apoyo a estos lenguajes ayudará a aumentar drásticamente el número de desarrolladores de contratos inteligentes de NEO.

### 5.3 Otros lenguajes

Posteriormente, NeoContract agregará soporte para otros lenguajes de alto nivel, basados en el grado de dificultad, en el proceso de desarrollo del compilador. Algunos de los lenguajes que pueden ser soportados incluyen:

* C, C + +, GO
* Python, JavaScript

En el futuro, continuaremos agregando más soporte de lenguajes de alto nivel. Nuestro objetivo es ver más del 90% de los desarrolladores de NEO desarrollando con NeoContract, sin necesidad de aprender un nuevo lenguaje, e incluso posiblemente transferir el código existente del sistema empresarial directamente a la cadena de bloqueo.

## 6. Servicio

### 6.1 Libro Mayor de Cadena de Bloques

NEO Smart Contracts puede obtener datos completos de bloque para la cadena de bloqueo NEO, incluyendo bloques completos y transacciones, y cada uno de sus campos, en tiempo de ejecución, a través de las funciones del sistema proporcionadas por el servicio interoperable. Específicamente, se pueden consultar estos datos:

* Altura de la cadena de bloques;
* Bloque principal, bloque actual;
* Transacciones;
* Tipo de transacción, atributos, entrada, salida, etc;

A través de estos datos, se pueden desarrollar algunas aplicaciones interesantes, tales como dividendos automáticos, contratos inteligentes basados en la prueba de carga de trabajo.

### 6.2 Activos digitales

A través de los servicios interoperables proporcionados por la interfaz de activos digitales, los contratos inteligentes no solo pueden consultar la cadena de bloques de NEO en términos de las propiedades y estadísticas de diversos activos digitales, sino también crear nuevos activos digitales durante su tiempo de ejecución. Los activos digitales creados por contratos inteligentes pueden ser emitidos, transferidos o negociados fuera del contrato. Son los mismos que los activos originales de NEO y se pueden gestionar con cualquier software compatible con NEO. 

Esta interfaz específica incluye:

* Consulta de atributos de activos.
* Consulta de estadísticas de activos.
* Gestión del ciclo de vida de los activos: crear, modificar, destruir, etc.
* Gestión de activos: nombre multi-lenguaje, cambio total, cambio de precisión, cambios en el administrador;

### 6.3 Persistencia

Cada programa de contrato inteligente desplegado en la cadena NEO, tendrá un área de almacenamiento privada que solo podrá ser leída y escrita por el propio contrato. Los contratos inteligentes tienen permisos operativos completos sobre los datos en su propio almacén: los pueden leer, escribir, modificar, eliminar. 

Los datos se almacenan en forma de pares clave-valor y proporcionan estas interfaces:

* Recorrer todos los registros almacenados;
* Regresar a un registro específico de acuerdo con la clave especificada;
* Modificar o escribir nuevos registros de acuerdo con la clave especificada;
* Eliminar el registro de acuerdo con la clave especificada;

En general, un contrato solo puede leer y escribir datos en su propio almacén, con una excepción: cuando se invoca un contrato, el contrato invocado puede acceder al almacén de la persona que lo llama mediante una solicitud entre dominios, siempre que la persona que llama proporcione la autorización. Además, para un subcontrato que se cree dinámicamente en el momento de la ejecución del contrato, el contrato principal obtiene acceso instantáneo a su almacén.

Las solicitudes entre dominios permiten a NeoContract implementar herramientas complejas de biblioteca, que proporcionan herramientas de gestión de datos altamente escalables para las personas que llaman.

## 7. Tarifas

### 7.1 Cuota de implementación
La arquitectura distribuida de NEO proporciona una alta redundancia en la capacidad de almacenamiento, y el uso de esta capacidad no es gratuito. La implementación de un contrato inteligente en la red NEO requiere una tarifa, actualmente fijada en 500GAS, que es recolectada por el sistema y registrada como una ganancia del sistema. Las comisiones futuras se ajustarán de acuerdo con el costo real de operación en el sistema. El contrato inteligente desplegado en la cadena de bloques se puede utilizar varias veces, hasta que el contrato sea destruido por quien lo implementó.

### 7.2 Cuota de implementación

NEO proporciona un entorno de ejecución confiable para contratos inteligentes y la ejecución de contratos requiere el consumo de recursos informáticos para cada nodo, por lo que los usuarios deben pagar por la ejecución de los contratos inteligentes. La tarifa está determinada por los recursos computacionales consumidos con cada ejecución, y el precio unitario también está en GAS. Si la implementación del contrato inteligente fracasa debido a la falta de GAS, el costo de consumo no será devuelto, y esto impedirá ataques maliciosos en el consumo de energía de la red.
Para la mayoría de los contratos simples, se pueden ejecutar de forma gratuita, siempre y cuando los costos de ejecución permanezcan bajo 10 GAS, lo que reduce enormemente los costos para el usuario.

## 8. Escenarios de Aplicación

### 8.1 Transacciones Superconductoras

Los activos digitales en la cadena de bloque requieren inherentemente alguna forma de liquidez, y usualmente las transacciones punto a punto no pueden proporcionar la liquidez suficiente, por lo tanto existe la necesidad de intercambios para proveer los servicios comerciales a los usuarios. Los intercambios de activos digitales se pueden dividir en dos categorías: 1) Intercambios centrales, en los que el usuario debe depositar los activos digitales con el intercambio, y subsecuentemente colocar los pedidos pendientes de negociación, en el sitio web. 2) Intercambios descentralizados, donde el sistema de comercio se basa en la cadena de bloques, y el sistema proporciona los servicios de coincidencia.

Los intercambios centralizados pueden proporcionar un rendimiento muy alto y servicios diversificados, pero necesitan tener una garantía de crédito fuerte, de lo contrario habrá riesgos morales; Como la apropiación indebida de fondos de usuarios, el fraude, etc. Comparativamente, el intercambio descentralizado no tiene ningún riesgo moral, pero la experiencia del usuario es pobre y hay un cuello de botella de mayor rendimiento. ¿Hay una manera de combinar ambas soluciones y lograr obtener lo mejor de ambos mundos?

Las transacciones superconductoras son un mecanismo que puede hacer esto; los usuarios no necesitan depositar activos, donde sean capaces de utilizar sus propios activos en la cadena de bloque en el comercio. La liquidación de transacciones ocurre completamente en la cadena de bloques, pero el proceso de emparejar las órdenes se produce fuera de la cadena, por un intercambio central que proporciona servicios de coincidencia. Dado que la coincidencia se lleva a cabo fuera de la cadena, su eficiencia es similar a los intercambios centralizados, pero los activos permanecen bajo el control del usuario. Los intercambios aprovechan la intención comercial del usuario para llevar a cabo servicios de coincidencia, sin riesgos morales involucrados, tales como malversación de fondos de usuarios, fraude, etc.
En la actualidad, dentro de la comunidad de NEO, ha surgido el desarrollo de contratos inteligentes para lograr transacciones superconductoras de cadenas de bloques, tales como OTCGO.

### 8.2 Fondo Inteligente

Los fondos inteligentes basados en la cadena de bloques tienen el beneficio de ser descentralizados, abiertos y transparentes, con un mayor grado de seguridad y libertad en comparación con los fondos tradicionales. Estos fondos inteligentes también son transfronterizos y están abiertos a inversionistas en todo el mundo, donde proyectos excepcionales pueden ser financiados con capital de todo el mundo.
Nest es un proyecto de fondos inteligentes basado en NeoContract, que es muy similar al proyecto TheDAO basado en Ethereum, donde se necesitan mejores medidas de seguridad para evitar los errores de TheDAO (hackers).

### 8.3 Interoperabilidad entre cadenas

En el futuro previsible, habrá un gran número de cadenas públicas, miles de cadenas de alianzas o cadenas privadas en existencia en todo el mundo. Estos sistemas de cadena de bloques aislados son islas de valor e información, que no son interoperables entre sí. A través del mecanismo de interoperabilidad entre cadenas, se pueden enlazar numerosas cadenas de bloques aisladas, de modo que los valores en cadenas de bloques diferentes se pueden intercambiar entre sí, para lograr aprovechar el verdadero valor de Internet.
NeoContract proporciona soporte para la implementación de la interoperabilidad entre cadenas, garantizando consistencia en el intercambio de activos entre cadenas, transacciones distribuidas entre cadenas y ejecución de contratos inteligentes en diferentes bloques.

### 8.4 Máquinas Oráculo

El concepto de los oráculos en el pensamiento popular, radica en la capacidad de una entidad sobrenatural que es capaz de responder a un conjunto particular de preguntas. En la cadena de bloques, las máquinas oráculo abren la puerta al mundo exterior para los contratos inteligentes, lo que hace posible que los contratos inteligentes utilicen la información del mundo real, como condiciones para la ejecución del contrato.

NeoContract no proporciona la capacidad de acceder directamente a datos externos, como el acceso a recursos en Internet, porque esto introducirá un comportamiento no determinista, resultando en inconsistencias entre nodos durante la ejecución del contrato. La implementación de la máquina oráculo en NeoContract requiere que los datos externos sean enviados a la cadena de bloques por un tercero de confianza, integrando estas entradas de datos como parte del libro mayor de la cadena de bloques, eliminando así el no determinismo.

El tercero creíble mencionado anteriormente, puede ser una persona o institución que sea de confianza para ambas partes en el contrato, o un proveedor de datos descentralizado que esté garantizado por incentivos económicos. De esta manera, NeoContract puede ser utilizado en la implementación de tales máquinas Oráculo.

### 8.5 Ethereum DAPP

Bitcoin creó la era de las cadenas de bloques y el efectivo electrónico, y Ethereum creó la era de los contratos inteligentes. Ethereum, los pioneros del contrato inteligente en la cadena de bloque, ha hecho grandes contribuciones a la idea de diseño, el modelo económico y la realización tecnológica de un sistema de contrato inteligente. Al mismo tiempo, la plataforma Ethereum ha visto un gran número de DAPP (aplicaciones distribuidas), donde algunas de estas funcionalidades incluyen, acuerdos de juego, activos digitales, oro electrónico, plataforma de juego, seguro médico, plataforma matrimonial, con uso generalizado en muchas industrias. En teoría, todos estos DAPPs, pueden ser fácilmente trasplantados a la plataforma NeoContract, como una aplicación NEO.
