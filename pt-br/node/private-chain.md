# Criação de uma *blockchain* privada

A implementação de uma *blockchain* privada requer ao menos 4 servidores para chegar a um consenso segundo o [mecanismo dBFT](/consesus.md). Cada servidor age como um nó de consenso e possui uma carteira NEO dedicada.


## 1. Configuração da máquina virtual

Abaixo estão ilustradas 4 máquinas virtuais (daqui em diante chamadas de VM) criadas no Azure, com tamanho padrão DS1 v2 (1 núcleo, 3,5 GB RAM). 

![image](/assets/privatechain_1.png)

Após criadas as VMs, a porta 10331-10334 deve ser aberta. Vá na configuração do *Firewall* do sistema, em **Configurações Avançadas** e em **Regras de entrada**. Adicione uma `Nova Regra...` do tipo *porta* com protocolo *TPC* e então insira o valor *10331-10334*.

> [!Note]
> Se for criada uma VM em um servidor na nuvem (*cloud server*), acesse o painel administrativo da VM e configure um grupo seguro de rede.
>
> Caso utilize o Azure, vá em `Network Interface` > `Network Security Group` > `Inbound Security Rules` > `add` e adicione a porta *10331-10334*.

Uma vez que as 4 VMs foram criadas, salve os seus endereços IP para uso futuro.


## 2. Instalação do Nó NEO

O processo de instalação do nó NEO em sua máquina está descrito detalhamente nas [instruções de interfaces da rede NEO](setup.md).

> [!Note]
> Para o procedimento descrito nesta sessão, utilize a instalação da interface de linha de comando Neo-CLI

## 3. Crie uma carteira

Primeiro precisaremos criar 4 arquivos de carteiras NEO (neste exemplo com os nomes `wallet1.db3`, `wallet2.db3`, `wallet3.db3` e `wallet4.db3`). **Este passo** pode ser realizado tanto com o [Neo-GUI](gui.md), quanto com o [Neo-CLI](cli.md). A imagem abaixo ilustra a interface Neo-CLI.

![image](../assets/privatechain_3.png)

Uma vez criadas as carteiras, salve suas chaves públicas em um arquivo de texto ou como preferir. Mova o arquivo `.db3` de cada uma das 4 carteiras, para a pasta em que se encontra o Neo-CLI na respectiva VM.

> [!Tip]
> Você pode ver a chave pública de uma carteira no Neo-CLI usando o comando `list key`


## 4. Modificando o arquivo de configuração

Abra o arquivo `protocol.json` que se encontra no diretório do Neo-CLI. Ele terá uma estrutura similar a esta:

```json
{
  "ProtocolConfiguration": {
    "Magic": 1704630,
    "AddressVersion": 23,
    "StandbyValidators": [
"02f27545181beb8f528d13bbb66d279db996ecb56ed9a324496d114acb48aa7a32",
      "02daa386d979ae6643869a365294055546023acb332ee1a74a5ae5d54774a97bac",
      "0306f12f7217569cdbe9dde9ff702d0040e0a4570873eee63291adaa658128e55c",
      "035781b4d55dc58187f61b5d9277afbaae425deacc5df57f9891f3a5c73ecb24df"
   ],
    "SeedList": [
      "13.75.112.62:10333",
      "137.116.173.200:10333",
      "168.63.206.73:10333",
      "137.116.171.134:10333"
   ],
    "SystemFee": {
      "EnrollmentTransaction": 1000,
      "IssueTransaction": 500,
      "PublishTransaction": 500,
      "RegisterTransaction": 10000
    }
  }
}
```

  - *`Magic`*: O número mágico, *Magic*, é usado para identificar a origem da rede de mensagens. Especificando um valor *Magic* diferente, garantimos que informação de diferentes redes não interfiram umas nas outras. Altere este valor, porém utilize o mesmo número para todos os nós dessa rede privada.

> [!Note]
> O número mágico é unitário, então o seu valor deve estar na faixa entre 0 e 4294967295.

  - *`StandbyValidators`*: Este vetor compreende a lista das chaves dos nós de consenso da rede privada, no nosso exemplo, os 4 servidores que criamos anteriormente. Troque os valores presentes pelas 4 chaves públicas salvas no passo **3**.

  - *`SeedList`*: Preencha este campo trocando os valores atuais pelos endereços de IP das 4 VMs criadas, que salvamos no passo **1**.

  - *`SystemFee`*: Tarifa paga para realizar operações e utilizar serviços do sistema. Aqui você pode definir a tarifa para a sua rede privada. O valor inicial padrão é, em unidades de GAS:
    - Registrar Nó de Consenso: 1000 
    - Distribuir Ativos: 500 
    - *Smart Contracts*: 500
    - Registrar Ativo: 10000


Faça as alterações descritas acima para os arquivos `protocol.json` em cada uma das 4 VMs, substituindo o conteúdo anterior pelas novas configurações.

Finalmente, em cada VM use os comandos abaixo para inicializar o Nó, carregar a carteira e começar o processo de consenso. Se estiver confuso, revise a [referência dos comandos do Neo-CLI](cli.md).

#### Inicializar o Nó:
```
dotnet neo-cli.dll
```

#### Carregar carteira:
```
open wallet wallet1.db3
```

> [!Note]
> Atente para alterar o número no nome do arquivo da carteira para a VM correspondente. A linha de código acima é para a VM com a "carteira 1", ou seja, com o arquivo `wallet1.db3`

#### Iniciar processo de consenso:
```
start consensus
```
Se tudo ocorrer como esperado, os 4 nós irão iniciar um processo de consenso, como mostrado abaixo

<p align="center"><img src="/pt-br/assets/privatechain_8.png"></p>

> [!Note]
> O consenso é alcançado mesmo se um dos nós de consenso estiver estiver desconectado, isto é, a sua VM não estiver rodando. Esta condição é ilustrada na imagem abaixo.

<p align="center"><img src="/pt-br/assets/privatechain_9.png"></p>




## 5. Extraindo NEO e GAS

Instale a interface gráfica do NEO ([Neo-GUI](gui.md)) e altere o arquivo `protocol.json` para conectá-lo à rede privada que foi criada anteriormente. O arquivo neste caso esta contido na pasta do Neo-GUI e deve ser configurado com os mesmos parâmetros que utilizamos no passo **4** para o Neo-CLI nas VMs.
Abra o programa executando o arquivo `neo-gui.exe`. Para comprovar que a conexão com a rede privada foi bem-sucedida, no canto inferior esquerdo você verá que o tamanho da *blockchain* é maior que zero e o número de conexões (`connected`) é 4, como mostra a figura abaixo.

> [!Note]
> Se você parou uma VM para testar o processo de consenso como no passo **4**, o número de conexões será 3 e não 4

<p align="center"><img src="/pt-br/assets/privatechain_10.png"></p>


Abra a carteira de arquivo `wallet1.db3`. Clique com o botão direito do mouse sobre a *hash* de endereço, mova o cursor para `Create Contract Add.` e clique em `Multi-Signature...`.

<p align="center"><img width="600" src="/pt-br/assets/privatechain_11.png"></p>

Insira as 4 chaves públicas salvas no passo **4**. Para isso, inserida cada chave no campo inferior e clique no símbolo `[+]`. Após inserir as chaves, altere o parâmetro `Min. Sig. Num.` para *3*, como mostra a figura abaixo.

> [!Note]
> O número 3 vem da expressão `n/2 + 1`, onde *n* é o número de nós de consenso

<p align="center"><img src="/pt-br/assets/privatechain_12.png"></p>

> [!Important] 
> Repita este passo de inserção *Multi-Signature* com as 4 chaves para cada uma das outras 3 carteiras dos servidores!

Após realizado o passo nas outras VMs, abra novamente a carteira `wallet1.db3` e refaça seus índices. Para tal, vá na barra de menu, em `Wallet` > `Rebuild Index`.

<p align="center"><img src="/pt-br/assets/privatechain_13.png"></p>

Uma vez refeitos os índices, aparecerá o endereço de contrato com 100 milhões de NEO.

<p align="center"><img src="/pt-br/assets/privatechain_14.png"></p>

> [!Note]
> Refaça os índices nas carteiras das outras VMs também.

Agora vamos enviar os NEO do endereço de contrato para o endereço da conta. Abra qualquer uma das 4 carteiras e vá em `Transaction` > `Transfer` e coloque o endereço destinatário que receberá os 100 milhões de NEO.

<p align="center"><img src="/pt-br/assets/privatechain_15.png"></p>

O sistema mostrará a mensagem **Transaction initiated, but the signature is incompleted**, pois são necessárias mais assinaturas para confirmar a transação já que é um contrato *Multi-Signature*.

<p align="center"><img src="/pt-br/assets/privatechain_16.png"></p>

Clique em `copy` e em seguida abra qualquer uma das outras 3 carteiras. No menu superior, vá em `Transaction` > `Signature`

<p align="center"><img src="/pt-br/assets/privatechain_17.png"></p>

Cole o código que acabou de ser copiado no campo **Input**, clique em `Signature` e copie o código do campo **Output** clicando em `copy`.

<p align="center"><img src="/pt-br/assets/privatechain_18.png"></p>

Repita o passo anterior: abra uma carteira distinta, das que ainda não foram abertas. Na barra de menu vá em `Transaction` > `Signature`. No campo **Input** cole o último código copiado e clique em `Signature`. Neste momento o botão `Broadcast` ficará visível, o que significa que a transação se completou com sucesso (Foi alcançado o número mínimo de assinaturas requerido pelo contrato). Clique em `Broadcast` para finalizar a operação.

<p align="center"><img src="/pt-br/assets/privatechain_19.png"></p>

Pode levar cerca de 15 segundos para a transferência ser realizada. Após esse curto período, abra o arquivo da carteira destino que recebeu os NEO para ver que foram transferidas para o endereço de conta.

<p align="center"><img src="/pt-br/assets/privatechain_20.png"></p>

A operação de extração dos GAS é similar. Abra a carteira `wallet1.db3` e na barra de menu vá em `Advanced` > `NeoGas Claim...`.

<p align="center"><img src="/pt-br/assets/privatechain_21.png"></p>

Clique em `Claim All`.

<p align="center"><img src="/pt-br/assets/privatechain_22.png"></p>

Como no caso anterior, veremos uma mensagem de quantidade de assinaturas insuficiente. 

<p align="center"><img src="/pt-br/assets/privatechain_23.png"></p>

Continue seguindo os passos realizados recentemente para validar o contrato de transferência dos 100mi NEO. 
  - Copie o código de assinatura incompleta;
  - Abra outra carteira; 
    - Vá no menu superior em `Transaction` > `Signature`;
    - Cole o código copiado no campo **Input**
    - Clique em `Signature`; 
    - Copie o código do campo **Output**;
  - Abra uma terceira carteira; 
    - Na barra de menu, vá em `Transaction` > `Signature`;
    - Cole o último código copiado;
    - clique em `Signature` 
    - Clique em `Broadcast`.

<p align="center"><img src="/pt-br/assets/privatechain_24.png"></p>

A transferência pode levar cerca de 15 segundos para ser transmitida completamente. Após esse tempo, refaça novamente os índices da carteira no menu superior em `Wallet` > `Rebuild Index`.

<p align="center"><img src="/pt-br/assets/privatechain_25.png"></p>

Uma vez refeitos os índices, os GAS irão aparecer no endereço de conta.

<p align="center"><img src="/pt-br/assets/privatechain_26.png"></p>
