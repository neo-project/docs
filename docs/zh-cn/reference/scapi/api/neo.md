# NEO 命名空间

NEO命名空间提供了原生合约操作以及数字签名验证的API。

**Native API**：

| API                           | 说明                         |
| -- | --|
|Neo.Native.Deploy|部署并初始化所有原生合约|

<br/>

<table class="table table-hover">
	<tr>
	    <th>API</th>
	    <th>方法名</th>
	    <th>说明</th>  
	</tr >
	<tr >
	    <td rowspan="12">Neo.Native.Tokens.NEO</td>
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
	    <td>RegisterValidator</td>
	    <td>注册为验证人</td>
	</tr>
	<tr>
	    <td>Vote</td>
	    <td>投票</td>
	</tr>
	<tr>
	    <td>GetRegisteredValidators</td>
	    <td>获取已注册的验证人列表</td>
	</tr>
	<tr>
	    <td>GetValidators</td>
	    <td>获取验证人列表</td>
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
	    <td rowspan="9">Neo.Native.Policy</td>
	    <td>GetMaxTransactionsPerBlock</td>
	    <td>获取每区块最大交易数</td>
	</tr>
	<tr>
	    <td>GetMaxBlockSize</td>
	    <td>获取最大的区块大小</td>
	</tr>
	<tr>
	    <td>GetFeePerByte</td>
	    <td>获取每字节手续费</td>
	</tr>
	<tr>
	    <td>setMaxBlockSize</td>
	    <td>设置最大的区块大小</td>
	</tr>
	<tr><td>GetBlockedAccounts</td>
	    <td>获取黑名单账户</td>
	</tr>
    <tr><td>SetMaxTransactionsPerBlock</td>
	    <td>设置每区块最大交易数</td>
	</tr>
    <tr><td>SetFeePerByte</td>
	    <td>设置每字节手续费</td>
	</tr>
    <tr><td>BlockAccount</td>
	    <td>设置黑名单账户</td>
	</tr>
    <tr><td>UnblockAccount</td>
	    <td>解除黑名单账户</td>
	</tr>
</table>

> [!Note]
> 以上 API 部分用于给Validator调用, 普通用户会在验签过程中失败
> 以上 API 的源码位于 NEO 项目中的 (https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/Native/PolicyContract.cs) 文件。

**Crypto API**：

| API                           | 说明                         |
| -- | -- |
| Neo.Crypto.ECDsaVerify            | 根据公钥，验证当前脚本容器的签名                   |
| Neo.Crypto.ECDsaCheckMultiSig       | 根据公钥，验证当前脚本容器的多个签名                    |

> [!Note]
>
> 以上 API 的源码位于 NEO 项目中的 [src/neo/SmartContract/InteropService.Native.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Native.cs) 和 [src/neo/SmartContract/InteropService.Crypto.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Crypto.cs) 文件。
