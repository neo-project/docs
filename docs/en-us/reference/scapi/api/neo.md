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
	    <td>设置每出一个区块所产生的GAS数</td>
	</tr>
	<tr>
	    <td>GetGasPerBlock</td>
	    <td>获取当前每个区块可产生的GAS数</td>
	</tr>
	<tr>
	    <td>RegisterCandidate</td>
	    <td>注册为候选人</td>
	</tr>
	<tr>
	    <td>UnregisterCandidate</td>
	    <td>取消注册为候选人</td>
	</tr>
	<tr>
	    <td>vote</td>
	    <td>Vote</td>
	</tr>
	<tr>
	    <td>GetCandidates</td>
	    <td>获取候选人列表</td>
	</tr>
	<tr>
	    <td>GetCommittee</td>
	    <td>获取委员会成员列表</td>
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
	    <td>获取区块最大的系统费</td>
	</tr>
	<tr>
	    <td>getFeePerByte</td>
	    <td>Gets fee per byte</td>
	</tr>
   	<tr>
		<td>IsBlocked</td>
	    <td>验证是否为黑名单账户</td>
	</tr>
	<tr>
	    <td>setMaxBlockSize</td>
	    <td>Sets the max block size</td>
	</tr>
	<tr>
		<td>SetMaxBlockSystemFee</td>
	    <td>设置区块最大的系统费</td>
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
	    <th>方法名</th>
	    <th>说明</th>  
	</tr >
	<tr >
	    <td rowspan="3">Neo.Native.Oracle</td>
	    <td>Finish</td>
	    <td>在获取Oracle响应后调用回调函数</td>
	</tr>
	<tr>
	    <td>Request</td>
	    <td>发起Oracle请求</td>
	</tr>
	<tr>
	    <td>Verify</td>
	    <td>验证Oracle响应交易的合法性</td>
	</tr>
</table>

> [!Note]
>
> 以上 API 部分用于给Committee调用, 普通用户会在验签过程中失败
> 以上 API 的源码位于 NEO 项目中的 (https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/Native/PolicyContract.cs) 文件。

**Crypto API**：

| API                           | Description                         |
| -- | -- |
| Neo.Crypto.ECDsaVerify            | Verifies signature of the current script container by public key                 |
| Neo.Crypto.ECDsaCheckMultiSig       | Verifies multiple signatures of the current script container by public key                 |

> [!Note]
>
> The source code for the above API can be found under `NEO` in the [src/neo/SmartContract/InteropService.Native.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Native.cs) and [src/neo/SmartContract/InteropService.Crypto.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Crypto.cs).