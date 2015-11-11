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
            string s = "TO BE OR NOT TO BE OR TO BE OR NOT";
            int length_leter = 0;
            char[] leters = new char[34];
            int[] col = new int[34];
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
            Console.WriteLine("Количество символов в первичном алфавите 26");
            Console.WriteLine("Количество символов в сообщении {0}, число различных символов в сообщении {1}",s.Length,length_leter);
            Console.WriteLine("Исходная таблица");
            for(int i=0; i<length_leter; i++)
            {
                Console.WriteLine("буква {0} | кол-во {1}", leters[i], col[i]);
            }
            Console.WriteLine("----------------");
            
            double I;
            double[] freq = new double[34];
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
                Console.WriteLine("буква {0} | частота {1:0.000}", leters[i], freq[i]);
            }
            Console.WriteLine("----------------");
            I = sum * s.Length;
            double H = sum / Math.Log(26,2);
            Console.WriteLine("Максимальная энтропия {0}", Math.Log(33, 2));
            Console.WriteLine("Количество информации = {0:0.000}\nЭнтропия - {1:0.000}\nИзбыточность = {2:0.000}", I, sum, 1 - H);
            Console.WriteLine("----------------");

            Console.WriteLine("Таблица кодов ДК");
            string[] codeDK = new string[34];
            for (int i = 0; i < length_leter; i++)
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
                Console.WriteLine("буква {0} | частота {1:0.000}", leters[i], freq[i]);
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
            Console.WriteLine("----------------");
            double[,] arifm = new double[34,2];
            Console.WriteLine("Арифметический код");
            double niz = 0.0;
            for (k = 0; k < length_leter; k++)
            {
                arifm[k, 0] = niz;
                arifm[k, 1] = freq[k] + niz;
                niz += freq[k];
            }
            for (int i = 0; i < length_leter; i++)
            {
                Console.WriteLine("буква {0} | нижняя граница {1:0.000} | верхняя граница {2:0.000}", leters[i], arifm[i, 0], arifm[i, 1]);
            }
            Console.WriteLine("----------------");
            Console.WriteLine("Кодирование арифметическим кодом");
            double[,] arifm_code = new double[35, 2];
            
            int length_leter2 = 0;
            char[] leters2 = new char[34];
            int[] col2 = new int[34];
            for (int i = 0; i < s.Length; i++)
            {
                int flag = 0;
                for (int j = 0; j < length_leter2; j++)
                    if (s[i] == leters2[j])
                    {
                        col2[j]++;
                        flag = 1;
                        break;
                    }
                if (flag == 0)
                {
                    leters2[length_leter2] = s[i];
                    col2[length_leter2] = 1;
                    length_leter2++;
                }
            }
            double[] freq2 = new double[34];
            for (int i = 0; i < length_leter; i++)
            {
                freq2[i] = (double)col2[i] / s.Length;
            }

            arifm_code[0, 0] = 0;
            arifm_code[0, 1] = 1;
            int count = 1;
            for (int i = 0; i < 8; i++)
            {
                arifm_code[count, 0] = arifm_code[count - 1, 0] + (arifm_code[count - 1, 1] - arifm_code[count - 1, 0]) * arifm[i, 0];
                arifm_code[count, 1] = arifm_code[count - 1, 0] + (arifm_code[count - 1, 1] - arifm_code[count - 1, 0]) * arifm[i, 1];
                count++;
            }
            Console.WriteLine("буква {0} | нижняя граница {1:0.000} | верхняя граница {2:0.000}", ' ', arifm_code[0, 0], arifm_code[0, 1]);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("буква {0} | нижняя граница {1:0.000000000000} | верхняя граница {2:0.000000000000}", leters2[i], arifm_code[i + 1, 0], arifm_code[i + 1, 1]);
            }
            Console.WriteLine("----------------");
            Console.WriteLine("Вероятности появления в закодированной строке");
            string codde = "0000000001000100001100100001010011000011";
            int p1=0, p0=0;
            for (int i = 0; i < codde.Length; i++)
                if (codde[i] == '1')
                    p1++;
                else
                    p0++;
            Console.WriteLine("'0' {0}/" + codde.Length + " | '1' {1}/" + codde.Length, p0, p1);
            Console.WriteLine("----------------");
            Console.Read();


        }
    }
}