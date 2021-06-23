using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using Helper = Neo.SmartContract.Framework.Helper;
using System;
using System.ComponentModel;
using System.Numerics;

namespace ITO
{
    public class ITO : SmartContract
    {
        [DisplayName("transfer")]
        public static event Action<byte[], byte[], BigInteger> Transferred;

        [DisplayName("refund")]
        public static event Action<byte[], BigInteger> Refund;

        private static readonly byte[] Owner = "Ad1HKAATNmFT5buNgSxspbW68f4XVSssSw".ToScriptHash(); //Owner Address
        private const ulong factor = 100000000; //decided by Decimals()
        private const ulong total_amount = 100000000 * factor;
        private static readonly byte[] AssetId = Helper.HexToBytes("9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc5"); //NEO Asset ID, littleEndian


        private const ulong pre_ico_cap = 0 * factor;
        private const int ico_start_time = 1502726400;
        private const int ico_end_time = 1503936000;

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

                if (method == "mintTokens") return MintTokens();

                if (method == "transfer") return Transfer((byte[])args[0], (byte[])args[1], (BigInteger)args[2]);
            }
            return false;
        }

        [DisplayName("balanceOf")]
        public static BigInteger BalanceOf(byte[] account)
        {
            if (account.Length != 20)
                throw new InvalidOperationException("The parameter account SHOULD be 20-byte addresses.");
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
            contract.Put("totalSupply", pre_ico_cap);
            StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            asset.Put(Owner, pre_ico_cap);
            Transferred(null, Owner, pre_ico_cap);
            return true;
        }

        [DisplayName("name")]
        public static string Name() => "WorldToken"; //name of the token

        [DisplayName("symbol")]
        public static string Symbol() => "AWT"; //symbol of the token

        [DisplayName("totalSupply")]
        public static BigInteger TotalSupply()
        {
            StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
            return contract.Get("totalSupply").AsBigInteger();
        }

        //Methods of actual execution
        private static bool Transfer(byte[] from, byte[] to, BigInteger amount)
        {
            //Check parameters
            if (from.Length != 20 || to.Length != 20)
                throw new InvalidOperationException("The parameters from and to SHOULD be 20-byte addresses.");
            if (amount <= 0)
                throw new InvalidOperationException("The parameter amount MUST be greater than 0.");
            if (!Runtime.CheckWitness(from))
                return false;
            StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            var fromAmount = asset.Get(from).AsBigInteger();
            if (fromAmount < amount)
                return false;
            if (from == to)
                return true;

            //Reduce payer balances
            if (fromAmount == amount)
                asset.Delete(from);
            else
                asset.Put(from, fromAmount - amount);

            //Increase the payee balance
            var toAmount = asset.Get(to).AsBigInteger();
            asset.Put(to, toAmount + amount);

            Transferred(from, to, amount);
            return true;
        }

        public static bool MintTokens()
        {
            Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
            TransactionOutput reference = tx.GetReferences()[0];
            // check whether asset is neo
            if (reference.AssetId.AsBigInteger() != AssetId.AsBigInteger()) return false;

            byte[] sender = reference.ScriptHash;
            TransactionOutput[] outputs = tx.GetOutputs();
            byte[] receiver = ExecutionEngine.ExecutingScriptHash;
            ulong value = 0;
            // get the total amount of Neo
            foreach (TransactionOutput output in outputs)
            {
                if (output.ScriptHash == receiver)
                {
                    // do not accept any other global assets 
                    if (output.AssetId.AsBigInteger() != AssetId.AsBigInteger())
                    {
                        return false;
                    }
                    value += (ulong)output.Value;
                }
            }

            // the current exchange rate between ico tokens and neo during the token swap period
            ulong swap_rate = CurrentSwapRate();
            // crowdfunding failure
            if (swap_rate == 0)
            {
                Refund(sender, value);
                return false;
            }
            // crowdfunding success
            ulong token = value * swap_rate / 100000000;


            StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
            BigInteger totalSupply = Storage.Get("totalSupply").AsBigInteger();
            contract.Put("totalSupply", totalSupply + token);

            StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            BigInteger balance = asset.Get(sender).AsBigInteger();
            asset.Put(Owner, balance + token);

            Transferred(null, sender, token);
            return true;
        }

        private static ulong CurrentSwapRate()
        {
            // factor is detemined by the decimal, which is a constant. The raate means 1 NEO => 1000 NEP5
            const ulong basic_rate = 1000 * factor;
            const int ico_duration = ico_end_time - ico_start_time;
            BigInteger total_supply = Storage.Get(Storage.CurrentContext, "totalSupply").AsBigInteger();
            if (total_supply >= total_amount) return 0;
            uint now = Blockchain.GetHeader(Blockchain.GetHeight()).Timestamp;
            int time = (int)now - ico_start_time;
            if (time < 0)
            {
                return 0;
            }
            else if (time > ico_duration)
            {
                return 0;
            }
            else
            {
                return basic_rate;
            }
        }
    }
}
