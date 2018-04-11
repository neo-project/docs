# 使用参数部署智能合约

## 1 - 介绍
本教程旨在介绍如何用图形用户界面在NEO区块链上来部署和调用智能合约。本教程是通用的，适用于包括NEP5代币在内的所有合同类型。本教程假定合同已经被编译成一个.avm文件。 如果没有，请首先参考其他教程。合同的编译版本和本教程中使用的源代码都已经提供，供参考。
## 2 - 实用的资源

本教程使用以下资源，在开发智能合约时可使用的有效参考资料：
1. [Lock2](Lock2.md)
2. [参数](Parameter.md)
3. [Woolong NEP5 智能合约](assets/examples/woolong.cs.md)
4. [开发人员 GUI](https://github.com/CityOfZion/neo-gui-developer)
5. [Neo API](../api/neo.md)
6. [NEP5 代币标准](https://github.com/neo-project/proposals/pull/4)

## 3 - SC 代码
本文档将使用Woolong示例中提供的示例代码来完成本教程。为了增加趣味性，这个合同将为每个invoke事件生成1个Woolong。

该示例已部署在testnet上，可以通过以下脚本哈希访问： 
​    
	dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f
​	

## 4 - 使用参数部署智能合约

1. 区块链运用中 (.avm)部署智能合约 , 在NEO桌面钱包菜单上点击 **Advanced** 并选择 **Deploy Contract**.  在开发合同中，我们推荐使用NEO开发GUI。

<p align="center"><img style="vertical-align: middle" src="assets/img/deploy.png" width="500"></p>

2.在 **Information** （信息）区域所有出现的窗口填充所有的字段.  必须填写所有字段才能部署合同.
3. 点击 **Load** 按钮加载.avm文件.  此 **code field** 将被脚本哈希填充.  复制的内容 **Code** 字段供以后使用。
4. 填充 **Metadata** 字段引用 [参数](Parameter.md) 文件.

    **Woolong示例标记被定义为:**  

    ```csharp
    public static object Main(string method, params object[] args)  
    ```

   所以这里运用:  
    * **Parameter List:** 0710
    * **Return Type:** 05

5. 如果合同需要存储 (运用[Read/Write API](../api/neo.md#readwrite-api)), 检查 **Need Storage** 盒子.  NEP5标准使用存储目的是来维护帐户，因此请确保在部署NEP5代币时此标准已经被检查妥当。

6. 点击 **Deploy** 键.


## 5 - 查看智能合约   

1. 在主NEO钱包窗口上, 右键单击地址区域并选择 (Create Contract Add > Custom)
2. 从 **Related Account** 下面部分选择您想要与合约关联的账户
3. 在 **Parameter List** 区域, 填充 **Parameter List** 在步骤4中使用的值 **Deploy Smart Contract w/ Parameters** 区域.
4. 填充 **Script** 字段中提供了第3步中提供的值**Deploy Smart Contract w/ Parameters**.
5. 点击 **Confirm** 将合约加载到钱包窗口中.


## 6 - 调用智能合约

要在NEO区块链上调用智能合约，您将需要智能合约脚本哈希。
1. 为了获得合同哈希,右键单击地址窗口中填写的合同帐户 **Watching the Smart Contract** 窗口.
2. 选择 **View Contract** 打开一个包含智能合约信息的窗口。  复制 **Script Hash** 区域的值.
3. 点击 **Advanced** 菜单选项并选择**Invoke Contract**.
4. 用 **Script Hash** 填充字段与在步骤中复制的值 2.  举个例子, 你可以在**Section 3**中使用脚本哈希来调用Woolong 。
5. 智能合约信息应该自动填入剩余的 **Invoke Function** 区域.
6. 填充输入参数, 点击 **...** 按钮旁边的参数字段打开参数填充菜单。
7. 选择左侧字段的参数，并在右下角字段填入变量值。

  **例如，调用以下内容:**
  * `6e616d65` 当调用 Woolong, 将返回 'Woolong'.
    ```csharp
    if (method == "name") return name;
    ```
  * `73796d626f6c` 将返回 'WNG'.
    ```csharp
     if (method == "symbol") return symbol;
    ```
  * `62616c616e63654f66, 5fe459481de7b82f0636542ffe5445072f9357a1261515d6d3173c07c762743b` 将返回测试网络上的Woolong当前余额。
    ```csharp
    if (method == "balanceOf") return Storage.Get(Storage.CurrentContext, (byte[]) args[0]);
    ```

8. 点击 **OK** 关闭参数输入窗口。
9. 点击 **Invoke** 键调用智能合约。

**提示:** 当前的标准桌面GUI不支持查看返回。  建议在执行事件时使用开发人员GUI。

 
