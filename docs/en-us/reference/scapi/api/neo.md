# NEO NameSpace

NEO namespace provides APIs for native contracts and verifying digital signature.

**Native API**：
| API                           | Description                         |
| -- | --|
|Neo.Native.Deploy|Deploy and initialize all native contracts|

<br/>

<table>
	<tr>
	    <th>API</th>
	    <th>Method Name</th>
	    <th>Description</th>  
	</tr >
	<tr >
	    <td rowspan="11">Neo.Native.Tokens.NEO</td>
	    <td>name</td>
	    <td>Get token name, ie: NEO</td>
	</tr>
	<tr>
	    <td>symbol</td>
	    <td>Get token symbol, ie: neo</td>
	</tr>
	<tr>
	    <td>decimals</td>
	    <td>Get decimals</td>
	</tr>
	<tr>
	    <td>totalSupply</td>
	    <td>Get the total supply</td>
	</tr>
	<tr>
	    <td>balanceOf</td>
	    <td>Get balance of the token</td>
	</tr>
	<tr>
	    <td>transfer</td>
	    <td>Transfer the token</td>
	</tr>
	<tr>
	    <td>registerValidator</td>
	    <td>Register to be a validator</td>
	</tr>
	<tr>
	    <td>vote</td>
	    <td>Vote for validators</td>
	</tr>
	<tr>
	    <td>getRegisteredValidators</td>
	    <td>Get registered validators</td>
	</tr>
	<tr>
	    <td>getValidators</td>
	    <td>Get validators</td>
	</tr>
	<tr><td>unclaimedGas</td>
	    <td>Get unclaimed Gas</td>
	</tr>
</table>
<br/>

<table>
	<tr>
	    <th>API</th>
	    <th>Method Name</th>
	    <th>Description</th>  
	</tr >
	<tr >
	    <td rowspan="7">Neo.Native.Tokens.GAS</td>
	    <td>name</td>
	    <td>Get token name, ie: GAS</td>
	</tr>
	<tr>
	    <td>symbol</td>
	    <td>Get token symbol, ie: gas</td>
	</tr>
	<tr>
	    <td>decimals</td>
	    <td>Get decimals</td>
	</tr>
	<tr>
	    <td>totalSupply</td>
	    <td>Get the total supply</td>
	</tr>
	<tr>
	    <td>balanceOf</td>
	    <td>Get balance of the token</td>
	</tr>
	<tr>
	    <td>transfer</td>
	    <td>Transfer the token</td>
	</tr>
	<tr>
	 	<td>getSysFeeAmount</td>
	    <td>Get the amount of the system fee</td>
	</tr>
</table>

<br/>

<table>
	<tr>
	    <th>API</th>
	    <th>Method Name</th>
	    <th>Description</th>  
	</tr >
	<tr >
	    <td rowspan="9">Neo.Native.Policy</td>
	    <td>getMaxTransactionsPerBlock</td>
	    <td>Get max transaction number per block</td>
	</tr>
	<tr>
	    <td>getMaxBlockSize</td>
	    <td>Get max block size</td>
	</tr>
	<tr>
	    <td>getFeePerByte</td>
	    <td>Get fee per byte</td>
	</tr>
	<tr>
	    <td>setMaxBlockSize</td>
	    <td>Set the max block size</td>
	</tr>
	<tr><td>getBlockedAccounts</td>
	    <td>Get blocked accounts</td>
	</tr>
    <tr><td>setMaxTransactionsPerBlock</td>
	    <td>Set max transaction per block</td>
	</tr>
    <tr><td>setFeePerByte</td>
	    <td>Set fee per byte</td>
	</tr>
    <tr><td>blockAccount</td>
	    <td>Set blocked accounts</td>
	</tr>
    <tr><td>unblockAccount</td>
	    <td>Unblock accounts</td>
	</tr>
</table>

**Crypto API**：

| API                           | Description                         |
| -- | -- |
| Neo.Crypto.ECDsaVerify            | Verify signature of the current script container by public key                   |
| Neo.Crypto.ECDsaCheckMultiSig       | Verify the multiple signature of the current script container by public key                    |

Note：The source code for the above API can be found under `NEO` in the [src/neo/SmartContract/InteropService.Native.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Native.cs) and [src/neo/SmartContract/InteropService.Crypto.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Crypto.cs).
