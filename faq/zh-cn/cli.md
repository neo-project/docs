# Neo-CLI

## 为什么我编译的neo-cli启动时报错: System.Collections.Generic.KeyNotFoundException. The given key 'LevelDBStore' was not present in the dictionary.

这是因为Neo-CLI的config文件中默认使用LevelDBStore插件来存储区块数据，需安装LevelDBStore插件。

## 为什么我编译的neo-cli和RpcServer插件，启动时报错：Unhandled exception. System.IO.FileNotFoundException: Could not load file or assembly  Microsoft.AspNetCore.ResponseCompression, Version=2.2.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'.

编译neo-cli时需要添加以下引用，生成Microsoft.AspNetCore.ResponseCompression.dll文件：

```
<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.ResponseCompression" />
</ItemGroup>
```

## 为什么在同一台机器上启动第二个节点时报错: Unhandled exception. System.IO.IOException: Failed to bind to address xxx: address already in use.

检查两个节点各自根目录下的config文件和RpcServer插件的config文件，端口设置是否有冲突。

## 为什么调用RPC接口openwallet时返回Access denied

在RpcServer插件的config文件中，默认禁用了openwallet方法，若需要允许远程调用，请在保证安全的前提下，从DisableMethods中将该方法删除。