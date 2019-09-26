from boa.interop.Neo.Storage import Get, Put, Delete, GetContext
from boa.interop.Neo.Runtime import Notify, CheckWitness, Serialize, Deserialize, Log
from boa.interop.Neo.Action import RegisterAction
from boa.interop.System.ExecutionEngine import GetScriptContainer, GetExecutingScriptHash
from boa.interop.Neo.Transaction import Transaction, GetReferences, GetOutputs, GetUnspentCoins
from boa.interop.Neo.Output import GetValue, GetAssetId, GetScriptHash
from boa.builtins import concat

ctx = GetContext()

OnTransfer = RegisterAction('transfer', 'addr_from', 'addr_to', 'amount')

TOKEN_DECIMALS = 8
# Name of the Token
TOKEN_NAME = 'NGD PET'
# Symbol of the Token
TOKEN_SYMBOL = 'NPT'

TOKEN_INITIAL_SUPPLY = 1000 * 100000000  # 10m total supply * 10^8 ( decimals)

TOKEN_OWNER = b'#\xba\'\x03\xc52c\xe8\xd6\xe5"\xdc2 39\xdc\xd8\xee\xe9'

NEO_ASSET_ID= b'\x9b|\xff\xda\xa6t\xbe\xae\x0f\x93\x0e\xbe`\x85\xaf\x90\x93\xe5\xfeV\xb3J\\"\x0c\xcd\xcfn\xfc3o\xc5'

def buyCat(from_acc, animal, amount):
    if not CheckWitness(from_acc):
        Notify("Not the owner, can't buy")
        return False

    tmplist = Get(ctx, from_acc + "CAT")
    if len(tmplist) != 0:
        delist = Deserialize(tmplist)
        Notify(delist)
        delist.append(animal)
        Notify(delist)
        Put(ctx, from_acc + "CAT", Serialize(delist))
    else:
        Put(ctx, from_acc + "CAT", Serialize([animal]))
        Notify(Serialize([animal]))

    current_balance = Get(ctx, from_acc)
    if current_balance <= amount:
        Notify("Insufficient funds")
        return False
    to_balance = Get(ctx, TOKEN_OWNER)
    to_balance += amount
    Put(ctx, TOKEN_OWNER, to_balance)
    current_balance -= amount
    if current_balance != 0:
        Put(ctx, from_acc, current_balance)
    else:
        Delete(ctx, from_acc)
    OnTransfer(from_acc, TOKEN_OWNER, amount)
    return True

def checkCat(owner):
    exists = Get(ctx, owner + "CAT")
    if len(exists) != 0:
        tmp = Deserialize(exists)
        Notify(tmp)
        return exists
    return False

def deploy():
    if not Get(ctx,"initialized"):
        Put(ctx, 'initialized', 1)
        Put(ctx, TOKEN_OWNER,TOKEN_INITIAL_SUPPLY)
        return True
    return False

def balanceOf(acc):
    itemValue = Get(ctx, acc)
    if len(itemValue) != 0:
        return itemValue
    return 0
    
def exchange_token():
    tx = GetScriptContainer()
    references = tx.References
    sender_addr = None
    receiver_addr = GetExecutingScriptHash()
    sent_amount_neo = 0
    sender_addr = 1
    neo_amount = 0
    if len(references) > 0:
        reference = references[0]
        sender_addr = reference.ScriptHash
    for output in tx.Outputs:
        if output.ScriptHash == receiver_addr:
            neo_amount += output.Value
    if neo_amount == 0:
        return false
    exchanged_amount = neo_amount * 10
    current_balance = Get(ctx, sender_addr)
    Put(ctx, sender_addr, current_balance + exchanged_amount)
    return True

def Main(operation, args):
    if operation == "totalSupply":
        return TOKEN_TOTAL_SUPPLY

    if operation == "name":
        return TOKEN_NAME

    if operation == "symbol":
        return TOKEN_SYMBOL

    if operation == "decimals":
        return TOKEN_DECIMALS

    if operation == "buyCat":
        return buyCat(from_acc = args[0], animal = args[1],amount = args[2])

    if operation == "checkCat":
        return checkCat(owner = args[0])

    if operation == "deploy":
        return deploy()

    if operation == "balanceOf":
        return balanceOf(args[0])

    if operation == "exchange_token":
        return exchange_token()

    return "Undefined operation."