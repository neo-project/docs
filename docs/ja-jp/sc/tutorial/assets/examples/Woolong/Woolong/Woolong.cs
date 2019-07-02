using System.ComponentModel;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System.Numerics;


namespace Woolong 
{
    public class Woolong : FunctionCode
    {

        /// <summary>
        ///   これはNEP5トークンの例です: Woolong
        ///   コントラクトが呼び出されるたびに1つのWoolongを生成します。
        /// 
        ///   以下のパラメータリストに注意してください:
        ///   パラメータリスト: 05
        ///   戻り値リスト: 05
        /// </summary>
        /// <param name="method">
        ///   呼び出されるNEP5のメソッド。
        /// </param>
        /// <param name="args">
        ///   NEP5の関数で使用されるオプションの入力パラメータ。
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

            //呼び出し元が正直であることを検証
            if (!Runtime.CheckWitness((byte[]) args[0])) return false;
            
            if (method == "transfer") return Transfer((byte[]) args[0], (byte[]) args[1], BytesToInt((byte[]) args[2]));
            
            return false;
        }


        /// <summary>
        ///   コントラクトが呼び出されるたびに1つのWoolongを生成します。
        /// </summary>
        private static void Grow(byte[] lllwvlvwlll)
        {          
            var value = BytesToInt(Storage.Get(Storage.CurrentContext, lllwvlvwlll)) + 1;
            Storage.Put(Storage.CurrentContext, lllwvlvwlll, IntToBytes(value));
            
            var supply = BytesToInt(Storage.Get(Storage.CurrentContext, "supply")) + 1;
            Storage.Put(Storage.CurrentContext, "supply", IntToBytes(supply));
        }

        /// <summary>
        ///   1の供給量でトークンをデプロイします。
        /// </summary>
        /// <param name="lllwvlvwlll">
        ///   私のアカウントです…
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
        ///   残高を他のアカウントへ転送します。
        /// </summary>
        /// <param name="originator">
        ///   コントラクトの呼び出し元
        /// </param>
        /// <param name="to">
        ///   転送先のアカウント
        /// </param>
        /// <param name="amount">
        ///   転送量
        /// </param>
        /// <returns>
        ///   トランザクションの成功可否
        /// </returns>
        private static bool Transfer(byte[] originator, byte[] to, BigInteger amount)
        {           
            //送信元と送信先のアカウントの値を取得
            var originatorValue = Storage.Get(Storage.CurrentContext, originator);
            var targetValue = Storage.Get(Storage.CurrentContext, to);
            
            
            BigInteger nOriginatorValue = BytesToInt(originatorValue) - amount;
            BigInteger nTargetValue = BytesToInt(targetValue) + amount;
            
            //トランザクションが有効な場合は続行
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
