# Um Algoritmo de Tolerância a Falhas Bizantinas Para *Blockchain*

*original por:*
Erik Zhang
erik@vcage.com


## Resumo
Este artigo propõe um algoritmo de Tolerância a Falhas Bizantinas aperfeiçoado para um sistema *blockchain*. Hipoteticamente, neste sistema as mensagens estão sujeitas a perda, dano, latência e repetição. Além disso, a ordem de envio pode não ser necessariamente consistente com a ordem de recebimento de mensagens. As atividades dos nós podem ser arbitrárias, eles podem entrar e sair da rede a qualquer momento; eles podem também apagar ou falsificar informações ou simplesmente pararem de funcionar corretamente. Problemas, artificiais ou não, podem ocorrer. Nosso algoritmo oferece uma tolerância a 𝑓 falhas para um sistema de consenso composto por 𝑛 nós validadores (nós de consenso), onde 𝑓 = ⌊(𝑛−1) / 3⌋. Essa tolerância diz respeito a falhas de segurança, bem como usabilidade, e é adaptável para qualquer ambiente de rede.


## Visão Geral
Uma *blockchain* é um sistema de registros (transações, como em um registro contábil) descentralizado e distribuído. Pode ser utilizada para registro e emissão de ativos digitalizados, certificados de direitos de propriedade, consórcios, etc. Permite transferências, pagamentos e transações *peer-to-peer* (sem sem mediação de terceiros). A tecnologia *blockchain* foi originalmente proposta por Satoshi Nakamoto para uma lista de mensagens criptografas, o Bitcoin. Desde então, inúmeras aplicações baseadas na *blockchain* vêm surgindo, como sistemas *e-cash*, bolsa de ações e sistemas de *smart contracts*.
O sistema *blockchain* é vantajoso em relação ao sistema tradicional de registro centralizado quando falamos em abertura, imutabilidade e meios anti cobrança em multiplicidade, além de não depender da mediação de terceiros.

Contudo, como todo sistema distribuído, sistemas *blockchain* são desafiadores quando se trata de latência na rede, tramissão de erros, bugs de software, falhas de segurança e ataques hackers. Além do mais, sua natureza descentralizada sugere que nenhum participante do sistema não possa ser confiável. Nós maliciosos podem surgir, bem como disparidade de dados devido a conflito de interesses.

Para prevenir estes erros em potencial, uma *blockchain* obrigatoriamente precisa ter um mecanismo de consenso eficiente que garanta que todo nó tenha uma cópia válida de todo o registro da rede. Os mecanismos tradicionais de tolerância a falhas não são totalmente capazes de lidar com os problemas que sistemas distribuidos e de *blockchain* enfrentam. Uma solução universal se faz necessária.


#### *Proof-of-Work* (PoW) - "Prova Por Trabalho/Potência"
O mecanismo *Proof-of-Work*[1], empregado pelo Bitcoin, cuida destas adversidades de forma brilhante. Porém, essa solução tem um preço caro, que é de consumos colossais de energia (eletricidade). Além disso, com a existência do Bitcoin, novas *blockchains* precisam encontrar diferentes algoritmos de criptografia para se prevenirem de ataques. Por exemplo, Litecoin adota o SCRYPT, ao invés do SHA256 como o Bitcoin.

#### *Byzantine Fault Tolerance* (BFT) - Tolerância a Falhas Bizantinas
O mecanismo de consenso BFT representa uma solução universal para sistemas distribuídos[5]. Neste artigo, baseado no mecanismo de Tolerância Prática a Falhas Bizantinas (PBFT)[3]  proposto por Castro e Liskov em 1999, um algoritmo aperfeiçoado de Tolerância a Falhas Bizantinas é proposto para sistema *blockchain*.


## Modelo 
Na *blockchain* os participantes (nós) conectam-se e transmitem mensagens entre si através de uma rede *peer-to-peer* (P2P). Os participantes são classificados de acordo com o seu papel na rede, que pode ser de **Nó Comum** ou de **Nó de Consenso**. Nós comuns fazem uso comum, isto é, utilizam o sistema para transferências e trocas na *blockchain*; já os Nós de Consenso, proporcionam serviços para toda a rede, além de manutenção do registro da *blockchain*.
Hipoteticamente, neste sistema as mensagens estão sujeitas a perda, dano, latência e repetição. Além disso, a ordem de envio pode não ser necessariamente consistente com a ordem de recebimento de mensagens. As atividades dos nós podem ser arbitrárias, eles podem entrar e sair da rede a qualquer momento; eles podem também apagar ou falsificar informações ou simplesmente parem de funcionar corretamente.
Integridade e autenticidade da informação transmitida são garantias que a criptografia nos proporciona, uma vez que os remetentes das transmissões precisam anexar suas assinaturas à *hash* da mensagem enviada. 
Aqui, definimos: 
<pre><code><spam align="center"><b>〈𝑚〉𝜎𝑖</b> é a assinatura digital da mensagem <b>𝑚</b> vinda do nó <b>𝑖</b></spam></code></pre>

```
**_D(_𝑚_)_** é o valor da *hash* da mensagem **𝑚**
```
As assinaturas referidas neste artigo são assinaturas à *hash* da mensagem.

## O Algoritmo
Nosso algoritmo garante tanto segurança quando usabilidade. O sistema tem garantia de funcionalidade e estabilidade enquanto o número de Nós de Consenso disfuncionais (desonestos, maliciosos, danificados, desativados, etc), isto é, o número de falhas, não for maior do que **𝑓**.
<pre><code><spam align="center">𝑓 = (𝑛 − 1) / 3</spam></code></pre>
onde
<pre><code><spam align="center"><b>𝑛</b> é o número de nós de consenso participando do processo de consenso</spam></code></pre>

Todos Nós de Consenso são necessários para manter uma tabela de estado para registrar o estado de consenso instantâneo. O conjunto de dados e informações envolvidos do começo ao fim de um processo de consenso é chamado de **_Vista_**. Se um consenso não é atingido em dada *Vista*, uma nova *Vista* é solicitada. Cada *Vista* é identificada pelo índice `v`, iniciando em `0` e incrementando em `1` a cada nova *Vista*, até que se chegue a um consenso.
Cada *Nó de Consenso* é identificado por um número, de `0` à `𝑛 − 1`. Para cada rodada no processo de consenso, um *Nó de Consenso* é definido aleatoriamente para o papel de **_orador_** enquanto os demais têm papel de _**delegados**_ (no sentido de ter a função de validação delegada a si). O **_orador_** é identificado pela variável `𝑝`, definida como
<pre><code><spam align="center">𝑝 = 𝑚𝑜𝑑[(ℎ − 𝑣), 𝑛]</spam></code></pre>
onde
**ℎ** é a altura do bloco
0 ≤ **𝑝** < 𝑛

Um novo bloco será validado e gerado na *blockchain* a cada rodada de consenso em que o número mínimo de `𝑛 − 𝑓` assinaturas dos Nós de Consenso for atingido. Com a geração de um bloco, uma nova rodada de consenso inicia com `𝑣 = 0`. Uma assinatura de um Nó de Contrato representa um voto a favor da validação do bloco, ou seja, quando `𝑛 − 𝑓` Nós de Consenso concordam em validar o bloco, é atingido o consenso e o bloco é gerado na *blockchain*.

## Procedimentos Gerais
Dado o intervalo de tempo da geração de um bloco, `𝑡`, sob circunstâncias normais, o algoritmo realiza os seguintes procedimentos:

1. Um nó transmite os dados de uma transação para toda a rede, com a assinatura do remetente anexada;
2. Todos os *Nós de Consenso* monitoram os dados das transações independentemente e os armazenam em sua memória respectivamente;
3. Após o tempo `𝑡`, o *orador* envia uma proposta de novo bloco assinada `〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑞𝑢𝑒𝑠𝑡, ℎ, 𝑣, 𝑝, 𝑏𝑙𝑜𝑐𝑜, 〈𝑏𝑙𝑜𝑐𝑜〉𝜎𝑝〉`;
4. Após receber a proposta, o *delegado* `𝑖` envia `〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑠𝑝𝑜𝑛𝑠𝑒, ℎ, 𝑣, 𝑖, 〈𝑏𝑙𝑜𝑐𝑜〉𝜎𝑖〉`;
5. Qualquer Nó, ao receber `𝑛 − 𝑓` assinaturas `〈𝑏𝑙𝑜𝑐𝑜〉𝜎𝑖` chega ao consenso e publica o bloco;
6. Qualquer Nó, após receber o bloco, deleta a transação em questão de sua memória e inicia o novo processo de consenso.

É necessário que, para todos *Nós de Consenso*, ao menos `𝑛 − 𝑓` nós estejam no mesmo estado. Isto quer dizer que, para todos os Nós `𝑖`, a altura do bloco, `ℎ`, e o índice da *Vista*, `𝑣`, são os mesmos. Isso não é difícil; constência de `ℎ` pode ser obtida sincronizando os blocos, enquanto consistência de `𝑣` pode ser obtida alterando-se a *Vista*. Sincronização de blocos não é tratada neste artigo. Já a alteração da *Vista* é tratada na próxima sessão.

Os *Nós*, após receberem uma proposta de novo bloco, validam as transações nela contidas. Se uma transação ilegal estiver presente na proposta, esta rodada de consenso será abandonada e a *Vista* será alterada imediatamente. Os procedimentos de validação das transações na proposta são:

1. O formato dos dados da transação são coerentes com as regras do sistema? Se não, a transação é classificada como ilegal;
2. A transação já existe na *blockchain*? Se sim, a transação é classificada como ilegal;
3. Todos os scripts de contrato da transação foram corretamente executados? Se não, a transação é classificada como ilegal;
4. Existe cobrança em multiplicidade na transação? Se sim, a transação é classificada como ilegal;
5. Se a transação não foi classificada como ilegal nos passos anteriores, ela é classificada como legal.

### Alteração da *Vista*

Se após o intervalo de tempo [tempo limite](https://latex.codecogs.com/gif.latex?t%5Cast%202%5E%7Bv&plus;1%7D) os nós `𝑖` não chegarem a um consenso, ou receberem uma proposta contendo transações ilegais, a *Vista* é alterada:

Dado ![k = 1](https://latex.codecogs.com/gif.latex?%5Cinline%20v_%7Bk%7D%20%3D%20v%20&plus;%20k) e ![v0 = 0](https://latex.codecogs.com/gif.latex?%5Cinline%20v_%7B0%7D%3D0),
<pre><code><span align="center"><img src="https://latex.codecogs.com/gif.latex?%5Cinline%20v_%7Bk%7D%20%3D%20v%20&plus;%20k"></span></code></pre>

1. Um *Nó* `𝑖` envia a requisição de troca de *Vista* `![<changeview>](https://latex.codecogs.com/gif.latex?ChangeView%2Ch%2Cv%2Ci%2Cv_%7Bk%7D)`;

2. Uma vez que qualquer *Nó* receber ao menos ![n - f](https://latex.codecogs.com/gif.latex?n-f) requisições, de diferentes delegados e mesma *Vista*, ![vk](https://latex.codecogs.com/gif.latex?v_%7Bk%7D), a alteração de *Vista* é realizada.

3. Atualiza-se a *Vista* atual para a nova: ![v=vk](https://latex.codecogs.com/gif.latex?v%3Dv_%7Bk%7D)

4. Se após o intervalo de tempo [tempo limite](https://latex.codecogs.com/gif.latex?t%5Cast%202%5E%7Bv&plus;1%7D) a troca de *Vista* não estiver completa, o valor de `𝑘` é incrementado e o processo retorna ao passo **1**.

Com o aumento de `𝑘`, o tempo de espera cresce exponencialmente, então frequentes trocas de *Vista* são evitadas e os *Nós* são estimulados a chegar a um consenso em `𝑣`. 

Antes da troca de *Vista* ser completada, a *Vista* original `𝑣` permanece válida, então trocas de *Vista* desnecessárias causadas por eventual latência na rede podem ser evitadas.


## Fluxograma

<p align="center"><img src="/pt-br/assets/consensus_flowchart.jpg"></p>


## Capacidade de Tolerar Falhas

Nosso algoritmo proporciona tolerância a 𝑓 falhas em um sistema com 𝑛 nós validadores, onde 𝑓 é o valor, arredondado para baixo, da divisão do número de *delegados* por 3. Esta tolerância diz respeito a falhas tanto de segurança quanto de usabilidade.
<pre><code><span align="center"><img src="/pt-br/assets/formulas/formula_f.png"></span></code></pre>

Como todas requisições carregam a assinatura do emissor, *Nós de Consenso* maliciosos não conseguem falsificar requisições. Ao invés disso, eles podem tentar reverter o status do sistema para um ponto no passado (uma altura de bloco menor do que a atual), forçando o sistema bifurcar.
Em uma rede hipotética, dividimos o conjunto de todos *Nós de Consenso*, `𝑅`, em 3 sub-conjuntos, `𝑅1`, `𝑅2` e `𝐹`, tais que
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_R-R1uR2uF.gif"></span></code></pre>
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_R1interR2.gif"></span></code></pre>
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_R1interF.gif"></span></code></pre>
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_R2interF.gif"></span></code></pre>

Dadas as seguintes suposições:
  - Os *Nós* de `𝑅1` são honestos e podem se comunicar apenas com outros nós pertencentes a `𝑅1`;
  - Os *Nós* de `𝑅2` são honestos e podem se comunicar apenas com outros nós pertencentes a `𝑅2`;
  - Os *Nós* de `𝐹` são desonestos e estão em acordo;
  - As condições da rede permitem que os *Nós* de `𝐹` se comuniquem entre si e também se comuniquem com os *Nós* de `𝑅1` e de `𝑅2`;

Se os *Nós* de `𝐹` desejarem bifurcar o sistema, eles terão de chegar a um consenso com os nós de `𝑅1`, publicar os blocos, e depois chegar a um concenso entre si, sem informar `𝑅2`, revogando o consenso com `𝑅1`.
Isto implicaria em:
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_R1maisFmaioreqnmenosf.gif"></span></code></pre>
e
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_R2maisFmaioreqnmenosf.gif"></span></code></pre>

Ainda, supondo o pior cenário possível, em que o número de *Nós* desonestos é igual ao número máximo de falhas que o sistema consegue tolerar:
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_Feqf.gif"></span></code></pre>
então
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_R1maioreqnmenos2f.gif"></span></code></pre>
e
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_R2maioreqnmenos2f.gif"></span></code></pre>

Resolvendo o sistema de equações,
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_R1maisR2maioreq2nmenos4f.gif"></span></code></pre>

Da nossa definição inicial,
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_neqR.gif"></span></code></pre>
então
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_nmaisf.gif"></span></code></pre>
logo,
<pre><code><span center="align"><img src="/pt-br/assets/formulas/formula_nmenoreq3f.gif"></span></code></pre>

A última equação contradiz nossa definição de `𝑓`, provando que o sistema não pode ser bifurcado dentro da faixa tolerável de falhas.



Referências:
[1] Nakamoto S. Bitcoin: A peer-to-peer electronic cash system[J]. 2008.
[2] Lamport L, Shostak R, Pease M. The Byzantine generals problem[J]. ACM Transactions on Programming Languages and Systems (TOPLAS), 1982, 4(3): 382-401.
[3] Castro M, Liskov B. Practical Byzantine fault tolerance[C]//OSDI. 1999, 99: 173 186.
[4] Bracha G, Toueg S. Asynchronous consensus and broadcast protocols[J]. Journal of the ACM (JACM), 1985, 32(4): 824-840.
[5] 范捷, 易乐天, 舒继武. 拜占庭系统技术研究综述[J]. 软件学报, 2013, 6: 012.
