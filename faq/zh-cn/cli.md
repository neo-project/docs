# Neo-CLI

## 为什么我编译的 neo-cli 启动时报错: System.Collections.Generic.KeyNotFoundException. The given key 'LevelDBStore' was not present in the dictionary.

这是因为 Neo-CLI 的 config 文件中配置了默认使用 LevelDBStore 插件来存储区块数据，需安装 LevelDBStore 插件。

## 为什么我编译的 neo-cli 和 RpcServer 插件，启动时报错：Unhandled exception. System.IO.FileNotFoundException: Could not load file or assembly  Microsoft.AspNetCore.ResponseCompression, Version=2.2.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'.

编译 neo-cli 时需要添加以下引用，生成 Microsoft.AspNetCore.ResponseCompression.dll 文件：

```
<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.ResponseCompression" />
</ItemGroup>
```

## 为什么在同一台机器上启动第二个节点时报错: Unhandled exception. System.IO.IOException: Failed to bind to address xxx: address already in use.

检查两个节点各自根目录下的 config 文件和 RpcServer 插件的 config 文件，端口设置是否有冲突。

## 为什么调用RPC接口openwallet时返回Access denied

在 RpcServer 插件的 config 文件中，默认禁用了openwallet 方法，若需要允许远程调用，请在保证安全的前提下，从 DisableMethods 中将该方法删除。