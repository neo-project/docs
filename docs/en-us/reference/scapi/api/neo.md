# NEO NameSpace

NEO namespace provides APIs for native contracts and verifying digital signature.

**Native API**：

| API                           | Description                         |
| -- | --|
|Neo.Native.Deploy|Deploys and initializes all native contracts|
|Neo.Native.Call|Invokes native contracts|

<br/>

<table class="table table-hover">
	<tr>
	    <th>API</th>
	    <th>Method Name</th>
	    <th>Description</th>  
	</tr >
	<tr >
	    <td rowspan="15">Neo.Native.Tokens.NEO</td>
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
	    <td>SetGasPerBlock</td>
	    <td>Sets the number of GAS generated for each block</td>
	</tr>
	<tr>
	    <td>GetGasPerBlock</td>
	    <td>Gets the number of GAS generated for each block</td>
	</tr>
	<tr>
	    <td>RegisterCandidate</td>
	    <td>Registers as a candidate</td>
	</tr>
	<tr>
	    <td>UnregisterCandidate</td>
	    <td>Unregisters as a candidate</td>
	</tr>
	<tr>
	    <td>vote</td>
	    <td>Vote</td>
	</tr>
	<tr>
	    <td>GetCandidates</td>
	    <td>Gets a list of candidates</td>
	</tr>
	<tr>
	    <td>GetCommittee</td>
	    <td>Gets a list of committee members</td>
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
	    <td rowspan="11">Neo.Native.Policy</td>
	    <td>getMaxTransactionsPerBlock</td>
	    <td>Gets max transaction number per block</td>
	</tr>
	<tr>
	    <td>getMaxBlockSize</td>
	    <td>Gets max block size</td>
	</tr>
    	<tr>
	    <td>GetMaxBlockSystemFee</td>
	    <td>Gets the maximum system fee for the block</td>
	</tr>
	<tr>
	    <td>getFeePerByte</td>
	    <td>Gets fee per byte</td>
	</tr>
   	<tr>
		<td>IsBlocked</td>
	    <td>Verifies whether the account is blocked</td>
	</tr>
	<tr>
	    <td>setMaxBlockSize</td>
	    <td>Sets the max block size</td>
	</tr>
	<tr>
		<td>SetMaxBlockSystemFee</td>
	    <td>Sets the maximum system fee for the block</td>
    </tr>
    <tr><td>setMaxTransactionsPerBlock</td>
	    <td>Sets max transaction per block</td>
	</tr>
    <tr><td>setFeePerByte</td>
	    <td>Sets fee per byte</td>
	</tr>
    <tr>
		<td>BlockAccount</td>
	    <td>Sets blocked accounts</td>
	</tr>
    <tr>
		<td>UnblockAccount</td>
	    <td>Unblocks accounts</td>
	</tr>
</table>

<table class="table table-hover">
	<tr>
	    <th>API</th>
	    <th>Method Name</th>
	    <th>Description</th>  
	</tr >
	<tr >
	    <td rowspan="3">Neo.Native.Oracle</td>
	    <td>Finish</td>
	    <td>Invokes the callback function after getting the Oracle response</td>
	</tr>
	<tr>
	    <td>Request</td>
	    <td>Initiates an Oracle request</td>
	</tr>
	<tr>
	    <td>Verify</td>
	    <td>Verifies if the Oracle response transaction is legal</td>
	</tr>
</table>


> [!Note]
>
> The above API are used for committee members only; ordinary users will fail during the signature verification process.
>
> The source code for the above API can be found under `NEO` in the  (https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/Native/PolicyContract.cs).

**Crypto API**：

| API                           | Description                         |
| -- | -- |
| Neo.Crypto.ECDsaVerify            | Verifies signature of the current script container by public key                 |
| Neo.Crypto.ECDsaCheckMultiSig       | Verifies multiple signatures of the current script container by public key                 |

> [!Note]
>
> The source code for the above API can be found under `NEO` in the [src/neo/SmartContract/InteropService.Native.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Native.cs) and [src/neo/SmartContract/InteropService.Crypto.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Crypto.cs).