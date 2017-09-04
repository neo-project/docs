# Tutorial contratos inteligentes NEO

Después de leer los tutoriales anteriores, deberías tener la capacidad de crear un proyecto de contrato inteligente
en `Visual Studio 2017`. Aquí hablaremos de cómo se ejecutan los contratos inteligentes en la máquina virtual de NEO. (Neo-VM)

## Desencadenadores de contratos inteligentes

Existen dos formas de desencadenar contratos inteligentes:

1. Contrato de autenticación de usuario: Aquí el contrato inteligente es una cuenta. Cuando el usuario usa un activo (por ejemplo una transferencia) de la cuenta contrato se desencadena el contrato inteligente.

2. Enviar manualmente una solicitud de transacción de contrato inteligente: Aquí el usuario genera una transacción (Invocación de Transacción) para desencadenar la implementación de un contrato inteligente.

## Tipos de contratos inteligentes

Los contratos inteligentes tienen dos clases base, `FunctionCode` y `VerificationCode.`

### Contrato inteligente que hereda de FunctionCode

Este tipo de contratos pueden ser compilados y distribuidos a la blockchain para que sean utilizados por otros usuarios. Es equivalente a una "función" en el mundo de la programación, pudiendo ser llamado tanto por la "Main" como por "otras funciones" (otros contratos inteligentes que hereden de FunctionCode).

El punto de entrada para el contrato inteligente es el método `Main`. El valor de retorno puede ser `void`, `int`, o `byte`. 

Ejemplo de un contrato vacío que hereda de FunctionCode:

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Nota: El método main comienza en mayúscula
    {
    // El contrato inteligente hereda de FunctionCode, puede ser compilado y publicado en la
    //blockchain para que otros usuarios lo usen.
    }
}
```

### Contrato inteligente que hereda de VerificationCode

Este tipo de contrato hereda de VerificationCode, puede generar una dirección de contrato en el monedero del cliente. El contrato inteligente se desencadena si el usuario desea usar un activo de la dirección de contrato. El usuario crea/invoca una transacción.


Cuando el contrato retorna un valor `true` la validación se valida y usuario puede usar el activo. En caso contrario, fallo en la autenticación, el contrato retorna un valor false y el usuario no podrá usar el activo. La transacción que ha fallado en la verificación no puede ser transmitida por otro nodo y no se confirmará por el nodo de consenso.

Ejemplo de un contrato que hereda de VerificationCode. El valor de retorno en el método `Verify` debe ser de tipo `bool`.

```c#
public class Contract1: VerificationCode
{
    public static bool Verify ()
    {
        return true;
    }
}
```

## Máquina Virtual de Neo

Neo-VM es la máquina virtual que ejecuta el código de los contratos inteligentes de Neo. Hablamos de máquina virtual en el sentido estricto del término, no en referencia a sistemas operativos o programas que puedan simularlas como son VMware o Hyper-V.

Por ejemplo, en la JVM de java o en el CLR de .NET el código fuente es compilado en su correspondiente bytecode y ejecutado por su correspondiente máquina virtual. Tanto la JVM o el CLR ejecutarán el bytecode de la misma forma que si se ejecutara en una máquina física real. Aún así, las correspondientes instrucciones binarias se siguen ejecutando en una máquina física. La máquina física obtiene las instrucciones de la memoria, las transfiere a la CPU a través del bus, se decodifican, se ejecutan y almacena el resultado.

### Arquitectura de la máquina virtual

<img style="vertical-align: middle" src="/assets/neo-vm.jpg">
   

El diagrama de arriba muestra la arquitectura del sistema para la máquina virtual de Neo (Neo-VM), donde la parte contenida dentro de la línea de puntos es el núcleo de la máquina virtual.

#### Motor de ejecución

La parte verde de la derecha es el motor de ejecución de la máquina virtual (equivalente a la CPU) donde puede ejecutar 
instrucciones comunes como control de flujo, operaciones de pila, operaciones de bits, operaciones aritméticas, método criptograficos e interactuar con la capa del servicio de interoperabilidad. (descrito abajo)

#### Calcular pila

La parte media del gris es la pila de computación de la máquina virtual (equivalente a la memoria). La máquina virtual tiene dos formas para computar la pila, ya sea basado en la pila o basado en el registro. La dos formas de lograr esto tiene sus ventajas y desventajas. En la actulidad existen máquinas virtuales basadas en la pila como JVM, CPython y .Net CLR y máquinas virtuales basadas en registros existen en reales. Las máquinas virtuales basadas en la pila tienen un concepto de pila que permite a las máquinas virtuales interactuar directamente con la pila al realizar operaciones reales.

Como por defecto es recuperar datos de la pila de operandos no hay necesidad de especificar operandos. Por ejemplo, en ensamblador x86 la operación "ADD EAX, EBX" tienes que especificar donde se realizará la operación y en que lugar se guardaran los resultados. Las intrucciones de la máquina virtual basadas en pila no necesita especificar estos parámetros. Por ejemplo, para una operación de suma los operandos se guardan en la pila de operandos y podemos extraerlos directamente de la pila para hacer la suma.

#### Capa del servicio de interoperabilidad

La parte azul del lado derecho es la capa de servicio interoperable de la máquina virtual (equivalente a los periféricos). En la actualidad, la capa de servicio interoperabilidad proporciona algunas API para acceder a los datos de cadena del contrato inteligente, que pueden acceder a información de bloque, información de transacción, información de contrato, información de activos, etc.

Además, la capa de servicio interoperable también proporciona un área de almacenamiento persistente para cada contrato. Cada uno de los contratos inteligentes se crea opcionalmente con almacenamiento privado, que es un objeto del tipo valor-clave determinado por el destinatario del contrato, en lugar del contexto del almacén persistente.


### Carga de tarifas

Un contrato inteligente se puede programar para cargar cierta tarifa, dividida entre costes de desarollo y costos de implementación.

Los costes de desarrollo hacen referencia a la necesidad del desarrollador a desplegar un contrato inteligente en la blockchain y pagar una tarifa por el despliegue. (Actualmente de 500 NeoGas). Los costes de ejecución el usuario paga por ejecutar un contrato inteligente. (Es gratis)

## Contrato inteligente sencillo

Ejemplo de un contrato inteligente sencillo que hereda de VerificationCode

```c#
public static bool Verify ()
{
    return true;
}
```

Aquí el valor de retorno siempre es true, indicando que cualquiera puede consumir la dirección del contrato de los activos (puede entenderse como dinero).

Existe una función para eliminar un activo del monedero del cliente. Cuando se elimina un activo, este es enviado a una dirección especificada que es la dirección del contrato generada por el contrato inteligente anterior.

```c#
public static bool Verify ()
{
    return false;
}
```

El valor de retorno del contrato es siempre falso, lo que indica que los activos de este contrato no puede ser utilizado (se puede entender como destruir un activo)

Para más ejemplo, ver:

[Call](tutorial/call.md)

[Deploy-Invoke](tutorial/deploy-invoke.md)

[Domain](tutorial/Domain.md)

[HelloWorld](tutorial/HelloWorld.md)

[Lock](tutorial/Lock.md)

[Lock2](tutorial/Lock2.md)

[Verify](tutorial/Verify.md)

