<center><h2>Token Model</h2></center>

### **Native Token**

&emsp;&emsp;There are 2 kinds of native token defined in Neo system: NEO and NeoGas (GAS).

&emsp;&emsp;NEO is Governing Token. Neo holders can take part in NEO network management, including voting for consensus nodes, network parameter modification, etc. NEO's total amount is 100 million. Its minimum unit is 1 and can not be divided. It's registered in Genesis block, and stored in standby validators' muti-signature addresses.

&emsp;&emsp;GAS is utility token, or network fuel token. Operation costs and incentive for consensus node in NEO network are paid in GAS. GAS's total amount is also 100 million and can be divided to 0.00000001 unit. Gas is registered in Genesis block and issued afterwards as block incentive for NEO holders.

&emsp;&emsp;A new block is generated about every 15 seconds according to system design. Thus approximately 2 million new blocks are created every year. 100 million GAS is issued gradually in 22 years according to a attenuation algorithm. No GAS is issued afterwards.

| Cycle |  Block Height Range | Block excitation GAS  |
|-----|-------------     |---------------|
| 1   |0 - (200W -1)     |    8          |
| 2   |200W ~ (400W -1)  |    7          |
| 3   |400W ~ (600W -1)  |    6          |
| 4   |600W ~ (800W -1)  |    5          |
| 5   |800W ~ (1000W -1) |    4          |
| 6   |1000W ~ (1200W -1)|    3          |
| 7   |1200W ~ (1400W -1)|    2          |
|8~22 |1400W ~ (4600W -1)|    1          |
|23~  |4600W ~           |    0          |


[![gas distribution](../../images/blockchain/gas-distribution-en.jpg)](../../images/blockchain/gas-distribution-en.jpg)

### **NEP5 Asset (Token)**

&emsp;&emsp;NEP5 token needs to be issued and managed through smart contract. It's information is stored in smart contract's storage. Account model is used. Detailed inforamtion please refer to `NEP5` part in chapter `Smart Contract`.