# Signature and verification

The process of CGAS execution can be roughly divided into two steps. The first step is to execute the verification scripts in the transaction, namely the Verification trigger. If the verification fails, the transaction will not be confirmed. This step is performed by all nodes that receive the transaction before the block is generated.

The second step is to execute the smart contract, namely the Application trigger. This step is performed by all nodes that synchronize blocks after synchronization.

The relevant script in the first step is called Witness, which contains validation script and invocation script. When NeoVM is running, the verification script is the code executed by the smart contract, of which the parameters in included in the invocation script, usually the signature.

Multiple sets of invocation and validation scripts can be included in Witness. Refer to [CGAS GitHub](https://github.com/neo-ngd/CGAS-Contract) for details.

The following is an example of the transaction for the first step of the refund.

Transaction structure for the first step of the refund:

> [!Note]
>
> - Type: InvocationTransaction
>
> - Input: transfer from the contract address of CGAS
>
> - Output: transfer to the contract address of CGAS (same as input)
>
> - Script: invoke the refund method, setting the parameter to the refunder's Script Hash
>
> - Scripts: need two witnesses: 1、 witness of CGAS contract ; 2、witness of the user（additional witness）

```c#
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x306daa4ab2b2ef73ff4fd8f9121fc926f5e21653080602b6841ad3f17f80777c",
        "size": 7205,
        "type": "InvocationTransaction",
        "version": 0,
        "attributes": [
            {
                "usage": "Script",
                "data": "e8e3ce08268d16d867101feaf8c0ea130a923aba"
            }
        ],
        "vin": [
            {
                "txid": "0x48bd784d0ed6000cba64d0e303117e4c10081e3268afcf3b07e8b353a7594772",
                "vout": 0
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "5",
                "address": "AScKxyXmNtEnTLTvbVhNQyTJmgytxhwSnM"
            },
            {
                "n": 1,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "5",
                "address": "AScKxyXmNtEnTLTvbVhNQyTJmgytxhwSnM"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
                "invocation": "520131",
                "verification": ""
            },
            {
                "invocation": "404c53a9ca937470df9dcbbb71cf00e2b4d75761e4667ccfd820e40829887c4444c7911ed509e564b2bac30e41c92c43f7df2dd2a25ea1c8e2bc10aec3d3208251",
                "verification": "21037ebe29fff57d8c177870e9d9eecb046b27fc290ccbac88a0e3da8bac5daa630dac"
            }
        ],
        "script": "14e8e3ce08268d16d867101feaf8c0ea130a923aba51c106726566756e646776db3192722022eb7841038246dc8fa636dcf274f1",
        "gas": "0",
        "blockhash": "0xd04d56259a6c92e290ab009e2062fbd078c3c371036d74dd745b379a4d55a899",
        "confirmations": 14,
        "blocktime": 1536907058
    }
}
```

## CheckWitness() and additional witness

Note that there are attributes in this transaction, since CheckWitness() exists in the smart contract code. For the permission verification of the current contract, it’s not necessary to add a script to the transaction attribute. This is limited to the signature verified not the contract itself. For example, in the first step of the refund, the user is passed in via the parameter from, and its script hash is not equal to the CGAS script hash. In this case, the script hash of from needs to be added as an additional witness to the transaction attributes.

Also, the verification can be omitted (as the first verification script in the example above), if so, the node will automatically add this part by the script hash on the chain. This requires knowing the full script hashes and the order of the items in witness. Currently items in witness are sorted in ascending order of script hash.

In this way, since the system knows the full script hashes (script hashes of the current contract plus the script hashes listed in the transaction attributes) and positions all the invocation and validation scripts, as well as the matching order of these invocation and verification scripts to the script hash, then it can execute the code.

## OpCode script

After finishing talking about the CheckWitness() and transaction attributes, let's take a look at the first set of invocation scripts. The example above is 520131. What does this mean? First put 52 into the invocation stack, then put 01, and then put 31.

Interpret the code according to the comments in [OpCode](https://github.com/neo-project/neo-vm/blob/master/src/neo-vm/OpCode.cs) when fetching data, so 52 means to Push 2.

0x01 means the following is an array with the length 1 (0x01 corresponds to decimal 1), and the next 1 byte is the data, not the instruction.

0x31 corresponds to the character ‘1’ in the ASCII code.

So the first parameter is the digit 2 and the second parameter is the string "1".

Push these two parameters into the invocation stack. Read the data according to the order of the stack, the first popped parameter is the string "1", and then is the digit 2.

**Example 1**

With the above example, let's look at the second set of invocation scripts:

```
404c53a9ca937470df9dcbbb71cf00e2b4d75761e4667ccfd820e40829887c4444c7911ed509e564b2bac30e41c92c43f7df2dd2a25ea1c8e2bc10aec3d3208251
```

0x40 corresponds to decimal 64, the next 64 bits is a byte array (actually a signature).

**Example 2**

Take a look at the second set of verification scripts:

```
21037ebe29fff57d8c177870e9d9eecb046b27fc290ccbac88a0e3da8bac5daa630dac
```

0x21 corresponds to decimal 33, the next 33 bits is a byte array (actually a public key), and the last 0xac means CHECKSIG, which means verifying the signature, and that’s it.
## Next Step
Now let us know how to [invoke this CGAS contract](7_invocation.md)

To learn the function of mint token and refund, click [here](5_minttokens_and_refund.md).

