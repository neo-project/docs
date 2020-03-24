using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;
using Helper = Neo.SmartContract.Framework.Helper;

namespace NEP5
{
    public class NEP5 : SmartContract
    {
        [DisplayName("transfer")]
        public static event Action<byte[], byte[], BigInteger> Transferred;

        private static readonly byte[] Owner = "AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y".ToScriptHash(); //Owner Address
        private static readonly byte[] AssetId = Helper.HexToBytes("9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc5"); //NEO Asset ID, littleEndian
        private static readonly byte[] slider = Helper.HexToBytes("6e656f");//the hexstring of "neo"
        private const ulong factor = 100000000; //decided by Decimals()
        private const ulong initValue = 100000000 * factor;


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

                if (method == "buyItem") return buyItem((byte[])args[0], (byte[])args[1], (BigInteger)args[2]);

                if(method == "checkItem") return checkItem( (byte[]) args[0]);

                if (method == "exchange_token") return exchange_token();
            }
            return false;
        }

        [DisplayName("exchange_token")]
        public static object exchange_token()
        {
            Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
            TransactionOutput reference = tx.GetReferences()[0];
            if (reference.AssetId.AsBigInteger() != AssetId.AsBigInteger()) return false;

            byte[] sender = reference.ScriptHash;
            byte[] receiver = ExecutionEngine.ExecutingScriptHash;
            ulong value = 0;
            TransactionOutput[] outputs = tx.GetOutputs();

            // get the total amount of Neo
            foreach (TransactionOutput output in outputs)
            {
                if (output.ScriptHash == receiver)
                {
                    value += (ulong)output.Value;
                }
            }

            ulong exchanged_amount = value * 10;
            StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            BigInteger balance = asset.Get(sender).AsBigInteger();
            asset.Put(Owner, balance + exchanged_amount);
            return true;
        }

        [DisplayName("checkItem")]
        public static object checkItem(byte[] from)
        {
            StorageMap item = Storage.CurrentContext.CreateMap(nameof(item));
            String my_item= item.Get(from).AsString();
            return my_item;
        }

        [DisplayName("balanceOf")]
        public static BigInteger BalanceOf(byte[] account)
        {
            StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            return asset.Get(account).AsBigInteger();
        }
        
        [DisplayName("decimals")]
        public static byte Decimals() => 8;

        [DisplayName("deploy")]
        public static bool Deploy()
        {
            if (TotalSupply() != 0) return false;
            StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
            contract.Put("totalSupply", initValue);
            StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            asset.Put(Owner, initValue);
            Transferred(null, Owner, initValue);
            return true;
        }

        [DisplayName("name")]
        public static string Name() => "NEO GAME DIAMOND"; //name of the token

        [DisplayName("symbol")]
        public static string Symbol() => "NGD"; //symbol of the token

        [DisplayName("totalSupply")]
        public static BigInteger TotalSupply()
        {
            StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
            return contract.Get("totalSupply").AsBigInteger();
        }

        //Methods of actual execution
        [DisplayName("buyItem")]
        public static bool buyItem(byte[] from, byte[] to, BigInteger amount)
        {
            if (!Runtime.CheckWitness(from))
                return false;
            StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            var fromAmount = asset.Get(from).AsBigInteger();
            if (fromAmount < amount)
                return false;
            //Reduce payer balances
            if (fromAmount == amount)
                asset.Delete(from);
            else
                asset.Put(from, fromAmount - amount);
            //Increase the payee balance
            var toAmount = asset.Get(Owner).AsBigInteger();
            asset.Put(Owner, toAmount + amount);

            StorageMap item = Storage.CurrentContext.CreateMap(nameof(item));
            byte[] my_item = item.Get(from);
            if (my_item.Length == 0)
            {
                item.Put(from, to);
            }
            else
            {
                item.Put(from, my_item.Concat(slider).Concat(to));

            }
            Transferred(from, Owner, amount);
            return true;
        }
    }
}
