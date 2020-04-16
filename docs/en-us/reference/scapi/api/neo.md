# NEO NameSpace

NEO namespace provides APIs for native contracts and verifying digital signature.

**Native API**：

| API                           | Description                         |
| -- | --|
|Neo.Native.Deploy|Deploys and initializes all native contracts|

<br/>

<table class="table table-hover">
	<tr>
	    <th>API</th>
	    <th>Method Name</th>
	    <th>Description</th>  
	</tr >
	<tr >
	    <td rowspan="11">Neo.Native.Tokens.NEO</td>
	    <td>name</td>
	    <td>Gets token name, ie: NEO</td>
	</tr>
	<tr>
	    <td>symbol</td>
	    <td>Gets token symbol, ie: neo</td>
	</tr>
	<tr>
	    <td>decimals</td>
	    <td>Gets decimals</td>
	</tr>
	<tr>
	    <td>totalSupply</td>
	    <td>Gets the total supply</td>
	</tr>
	<tr>
	    <td>balanceOf</td>
	    <td>Gets balance of the token</td>
	</tr>
	<tr>
	    <td>transfer</td>
	    <td>Transfers the token</td>
	</tr>
	<tr>
	    <td>registerValidator</td>
	    <td>Registers to be a validator</td>
	</tr>
	<tr>
	    <td>vote</td>
	    <td>Votes for validators</td>
	</tr>
	<tr>
	    <td>getRegisteredValidators</td>
	    <td>Gets registered validators</td>
	</tr>
	<tr>
	    <td>getValidators</td>
	    <td>Gets validators</td>
	</tr>
	<tr><td>unclaimedGas</td>
	    <td>Gets unclaimed Gas</td>
	</tr>
</table>

<br/>

<table class="table table-hover">
	<tr>
	    <th>API</th>
	    <th>Method Name</th>
	    <th>Description</th>  
	</tr >
	<tr >
	    <td rowspan="7">Neo.Native.Tokens.GAS</td>
	    <td>name</td>
	    <td>Gets token name, ie: GAS</td>
	</tr>
	<tr>
	    <td>symbol</td>
	    <td>Gets token symbol, ie: gas</td>
	</tr>
	<tr>
	    <td>decimals</td>
	    <td>Gets decimals</td>
	</tr>
	<tr>
	    <td>totalSupply</td>
	    <td>Gets the total supply</td>
	</tr>
	<tr>
	    <td>balanceOf</td>
	    <td>Gets balance of the token</td>
	</tr>
	<tr>
	    <td>transfer</td>
	    <td>Transfers the token</td>
	</tr>
</table>

<br/>

<table class="table table-hover">
	<tr>
	    <th>API</th>
	    <th>Method Name</th>
	    <th>Description</th>  
	</tr >
	<tr >
	    <td rowspan="9">Neo.Native.Policy</td>
	    <td>getMaxTransactionsPerBlock</td>
	    <td>Gets max transaction number per block</td>
	</tr>
	<tr>
	    <td>getMaxBlockSize</td>
	    <td>Gets max block size</td>
	</tr>
	<tr>
	    <td>getFeePerByte</td>
	    <td>Gets fee per byte</td>
	</tr>
	<tr>
	    <td>setMaxBlockSize</td>
	    <td>Sets the max block size</td>
	</tr>
	<tr><td>getBlockedAccounts</td>
	    <td>Gets blocked accounts</td>
	</tr>
    <tr><td>setMaxTransactionsPerBlock</td>
	    <td>Sets max transaction per block</td>
	</tr>
    <tr><td>setFeePerByte</td>
	    <td>Sets fee per byte</td>
	</tr>
    <tr><td>blockAccount</td>
	    <td>Sets blocked accounts</td>
	</tr>
    <tr><td>unblockAccount</td>
	    <td>Unblocks accounts</td>
	</tr>
</table>

**Crypto API**：

| API                           | Description                         |
| -- | -- |
| Neo.Crypto.ECDsaVerify            | Verifies signature of the current script container by public key                 |
| Neo.Crypto.ECDsaCheckMultiSig       | Verifies multiple signatures of the current script container by public key                 |

> [!Note]
>
> The source code for the above API can be found under `NEO` in the [src/neo/SmartContract/InteropService.Native.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Native.cs) and [src/neo/SmartContract/InteropService.Crypto.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Crypto.cs).