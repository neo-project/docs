# NEO Protocol and Networking

The NEO network consists of two kind of protocols: a protocol to communicate with local clients and wallets, and an external protocol to communicate with other NEO nodes. To connect to a local node, [JSON-RPC](https://www.jsonrpc.org/) is used. This JSON-RPC can also be exposed to other external nodes.

```
                          +--------------+
+----------+              | +----------+ |
|          | NEO Protocol | |          | |
| NEO node +----------------+ NEO peer | |
|          |              | |          | |
+----------+              | +----+-----+ |
                          |      |       |
                          |      |JSON   |
                          |      |RPC    |
                          |      |       |
                          | +----+-----+ |
                          | |          | |
                          | |Local node| |
                          | |          | |
                          | +----------+ |
                          +--------------+
                              NEO node
```

In this tutorial, we will focus on the other protocol, the [NEO protocol](https://docs.neo.org/docs/en-us/tooldev/advanced/network-protocol.html). Using the Golang programming language, we will learn how to communicate with a NEO node.

## NEO Ping with Golang

Although many [core libraries of NEO](https://github.com/neo-project/neo) are written in C# or Python, for this tutorial we will use [Golang](https://golang.org/). The communication basics are the same for all languages.

The NEO protocol defines However, ia header and a payload. Every message needs to be sent with this specific format, with a 24 bytes header and its payload:

```
 0                   1                   2                   3
 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
|                      Magic: 0x00746E41                        |
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
|                                                               |
+                                                               +
|                      Command: 12 bytes                        |
+                                                               +
|                                                               |
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-++-+-++-+-++-+-++-+-+-+-+-+-+-+-+
|                        Payload length                         |
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-++-+-++-+-++-+-++-+-+-+-+-+-+-+-+
|                       Payload checksum                        |
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-++-+-++-+-++-+-++-+-+-+-+-+-+-+-+
|                                                               |
|                           Payload                             |
```
Communication with other NEO nodes is handled via TCP or via [WebSockets](https://developer.mozilla.org/en-US/docs/Web/API/WebSockets_API). The advantage of using WebSockets is that you could connect to a NEO node with a web browser, however in this tutorial we will use TCP.

The header contains a 4 bytes magic, which stands for "Ant" (little-endian), the name that was used before the NEO rebranding. The testnet uses slightly different magic bytes, allowing messages to be distinguished between the MainNet and TestNet.

---
**Exercise 1**:However, i
Please answer the following question:

Although compatibility is very important and changing the format of the protocol could break many clients, what theoretical optimizations could be done in the protocol header?

---

In order to participate in the NEO distributed system, firstly we need to open a connection to a NEO node. Since we want to issue ping/pong commands, which was released in NEO version 2.10.1 on 4. April 2019, we need to make sure that our node has this version. A list of NEO nodes with versions can be found here: [http://monitor.cityofzion.io/](http://monitor.cityofzion.io/). The following nodes announce this version at the time of writing:

* node1.ledgercate.com:10333
* seed.neoeconomy.io:10333
* seed10.ngd.network:10333

Please note that peers can go offline at any time, and those peers above may not be online anymore. Any other NEO node above v2.10.1 may be substituted.

These nodes must be well reachable on the respective port. The default port in the mainnet is 10333. In case a node is behind a firewall, a node can use UPnP to configure the router to accept incoming connection to the node. NAT-PMP is currently not supported. In our tutorial we won't accept any incoming connections, that means we don't have any NAT issues.

Let's implement the protocol. Here is what we need to do: first we set the magic number, then we set the command followed by the payload length. Then we calculate the checksum and append the payload. Now, we can send our packet to one of the NEO nodes. Sounds easy, right?

### Little-Endian vs. Big-Endian

For every protocol, it must be defined which byte order is used. In case of NEO its little-endian. Thus, the magic byte will be encoded as follows:

```
0x00746E41 -> [41][6E][74][00]
```
Big-endian encoding would like as follows: [00][74][6E][41]. Many programming languages have utilities to handle the conversion, such as Golang:

```
binary.LittleEndian.PutUint32(b[0:], 0x00746E41)
```
While most CPUs use little-endian encoding, network protocols such as TCP or UDP use big-endian. More information on endianness can be found in [https://en.wikipedia.org/wiki/Endianness](https://en.wikipedia.org/wiki/Endianness). For this tutorial we will use little-endian, as most data is encoded in little-endian in NEO, and we won't touch the exceptions.

### Checksum
The checksum field in the header is the checksum calculated over the payload. Although TCP also has a checksum over its payload, the TCP checksum is only 16 bits. The payload checksum in NEO is the first 4 bytes (32 bits) of the double SHA256 hash of the payload. In Golang, the checksum can be calculated as follows:

```
 tmp := sha256.Sum256(payload)
 hash := sha256.Sum256(tmp[:])
 ...
 copy(b[20:], hash[0:4])
```
If the checksum does not match, the node should ignore the message.

---
**Exercise 2**:
Write an encoder and decoder for the header. Use the following "quick and dirty" template in Appendix A and complete the following two functions: `encodeHeader(cmd string, payload []byte) []byte`, where the return array is the header combined with the payload. The encoder should return the whole byte array that can be sent on the wire, and `decodeHeader(b []byte) (uint32, uint32)`, where the first return value is the length of the payload and the second value is the checksum.

Hint: the magic number can be encoded as:
```
binary.LittleEndian.PutUint32(b[0:], 0x00746E41)
```
and decoded as:
```
fmt.Printf("magic: 0x%x\n", binary.LittleEndian.Uint32(b))
```
---

### Payload protocol
After implementing the encoding and decoding of the headers for the NEO protocol, we can focus on the payload. The NEO protocol supports the following commands, though not every command has a payload.

* version - information about the version of the node, including version number
* verack - on successfully receiving of version information, send back verack (no payload)
* getaddr - request to send a send active NEO nodes
* addr - response to getaddr request
* getblocks - request to send blocks
* block - response to getblocks or getdata
* consensus - response to getdata
* filteradd - add data to the bloomfilter
* filterclear - clear the bloomfilter
* filterload - create the bloomfilter with its initial settings. The bloomfilter is used to return only blocks with transactions we are interested in
* getdata - request a specific object. Response will be in tx, block, merkleblock, or consensus message
* getheaders - request to send block headers
* headers - response to getheaders
* inv - send information about transactions, blocks, or consensus
* mempool - request verified transactions from the mempool. Response will be in inv
* ping - checks if the peer alive
* pong - response to a ping message
* tx - response to a getdata message

To write a NEO ping message it is important to understand that there is a strict order of commands that needs to be issued. For every connection, a version and its acknowledgment verack needs to be exchanged twice; once from your node and once from the remote node. The following flow diagram shows this sequence of commands:

```
+-------+             +-------+
| NEO1  |             | NEO2  |
+-------+             +-------+
    |                     |
    | command version     |
    |-------------------->|
    |                     |
    |     command version |
    |<--------------------|
    |                     |
    | command verack      |
    |-------------------->|
    |                     |
    |      command verack |
    |<--------------------|
    |                     |
    | command ping        |
    |-------------------->|
    |                     |
    |        command pong |
    |<--------------------|
    |                     |
```

For the NEO ping, we will only use the version and ping command with a payload. The verack command does not have any payload and will not be described. The payload of those two commands are defined as follows:

### Command "version"

* Version (uint32) specifies the version of the protocol, currently the version is 0
* Services (uint64) - specifies the services, currently set to 1
* Timestamp (uint32) - time in seconds since 01.01.1970
* Port (uint16) - the port we are listening to, this can be 0 if your node does not handle incoming connections
* Nonce (uint32) - random number
* UserAgent max 1024 bytes - use 1 byte as the length in this tutorial, then the string. Don't go over 253 bytes (0xfd)
* BlockHeight (uint32) - the block height, your block height can be 0
* Relay (uint8) - if your node is a relay, set to false (0)

### Command "ping"

* BlockHeight (uint32) - the block height, your block height can be 0
* Timestamp (uint32) - time in seconds since 01.01.1970
* Nonce (uint32) - random number

### Protocol
With this information we can implement the NEO node ping. First we need to write the encoders and decoders for the payload of version and ping.

---
**Exercise 3**:
Write an encoder and decoder for ping/version. Use the following template at [https://github.com/tbocek/VSS-NEO-TUTORIAL/blob/master/neo_ping_template.go](https://github.com/tbocek/VSS-NEO-TUTORIAL/blob/master/neo_ping_template.go) and complete the following two functions: `encodeVersion(userAgent string) []byte`, `encodePing() []byte`, `decodeVersion(b []byte) string`, which returns the user agent, and `decodePing(b []byte)`. Print relevant information to the console in the decoder.

Hint: the timestamp can be encoded as:

```
binary.LittleEndian.PutUint32(b[12:], uint32(time.Now().Unix()))
```
and decoded as:

```
fmt.Printf("time: %v\n", time.Unix(int64(binary.LittleEndian.Uint32(b[12:])), 0))
```

---

### Putting It together
First, connect to a NEO node that supports ping/pong. We will check for the correct version later on.

```
func main() {
	remote, err := net.Dial("tcp", "node1.plutolo.gy:10333") //check: http://monitor.cityofzion.io/
	if err != nil {
		panic(err)
	}
	defer remote.Close()
	fmt.Println("Conneced to: %v", remote.RemoteAddr())
```
Now we send our version to the remote NEO node.
```
	payloadVersion := encodeVersion("/Our NEO client:0.0.1/")
	packetVersion := encodeHeader("version", payloadVersion)
	n, err := remote.Write(packetVersion)
	if err != nil {
		panic(err)
	}
	fmt.Printf("wrote version packet: %v, %d\n", packetVersion, n)
```

We wrote the version and now we can expect the version from the remote host. In fact, some clients also send it right after connection is established.

```
	//we get the version from the remote, display it
	read := make([]byte, 24)
	n, err = io.ReadFull(remote, read) //read header
	plen,rcvChecksum := decodeHeader(read)
	read = make([]byte, plen)
	n, err = io.ReadFull(remote, read) //read payload
	userAgent := decodeVersion(read)
```

On receiving the version from the NEO node, we additionally check the checksum to ensure that they match. The checksum is the first 4 bytes of the double SHA256 hash of the payload.

```
	tmp := sha256.Sum256(read)
	hash := sha256.Sum256(tmp[:])
	checksum := binary.LittleEndian.Uint32(hash[0:4])
	fmt.Printf("read version payload: %v, %d\n", read, n)
	if rcvChecksum != checksum {
		panic(errors.New("checksum mismatch in version!"))
	}
```

Since ping/pong was only implemented recently, we need to make sure that we ask a supported version. It looks that the versions use semantic versioning. However, the Python implementation uses different versioning, so we should also check which user agent is used. As there is no other implementation with such a high version 2.10.1, we can just check this version (its quick and dirty :).

```
	//check if we have a good version
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

Since we sent a version packet, we need to get the verack and we also need to send a verack, as we received the version as well:

```
	////////// got version, send ack
	packetVerack := encodeHeader("verack", []byte{})
	n, err = remote.Write(packetVerack);
	if err != nil {
		panic(err)
	}

	///////// wait for verack confirmation
	read = make([]byte, 24)
	n, err = io.ReadFull(remote, read)
	plen, rcvChecksum = decodeHeader(read)
	fmt.Printf("read verack array: %v, %d\n", read, plen)
	if rcvChecksum != 3806393949 {
		panic(errors.New("checksum mismatch in verack!"))
	}
```

After the version/verack, we can now send the ping. Without the versions, no commands can be sent.

```
	/////// send ping
	packet2 := encodeHeader("ping", encodePing())
	n, err = remote.Write(packet2)
	if err != nil {
		panic(err)
	}
	fmt.Printf("wrote ping: %v, %d\n", packet2, n)
```

After sending the ping, we can expect a pong message.

```
	//////// receive pong
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
**Exercise 4**:
Merge your encoder/decoder code with the main function from the template and run it on the MainNet. What can you see?

---

After successfully sending a NEO ping and receiving a pong back, we can send `getaddr` and receive further nodes in the NEO network. For that, you can use the connection you have already established. Finding other peers is crucial for P2P and distributed systems, as peers may go offline at any time, and having other nodes to connect to is vital.

---
**Exercise 5**:
After sending the ping message, send a `getaddr` message. Analyze the output.

Hint:
The output contains a list of IP addresses (16 bytes IPv6/4, 2 bytes port) that are encoded big-endian. The data also contains a service flag (set to 1) and a timestamp.

---

You now have successfully implemented a NEO client that can initiate a connection to other NEO nodes, send a ping, receive a pong, and get a list of further peers.


## Appendix A: Quick & Dirty Template

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

	//we get the version from the remote, display it
	read := make([]byte, 24)
	n, err = io.ReadFull(remote, read) //read header
	plen, rcvChecksum := decodeHeader(read)
	read = make([]byte, plen)
	n, err = io.ReadFull(remote, read) //read payload
	userAgent := decodeVersion(read)

	tmp := sha256.Sum256(read)
	hash := sha256.Sum256(tmp[:])
	checksum := binary.LittleEndian.Uint32(hash[0:4])
	fmt.Printf("read version payload: %v, %d\n", read, n)
	if rcvChecksum != checksum {
		panic(errors.New("checksum mismatch in version!"))
	}

	//check if we have a good version
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

	////////// got version, send ack
	packetVerack := encodeHeader("verack", []byte{})
	n, err = remote.Write(packetVerack)
	if err != nil {
		panic(err)
	}

	///////// wait for verack confirmation
	read = make([]byte, 24)
	n, err = io.ReadFull(remote, read)
	plen, rcvChecksum = decodeHeader(read)
	fmt.Printf("read verack array: %v, %d\n", read, plen)
	if rcvChecksum != 3806393949 {
		panic(errors.New("checksum mismatch in verack!"))
	}

	/////// send ping
	packet2 := encodeHeader("ping", encodePing())
	n, err = remote.Write(packet2)
	if err != nil {
		panic(err)
	}
	fmt.Printf("wrote ping: %v, %d\n", packet2, n)

	//////// receive pong
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
	//encoding here
	copy(b[4:], cmd)
	//payload length
    binary.LittleEndian.PutUint32(b[16:], uint32(len(payload)))
    //payload checksum
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
	// encoding here
	b[27+userAgentLen] = 0
	return b
}

func encodePing() []byte {
	b := make([]byte, 12)
	// encoding here
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
	// decoding here
	//return userAgent

	return ""
}

func decodePing(b []byte) {
	// decoding here
}


```

## What's next?

[Persistence](../6-persistence/1-persistence.md)