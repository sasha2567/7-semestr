using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using System.Text;
using System.IO;

namespace HuffmanTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input =  "Поменьше говори - больше услышишь";
            string input2 = "TO BE OR NOT TO BE OR TO BE OR NOT?";
            HuffmanTree huffmanTree = new HuffmanTree();
            huffmanTree.Build(input2);
            BitArray encoded = huffmanTree.Encode(input2);
            string decoded = huffmanTree.Decode(encoded);
            Console.WriteLine("Huffman\n");
            Console.WriteLine("String : " + input2);
            Console.WriteLine("Encoded:\n" + decoded);
            Console.WriteLine("Decoded:\n" + decoded);
            Console.WriteLine("=======================\n");

            var lz= LZW.Compress(input2);
            Console.WriteLine("LZ77\n");
            for (int i = 0; i < lz.Count; i++)
                Console.WriteLine("" + lz[i] + "\t[" + input2[i] + "]\t" + Convert.ToString(lz[i],2));
            Console.WriteLine("=======================\n");
            Console.ReadLine();
        }
    }
}
