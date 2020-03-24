using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using Helper = Neo.SmartContract.Framework.Helper;
using System;
using System.ComponentModel;
using System.Numerics;

namespace NFT
{
    public class NFT : SmartContract
    {

        [DisplayName("transfer")]
        public static event Action<string, string, BigInteger> Transferred;


        private static readonly byte[] Owner = "Ad1HKAATNmFT5buNgSxspbW68f4XVSssSw".ToScriptHash(); //Owner Address
        private static readonly String Owner_address = "Ad1HKAATNmFT5buNgSxspbW68f4XVSssSw";
        private const ulong total_supply = 100000000;
        private static readonly String TOKEN_ID_KEY = "TOKEN_ID_KEY";
        private static readonly String TOKEN_COUNTER_KEY = "TOKEN_COUNTER_KEY";

        public static object Main(string method, object[] args)
        {
            if (Runtime.Trigger == TriggerType.Verification)
            {
                return Runtime.CheckWitness(Owner);
            }
            else if (Runtime.Trigger == TriggerType.Application)
            {

                if (method == "balanceOf") return BalanceOf((string)args[0], (string)args[1]);

                if (method == "decimals") return Decimals();

                if (method == "deploy") return Deploy();

                if (method == "name") return Name();

                if (method == "symbol") return Symbol();

                if (method == "totalSupply") return TotalSupply();

                if (method == "mintTokens") return MintTokens();

                if (method == "transfer")
                {
                    if (args.Length==2)
                    {
                        return transfer((string)args[0], (string)args[1], (BigInteger)args[2], (string)args[3]);
                    }
                    else
                    {
                        return transfer((string)(args[0]), (string)args[1]);
                    }
                }
            }
            return false;
        }

        private static bool MintTokens()
        {
            if (!Runtime.CheckWitness(Owner))
            {
                return false;
            }
            BigInteger token_counter = Storage.Get(Storage.CurrentContext, TOKEN_COUNTER_KEY).AsBigInteger();
            token_counter = token_counter + 1;
            if(token_counter > total_supply)
            {
                return false;
            }
            String random_token_id = "";
            Storage.Put(Storage.CurrentContext, TOKEN_COUNTER_KEY, token_counter);
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            StorageMap asset = Storage.CurrentContext.CreateMap("balance" + Owner);
            asset.Put(random_token_id, new BigInteger(1));
            Storage.Put(Storage.CurrentContext, TOKEN_ID_KEY + token_counter, random_token_id);
            Storage.Put(Storage.CurrentContext, TOKEN_COUNTER_KEY, token_counter);
            Storage.Put(Storage.CurrentContext, Owner+random_token_id,random_token_id );
            Storage.Put(Storage.CurrentContext, random_token_id+Owner, Owner);
            return true;
        }

        [DisplayName("balanceOf")]
        public static BigInteger BalanceOf(string account, string tokenid)
        {
             if (account.Length != 34)
                throw new InvalidOperationException("The parameter account SHOULD be 20-byte addresses.");
                StorageMap asset = Storage.CurrentContext.CreateMap("balance" + account);
                return asset.Get(tokenid).AsBigInteger();
        }

        [DisplayName("decimals")]
        public static byte Decimals() => 8;


        [DisplayName("deploy")]
        public static bool Deploy()
        {
            if (TotalSupply() != 0) return false;
            Storage.Put(Storage.CurrentContext, "totalSupply", total_supply);
            Storage.Put(Storage.CurrentContext, TOKEN_COUNTER_KEY, 1);
            Storage.Put(Storage.CurrentContext, TOKEN_ID_KEY + 1, 1);
            return true;
        }

        [DisplayName("name")]
        public static string Name() => "MyNFT"; //name of the token

        [DisplayName("symbol")]
        public static string Symbol() => "MNFT"; //symbol of the token

        [DisplayName("totalSupply")]
        public static BigInteger TotalSupply()
        {
            StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
            return contract.Get("totalSupply").AsBigInteger();
        }

        public static Iterator<string, byte[]> tokens()
        {
            return Storage.Find(Storage.CurrentContext, TOKEN_ID_KEY);
        }

        public static Iterator<string, byte[]> ownerOf(string tokenid)
        {
      
            return Storage.Find(Storage.CurrentContext, tokenid);
        }

        public static Iterator<string, byte[]> tokensOfOwner(string owner)
        {
            return Storage.Find(Storage.CurrentContext, owner);
        }

        public static string tokenURI(string tokenid)
        {
            return "random uri";
        }

        public static bool transfer(string to, string tokenid)
        {
            if (!Runtime.CheckWitness(Owner))
            {
                return false;
            }
            StorageMap asset = Storage.CurrentContext.CreateMap("balance" + Owner);

           if(asset.Get(tokenid)==null)
           {
                return false;
           }

            asset.Delete(tokenid);

            StorageMap asset_to = Storage.CurrentContext.CreateMap("balance" + to);
            asset_to.Put(tokenid, new BigInteger(1));


            Storage.Delete(Storage.CurrentContext, Owner + tokenid);
            Storage.Delete(Storage.CurrentContext, tokenid + Owner);

            Storage.Put(Storage.CurrentContext, to + tokenid, tokenid);
            Storage.Put(Storage.CurrentContext, tokenid + to, to);
            Transferred(Owner_address, to, new BigInteger(1));
            return true;
        }
        //Methods of actual execution
        private static bool transfer(String from, String to, BigInteger amount, string tokenid)
        {
  
            if (from.Length != 34 || to.Length != 34)
                 throw new InvalidOperationException("The parameters from and to SHOULD be 34-byte addresses.");
            if (!Runtime.CheckWitness(from.ToScriptHash()))
            {
                return false;
            }

            if (amount <= 0 || amount >= new BigInteger(1))
                throw new InvalidOperationException("The parameter amount MUST be greater than 0 and SmallerThan 1.");
 

            StorageMap asset = Storage.CurrentContext.CreateMap("balance" + from);

            var fromAmount = asset.Get(tokenid).AsBigInteger();
            if (fromAmount < amount)
                return false;
            if (from == to)
                return true;

            //Reduce payer balances
            if (fromAmount == amount)
            {
                asset.Delete(tokenid);
                Storage.Delete(Storage.CurrentContext, from + tokenid);
                Storage.Delete(Storage.CurrentContext, tokenid + from);
            }
            else
            {
                asset.Put(tokenid, fromAmount - amount);
            }

            StorageMap asset_to = Storage.CurrentContext.CreateMap("balance" + to);
            BigInteger toAmount = asset_to.Get(to).AsBigInteger();
            asset_to.Put(tokenid, toAmount + amount);


            Storage.Put(Storage.CurrentContext, to + tokenid, tokenid);
            Storage.Put(Storage.CurrentContext, tokenid + to, to);

            Transferred(from, to, amount);

            return true;
        }

    }
}
