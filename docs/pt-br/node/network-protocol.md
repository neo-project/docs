# Protocolo de rede

NEO utiliza estrutura de rede P2P (*peer-to-peer*), na qual a comunicação entre os nós (*peers*) é feita através do protocolo TPC/IP. Nesta estrutura, os nós são separados em duas categorias: Nós de Rede e Nós Validadores (Nós de Consenso). Os Nós de Rede - nós simples, máquinas conectadas na rede - podem transmitir, receber e transferir transações ou blocos, enquanto que os Nós de Consenso participação da criação dos blocos. 
O protocolo de rede da NEO é bastante similar ao do Bitcoin, entretanto, suas estruturas de dados como bloco ou transações são muito diferentes.


## Convenção

1. **Ordem dos bytes** : O tipo **inteiro** no NEO é *Little-Endian*, com exceção ao endereço IP e ao número de porta, que são *Big-Endian*

2. _**Hash**_ : NEO usa duas funções diferentes: SHA256 e RIPEMD160 
SHA256 é utilizada para gerar uma *hash* longa, enquanto RIPEMD160 gera *hash's* curtas. Normalmente a *hash* é obtida aplicando-se duas vezes a função em si. Por exemplo, SHA256 é utlizada duas vezes para gerar a *hash* de bloco ou de transação, já para gerar um endereço de contrato, primeiro a função SHA256 é utilizada uma vez e em seguida a RIPEMD160 é utilizada.

Além disso, o bloco usará uma estrutura de *hashes* chamada Merkle Tree, que permite o armazenamento de dados (transações do bloco) de forma segura, fiel e estruturada. Cada bloco tem uma *hash* adicional, chamada *Merkle Root*, que carrega toda a informação da *Merkle Tree*. 


3. **Comprimentos das variáveis por tipo**

   + *Variant*： Inteiro de tamanho variável. Pode ser codificada de acordo com seu valor para poupar espaço

      |Valor|Tamanho|Formato|
      |---|---|---|
      |< 0xfd|1|uint8|
      |<= 0xffff|3|0xfd + uint16|
      |<= 0xffffffff|5|0xfe + uint32|
      |> 0xffffffff|9|0xff + uint64|

   + *Varstr*： *String* de tamanho variável, composta por um inteiro de tamanho variável seguido de *strings*; é codificada em formato UTF8
   
      |Tamanho|Campo|Tipo de Dado|Descrição|
      |---|---|---|---|
      | ? |length|variant|comprimeto de da *string* em bytes|
      |length|string|uint8[length]| a *string* em si|

   + *array*： inteiro de comprimento variável seguido por uma série de elementos

4. **Número de tamanho-fixo**
   Dados como *quantia* ou *preço*, no NEO são números de tamanho-fixo, de 64 bits; têm precisão decimal de ordem 10<sup>-8</sup> (8 casas após a vírgula) e pertencem ao domínio real [-2<sup>63</sup>/10<sup>8</sup>, +2<sup>63</sup>/10<sup>8</sup>]


## Tipos de dados


### 1. _Blockchain_

  A *blockchain* é um tipo de estrutura lógica, formada pelo encadeamento sequencial e ordenado de uma série de blocos de dados. É utilizada para armazenar os dados de toda a rede, como transações e ativos.
      
### 2. Bloco
> [!Note]
> Tabelas precisam melhorar... falta clareza.. ALTERAR

   |Tamanho|Campo|Tipo|Descrição|
   |---|---|---|---|
   |4|Version|uint32|versão do bloco|
   |32|PrevBlock|uint256|*hash* do bloco anterior|
   |32|MerkleRoot|uint256|*hash* raiz da estrutura *Merkle Tree* das transações contidas no bloco|
   |4|Timestamp|uint32|*timestamp*|
   |4|Height|uint32|altura, isto é, número de blocos, da *blockchain*|
   |8|Nonce|uint64|número aleatório|
   |20|NextMiner|uint160|endereço de contrato do próximo mineiro|
   |1|-|uint8|Fixada no valor 1|
   |?|Script|script|Script usado para validar o bloco|
   |?*?|Transactions|tx[]|Lista de transações|

   Quando se gera a *hash* do bloco, ao invés de computar o bloco inteiro, apenas os 7 primeiros campos do bloco são avaliados, que são, *versão*, *PrevBlock*, *MerkleRoot*, *timestamp*, *height*, *nonce* e *NextMiner*. Dado que *MerkleRoot* contém a *hash* de todas as transações, a modificação de alguma transação refletirá na alteração da *hash* do bloco.
 
   Estrutura de dados do *header* ("cabeçalho") de um bloco:

   |Tamanho|Campo|Tipo|Descrição|
   |---|---|---|---|
   |4|Version|uint32|versão do bloco|
   |32|PrevBlock|uint256|*hash* do bloco anterior|
   |32|MerkleRoot|uint256|*hash* raiz da estrutura *Merkle Tree* das transações contidas no bloco|
   |4|Timestamp|uint32|*timestamp*|
   |4|Height|uint32|altura, isto é, número de blocos, da *blockchain*|
   |8|Nonce|uint64|número aleatório|
   |20|NextMiner|uint160|endereço de contrato do próximo mineiro|
   |1|-|uint8|Fixada no valor 1|
   |?|Script|script|Script usado para validar o bloco|
   |1|-|uint8|Fijada a valor 0|
      
  O *timestamp* de cada bloco deve, obrigatoriamente, ser posterior ao *timestamp* do bloco prévio. Geralmente a diferença entre *timestamps* de dois blocos consecutivos é de aproximadamente 15 segundos.

### 3. Transação

   |Tamanho|Campo|Tipo|Descrição|
   |---|---|---|---|
   |1|Type|uint8|tipo de transação|
   |1|Version|uint8|versão do acordo, inicialmente 0|
   |?|-|-|Dados específicos dos tipos de transação|
   |?*?|Attributes|tx_attr[]|atributos adicionais da transação|
   |34*?|Inputs|tx_in[]|entradas|
   |60*?|Outputs|tx_out[]|saídas|
   |?*?|Scripts|script[]|lista de scripts utilizados para validar a transação|

   Todos os processos no sistema NEO são salvos como transações, que por sua vez, podem ser de um dos tipos abaixo.

   |Valor|Nome|Tarifa do sistema|Descrição|
   |---|---|---|---|
   |0x00|MinerTransaction|0|atribuir tarifa de byte|
   |0x01|IssueTransaction|500\|0|emissão de ativo|
   |0x02|ClaimTransaction|0|resgate de GAS|
   |0x20|EnrollmentTransaction|1000|inscrição de um validador (Nó de Consenso)|
   |0x40|RegisterTransaction|10000|registro de ativo|
   |0x80|ContractTransaction|0|transação de contrato|
   |0xd0|PublishTransaction|500 * n|(não utilizável) transações especiais para *smart contracts*|
   |0xd1|InvocationTransaction|0|transações especiais para a chamada (invocação) de *smart contracts*|

Cada tipo de transação, além do campo público, possui um campo exclusivo privado. Abaixo, segue a descrição destes campos com mais detalhes.

   + *MinerTransaction*
     
   |Tamanho|Campo|Tipo de Dado|Descrição|
   |---|---|---|---|
   |4|Nonce|uint32|número aleatório|
  
A primeira transação em cada bloco deve ser do tipo *MinerTransaction*. É uma transação utilizada para recompensar os validadores de cada bloco com as tarifas de transação de tal bloco. O emprego de um número aleatório serve para evitar choque de *hashes* entre os blocos.
      
   + *IssueTransaction*

      Não há um campo especial para este tipo de transação.

Os gestores de ativos podem criar e enviar os ativos registrados na *blockchain* através de uma *IssueTransaction*. Em particular, se os ativos emitidos são NEO, a transação será enviada de graça.
 
   + *ClaimTransaction*

      |Tamanho|Campo|Tipo de Dado|Descrição|
      |---|---|---|---|
      |34*?|Claims|tx_in[]|NEO's para distribuição|

   + *EnrollmentTransaction*

      |Tamanho|Campo|Tipo de Dado|Descrição|
      |---|---|---|---|
      |33|PublicKey|ec_point|chave pública do nó validador|

      A transação representa um formulário de inscrição que indica que o responsável pela transação deseja se registrar como validador. A forma de registrar-se se dá pela construção de uma transação do tipo *EnrollmentTransaction* e do envio de um depósito para o endereço da chave pública. Para cancelar o registro, basta gastar o depósito no endereço da chave pública.
      
   + *RegisterTransaction*

      > [!Note]
      > Foi desativada e substituída por *Neo.Asset.Create* para *smart contract*.
      > Consultar [Framework .NET *Smart Contract* Alternativo](../sc/fw/dotnet/Neo/Asset/Create.md)
      > Consultar [API *Smart Contract* Alternativa](../sc/api/Neo.md)

   + *ContractTransaction*

      Não há atributos especiais para uma transação de contrato. Este é um tipo de transação muito comum já que permite o envio de NEO de uma carteira para outra. Os campos `transaction`, `inputs` e `outputs` serão importantes para este tipo de transação (por exemplo, para definir a quantia de NEO que será enviada e o endereço de destino).

   + *PublishTransaction*

      > [!Note]
      > Este tipo foi desativo e substituído por `Neo.Contract.Create` para *smart contract*.
      > Consultar [Framework .NET *Smart Contract* Alternativo](../sc/fw/dotnet/Neo/Contract/Create.md)
      > Consultar [API *Smart Contract* Alternativa](../sc/api/Neo.md)
            

   + *InvocationTransaction*
   
   Invocar/chamar uma transação.

   | Tamanho | Campo | Tipo de dado | Descrição |
   | --- | --- | --- | --- |
   | -    | -      | -       | Campos públicos para transações |
   | ?    | Script | uint8[] | Invocar por *smart contract* |
   | 8    | GAS    | int64   | Custo em GAS necessário para executar o *smart contract* |
   | -    | -      | -       | Campos públicos para transações  |


### 4. Atributos de uma Transação

   | Tamanho | Campo | Tipo de dado | Descrição |
   |---|---|---|---|
   |1|Usage|uint8|uso|
   |0\|1|length|uint8|comprimento de dado (circustâncias específicas serão omitidas)|
   |length|Data|uint8[length]|dados externos|

   Quando a transação contém dados para uso externo, estes dados são colocados no campo de atributos da transação.

   Cada atributo tem diferente uso, como mostrando na tabela a seguir.

   |Valor|Nome|Descrição|
   |---|---|---|
   |0x00|ContractHash| *hash* do contrato |
   |0x02-0x03|ECDH02-ECDH03| Chave pública para intercâmbio de chave ECDH |
   |0x20|Script| Validação adicional de transações|
   |0x30|Vote| Voto |
   |0x80|CertUrl| Endereço url do certificado |
   |0x81|DescriptionUrl| Endereço url da descrição |
   |0x90|Description| Breve descrição |
   |0xa1-0xaf|Hash1-Hash15| Usado para armazenar *hashes* próprias |
   |0xf0-0xff|Remark-Remark15| Notas/Observações |

   Para *ContractHash*, *ECDH series* e *Hash series*, o comprimento de dados está fixado em 32 bytes e o comprimento do campo está omitido;
   Para *CertUrl*, *DescriptionUrl*, *Description* e *Remark series*, o comprimento dos dados deve ser claramente definido e não deverá exceder 255;

### 5. Entrada da transação (*inputs*)

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |32|PrevHash|uint256| *hash* da transação anterior |
   |2|PrevIndex|uint16| índice da transação anterior|


### 6. Saída da transação (*outputs*)

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |32|AssetId|uint256|*id* do ativo|
   |8|Value|int64|valor|
   |20|ScriptHash|uint160|endereço do remetente|

   Cada transação poderá ter saídas até 65536.


### 7. Script de validação

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |?|StackScript|uint8[]|código do script da pilha (*stack*) |
   |?|RedeemScript|uint8[]|código do script do contrato|

  Script de pilha só pode ser utilizado para operações *PUSH*, que são utilizadas para inserir dados como assinaturas na pilha. O interpretador de scripts executará primeiro o código do script de pilha e depois o código do script de contrato.

Em uma transação, a *hash* do código de script de contrato deve ser coerente com a saída da transação, que faz parte da validação. Na seção seguinte, o processo de execução será tratado com mais detalhes.
 

# Mensagem de Rede


Todas as mensagens de rede são enviadas com a seguinte estrutura:

|Tamanho|Campo|Tipo de dado|Descrição|
|---|---|---|---|
|4|Magic|uint32|*id* de protocolo|
|12|Command|char[12]|comando|
|4|length|uint32|comprimento de *payload*|
|4|Checksum|uint32|checksum|
|length|Payload|uint8[length]|conteúdo das mensagens|

Definição de número mágico:

|Valor|Descrição|
|---|---|
|0x00746e41|produção|
|0x74746e41|teste|

Comando é no formato UTF8, em que o comprimento é de 12 bytes e a parte que sobra é preenchida com 0s.
*Checksum* são os 4 primeiros bytes de duas vezes a *hash* SHA256 do *payload*.

De acordo com diferentes estados, o *payload* tem formato diferente:

### 1. *version*

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |4|Version|uint32|versão do protocolo; por enquanto 0 |
   |8|Services|uint64|o serviço provido pelo nó; atualmente 1|
   |4|Timestamp|uint32|hora atual|
   |2|Port|uint16|porta que o servidor está escutando; 0 se não usado|
   |4|Nonce|uint32|usado para distinguir o nó do *IP* público |
   |?|UserAgent|varstr|*id* do cliente|
   |4|StartHeight|uint32|tamanho da *blockchain*|
   |1|Relay|bool|se recebe ou encaminha|

   Quando um nó recebe uma solicitação de conexão, este declara sua versão imediatamente. Não haverá outra comunicação até que ambas as partes estejam recebendo as versões uma da outra.

### 2. *verack*

   Quando um nó recebe a mensagem de versão, este responde imediantamente com um 'verack' de resposta. Esta mensagem não tem *payload*

### 3. *getaddr*

   Fazer solicitações a um nó para receber os nós ativos e assim aumentar o número de conexões. Esta mensagem não tem *payload*.

  
### 4. *addr*

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |30*?|AddressList|net_addr[]| endereço dos outros nós da rede |

   Depois de receber a mensagem `*getaddr*`, o nó devolve, como resposta, uma mensagem 'addr' com informação sobre os nós conhecidos na rede.
   
    
### 5. *getheaders*

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |32*?|HashStart|uint256[]| *hash* do primeiro bloco solicitado pelo nó |
   |32|HashStop|uint256| *hash* do último bloco solicitado pelo nó |

   Solicita a um nó os *headers* dos blocos que contêm *hash* desde a *HashStart* até a *HashStop*, com limite máximo de 2000 blocos. Para obter a *hash* de mais blocos do que este limite, é preciso reenviar a mensagem `getheaders`. Esta mensagem é utilizada para rapidamente fazer o download da blockchain sem o conteúdo de transações.


### 6. *headers*

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |?*?|Headers|header[]| *header* (cabeçalho) do bloco |

   Após receber a mensagem `getheaders`, o nó retorna uma mensagem `header` como resposta, contendo a informação dos nós conhecidos da rede.
   
### 7. *getblocks*

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |32*?|HashStart|uint256[]| *hash* do primeiro bloco solicitado pelo nó |
   |32|HashStop|uint256| *hash* do último bloco solicitado pelo nó |

   Realiza solicitações a um nó pela mensagem `inv` desde a *HashStart* até a *HashStop*, para um limite máximo de 500 blocos. Para obter a *hash* de mais blocos além do 500º, é necessário reenviar a mensagem `getblocks`.
   
### 8. *inv*

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|dados de registro (inventório) |

   Através desta mensagem, o nó pode transmitir a informação que possui de objeto. A mensagem pode ser enviada automaticamente ou ser utilizada para responder a mensagens `getblocks`.
   
   *A informação de objeto possui os seguintes campos:*
   
   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |4|Type|uint32|tipo de objeto|
   |32|Hash|uint256|*hash* de objeto|

   *Podendo o objeto ser de um dos seguintes tipos:*

   |Valor|Nome|Descrição|
   |---|---|---|
   |0x01|TX|transação|
   |0x02|Block|bloco|
   |0xe0|Consensus|dado de consenso|

### 9. *getdata*

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|dados de registro|

   Solicita um objeto específico de um nó. Normalmente é enviado após o pacote `inv` ter sido recebido e o elemento conhecido ter sido removido.
   
### 10. *block*

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |?|Block|block|bloco|

   Envia um bloco a um nó para responder a mensagem `getdata`.

### 11. *tx*

   |Tamanho|Campo|Tipo de dado|Descrição|
   |---|---|---|---|
   |?|Transaction|tx|transação|

   Envia uma transação a um nó para responder a mensagem `getdata`.
