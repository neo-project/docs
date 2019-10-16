# Validation of blocks
As with transactions, blocks are validated by every node on the network. The goal for this validation is that every block can independently be validated on any node, and is not depending on any external characteristics. 

## Invocation and Verification Script
Every full node on the network receives the full NEO blockchain from its peers, and will independently validate every block it receives to ensure that the block received was not sent by a malicious or faulty node. This way, the nodes are not required to trust any other node, creating a secure and trustless system. For every block received, the node will validate all individual transactions in that block by means of using the Verification Script to validate the Invocation Script. This Invocation Script can be seen as the key to unlock the UTXO, proving that it has the right to spend it, and passing the Verification Script as a tool for every node to validate this. For more information on transaction validation, have a look at [Transactions](../3-transactions/1-Introduction_to_transactions.md).

Apart from the Invocation Script and Validation Script on each individual transaction, every block itself also contains an Invocation Script and Validation Script. The Validation Script is sometimes referred to as the *Witness* as well.

When we look at the block with height 3,649,960, which was introduced in [Structure of transactions on the NEO blockchain](2-Structure_of_a_block.md), we can identify these 2 scripts in the field "script." It is repeated below for convenience:

```
"script": {
	"invocation": "4013a82dff8a58ff750703cc32852899124917ded6bd7a7d66bf31d693890488717ab4ee258c0806286d3c2d49da4f9f52d1c6a20843ab5a9a0b4e867ed3d4c5644087875bbc17e8300bb2ee82b3623833be4693fe378cde10e380ce64fe4f1cdba6acb70b6d9d3c52efaa776a6c8a5f91cf3a48b6df79edeae1cd26259b00add96640a1053731b59c6687965e942600301b68f79252e9aa08047115e649930df679d853438bc95c88c9cfa7aa9737d51f82d25dde5b5435cd8266a132a726d7d01f294043df832e612d220c3ce639cbca4ab18f9ce21dfd8718340dae4ca49fd239a4ee06d294e9d583bc4e0da5cccb5eb0f35e7b836d7c633b1e9ca20c0c0af429644740c352f2425c56001a292cc28cba9e736913f9c116580796efacda4270ac104659173ee1bc4bed706c0f3ea90c9b8201653abe74a30e627c443855af6c08c90acb",
	"verification": "5521024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d21025bdf3f181f53e9696227843950deb72dcd374ded17c057159513c3d0abe20b6421035e819642a8915a2572f972ddbdbe3042ae6437349295edce9bdc3b8884bbf9a32103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae"
}
```

Now this might seem some totally random cryptic code. However, there's a method to this madness. Let us dig in.

## Opcodes
The OpCodes for NEO can be found [here](https://github.com/neo-project/neo-vm/blob/master/src/neo-vm/OpCode.cs). When validating a block, these OpCodes tell the NeoVM how to proceed. Let's start by looking at the verification string. As this is a HEX representation of the byte code, we take it byte per byte. The way it works is that you interpret every OpCode and push it onto the execution stack, one at a time. This stack eventually gets executed by the NeoVM to validate the block.

```   
5521024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d21025bdf3f181f53e9696227843950deb72dcd374ded17c057159513c3d0abe20b6421035e819642a8915a2572f972ddbdbe3042ae6437349295edce9bdc3b8884bbf9a32103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae
```

1. We start with the first byte: `0x55`. According to our table of OpCodes, we find:

   ```
   /// <summary>
   /// The number 5 is pushed onto the stack.
   /// </summary>
   PUSH5 = 0x55
   ```

   So we push the number 5 onto our stack.

2. Next up: `0x21`. This will make us take the next 33 bytes and push them onto the stack.

   ```
   /// <summary>
   /// Push 33 bytes on the evaluation stack.
   /// </summary>
   PUSHBYTES33 = 0x21
   ```

3. The next 33 bytes are pushed to the stack:

   ```
   024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d
   ```

4. After these 33 bytes, we again see an OpCode `0x21` (...6662d4a59ad548df0e7d**21**025bdf3f...). This again means to take the next 33 bytes and push them on the stack. We have a total of 7 occurrences of OpCode `0x21`, and thus 7 times 33 bytes that are pushed onto the stack.

   | Adding a total of 7 occurrences of 33 bytes to the stack 		|
	|----------------------------------------------------------------------	|
   | 0x024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d 	|
   | 0x025bdf3f181f53e9696227843950deb72dcd374ded17c057159513c3d0abe20b64	|
   | 0x035e819642a8915a2572f972ddbdbe3042ae6437349295edce9bdc3b8884bbf9a3 	|
   | 0x03b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c 	|
   | 0x03b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a 	|
   | 0x02ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba554 	|
   | 0x02df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e895093 	|

5. We're almost there! Now we only have the last 2 bytes left. The next one is `0x57`. So we push the number 7 on the stack.

   ```
   /// <summary>
   /// The number 7 is pushed onto the stack.
   /// </summary>
   PUSH7 = 0x57
   ```

6. The last byte to parse is `0xae`. Let's look this up one last time:

   ```
   /// <summary>
   /// A set of n public keys (an array or value n followed by n pubkeys) is validated against a set of m signatures (an array or value m followed by m signatures). Verify transaction as multisig and a boolean output is put on top of the main stack.
   /// </summary>
   CHECKMULTISIG = 0xAE
   ```

   So the final stack will look like this:

   | Full stack of the Verification Script	|
	|----------------------------------------------------------------------	|
	| 5                                                                    	|
   | 0x024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d 	|
	| 0x025bdf3f181f53e9696227843950deb72dcd374ded17c057159513c3d0abe20b64	|
	| 0x035e819642a8915a2572f972ddbdbe3042ae6437349295edce9bdc3b8884bbf9a3 	|
	| 0x03b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c 	|
	| 0x03b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a 	|
	| 0x02ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba554 	|
	| 0x02df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e895093 	|
	| 7                                                                    	|
	| CHECKMULTISIG                                                        	|

   When we apply the same process to decode the bytecode of the Invocation Script, we come up with 5 HEX strings, each 64 bytes.

   | Full stack of the Invocation Script	|
	|----------------------------------------------------------------------	|
   |0x13a82dff8a58ff750703cc32852899124917ded6bd7a7d66bf31d693890488717ab4ee258c0806286d3c2d49da4f9f52d1c6a20843ab5a9a0b4e867ed3d4c564|
   |0x87875bbc17e8300bb2ee82b3623833be4693fe378cde10e380ce64fe4f1cdba6acb70b6d9d3c52efaa776a6c8a5f91cf3a48b6df79edeae1cd26259b00add966|
   |0xa1053731b59c6687965e942600301b68f79252e9aa08047115e649930df679d853438bc95c88c9cfa7aa9737d51f82d25dde5b5435cd8266a132a726d7d01f29|
   |0x43df832e612d220c3ce639cbca4ab18f9ce21dfd8718340dae4ca49fd239a4ee06d294e9d583bc4e0da5cccb5eb0f35e7b836d7c633b1e9ca20c0c0af4296447|
   |0xc352f2425c56001a292cc28cba9e736913f9c116580796efacda4270ac104659173ee1bc4bed706c0f3ea90c9b8201653abe74a30e627c443855af6c08c90acb|

## Interpretation
We've done it! Now we know what's inside both the Invocation and Verification Scripts, let's look at what they mean. The goal of these scripts is to allow any node to validate that the block was actually created and agreed upon by the consensus nodes. To do this, the consensus nodes sign the block with their private key. From the moment we have 5 of the 7 consensus nodes that signed the same block, we achieve consensus and the block is valid. These 5 signatures are the ones included in the Invocation Script.

Now all we need to be able to do, is to validate that these 5 signatures are actually valid in order to validate the block. For that, the block contains the Verification Script. This way, the block tells every node how to validate it. The node that validates the block thus executes the Verification Script, and if this script passes, then the block is marked as valid.

We already found the meaning of the Verification Script. What happens is that the 7 public keys of the consensus nodes that were involved in creating this specific block are used. The way this is done is with a concept similar to a multisig transaction, which is then applied on a block. The last OpCode `CHECKMULTISIG` is the one that gives meaning to everything that came before. The syntax is interpreted as a 5-out-of-7 multisig, and the 7 33-byte strings on the stack are therefore interpreted as the public keys of these 7 nodes.

A block is then considered valid if the 5 signatures in the Invocation Script can be verified using 5 out of the 7 provided public keys in the Verification Script.

## What's next?

[NEO Protocol and Networking](../5-network/1-Introduction_to_the_NEO_network_protocol.md)