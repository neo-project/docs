# Neo-CLI

## When I start the neo-cli compiled by myself, it reports an error: System.Collections.Generic.KeyNotFoundException. The given key 'LevelDBStore' was not present in the dictionary.

You need to install the plugin LevelDBStore, as it is defined in the Neo-CLI config file by default for storing the block data.

## When I start the neo-cli and RpcServer compiled by myself, they report an error: Unhandled exception. System.IO.FileNotFoundException: Could not load file or assembly  Microsoft.AspNetCore.ResponseCompression, Version=2.2.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'.

To solve this issue, add the following reference to generate the Microsoft.AspNetCore.ResponseCompression.dll file before you compile neo-cli:

```
<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.ResponseCompression" />
</ItemGroup>
```

## When I start the second node on the same computer, it reports an error: Unhandled exception. System.IO.IOException: Failed to bind to address xxx: address already in use. 

There is port conflicting. Check the config files of the two nodes and the config files of their RpcServer plug-in, and make sure all ports are set different. 

## When I invoke the RPC API openwallet, it returns an error: Access denied

The openwallet is disabled in the RpcServer config file by default for security reasons. If you need to invoke it remotely,  remove the method from the DisableMethods field under the secure conditions.