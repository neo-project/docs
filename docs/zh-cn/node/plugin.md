# NEO 客户端插件

从 NEO 2.9.0 开始，一些附加功能被独立封装在插件中用以调用，目的是为了提升节点的安全性，稳定性和灵活性。用户可以自行选取所需要的扩展功能而不用每次在启动 NEO-CLI时通过附加参数来调用，避免了很多人为的失误操作同时简化了打开钱包，调用 API 等一系列繁琐的指令。点击此处下载 [Plugins](https://github.com/neo-project/neo-plugins/releases)。

<table class="table table-hover">
    <thead>
        <tr>
            <th style="width: 25%;">插件</th>
            <th style="width: 35%;">功能</th>
            <th style="width: 20%;">包含 API</th>
            <th style="width: 20%;"></th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/ApplicationLogs.zip">ApplicationLogs</a>
            </td>
            <td>在 RPC 模式下自动同步智能合约日志（ApplicationLogs），目前日志已经改为以 LevelDB 格式存储。</td>
            <td><a href="cli/latest-version/api/getapplicationlog.html">getapplicationlog</a></td>
            <td>交易所必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/CoreMetrics.zip">CoreMetrics</a>
            </td>
            <td>查询历史区块的时间戳。</td>
            <td><a href="cli/latest-version/api/getmetricblocktimestamp.html">getmetricblocktimestamp</a></td>
            <td>交易所推荐使用</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/ImportBlocks.zip">ImportBlocks</a>
            </td>
            <td>同步离线包。</td>
            <td></td>
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcWallet.zip">RpcWallet</a>
            </td>
            <td>提供钱包相关的 RPC 功能。</td>
            <td><a href="cli/latest-version/api/getmetricblocktimestamp.html">claimgas</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">dumpprivkey</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">getbalance</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">getnewaddress</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">getunclaimedgas</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">getwalletheight</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">importprivkey</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">listaddress</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">sendfrom</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">sendmany</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">sendtoaddress</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">invoke</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">invokefunction</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">invokescript</a></td>
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/SimplePolicy.zip">SimplePolicy</a>
            </td>
            <td>过滤非法交易。</td>
            <td></td>
            <td>必选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcSecurity.zip">RpcSecurity</a>
            </td>
            <td>提升 RPC 安全。</td>
            <td></td>
            <td>可选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/RpcSystemAssetTracker.zip">RpcSystemAssetTracker</a>
            </td>
            <td>查询 UTXO 资产相关信息。</td>
            <td><a href="cli/latest-version/api/getmetricblocktimestamp.html">getunclaimed</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">getclaimable</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">getunspents</a></td>
            <td>交易所推荐使用</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/StatesDumper.zip">StatesDumper</a>
            </td>
            <td>导出 NEO-CLI 状态数据。</td>
            <td></td>
            <td>可选</td>
        </tr>
        <tr>
            <td><a
                    href="https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcNep5Tracker.zip">RpcNep5Tracker</a>
            </td>
            <td>提供 NEP-5 余额及交易历史的 RPC 查询功能。</td>
            <td><a href="cli/latest-version/api/getmetricblocktimestamp.html">getnep5balances</a><br><a
                    href="cli/latest-version/api/getmetricblocktimestamp.html">getnep5transfers</a></td>
            <td>交易所推荐使用</td>
        </tr>
    </tbody>
</table>

## 安装插件

要安装插件，在客户端根目录下新建 Plugins 文件夹（注意首字母大写），然后将解压出来的插件拷贝到其中，如下所示在neo-cli根目录下安装：

![plugins.png](../../assets/plugins.png)
