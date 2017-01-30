using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            DESAlgorithm des = new DESAlgorithm();

            Console.Write("암호화 할 문자열: ");
            string plainText = Console.ReadLine();

            Console.Write("키: ");
            string key = Console.ReadLine();

            long key64 = BitConverter.ToInt64(Encoding.Unicode.GetBytes(key).ToArray(), 0);
            var subkeys = des.GenerateSubkeys(key64);

            for(int i=0; i<16; i++)
            {
                Console.WriteLine(i + 1 + "라운드 서브 키: " + Convert.ToString(subkeys[i], 16));
            }

            //long[] encs = des.Encrypt("Data Encryption Standard Test. ABCD 가나다라 加羅多", subkeys);
            long[] encs = des.Encrypt(plainText, subkeys);
            foreach (var enc in encs)
            {
                Console.WriteLine("암호문(Hex): " + Convert.ToString(enc, 16));
            }
            
            Console.WriteLine("암호문: " + encs.ToUnicodeString());

            var decs = des.Decrypt(encs, subkeys);
            Console.WriteLine("복호문: " + decs.ToUnicodeString());

        }

        
    }
}
