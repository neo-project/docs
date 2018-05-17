# Smart Contract Triggers

A smart contract trigger is a mechanism that triggers the execution of smart contracts. There are four triggers introduced in the NEO smart contract，`Verification`, `Application`， `VerificationR`, and `ApplicationR`.

### Verification

A validation trigger is used to call the contract as a verification function, which can accept multiple parameters and should return a valid Boolean value, indicating the validity of the transaction or block. 

When you transfer assets from account A to account B, a verification contract is triggered. All the nodes that received the transaction (including normal nodes and blue consensus nodes) verify account A's contract. If the return value is true, the transfer is completed successfully. If false is returned, the transfer is failed.

If the execution of the verification contract is failed, the transaction will not be recorded in the blockchain.

The following is a code sample of a simple verification contract. When condition A is met, it returns true, indicating the transfer is successful. Otherwise, it returns false, indicating the transfer is failed.

```c#
public static bool Main(byte[] signature)
{
    if (/*condition A*/)
        return true;
    else
        return false;
}
```
Based on the above code, the following code adds a condition to determine the running trigger type. Only when the trigger is a verification trigger, the  verification part of the code is executed. This is useful for complex smart contracts. If a smart contract implements multiple triggers, the trigger should be evaluated in the Main method.


```c#
public static bool Main(byte[] signature)
{
    if (Runtime.Trigger == TriggerType.Verification)
    {
        if (/*condition A*/)
                return true;
            else
                return false;
    }  
}
```

### Application 

An application trigger is used to invoke the contract as a verification function, which can accept multiple parameters, change the blockchain status, and return values of any type. 

Theoretically, smart contracts can have any entry points, but we recommend you use the main function as the entry point of smart contracts for easier invocation.

```c#
public static Object Main(string operation, params object[] args) 
```

The following is a simple contract using an application trigger. 

```c#
public static Object Main(string operation, params object[] args)
{
    if (Runtime.Trigger == TriggerType.Application)
    {
        if (operation == "FunctionA") return FunctionA(args);
        if (operation == "FunctionB") return FunctionB(args);
        if (operation == "FunctionC") return FunctionC(args);
    }  
}
public static bool FunctionA(params object[] args)
{
    //some code  
}
public static BigInteger FunctionB(params object[] args)
{
    //some code  
}
public static byte[] FunctionC(params object[] args)
{
    //some code  
}
```

Unlike the verification trigger which is triggered by a transfer, an application trigger is triggered by a special transaction  `InvocationTransaction`. If the application (Web/App) calls a smart contract, an `InvocationTransaction` is constructed, and then signed and broadcast in the program. After the `InvocationTransaction` transaction is confirmed, the smart contract is executed by the consensus node. The common node does not execute the smart contract when forwarding the transaction.

Since the application contract is executed after  `InvocationTransaction` is confirmed, the transaction is recorded in the blockchain no matter the execution of the application contract is successful or not.  

The success and failure of InvocationTransaction is not necessarily related to the success or failure of execution of smart contracts.

### VerificationR

To be added. For information about VerificationR, refer to [here](https://github.com/neo-project/proposals/blob/597f0dc53a80bbedb14974c8168f8df288c1d82e/nep-7.mediawiki) .

### ApplicationR

To be added. For information about ApplicationR, refer to [here](https://github.com/neo-project/proposals/blob/597f0dc53a80bbedb14974c8168f8df288c1d82e/nep-7.mediawiki) .

### Multiple triggers in a smart contract

A smart contract can contain multiple triggers to accommodate different contexts. The following code contains both a Verification trigger and an Application trigger.

```c#
public static Object Main(string operation, params object[] args)
{
    if (Runtime.Trigger == TriggerType.Verification)
    {
        if (/*condition A*/)
                return true;
            else
                return false;
    }  
    if (Runtime.Trigger == TriggerType.Application)
    {
        if (operation == "FunctionA") return FunctionA(args);
    }  
}

public static bool FunctionA(params object[] args)
{
    //some code  
}
```

### Triggers comparison

The following is a comparison of these smart contract triggers.

|                    | Verification                                                 | Application                                                  | VerificationR                                                | ApplicationR                                                 |
| ------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Name               | Verification trigger                                         | Application trigger                                          | TBD                                                          | TBD                                                          |
| Status             | Development completed                                        | Development completed                                        | Development completed                                        | Development completed                                        |
| Trigger method     | Triggered when sending a transfer                            | Triggered when sending InvocationTransaction                 | Triggered when receiving a transfer                          | Triggered when receiving a transfer                          |
| Contract execution | Executes the smart contract first and then confirms the transaction | Confirms the transaction first and then executes the smart contract | Executes the smart contract first and then confirms the transaction | Confirms the transaction first and then executes the smart contract |
| Return value       | Boolean                                                      | Any                                                          | Boolean                                                      | Any                                                          |
| Contract storage   | Read only                                                    | Read and Write                                               | Read only                                                    | Read and Write                                               |

