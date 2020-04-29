# Big and Little Endian Usage

All integer types in Neo are coded in little endian, except for cases when transfering IP address and port number, big endian are adopted.
In practical use,  especially when constructing transactions using SDK for transferring assets or invoking smart contracts, developers must correctly choose the big or little endian byte order, otherwise it may lead to the loss of assets.

In this section, we will describe endianness usage of the wallet address and contract scripthash in some common scenarios.

## Address and ScriptHash
### The wallet address scripthash
When creating a wallet in Neo blockchain, the private key, public key, wallet address, and related scripthash are generated.

Let's look at a standard wallet address and corresponding scripthash strings in big and little endian formats beneath.

- Address: AceQbAj2xuFLiH5hQAHMnV39wtmjUKiVRj
- ScriptHash
  - Big endian：0x946d6caa602a2b85fbeb7cf05335b2c3b124f1e4
  - Little endian：e4f124b1c3b23553f07cebfb852b2a60aa6c6d94

To convert between the wallet address and scripthash, or between big endian and little endian byte order, use one of the following:

- [DataTransformationTools](https://peterlinx.github.io/DataTransformationTools/)
- Neo SDK (See [Data Conversion](../sdk/conversion.md))

### The contract scripthash
When a contract has been deployed a scripthash is generated as a unified identifier of the contract. The contract scripthash can be converted into the standard 20-byte address for receiving assets from transfer transactions. In that case the contract scripthash is used in big endian format. For example:

- CGas ScriptHash (big endian)：0x 74f2dc36a68fdc4682034178eb2220729231db76 

- CGas contract address：AScKxyXmNtEnTLTvbVhNQyTJmgytxhwSnM

## Usage scenarios
The wallet address is commonly used in the transaction of global assets transfer or smart contract invocation.
### Global assets transfer
In the case that you construct a global asset transfer transaction (ContractTransaction) using Neo SDK, you need to construct related Output for the asset receiver. As shown below, you should fill in TransactionOutput with **big-endian** scripthash of the address receiving assets.

```
var outputs = new List<TransferOutput>{ new TransferOutput()
{
    AssetId = Blockchain.UtilityToken.Hash, //AssetId of GAS
    ScriptHash = "Ad1HKAATNmFT5buNgSxspbW68f4XVSssSw".ToScriptHash(), //The address scripthash is big endian
    Value = new Fixed8((long)(0.999 * (long)Math.Pow(10, 8)))
}}.ToArray();
```

### Smart contract invocation
When invoking a smart contract that requires a wallet address scripthash be passed, note that you should use the correct endianness.

#### Invoking contract through RPC

As an example, use [InvokeFunction](../../reference/rpc/latest-version/api/invokefunction.md) to invoke the method balanceOf of an NEP-5 contract.

If data type of the passed address is Hash160, you should enter **big-endian** scripthash of the address.

```
    {
        "jsonrpc": "2.0",
        "method": "invokefunction",
        "params": [
            "74f2dc36a68fdc4682034178eb2220729231db76",
            "balanceOf",
            [
            {
                "type": "Hash160", //The Data type is Hash160
                "value": "946d6caa602a2b85fbeb7cf05335b2c3b124f1e4" //The address scripthash is big endian
            }
            ]
        ],
        "id": 3
    }
```

If data type is ByteArray, you should enter **little-endian** scripthash of the address.

```
{
    "jsonrpc": "2.0",
    "method": "invokefunction",
    "params": [
        "74f2dc36a68fdc4682034178eb2220729231db76",
        "balanceOf",
        [
        {
            "type": "ByteArray", //The Data type is ByteArray
            "value": "e4f124b1c3b23553f07cebfb852b2a60aa6c6d94" //The address scripthash is little endian
        }
        ]
    ],
    "id": 3
}
```

#### Invoking contract through SDK


In the case that you use Neo SDK to construct InvocationTransaction, you need to construct the execution script with ScriptBuilder to invoke the contract. As an example, here we use Neo-SDK JavaScript [neon-js](http://cityofzion.io/neon-js/en/), you should use **little-endian** scripthash of the wallet address：

```
const { default: Neon, api, rpc, wallet, tx, u } = require("@cityofzion/neon-js");
const privateKey = "8fdebad22fe4a13b6f430120b784606213eb123a54118b6b265bbc896015fd21";
const account = new wallet.Account(privateKey);
const cgasContractHash = "74f2dc36a68fdc4682034178eb2220729231db76"; //CGAS ScriptHash

const fromAddressLittle = Neon.u.reverseHex(wallet.getScriptHashFromAddress("Abjdb3tegQmAjXVAAYuQPHG9Lw4j2mjUhT")); // address -> ScriptHash (Little Endian)
const toAddressLittle = Neon.u.reverseHex(wallet.getScriptHashFromAddress("AceQbAj2xuFLiH5hQAHMnV39wtmjUKiVRj")); // address -> ScriptHash (Little Endian)
sb.emitAppCall(cgasContractHash, "balanceOf", [fromAddressLittle, toAddressLittle, 250000000]);
var script = sb.str;

const rpcClient = new rpc.RPCClient("http://seed10.ngd.network:20332");
rpcClient.invokeScript(script)
    .then(response => {
        console.log(response.stack);
    })
    .catch(err => {
        console.log(err);
    });
```

After execution is finished, you can view the log using [getapplicationlog method](../../reference/rpc/latest-version/api/getapplicationlog.md). The execution log outputs little-endian scripthash of the address as it uses the ByteArray data type.
