using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Поменьше говори - больше услышишь";
            string input2 = "Pomenshe govory - bolshe uslishish";
            HuffmanTree huffmanTree = new HuffmanTree();
            huffmanTree.Build(input2);
            BitArray encoded = huffmanTree.Encode(input2);
            string decoded = huffmanTree.Decode(encoded);
            Console.WriteLine("Huffman\n");
            Console.WriteLine("String : " + input2);
            Console.WriteLine("Decoded:\n" + decoded);
            Console.WriteLine("=======================\n");

            var lz= LZ77.Compress(input2);
            Console.WriteLine("LZ\n");
            for (int i = 0; i < lz.Count; i++)
                Console.WriteLine("" + lz[i] + "\t[" + input2[i] + "]\t" + Convert.ToString(lz[i],2));
            Console.WriteLine("=======================\n");
            //193 119 56 196 14 247 131 129 196 228 121 136 28 78 135 35 161 228 44 16 57 28 2 7 107 148 64 241 117 59 158 14 232 187 169 192 230 114 188 133 6 

            Console.ReadLine();
        }
    }
}
