

# NEO White Paper

Una red distribuida para la Economía Inteligente


# Objetivos de diseño de NEO: Economía Inteligente

NEO es el uso de la tecnología de cadena de bloques y la identidad digital para digitalizar los activos, el uso de contratos inteligentes para que los activos digitales sean autogestionados, para lograr una "economía inteligente" con una red distribuida.
### Activos digitales

Los activos digitales son activos programables que existen en forma de datos electrónicos. Con la tecnología de cadena de bloques, la digitalización de los activos puede ser descentralizada, confiable, rastreable, altamente transparente y libre de intermediarios. En la cadena de bloques NEO, los usuarios pueden registrar, comercializar y distribuir múltiples tipos de activos. Probar la conexión entre los activos digitales y físicos es posible a través de la identidad digital. Los bienes registrados a través de una identidad digital válida están protegidos por la ley.

NEO tiene dos formas de activos digitales: los activos globales y los activos contractuales. Los activos globales se pueden registrar en el espacio del sistema y pueden ser identificados por todos los contratos y clientes inteligentes. Los activos contractuales se registran en el área de almacenamiento privado del contrato inteligente y requieren que un cliente compatible los reconozca. Los activos contractuales pueden adherirse a ciertos estándares para lograr la compatibilidad con la mayoría de los clientes.


### Identidad digital
La identidad digital se refiere a la información de la identidad de los individuos, las organizaciones y otras entidades que existen en forma electrónica. El sistema de identidad digital más maduro se basa en la norma PKI (Public Key Infrastructure) X.509. En NEO, implementaremos un conjunto de estándares de identidad digital compatibles con X.509. Este conjunto de estándares de identidad digital, además de ser compatible con el modelo de emisión de certificados de nivel X.509, también soportará el modelo de emisión de certificados punto a punto de Web Of Trust. Nuestra verificación de identidad al emitir o usar identidades digitales incluye el uso de rasgos faciales, huellas dactilares, voz, SMS y otros métodos de autenticación de múltiples factores. Al mismo tiempo, también usaremos la cadena de bloques para reemplazar el Protocolo de Estatus de Certificados en línea (OCSP, por sus siglas en inglés) para administrar y registrar la Lista de Revocación de Certificados (CRL, por sus siglas en inglés) X.509.
t### Contrato Inteligente
El contrato inteligente fue propuesto por primera vez por el criptógrafo Nick Szabo en 1994, apenas cinco años después de la creación de la World Wide Web. Según la definición de Szabo: Cuando se activa una condición preprogramada, el contrato inteligente ejecutará los términos del contrato correspondiente. La tecnología de cadena de bloques nos proporciona un sistema descentralizado, resistente a las manipulaciones y altamente fiable, en el que los contratos inteligentes son muy útiles. NEO tiene un sistema independiente de contrato inteligente: NeoContract.

El sistema de contrato inteligente NeoContract es la característica más importante de la integración perfecta del ecosistema de desarrolladores existente. Los desarrolladores no necesitan aprender un nuevo lenguaje de programación, sino que usan C #, Java y otros lenguajes de programación convencionales en sus entornos IDE (Visual Studio, Eclipse, etc.) conocidos para el desarrollo, depuración y compilación de contratos inteligentes. La Máquina Virtual Ligera Universal de Neo, NeoVM, tiene las ventajas de alta seguridad, alta concurrencia y alta escalabilidad. El sistema de contrato inteligente NeoContract permitirá a millones de desarrolladores de todo el mundo llevar a cabo rápidamente el desarrollo de contratos inteligentes. NeoContract tendrá un documento técnico aparte que describirá los detalles de su implementación.
### Aplicación y Ecosistema


El ecosistema es la vitalidad de la comunidad de código abierto. Para lograr el objetivo de una red económica inteligente, NEO se compromete a desarrollar su ecosistema, proporcionando herramientas maduras de desarrollo, mejorando el desarrollo de documentos, organizando actividades de educación y capacitación y proporcionando apoyo financiero. Planeamos apoyar las siguientes aplicaciones y ecología basadas en NEO y recompensar las mejoras en el diseño de la experiencia:


**Programa de Nodo**

* Un programa completo de nodo para PC completamente funcional
* Un programa de nodo ligero para PC con una mejor experiencia de usuario
* Clientes Web / Android / iOS que no requieren sincronizarse con la cadena de bloques
* Monedero Hardware 

**Explorador de Cadena de Bloques**

**Kit de Desarrollo SDK **

* Soporta Java / Kotlin, .NET C # / VB, JavaScript / Typescript, Python, Go

**Compilador de Contratos Inteligentes y Plugin IDE**
* C# / VB.Net / F#, Visual Studio
* Java / Kotlin, Eclipse
* C / C++ / GO
* JavaScript / TypeScript
* Python / Ruby

**Aplicaciones Descentralizadas**

* Fondo inteligente
* Contrato inteligente asistido con IA
* Redes sociales
* Proveedores de fichas automáticas de liquidez
* Intercambio descentralizado
* Protocolo de comunicación segura
* Mercado de intercambio de datos
* Mercado de intercambio de la propiedad intelectual
* Mercado de predicciones
* Mercado de publicidad
* Mercado Hashpower
* Mercado NeoGas

## Modelo de Gestión de NEO

### Modelo Económico

AS es el token combustible para la realización del control de recursos de la red NEO, con un límite máximo total de 100 millones. La red de NEO cobra por la operación y almacenamiento de fichas y contratos inteligentes, creando así incentivos económicos para los contadores y previniendo el abuso de recursos. La unidad mínima de GAS es 0.00000001.
En el bloque genesis de la red NEO, se generan 100 millones de NEOs, mientras que aún no se han generado GAS. 100 millones de GAS, correspondientes a los 100 millones de NEO, se generarán a través de un algoritmo de decaimiento en unos 22 años para abordar el mantenimiento de NEO. Si NEO se transfiere a una nueva dirección, los GAS que se generen a continuación serán acreditados a la nueva dirección.

La red NEO fijará un umbral votando para eximir al GAS de una cierta cantidad de transacciones de transferencia y operaciones de contratos inteligentes para mejorar la experiencia del usuario. Cuando se produzca una gran cantidad de transacciones de spam, se puede utilizar lar NeoID para priorizar las transacciones y contratos inteligentes con identidades calificadas. Las transacciones y contratos inteligentes sin identidades digitales calificadas pueden obtener prioridad al pagar con GAS.

### Mecanismo de Distribución

Distribución de NEO:

Los 100 millones de fichas de NEO se dividen en dos partes. La primera parte es de 50 millones de fichas distribuidas proporcionalmente entre los partidarios de NEO durante la recolección de fondos. Esta parte ya ha sido distribuida.

La segunda parte es de 50 millones de NEO administrada por el Consejo de NEO para sostener el desarrollo de NEO a largo plazo, su operación y mantenimiento y su ecosistema. El NEO en esta parte tiene un período de bloqueo de 1 año y se desbloqueará solo después del 16 de octubre de 2017. Esta parte no entrará en los intercambios y servirá únicamente para el apoyo a largo plazo de los proyectos de NEO. Los planes para ello son los siguientes:

* 10 millones de fichas (10% en total) se utilizarán para incentivar a los desarrolladores de NEO y miembros del Consejo de NEO.
* 10 millones de fichas (10% en total) se utilizarán para incentivar a los desarrolladores en el ecosistema NEO.

* 15 millones de fichas (15% en total) se utilizarán para invertir en otros proyectos de cadena de bloques, que sean propiedad del Consejo de NEO y que se utilicen solo para proyectos NEO.

* 15 millones (total 15%) se mantendrán como contingencia.

* El uso anual de NEO en principio no excederá los 15 millones de tokens.

Distribución de GAS:

Los GAS se generan con cada nuevo bloque. La cantidad total inicial de GAS es cero. Con el aumento de la tasa de generación de nuevos bloques, el límite total de 100 millones de GAS se alcanzará en aproximadamente 22 años. El intervalo entre cada bloque es de unos 15-20 segundos, y se generan 2 millones de bloques en aproximadamente un año.

Durante los primeros 2 millones de bloques (aproximadamente un año), cada bloque generará 8 nuevos GAS; el segundo año (bloques de 2 a 4 millones), cada nuevo bloque generará 7 GAS y así sucesivamente. La reducción anual de la tasa de 1 GAS por año se mantendrá durante los primeros 8 años hasta que se alcance 1 GAS por bloque, momento a partir del cual la tasa de generación de GAS se mantendrá constante durante unos 22 años. Después de que se hayan generado 44 millones de bloques, se alcanzarán los 100 millones de GAS y la generación de GAS de nuevos bloques se detendrá.

De acuerdo con esta curva de liberación, el 16% del GAS se creará en el primer año, el 52% del GAS se creará en los primeros cuatro años y el 80% del GAS se creará en los primeros 12 años. Estos GAS se distribuirán proporcionalmente de acuerdo con la relación de mantenimiento NEO, registrada en las direcciones correspondientes. Los titulares de NEO pueden iniciar una transacción de reclamación en cualquier momento y reclamar estas fichas GAS en sus direcciones de retención.


### Mecanismo de gobierno

Cadena de mando: Los titulares de tokens NEO son los propietarios y gestores de redes, gestionan la red a través del voto en la red, utilizando los GAS generados desde NEO para utilizar las funciones en la red. Las fichas NEO pueden ser transferidas.

Mando fuera de la cadena: El Consejo de NEO está formado por los miembros fundadores del proyecto NEO, bajo los cuales el comité de gestión, el comité técnico y la secretaría, respectivamente, son responsables de la toma de decisiones estratégicas, la toma de decisiones técnicas y la implementación específica. El Consejo de la NEO es responsable ante la comunidad de NEO de la promoción y desarrollo del ecosistema NEO como su principal objetivo.

## Implementación de la tecnología NEO


### Mecanismo de consenso: dBFT


dBFT son las siglas en inglés para “Tolerancia Delegada ante Fallo Bizantino”, un mecanismo de consenso tolerante ante fallos bizantinos que permite la participación a gran escala en el consenso a través de la votación delegada. El poseedor de la ficha NEO puede, al votar, elegir al contador que apoya. El grupo seleccionado de contadores, a través del algoritmo BFT, llega a un consenso y genera nuevos bloques. La votación en la red NEO continúa en tiempo real, en lugar de cumplir con un plazo fijo.



dBFT proporciona tolerancia a fallos de f = ⌊ (n-1) / 3 ⌋ para un sistema de consenso que consta de n nodos de consenso. Esta tolerancia a fallos también incluye seguridad y disponibilidad, resistencia a fallos generales y bizantinos, y es adecuada para cualquier entorno de red. La DBFT tiene buena finalización, lo que significa que una vez que las confirmaciones sean finales, el bloque no puede ser bifurcado, y la transacción no será revocada o revertida.


En el mecanismo de consenso dBFT de NEO, que se toma unos 15 a 20 segundos para generar un bloque, el rendimiento de la transacción se mide hasta aproximadamente 1.000 TPS, lo cual es un excelente rendimiento entre las cadenas públicas. A través de una optimización adecuada, hay potencial para alcanzar 10.000 TPS, lo que le permite soportar aplicaciones comerciales a gran escala.
dBFT combina la tecnología de identidad digital, lo que significa que los contadores pueden ser el nombre real de una persona o institución. Por lo tanto, es posible congelar, revocar, heredar, recuperar y tranferir la propiedad debido a decisiones judiciales sobre ellos. Esto facilita el registro de activos financieros conformes en la red NEO. La red NEO planea apoyar tales operaciones cuando sea necesario.
 
### Sistema de contrato inteligente: NeoContract

El sistema de contrato inteligente de NEO consta de tres partes:

**NeoVM - Máquina Virtual de Cadena de Bloques Universal:**

NeoVM es una máquina virtual ligera y de uso general cuya arquitectura es muy cercana a la JVM y al .NET Runtime, similar a una CPU virtual que lee y ejecuta instrucciones en el contrato en secuencia, realiza el control del proceso con base en la funcionalidad de las operaciones de instrucción, operaciones lógicas y así sucesivamente. Tiene una buena velocidad de arranque y versatilidad, es muy adecuado para programas pequeños como contratos inteligentes, también puede ser llevado a otros sistemas que no sean de cadena de bloques en la escena, o integrado con el IDE para proporcionar una experiencia óptima de desarrollo. La funcionalidad de NeoVM puede extenderse, como mediante la introducción de un mecanismo JIT (compilador en tiempo real), mejorando así la eficiencia de la implementación.

**InteropService - Servicios Interoperables:**

Se utiliza para cargar el libro mayor de la cadena de bloques, los activos digitales, la identidad digital, el área de almacenamiento permanente y otros servicios subyacentes. Son como máquinas virtuales proporcionadas para las máquinas virtuales, lo que permite que los contratos inteligentes accedan a estos servicios en el momento de la ejecución para cumplir con algunas funciones avanzadas. A través de este diseño de bajo acoplamiento, **NeoVM puede ser llevado a cualquier sistema de cadena de bloques o incluso a un sistema que no sea de cadena de bloques, lo que aumenta la utilidad de los contratos inteligentes.**

**DevPack - Compilador y complemento IDE:**


DevPack incluye el compilador de lenguaje de alto nivel y el complemento IDE. Debido a que la arquitectura de NeoVM es muy similar a JVM y .NET Runtime, los compiladores de DevPack pueden compilar código de bytes Java y .NET MSIL en el conjunto de instrucciones de NeoVM. Los desarrolladores Java / Kotlin, C # no necesitan aprender nuevos lenguajes y podrán comenzar inmediatamente a desarrollar contratos inteligentes en VS, Eclipse y otros entornos IDE que les sean conocidos. **Esto reduce en gran medida la curva de aprendizaje para desarrollar contratos inteligentes, lo que nos permite construir fácilmente una comunidad vibrante alrededor de NeoContract.**

NeoContract puede crear un diagrama de flujo de contratos inteligentes mediante el análisis estático antes de ejecutar un contrato inteligente. **A través del diagrama determinista, el nodo NEO puede fragmentar dinámicamente el contrato inteligente para lograr una expansión teóricamente ilimitada**, que supera el "efecto de interferencia" causado por la fragmentación estática de otros sistemas de cadena de bloques.

### Acuerdo de interoperabilidad entre cadenas: NeoX

NeoX es un protocolo que implementa la interoperabilidad entre cadenas. NeoX se divide en dos partes: el “protocolo de intercambio de bienes de cadena cruzada” y el “protocolo de transacción distribuida de cadena cruzada”.

**Acuerdo de intercambio de activos entre cadenas cruzadas:**

NeoX se ha ampliado en los actuales protocolos de intercambio de activos atómicos de doble cadena para permitir que múltiples participantes intercambien activos a través de diferentes cadenas y asegurar que todos los pasos del proceso de transacción tengan éxito o fracasen en conjunto. Para cumplir con esta función, necesitamos utilizar la función NeoContract para crear una cuenta de contrato para cada participante. Si otras cadenas de bloques no son compatibles con NeoContract, pueden ser compatibles con NeoX siempre y cuando puedan proporcionar la funcionalidad de contrato inteligente simple.

**Protocolo de transacciones distribuidas de cadena cruzada:**

Las transacciones distribuidas de cadena cruzada significan que varios pasos de una transacción están dispersos a través de bloques diferentes y que se garantiza la coherencia de toda la transacción. Esta es una extensión del intercambio de activos entre cadenas cruzadas, ampliando el comportamiento del intercambio de activos a un comportamiento arbitrario. En términos sencillos, NeoX hace posible que en los contratos inteligentes de cadena cruzada, un contrato inteligente pueda realizar diferentes partes en cadenas múltiples, ya sea con éxito o revirtiéndose en su conjunto. Esto ofrece excelentes posibilidades para colaboraciones entre cadenas y estamos explorando escenarios de aplicación de contratos inteligentes entre cadenas.

### Protocolo de Almacenamiento Distribuido: NeoFS

NeoFS es un protocolo de almacenamiento distribuido que utiliza la tecnología Distributed Hash Table. NeoFS indexa los datos a través del contenido del archivo (Hash) en lugar de la ruta del archivo (URI). Los archivos grandes se dividirán en bloques de datos de tamaño fijo que se distribuirán y almacenarán en múltiples nodos diferentes.

El principal problema con este tipo de sistema es la necesidad de encontrar un equilibrio entre redundancia y fiabilidad. NeoFS planea resolver esta contradicción mediante incentivos simbólicos y el establecimiento de un eje de nodos. Los usuarios pueden elegir los requisitos de confiabilidad del archivo. Los archivos con requisitos de baja fiabilidad pueden almacenarse y se puede acceder a ellos de forma gratuita o casi. Los servicios estables y confiables para archivos con requisito de alta confiabilidad serán proporcionados por los nodos backbone.

NeoFS servirá como uno de los servicios de interoperabilidad de InteropService bajo el sistema NeoContract, permitiendo que los contratos inteligentes almacenen archivos grandes en la cadena de bloques y establezcan el acceso para esos archivos. Además, NeoFS se puede combinar con la identidad digital para que los certificados digitales utilizados por las identidades digitales se puedan asignar, enviar y revocar sin necesidad de un servidor central que los gestione. En el futuro, los datos de bloque antiguo se pueden almacenar en NeoFS, de modo que la mayoría de los nodos completos pueden liberar los datos antiguos para una mejor escalabilidad y, al mismo tiempo, garantizar la integridad de los datos históricos.

## Mecanismo de criptografía antiquántica: NeoQS

La aparición de computadoras cuánticas constituye un gran reto para los mecanismos criptográficos basados en RSA y ECC. Los ordenadores cuánticos pueden resolver el gran número de problemas de descomposición (de los que depende la RSA) y el logaritmo discreto de la curva elíptica (en el que se basa la ECC) en muy poco tiempo. NeoQS (Quantum Safe) es un mecanismo criptográfico basado en una rejilla. En la actualidad, los ordenadores cuánticos no tienen la capacidad de resolver rápidamente el problema vectorial más corto (SVP) y el problema vectorial más cercano (CVP), que se considera el algoritmo más fiable para resistirse a los ordenadores cuánticos.

## Resumen 

NEO es una red distribuida que combina activos digitales, identidades digitales y contratos inteligentes. El sistema NEO utilizará DBFT, NeoX, NeoFS, NeoQS y muchas otras tecnologías originales, como infraestructura para la economía inteligente del futuro.
