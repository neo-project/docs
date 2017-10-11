# Introdução aos Nós da Rede NEO
Nós são máquinas conectadas na rede, e quando estes nós ou máquinas armazenam uma cópia completa da *blockchain*, eles são chamados de nós "*full*". Eles se conectam à *blockchain* através de uma rede P2P e se comportam tanto como cliente quanto como servidor.

Existem dois *softwares* para nós *full* no NEO: o **Neo-GUI**, voltado para clientes NEO, comporta todas as funções básicas de um usuário/cliente, incluindo interface gráfica; e o **Neo-CLI**, voltado aos desenvolvedores NEO, oferece uma API com funções básicas de carteiras e também irá ter papel na geração de blocos e auxílio no mecanismo de consenso.

O [protocolo de rede NEO](network-protocol.md) irá prover uma API de baixo nível para algumas transações que não suportadas pelo Neo-CLI, como reinvindicar GAS ou enviar NEO sem uma carteira aberta.

## Downloads dos Softwares de Nó NEO 

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Lançamentos | [Official website](https://www.neo.org/download) ou [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Código fonte | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Comparação entre as funções do Neo-GUI e do Neo-CLI

|           | GUI  | CLI  |
| --------- | ---- | ---- |
| Interface Gráfica | ✅    |      |
| Interface com linha de comando |      | ✅    |
| Criação de carteira | ✅    | ✅    |
| Carteira aberta | ✅    | ✅  |
| Reconstrução de índice de carteira | ✅    | ✅    |
| Visualização de todos pares de chaves | ✅    | ✅    |
| Importa/Exporta pares de chaves | ✅    | ✅    |
| Visualização de todos endereços | ✅    | ✅    |
| Visualização de todos ativos  | ✅    | ✅    |
| Criação de endereços | ✅    | ✅    |
| Transferências | ✅    | ✅    |
| Transações (troca de ativo)  | ✅    |      |
| Criação de *smart contract* multilateral | ✅    |      |
| Criação de *smart contract* customizado | ✅    |      |
| Assinatura | ✅    |      |
| Nó de Consenso | ✅    |      |
| Votação | ✅    |      |
| Registro de ativos | ✅    |      |
| Distribuição de ativos | ✅    |      |
| Extração de NEO | ✅    |      |
| Geração de endereços em lotes (*batch*)  |      | ✅    |
| JSON-RPC |      | ✅    |
| Consenso dos blocos participantes |      | ✅    |

## Descrição de Porta

Se você desejar acessar a API do nó a partir de um programa externo, é necessário liberar uma porta no firewall. Abaixo há uma descrição das portas que podem ser configuradas.

|                    | Rede Principal | Rede de Teste |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |

Para mais informações, acesse a documentação da [rede de teste](testnet.md).
