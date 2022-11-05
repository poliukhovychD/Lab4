using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    

namespace Lab3
{
    internal class Program
    {
        static float Task1(int summa, int a, int b)
        {
            float probability = ((a + b) % summa);
            return probability;
        }

        static float Task3(int find, int another, int take)
        {
            float prob;
            int summa = find + another;

            prob = FindC(take, another) / FindC(take, summa);
            prob = 1 - prob;

            return prob;
        }

        static float Task4(float a, float b, float c, float d)
        {
            float summa = a + b + c + d;
            float probability = 1 - summa;
            return probability;
        }

        static double Adopov(float m, float n)
        {
            double result = Math.Pow(n, m);
            return result;
        }

        static double Task5(float all, float find, float take)
        {
            double prob = Adopov(take, find) / Adopov(take, all);
            return prob;
        }

        static float Task6(float prob1, float prob2)
        {
            float prob = prob1 * prob2;
            return prob;
        }

        private static long Fact(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * Fact(n - 1);
        }

        static float FindC(int m, int n)
        {
            float C;
            C = Fact(n) / (Fact(m) * Fact(n - m));
            return C;
        }

        static float Task2()
        {
            float prob = FindC(2, 8) / FindC(2, 10);
            return prob;
        }

        static float Task7(int vidminno, int dobre, int sered, int pogano, int vidminput, int dobreput, int seredput, int poganoput, string asked)
        {
            float summaput = vidminput;
            float summastud = vidminno + dobre + sered + pogano;

            float vidminprob = Help7(vidminno, vidminput, summaput, summastud);
            float dobreprob = Help7(dobre, dobreput, summaput, summastud);
            float seredprob = Help7(sered, seredput, summaput, summastud);
            float poganoprob = Help7(pogano, poganoput, summaput, summastud);

            float proball = vidminprob + dobreprob + seredprob + poganoprob;

            switch (asked)
            {
                case "vidminno":
                    vidminprob /= proball;
                    return vidminprob;
                case "dobre":
                    dobreprob /= proball;
                    return dobreprob;
                case "sered":
                    seredprob /= proball;
                    return seredprob;
                case "pogano":
                    poganoprob /= proball;
                    return poganoprob;
                default:
                    return 0;
            }
        }
        static float Help7(int studamount, int questinamount, float summaput, float summastud)
        {
            float probstud = (studamount / summastud) * (questinamount / summaput) * (questinamount - 1) / (summaput - 1) * (questinamount - 2) / (summaput - 2);
            return probstud;
        }
        static float Task8_9_10(float firstperc, float secondperc, float thirdperc, float firstprob, float secondprob, float thirdprob, int take)
        {
            float answer = firstperc  * firstprob + secondperc  * secondprob + thirdperc * thirdprob;

            if (take == 1)
                return (firstperc * firstprob) / answer;
            else if (take == 2)
                return (secondperc * secondprob) / answer;
            else if (take == 3)
                return (thirdperc * thirdprob) / answer;
            else
                return answer;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            float prob = Task1(100, 22, 12);
            Console.WriteLine("Probability for task #1 is: " + prob + "%");

            float prob2 = Task2();
            Console.WriteLine("Probability for task #2 is: " + prob2 + " or " + prob2 * 100 + "%");

            float prob3 = Task3(2, 8, 3);
            Console.WriteLine("Probability for task #3 is: " + prob3 + " or " + Math.Round(prob3 * 100) + "%");

            float prob4 = Task4(0.15f, 0.25f, 0.2f, 0.1f);
            Console.WriteLine("Probability for task #4 is: " + prob4 + " or " + prob4 * 100 + "%");

            double prob5 = Task5(120, 80, 2);
            Console.WriteLine("Probability for task #5 is: " + Math.Round(prob5 * 100) + "%");

            float prob6 = Task6(0.9f, 0.8f);
            Console.WriteLine("Probability for task #6 is: " + prob6 + " or " + prob6 * 100 + "%");

            float prob7_1 = Task7(3, 4, 2, 1, 20, 16, 10, 5, "vidminno");
            Console.WriteLine("Probability for task #7(vidminno) is ≈ " + prob7_1 + " or " + Math.Round(prob7_1 * 100) + "%");
            float prob7_2 = Task7(3, 4, 2, 1, 20, 16, 10, 5, "pogano");
            Console.WriteLine("Probability for task #7(pogano) is ≈ " + prob7_2 + " or " + prob7_2 * 100 + "%");

            float prob8 = Task8_9_10(0.4f, 0.3f, 0.3f, 0.9f, 0.95f, 0.95f, 0);
            Console.WriteLine("Probability for task #8 is: " + prob8 + " or " + prob8 * 100 + "%");

            float prob9 = Task8_9_10(0.4f, 0.3f, 0.3f, 0.8f, 0.7f, 0.85f, 2);
            Console.WriteLine("Probability for task #9 is ≈ " + prob9 + " or " + prob9 * 100 + "%");

            float prob10 = Task8_9_10(0.3f, 0.7f, 0, 0.9f, 0.8f, 0, 1);
            Console.WriteLine("Probability for task #10 is ≈ " + prob10 + " or " + prob10 * 100 + "%");

            Console.ReadLine();
        }
    }
}
