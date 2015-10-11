using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITlab1
{
    class Program
    {
        static string Reverse(string s)
        {
            string str = s;
            if (str.Length < 5)
                for (int i = 0; i < 5 - s.Length; i++)
                    str += "0";
            return str;
        }
        
        static string Code(int code)
        {
            string str="";
            while(code > 1)
            {
                if (code % 2 == 0)
                    str += "0";
                else
                    str += "1";
                code = code >> 1;
            }
            if (code % 2 == 0)
                str += "0";
            else
                str += "1";
            return str;
        }

        static void Main(string[] args)
        {
            string s="Поменьше говори - больше услышишь";
            int length_leter = 0;
            char[] leters = new char[18];
            int[] col = new int[18];
            for(int i=0; i<s.Length; i++)
            {
                int flag = 0;
                for (int j = 0; j < length_leter; j++)
                    if(s[i] == leters[j])
                    {
                        col[j]++;
                        flag = 1;
                        break;
                    }
                if(flag == 0)
                {
                    leters[length_leter] = s[i];
                    col[length_leter] = 1;
                    length_leter++;
                }
            }
            Console.WriteLine(s);
            Console.WriteLine("Количество символов в первичном алфавите 33");
            Console.WriteLine("Количество символов в сообщении {0}, число различных символов в сообщении{1}",s.Length,length_leter);
            Console.WriteLine("Исходная таблица");
            for(int i=0; i<length_leter; i++)
            {
                Console.WriteLine("leter {0} | freq {1}", leters[i], col[i]);
            }
            Console.WriteLine("----------------");
            
            double I;
            double[] freq = new double[18];
            for (int i = 0; i < length_leter; i++)
            {
                freq[i] = (double)col[i] / s.Length;
            }
            double sum = 0;
            for (int i = 0; i < length_leter; i++)
            {
                sum += freq[i] * Math.Log(1.0 / freq[i], 2);
            }

            Console.WriteLine("Таблица частот");
            for (int i = 0; i < length_leter; i++)
            {
                Console.WriteLine("leter {0} | freq {1:0.000}", leters[i], freq[i]);
            }
            Console.WriteLine("----------------");
            I = sum * length_leter;
            double H = sum / Math.Log(33,2);
            Console.WriteLine("Количество информации = {0:0.000}\nЭнтропия - {1:0.000}\nИзбыточность = {2:0.000}", I, sum, 1 - H);
            Console.WriteLine("----------------");

            Console.WriteLine("Таблица кодов ДК");
            string[] codeDK = new string[18];
            for(int i=0; i<18; i++)
            {
                codeDK[i] = Code(i);
                codeDK[i] = Reverse(codeDK[i]);
                Console.WriteLine("буква {0}, код {1}", leters[i], codeDK[i]);
            }
            Console.WriteLine("----------------");

            for (int i = 0; i < freq.Length; i++)
            {
                for (int j = i + 1; j < freq.Length; j++)
                {
                    if (freq[i] < freq[j])
                    {
                        double temp = freq[i];
                        freq[i] = freq[j];
                        freq[j] = temp;
                        char temp2 = leters[i];
                        leters[i] = leters[j];
                        leters[j] = temp2;
                        int temp3 = col[i];
                        col[i] = col[j];
                        col[j] = temp3;
                        string temp4 = codeDK[i];
                        codeDK[i] = codeDK[j];
                        codeDK[j] = temp4;
                    }
                }
            }
            Console.WriteLine("Отсортированная таблица");
            for (int i = 0; i < length_leter; i++)
            {
                Console.WriteLine("leter {0} | freq {1:0.000}", leters[i], freq[i]);
            }
            Console.WriteLine("----------------");

            double summ = 0;
            int k = 0;
            for (k = 0; k < length_leter; k++)
            {
                summ += freq[k];
                if (summ > 0.5)
                {
                    summ -= freq[k];
                    break;
                }
            }
            Console.WriteLine("Сумма вероятностей в первой группе {0:0.000}",summ);
            Console.Read();
        }
    }
}
