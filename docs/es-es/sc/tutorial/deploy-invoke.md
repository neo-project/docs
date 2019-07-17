# Desplegar un contrato inteligente con parámetros

## 1 - Introducción

El siguiente documento muestra como desplegar contratos inteligentes con parámetros.
 
## 2 - Recursos útiles

* [Lock2](Lock2.md)
* [Parametros](Parameter.md)
   
## 3 - SC Código
 
## 4 - Desplegar un contrato inteligente con parámetros
 
1. Para desplegar un contrato inteligente `.avm` en la blockchain, click en el menú de opciones `Advanced` en el cliente PC, `Neo-gui` y click en `Deploy Contract`.
2. Rellena todos los campos del apartado `Information`. Todos los campos deben ser rellenados para desplegar el contrato.
3. Click en en `Load` y abre el fichero `.avm`. Una vez cargado el fichero, el código aparecerá en la ventada. Copia el contenido del campo `Code`, lo usaremos más tarde.
4. Rellena el campo `Metadata` segun los parámetros. Consulta los valores de los parámetros, [aquí](Parameter.md)


**Ejemplo**

El siguinte contrato está definido así:

```c#
    public static bool Main( (byte[]) publicKey, (byte[]) Sig, int value ){}
```

Los parámetros serian:

|Parámetro función |Tipo de parámetro|Valor Parámetro|Hexadecimal|
 |---|---|---|---|
 |`byte-array publickey`| PublicKey | 6 | 06 |
 |`byte-array Sig`| Signature| 0| 00 |
 |`int value`| Integer | 2 | 02 |

|Parámetro retorno|Tipo de parámetro|Valor Parámetro|Hexadecimal|
 |---|---|---|---|
 |`bool Main`| Boolean | 1 | 01 |

El valor hexadecimal de los parámetros seria: **060002** y el valor de retorno: **01**
  
5. Si el contrato necesita almacenamiento (usa el método Storage), marca la casilla `Need Storage`
6. Finalmente, click en `Deploy`.

## 5 - Ver el contrato inteligente

1. Desde el cliente PC, `NEO-gui`, en el tab `Account` click con el botón derecho sobre el area y click en `Create Contract. Add` y click en `Custom`.
2. Selecciona la cuenta a la que quieres asociar el contrato desde la lista desplegable `Related Account`. En el campo `Parameter List`, rellena los valores del Paso 4.
3. Inserta el script hash del contracto obtenido en el paso anterior.
4. Click en `Confirm` para cargar el contrato en la cuenta contrato.

 
## 6 - Invocar el contrato inteligente

Para invocar el contrato inteligente en la blockchain NEO, necesitas en script hash del contrato.
1. Para obtener el script hash del contrato, botón derecho sobre la cuenta del contrato anteriormente creada y click en `View Contract`. 
2. Al hacer click, nos aparecerá una ventada de información del contrato. Copía el valor del campo `Script Hash`
3. Una vez copiado en el menú de opciones, click en `Advanced` y click `Invoke Contract`
4. Completa el campo `Script Hash` con el valor copiado en la Paso 1.
5. Al introducir el script hash la información del contrato inteligente deberia completarse.
6. Para completar los parametros, click en `...` del campo `Parameters`
7. Click en `OK`para cerrar la ventana de los parámetros.
8. Click en en el botón `Invoke` para invocar el contrato inteligente.

 
 
