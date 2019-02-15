<p align="center">
  <img 
    src="../assets/logo.svg" 
    width="200px"
    alt="Neo">
</p>
<p align="center" style="font-size: 48px;">
  <strong>Privatenet / Eventnet</strong>
</p>

# Purpose
This document will outline the process for deploying a remote privatenet/eventnet of the Neo Blockchain

# Tools
* Clean AWS EC2 medium instance (Ubuntu 14+)

# Procedure
1. Deploy a clean Ubuntu EC2 instance
2. Create a new security group for the instance which exposes the following ports:
   * 20333-20336 (nodes)
   * 30333-30336 (nodes)
   * 4000 (neoscan)
   * 4002 (faucet)
3. SSH into the instance
4. execute:

```bash
    wget https://raw.githubusercontent.com/neo-project/docs/feature/workshops/en-us/workshop/support/deployEventnet.sh
    sudo chmod +x deployEventnet.sh
    sudo ./deployEventnet.sh
```

You should now be able to access the applications at the following:
* <b>Neoscan:</b> {{public IP}}:4000
* <b>Neo-Local-Faucet:</b> {{public IP}}:4002
* <b>Neo Node RPC:</b> {{public IP}}:20333

<i><b>Note:</b> For a stable/long term development environment, it is recommended to use a volume size of at least 20GB </i>

