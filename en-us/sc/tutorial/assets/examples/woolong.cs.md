```c#
using System.ComponentModel;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System.Numerics;


namespace Woolong 
{
    public class Woolong : FunctionCode
    {

        /// <summary>
        ///   This is the NEP5 example token: Woolong.
        ///   It will generate 1 new Woolong every time the contract is invoked.
        /// 
        ///   Note the parameter list below:
        ///   Parameter List: 0710
        ///   Return List: 05
        ///
        ///   参数：0710
        ///   返回值：05
        /// </summary>
        /// <param name="method">
        ///   The NEP5 Method being invoked.
        ///   所调用的 NEP5 方法
        /// </param>
        /// <param name="args">
        ///   Optional input parameters used by the NEP5 functions.
        ///   NEP5 方法的参数
        /// </param>

        public static object Main(string method, params object[] args)
        {
            string name = "Woolong";
            string symbol = "WNG";
            BigInteger decimals = 0;
            var lllwvlvwlll = new byte[] { 3, 84, 174, 73, 130, 33, 4, 108, 102,
                110, 254, 187, 174, 233, 189, 14, 180,
                130, 52, 105, 201, 142, 116, 132, 148,
                169, 42, 113, 243, 70, 177, 166, 97 };

            if (method == "deploy") return Deploy(lllwvlvwlll);
            
            Grow(lllwvlvwlll); 
            
            if (method == "totalSupply") return Storage.Get(Storage.CurrentContext, "supply");
 
            if (method == "name") return name;
 
            if (method == "symbol") return symbol;

            if (method == "decimals") return decimals;
           
            if (method == "balanceOf") return Storage.Get(Storage.CurrentContext, (byte[]) args[0]);

            //Verify that the originator is honest.
            //确认交易者诚实
            if (!Runtime.CheckWitness((byte[]) args[0])) return false;
            
            if (method == "transfer") return Transfer((byte[]) args[0], (byte[]) args[1], BytesToInt((byte[]) args[2]));
            
            return false;
        }


        /// <summary>
        ///   Generate 1 Woolong every time the contract is invoked.
        /// </summary>
        private static void Grow(byte[] lllwvlvwlll)
        {          
            var value = BytesToInt(Storage.Get(Storage.CurrentContext, lllwvlvwlll)) + 1;
            Storage.Put(Storage.CurrentContext, lllwvlvwlll, IntToBytes(value));
            
            var supply = BytesToInt(Storage.Get(Storage.CurrentContext, "supply")) + 1;
            Storage.Put(Storage.CurrentContext, "supply", IntToBytes(supply));
        }

        /// <summary>
        ///    Deploy the token with 1 supply
        /// </summary>
        /// <param name="lllwvlvwlll">
        ///    My account...
        /// </param>
        /// <returns></returns>
        private static bool Deploy(byte[] lllwvlvwlll)
        {
            BigInteger initSupply = 1;
            Storage.Put(Storage.CurrentContext, lllwvlvwlll, IntToBytes(initSupply));
            Storage.Put(Storage.CurrentContext, "supply", IntToBytes(initSupply));
            return true;
        }
        
        
        /// <summary>
        ///   Transfer a balance to another account.
        ///   转帐
        /// </summary>
        /// <param name="originator">
        ///   The contract invoker.
        ///   合约调用者的公钥
        /// </param>
        /// <param name="to">
        ///   The account to transfer to.
        ///   转帐目标
        /// </param>
        /// <param name="amount">
        ///   The amount to transfer.
        ///   转账数量
        /// </param>
        /// <returns>
        ///   Transaction Successful?
        ///   交易是否成功，布尔值
        /// </returns>
        private static bool Transfer(byte[] originator, byte[] to, BigInteger amount)
        {           
            //Get the account value of the source and destination accounts.
            //获取源和目标账户的余额
            var originatorValue = Storage.Get(Storage.CurrentContext, originator);
            var targetValue = Storage.Get(Storage.CurrentContext, to);
            
            
            BigInteger nOriginatorValue = BytesToInt(originatorValue) - amount;
            BigInteger nTargetValue = BytesToInt(targetValue) + amount;
            
            //If the transaction is valid, proceed.
            //如果交易有效，继续
            if (nOriginatorValue >= 0 &&
                amount >= 0)
            {
                Storage.Put(Storage.CurrentContext, originator, IntToBytes(nOriginatorValue));
                Storage.Put(Storage.CurrentContext, to, IntToBytes(nTargetValue));
                Runtime.Notify("Transfer Successful", originator, to, amount, Blockchain.GetHeight()); 
                return true;
            }
            return false;
        }

       
        private static byte[] IntToBytes(BigInteger value)
        {
            byte[] buffer = value.ToByteArray();
            return buffer;
        }
        
  
        private static BigInteger BytesToInt(byte[] array)
        {
            var buffer = new BigInteger(array);
            return buffer;
        }

        
    }
}

```

