using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using Helper = Neo.SmartContract.Framework.Helper;
using System;
using System.ComponentModel;
using System.Numerics;

namespace NFT
{
    public class NFT : SmartContract{

        [DisplayName("transfer")]
        public static event Action<byte[], byte[], BigInteger> Transferred;


        private static readonly byte[] Owner = "Ad1HKAATNmFT5buNgSxspbW68f4XVSssSw".ToScriptHash(); //Owner Address
        private const ulong total_supply = 100000000;
        private static readonly byte[] AssetId = Helper.HexToBytes("9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc5"); //NEO Asset ID, littleEndian


        public static object Main(string method, object[] args)
        {
            if (Runtime.Trigger == TriggerType.Verification)
            {
                return Runtime.CheckWitness(Owner);
            }
            else if (Runtime.Trigger == TriggerType.Application)
            {

                if (method == "balanceOf") return BalanceOf((byte[])args[0]);

                if (method == "decimals") return Decimals();

                if (method == "deploy") return Deploy();

                if (method == "name") return Name();

                if (method == "symbol") return Symbol();

                if (method == "totalSupply") return TotalSupply();

                if (method == "transfer") return Transfer((byte[])args[0], (byte[])args[1], (BigInteger)args[2]);
            }
            return false;
        }

        [DisplayName("balanceOf")]
        public static BigInteger BalanceOf(byte[] owner, byte[] tokenid)
        {
            // if (account.Length != 20)
            //     throw new InvalidOperationException("The parameter account SHOULD be 20-byte addresses.");
            // StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            // return asset.Get(account).AsBigInteger();
        }

        [DisplayName("decimals")]
        public static byte Decimals() => 8;


        [DisplayName("deploy")]
        public static bool Deploy()
        {
            if (TotalSupply() != 0) return false;
            StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
            contract.Put("totalSupply", pre_ico_cap);
            StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            asset.Put(Owner, pre_ico_cap);
            Transferred(null, Owner, pre_ico_cap);
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

        public static enumerator tokens(){

        }

        public static enumerator ownerOf(byte[] tokenid){

        }

        public static enumerator tokensOfOwner(byte[] owner){

        }

        public static string tokenURI(byte[] tokenid){

        }

        public static bool transfer(byte[] to, byte[] tokenid){

        }
        //Methods of actual execution
        private static bool Transfer(byte[] from, byte[] to, , BigInteger amount, byte[] tokenid)
        {
            // //Check parameters
            // if (from.Length != 20 || to.Length != 20)
            //     throw new InvalidOperationException("The parameters from and to SHOULD be 20-byte addresses.");
            // if (amount <= 0)
            //     throw new InvalidOperationException("The parameter amount MUST be greater than 0.");
            // if (!Runtime.CheckWitness(from))
            //     return false;
            // StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            // var fromAmount = asset.Get(from).AsBigInteger();
            // if (fromAmount < amount)
            //     return false;
            // if (from == to)
            //     return true;

            // //Reduce payer balances
            // if (fromAmount == amount)
            //     asset.Delete(from);
            // else
            //     asset.Put(from, fromAmount - amount);

            // //Increase the payee balance
            // var toAmount = asset.Get(to).AsBigInteger();
            // asset.Put(to, toAmount + amount);

            // Transferred(from, to, amount);
            // return true;
        }

    }
}
