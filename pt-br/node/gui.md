# Instruções de Uso

## Visão Geral

### Introdução

O Neo-GUI é compatível com as seguintes versões do Windows: Windows 7 (*Service Pack* 1), Windows 8 e Windows 10.

O Neo-GUI não requer instalação para ser utilizado. Baixe o arquivo [neo-gui-windows.zip](https://github.com/neo-project/neo-gui/releases), extraia seu conteúdo para um diretório a sua escolha e execute o arquivo *neo-gui.exe*.
Se houver qualquer problema que impossibilite o funcionamento correto do programa, por favor guarde o arquivo `error.log`, localizado no mesmo diretório em que o `neo-gui.exe`, e entre em contato com nosso suporte técnico que irá auxilia-lo a resolver este problema.

> :information_source:
> Versões anteriores ao Windows 10 necessitam da instalação do [.NET Framework 4.6.2+](https://www.microsoft.com/net/download/framework).

Em sua primeira inicialização, o Neo-GUI irá alertá-lo para realizar a instalação do certificado Onchain; Permita os passos seguintes.

### Sincronização

O programa precisa estar sincronizado antes do uso. No canto inferior esquerdo vemos o número de blocos sincronizados e o número total de blocos na rede (veja a imagem abaixo). Estes números serão atualizados regularmente.

  <p align="center"> <img src="/pt-br/assets/gui_1.png"> </p>


### Download e sincronização offline

Para acelerar o processo de sincronização da *blockchain*, você pode baixar o arquivo da *blockchain* completa mais recente diretamente do [site da NEO](https://www.neo.org/client/chain.acc.zip) 

Após finalizar o download, confirme que o Neo-GUI não esteja sendo executado e mova o arquivo `chain.acc.zip` para o diretório em que se encontra o executável `Neo-gui.exe`. Agora, ao iniciar o Neo-GUI, o software irá descompactar o arquivo `.zip` e carregar os blocos salvos.

  <p align="center"> <img src="/pt-br/assets/gui_58.png"> </p>

Uma vez que os blocos tenham sido carregados, o programa vai excluir o arquivo zip.

  <p align="center"> <img src="/pt-br/assets/gui_60.png"> </p>


### Glossário


#### _**Wallet**_ ( Carteira )

Um arquivo de Carteira é um arquivo de banco de dados com extensão `.db3` que armazena uma referência aos seus NEO e GAS e à informação de sua conta. Este arquivo é muito importante e precisa ter uma cópia de segurança salva e segura.

> [!IMPORTANT]
> A perda, tanto do arquivo da carteira, quanto da senha da carteira, implicará na perda de seus ativos! Por favor, garanta que o arquivo de carteira seja seguramente armazenado e tenha uma cópia de segurança, e lembre de sua senha.

#### _**Account**_ ( Conta )

A conta é usada para rastrear ativos na *blockchain*.

Informações da conta incluem: endereço, chave privada, chave pública e tipo.

  - **Endereço**: é a informação utilizada na realização de transações. Pode ser entendido como equivalente ao número de uma conta em um banco ou ao número de um cartão de crédito.

  - **Tipos**: 
    `Neo.Wallets.SignatureContract`: Significa que o endereço consiste de uma chave pública e tem relação de assinatura 1-pra-1. 
    `Neo.Wallets.MultiSigContract`: Indica que o endereço possui múltiplas chaves públicas e tem relação de múltiplas assinaturas m-pra-n, o qual é usado para *smart contracts*.

  - **Chave privada**: É um número randômico de 256 bits, mantido pelo usuário e não informado publicamente. Esta chave representa o proprietário da conta e dos ativos na conta.

  - **Chave pública**: Cada chave privada tem uma chave pública correspondente (obs: apesar da informação da chave pública e da chave privada, poder ser vista através do endereço da conta, o número da chave privada em si, **não pode**).

> [!IMPORTANT]
> De forma alguma a chave privada deve ser divulgada a terceiros, ou você corre o risco de perder sua carteira e todos seus ativos.


#### _**Asset**_ ( Ativo )

Os ativos da conta. Informações dos ativos de uma conta incluem: ativos (NEO, GAS ou outros ativos criados por usuários), tipo, balanço e usuário emissor.

#### _**Transaction Record/History**_ ( Registro/Histórico de Transações )

Registro de todas as transações associadas à conta e suas informações.

#### _**Transfer**_ ( Transferência )

Transferência de um ativo para um endereço de destino. Se o tipo do ativo for NEO, todas partes devem confirmar a transferência com suas assinaturas. Outros tipos de ativos podem ser transferidos sem a confirmação de todas as partes.

#### _**Trade**_ ( Troca/Acordo )

Intercâmbio de ativos entre duas partes, onde são necessárias as confirmações de ambas as partes para a troca ser realizada.

#### _**Signature**_ ( Signatário/Reconhecer firma )

Reconhecimento de firma significa reconhecer, ou confirmar, as informações do contrato pelo signatário.
Para transações envolvendo alocação de capital e transferência de ativos, o reconhecimento é necessário como prova de consentimento das partes envolvidas.

#### _**Registered Asset**_ ( Ativo Registrado )

Um novo ativo criado por um usuário na rede NEO. O usuário pode definir tipo, nome, total, etc, do ativo e especificar a conta de quem administrará o ativo. A criação de ativos pode ter custo em NEO e GAS como tarifa de serviço. 

#### _**Asset Distribution**_ ( Distribuição de Ativo )

Dentro do limite máximo definido pelo criador, o ativo é emitido ao endereço especificado pelo emissor.
A distribuição de ativos consome certa quantidade de GAS como tarifa de serviço. Obs: A tarifa na rede de teste é menor e GAS na rede teste para fins de desenvolvimento podem ser solicitados.

#### _**Election**_ ( Eleição )

Os validadores da rede, ou Nós de consenso, são definidos por eleição. Para participar da escolha (eleição) deve ser pagar certa quantia de NEO e as qualificações dos candidatos são avaliadas. Atualmente ainda não há suporte para este mecanismo.

#### Voto

Portadores de NEO podem votar nos candidatos a Nó de Consenso e através desse mecanismo de eleição é definido se algum candidato será selecionado. 

#### _**Broadcast**_ ( Transmissão )

Após reconhecida pelo signatário, a transação é transmitida por toda a rede e a confirmação por um Nó de Consenso (através do mecanismo dBFT) valida e completa a transação. Atualmente apenas o modo de signatário suporta este modelo.

#### Monitor de endereço

Após importar um endereço de outra parte, você estará apto a monitar (ver) os ativos daquele endereço.


## `Wallet` - Carteira
### `New Wallet database...` - Criar o banco de dados da carteira

1. No canto superior esquerdo clique em `Wallet` >> `New Wallet database...`

<p align="center"> <img src="/pt-br/assets/gui_2.png"> </p>

2. Clique em `Browse` e na janela pop-up que abriu, selecione o diretório para armazenar e o nome que terá o arquivo `.db3` da carteira. Clique `Save`

<p align="center"> <img src="/pt-br/assets/gui_3.png"> </p>

3. Defina uma senha de sua escolha em `Password`, confirme a mesma em `Re-Password` e clique `confirm` para finalizar o processo de criação

<p align="center"> <img src="/pt-br/assets/gui_4.png"> </p>

> [!IMPORTANT] 
> Esta senha não deverá ser perdida ou esquecida. Anote-a em lugar seguro.


### `Open Wallet database...` - Abrir carteira (banco de dados)

Cada vez que o Neo-GUI é aberto, é necessário re-abrir a carteira manualmente.

1. Clique em `Wallet` >> `Open Wallet Database...` e selecione o arquivo `.db3` da sua carteira

<p align="center"> <img src="/pt-br/assets/gui_5.png"> </p>

Se eventualmente o arquivo da carteira apresentar erros, tente marcar a opção `repair mode` ao abrir a carteira.


### `Change Passaword...` - Alteração de senha

Para alterar sua senha, baster clicar em `Wallet` e `Change Password...`

<p align="center"> <img src="/pt-br/assets/gui_6.png"> </p>

> [!IMPORTANT]
> Após alterar a senha, não se esqueça de salvar uma nova cópia de segurança, uma vez as versões anteriores do arquivo database da carteira não contém a nova senha.

### `Rebuild index` - Refazer os índices da carteira

Esta opção é utilizada para restauração da carteira quando algum erro ocorre. 

<p align="center"> <img src="/pt-br/assets/gui_7.png"> </p>

Os índices da carteira podem ter de serem refeitos nos seguintes casos:

1. Após importar uma chave privada
2. Uma transação não ter sido confirmada depois de muito tempo
3. Os ativos da carteira possuirem erros, não coincidindo com os dados na *blockchain*

Como a altura, isto é, a quantidade de blocos, da *blockchain* é grande, refazer os índices da carteira pode demorar vários minutos. Seja paciente!



### `Restore Accounts...` - Restaurar contas 

Esta opção é utilizada para restaurar o endereço e os ativos da carteira a partir do seu arquivo database no caso de acidentalmente serem deletados. Vale ressaltar que não é recomendado realizar operações de `delete` através do Neo-GUI para evitar a perda de ativos.

<p align="center"> <img src="/pt-br/assets/gui_8.png"> </p>



## `Transaction` - Transações

### `Transafer...`- Transferência

#### Transferência de tokens

1. Vá em `Transaction` e em `Transfer...` 

<p align="center"> <img src="/pt-br/assets/gui_9.png"> </p>


2. Clique em `[+]` 
   - No campo `Asset` selecione o token que deseja transferir (`NeoGas` na imagem ilustrativa)
   - No campo `Pay to` insira o endereço de destino dos tokens
   - No campo `Amount` insira a quantidade que será transferida
   - Clique `OK`

<p align="center"> <img src="/pt-br/assets/gui_10.png"> </p>


3. Após a transação ser adicionada à lista de destinatários (*recipient list*), clique em `OK` para realizar a transferência.

<p align="center"> <img src="/pt-br/assets/gui_11.png"> </p>

> [!Note]
> Você pode adicionar várias transações à lista de destinatários utilizando o botão `[+]` e então realizar todas de uma só vez clicando no botão `OK`



#### Transferências por lote (*batch*)

É utilizada para se efetuar múltiplas transferências de um mesmo tipo de ativo a endereços diferentes de forma simplificada. 


1. Clique no ícone mostrado na imagem abaixo.

<p align="center"> <img src="/pt-br/assets/gui_14.png"> </p>


2. Defina o tipo de ativo a ser transferido
  - Insira o endereço e a quantidade com exatamente **um espaço** entre ambos
  - Clique `OK`

<p align="center"> <img src="/pt-br/assets/gui_15.png"> </p>


3. Após a transação ser adicionada à lista de destinatários, clique em `OK` para realizar todas as transferências.

<p align="center"> <img src="/pt-br/assets/gui_16.png"> </p>




#### Observações (*Remarks)

É possível adicionar observações e comentários para serem registrados na *blockchain* juntamente com a transação. Basta clicar no ícone no canto inferior direito da janela da lista de destinatários, como mostrado na imagem abaixo. 

<p align="center"> <img src="/pt-br/assets/gui_17.png"> </p>


Atualmente, pode-se utilizar o [NeoScan](https://neoscan.io) para visualizar esta e outras informações das transações.






### `Transaction(X)...` - Transação Cruzada/Acordo

#### Iniciar um acordo

> [!Note]
> Para realizar um acordo, é necessário o conscentimento de ambas as partes. 

O contexto do nosso exemplo será entre duas partes, A e B:
> A parte **A** vai pagar 5 tokens do tipo *MyToken* em troca de 1 token do tipo *NEO* da parte **B**


#### Parte envolvida **A**

1. Clique em `Transaction` e em `Transactions(X)...` 
   - No campo `Pay To` insira o endereço da outra parte do acordo (**B**)
   - Clique em `[+]`
   - Na janela `Payment` escolha o tipo de ativo em `Asset` (no nosso exemplo, "MyToken")
   - No campo `Amount`  insira a quantia (no nosso exemplo a quantia é 5) 
   - Clique em `initiate`

  <p align="center"> <img src="/pt-br/assets/gui_18.png"> </p>


2. Quando a janela de requisição de acordo `Trade Request` abrir, clique em `copy` e feche a janela clicando em `close`

  <p align="center"> <img src="/pt-br/assets/gui_19.png"> </p>


3. Agora na aba `merge tx. request` da janela **Transaction**, temos que inserir o código da outra parte envolvida no acordo (**B**).

  <p align="center"> <img src="/pt-br/assets/gui_20.png"> </p>



#### Parte envolvida **B**

A parte **B** deve realizar os mesmos passos, preenchendo a solicitação com sua contrapartida, nesse exemplo, de **1 NEO**.

1. Clique em `Transaction` e em `Transactions(X)...` 
   - No campo `Pay To`, o endereço de **A** deve ser nserido 
   - Clique em `[+]` 
   - Na janela **Payment**, no campo `Asset`, escolha o tipo de ativo (nesse exemplo, a contrapartida de **B** é em **NEO**) 
   - No campo `Amount`, insira a quantia (nesse exemplo, a quantia da contrapartida de **B** é de **1** NEO)
   - Clique em `Initiate`

<p align="center"> <img src="/pt-br/assets/gui_21.png"> </p>


2. Quando a janela de requisição de acordo `Trade Request` abrir, clique em `copy` e feche a janela clicando em `close`

<p align="center"> <img src="/pt-br/assets/gui_22.png"> </p>


#### Parte envolvida **A**

4. O código da requisição de **B** deve, então, ser inserido na aba **merge tx. request** no campo **counterparty request** e confirmado no botão `validate`

  <p align="center"> <img src="/pt-br/assets/gui_23.png"> </p>


5. Na janela de verificação `Transaction Verification` você pode cancelar a requisição se alguma informação estiver incorreta, ou, como no nosso exemplo, confirmar clicando em `Accept`

  <p align="center"> <img src="/pt-br/assets/gui_24.png"> </p>


6. Após confirmada a informação de requisição, clique em `Merge`

  <p align="center"> <img src="/pt-br/assets/gui_25.png"> </p>


7. Agora, copie o código da janela **Need Signature** e envie para a outra parte envolvida, **B**, que deverá utilizá-lo para reconhecer a requisição do seu lado (como **A** fez nos passos anteriores)

  <p align="center"> <img src="/pt-br/assets/gui_26.png">



#### Parte envolvida **B**

3. Agora é a vez de **B** reconhecer a transação, colando o código gerado em **A.7** no campo **counterparty request** da aba **merge tx. request** e clicando em `Validate`

  <p align="center"> <img src="/pt-br/assets/gui_27.png"> </p>


4. Em seguida, na janela **Transaction Verification**, **B** confirma a transação clicando em `Accept`

  <p align="center"> <img src="/pt-br/assets/gui_28.png"> </p>


5. Após confirmada a transação, **B** deve clicar em `merge`

  <p align="center"> <img src="/pt-br/assets/gui_29.png"> </p>


6. Se tudo ocorrer corretamente, a janela `Trade Success` irá abrir com o código da transação e representando que a transação do acordo foi bem-sucedida; a janela pode ser fechada clicando em `close`

  <p align="center"> <img src="/pt-br/assets/gui_30.png"> </p>



Na aba de ativos (**Asset**) veremos os ativos que acabaram de ser acordadados com a outra parte (**B** recebeu 5 MyToken de **A**)

  <p align="center"> <img src="/pt-br/assets/gui_31.png"> </p>



#### `Signature` - Signatário 

  ##### **_PRECISA MELHORAR A COMPREENSÃO DO USO_**

Algumas transações precisam ser reconhecidas por outra(s) parte(s). O código recebido de cada parte, deve então, ser colado no campo `Input` e em seguida confirmado clicando em `Signature` para adicionar o signatário.
Quando o número necessário de signatários for atingido, o botão `broadcast` ficará disponível. Clique em `Broadcast` para transmitir à rede a informação.

<p align="center"> <img src="/pt-br/assets/gui_32.png"> </p>

Se tudo ocorrer corretamente, a janela de transação bem-sucedida irá se abrir.

<p align="center"> <img src="/pt-br/assets/gui_33.png"> </p>



## `Advanced` - Avançado

### `NeoGas Claim...` - Resgate de GAS

Novos GAS são gerados a cada novo bloco registrado na *blockchain*. Esses GAS são registrados nos endereços dos portadores de NEO. Na aba de ativos `Asset`, o número entre parênteses representa a quantidade de GAS que pode ser resgatada.

<p align="center"> <img src="/pt-br/assets/gui_34.png"> </p>

A qualquer momento o usuário portador de NEO pode solicitar o resgate dos GAS para o endereço dos NEO correspondentes. Atualmente, apenas a versão para PC do **Neo-GUI** possui a funcionalidade de resgatar GAS.

Para o resgate de GAS, os passos são:

1. Transfira todos os NEO da carteira através de uma operação de transferência. É possível transferir os NEO diretamente ao mesmo endereço atual. 
      - Se você for em `Advanced` na barra superior e clicar em `NeoGas Claim...`, a janela de resgate abrirá com o botão de resgate de GAS `Claim All` em cinza, desativado; Não é possível resgatar os GAS sem antes realizar uma transferência dos NEO.
      
      
  <p align="center"> <img src="/pt-br/assets/gui_35.png"> </p>
      
2. No menu `Trasanction`, clique em `Transfer...` e realize uma transferência de todos os NEO, nesse exemplo, para a mesma conta, como mostrado na imagem
      <br>
      
  <p align="center"> <img src="/pt-br/assets/gui_36.png"> </p>
      
3. Uma vez realizada a transferência, volte a `Advanced`, clique em `NeoGas Claim...` e agora clique em `Claim All` 
      
  <p align="center"> <img src="/pt-br/assets/gui_37.png"> </p>
      
      
4. Após realizado o resgate, os GAS ficam disponíveis e podem ser vistos no endereço
      <br>
      <p align="center"> <img src="/pt-br/assets/gui_38.png"> </p>
      

<br><br>
### `Request Certificate...` - Solicitar um certificado

> [!IMPORTANT] 
> A funcionalidade de solicitar e importar certificados não está disponível na versão atual do Neo-GUI.

Esta funcionalidade permite unicamente gerar o arquivo de de solicitação de certificado. O usuário ainda precisará recorrer a uma autoridade certificadora para solicitar o certificado.

  1. Vá em `Advanced`, clique em `Request Certificate...` e preencha os campos

  <p align="center"> <img src="/pt-br/assets/gui_39.png"> </p>

  2. Clique em `OK` e defina onde o arquivo será salvo

  <p align="center"> <img src="/pt-br/assets/gui_40.png"> </p>

  3. Uma vez gerado o arquivo, aplicaremos a uma entidade certificadora para que possamos emitir o certificado; Uma vez emitido, importaremos o certificado para o armazenamento **Personal**

  <p align="center"> <img src="/pt-br/assets/gui_41.png"> </p>

  4. Após importado, clique no endereço com o botão direito do mouse, vá em `Import` e clique em `Import from Certificate` para selecionar o certificado; clique `OK`

  <p align="center"> <img src="/pt-br/assets/gui_42.png"> </p>


### `Asset Registration...` - Registrar ativos

Existem dois tipos de ativos: **Tokens** e **Shares**. Neste exemplo vamos registrar um ativo do tipo Token.

  1. Vá em `Advanced` e clique em `Asset Registration`; 
      - Em `Asset Type`, indique o tipo de ativo, neste exemplo "Token", preencha os campos e clique em `OK`

   <p align="center"> <img src="/pt-br/assets/gui_43.png"> </p>

      
  2. Como o registro de ativos custa uma quantia de GAS, primeiro clique em `Test` para saber a tarifa, e então, se quiser seguir com o registro, clique em `Invoke`

   <p align="center"> <img src="/pt-br/assets/gui_44.png"> </p>
   

  3. Se tudo ocorrer bem, irá aparecer a janela de transação bem-sucedida com o **id** da transação

  <p align="center"> <img src="/pt-br/assets/gui_45.png"> </p>
  
  >[!Note]
  > O id da transação de registro de ativo será utilizado na sessão seguinte para a distribuição de ativos


### `Asset Distribution...` - Distribuição de ativos

  1. Vá em `Advanced`, clique em `Asset Distribution` e no campo `Asset Id` insira o id obtido na transação anterior (de registro do ativo); Clique no botão `[+]`

  <p align="center"> <img src="/pt-br/assets/gui_46.png"> </p>

  2. Em `Pay To` e em `Amount` inserimos, respectivamente, o endereço para o qual iremos distribuir e a quantia que será distribuida; Clicamos em `Ok` e em `Confirm`

  <p align="center"> <img src="/pt-br/assets/gui_47.png"> </p>

  3. Uma vez distribuido, na aba `Asset` será possível ver os ativos que acabamos de enviar

  <p align="center"> <img src="/pt-br/assets/gui_48.png"> </p>


### `Deploy contract...` - Implementar *smart contracts*

Neste exemplo vamos implementar um *smart contract* criado na sessão [_**Smart Contracts**_](../sc/getting-started.md)

1. Vá em `Advanced`, clique em `Deploy Contract` e preencha todos os campos

  <p align="center"> <img src="/pt-br/assets/gui_49.png"> </p>


2. No campo `Code` pode-se tanto colar o código quanto carregá-lo de um arquivo; neste exemplo o *smart contract* será carregado de um arquivo; Depois de inserir o código ou escolher o arquivo, clique em `Deploy`

  <p align="center"> <img src="/pt-br/assets/gui_50.png"> </p>


3. Na janela seguinte, clique em `Test` para saber o custo para gerar o contrato na *blockchain* e clique em `Invoke`

  <p align="center"> <img src="/pt-br/assets/gui_51.png"> </p>


4. Se tudo ocorrer bem, a janela de transação bem-sucedida aparecerá com o **id** da transação

  <p align="center"> <img src="/pt-br/assets/gui_52.png"> </p>


5. Na janela `Transaction History` podemos ver que o contrato foi implementado corretamente e suas confirmações

  <p align="center"> <img src="/pt-br/assets/gui_53.png"> </p>


### `Invoke Contract...` - Invocar um contrato

Neste exemplo vamos invocar o contrato implementado anteriormente.

1. Vá em `Advanced`, clique em `Invoke Contract` e no campo `Custom` colamos o código gerado anteriormente na implementação do contrato; Clique em `Test` para saber a tarifa para invocar o contrato e em seguida clique em `Invoke`

  <p align="center"> <img src="/pt-br/assets/gui_54.png"> </p>


2. Uma vez invocado o contrato, veremos a mensagem de transação bem-sucedida com o id da transação

  <p align="center"> <img src="/pt-br/assets/gui_55.png"> </p>

3. Agora na aba `Transaction History` podemos ver que a invocação do contrato foi implementada corretamente 

  <p align="center"> <img src="/pt-br/assets/gui_56.png"> </p>


### `Election...` - Eleição

Esta função é usada para registrar um candidato a Nó de Consenso na *blockchain*.

  > [!IMPORTANT] 
  > A função de eleição para Nó de Consenso não está disponível atualmente.

1. Vá em `Advanced` e clique em `Election`

  <p align="center"> <img src="/pt-br/assets/gui_57.png"> </p>

  > [!Note] 
  > Da mesma forma que o registro de ativos requer uma quantia de GAS, o registro para candidato também reguer.



### `Options...` - Opções

_**Conteúdo Pendente**_


## `Help` - Ajuda

  ### `*Check for help*` - Procure ajuda

  _**Conteúdo pendente**_

  ### `*Official Web*` - website oficial

  [https://neo.org](https://neo.org)

  ### `Developer Tool` - Ferramenta de Desenvolvimento

  _**Conteúdo pendente**_

  ### `About NEO` - Sobre o NEO

  Mostra a versão da interface Neo-GUI.
