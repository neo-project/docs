# CLI - Interface de Linha de Comando

Abra o prompt de comando do SO, navegue até o diretório em que o conteúdo do NeoCLI foi extraído, e execute o comando abaixo para iniciar a carteira (em outras palavras, o Nó NEO).

```
dotnet neo-cli.dll
```

<p align="center"><img src="/pt-br/assets/cli_1.png"></p>

> [!Note] 
> Para executar a interface `Neo-CLI`, é necessária a instalação do [Runtime .NET Core](https://www.microsoft.com/net/download/core#/runtime)  **versão 1.1.2** ou superior


Ao executar, o interpretador de linha de comando é carregado no prompt. Através dos comandos  o NeoCLI, você consegue criar uma carteira, importar e exportar chave privada, realizar transferências, iniciar processo de consenso, etc.

Primeiro vamos explorar os comandos disponíveis, listados abaixo. No prompt de comando, você pode digitar `help` para ver esta lista.

<p align="center"><img src="/pt-br/assets/cli_2.png"></p>

- Parênteses angulares ``<>`` indicam um parâmetro.
- Colchetes `[]` são parâmetros opcionais.
- O símbolo `|` indica preenchimento de uma ou outra(s) informação(ões).
- O sinal de igual `=` representa o valor *default* quando não houver *input* para o parâmetro opcional.


## 1. Instruções do Console

| Comando      | Descrição da Função      |
| ------- | --------- |
| version | Versão atual do software |
| help    | Menu de ajuda      |
| clear   | Limpa o conteúdo mostrado no prompt  |
| exit    | Sai do Neo-CLI    |


## 2. Operação de Carteira

Comando | Descrição da Função | Observação |
| ---------------------------------------- | -------------------------------- | ------ |
| `create wallet <caminho>` | Cria um arquivo de carteira no caminho especificado |
| `open wallet <caminho>` | Abre a carteira pelo arquivo contido no caminho especificado |
| `rebuild index` | Refaz os índices da carteira | Necessita abrir a carteira antes |
| `list address` | Lista todas as contas na carteira | Necessita abrir a carteira antes |
| `list asset` | Lista todos os ativos na carteira | Necessita abrir a carteira antes |
| `list key` | Lista todas as chaves públicas na carteira | Necessita abrir a carteira antes |
| `show utxo [id\|alias]` | Lista as transações pelo *id* ou pelo *alias* | Necessita abrir a carteira antes |
| `show gas` | Mostra a quantidade de GAS | Necessita abrir a carteira antes |
| `claim gas` | Resgata o GAS disponível | Necessita abrir a carteira antes |
| `create address [n = 1]` | Cria um ou mais endereços de forma automática | Necessita abrir a carteira antes |
| `import key <wif\|caminho>` | Importa uma ou mais chaves privadas de uma só vez | Necessita abrir a carteira antes |
| `export key [endereço] [caminho]` | Exporta a chave privada | Necessita abrir a carteira antes |
| `send <id\|alias> <endereço> <valor> [fee=0]`| Envia ao endereço especificado | Necessita abrir a carteira antes |


Os seguintes comandos são explicados com mais detalhes:

#### `rebuild index`

Este comando é usado para refazer os índices da carteira.
Existe um campo na carteira que registra a altura do atual bloco sincronizado na carteira. Para cada novo bloco na *blockchain*, a carteira é sincronizada e seus ativos e transações são re-calculados e atualizados com base nas mudanças sofridas no novo bloco. Supondo que a altura do bloco atual seja 100 e você importa uma chave privada, a carteira vai carregar as informações existentes e registrar que a altura atual é 100. Porém, se a chave importada possuir transações oriundas de blocos de altura menor do que 100, os índices da carteira devem ser refeitos forçando a carteira re-calcular seus ativos desde o bloco de altura 0. Lembre-se que não existe um balanço na *blockchain*, apenas fluxo de informação com base no valor prévio e nas transações realizadas desde então.

Carteiras recém criadas não necessitam que se refaça seus índices. Refaça apenas quando importar chaves privadas.


#### `create address [n = 1]`

Cria *n* novo(s) endereço(s). Quando é criado mais de um endereço em uma só execução (exemplo `create address 35`), a lista de endereços criados é automaticamente exportada para o arquivo `address.txt`.


#### `export key [endereço] [caminho]`

Você pode especificar um endereço e/ou caminho de arquivo para onde exportar a chave privada. O comando requer confirmação usando a senha da carteira. Veja exemplos:

```
export key
```

```
export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b
```

```
export key chave.txt
```

```
export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b chave.txt
```


#### `import key <wif | path>`

Quando importar uma chave privada, você pode optar por fazê-lo inserindo a chave em si ou o caminho do arquivo que contém a(s) chave(s) desejada(s). 

```
import key L4zRFphDJpLzXZzYrYKvUoz1LkhZprS5pTYywFqTJT2EcmWPPpPH
```

```
import key key.txt
```
> [!Note]
> Se um arquivo for especificado, ele precisa estar no formato adequado. Para saber o formato, veja o arquivo de saída do comando `export key exemplo.txt`.


#### `send <id | alias> <address> <value> [fee = 0]`

Este comando exige confirmação com a senha da carteira. 
Os parâmetros para envios (transferências) são: 
  - O primeiro parâmetro é o *id* do ativo. Se estiver incerto sobre o *id* do ativo, use o comando `list asset`
  - O segundo parâmetro é o endereço de destino
  - O terceiro é a quantia a ser enviada
  - O quarto é a tarifa para realizar a operação
  
<br>

Os *ids* dos ativos próprios do sistema são:
  - NEO: *c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b*
  - GAS: *602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7*

<br>

Exemplo de comando para enviar 100 NEO para o endereço `AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b`:

```
send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100
```

<br>

## 3. Informações do Nó

Comando | Descrição |
| ---------- | ----------------------- |
`show state` | Mostra o status atual da sincronização da *blockchain* |
`show node` | Mostra o endereço e porta dos Nós conectados |
`show pool` | Mostra as transações armazenadas na memória (Estas transações ficam em estado de zero confirmação) |


## 4. Instruções Avançadas

Comando | Descrição |
| --------------- | ---- |
`start consensus` | Inicia o processo de consenso
Inicia o processo de consenso com a premissa de que a carteira tem autoridade de Nó de Consenso. <br>Para o caso de uma rede privada, as chaves públicas dos Nós de Consenso devem ser configurados no arquivo `protocol.json`. Para mais detalhes, acesse a documentação de [redes privadas](private-chain.md).
`export blocks [path=chain.acc]` | Exporta a *blockchain* para um arquivo |
`refresh policy` | Atualiza a diplomacia
