# Charging Model

Participants in NEO ecosystem need to pay network fees and system fees with GAS when using the NEO network. Fees distribution rule is shown below:

[![economic model](../images/blockchain/economic_model.jpg)](../../images/blockchain/economic_model.jpg)

### Network Fee

Network fee is the fee to pack transactions into a block. Users can define the amount of network fee. Network fee is paid to consensus node as new block incentive. Theoretically the higher network fee per byte is, the easier corresponding transaction is to be put into a block. In the current main network, a block supports up to 500 transactions, including up to 20 free transactions.

The default charging rules are as follows:

<table class='table table-hover'>
    <thead>
        <tr>
            <th>Transaction type</th>
            <th>Transaction size (byte）</th>
            <th>Total fee (GAS)</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td rowspan="2">Non-ClaimTransaction transactions</td>
            <td>&lt;= 1024</td>
            <td>0</td>
        </tr>
        <tr>
            <td>&gt; 1024</td>
            <td>Transaction size&times;0.00001 + 0.001<br></td>
        </tr>
        <tr>
            <td rowspan="3">ClaimTransaction</td>
            <td>All</td>
            <td>0</td>
        </tr>
    </tbody>
</table>



> [!Note]
>
> - If the user specifies fee when using the send command/method to send the transaction to the user's address, only the higher of the two fees is charged.
> - A configuration file config.json is added in NEO-CLI 2.10.2+ RpcWallet plugin to allow you to specify the fee limit for transactions sent using RPC commands. If the transaction fee does not exceed the fee limit, it will be processed on blockchain normally; otherwise the transaction will fail.

### System Fee
System fees are the cost of resources consumed by the transaction execution in NeoVM. The total fee depends on the number and type of instructions executed in the smart contract script. All Smart Contract fees are considered as Service fee to be put in a pool for re-distribution to all NEO holders. The distribution is proportional to amount of NEO.

The system fees of the special transactions defined in NEO are listed in the table below:

| Type | System Fee (GAS) | Description |
| --------   | :-----:   | :----: |
| MinerTransaction | 0 | The first transaction of a block, used to allocate byte fees |
| RegisterTransaction | 10000 | (Deprecated) Registers assets |
| IssueTransaction | 500 | Issues assets |
| ClaimTransaction | 0 | Claims GAS |
| EnrollmentTransaction | 1000 | (Deprecated) Enroll as validator candidate |
| StateTransaction | 1000 | Enrolls as a validator candidate or votes for consensus nodes |
| ContractTransaction | 0 | The most commonly used transaction |
| PublishTransaction | 500 | (Deprecated) Publishes smart contracts |
| InvocationTransaction | Fees vary with execution instructions. | Invokes smart contracts |

Additionally, when running a smart contract, system calls or instructions executed by NeoVM also incur system fees. For details, refer to [Fees](../../sc/fees.md).
