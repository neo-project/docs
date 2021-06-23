// You need to specify below info
const NEO_SCAN_URL = "https://neoscan-testnet.io/api/main_net";
const PRIV_RPC_NODE = "http://192.168.99.100:30333";
const CONTRACT_ADDRESS = 'AdYrj6yhqL8EWPKmK5hgcJydthchFTpGsf';
const CONTRACT_SCRIPTHASH = 'b6730fd741b632401f89020409c6c0415d97dcee';
const AMOUNT_OF_NEO_TO_BUY_ONE_VOUCHER = 0.1;

const testNetNeoScan = new Neon.api.neoscan.instance("TestNet");

// elements
const privateKeyInputEle = document.getElementById('priv_key');
const loginEle = document.getElementById('login');
const buyDiamondEle = document.getElementById('buy-diamond');
const confirmBuyItemEle = document.getElementById('confirm-buy-item');
const loginButtonEle = document.getElementById('login_button');
const neoCostAmountInputEle = document.getElementById('neo-cost-amount');
const voucherAffordableAmountEle = document.getElementById('voucher-affordable-amoount');
const petsContainerEle = document.getElementById('pets-container');
const petsContainerStoreEle = document.getElementById('pets-container-store');
const globalGasDisplayEle = document.getElementById('gas_global_display');
const globalVoucherDisplayEle = document.getElementById('voucher_global_display');

const diamondsToBuyInputEle = document.getElementById('diamond_to_buy');
const diamondsMinusEle = document.getElementById('diamonds_minus');
const diamondsPlusEle = document.getElementById('diamonds_plus');
const neoToCostEle = document.getElementById('neo_to_cost');
const buyDiamondButtonEle = document.getElementById('buy_diamonds_button');

let loginAccount;
checkStoredPrivKey();

// check whether session has private key
function checkStoredPrivKey() {
    let privKey = sessionStorage.getItem('private_key');
    if (privKey === null) {
        return;
    } else {
        initWithPrivKey(privKey);
    }
}

// When use login with private key
function submitPrivateKey(event) {
    if (privateKeyInputEle.value === "") {
        return;
    }
    window.sessionStorage.setItem('private_key', privateKeyInputEle.value);
    initWithPrivKey(privateKeyInputEle.value);
    dismissLogin();
}

// init account when get private key from session or user input.
function initWithPrivKey(privKey) {
    try {
        loginAccount = new Neon.wallet.Account(privKey);
        loginButtonEle.innerText = "Logout";

        // add private net config
        const config = {
            name: "PrivateNet",
            extra: {
                neoscan: NEO_SCAN_URL
            }
        };
        Neon.default.add.network(new Neon.rpc.Network(config));

        // get balance
        var privateNetNeoscan = new Neon.api.neoscan.instance("PrivateNet");
        privateNetNeoscan.getBalance(loginAccount.address).then(res => {
            console.log(res);
            updateGasDisplay(res);
        });

        invokeScriptReadOnly('balanceOf', checkVoucherBalanceCallback);
        invokeScriptReadOnly('checkCat', checkCatCallback);
    } catch(e){
        console.log(e);
    }
}

function onNeoAmountChange() {
    voucherAffordableAmountEle.innerText = 10 * neoCostAmountInputEle.value;
}

function dismissLogin(event) {
    privateKeyInputEle.value = "";
    document.querySelectorAll('.curtain').forEach(ele => {
        ele.style.display = "none";
    });
}

loginButtonEle.onclick = function(event) {
    if (this.innerText == "Login") {
        loginEle.style.display = "flex";
    } else {
        sessionStorage.clear();
        loginAccount = null;
        location.href = location.href;
    }
}

function buyDiamondPopup(event) {
    buyDiamondEle.style.display = "flex";
}

function checkVoucherBalanceCallback(res) {
    console.log(res);
    const voucherAmount = hexToBytes(res.result.stack[0].value);
    updateVoucherDisplay(voucherAmount);
}

function checkCatCallback(res) {
    const pets = reformCheckCatResult2(res.result.stack[0].value);
    console.log(pets);
    ownedPets = pets;
    renderPetsContainer(pets, false);
    renderPetsContainer(pets, true);
}

function updateGasDisplay(balance) {
    if (balance.assets['NEO'] === undefined) {
        globalGasDisplayEle.innerText = '0';
        return ;
    }
    const unSpentUtxos = balance.assets['NEO'].unspent;
    let gasAmount = 0;
    unSpentUtxos.forEach(unspent => {
        gasAmount += unspent.value.toNumber();
    });
    globalGasDisplayEle.innerText =  gasAmount;
}

const hexToBytes = function (hex) {
    if ((hex.length & 1) != 0)
        throw new RangeError();
    var bytes = new Uint8Array(hex.length / 2);
    for (var i = 0; i < bytes.length; i++)
        bytes[i] = parseInt(hex.substr(i * 2, 2), 16);
    return (new AntShares.BigInteger(bytes))/1e8;
};

function updateVoucherDisplay(voucherAmount) {
    globalVoucherDisplayEle.innerText = voucherAmount;
}

function buyCat(petName, price) {
    confirmBuyItemEle.style.display = 'flex';
    NAME_OF_PET_TO_BUY = petName;
    PRICE_OF_PET_TO_BUY = price;
}

document.getElementById('confirm_buy').onclick = function(event) {
    _buyCat(NAME_OF_PET_TO_BUY, PRICE_OF_PET_TO_BUY);
    confirmBuyItemEle.style.display = 'none';
}

document.getElementById('cancel_buy').onclick = function(event) {
    confirmBuyItemEle.style.display = 'none';
}

function _buyCat(petName, price) {
    const apiProvider = new Neon.api.neoscan.instance('PrivateNet');
    const param_address = Neon.sc.ContractParam.byteArray(
          loginAccount.address,
          "address"
        );
    const param_petName = Neon.default.create.contractParam("String", petName);
    const param_price = Neon.default.create.contractParam("Integer", price*1e8);

    const props = {
        scriptHash: CONTRACT_SCRIPTHASH,
        operation: "buyCat",
        args: [param_address, param_petName, param_price]
    };
    const script = Neon.default.create.script(props);
    const config = {
        api: testNetNeoScan,
        // url: PRIV_RPC_NODE,
        account: loginAccount,
        script: script
    };

    Neon.default.doInvoke(config).then(config => {
        console.log(config.response);
        if (config.response.result == true) {
            ownedPets = ownedPets.concat(petName);
            renderPetsContainer(ownedPets, false);
            renderPetsContainer(ownedPets, true);
            globalVoucherDisplayEle.innerText = Number(globalVoucherDisplayEle.innerText) - price;
        }
    }).catch(config => {
        console.log(config);
    });
}

// 80 03(item number) 0003(item1length) 426f62(item1) 0003 426f62 0005 416c696365
function reformCheckCatResult(responseString) {
    const pets = [];
    let result = responseString.slice(1);
    const arrayLength = Number(result.substring(0,3));
    result = result.slice(3);
    for (let i = 0; i < arrayLength; i++) {
        const length = Number(result.substring(0, 4));
        pets.push(hexToString(result.substring(4, 4 + length * 2)));
        result = result.slice(4 + length * 2);
    }
    return pets;
}

function reformCheckCatResult2(responseString) {
    let pets = [];
    let result = hexToString(responseString);
    pets = result.slice("neo");
    return pets;
}

function hexToString(hex) {
    var trimhex = hex.trim();
    var rawStr = trimhex.substr(0, 2).toLowerCase() === "0x" ? trimhex.substr(2) : trimhex;
    var len = rawStr.length;
    if (len % 2 !== 0) {
        alert("Illegal Format ASCII Code!");
        return "";
    }
    var cuChar;
    var result = [];
    for (var i = 0; i < len; i = i + 2) {
        cuChar = parseInt(rawStr.substr(i, 2), 16);
        result.push(String.fromCharCode(cuChar));
    }
    return result.join("");
}

function renderPetsContainer(pets, inStore) {
    let petsToBeShown;
    let petContainer;
    if (inStore) {
        petContainer = petsContainerStoreEle;
        petsToBeShown = PETS.filter(pet => pets.indexOf(pet.name) < 0);
    } else {
        petContainer = petsContainerEle;
        petsToBeShown = PETS.filter(pet => pets.indexOf(pet.name) >= 0);
    }

    petContainer.innerHTML = "";

    // <div class="pet-wrapper">
    //           <img class="pet-image" src="./resources/neo-house/1-1.png" />
    //           <div onclick="buyCat('Alice', 20)">
    //             <img class="buy-item-img" src="./resources/neo-house/buy.png">
    //           </div>
    //         </div>

    petsToBeShown.forEach(pet => {
        let childNode = document.createElement('div');
        childNode.classList = "pet-wrapper";
        let imgNode = document.createElement('img');
        imgNode.classList = "pet-image";
        imgNode.setAttribute('src', inStore? pet.image : pet.homeIcon);
        childNode.appendChild(imgNode);
        if (inStore) {
            let buyNode = document.createElement('img');
            buyNode.classList = "buy-item-img";
            buyNode.setAttribute('onclick', `buyCat("${pet.name}", ${pet.price})`);
            buyNode.setAttribute('src', "./resources/neo-house/buy.png");
            childNode.appendChild(buyNode);
        }

        petContainer.appendChild(childNode);
    });
}

function invokeScriptReadOnly(method, callback) {
    const methodParam = Neon.default.create.contractParam("String", method);
    const addressParam = Neon.sc.ContractParam.byteArray(
      loginAccount.address,
      "address"
    );
    let a = Neon.rpc.Query.invoke(
        CONTRACT_SCRIPTHASH,
        methodParam,
        Neon.sc.ContractParam.array(addressParam)
    ).execute("http://seed6.ngd.network:20332").then(res => callback(res));
}


diamondsToBuyInputEle.onchange = function(event) {
    if (this.value < 0) {
        this.value = 0;
        return;
    }
    const result = parseInt(this.value / 10) * 10;
    if (this.value != result) {
        this.value = result + 10;
    }
    neoToCostEle.innerText = this.value / 10;
};

diamondsMinusEle.onclick = function(event) {
    if (diamondsToBuyInputEle.value <= 0) {
        return;
    }
    diamondsToBuyInputEle.value = diamondsToBuyInputEle.value - 10;
    neoToCostEle.innerText = diamondsToBuyInputEle.value / 10;
};

diamondsPlusEle.onclick = function(event) {
    diamondsToBuyInputEle.value = parseInt(diamondsToBuyInputEle.value) + 10;
    neoToCostEle.innerText = diamondsToBuyInputEle.value / 10;
};

buyDiamondButtonEle.onclick = function(event) {
    if (diamondsToBuyInputEle.value <= 0) {
        return;
    }

    const neoAmount = parseInt(neoToCostEle.innerText);
    if (neoAmount === undefined || neoAmount === '') {
        return ;
    }

    const apiProvider = new Neon.api.neoscan.instance('PrivateNet');

    const intent = Neon.api.makeIntent({NEO:neoAmount}, CONTRACT_ADDRESS);
    const props = {
        scriptHash: CONTRACT_SCRIPTHASH,
        operation: "exchange_token",
        args: []
    };
    const script = Neon.default.create.script(props);
    const config = {
        api: testNetNeoScan,
        // url: PRIV_RPC_NODE,
        account: loginAccount,
        intents: intent,
        script: script
    };

    Neon.default.doInvoke(config).then(config => {
        console.log(config.response);
        if (config.response.result == true) {
            globalGasDisplayEle.innerText = Number(globalGasDisplayEle.innerText) - neoAmount;
            globalVoucherDisplayEle.innerText = Number(globalVoucherDisplayEle.innerText) + neoAmount*10;
            buyDiamondEle.style.display = 'none';
            diamondsToBuyInputEle.value = 0;
            neoToCostEle.innerText = '0';
        }
    }).catch(config => {
        console.log(config);
    });
}
