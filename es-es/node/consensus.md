# Consenso

## 1 - Lista de Términos

* **Prueba de Participación** (PoS)  - Un tipo de algoritmo que utiliza el consenso de la red para manejar la tolerancia ante los fallos.
* **Prueba de Funcionamiento** (PoW) - Un tipo de algoritmo que utiliza la potencia de cálculo para manejar la tolerancia ante los fallos.
* **Fallo Bizantino** (BF) - Un fallo en el que un nodo permanece funcional, pero opera de manera deshonesta.
* **Tolerancia Delegada ante Fallo Bizantino** (DBFT) - Un algoritmo de consenso implementado dentro de la cadena de bloque NEO para garantizar la tolerancia ante los fallos.
* **Vista v** - El conjunto de datos utilizado durante una actividad de consenso en NEO DBFT.

## 2 - Roles

**En el algoritmo de consenso de NEO, los nodos de consenso son elegidos por los titulares de NEO y votan sobre la validez de las transacciones. Estos nodos también se han referido como 'Bookkeepers'. En adelante, se denominarán Nodos de Consenso**

  - <img style="vertical-align: middle" src="/assets/nNode.png" width="25"> **Nodo de Consenso** - Este nodo participa en la actividad de consenso. Durante una actividad de consenso, los nodos de consenso toman turnos asumiendo los siguientes dos roles:
  - <img style="vertical-align: middle" src="/assets/speakerNode.png" width="25"> **Orador** `(Uno)` - El Orador es responsable de la transmisión de una propuesta de bloques al sistema.
  - <img style="vertical-align: middle" src="/assets/cNode.png" width="25"> **Delegado** `(Múltiples)` - Los Delegados son responsables de alcanzar un consenso respecto a la transacción.
  

## 3 - Introduction

Una de las diferencias fundamentales entre las cadenas de bloques es cómo pueden garantizar la tolerancia ante los fallos en caso de actividad defectuosa, no honesta en la red.

Los métodos tradicionales implementados mediante PoW pueden proporcionar esta garantía siempre y cuando la mayoría de la potencia computacional de la red sea honesta. Sin embargo, debido a la dependencia de este esquema en la computación, el mecanismo puede ser muy ineficiente (la energía computacional cuesta energía y requiere hardware). Estas dependencias exponen una red PoW a una serie de limitaciones, siendo la principal el costo para el escalado.

NEO implementa un algoritmo de consenso delegado de tolerancia a fallos bizantinos (DBFT) que aprovecha algunas características similares a PoS (los titulares de NEO votan en nodos de consenso) que protege a la red de las fallas bizantinas utilizando recursos mínimos y rechaza algunos de sus problemas. Esta solución aborda los problemas de rendimiento y escalabilidad asociados con las actuales implementaciones de cadenas de bloques sin un impacto significativo en la tolerancia a fallos.

## 4 - Teoría

El Problema de los Generales Bizantinos (DBFT) es un problema clásico en la computación distribuida. El problema define a varios Delegados que deben llegar a un consenso sobre los resultados de la orden de un Orador. En este sistema, debemos tener cuidado porque el Orador o cualquier número de Delegados podrían ser traidores. Un nodo deshonesto puede no enviar un mensaje consistente a todos los destinatarios. Esta es considerada la situación más desastrosa. La solución del problema requiere que los Delegados identifiquen si el Orador es honesto y cuál era el comando real como grupo.

Con el propósito de describir cómo funciona la DBFT, nos centraremos principalmente en esta sección sobre la justificación de la tasa de consenso del 66,66% utilizada en la Sección 5. Ten en cuenta que un nodo deshonesto no necesita ser activamente malicioso, simplemente puede no estar funcionando según lo previsto.

Para el bien de la discusión, describiremos un par de escenarios. En estos ejemplos simples, asumiremos que cada nodo envía el  mensaje que recibió del **Orador**. Este mecánico se utiliza en DBFT también y es crítico para el sistema. Solo describiremos la diferencia entre un sistema funcional y un sistema disfuncional. Para una explicación más detallada, consulta las referencias.


### **Orador honesto**

  <p align="center"><img src="/assets/n3.png" width="300"><br> <b>Figura 1:</b> Un ejemplo n = 3 con un <b>Delegado</b> deshonesto.</p>
  
  En la **Figura 1**, tenemos un solo **Delegado** fiel (50%). Ambos **Delegados** recibieron el mismo mensaje del honesto **Orador**. Sin embargo, debido a que un **Delegado** es deshonesto, el **Delegado** honesto unicamente puede determinar que hay un nodo deshonesto, pero es incapaz de identificar si es el nucleador de bloque (block nucleator) (**el Orador**) o el **Delegado**. Debido a esto, el **Delegado** debe abstenerse de una votación, cambiando la vista.

 <p align="center"><img src="/assets/n4.png" width="400"><br> <b>Figura 2:</b> Un ejemplo n = 4 ejemplo con un deshonesto <b>Delegado</b>.</p>
 
En la **Figura 2**, tenemos dos **Delegados** leales (66%). Todos los **Delegados** recibieron el mismo mensaje del honesto **Orador** y enviaron su resultado de validación, junto con el mensaje recibido del Orador entre los **Delegados**. Con base en el consenso de los dos **Delegados** honestos, podemos determinar que el **Orador** o el **Delegado** de la derecha es deshonesto en el sistema.
 
  
### **Orador deshonesto** 
  
  <p align="center"><img src="/assets/g3.png" width="300"><br> <b>Figura 3:</b> Un ejemplo n = 3 con un <b>Orador</b> deshonesto.</p>
  
  En el caso de la **Figura 3**, el **Orador** deshonesto, tenemos una conclusión idéntica a la que se muestra en la Figura 1. Ni siquiera el **Delegado** puede determinar qué nodo es deshonesto.
    
  <p align="center"><img src="/assets/g4.png" width="400"><br> <b>Figura 4:</b> Un ejemplo n = 4 con un <b>Orador</b> deshonesto. </p>
  
 En el ejemplo representado por la Figura 4 los bloques recibidos por el nodo central y el derecho no son validados. Esto los hará esperar para una nueva vista para elegir un nuevo Orador porque llevan una mayoría del 66%. En este ejemplo, si el Orador deshonesto hubiese enviado datos honestos a dos de los tres Diputados, habría sido validado sin necesidad de un cambio de vista.
  
## 5 - Implementación Práctica

La implementación práctica de DBFT en NEO usa un método de consenso iterativo para garantizar que se alcance el consenso. El desempeño del algoritmo es dependiente a la fracción de nodos honestos en el sistema. La **figura 5** muestra las iteraciones esperadas en función de la fracción de nodos deshonestos.

Tenga en cuenta que la **Figura 5** no se extiende por debajo del 66,66% de honestidad del **Nodo de Consenso**. Entre este punto crítico y la honestidad del nodo de consenso del 33%, hay una "tierra de nadie" donde el consenso es inalcanzable. Por debajo del 33,33% la honestidad del nodo de consenso, los nodos deshonestos (suponiendo que están alineados en el consenso) son capaces de llegar a un consenso y convertirse en el nuevo punto de verdad en el sistema.

<img src="/assets/consensus.iterations.png" width="800">

**Figura 5:** Simulación montecarlos del algoritmo DBFT algorithm representando las iteraciones necesarias para llegar a un consensos. {100 Nodos; 100,000 Bloques simulados con seleción aleataria de nodos honestos.}


### 5.1 - Definiciones

**Dentro del algoritmo, definimos lo siguiente:**

  - `t`: La cantidad de tiempo asignado para la generación de bloques, medido en segundos.
    - Actualmente: `t = 15 segundos`
	-  Este valor puede usarse para aproximarse a la duración de una sola iteración de vista, ya que la actividad de consenso y los eventos de comunicación son rápsidos con relación a esta constante de tiempo.
	
  - `n`: El número de **nodos de consenso** activos.
  - `f`: El umbral mínimo de los nodos consensos defectuosos dentro del sistema. 
  	- `f = (n - 1) / 3`
 
  - `h` : La altura (tamaño) actual del bloque durante la actividas del consenso.
  
  - `i` : Indice del **nodo consenso**.
   
  - `v` : La vista de un nodo consenso. La vista contiene información agregada que el nodo ha recibido durante una ronda de consenso. Esto incluye el voto (`prepareResponse` o `ChangeView`) emitidos por todos los delegados.

  - `k` : El índice de la vista `v`. Una actividad de consenso require múltipes rodas.  Cuando el consenso falla, `k` se incrementa y una nueva ronda de consenso comienza.
  
  - `p` : Índice del **nodo consenso** elegido como **Orador**. Este mecanismo de cálculo para este índice rota a través de los **nodos consensos** para prevenir que un solo nodo como dictador del sistema.
  	- `p = (h - k) mod (n)`
 
  - `s`: El umbral de consenso seguro. Por debajo de este umbral, la red está expuesta a fallo.  
  	- `s = ((n - 1) - f)`


### 5.2 - Requerimientos

**En NEO, hay tres requisitos principales para la tolerancia a fallos de consenso:**

1. `s` Los **Delegados** deben llegar a un consenso sobre una transacción antes de que un bloque se se publique.

2. Deshonestos **Nodos consenso** no deben ser capaces de persuadir a los nodos de consenso honestos de transacciones defectuosas.

3. Al mensos `s` **Delegados** están en el mismo estado (`h`,`k`) para llegar a una actividad de consenso.

	
### 5.3 - Algoritmo

**El algoritmo funciona de esta manera:**

1. Un **Nodo consenso** transmite una transacción a toda la red con la firma del remitente.

   <p align="center"><img src="/assets/consensus1.png" width="450"><br> <b>Figura 6:</b> Un <b>Nodo consenso</b> recibe una transacción y la transmite al sistema. </p>
    
2. **Nodo consenso** cargan los datos de la transacción en memoria local.

3. Se inicia la primera vista `v` de la actividad de consenso.

4. Se identifica el **Orador**.

	 <p align="center"><img src="/assets/consensus2.png" width="450"><br> <b>Figura 7:</b> Un <b>Orador</b> ha sido identificado y la vista ha sido establecida. </p>
	
  **Espera** `t` segundos
	
5. El **Orador** transmite la propuesta :
    <!-- -->
        <prepareRequest, h, k, p, bloque, [bloque]sigp>

	 <p align="center"><img src="/assets/consensus3.png" width="450"><br> <b>Figure 8:</b> El <b>Orador</b> presenta una propuesta de bloque para su revisión por los <b>Delegados</b>. </p>
	 
6. Los **Delegados** reciben la propuesta y la validan:

    - ¿Son los datos consistentes con las reglas del sistema?
    - ¿Ya está la transacción en la blockchain?
    - ¿Están los scripts del contrato correctamente ejecutados?
    - ¿La transacción sólo contiene un gasto? (Es decir, ¿la transacción evita un escenario de gasto doble?)

    - **Si se valida la propuesta:**
	    <!-- -->
	        <prepareResponse, h, k, i, [block]sigi>
	 	
    - **Si se invalida la propuesta:**
	    <!-- -->
	        <ChangeView, h,k,i,k+1>
			
   <p align="center"><img src="/assets/consensus4.png" width="500"><br> <b>Figura 9:</b> Los <b>Delegado</b> revisan la propuesta de bloque y responden. </p>

7. Después de recibir `s` numeros de 'prepareResponse' de transmisiones, un **Delegado** llega a un consenso y publica el bloque.

8. El **Delegado** firma el bloque.

   <p align="center"><img src="/assets/consensus5.png" width="500"><br> <b>Figura 10:</b> Se llega a un consenso y se aprueba a los <b>Delegados</b> para firmar el bloque, vinculándolo a la cadena. </p>
  
8. Cuando un **Nodo Consenso** recibe un bloque completo, la actual de la actual data se purga, y una nueva ronda de consenso comienzaa.
	- `k = 0`
 
--- 
  
**Nota:**
 
 Si después (![timeout](/assets/consensus.timeout.png) ) segundos en la misma vista sin conseso:
  - El **Nodo Consenso** transmite:

	<!-- -->
	    <ChangeView, h,k,i,k+1>
		
  - Una vez que el **Nodo consenso** recibe al menos `s` numeros de transmisiones con el mismo cambio de vista, incrementa la vista `v`, lanzando una nueva ronda de consenso.
	

## 6 - Referencias
1. [A Byzantine Fault Tolerance Algorithm for Blockchain](https://www.neo.org/Files/A8A0E2.pdf)
2. [Practical Byzantine Fault Tolerance](http://pmg.csail.mit.edu/papers/osdi99.pdf)
3. [The Byzantine Generals Problem](https://www.microsoft.com/en-us/research/wp-content/uploads/2016/12/The-Byzantine-Generals-Problem.pdf)

