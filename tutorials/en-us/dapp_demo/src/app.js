// You need to specify below info
const NEO_SCAN_URL = "http://localhost:4000/api/main_net";
const CONTRACT_ADDRESS = 'AcVwpkHqVFidzC3DFZEH2c1BjvSmbAbjSc';
const CONTRACT_SCRIPTHASH = '63f902d6c5ed8c524cd2ce4f6af015dafc7857e3';
const AMOUNT_OF_NEO_TO_BUY_ONE_VOUCHER = 0.1;
const PRIV_RPC_NODE = "http://127.0.0.1:30333";

// elements
const privateKeyInputEle = document.getElementById('priv_key');
const loginEle = document.getElementById('login');
const buyDiamondEle = document.getElementById('buy-diamond');
const confirmBuyItemEle = document.getElementById('confirm-buy-item');
const loginButtonEle = document.getElementById('login_button');
const neoCostAmountInputEle = document.getElementById('neo-cost-amount');
const voucherAffordableAmountEle = document.getElementById('voucher-affordable-amoount');
const itemsContainerEle = document.getElementById('items-container');
const itemsContainerStoreEle = document.getElementById('items-container-store');
const globalGasDisplayEle = document.getElementById('gas_global_display');
const globalVoucherDisplayEle = document.getElementById('voucher_global_display');
const diamondsToBuyInputEle = document.getElementById('diamond_to_buy');
const diamondsMinusEle = document.getElementById('diamonds_minus');
const diamondsPlusEle = document.getElementById('diamonds_plus');
const neoToCostEle = document.getElementById('neo_to_cost');
const buyDiamondButtonEle = document.getElementById('buy_diamonds_button');



// add private net config
const config = {
    name: "PrivateNet",
    extra: {
        neoscan: NEO_SCAN_URL
    }
};
Neon.default.add.network(new Neon.rpc.Network(config));
var privateNetNeoscan = new Neon.api.neoscan.instance("PrivateNet");

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


        privateNetNeoscan.getBalance(loginAccount.address).then(res => {
            console.log(res);
            updateGasDisplay(res);
        });

        invokeScriptReadOnly('balanceOf', checkVoucherBalanceCallback);
        invokeScriptReadOnly('checkItem', checkItemCallback);
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
    const voucherAmount = hexToBytes(res.result.stack[0].value);
    updateVoucherDisplay(voucherAmount);
}

function checkItemCallback(res) {
    const items = reformCheckItemResult2(res.result.stack[0].value);
    ownedItems = items;
    renderItemsContainer(items, false);
    renderItemsContainer(items, true);
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

function buyItem(itemName, price) {
    confirmBuyItemEle.style.display = 'flex';
    NAME_OF_ITEM_TO_BUY = itemName;
    PRICE_OF_ITEM_TO_BUY = price;
}

document.getElementById('confirm_buy').onclick = function(event) {
    _buyItem(NAME_OF_ITEM_TO_BUY, PRICE_OF_ITEM_TO_BUY);
    confirmBuyItemEle.style.display = 'none';
}

document.getElementById('cancel_buy').onclick = function(event) {
    confirmBuyItemEle.style.display = 'none';
}

function _buyItem(itemName, price) {
    const apiProvider = new Neon.api.neoscan.instance('PrivateNet');
    const param_address = Neon.sc.ContractParam.byteArray(
          loginAccount.address,
          "address"
        );
    const param_itemName = Neon.default.create.contractParam("String", itemName);
    const param_price = Neon.default.create.contractParam("Integer", price*1e8);
    

    const props = {
        scriptHash: CONTRACT_SCRIPTHASH,
        operation: "buyItem",
        args: [param_address, param_itemName, param_price]
    };

    console.log(props)

    const script = Neon.default.create.script(props);
    const config = {
        api: privateNetNeoscan,
        url: PRIV_RPC_NODE,
        account: loginAccount,
        script: script
    };

    Neon.default.doInvoke(config).then(config => {
        console.log(config.response);
        if (config.response.result == true) {
            ownedItems = ownedItems.concat(itemName);
            renderItemsContainer(ownedItems, false);
            renderItemsContainer(ownedItems, true);
            globalVoucherDisplayEle.innerText = Number(globalVoucherDisplayEle.innerText) - price;
        }
    }).catch(config => {
        console.log(config);
    });
}

// 80 03(item number) 0003(item1length) 426f62(item1) 0003 426f62 0005 416c696365
function reformCheckCatResult(responseString) {
    const items = [];
    let result = responseString.slice(1);
    const arrayLength = Number(result.substring(0,3));
    result = result.slice(3);
    for (let i = 0; i < arrayLength; i++) {
        const length = Number(result.substring(0, 4));
        items.push(hexToString(result.substring(4, 4 + length * 2)));
        result = result.slice(4 + length * 2);
    }
    return items;
}

function reformCheckItemResult2(responseString) {
    let items = [];
    let result = hexToString(responseString);
    if(result!=""){
        items = result.slice("neo");
    }
    return items;
}

function hexToString(hex) {
    var trimhex = hex.trim();
    if(trimhex == ""){
        return ""
    }
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

function renderItemsContainer(items, inStore) {
    let itemsToBeShown;
    let itemContainer;
    if (inStore) {
        itemContainer = itemsContainerStoreEle;
        itemsToBeShown = ITEMS.filter(item => items.indexOf(item.name) < 0);
    } else {
        itemContainer = itemsContainerEle;
        itemsToBeShown = ITEMS.filter(item => items.indexOf(item.name) >= 0);
    }

    itemContainer.innerHTML = "";

    // <div class="item-wrapper">
    //           <img class="item-image" src="./resources/neo-house/1-1.png" />
    //           <div onclick="buyCat('Alice', 20)">
    //             <img class="buy-item-img" src="./resources/neo-house/buy.png">
    //           </div>
    //         </div>

    itemsToBeShown.forEach(item => {
        let childNode = document.createElement('div');
        childNode.classList = "item-wrapper";
        let imgNode = document.createElement('img');
        imgNode.classList = "item-image";
        imgNode.setAttribute('src', inStore? item.image : item.homeIcon);
        childNode.appendChild(imgNode);
        if (inStore) {
            let buyNode = document.createElement('img');
            buyNode.classList = "buy-item-img";
            buyNode.setAttribute('onclick', `buyItem("${item.name}", ${item.price})`);
            buyNode.setAttribute('src', "./resources/neo-house/buy.png");
            childNode.appendChild(buyNode);
        }
        
        itemContainer.appendChild(childNode);
    });
}

function invokeScriptReadOnly(method, callback) {
    const methodParam = Neon.default.create.contractParam("String", method);
    const addressParam = Neon.sc.ContractParam.byteArray(
      loginAccount.address,
      "address"
    );
    console.log(methodParam,loginAccount)
    Neon.rpc.Query.invoke(
        CONTRACT_SCRIPTHASH,
        methodParam,
        Neon.sc.ContractParam.array(addressParam)
    ).execute(PRIV_RPC_NODE).then(res => callback(res));
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
        api: privateNetNeoscan,
        account: loginAccount,
        intents: intent,
        script: script
    };

    Neon.default.doInvoke(config).then(config => {
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