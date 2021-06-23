# Global assets and NEP-5 assets

Two types of assets are supported in NEO: global assets and NEP-5 assets.

Global assets are the native assets supported by NEO. With a unified template, registration, issue, and transfer can be easily done by filling in the parameters in the neo-gui client. Global assets’ issuers can be identified by binding digital certificates. For example, a company can issue real-name certified assets such as stocks, vouchers, membership cards, etc. on NEO with a digital certificate issued by the CA authority. However, the cost is high. Taking the price of GAS 15 yuan as an example, the annual cost of issuing global assets is about 5000 * 15 = 75,000 yuan.

In simple terms, the advantages of global assets are simplicity, security and supporting digital certificates, while the cost is high.

NEP is called NEO Enhancement Proposals, and NEP-5 refers to the No.5 NEO enhancement proposal, named Token Standard, which specifies the asset specifications in smart contracts. NEP-5 assets are technically contract assets that meet the NEP-5 standards. It is the "asset" stipulated by the developer to register issue and transfer in the smart contract. The circulation, name, precision, and balance of all users are stored in the storage area of the smart contract. The security of the NEP-5 asset depends on the contract developer, who can open source the contract for community audit or not. To use NEP-5 assets means trusting developers not to do evil.

In simple terms, NEP-5 assets have the advantages of high degree of freedom, supporting complex smart contracts and lower issuance costs, while they do not support digital certificates, with lower security than global assets.

For an introduction to NEP-5, you can refer to previous tutorials or [GitHub](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki).

Here is a systematic comparison of the two assets.

|                          | Global assets                | NEP-5 assets               |
| ------------------------ | ----------------------- | ------------------------ |
| Time to start support             | native support                | Since 2.0       |
| Supposed time to end support          | Since NEO 3.0             |                          |
| Representative assets                 | NEO、GAS                | CGAS、SDUSD、NNC、PHX, etc.  |
| Registration fee                 | 5000GAS/year | 500~1000 GAS             |
| Model to store records             | UTXO                | Balance                 |
| Security                   | High                      | Depends on contract developers         |
| Functions                     | Simple                    | Complicated                     |
| Identification via digital certificates       | Support                    | Not support                   |
| Transfer through smart contracts | No                    | yes                       |


## Next Step
In order to learn how the UTXO is working in CGAS, we move to [here](3_utxo_model.md).

If you want to know what is CGAS, click [here](1_what_is_cgas.md).
