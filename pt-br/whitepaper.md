# NEO White Paper

## Uma rede distribuída para *Smart Economy*.

### Objetivo do projeto NEO: *Smart Economy*

O NEO é um ecosistema digital que utiliza as tecnologias de *blockchain* e de identidade digital a fim de digitalizar e auto-gerenciar ativos do mundo real em uma rede distribuída. 

### Ativos digitais

Ativos digitais são ativos programáveis que existem sob a forma de dados eletrônicos. Com a tecnologia *blockchain*, a digitalização de ativos pode ser descentralizada, confiável, rastreável, altamente transparente e livre de intermediários. Na *blockchain* do NEO, os usuários podem registrar e transferir vários tipos de ativos. É possível comprovar a relação entre os recursos físicos (no mundo real) e digitais (na rede NEO) ao registrar tais recursos através de uma identidade digital válida, uma vez que os ativos registrados dessa forma são protegidos por lei.

O NEO possui duas formas de ativos digitais: ativos globais e ativos contratuais. Os ativos globais são registrados publicamente na rede e podem ser identificados por todos *smart contracts* e clientes/usuários. Já os ativos contratuais são registrados de forma privativa no armazenamento do próprio *smart contract*, sendo reconhecíveis apenas dentro do ambiente do contrato em questão, ou seja, apenas para os clientes compatíveis com as normas de tal contrato.

### Identidade Digital

Como o nome sugere, identidade digital refere-se às informações de identificação de indivíduos, organizações, entidades, etc, em formato eletrônico. Atualmente o sistema de identidade digital mais moderno e amplamente utilizado no mundo é baseado no padrão PKI (do inglês *Public Key Infrastructure*) x.509. No NEO implementaremos um conjunto de normas de identidade digital compatíveis com o PKI x.509, utilizando a *blockchain* para substituir o Protocolo de Status de Certificado Online (OCSP) no gerenciamento da Lista de Revogação de Certificado (CRL) x.509. O NEO também  terá suporte *point-to-point* ao conceito WoT (do inglês *Web of Trust*). Os mecanismos de verificação e garantia de identidade digital do NEO incluirão reconhecimento facial, reconhecimento de impressões digitais e de voz, SMS, entre outros métodos de autenticação multifacetada.

### *Smart Contracts*

O conceito de "contrato inteligente" foi proposto pela primeira vez pelo criptógrafo Nick Szabo em 1994, apenas cinco anos após a criação da World Wide Web. De acordo com a definição de Szabo, *"quando uma condição pré-programada é desencadeada, o contrato inteligente executará os termos contratuais correspondentes"*. A tecnologia de *blockchain* viabiliza um sistema descentralizado, inviolável e altamente confiável, no qual os contratos inteligentes se tornam muito úteis. O NEO possui um sistema de contrato inteligente independente, chamado NeoContract. Para fins de terminologia adequada, seguiremos fazendo uso do termo internacional "*smart contract*" ao invés de "contratos inteligentes".

O NeoContract é o grande fator que viabiliza uma integração sólida entre a rede NEO e o ambiente de desenvolvimento do NEO. Os desenvolvedores não precisam aprender uma nova linguagem específica para a programação de *smart contracts*, mas sim, usar C#, Java e outras linguagens convencionais, permitindo que milhões de pessoas em todo o mundo desenvolvam *smart contracts* em seus ambientes IDE familiares (Visual Studio, Eclipse, etc). Aliado a isso, a máquina virtual da NEO, a NeoVM, possui vantagens de precisão, capacidade para grande simultaniedade e alta escalabilidade. O NeoContract terá um *white paper* exclusivo descrevendo os detalhes de sua implementação.

### Software e Ecossistema

O ecossistema é a essência da comunidade *open source*. Para alcançar o objetivo de uma rede para a *Smart Economy*, o NEO está comprometido com o desenvolvimento do seu ecossistema, fornecendo ferramentas modernas de desenvolvimento, organizando atividades de educação e treinamento, melhorando a qualidade de sua documentação e fornecendo suporte financeiro aos colaboradores. Planejamos recompensar as melhorias e dar suporte ao trabalho nas seguintes soluções tecnológicas na rede NEO:

🔹 Software de nó  

•	Um software para PC, *full-node* (carrega a *blockchain* completa), Neo-GUI para uso de clientes

•	Um software para PC, Neo-CLI para uso de desenvolvedores 

•	Clientes Web/Android/iOS que não precisam sincronizar com a *blockchain* (*non-full-nodes*)

•	Hardware para carteira de usuário

🔹 Blockchain Explorer

🔹 Kit para Desenvolvimento de Software (SDK)

•	Suporte às linguagens Java/Kotlin, .NET C#/VB, JavaScript/Typescript, Python, Go

🔹 Compilador de *Smart Contracts* e Plugin IDE

•	C# / VB.Net / F#, Studio Visual

•	Java / Kotlin, Eclipse

•	C / C++ / GO

•	JavaScript / TypeScript

•	Python / Ruby

🔹 dApps ( Aplicações Descentralizadas )

•	*Smart fund* - Fundo financeiro inteligente

•	*Smart contracts* assistidos por IA

•	Rede Social

•	Provedores de tokens automáticos de liquidez

•	Intercâmbio descentralizado

•	Protocolo de comunicação segura

•	Mercado de intercâmbio de dados

•	Mercado de intercâmbio de propriedade intelectual

•	Previsão de mercado

•	Mercado de publicidade

•	Mercado Hashpower

•	Mercado NeoGas




## Modelo da Gestão NEO

### Modelo econômico

O ecossistema NEO possui dois tokens nativos: NEO e NeoGas (abreviado a GAS).

O NEO é limitado em um máximo de 100 milhões de tokens disponíveis e representa o direito de participar no gerenciamento da rede, como em votações para definições e mudanças de parâmetros da rede, e assim por diante. A unidade mínima de NEO é 1 e os tokens não podem ser subdivididos. Os tokens de NEO podem ser transferidos entre endereços (usuários, carteiras, etc).

O GAS, com limite máximo total de 100 milhões, é o token com papel de alimentação da rede, utilizado no controle de recursos da mesma. A rede NEO cobra GAS pelas operações e armazenamento de tokens e *smart contracts*, assim gerando incentivos para os Nós de Consenso e impedindo o abuso de recursos. A unidade mínima de GAS é 0,00000001.

No bloco gênese da rede NEO, 100 milhões de NEOs foram gerados, porém nenhum GAS. 100 milhões de GAS, correspondentes aos 100 milhões de NEO, serão gerados através de um algoritmo de decaimento por um período de aproximadamente 22 anos. Quando NEO é transferido para um novo endereço, o GAS subsequentemente gerado por esse NEO será creditado ao novo endereço.

Será estabelecido através de votação um limiar para isentar o GAS de certa quantidade de transações, como transferências e operações de *smart contracts*, a fim de incentivar e melhorar a experiência de novos usuários. Quando uma grande quantidade de transações *spam* ocorrer, o NeoID será usado para priorizar transações e *smart contracts* com identidades digitais qualificadas. Transações e *smart contracts* sem identidades qualificadas podem ser priorizados através do pagamento de um valor em GAS.


### Mecanismos de Distribuição

#### Distribuição NEO:

Os 100 milhões de tokens NEO são divididos em duas parcelas de 50 milhões: a primeira foi distribuida proporcionalmente entre os investidores e apoiadores do NEO durante seu financiamento colaborativo (ICO); a segunda é administrada pelo Conselho NEO, que a utiliza para suportes ao desenvolvimento, à operação e à manutenção da rede a longo prazo. Esta parcela utilizada para manter a rede é detalhada abaixo:

🔹 10% do total (10 milhões de tokens) serão utilizados para motivar desenvolvedores NEO e membros do Conselho NEO

🔹 10% do total (10 milhões de tokens) serão utilizados para motivar desenvolvedores do ecossistema NEO

🔹 15% do total (15 milhões de tokens) serão utilizados para investir em outros projetos de *blockchains* e projetos NEO

🔹 os 15% restantes (15 milhões de tokens) serão reservados para lidar com possíveis contingências

Em princípio, o uso de NEO não deverá exceder 15 milhões de tokens.


#### Distribuição de GAS:

A quantidade total inicial de GAS na rede é zero, mas sua geração ocorre a cada novo bloco na *blockchain*. O intervalo entre a geração de dois blocos consecutivos na *blockchain* é de aproximadamente 15 segundos, ou seja, a geração anual é cerca de 2 milhões de blocos. 

Inicialmente, cada novo bloco validado na *blockchain* vai gerar 8 GAS na rede, que por sua vez será distribuído proporcionalmente entre os portadores de NEO. A cada ano, a taxa de geração de GAS por bloco será subtraída em 1, até chegar ao patamar base de geração de 1 GAS a cada novo bloco. De acordo com esta curva, no primeiro ano serão criados 16 milhões de GAS (16% do limite total) e os primeiros 50 milhões de GAS serão gerados em aproximadamente 4 anos. Após o 44º milionésimo bloco, o GAS total gerado terá atingido os 100 milhões estipulados e a partir deste ponto não haverá mais geração de GAS nos novos blocos. 


### Mecanismo de governança

Governança na *blockchain*: os portadores de tokens NEO, como já mencionado, têm papel ativo na rede. Através de votações, os portadores de NEO influenciam e auxiliam na administração da rede e de seus parâmetros. 

Governança fora da *blockchain*: o Conselho NEO é composto pelo comitê de gestão, pelo comitê técnico e pelo secretariado, nos quais os membros são responsáveis, respectivamente, pela tomada de decisões estratégicas, pela tomada de decisões técnicas e por implementações específicas. O Conselho NEO responde à comunidade NEO, tendo a divulgação e o desenvolvimento do ecossistema NEO como seus principais objetivos.


## Implementação da tecnologia NEO

### Mecanismo de Consenso dBFT

O dBFT é uma sigla em inglês para ‘delegated Byzantine Fault Tolerance’, um mecanismo de consenso baseado no “problema dos generais bizantinos”, que permite ampla participação através da “votação por representação” para se chegar a um consenso. Um portador de tokens NEO pode definir seu representante através de seu voto. Este "representante" é chamado na rede de "Nó de Consenso". O grupo selecionado de representantes (nós de consenso), através do algoritmo BFT, chega em um consenso e gera os novos blocos. A votação na rede NEO é contínua em tempo real. 

A combinação do dBFT com a tecnologia de identidade digital permite que os nós de consenso tenham nomes verdadeiros de indivíduos ou instituições, possibilitando congelar, revogar, herdar ou recuperar uma transferência devido a decisões judiciais. A rede NEO planeja suportar tais operações quando necessárias.

O dBFT fornece tolerância de *f = ⌊ (n-1) / 3 ⌋* falhas, para um sistema de consenso composto de ‘*n*’ nós de consenso, ou seja, em um sistema com 10 nós, 4 ou mais nós precisariam ser corrompidos para influenciar o resultado, se mostrando bastante seguro e adequado a qualquer ambiente de rede. Outra vantagem da utilização do dBFT no NEO é proporcionar alta finitude à *blockchain*, o que significa que uma vez que um bloco é validado e adicionado na cadeia, a transação não é mais revogada ou revertida, acabando com o problema de bifurcamento (*fork*).

Este mecanismo de consenso, com a frequência de um novo bloco gerado a cada 15 segundos, propicia rendimento de até 1.000TPS (*transactions per second*), o que é um excelente desempenho entre cadeias públicas. Com a otimização apropriada, há potencial para atingir 10.000TPS, viabilizando suportar aplicações comerciais em larga escala.


### Sistema de *Smart Contracts*: NeoContract

O sistema de *smart contract* do NEO é constituído de três partes:


#### NeoVM – Máquina Virtual Universal de *Blockchain*:

A NeoVM é uma máquina virtual leve e de uso geral, semelhante a uma CPU virtual que lê e executa instruções, cuja arquitetura é muito próxima da JVM e da *runtime* .NET. Executa controle de processo baseado em funções de instrução, operações lógicas, e assim por diante. Possui boa velocidade de inicialização e versatilidade, sendo adequada para *smart contracts*, que podem ser portados para cenários fora da *blockchain*, como integrados com uma IDE para fornecer uma boa experiência de desenvolvimento. A funcionalidade da NeoVM pode ainda ser estendida com a introdução de um mecanismo JIT (compilador em tempo real), melhorando assim, a eficiência das instruções implementadas. Através de um design de baixo acoplamento, a NeoVM pode ser portada para qualquer *blockchain*, ou mesmo um sistema alternativo, aumentando a utilidade dos *smart contracts*.


#### InteropService - Serviços Interoperáveis:

Servem para carregar o registro de blocos, ativos digitais, identidade digital, área de armazenamento persistente e outros serviços subjacentes. Eles são como máquinas virtuais fornecidas para máquinas virtuais, permitindo que *smart contracts* acessem esses serviços durante sua execução para viabilizar funcionalidades avançadas. 


#### DevPack - Compilador e plugin IDE:

O DevPack inclui o compilador de linguagem de alto nível e o plug-in IDE. Como a arquitetura da NeoVM é muito semelhante à JVM e ao .NET Runtime, o DevPack pode compilar códigos Java e .NET MSIL nas instruções da NeoVM. Desenvolvedores de Java / Kotlin e C # não precisam aprender novas linguagens específicas e podem começar imediatamente o desenvolvimento de *smart contracts* em ambientes familiares como VS, Eclipse, entre outros IDE. Isso reduz consideravelmente a curva de aprendizado para o desenvolvimento de *smart contracts*, o que nos permite construir facilmente uma comunidade próspera em torno do NeoContract.

O NeoContract é capaz de estruturar a árvore de processos de *smart contracts* através de análise prévia à execução do *smart contract*. Com a determinação antecipada desta árvore de processos, o nó da rede NEO pode então fragmentar o *smart contract* e separar a execução de tarefas em partições que operam estados diferentes, de forma que estas partições possam ser executadas em paralelo e não sofram interferência.


### Protocolo de interoperabilidade entre cadeias: NeoX

O NeoX é um protocolo de implementação de interoperabilidade entre cadeias. O NeoX é dividido em dois protocolos; um para a troca de ativos entre cadeias e outro para transações distribuídas em diferentes cadeias.

#### Troca de Ativos Entre Cadeias
O NeoX foi estendido do protocolo "*atomic cross-chain*", em que duas ou mais partes trocam entre si ativos que estão em diferentes cadeias, de forma que todas as etapas da transação sejam bem-sucedidas ou falhem em conjunto. Para isto, utilizamos o NeoContract para criar uma conta de contrato (*smart contract*) para cada parte envolvida. Se alguma das partes tiver seus ativos em uma *blockchain* não compatível com o NeoContract, basta que essa altchain possua funcionalidades de um *smart contract* simples para que seja compatível com o NeoX.

#### Transação Distribuída em Diferentes Cadeias
Nste caso, uma transação tem várias etapas espalhadas por diferentes *blockchains* e a consistência de toda a transação deve ser assegurada, ou seja, todas etapas devem ser bem-sucedidas ou falharem, em conjunto. Alcançamos tal objetivo com a extenção do comportamento do protocolo anterior para a troca de ativos entre cadeias. O NeoX torna possível a execução de diferentes tarefas de um *smart contract* em múltiplas cadeias, com tais tarefas sendo bem-sucedidas ou falhando em conjunto. Isso oferece excelentes possibilidades para colaborações de outras *blockchains* e estamos explorando este cenário para aplicativos de *smart contract*.


### Protocolo de Armazenamento Distribuído: NeoFS

NeoFS é um protocolo de armazenamento distribuído que utiliza a tecnologia *‘Distributed Hash Table’*. NeoFS indexa os dados através do conteúdo do arquivo (Hash) em vez do caminho do arquivo (URI). Os arquivos grandes são divididos em blocos de dados de tamanho fixo que são então distribuídos e armazenados em muitos nós diferentes.

O principal problema com este tipo de sistema é a necessidade de encontrar um equilíbrio entre redundância e confiabilidade. O NeoFS planeja resolver essa contradição por meio de incentivos com tokens e pelo estabelecimento de nós de *backbone*. Os usuários podem escolher os requisitos de confiabilidade do arquivo, então os arquivos com baixos requisitos de confiabilidade podem ser armazenados e acessados de forma gratuita ou quase gratuita. Serviços de maior confiabilidade e estabilidade para outros arquivos serão fornecidos pelos nós de backbone.

O NeoFS prestará serviços de interoperabilidade no sistema NeoContract, permitindo que *smart contracts* armazenem grandes arquivos na *blockchain*, bem como definam acesso para esses arquivos. Além disso, o NeoFS pode ser combinado com identidades digitais para atribuir, enviar ou revogar certificados sem necessitar um servidor central para gerenciá-los. No futuro, os dados dos blocos mais antigos poderão ser armazenados no NeoFS, de modo que a maioria dos nós cheios (nós que armazenam toda a *blockchain*) possam fornecer os dados antigos, garantindo melhor escalabilidade e, ao mesmo tempo, integridade histórica.

### Mecanismo de Criptografia Anti-Quântico: NeoQS

O surgimento de computadores quânticos representa um grande desafio para os mecanismos criptográficos RSA e ECC. Os computadores quânticos podem resolver um grande número de problemas de decomposição (em que o RSA se baseia) e de curva elíptica (em que o ECC depende) em um tempo muito curto. O NeoQS (NEO Quantum Safe) é um mecanismo criptográfico baseado em reticulados, que é considerado o algoritmo mais confiável para resistir à computadores quânticos, uma vez que os computadores quânticos não têm a capacidade de resolver rapidamente os conhecidos *"Problema do vetor mais curto"* (PVS) e *"Problema do vetor mais próximo"* (PVP).

## Resumo	

O NEO é um ecossistema composto de uma rede distribuída que combina ativos digitais, identidades digitais e *smart contracts*. O sistema NEO usará dBFT, NeoX, NeoFS, NeoQS e muitas outras tecnologias originais como infra-estrutura para a *Smart Economy* do futuro.

