# Local Blockchain
You can choose to use a local network for development purposes. To do this, we recommend you to check [NEO-Local](https://github.com/CityOfZion/neo-local).

**Note:** This is used for development purposes only, neo components used in these docker images may not be the latest available. **Always test your smart-contract using the Testnet.**

**Docker Required**
This projects uses Docker and Docker-compose. It works on MacOS, Linux and Windows machines.
Fore more information related to Docker, check their [official website](https://www.docker.com/).


![](../../assets/neolocal.png)


## Neo-local content
NEO-local will start several containers, being:
  - 4 consensus nodes - a fully working network;
  - Block explorer \(Neoscan\);
  - Notification server \(Neo-python\);
  - Development tools \(Neo-python\);
  - A wallet with GAS;
  - Developer faucet (to obtain extra GAS);

## Simple setup
Having docker and docker-compose installed:
  1. Clone the repository:  https://github.com/CityOfZion/neo-local
  2. From terminal or powershell change to the newly cloned directory on your machine: ```cd ./neo-local ```. 
  3. Run ```docker-compose up ```. 
  4. After the setup is done, check if everything is running by accessing `http://localhost:4000` using your browser.


Please check  [Neo-local wiki](https://github.com/CityOfZion/neo-local/wiki) for more information.
