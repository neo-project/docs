# NEO 协议和网络

NEO网络由两种协议组成：与本地客户端和钱包进行通信的协议，以及与NEO网络中其他节点通信的外部协议。与本地节点进行连接使用的是[JSON-RPC](https://www.jsonrpc.org/)协议。也可以通过JSON-RPC连接到外部节点。

```
                          +--------------+
+----------+              | +----------+ |
|          | NEO 协议| |          | |
| NEO 节点+----------------+ NEO 对等节点| |
|          |              | |          | |
+----------+              | +----+-----+ |
                          |      |       |
                          |      |JSON   |
                          |      |RPC    |
                          |      |       |
                          | +----+-----+ |
                          | |          | |
                          | |本地节点| |
                          | |          | |
                          | +----------+ |
                          +--------------+
                              NEO 节点
```

在本教程中，我们将重点介绍另一个协议，[NEO协议](https://docs.neo.org/docs/zh-cn/tooldev/advanced/network-protocol.html)。我们将使用Golang语言来学习如何与NEO节点通信。

## 使用Golang来Ping NEO 网络

虽然很多的[NEO核心库](https://github.com/neo-project/neo)都是用C#或Python编写的，但在本教程中，我们将使用[Golang](https://golang.org/)语言。通信基础对任何语言而言都是相同的。

NEO协议定义了一个区块头和一个payload。每个报文都需要按照特定的格式发送，即24字节长的协议头以及相应的payload：

```
 0                   1                   2                   3
 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
|                      魔法数: 0x00746E41                        |
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
|                                                               |
+                                                               +
|                      命令: 12 字节                            |
+                                                               +
|                                                               |
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-++-+-++-+-++-+-++-+-+-+-+-+-+-+-+
|                        Payload 长度                           |
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-++-+-++-+-++-+-++-+-+-+-+-+-+-+-+
|                       Payload 校验和                          |
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-++-+-++-+-++-+-++-+-+-+-+-+-+-+-+
|                                                               |
|                           Payload                             |
```

与其他NEO节点的通信是通过TCP或[WebSockets](https://developer.mozilla.org/en-us/docs/web/api/websockets_-api)进行的。使用WebSockets的好处是，你可以通过Web浏览器连接到NEO节点。不过在本教程中，我们使用的是TCP协议。

协议头包含一个4字节的魔法数，代表的是“Ant”（小端存储），这个名称是在NEO品牌重塑之前使用的。测试网使用的魔法数有些许不同，从而来区分主网和测试网的消息。

------

**练习1**: 请回答以下问题：

尽管兼容性非常重要，而更改协议的格式可能会对客户端的运行产生影响，不过理论上来说，可以对协议头做哪些优化呢？

---

为了加入到NEO分布式系统，首先，我们需要先建立一个到NEO节点的连接。由于我们会用到ping/pong命令，这个命令在2019年4月4日发布的NEO v2.10.1版本中已经实现了，所以我们需要确保我们的节点运行了这个版本。可以点击此处 [http://monitor.cityofzion.io/](http://monitor.cityofzion.io/)查看运行了该版本的NEO节点列表。在编写本文档的时候，以下几个节点使用了该版本：

* node1.plutolo.gy:10333
* seed.neoeconomy.io:10333
* seed10.ngd.network:10333

请注意，节点可能会随时下线，上面这几个节点也可能不会再上线了。可以替换为运行了v2.10.1以上版本的任意的NEO节点。

这些节点必须能够在相应的端口上提供很好的可访问性。主网的默认端口是10333。如果节点开启了防火墙，可以使用UPnP配置路由从而接受发送到节点的传入连接请求。目前不支持NAT-PMP。在本教程中，我们不会接受任何的传入连接，这意味着不会有任何NAT问题。

让我们来实现这个协议。我们需要做的是：首先设置魔法数，然后设置紧跟着payload长度的命令。之后计算校验和并附加payload信息。现在，我们可以将报文发送到一个NEO节点。听起来很简单，对吧？

### 小端和大端

对于每个协议，都必须定义使用的是哪种字节顺序。NEO中使用的是小端存储。因此，魔法数字节的编码如下所示：
```
0x00746E41 -> [41][6E][74][00]
```
大端编码看起来是这样的：[00][74][6E][41]。许多编程语言都提供了相应的转换工具，Golang中的操作是这样的：

```
binary.LittleEndian.PutUint32(b[0:], 0x00746E41)
```
虽然大多数CPU使用的是小端编码，但是网络协议（如TCP或UDP）使用的是大端序。有关端序的更多信息，请查看[https://en.wikipedia.org/wiki/endianness](https://en.wikipedia.org/wiki/endianness)。在本教程中，我们使用的是小端序，因为NEO中的大部分数据都是使用小端编码的，并且我们不会涉及到异常问题。

### 校验和
协议头中的校验和字段是针对payload计算出的校验和。虽然TCP在其payload上也有校验和，但TCP的校验和只有16位。NEO中的payload校验和是对payload进行两次SHA256哈希之后取最终结果的前4字节（32位）。在Golang中，校验和的计算方法如下所示：

```
 tmp := sha256.Sum256(payload)
 hash := sha256.Sum256(tmp[:])
 ...
 copy(b[20:], hash[0:4])
```
如果校验和不匹配，节点应该忽略这条消息。

------

**练习2**: 编写用于协议头的编码器和解码器。使用底下附录A中 “快速而粗糙”的模板，实现以下两个功能：`encodeheader（cmd string，payload[]byte）[]byte`，其中返回的数组是组合了payload的协议头。编码器应该返回可以发送到链路的完整的字节数组。另一个是`decodeheader（b[]byte）（uint32，uint32）`，其中第一个返回值是payload的长度，第二个值是校验和。

提示：魔法数可以编码为：
```
binary.LittleEndian.PutUint32(b[0:], 0x00746E41)
```
解码为:
```
fmt.Printf("magic: 0x%x\n", binary.LittleEndian.Uint32(b))
```
---

### Payload协议

实现了NEO协议头的编码和解码功能之后，我们可以专注于payload了。NEO协议支持以下这些命令，不过并不是所有命令都具有payload。

- version - 节点版本的相关信息，包括版本号

- verack - 成功接收到版本信息时，发送应答信息verack（无payload）

- getaddr - 请求活跃的NEO节点列表

- addr - 对getaddr请求的响应

- getBlocks - 请求区块

- block - 对getblocks或getdata的响应

- consensus - 对getdata的响应

- filteradd - 向布隆过滤器添加数据

- filterclear - 清除布隆过滤器

- filterload - 创建带有初始设置的布隆过滤器。布隆过滤器只返回我们感兴趣的交易的区块

- getdata - 请求特定对象。交易、区块、默克尔区块或共识报文中有响应信息。

- GetHeaders - 请求区块头

- headers - 对getHeaders的响应

- inv - 发送有关交易、区块或共识的信息

- mempool - 请求内存池中已验证的交易。inv报文中带有响应信息

- ping - 检查节点是否处于活跃状态

- pong - 对ping消息的响应

- tx - 对getData消息的响应

要编写NEO ping报文，必须知道待发布的命令是有严格的顺序要求的。对于每个连接，version及其应答verack需要进行两次握手通信：一次从你的节点发出，一次从远程节点发出。以下流程图显示了这个命令序列：

```
+-------+             +-------+
| NEO1  |             | NEO2  |
+-------+             +-------+
    |                     |
    | 命令version     |
    |-------------------->|
    |                     |
    |     命令version |
    |<--------------------|
    |                     |
    | 命令verack      |
    |-------------------->|
    |                     |
    |      命令verack |
    |<--------------------|
    |                     |
    | 命令ping        |
    |-------------------->|
    |                     |
    |        命令pong |
    |<--------------------|
    |                     |
```

对于NEO ping，我们只使用带有payload的version和ping命令。verack命令不带有任何的payload，这里不做说明。这两个命令的payload定义如下：

### “version”命令

- version（uint32）指定协议的版本，当前版本为0。

- Services（uint64）- 指定服务，当前设置为1

- Timestamp（uint32）- 自1970年1月1日起经过的时间（单位：秒）

- Port（uint16）- 监听的端口号，如果节点不处理传入连接，可以设为0

- Nonce（uint32）- 随机数

- Useragent 最多1024 字节- 本教程使用1字节长，字符串的格式。不要超过253字节（0xfd）

- Blockheight（uint32）- 区块高度，你的区块高度可以是0

- Relay（uint8）- 如果是中继节点，则设置为false（0）

### “ping”命令

- Blockheight（uint32）- 区块高度，你的区块高度可以是0

- Timestamp（uint32）- 自1970年1月1日起经过的时间（单位：秒）

- Nonce（uint32）- 随机数

### 协议

利用这些信息，我们就可以实现NEO节点的ping命令。首先，我们需要编写针对version/ping的payload的编码器和解码器。

------

**练习3**: 编写用于ping/version命令的编码器和解码器。使用[https://github.com/tbocek/vss-neo-tutorial/blob/master/neo-ping-template.go](https://github.com/tbocek/vss-neo-tutorial/blob/master/neo-ping-template.go)提供的模板实现以下两个功能：一个是`encodeversion（useragent string）[]byte`，`encodeping（）[]byte`，`decodeversion（b[]byte）string`，返回用户代理；另一个是 `decodePing（b[]byte）`。在解码器中将相关信息输出到控制台。

提示：timestamp可以编码为：

```
binary.LittleEndian.PutUint32(b[12:], uint32(time.Now().Unix()))
```

解码为:
```
fmt.Printf("time: %v\n", time.Unix(int64(binary.LittleEndian.Uint32(b[12:])), 0))
```

---

### 进行组装

首先，连接到支持ping/pong命令的NEO节点。后面我们会检查版本的正确性：

```
func main() {
	remote, err := net.Dial("tcp", "node1.plutolo.gy:10333") // check: http://monitor.cityofzion.io/
	if err != nil {
		panic(err)
	}
	defer remote.Close()
	fmt.Println("Conneced to: %v", remote.RemoteAddr())
```

现在我们发送version信息到远程的NEO节点。

```
	payloadVersion := encodeVersion("/Our NEO client:0.0.1/")
	packetVersion := encodeHeader("version", payloadVersion)
	n, err := remote.Write(packetVersion)
	if err != nil {
		panic(err)
	}
	fmt.Printf("wrote version packet: %v, %d\n", packetVersion, n)
```

发送了version，现在我们可以等远程主机发送version。实际上，一些客户端也会在连接建立后立即发送version信息。

```
	//获取远程节点的版本，并显示
	read := make([]byte, 24)
	n, err = io.ReadFull(remote, read) //读取报头
	plen,rcvChecksum := decodeHeader(read)
	read = make([]byte, plen)
	n, err = io.ReadFull(remote, read) //读取payload
	userAgent := decodeVersion(read)
```

在接收到NEO节点的版本信息时，我们还会额外检查校验和是否匹配。校验和是payload的两次SHA256哈希后结果的前4个字节。

```
	tmp := sha256.Sum256(read)
	hash := sha256.Sum256(tmp[:])
	checksum := binary.LittleEndian.Uint32(hash[0:4])
	fmt.Printf("read version payload: %v, %d\n", read, n)
	if rcvChecksum != checksum {
		panic(errors.New("checksum mismatch in version!"))
	}
```

由于ping/pong是最近才实现的，因此我们需要确保我们的版本是否支持这个功能。看起来版本使用了语义版本控制。但是，Python实现使用了不同的版本控制，因此我们还应该检查使用了哪个用户代理。由于还没有高于v2.10.1的实现版本，因此我们只需检查这个版本（快速而粗糙：）。

```
	//检查版本是否正确
	start := strings.Index(userAgent, ":")
	end := strings.Index(userAgent[start:], "/")
	if start < 0 && end < 0 {
		panic(errors.New(fmt.Sprintf("cannot parse version in %s", userAgent)))
	}
	semVer := userAgent[start+1:start+end]
	fmt.Printf("parsed semver: %v\n", semVer)
	v1, err := version.NewVersion(semVer)
	min, err := version.NewVersion("2.10.1")
	if v1.LessThan(min) {
		panic(errors.New(fmt.Sprintf("%s is less than %s", v1, min)))
	}
```

由于我们发送了一个version数据包，所以我们需要接收一个verack包，而又由于我们也收到了version包，所以我们还需要发送回verack：

```
	////////// 获取version，发送verack
	packetVerack := encodeHeader("verack", []byte{})
	n, err = remote.Write(packetVerack);
	if err != nil {
		panic(err)
	}

	///////// 等待verack 确认
	read = make([]byte, 24)
	n, err = io.ReadFull(remote, read)
	plen, rcvChecksum = decodeHeader(read)
	fmt.Printf("read verack array: %v, %d\n", read, plen)
	if rcvChecksum != 3806393949 {
		panic(errors.New("checksum mismatch in verack!"))
	}
```

在version/verack之后，现在我们可以发送ping了。没有这些versions信息，就不能发送任何命令

```
	/////// 发送ping
	packet2 := encodeHeader("ping", encodePing())
	n, err = remote.Write(packet2)
	if err != nil {
		panic(err)
	}
	fmt.Printf("wrote ping: %v, %d\n", packet2, n)
```

发送ping之后，我们可以期待接收到一个pong报文。

```
	//////// 收到pong
	read = make([]byte, 36)
	_, err = io.ReadFull(remote, read)
	_, rcvChecksum = decodeHeader(read)
	decodePing(read[24 : 24+12])
	fmt.Printf("read array: %v\n", read)

	tmp = sha256.Sum256(read[24 : 24+12])
	hash = sha256.Sum256(tmp[:])
	checksum = binary.LittleEndian.Uint32(hash[0:4])

	if rcvChecksum != checksum {
		panic(errors.New("checksum mismatch in pong!"))
	}

	remote.Close()
}
```

---
**练习4**: 利用模板将编码器/解码器代码与main函数进行合并，并在主网上运行。你能看到什么？

在成功发送NEO ping并接收到返回的pong之后，我们可以发送`getaddr`并获取更多NEO网络中的节点信息。这样你就可以使用已经建立的连接了。对于P2P和分布式系统来说，寻找其他对等节点至关重要，因为节点随时可能下线，需要连接到其他节点。

------

**练习5**: 发送完ping报文后，发送`getaddr`报文。分析输出。

提示：输出包含一个IP地址列表（16字节长的IPv6/4，2字节长的端口），这些地址是经过大端编码的。数据还包含一个service标志位（设置为1）和一个时间戳timestamp。

现在，你已经成功地实现了一个NEO客户端，它可以建立一个到其他NEO节点的连接，发送ping命令，接收pong命令以及获取更多节点的列表。

------


##附录A：快速而粗糙的模板
```go

package main

import (
	"bytes"
	//"bytes"
	"crypto/sha256"
	"encoding/binary"
	"errors"
	"fmt"
	"github.com/hashicorp/go-version"
	"io"
	//"math/rand"
	"net"
	"strings"
	//"time"
)

func main() {
	remote, err := net.Dial("tcp", "node1.plutolo.gy:10333") //check: http://monitor.cityofzion.io/
	if err != nil {
		panic(err)
	}
	defer remote.Close()
	fmt.Println("Conneced to: %v", remote.RemoteAddr())

	payloadVersion := encodeVersion("/The HSR NEO client:0.0.1/")
	packetVersion := encodeHeader("version", payloadVersion)
	n, err := remote.Write(packetVersion)
	if err != nil {
		panic(err)
	}
	fmt.Printf("wrote version packet: %v, %d\n", packetVersion, n)

	//从远程节点获得version，并加以显示
	read := make([]byte, 24)
	n, err = io.ReadFull(remote, read) //读取报头
	plen, rcvChecksum := decodeHeader(read)
	read = make([]byte, plen)
	n, err = io.ReadFull(remote, read) //读取payload
	userAgent := decodeVersion(read)

	tmp := sha256.Sum256(read)
	hash := sha256.Sum256(tmp[:])
	checksum := binary.LittleEndian.Uint32(hash[0:4])
	fmt.Printf("read version payload: %v, %d\n", read, n)
	if rcvChecksum != checksum {
		panic(errors.New("checksum mismatch in version!"))
	}

	//检验版本是否正确
	start := strings.Index(userAgent, ":")
	end := strings.Index(userAgent[start:], "/")
	if start < 0 && end < 0 {
		panic(errors.New(fmt.Sprintf("cannot parse version in %s", userAgent)))
	}
	semVer := userAgent[start+1 : start+end]
	fmt.Printf("parsed semver: %v\n", semVer)
	v1, err := version.NewVersion(semVer)
	min, err := version.NewVersion("2.10.1")
	if v1.LessThan(min) {
		panic(errors.New(fmt.Sprintf("%s is less than %s", v1, min)))
	}

	////////// 收到version, 发送verack
	packetVerack := encodeHeader("verack", []byte{})
	n, err = remote.Write(packetVerack)
	if err != nil {
		panic(err)
	}

	///////// 等到verack 确认
	read = make([]byte, 24)
	n, err = io.ReadFull(remote, read)
	plen, rcvChecksum = decodeHeader(read)
	fmt.Printf("read verack array: %v, %d\n", read, plen)
	if rcvChecksum != 3806393949 {
		panic(errors.New("checksum mismatch in verack!"))
	}

	/////// 发送ping
	packet2 := encodeHeader("ping", encodePing())
	n, err = remote.Write(packet2)
	if err != nil {
		panic(err)
	}
	fmt.Printf("wrote ping: %v, %d\n", packet2, n)

	//////// 接收pong
	read = make([]byte, 36)
	_, err = io.ReadFull(remote, read)
	_, rcvChecksum = decodeHeader(read)
	decodePing(read[24 : 24+12])
	fmt.Printf("read array: %v\n", read)

	tmp = sha256.Sum256(read[24 : 24+12])
	hash = sha256.Sum256(tmp[:])
	checksum = binary.LittleEndian.Uint32(hash[0:4])

	if rcvChecksum != checksum {
		panic(errors.New("checksum mismatch in pong!"))
	}

	remote.Close()
}

func encodeHeader(cmd string, payload []byte) []byte {
	b := make([]byte, 24+len(payload))

	binary.LittleEndian.PutUint32(b[0:], 0x00746E41)
	//此处进行编码
	copy(b[4:], cmd)
	//payload长度
    binary.LittleEndian.PutUint32(b[16:], uint32(len(payload)))
    //payload校验和
    tmp := sha256.Sum256(payload)
    hash := sha256.Sum256(tmp[:])
    copy(b[20:], hash[0:4])

	//payload
	copy(b[24:], payload)
	return b
}

func encodeVersion(userAgent string) []byte {
	userAgentLen := len(userAgent)
	b := make([]byte, 27+userAgentLen+1)
	// 此处进行编码
	b[27+userAgentLen] = 0
	return b
}

func encodePing() []byte {
	b := make([]byte, 12)
	// 此处进行编码
	return b
}

func decodeHeader(b []byte) (uint32, uint32) {
	fmt.Printf("magic: 0x%x\n", binary.LittleEndian.Uint32(b))
	fmt.Printf("command: %v\n", string(bytes.Trim(b[4:16], "\x00")))
	len := binary.LittleEndian.Uint32(b[16:])
	fmt.Printf("payload len: %d\n", len)
	checksum := binary.LittleEndian.Uint32(b[20:])
	fmt.Printf("checksum: 0x%x\n", checksum)
	return len, checksum

}

func decodeVersion(b []byte) string {
	// 此处进行解码
	//返回userAgent

	return ""
}

func decodePing(b []byte) {
	// 此处进行解码
}


```

## 阅读下节

[持久化](../6-persistence/1-persistence.md)

