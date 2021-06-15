using System;

namespace TLVParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tlv data for Visa card:
            var tlvString = "57134854700300556994d24052012526900000898f8407a00000000310105f2a0208405f34010182020000950500000000009a032106159c01009f02060000000001009f0607a00000000310109f0702c0809f090200029f101206021103a020000a020000000000c0e0cfb99f1a0208409f21030924349f2608110454772f199e249f2701809f360200169f3704e20c43c59f3901079f6c0238005f2d047275656e9f03060000000000009f3501229f6e04207000009f33030008e8";
            
            var data = EmvTags.EmvTlvList.Parse(tlvString);
            var pan = data.FindFirst("57").Value.ToString();
            Console.WriteLine(pan);
            Console.ReadKey();//3 4 43
            //
        }

        private static Action<uint, byte[]> ProcessTlv()
        {
            return (tag, data) =>
            {
                Console.WriteLine($"Tag:{tag} Data:{data.ByteArrayToHexString()}");
            };
        }
        
    }
}
