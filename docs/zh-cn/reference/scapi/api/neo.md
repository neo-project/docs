# NEO 命名空间

NEO命名空间提供了原生合约操作以及数字签名验证的API。

**Native API**：

| API                           | 说明                         |
| -- | --|
|Neo.Native.Deploy|部署并初始化所有原生合约|
|Neo.Native.Call|调用原生合约|

<br/>

<table class="table table-hover">
	<tr>
	    <th>API</th>
	    <th>方法名</th>
	    <th>说明</th>  
	</tr >
	<tr >
	    <td rowspan="15">Neo.Native.Tokens.NEO</td>
	    <td>name</td>
	    <td>获取名称, 即：NEO</td>
	</tr>
    <tr>
	    <td>symbol</td>
	    <td>获取符号, 即: neo</td>
	</tr>
	<tr>
	    <td>decimals</td>
	    <td>获取精度</td>
	</tr>
	<tr>
	    <td>TotalSupply</td>
	    <td>获取总发行量</td>
	</tr>
	<tr>
	    <td>BalanceOf</td>
	    <td>获取余额</td>
	</tr>
	<tr>
	    <td>Transfer</td>
	    <td>转账</td>
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
	    <td>Vote</td>
	    <td>投票</td>
	</tr>
	<tr>
	    <td>GetCandidates</td>
	    <td>获取候选人列表</td>
	</tr>
	<tr>
	    <td>GetCommittee</td>
	    <td>获取委员会成员列表</td>
	</tr>
	<tr>
	    <td>UnclaimedGas</td>
	    <td>获取未领取的Gas数</td>
	</tr>
	<tr>
	    <td>GetNextBlockValidators</td>
	    <td>获取下个区块的验证人列表</td>
	</tr>
</table>

<br/>

<table class="table table-hover">
	<tr>
	    <th>API</th>
	    <th>方法名</th>
	    <th>说明</th>  
	</tr >
	<tr >
	    <td rowspan="7">Neo.Native.Tokens.GAS</td>
	     <td>name</td>
	    <td>获取名称, GAS</td>
	</tr>
    <tr>
	    <td>symbol</td>
	    <td>获取符号, 即: gas</td>
	</tr>
	<tr>
	    <td>decimals</td>
	    <td>获取精度</td>
	</tr>
	<tr>
	    <td>TotalSupply</td>
	    <td>获取总发行量</td>
	</tr>
	<tr>
	    <td>BalanceOf</td>
	    <td>获取余额</td>
	</tr>
	<tr>
	    <td>Transfer</td>
	    <td>转账</td>
	</tr>
</table>

<br/>

<table class="table table-hover">
	<tr>
	    <th>API</th>
	    <th>方法名</th>
	    <th>说明</th>  
	</tr >
	<tr >
	    <td rowspan="11">Neo.Native.Policy</td>
	    <td>GetMaxTransactionsPerBlock</td>
	    <td>获取每区块最大交易数</td>
	</tr>
	<tr>
	    <td>GetMaxBlockSize</td>
	    <td>获取最大的区块大小</td>
	</tr>
	<tr>
	    <td>GetMaxBlockSystemFee</td>
	    <td>获取区块最大的系统费</td>
	</tr>
	<tr>
	    <td>GetFeePerByte</td>
	    <td>获取每字节手续费</td>
	</tr>
	<tr>
		<td>IsBlocked</td>
	    <td>验证是否为黑名单账户</td>
	</tr>
	<tr>
	    <td>setMaxBlockSize</td>
	    <td>设置最大的区块大小</td>
	</tr>
	<tr>
		<td>SetMaxBlockSystemFee</td>
	    <td>设置区块最大的系统费</td>
	</tr>
    <tr><td>SetMaxTransactionsPerBlock</td>
	    <td>设置每区块最大交易数</td>
	</tr>
    <tr><td>SetFeePerByte</td>
	    <td>设置每字节手续费</td>
	</tr>
    <tr>
		<td>BlockAccount</td>
	    <td>设置黑名单账户</td>
	</tr>
    <tr>
		<td>UnblockAccount</td>
	    <td>解除黑名单账户</td>
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

| API                           | 说明                         |
| -- | -- |
| Neo.Crypto.ECDsaVerify            | 根据公钥，验证当前脚本容器的签名                   |
| Neo.Crypto.ECDsaCheckMultiSig       | 根据公钥，验证当前脚本容器的多个签名                    |

> [!Note]
>
> 以上 API 的源码位于 NEO 项目中的 [src/neo/SmartContract/InteropService.Native.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Native.cs) 和 [src/neo/SmartContract/InteropService.Crypto.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Crypto.cs) 文件。
