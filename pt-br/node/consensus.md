# Consenso

## 1 - Lista de Termos

- **_Proof of Stake_** (PoS): É um tipo de algoritmo que utiliza o consenso da rede para manejar a tolerância a falhas.
- **_Proof of Work_** (PoW): É um tipo de algoritmo que utiliza poder computacional para cuidar da tolerância a falhas.
- **_Byzantine Fault_** (BF): Uma falha em que um nó, apesar de continuar funcional, funciona de maneira incorreta (desonesta).
- **_Distributed Byzantine Fault Tolerance_** (DBFT): Algortimo implementado na *blockchain* NEO para garantir a tolerância às "falhas bizantinas" (BF).
- **v**: Conjunto de dados do ponto de vista utilizado durante uma atividade de consenso no modelo DBFT da rede NEO.

## 2 - Papéis

No algoritmo de consenso NEO (DBFT), os **Nós de Consenso** (também chamados de *bookkeepers*) são responsáveis pela validade das transações e são escolhidos/eleitos pelos portadores de tokens NEO.

  - <img src="/assets/nNode.png" width="25"> **Nó de Consenso** - Este nó participa da atividade de consenso. Durante uma atividade de consenso, os **nós de consenso** se revezam assumindo os seguintes papéis:
    - <img src="/assets/speakerNode.png" width="25"> **Orador** `(Um a cada rodada)` - O orador é responsável por transmitir uma proposta, isto é, uma versão, da *blockchain* correta à rede.
    - <img src="/assets/cNode.png" width="25"> **Delegado** `(todos que não o orador)` - Os delegados são responsáveis por chegar a um consenso a respeito da versão da *blockchain* recebida do *orador*.
  

## 3 - Introdução

Uma das diferenças fundamentais entre as *blockchains* é o mecanismo utilizado para garantir tolerância a falhas em caso de atividade indesejada, como mau funcionamento, ataque, comportamento desonesto, etc, na rede

Os métodos tradicionais baseados em *PoW* proporcionam esta garantia desde que a maior parte da potência computacional da rede seja honesta (nenhuma entidade concentra poder computacional suficiente para sobrepor o funcionamento honesto da rede e criar uma versão desonesta da *blockchain*). Entretanto, o fato deste mecanismo ser baseado no uso de poder computacional, em outras palavras, uso de energia, torna o *PoW* limitado e ineficiente, sendo uma opção longe da ideal.

O mecanismo utilizado na rede NEO (dBFT) é um algoritmo de consenso tolerante a falhas bizantinas delegado, que aproveita algumas características similares à *PoS* (os portadores de NEO têm participação votando nos Nós de Consenso) que protege a rede com mínima utilização de recursos, ao mesmo tempo em que descarta alguns de seus problemas. Esta solução (DBFT) agrega rendimiento e escalabilidade em comparação às implementações utilizadas em outras *blockchain's*, sem comprometer a tolerância a falhas.

## 4 - Teoria

O *Problema dos Generais Bizantinos* é um problema clássico na computação distribuída. O problema define um número de **_delegados_** que devem chegar a um consenso (todo o grupo aceita o resultado final como verdadeiro) sobre os resultados da ordem de um **_orador_**. Neste contexto devemos observar cuidadosamente o fato de que o **_orador_** em questão ou qualquer número de **_delegados_** pode(m) ser traidor(es). Um nó desonesto poderia enviar uma mensagem inconsistente aos demais nós. A solução deste problema requer que os **_delegados_** identifiquem se o **_orador_** é honesto e qual a verdadeira ordem dada.

A fim de descrever o funcionamento do DBFT, nesta sessão vamos dar atenção à justificativa de a taxa de consenso utilizada na sessão seguinte ser de 66,66%. Tenha em mente que um nó desonesto não é ativamente malicioso, ele pode simplesmente não agir dentro do esperado.

Para melhor compreensão, vamos abordar dois cenários diferentes e descrever a diferença entre um sistema funcional e um disfuncional. Para mais detalhes mais parofundados, consulte as referências. Para simplicar, assumiremos que cada NÓ repassa adiante a mesma mensagem que recebeu do **_orador_**. Esta dinâmica também acontece no DBFT e é crítica para o sistema. 


### **Orador honesto**

  Na figura 1 temos apenas 1 **_delegado_**. Ambos os **_delegados_** recebem a mesma mensagem, uma vez que o **_orador_** é honesto, entretando, devido à controvérsia no conteúdo da mensagem do **_delegado_** desonesto, o **_delegado_** honesto sabe que, e apenas que, há um nó desonesto na rede, sem saber se este é o **_orador_** ou o outro **_delegado_**. Dada esta condição, o **_delegado_** deve se abster de uma votação (afinal ele não sabe qual informação é verdadeira), revezando o nó **_orador_**. A taxa de consenso é de 50%, pois temos 1 **_delegado_** honesto e 1 desonesto.

  <p align="center"> <img src="/assets/n3.png" width="400"><br> 
  <b>Figura 1:</b> Exemplo 1 <br>
	n = 3 com 1 <b><i>delegado</i></b> desonesto</p>
<p><br><br></p>
 
 
Agora, na figura 2, temos 2 **_delegados_** honestos. Todos os **_delegados_** recebem a mesma mensagem, uma vez que o **_orador_** é honesto, entretando, o **_delegado_** desonesto repassa uma mensagem diferente aos demais. Para esta condição é possível chegar a conclusão de que ou o **_orador_** ou o **_delegado_** da direita é desonesto. A taxa de consenso dessa vez é de 66,66%, pois temos 2 **_delegados_** com uma versão (honestos) e 1 **_delegado_** com outra (desonesto).

 <p align="center"><img src="/assets/n4.png" width="400"><br> 
 <b>Figura 2:</b> Exemplo 2<br>
	n = 4 com 1 <i><b>delegado</b></i> desonesto</p>
<p><br><br></p>


### **Orador desonesto** 
    
  Temos uma situação semelhante à do exemplo 1. Nenhum **_delegado_** consegue identificar quem é desonesto na rede, apenas que há um nó desonesto. Novamente temos uma taxa de consenso de 50%, afinal são 2 mensagens recebidas, cada uma diferente da outra.


  <p align="center"><img src="/assets/g3.png" width="400"><br> 
  <b>Figura 3:</b> Exemplo 3<br>
	n = 3 com 1 <i><b>orador</b></i> desonesto</p>
<p><br><br></p>
   
  
 No exemplo 4, as versões recebidas pelo nó esquerdo e pelos demais são diferentes. Neste caso, como há 66,66% de consenso sobre a divergência, todos votam para que uma nova rodada seja realizada, alterando o **_orador_** da vez, o que nos leva a um cenário como o do exemplo 1.
 
   <p align="center"><img src="/assets/g4.png" width="400"><br>
   <b>Figura 4:</b> Exemplo 4<br>
	n = 4 com 1 <i><b>orador</b></i> desonesto<br><br></p>     
     
<p><br><br></p>
	     
## 5 - Implementação Prática

A implementação prática do DBFT no NEO utiliza um mecanismo de conversão iterativo para garantir que o consenso seja alcançado. O desempenho do algoritmo depende da fração de **_delegados_** honestos no sistema. A figura abaixo ilustra as iterações esperadas em função da fração de **_delegados_** honestos no sistema.

<p align="center"> <img src="/assets/consensus.iterations.png" width="800"> <br>
<b>Figura 5:</b> *Simulação de Monte Carlo do DBFT com uma população de 100 Nós; 100.000 blocos simulados (ou seja, versões da verdade simuladas) e seleção aleatória de nós honestos*<br><br></p>

> [!Note]
> Para uma fração de **_delegados_** honestos entre 33,33% e 66,66%, o algoritmo diverge.
> Para uma fração de **_delegados_** honestos abaixo de 33,33%, a versão desonesta pode se tornar a escolhida pelo consenso.


### 5.1 - Definições

**Dentro do algoritmo, definimos o siguinte:**

  - `t`: tempo, em segundos, alocado para a geração de blocos; Atualmente: `t = 15`
  	- Este valor pode ser utilizado para calcular a duração aproximada de uma iteração da atividade de consenso
	
  - `n`: número de **Nós de Consenso** ativos
  - `f`: limite máximo de falhas (Nós de Consenso desonestos/defeituosos) no sistema para que o algoritmo continue convergente  
	<pre><code><p align="center"><b><i>f = (n - 1) / 3</i></b></p></code></pre>
 
  - `h` : altura (tamanho) da *blockchain* durante as atividades de consenso
  
  - `i` : índice do **Nó de Consenso**
   
  - `v` : ponto de vista de um Nó de Consenso. O ponto de vista contém a informação emitida por todos os **_delegados_** durante uma rodada da atividade de consenso, incluindo o voto em avançar na validade da versão da *blockchain* (**prepareResponse**) ou em revezar o ponto de vista para uma nova rodada de consenso (**ChangeView**)

  - `k` : índice do ponto de vista `v`. Uma atividade de consenso requer múltiplas rodadas (diferentes pontos de vista) para convergir
  
  - `p` : índice do **Nó de Consenso** **_orador_**. O cálculo do índice reveza entre os **Nós de Consensos** para prevenir que apenas um nó seja ditador do sistema 	
	<pre><code><p align="center"><b><i>p = (h - k) mod (n)</i></b></p></code></pre>
 
  - `s` : número mínimo de **Nós de Consenso** honestos para  manter a segurança do consenso. Abaixo desse limiar, a rede fica exposta a falhas  
	<pre><code><p align="center"><b><i>s  =  (n - 1) - f  =  2 / 3 * (n - 1)</i></b></p></code></pre>


### 5.2 - Requisitos

**O mecanismo de consenso do NEO tem três exigências primordiais para garantir a tolerância a falhas de consenso:**

1. Um bloco só é publicado após `s` **_delegados_** chegarem a um consenso 
2. **Nós de Consenso** **desonestos** não devem ser capazes de persuadir os **honestos** em transações defeituosas
3. Ao menos `s` **_delegados_** devem estar no mesmo estado (`h`, `k`) para realizar uma atividade de consenso    
    
    

	
### 5.3 - Algoritmo

**Funcionamento do algoritmo:**

1. Um **Nó de Consenso** transmite uma transação a toda a rede com assinatura do remetente

   <p align="center"><img src="/pt-br/assets/consensus1_noblank.png" height="400"><br> 
   <b>Figura 6:</b> Um <b>Nó de Consenso</b> recebe uma transação e a transmite ao sistema<br><br></p>
    
2. Os **Nós de Consenso** gravam os dados da transação na memória local

3. O primero ponto de vista `v` é definido e inicia-se a rodada da atividade de consenso

4. O **_orador_** é identificado

	 <p align="center"><img src="/pt-br/assets/consensus2_align.png" height="400"><br> 
   <b>Figura 7:</b> Um ponto de vista é estabelecido e um <i><b>orador</b></i> é identificado<br><br></p>
	
  Aguarda-se `t` segundos
	
5. O **_orador_** transmite a proposta/versão do bloco correto:
    <pre><code><p align="center"><b>< prepareRequest, h, k, p, block, [block]sigp ></b></p></code></pre>

	 <p align="center"><img src="/pt-br/assets/consensus3_align.png" height="400"><br> 
   <b>Figura 8:</b> O <i><b>orador</b></i> apresenta uma versão de bloco para revisão pelos <i><b>Delegados</b></i><br><br></p>
	 
   
6. Os **_delegado_** recebem a versão proposta e a validam:

    - Os dados são consistentes com as normas do sistema?
    - A transação já está na *blockchain*?
    - Os scripts de **smart contrats** foram executados corretamente?
    - A transação é de cobrança única? (*isto é, a transação não se enquadra em um cenário de *cobrança duplicada*, quando uma mesma cobrança é paga mais de uma vez*)
    - **Se a versão proposta é válida:**
	<pre><code><p align="center"><b>< prepareResponse, h, k, i, [block]sig(i) ></b></p></code></pre>
    - **Se a versão proposta é inválida:**  
	<pre><code><p align="center"><b>< ChangeView, h, k, i, k+1 ></b></p></code></pre>
	
			
   <p align="center"><img src="/pt-br/assets/consensus4_noblank.png" height="400"><br> 
   <b>Figura 9:</b> Os <i><b>delegados</b></i> revisam a versão de novo bloco proposta pelo <i><b>orador</b></i> e respondem entre si<br><br></p>     
   


7. Após receber ao menos uma quantidade `s` de respostas `prepareResponse`, um _**delegado**_ chega a um consenso e publica o novo bloco


8. O _**delegado**_ assina o bloco na *blockchain*

   <p align="center"><img src="/pt-br/assets/consensus5_noblank.png" height="400"><br> 
   <b>Figura 10:</b> Se chega a um consenso e os <i><b>Delegados</b></i> assinam o bloco, vinculando-o na <i>blockchain</i><br><br></p>
  
  
9. Quando um **Nó de Consenso** recebe um bloco completo, o ponto de vista é redefinido e uma nova rodada na atividade de consenso se inicia com `k = 0`
<p><br></p>
 
---    
  
**Nota:**
 
 Se após ![timeout](/assets/consensus.timeout.png) segundos, em um mesmo ponto de vista, não se chegou a um consenso, o **Nó de Consenso** transmite:	
<pre><code><p align="center"><b>< ChangeView, h, k, i, k+1 ></b></p></code></pre>
		
Uma vez que um **Nó de Consenso** recebe ao menos `s` transmissões com a resposta de `ChangeView` (alterar ponto de vista), o valor de `v` é incrementado e inicia-se uma nova rodada na atividade de consenso.
	

## 6 - Referências
1. [A Byzantine Fault Tolerance Algorithm for Blockchain](https://www.neo.org/Files/A8A0E2.pdf)
2. [Practical Byzantine Fault Tolerance](http://pmg.csail.mit.edu/papers/osdi99.pdf)
3. [The Byzantine Generals Problem](https://www.microsoft.com/en-us/research/wp-content/uploads/2016/12/The-Byzantine-Generals-Problem.pdf)

