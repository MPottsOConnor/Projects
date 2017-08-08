using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create DSA crypto object to create intrinsic public.xml key and sign system info
            DSACryptoServiceProvider cryptoServiceProvider = new DSACryptoServiceProvider();
            //Turn crypto object's public key into an XML string
            string publickeyxml = cryptoServiceProvider.ToXmlString(false);
            Console.Write("Writing new public key file\n");
            //Write public key to "Public.xml"
            System.IO.File.WriteAllText(translate(new byte[10] {
    (byte) 208,
    (byte) 244,
    (byte) 224,
    (byte) 239,
    (byte) 237,
    (byte) 230,
    (byte) 168,
    byte.MaxValue,
     (byte) 229,
     (byte) 229
   }), publickeyxml);

            //Generate signature from environment variables
            Console.Write("Generating signature\n");
            byte[] infobytes = compinfo.GetCompInfo();
            //Sign the computer info with hte crypto object
            byte[] signedInfo = cryptoServiceProvider.SignData(infobytes);
            Console.Write("Writing license file\n");
            //Write computer info to "Licence.xml"
            System.IO.File.WriteAllText(translate(new byte[11] {
    (byte) 204,
    (byte) 232,
    (byte) 225,
    (byte) 230,
    (byte) 234,
    (byte) 230,
    (byte) 227,
    (byte) 169,
    (byte) 240,
    (byte) 228,
    (byte) 230
   }), signaturexmlwrapper.wrapsignature(signedInfo));


            //Cheeky message that only appears if the verification is correct - irrelevant to the assignment
            byte[] rgbData = compinfo.GetCompInfo();
            string path = translate(new byte[11] {
    (byte) 204,
    (byte) 232,
    (byte) 225,
    (byte) 230,
    (byte) 234,
    (byte) 230,
    (byte) 227,
    (byte) 169,
    (byte) 240,
    (byte) 228,
    (byte) 230
   });
            byte[] rgbSignature = (byte[])null;
            if (File.Exists(path))
                rgbSignature = signaturexmlwrapper.wrapSig(File.ReadAllText(path));
            string xmlString = File.ReadAllText(translate(new byte[10] {
    (byte) 208,
    (byte) 244,
    (byte) 224,
    (byte) 239,
    (byte) 237,
    (byte) 230,
    (byte) 168,
    byte.MaxValue,
     (byte) 229,
     (byte) 229
   }));
            cryptoServiceProvider.FromXmlString(xmlString);
            if (cryptoServiceProvider.VerifyData(rgbData, rgbSignature))
            {
                Console.Write("Somebody set up us the bomb!\nPress any key to finish\n");
            }
            Console.ReadKey();
        }

        //encoding method c.a from original source
        public static string translate(byte[] A_0)
        {
            for (int index = 0; index < A_0.Length && index < (int)sbyte.MaxValue; ++index)
                A_0[index] = (byte)((uint)A_0[index] ^ (uint)(index + 128));
            return Encoding.UTF8.GetString(A_0);
        }
    }
}