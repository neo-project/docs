# Method of accessing TEST NEO and/or TEST GAS

If you are a developer, you can ask for NEO and GAS on the TestNet 

- Fill in the request form (https://www.neo.org/Testnet/Create) specifying your PUBLIC key and EMAIL.
- A day or so later you will receive an email with an Contract Address and a second PUBLIC KEY. 
- Create/Add a multi-sig address in your wallet.
- Select the new address and transfer the assets from the multi-part signed address to your own address.

## STEP 1 - Look up your PUBLIC key
In NEO the address and PUBLIC key are different.  
The PUBLIC KEY is shown when you view the PRIVATE KEY. (Never share your PRIVATE key.)

  ![image](/assets/neo_gas_0.jpg)

## STEP 2 - Fill in the request
Complete the form here: https://www.neo.org/Testnet/Create specifying your EMAIL and PUBLIC key.
After a day or so you will be sent an email containing a "Multi-party signed address" and the PUBLIC key of the sender. See Advanced Features, Multi-party signed address.

## STEP 3 - Create a multi-party signed address
To access the assets, in your neo-gui you will create a "Multi-party signed address" in your wallet using 
- The "Multi-party signed address" (from the email) 
- The PUBLIC KEY of the sender (from the email)
- Your PUBLIC KEY (from STEP 1 above) 

1. From NEO-GUI, right-click on the account area and select `Create Contract Address` -> `Multi-Signature`.

  ![image](/assets/neo_gas_1.jpg)

2. In the public key list, enter the public keys used for signing. (PUB Key of sender and your PUB key) 
3. Specify the minimal number of signatures to be  `1`.
4. Click `confirm`.

The contract address specified in the email is created and displayed in the account page.

![image](/assets/neo_gas_2.jpg)

You will see the quantity of NEO and/or GAS shown beside the Contact address.


## STEP 4 - Transfer the assets to another account

1. Select the `Contact address` by clicking on it.

2. From NEO-GUI menu, select `Transaction` -> `Transfer`

![image](/assets/neo_gas_3.png)

3. Select the Asset and the amount to send and the account you want to transfer the access to. 

