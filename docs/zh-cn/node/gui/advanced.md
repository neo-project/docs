# 选举与投票

使用 Neo-GUI 可以报名成为共识节点的候选人，也可以对候选节点进行投票。Neo 共识节点将通过 dBFT 算法达成共识，生成新的区块。投票在 Neo 网络实时持续进行，其流程大致为：

1. 报名成为候选人
2. NEO 持有者对候选人进行投票
3. 根据投票数和候选人数计算选出共识节点

## 报名成为候选人

成为候选人后就可以根据投票数竞选成为共识节点。报名成为候选人需要花费一定的 GAS。

要成为候选人：

1. 在 Neo-GUI 主页面中点击`高级`-> `选举`。
2. 选择参加选举的地址公钥，点击 `确定`。

可以使用 API [getvalidators](../../reference/rpc/latest-version/api/getvalidators.html) 查看是否成功成为候选人，候选人公钥会显示在该 API 的响应正文中 （publickey）：

![](../assets/getvalidator1.png)

也可以在官网的 [共识节点页面](https://neo.org/consensus) 查看现有的共识节点和候选节点。

## 投票

每个 Neo 节点都可以对候选人进行投票，当前投票账户中的 NEO 数量会自动计算为所投候选人的票数。 例如当前账户有 100 个 NEO，从该账户投票给候选人后，候选人得到 100 票。投票后如果花费了该账户的 NEO，则候选人的票数也将实时更改为当前账户 NEO 余额数。

要进行投票：

1. 在 Neo-GUI 主页面中点击 `高级`->`投票`
2. 选择自己的地址
3. 在候选人框内输入要投票的候选人公钥
4. 确认投票

投票成功后可以使用 API [getvalidators](../../reference/rpc/latest-version/api/getvalidators.html) 查看候选人票数。如下图所示，从余额为 100000000 的账户投票给候选人（公钥 03076fc0ee6c6ccf3fb0c9b3ff9d0e3d9ba7ef97e54c77240991ec1dffa295503b）， 通过 API getvalidators 可以查看到返回的响应正文中显示出该公钥与对应的的票数。

![](../assets/getvalidator2.png)

也可以在官网的 [共识节点页面](https://neo.org/consensus) 查看现有的共识节点和候选节点的票数。

