"""
Testing:
neo> build 4-domain.py test 0710 05 True False query ["test.com"]
neo> build 4-domain.py test 0710 05 True False register ["test.com","AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y"]
neo> build 4-domain.py test 0710 05 True False delete ["test.com"]
neo> build 4-domain.py test 0710 05 True False transfer ["test.com","AK2nJJpJr6o664CWJKi1QRXjqeic"]
Importing:
neo> import contract 4-domain.avm 0710 05 True False
neo> contract search ...
Using:
neo> testinvoke 5030694901a527908ab0a1494670109e7b85e3e4 query ["test.com"]
neo> testinvoke 5030694901a527908ab0a1494670109e7b85e3e4 register ["test.com","AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y"]
neo> testinvoke 5030694901a527908ab0a1494670109e7b85e3e4 delete ["test.com"]
neo> testinvoke 5030694901a527908ab0a1494670109e7b85e3e4 transfer ["test.com","AZ9Bmz6qmboZ4ry1z8p2KF3ftyA2ckJAym"]
"""
from boa.interop.Neo.Runtime import Log, Notify
from boa.interop.Neo.Storage import Get, Put, GetContext
from boa.interop.Neo.Runtime import GetTrigger,CheckWitness
from boa.builtins import concat


def Main(operation, args):
    nargs = len(args)
    if nargs == 0:
        print("No domain name supplied")
        return 0

    if operation == 'query':
        domain_name = args[0]
        return QueryDomain(domain_name)

    elif operation == 'delete':
        domain_name = args[0]
        return DeleteDomain(domain_name)

    elif operation == 'register':
        if nargs < 2:
            print("required arguments: [domain_name] [owner]")
            return 0
        domain_name = args[0]
        owner = args[1]
        return RegisterDomain(domain_name, owner)

    elif operation == 'transfer':
        if nargs < 2:
            print("required arguments: [domain_name] [to_address]")
            return 0
        domain_name = args[0]
        to_address = args[1]
        return TransferDomain(domain_name, to_address)


def QueryDomain(domain_name):
    msg = concat("QueryDomain: ", domain_name)
    Notify(msg)

    context = GetContext()
    owner = Get(context, domain_name)
    if not owner:
        Notify("Domain is not yet registered")
        return False

    Notify(owner)
    return owner


def RegisterDomain(domain_name, owner):
    msg = concat("RegisterDomain: ", domain_name)
    Notify(msg)

    if not CheckWitness(owner):
        Notify("Owner argument is not the same as the sender")
        return False

    context = GetContext()
    exists = Get(context, domain_name)
    if exists:
        Notify("Domain is already registered")
        return False

    Put(context, domain_name, owner)
    return True


def TransferDomain(domain_name, to_address):
    msg = concat("TransferDomain: ", domain_name)
    Notify(msg)

    context = GetContext()
    owner = Get(context, domain_name)
    if not owner:
        Notify("Domain is not yet registered")
        return False

    if not CheckWitness(owner):
        Notify("Sender is not the owner, cannot transfer")
        return False

    if not len(to_address) != 34:
        Notify("Invalid new owner address. Must be exactly 34 characters")
        return False

    Put(context, domain_name, to_address)
    return True


def DeleteDomain(domain_name):
    msg = concat("DeleteDomain: ", domain_name)
    Notify(msg)

    context = GetContext()
    owner = Get(context, domain_name)
    if not owner:
        Notify("Domain is not yet registered")
        return False

    if not CheckWitness(owner):
        Notify("Sender is not the owner, cannot transfer")
        return False

    Delete(context, domain_name)
    return True
