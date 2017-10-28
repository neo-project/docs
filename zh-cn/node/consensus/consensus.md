# 共识机制

## 1 - 术语说明

* **权益证明** `PoS` 一种利用网络协商一致来处理容错的算法。

* **工作量证明** `PoW` 一种利用计算能力来处理容错的算法。

* **拜占庭错误** `BF` 一个节点保持功能，但以不诚实甚至是恶意的方式来工作。

* **dBFT（一种改进的拜占庭容错算法）** `dBFT` NEO区块链中的共识算法，该算法通过多个共识节点的协商来达成共识，有良好的可用性和最终性。

* **视图** `V` 在dBFT算法中，一次共识从开始到结束所使用的数据集合，称为视图。

## 2 - 规则
**在NEO的共识算法中，共识节点由NEO持有人股票选出，并对区块链中交易的有效性进行验证。过去这些节点被称作“记账人”，现在他们被称作“共识节点”**

  - <img style="vertical-align: middle" src="/assets/nNode.png" width="25"> **共识节点** —— 此节点参与共识行为。 在共识行为中, 共识节点轮流担任以下两个角色：
  - <img style="vertical-align: middle" src="/assets/speakerNode.png" width="25"> **议长** `（一人）` —— **议长** 负责向系统发送一个新的区块的提案。
  - <img style="vertical-align: middle" src="/assets/cNode.png" width="25"> **议员** `（多人）` —— **议员** 负责对议长的提案进行投票，大于等于2/3的议员投票时，提案通过。


## 3 - 介绍

众多区块链共识算法的根本区别是他们如何保障对系统中的故障节点、恶意节点的容错能力。

传统的 PoW 方法可以提供这种容错能力，只要网络的大多数算力是诚实的。                                                         

然而，由于这种模式依赖于大量的计算，这种机制可能会非常低效且不环保（算力消耗能源，需要硬件）。 这些依赖就是 PoW 方法的限制所在，最主要的就是扩展的成本。

NEO实现了一种委托的拜占庭容错共识算法，它借鉴了一些 PoS 的特点（NEO持有人需要对共识节点进行投票） 利用最小的资源来保障网络免受拜占庭故障的影响，同时也弥补了 PoS 的一些问题。该解决方案解决了与当前块链实现相关的性能和可扩展性问题，而不会对容错产生重大影响。



## 4 - 理论

拜占庭位于如今的土耳其的伊斯坦布尔，是东罗马帝国的首都。由于当时拜占庭罗马帝国国土辽阔，为了防御目的，因此每个军队都分隔很远，将军与将军之间只能靠信差传消息。 在战争的时候，拜占庭军队内所有将军和副官必需达成一致的共识，决定是否有赢的机会才去攻打敌人的阵营。但是，在军队内有可能存有叛徒和敌军的间谍，左右将军们的决定又扰乱整体军队的秩序。在进行共识时，结果并不代表大多数人的意见。这时候，在已知有成员谋反的情况下，其余忠诚的将军在不受叛徒的影响下如何达成一致的协议，拜占庭问题就此形成。

为了描述 DBFT 的工作原理，我们将本节重点放在第 5 部分中的证明 66.66％ 的共识率的正确性。请记住，不诚实的节点不需要主动恶意，因为它根本不可能是按预期运作。

为了讨论，我们将描述一些情景。 在这些简单的例子中，我们假设每个节点沿着从 **议长** 发送过来的消息发送。 此技工也用于DBFT，对系统至关重要。 我们将仅描述功能系统与功能失效系统之间的区别。 有关更详细的说明，请参阅参考资料。


### **诚实的议长**

  <p align="center"><img src="/assets/n3.png" width="300"><br>

 <b>图 1：</b> 一个 n = 3 的例子中存在一个不诚实的 <b>议员</b>。</p>

在图 1 中，我们有一个诚实的 **议员** (50%)。两个 **议员** 从 **议长**  那里收到相同的消息，然而，由于其中一个 **文员** 不是诚实的，诚实的议员只能确定有不诚实的节点，但无法识别它是 **议长** 还是 **议员**。因为 **议员** 必须弃票，改变视图。

  <p align="center"><img src="/assets/n4.png" width="400"><br>

 <b>图 2：</b> 一个 n =4 的例子中存在一个不诚实的 <b>议员</b>。</p>

在图 2 中，我们有两个诚实的 **议员** (66%)。所有的 **议员** 从 **议长**  那里收到相同的消息，然后向其它 **议员** 发送消息和自己的验证结果。根据两位诚实 **议员** 的共识，我们可以确定 **议长** 或者右边的 **议员** 在系统中是不诚实的。



### **不诚实的议长** 

  <p align="center"><img src="/assets/g3.png" width="300"><br> 

 <b>图 3：</b> 一个 n = 3 的例子中存在一个不诚实的 <b>议长</b>。</p>

在图 3 中，不诚实的是  **议长**，这和图 1 中描述的案例有同样的结论。**议员** 无法确定哪个节点是不诚实的。

  <p align="center"><img src="/assets/g4.png" width="400"><br> 

 <b>图 4：</b> 一个 n = 4 的例子中存在一个不诚实的 <b>议长</b>。</p>

在图 4 所示的例子中，中间的节点和右边的节点接收的区块不可验证， This causes them to defer for a new view which elects a new **Speaker** because they carry a 66% majority.  In this example, if the dishonest **Speaker** had sent honest data to two of the three **Congressmen**, it would have been validated without the need for a view change.


## 5 - 实际实施

The practical implementation of DBFT in NEO uses an iterative consensus method to guarantee that consensus is reached.  The performance of the algorithm is dependent on the fraction of honest nodes in the system.**Figure 5** depicts the
expected iterations as a function of the fraction of dishonest nodes.  

Note that the **Figure 5** does not extend below 66.66% **Consensus Node** honesty.  Between this critical point and 33% **Consensus Node** honesty, there is a 'No-Man's Land' where a consensus is unattainable.  Below 33.33% **Consensus Node** honesty, dishonest nodes (assuming they are aligned in consensus) are able to reach a consensus themselves and become the new point of truth in the system.


<img src="/assets/consensus.iterations.png" width="800">

**Figure 5:** Monto-Carlo Simulation of the DBFT algorithm depicting the iterations required to reach consensus. {100 Nodes; 100,000 Simulated Blocks with random honest node selection}


### 5.1 - 定义

**Within the algorithm, we define the following:**

  - `t`: The amount of time allocated for block generation, measured in seconds.
    - Currently: `t = 15 seconds`
    - This value can be used to roughly approximate the duration of a single view iteration as the consensus activity and communication events are fast relative to this time constant.

  - `n`: The number of active **Consensus Nodes**.

  - `f`: The minimum threshold of faulty **Consensus Nodes** within the system. 
     - `f = (n - 1) / 3`

  - `h` : The current block height during consensus activity.

  - `i` : **Consensus Node** index.


  - `v` : The view of a **Consensus Node**.  The view contains the aggregated information the node has received during a round of consensus.  This includes the vote (`prepareResponse` or `ChangeView`) issued by all congressmen.


  - `k` : The index of the view `v`.  A consensus activity can require multiple rounds.  On consensus failure, `k` is incremented and a new round of consensus begins.


  - `p` : Index of the **Consensus Node** elected as the **Speaker**.  This calculation mechanism for this index rotates through **Consensus Nodes** to prevent a single node from acting as a dicator within the system. 
     - `p = (h - k) mod (n)`


  - `s`: The safe consensus threshold.  Below this threshold, the network is exposed to fault.  
     - `s = ((n - 1) - f)`


### 5.2 - 要求

**Within NEO, there are three primary requirements for consensus fault tolerance:**

1. `s` **Congressmen** must reach a consensus about a transaction before a block can be committed.

2. Dishonest **Consensus Nodes** must not be able to persuade the honest consensus nodes of faulty transactions. 

3. At least `s` **Congressmen** are in same state (`h`,`k`) to begin a consensus activity



### 5.3 - 算法
**The algorithm works as follows:**

1. A **Consensus Node** broadcasts a transaction to the entire network with the sender's signatures.

   <p align="center"><img src="/assets/consensus1.png" width="450"><br> <b>Figure 6:</b> A <b>Consensus Node</b> receives a transaction and broadcasts it to the system. </p>

2. **Consensus Nodes** log transaction data into local memory.

3. The first view `v` of the consensus activity is initialized.

4. The **Speaker** is identified.

   <p align="center"><img src="/assets/consensus2.png" width="450"><br> <b>Figure 7:</b> A <b>Speaker</b> has been identified and the view has been set. </p>

  **Wait** `t` seconds
​	
5. The **Speaker** broadcasts the proposal :
    <!-- -->
        <prepareRequest, h, k, p, bloc, [block]sigp>

     <p align="center"><img src="/assets/consensus3.png" width="450"><br> <b>Figure 8:</b> The <b>Speaker</b> mints a block proposal for review by the <b>Congressmen</b>. </p>

6. The **Congressmen** receive the proposal and validate:

    - Is the data format consistent with the system rules?
    - Is the transaction already on the blockchain?
    - Are the contract scripts correctly executed?
      - Does the transaction only contain a single spend?(i.e. does the transaction avoid a double spend scenario?)

    - **If Validated Proposal Broadcast:**
        <!-- -->
            <prepareResponse, h, k, i, [block]sigi>

    - **If Invalidated Proposal Broadcast:**
        <!-- -->
            <ChangeView, h,k,i,k+1>
        ​	
           <p align="center"><img src="/assets/consensus4.png" width="500"><br> <b>Figure 9:</b> The <b>Congressmen</b> review the block proposal and respond. </p>

7. After receiving `s` number of 'prepareResponse' broadcasts, a **Congressman** reaches a consensus and publishes a block.

8. The **Congressmen** sign the block.

   <p align="center"><img src="/assets/consensus5.png" width="500"><br> <b>Figure 10:</b> A consensus is reached and the approving <b>Congressmen</b> sign the block, binding it to the chain. </p>

9. When a **Consensus Node** receives a full block, current view data is purged, and a new round of consensus begins. 
  - `k = 0`

---

**Note:**

 If after   (![timeout](/assets/consensus.timeout.png) )  seconds on the same view without consensus:
  - **Consensus Node** broadcasts:

  <!-- -->
      <ChangeView, h,k,i,k+1>

  - Once a **Consensus Node** receives at least `s` number of broadcasts denoting the same change of view, it increments the view `v`, triggering a new round of consensus.


​	

## 6 - 引用
1. [A Byzantine Fault Tolerance Algorithm for Blockchain](whitepaper.md)
2. [Practical Byzantine Fault Tolerance](http://pmg.csail.mit.edu/papers/osdi99.pdf)
3. [The Byzantine Generals Problem](https://www.microsoft.com/en-us/research/wp-content/uploads/2016/12/The-Byzantine-Generals-Problem.pdf)

