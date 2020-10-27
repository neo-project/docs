# Deploying and invoking contract

In the previous section we have compiled an NEP-5 contract file (NEP5.nef) and contract descriptive file (NEP5.manifest.json), next we will move on to deployment and invocation of the contract with Neo-CLI.

## Deploying contract

In Neo-CLI, input the deploy command  `deploy <nefFilePath> [manifestFile]` , for example:

```bash
deploy NEP5.nef
```

Or

```bash
deploy NEP5.nef NEP5.manifest.json
```

After the command is executed, the NEP-5 contract is deployed and the related fee is charged by the system automatically.

```bash
neo> deploy NEP5.nef
Script hash: 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26
Gas: 3

Signed and relayed transaction with hash=0xe03aade81fb96c44e115a1cc9cfe984a9df4a283bd10aa0aefa7ebf3e296f757
```

For more information, refer to [Deploying Smart Contracts](../deploy/deploy.md)。

## Invoking contract

Now we can invoke the contract using the Neo-CLI command `invoke`:

```bash
invoke <scriptHash> <operation> [contractParameters=null] [witnessAddress=null]
```

For example:

```bash
invoke 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26 name
```

After executed successfully, the following information is printed：

```bash
Invoking script with: '10c00c046e616d650c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0103609
Evaluation Stack: [{"type":"ByteArray","value":"TXlUb2tlbg=="}]

relay tx(no|yes):
```

Where:

- VM State: `HALT` indicates the vm executed successfully;  `FAULT` indicates the vm exited during execution due to an exception.
- Evaluation Stack: the result of contract execution, where the value is encoded with Base64 when it is a string or ByteArray.

For more information, refer to [Invoking Smart Contracts](../deploy/invoke.md).
