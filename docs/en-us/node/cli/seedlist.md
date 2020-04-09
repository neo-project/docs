# Neo-CLI SeedList

## About SeedList
The SeedList, simply put, is a list of URLs. They belong to the nodes that Neo-CLI tries to connect to when it starts.
You can find the SeedList in `protcol.json`, under the neo-cli directory.

```json
{
  "ProtocolConfiguration": {
    "Magic": ...,
    "MillisecondsPerBlock": ...,
    "StandbyValidators": [
      ...
    ],
    "SeedList": [
      "seed1.neo.org:10333",
      "seed2.neo.org:10333",
      "seed3.neo.org:10333",
      "seed4.neo.org:10333",
      "seed5.neo.org:10333"
    ]
  }
}
```
Here, Neo-CLI is configured to connect to `seed1.neo.org`, `seed2.neo.org`, and so on through `PORT:10333`.

### Potential Issues with current setup
That's all well and good, but what happens if every single node in our list is down?

Well, neo-cli is smart, so it will attempt to connect to neighbouring nodes. However, there are many unknown factors in this approach. Perhaps the neighbours are down. The wait time may grow to be unbearable.

## Updating the SeedList
By updating the SeedList with addresses of nodes that we're certain are alive, we can avoid lengthy wait times as described in **Potential Issues**.

### How to update?
####  Live nodes
And how do we find out which nodes are alive? The good folks at ***City of Zion*** has created an excellent [resource](https://github.com/CityOfZion/neo-mon) that constantly pings nodes all around the world. The results are displayed on this [tracker](http://monitor.cityofzion.io/).

![seedlist](../../assets/seedlist.png)
Here we see a list of nodes that are available. The latest ones are pushed to the top.
*2* tells us if the node is responding. Generally, we take the ones that say `yes` and are green in color.

We try to follow the standard protocol for ports.

|                    | Main Net | Test Net |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |

With that, we will choose the first node over the third node, since *1* adheres the convention and *3* does not.

We will choose the following live node addresses:

- `seed3.aphelion-neo.com`
- `seed4.aphelion-neo.com`
- `node2.ams2.bridgeprotocol.io`
- `pyrpc1.nodeneo.ch`
- `node2.nyc3.bridgeprotocol.io`

The main port neo-cli works with is `10333`. Currently, we are pinging `RPC` only. We are assuming that if a node's `RPC` port is up, then its `P2P` port should be up as well. If this sounds wrong, that's because it is! We will address it in one of our upcoming Hackathons, so stay tuned!


#### Editing the protocol
To let Neo-CLI know the new SeedList, we will paste the addresses chosen before into `protocol.json`.

```json
{
  "ProtocolConfiguration": {
    "Magic": 7630401,
    "MillisecondsPerBlock": 15000,
    "StandbyValidators": [
      "03b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c",
      "02df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e895093",
      "03b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a",
      "02ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba554",
      "024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d",
      "02aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e",
      "02486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a70"
    ],
    "SeedList": [
      "seed1.neo.org:10333",
      "seed2.neo.org:10333",
      "seed3.neo.org:10333",
      "seed4.neo.org:10333",
      "seed5.neo.org:10333",
      "seed4.aphelion-neo.com:10333",
      "node2.sgp1.bridgeprotocol.io:10333",
      "seed2.aphelion-neo.com:10333",
      "seed3.aphelion-neo.com:10333",
      "node2.ams2.bridgeprotocol.io:10333",
      "pyrpc1.narrative.network:10333",
      "node2.nyc3.bridgeprotocol.io:10333",
      "pyrpc4.narrative.network:10333",
      "pyrpc2.narrative.network:10333",
      "pyrpc3.narrative.network:10333",
      "seed1.aphelion-neo.com:10333",
      "seed1.switcheo.network:10333",
      "seed2.switcheo.network:10333",
      "seed5.cityofzion.io:10333",
      "seed3.cityofzion.io:10333",
      "seed3.switcheo.network:10333",
      "seed1.o3node.org:10333",
      "seed3.travala.com:10333",
      "seed4.cityofzion.io:10333",
      "seed2.cityofzion.io:10333",
      "seed2.o3node.org:10333",
      "seed3.o3node.org:10333",
      "node1.sgp1.bridgeprotocol.io:10333",
      "seed2.travala.com:10333",
      "seed4.switcheo.network:10333",
      "seed1.spotcoin.com:10333",
      "node1.nyc3.bridgeprotocol.io:10333"
    ]   
  }
}
```
Notice that we've added `:10333` to the end of each of the addresses, to tell Neo-CLI that to connect using the `P2P` protocol.

And that's it! You can now start neo-cli as usual.

### Reference tools
If the above steps are too tedious, there's also a script written that automatically updates the `protocol.json`. Check it out [here](https://github.com/HandsomeJeff/neo-cli-protocol-maker).

