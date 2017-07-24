# Introducción a los contratos inteligentes NEO

## ¿Qué es un contrato inteligente?

Un contrato inteligente es una serie de compromisos definidos de forma digital, incluyendo el acuerdo que el emisor puede realizar en esos compromisos. La tecnología Blockchain nos permite tener un sistema descentralizado, no manipulable y de alta confiabilidad donde los contratos inteligentes son muy útiles. Los contratos inteligentes son una de la características más importantes de la blockchain, es por ello que se le puede llamar tecnología disruptiva.

## ¿Cuales son las características de los contratos inteligentes de Neo?

Los contratos inteligentes 2.0 de NEO incluyen las siguientes características: seguridad, alto rendimiento y capacidad de expansión. Estos pueden ser del siguiente tipo: contratos de validación, funciones y aplicaciones.

Desde el punto de vista del rendimiento, NEO utiliza una máquina virtual ligera (Neo-VM), como  entorno de ejecución de contratos inteligentes, este se inicia muy rápido utilizando una cantidad mínima de recursos, perfecto tanto para los contratos inteligentes como para procedimientos sencillos. Tanto la compilación estática como el cacheado de los contratos activos puede ser significativamente mejorada a través de la tecnología JIT (compilación en tiempo real). La configuración instruccional de la máquina virtual de Neo proporciona una serie de instrucciones criptográficas para optimizar la eficiencia en la ejecución de los algoritmos criptográficos de los contratos inteligentes. Además, las instrucciones de manipulación de datos son directamente compatibles con matrices y estructuras de datos complejas, lo que mejorará el rendimiento.

Los contratos inteligentes 2.0 logran un enfoque escalable a través de la combinación de una alta concurrencia y un particionamiento dínamico junto a un diseño de bajo acoplamiento. El procedimiento del contrato es ejecutado por una máquina virtual (máquina virtual de Neo) y se comunica con el exterior a través de una capa de servicios interctiva. Por lo tanto, la inmensa mayoría de mejoras en la función de contrato inteligente se pueden realizar a través de la API de la capa de servicios interactiva.

## Crear un contrato inteligente en diferentes lenguajes

Desde el punto de vista del lenguaje, la diferencia entre NEO y Ethereum es más intuitiva: a diferencia del lenguaje Solidity de Ethereum, el contrato de NEO puede ser usado directamente por casi cualquier lenguaje de programación de alto nivel. Los primeros lenguages soportados son C#, VB.Net, F# y así sucesivamente. Neo proporciona compiladores y plug-ins para compilar estos lenguajes en un conjunto de instruciones interpretables por la máquina virtual de NEO. El primer compilador será para MSIL (lenguaje intermedio de Microsoft) de manera que cualquier lenguaje en .Net será compatible y pasado a MSIL.

Neo también proporciona compiladores y plug-ins utilizados para compilar lenguajes de alto nivel en conjuntos de instrucciones interpretables por la máquina virtual. El compilador usa MSIL (lenguaje intermedio de Microsoft) para compilar, por lo que teoricamente cualquier lenguaje .Net que pueda ser pasado al lenguaje MSIL será directamente compatible.

Lenguajes actualmente soportados:

1) C#, VB.Net, F#
2) Java, Kotlin

Lenguajes avanzados que planeamos soportar:

1) C, C ++, GO
2) Python, JavaScript

Nuestro objetivo es que los desarrolladores no necesiten aprender un nuevo lenguaje para participar en el desarrollo de un contrato inteligente. Los sistemas de código de negocio existentes pueden ser portados directamente a la blockchain. Creemos que esto aumentará en gran medida la popularidad de la blockchain.

Normalmente los contratos inteligentes son dificiles de depurar y probar dada la falta de herramientas. Neo proporcionará soporte para poder depurar a nivel de la Neo-VM, facilitando la creación de contratos.
