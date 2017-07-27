# Contratos Inteligentes NEO 2.0 Whitepaper

:book: **El documento está siendo editado** y lo completaremos lo antes posible. Puedes ver otros documentos en [GitHub](https://github.com/neo-project/neo/wiki) or visitar la [web oficial](http://www.neo.org).

Esto es un proyecto de codigo abierto. Puedes contribuir al desarrollo de la documentación en [github.com/neo-project/docs](https://github.com/neo-project/docs). Gracias por tu ayuda.


------

## 1. Introducción

Un contrato inteligente es una serie de compromisos definidos de forma digital, incluyendo el acuerdo que el emisor puede realizar en esos compromisos. La tecnología blockchain nos aporta un sistema descentralizado, no manipulable y altamente confiable en el cual los contratos inteligentes son muy útiles. El contrato inteligente es una de las características más importantes del blockchain y también es la razón principal por la cual la blockchain puede llamarse tecnología disruptiva. Esta tecnologia esta haciendo que nuestra estructura social cambie con cada día que pasa.


## 2. Las características

### 2.1 Seguridad

Si un programa se está ejecutando en una computadora diferente, o en momentos diferentes en la misma computadora, la misma entrada puede garantizar producir la misma salida, entonces el comportamiento del programa es determinista y viceversa, es no determinista. Blockchain es un almacenamiento múltiple de diferentes partes, un método de computación de partes múltiples para lograr que los datos que no pueden ser modificados con cálculos confiables de los resultados de sistemas distribuidos, un contrato inteligente estará en una red de blockchain para ejecutarse en múltiples nodos. Si un contrato inteligente es no determinista, entonces los resultados de diferentes nodos pueden ser inconsistentes, lo que resulta un consenso al que no se puede llegar, la red cae en estancamiento. Por lo tanto, en el diseño de un contrato inteligente, la necesidad de descartar todo puede conducir a factores no deterministas.

### 2.1.1 Tiempo

La obtención de tiempo del sistema es una función muy común que puede ser aplicada en algunos procedimientos de contratos sensibles al tiempo. Pero la adquisición del tiempo es una función del sistema no determinista, los resultados de diferentes acciones de los nodos serán inconsistentes, en el sistema distribuido es difícil obtener un tiempo preciso unificado. Por lo tanto, el contrato de AnsShares sólo proporciona un bloque de sistema basado en la marca de tiempo de bloque, que toma toda la blockchain como un servidor de marca de tiempo y obtiene la marca de tiempo cuando se construye cualquiera de los bloques. Dado que el NeoGas se en un intervalo cada 15 segundos, el contrato se ejecuta aproximadamente al mismo tiempo que el último tiempo del bloque, más 15 segundos.


### 2.1.2 Número aleatorios

Muchos procedimientos de los contratos inteligentes usan funciones de números aleatorios, como contratos de juego de apuestas y otros juegos, pero la función número aleatorio es una típica función no-determinista, cada opción obtendrá resultados diferentes. En un sistema distribuido, hay muchas formas de resolver este problema: la misma semilla aleatoria puede usarse para todos los nodos de modo que la función aleatoria sea determinista, pero este método expone el resultado aleatorio entero por adelantado, lo que hace que el valor práctico del número aleatorio se reduzca en gran medida; Otro método es permitir que todos los nodos se comuniquen de una manera colaborativa para generar números aleatorios, puede utilizar algunas técnicas criptográficas para producir un número aleatorio justo, pero la desventaja es que el rendimiento es muy pobre, necesita una sobrecarga de comunicación adicional; Hay también una manera de introducir números aleatorios centralizado que proporciona números aleatorios y asegura la coherencia, pero el inconveniente de este enfoque es que es obvio que el usuario debe confiar incondicionalmente en el proveedor. Hay dos maneras de obtener un número aleatorio en NEO: la primera es que cuando se construye cada bloque, el nodo Consenso llegue a un consenso sobre un número aleatorio y lo establezca en el campo 'Nonce' del bloque. El procedimiento del contrato puede leer este valor de cualquier bloque; el segundo es que el programa de contrato puede utilizar el valor hash del bloque como un medio de generación de números aleatorios, porque el valor hash del bloque tiene una cierta aleatoriedad, de esta manera puede obtener un números aleatorios algo más débiles.


### 2.1.3 Origen de los datos

Si un programa obtiene datos en el momento que se ejecuta y la fuente de datos proporciona datos no-deterministas, el programa puede volverse un programa no-determinista. Por ejemplo, usar un motor de búsqueda para los diez primeros resultados de una palabra – los motores de búsqueda puede responder con diferentes resultados dependiendo de la direcciones IP de origen. La inteligencia NEO proporciona dos fuentes de datos no deterministas:

**1.**	Blockchain: El procedimiento de contrato puede acceder a todos los datos de toda la cadena mediante servicios interactivos, incluyendo bloques completos y transacciones, así como cada uno de sus campos. Los datos sobre los bloques son deterministas y consistentes, por lo que se puede acceder de forma segura mediante contratos inteligentes.

**2.**	Espacio de almacenamiento de contrato: Cada contrato desplegado en NEO tiene un espacio de almacenamiento que sólo puede ser accedido por ese contrato además, el mecanimso de consenso de NEO garantiza que el estado de almacenamiento en cada nodo sea consistente. En el caso de que el contrato necesite obtener datos fuera de la cadena NEO no proporciona una via directa. 

### 2.1.4 Llamada de contrato

Los contratos inteligentes tienen la habilidad de llamarse entre sí, pero no pueden llamarse de forma recursiva. La recursión puede lograrse dentro del contrato, pero no puede sobrepasar los límites del contrato actual. Además, la relación de la llamada entre contratos debe ser estática, es decir, el contrato a llamar no puede ser especificado en el momento de ejecución. Esto permite que el comportamiento del programa se determine completamente antes de que pueda ejecutarse y la llamada al contrato puede determinarse completamente antes de ejecutarse. Hay que tener en cuenta lo anterior en caso que se quiera realizar un particionamiento dinamico para ejecutar contratos de forma paralela.

## 2.2 Alto Rendimiento

El entorno de ejecución de un contrato inteligente puede jugar un rol muy importante en el desempeño del contrato. Cuando analizamos el performance de ejecución de un contrato hay dos indicadores críticos: la primera es la velocidad de ejecución de la instrucción y el segundo la ejecución del propio contrato. Para contratos inteligentes, la velocidad de ejecución en el es a menudo más importante que la ejecución de las instrucciones. El contrato inteligente está un poco más involucrado en la operación IO de la lógica para determinar las instrucciones, la aplicación de estas instrucciones se pueden optimizar fácilmente. Cada vez que se ejecuta un contrato inteligente se inicia la máquina virtual/contenedor, por lo tanto la ejecución  de maquina virtual tiene un mayor impacto en el rendimiento de los contratos inteligentes. NEO utiliza una máquina virtual muy ligera, se ejecuta muy rapida y consume muy pocos recursos, ideal para la ejecución de contratos.La compilación estática y el almacenamiento en caché de los contratos mejoran significativamente la eficiencia de las máquinas virtuales mediante la tecnología JIT (compilador en tiempo real).


## 2.3 Extensibilidad

### 2.3.1 Concurrencia alta y particionamiento dinámico

Cuando se hablamos  de la escalabilidad de un sistema, exiten dos tipos: la escabilidad vertical y la escabilidad horizontal. La escabilidad vertical es la capacidad de optimizar el flujo de proceso para que el sistema pueda aprovechar al máximo la capacidad del equipo existente, la capacidad de procesamiento del sistema dependera del límite hardware. Cuando tenemos que expandir el sistema, si hay una manera de transformar el sistema serial en un sistema paralelo, entonces teóricamente sólo necesitamos aumentar el número de dispositivos, puede obtener escalabilidad casi ilimitada, este enfoque es la expansión horizontal. ¿Tenemos la posibilidad de expansión ilimitada cuando consideramos extender el sistema de cadena de bloque? En otras palabras, ¿puede la cadena de bloque manejar la situación en paralelo? La cadena de bloques es un libro grande distribuido, que registra una variedad de datos de estado, pero también registra las reglas de cómo estos cambios, el contrato inteligente se utiliza para registrar las reglas del portador. Si la cadena de cadena puede manejar el negocio en paralelo depende de si múltiples contratos inteligentes pueden ejecutarse simultáneamente, es decir, si la ejecución del contrato es ordenada. Básicamente, si los contratos no interactúan entre sí, o si el contrato no modifica los mismos datos de estado al mismo tiempo, su ejecución es secuencial y se puede ejecutar simultáneamente, de lo contrario sólo se puede ejecutar en serie, no se puede escalar horizontalmente. Con base en el análisis anterior, podemos diseñar fácilmente una "expansión ilimitada" del sistema de contrato inteligente. Sólo es necesario especificar:

1.	Un contrato inteligente sólo puede modificar el status del contrato si el mismo pertenece al registro; 
2.	en la misma tanda de transacción (bloque) un contrato sólo puede ejecutarse una vez; Como resultado, todos los Smart Contract son irrelevantes al orden y pueden manejarse en paralelo. Sin embargo, si un "contrato inteligente sólo puede modificar el estado del contrato pertenece a su propio registro", significa que el contrato no puede llamarse entre sí, cada contrato es una isla; Si "es un bloque, un contrato sólo se puede ejecutar una vez" Significa que un activo digital emitido con un contrato inteligente sólo puede manejar un acuerdo en un bloque. Esto es obvio y "inteligente" el diseño original de la palabra es muy diferente. Después de todo, la llamada mutua entre el contrato, el mismo bloque en una serie de llamadas del mismo contrato, es que queremos los objetivos de diseño. Afortunadamente, la relación de llamada entre el contrato inteligente de las hormigas es estática y no puede especificar el destino de la llamada en tiempo de ejecución. Esto permite que el comportamiento del programa se determine completamente antes de que se pueda ejecutar, y su relación de llamada puede determinarse completamente antes de ejecutarse. Exigimos que cada contrato indique explícitamente qué contratos es probable que sean invocados para que el entorno operativo pueda calcular el árbol de llamadas completo antes de ejecutar el procedimiento del contrato y particionar la ejecución del contrato basado en el árbol de llamadas. Los contratos que pueden modificar el mismo registro de estado se ejecutan en serie en la misma partición y las particiones y particiones se pueden ejecutar simultáneamente.


### 2.3.2 Acoplamiento bajo

El acoplamiento es la medida de dos o más entidades que dependen de la otra. El sistema de ejecución de los contratos inteligentes usa un diseño de bajo acoplamiento que se ejecuta en la máquina virtual ) y se comunica con el exterior a través de una capa interactiva de servicio. Por lo tanto, para actualizar las funciones de los contratos inteligentes bastará con aumentar las API en el capa de servicio.

# 3. Tipo de contrato

## 3.1 Verificación del contrato

El propósito de la verificación del contrato es verificar la propiedad de los activos en la cuenta del contrato. Cuando una transacción debe ser transferida a un activo en una cuenta, el contrato de verificación correspondiente a esa cuenta debe ejecutarse. Un contrato de validación puede aceptar un conjunto de parámetros (usualmente una firma digital u otros criterios) y devuelve un valor booleano después de la verificación para indicar al sistema si la verificación tuvo éxito. El usuario puede pre-desplegar el contrato de verificación a la cadena o publicar el contenido del contrato directamente en la transacción durante el proceso de transferencia. Si el contrato se despliega a la cadena por adelantado, el contrato puede ser utilizado no sólo como un contrato de verificación, sino también por otro contrato. Usted puede llamar a la "auto-destrucción" de la función del sistema para eliminar la cadena cuando se ha desplegado del contrato, se elimina y, a continuación, ya no se puede utilizar.

## 3.2 Funcion del contrato

La función de contrato se usa para proporcionar algunas funciones públicas o comunes para llamar otros contratos. Hace que el código del Smart Contract pueda ser reutilizado, para que los desarrolladores puedan escribir lógica de negocios más compleja. El contrato de la función debe ser pre-desplegado a la cadena para ser llamado y retirado de la cadena por "autodestrucción" de la función del sistema.

## 3.3 Aplicacion del contrato

La aplicación de contrato proporciona al usuario un cojunto de funciones donde no solo puede guardar el estado de ejecución sino que tambien le permite llamar a otros. Puedes llamar a la funcion "Self-Destruction" para borrar el bloque que se ha desplegado con el contrato.

# 4 Máquina Virtual

## 4.1 Hardware virtual

La máquina virtual NEO proporciona una capa de hardware virtual para soportar la ejecución de contratos inteligentes, incluyendo:

**1.**	CPU: Es responsable de leer y en el orden la implementación de instrucciones en el contrato, de acuerdo a la función de instrucción del flujo de control, operaciones aritméticas, operaciones lógicas. La función del CPU puede extenderse en el futuro, la introducción de JIT (compilador en tiempo real) mejorando así la eficiencia de la instrucción de ejecución

**2.**	Llamada de stack: Se usa para contener la información de contexto de la ejecución del programa en cada llamada de ejecución, para que pueda continuar la ejecución en el contexto actual después que la función complete y regrese.

**3.**	Calcular el stack: Todos los datos en el tiempo de ejecución en la Ant virtual y la máquina virtual son almacenados en el stack de cálculo, y cuando diferentes instrucciones se ejecutan, los elementos de datos en el stack de cálculo son manipulados de forma apropiada. Por ejemplo. Cuando la instrucción de adición se ejecuta, los dos operadores que participan en la adición son expulsados del stack de cálculo, y el resultado de la adición es empujado al tope del stack. Los parámetros de la función de llamada también deben ser presionados de derecha a izquierda en el orden del stack, la función puede completarse desde el tope del stack con una función de retorno de valor

**4.**	Standby Stack: cuando necesite programar o reacomodar los elementos en el stack, puede almacenar temporalmente los elementos en el stack en stack standby y recuperarlos luego en el futuro.


## 4.2 Set de intrucciones

La máquina virtual NEO proporciona un set simple y práctico de instrucciones para construir un procedimiento de Smart Contract. Por función, incluye en su mayoría las siguientes categorías: 

  * Instrucción constante
  * Instrucciones de control del proceso
  * Pila instrucciones de funcionamiento
  * Instrucciones de la secuencia
  * Instrucciones lógicas
  * Instrucciones aritméticas
  * Instrucciones criptográficas
  * Instrucciones de manipulación de datos. Cabe señalar que el conjunto de instrucciones de la máquina virtual NEO proporciona una serie de instrucciones criptográficas como ECDSA, SHA y otros algoritmos para optimizar la eficiencia de la implementación de algoritmos criptográficos en contratos inteligentes. Además, las instrucciones de manipulación de datos proporcionan soporte para matrices y estructuras de datos complejas directamente


## 4.3	Capa de servicio interactiva

La máquina virtual donde el Smart contract es ejecutado es un ambiente de sandbox que requiere una capa de servicio interactiva cuando el contrato necesita accesar a datos fuera del sandbox o cuando se persiste el tiempo de ejecución de datos, lo que proporciona el Smart Contract para la máquina virtual, el medio de comunicación externa. En la capa de servicio interactiva, una serie de funciones del sistema y servicios se exponen a procedimientos de Smart Contract. Se puede accesar al contrato como una función ordinaria. Todas las funciones son concurridas, así que no hay que preocuparse por el problema de escalabilidad.

## 4.4 Debugging function

A menudo, el desarrollo de un Smart Contract es muy difícil porque no hay un buen método de debugging y prueba. Las hormigas pequeñas en el nivel de la máquina virtual proporciona el apoyo de la función de depuración del programa, puede establecer el punto de interrupción en el código de contrato, también puede ejecución de un solo paso, un solo proceso. Gracias al diseño de acoplamiento bajo entre la máquina virtual y la cadena de bloques, es fácil integrar la máquina virtual de hormigas directamente con los distintos IDE para proporcionar un entorno de prueba que sea consistente con el entorno de producción final

# 5 Lenguajes de alto-nivel

## 5.1 C #, VB.Net, F #

Los desarrolladores pueden usar casi cualquier lenguaje de alto nivel para el desarrollo de contratos inteligentes. Los primeros lenguajes soportados son C#, VB.Net, F#. Se proporciona compiladores y plug-ins para compilar estos lenguajes de alto nivel a sets de instrucciones soportados en la máquina virtual de NEO. Como el compilador será para MSIL (lenguaje intermedio de Microsoft) teóricamente cualquier lenguaje .NET o traducido al lenguaje MSIL estará directamente soportado. El número de desarrolladores en estos lenguajes es numeroso y tiene un entorno de desarrollo integrado. Los desarrolladores pueden desarrollar, probar y depurar programas desarrollados en Visual Studio, y también pueden utilizar el plug-in SmartContract que genera una plantilla como punto de entrada al desarrollo.

## 5.2 Otros lenguajes

NEO soportará otros compiladores de alto nivel, algunos podran ser:

  * Java
  * C, C ++, GO
  * Python, JavaScript

En el futuro se continuará añadiendo lenguajes de alto nivel, de esta forma casi el 90% de los desarrolladores no necesitaran aprender un nuevo lenguaje para desarrollar contratos inteligente en NEOract con Neo.

# 6 Servicio.

## 6.1 Blockchain

Los contratos inteligentes pueden obtener los datos completos de la blockchain de NEO, incluyendo el bloque completo y la transacciones, así como todos sus campos en tiempo de ejecución a través de las funciones de sistema proporcionadas para interactuar con el sistemas. Específicamente, puede consultar:

  * La altura del blockchain.
  * La cabecera del bloque y el bloque.
  * Las transacciones.
  * El tipo de transacciones, atributos, entradas, salidas, etc. A través de estos datos se pueden desarrollar algunas
  aplicaciones interesantes, como dividendos automáticos basados en la carga de trabajo de contratos inteligentes y mucho más.


## 6.2 Activos digitales

Los contratos inteligentes ademas de consultar los atributos y estadisticas de los activos digitales en la blockchain también pueden crearlo en tiempos de ejecución. Los activos digitales creados con los contratos inteligentes pueden ser emitidos, transferidos y comercializados, además de poder administrarlos con cualquier monedero compatible con Neo.

La interfaz tiene las siguientes funcionalidades:

  * Consultar atributos de los activos.
  * Consultar estadísticas.
  * Gestión del ciclo de vida de los activos: crear, modificar, destruir, etc. 
  * Gestión de activos: nombre en varios idiomas, cambio, cambios de precisión, cambios en el administrador.


## 6.3 Persistencia

Al desplegar un contrato inteligente estos disponen de un área de almacenamiento donde únicamente el contrato puede leer y escribir. Los contratos inteligentes tienes permisos completos en su propia área: pueden leer, escribir, modificar y borrar. Los datos almacenados estan en la forma clave-valor.

La interfaz tiene la siguientes funcionalidad:

  * Consultar todos los registros almacenados.
  * Devolver un registro específico de acuerdo con la clave especificada.
  * Modificar o escribir nuevos registros de acuerdo con la clave especificada.
  * Eliminar el registro de acuerdo con la clave especificada. 
  
En general, un contrato sólo puede leer y escribir datos de su propio almacenamiento con una excepción: cuando se llama (InvokeContract) un contrato. El contrato llamado puede acceder al almacenamiento del contrato llamante a través de una llamada de inter-dominio (cross-domain). 

El area de almacenamiento de los llamantes inter-dominio puede ofrecer bibliotecas más complejas proporcionando más funcionalidades a los contratos invocados.


# 7 Costes

## 7.1 Coste de desarrollo

La estructura distribuida de la blockchain de NEO proporciona una alta redundancia a nivel de almacenamiento, el uso de este capacidad no es gratis. El costo de desplegar un contrato inteligente es un pequeños bloque está fijado a 500 NeoGas, el cual es recogido por el sistema y se vuelve una ganancia para el sistema. En el futuro el coste puede basarse en la operación y se podrá ajusta el precio. Un contrato inteligente desplegado en la blockchain se puede utilizar multiples veces hasta que el contrato se destruyes por quien lo ha desplegado.

## 7.2 Tarifa de ejecución

La ejecución de contratos inteligentes consume recursos de computación en los nodos, por lo que el usuario debe pagar por estos costes. El coste es determinado por los recursos de computación de cada ejecución y la unidad de precios es NeoGas, que es cobrado por el nodo de consenso. Si la implementación no tuviera coste de ejecución esto podria ser aprovechado por ataques maliciosos para consumir toda la red de computación.

# 8 La aplicación.

## 8.1 Transacción superconductora

Los activos digitales en la blockchain son inherentemente demandandos y por lo general las transacciones punto a punto no pueden proporcionar suficiente liquidez, por eso la necesidad de proporcionar a los usuarios servicios de intercambio comerciales. Los activos digitales del intercambio se dividen en dos categorías: el primero es el intercambio central, el usuario necesita recargar los activos digitales en el intercambiador (Exchange) y luego solicitarlos en una sola transacción; La segunda categoría es proporcionar un sistem el central de intercambio.

## 8.2 Financiación inteligente

## 8.3 8.3	Cross chain interoperability

Es previsible que, en el futuro por un largo período de tiempo otras blockchain, blockchains aliadas y blockchain privada coexistiran. A través del mecanismo de interoperabilidad entre blockchain numerosos blockchains aislados se podran unir entre sí, de modo que el valor de las diferentes blockchain intercambiarse entre sí para formar un valor real en Internet. Los contratos inteligentes tienen soporte para la interoperabilidad entre blockchains, no sólo para el intercambio de activos sino también para ejecutar transacciones y contratos distribuidos entre diferentes blockchains y asegurar su consistencia.

## 8.4 Maquina echo

Un susurro puede ser visto como una máquina tupla conectada a un profeta (oráculo). El concepto del profeta es una entidad que puede responder a un conjunto particular de preguntas. En la blockchain, el denunciante (whistleblower) abre la puerta al mundo exterior para los contratos inteligentes lo que permite utilizar la información del mundo real como condición para la ejecución del contrato. El contrato inteligente de NEO no proporciona la capacidad de acceder a los datos externos directamente, como el acceso a los recursos en Internet, ya que esto introduce datos no-determinista, haciendo que los nodos aparezcan inconsistentes con los resultados de la ejecución del contrato. En la blockchain de NEO para conseguir la máquina de silbato, la necesidad de un tercero de confianza a datos externos a través de la forma de transacciones enviadas a la cadena de bloques, haciendo que esta información se convierta en parte de los datos del libro, eliminando la incertidumbre. El tercero creíble a que se refiere el artículo anterior puede ser una persona o institución de confianza de ambas partes en el contrato, o un proveedor de datos descentralizado que esté garantizado por incentivos económicos. Para lograr tal silbato.

## 8.5 Ethernet Square Series DAPP

Bitcoin creó una blockchain y dinero electrónico, para crear una era de contrato electrónico. Con el pionero de contratos inteligentes de blockchain, es una gran contribución a la idea de diseño, modelo económico y realización tecnológica del sistema de contrato inteligente. Al mismo tiempo, hay muchos DAPP (aplicación distribuida) en tal plataforma, lo que tiene diferentes funciones, como acuerdos de juegos, activos digitales, oro electrónico, plataforma de juegos, plataforma de matrimonio, industria. Todos estos DAPP, teóricamente pueden ser fácilmente trasplantados a la plataforma de Neo.

# 9.	Explorar

## 9.1 Control de versión

Los contratos inteligentes deben implementarse en la blockchain antes de que puedan distribuirse. Una vez que el código de contrato se implementa, no se puede modificar porque el comportamiento del programa debe ser determinado por el usuario antes de ejecutarse. Si el código del contrato puede ser arbitrariamente modificado o actualizado, está obligado a traer algún riesgo moral.

## 9.2	Acceso de recursos IPFS

En el presente, los contratos inteligentes en el sistema solo puede accesar a los datos en su propia área de almacenamiento, en el futuro se puede necesitar un almacenamiento compartido público entre el contrato, el área de almacenamiento a través de la tabla para recuperar el archivo, y almacenamiento distribuido en los nodos.Pudiera ser implementado a través de DHT (Distributed hash table) o IPFS (InterPlanetary File System)

