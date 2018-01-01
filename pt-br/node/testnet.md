# Rede de Teste (TestNet)

A rede de testes é um ambiente de rede NEO onde o usuário pode desenvolver e testar programas e ações antes de implementá-los de fato na rede NEO principal (real). O GAS e NEO utilizados na rede de testes não são os mesmos da rede principal e não têm validade na mesma, sendo de propósito exclusivo para pagar tarifas na rede de teste para viabilizar os testes. 

A *blockchain* da rede de testes é independente da rede principal. Ela é suficiente para testar o desenvolvimento de *smart contracts*, operações de ativos, etc. Após os testes terem sido bem sucedidos, os projetos devem ser movidos para a rede NEO principal.

Se você precisar de NEO e GAS na rede de testes, você pode solicitá-los [aqui](https://www.neo.org/Testnet/Create) sem custo algum.


## Características da rede de testes

1. Não tem custo financeiro para testar registro e distribuição de ativos, execução de *smart contracts*, etc
2. É global, implatada na internet. Os *smart contracts* desenvolvidos na rede de testes podem ser utilizados em qualquer parte do mundo
3. Serve pra testar blocos da rede; transações e outras informações podem ser vistas checadas num [navegador de *blockchain*](https://neoscan.io)
4. A rede de testes não pode ser utilizada para aplicações comerciais


## Interfaces para a rede de teste

As interfaces de usuário (Neo-GUI) e de linha de comando (Neo-CLI) para a rede de testes são as mesmas das rede principal. Para alternar entre a rede principal e a rede de testes, basta alterar o arquivo de configuração das interfaces Neo-GUI ou Neo-CLI.

Referência: [Introdução ao Nó NEO](introduction.md).

|      | Neo-GUI                       | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Releases | [site oficial](https://www.neo.org/download) ou [GitHub](https://github.com/neo-project/neo-gui/releases/) | [GitHub](https://github.com/neo-project/neo-cli/releases/) |
Código fonte | [GitHub](https://github.com/neo-project/neo-gui/) | [GitHub](https://github.com/neo-project/neo-cli/) |


## Configurar os softwares para a rede de teste

Na pasta em que se encontra o arquivo executável `neo-gui.exe` (no caso de usar **Neo-GUI**) ou `neo-cli.exe` (no caso de usar **Neo-CLI**), situam-se os arquivos `protocol.testnet.json`, `protocol.mainnet.json`, `protocol.json`, `config.testnet.json`, `config.mainnet.json` e `config.json`, como mostrado na imagem abaixo. 
  - Os arquivos `protocol.json` e `config.json` são efetivamente lidos pelo Neo-GUI 
  - `protocol.testnet.json` e `config.testnet.json` são cópias que armazenam a configuração para utilizar a rede de teste 
  - da mesma forma, `protocol.mainnet.json` e `config.mainnet.json` são cópias que guardam as informações necessárias para utilizar a rede principal

<p align="center"> <img src="/pt-br/assets/testnet_1_v2.png"> </p>

<p align="center"> <img src="/pt-br/assets/testnet_2_v2.png"> </p>

#### Para utilizar a rede de testes:
1. Substitua o conteúdo do arquivo `protocol.json` pelo conteúdo presente no arquivo `protocol.testnet.json`  

2. Substitua o conteúdo do arquivo `config.json` pelo conteúdo presente no arquivo `config.testnet.json` 

> [!NOTE]
> Para utilizar a rede principal novamente, basta repetir o processo utilizando os conteúdos dos arquivos `protocol.mainnet.json` e `config.mainnet.json`.


# Solicitar NEO e GAS para uso na rede de teste

1. Certifique-se que os arquivos estão com a configuração correta para utilizar a Rede de Teste

2. Inicie o software (nesse exemplo, é o Neo-GUI) e tenha certeza de que está sincronizado

<p align="center"> <img src="/pt-br/assets/gui_1.png"> </p>
 
3. Crie uma carteira, utilizando o procedimento já descrito na [documentação do Neo-GUI](gui.md)

4. Uma vez criada a carteira, uma conta referência (*Account*) será automaticamente gerada

5. Clique com o botão direito do mouse sobre a conta referência, clique em `View Private Key` e copie a chave pública (conteúdo do campo *Public Key:*) como mostra a imagem abaixo

<p align="center"> <img src="/pt-br/assets/testnet_3.png"> </p>
  
6. Entre no [website da Rede de Teste](https://neo.org/en-us/Testnet/Create) para solicitar os NEO/GAS

7. Preencha o formulário. 
  * No campo `Reasons for Application`, explique detalhadamente seu projeto com informações como nome, descrição, website, white paper, uso dos NEO/GAS, etc

8. No campo `NEO PUBLIC KEY` insira a chave pública que foi copiada no passo **5.** 

<p align="center"> <img src="/pt-br/assets/testnet_4.png"> </p>
 
9. Após preencher o formulário, clique em `Submit Application`

10. Em alguns dias, se a aplicação for aprovada pela equipe NEO, receberás um e-mail com a conta contrato reconhecida e uma chave pública. Usaremos essa chave pública para criar uma conta contrato a partir de nossa conta referência  


    #### Criando a conta contrato

    - Clique com o botão direito sobre a conta em sua carteira (a que foi auto-gerada na criação da carteira), em `Create Contract Add.` e em `Multi-Signature...`
 
    <p align="center"> <img src="/pt-br/assets/testnet_5.png"> </p>
 
    - No campo `Min. Sig. Num.` coloque `1`
  
    - Na area `Public Key list` adicione as duas chaves públicas: a que foi recebida do NEO por e-mail e a sua (utilizada nos passos da sessão anterior) e clique em `Confirm`
 
    <p align="center"> <img src="/pt-br/assets/testnet_6.png"> </p>
 
    - Após a confirmação, em cerca de 5 minutos, os NEO e GAS solicitados vão estar disponíveis
 
    <p align="center"> <img src="/pt-br/assets/testnet_7.png"> </p>
  
 
11. Agora você pode transferir os NEO e GAS da conta contrato para a conta referência da carteira
