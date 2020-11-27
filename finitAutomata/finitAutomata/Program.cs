using System;
using System.Collections.Generic;
using System.IO;

namespace finitAutomata
{
    class Program
    {

        class Automata
        {
            string state = "A";
            Dictionary<String, String> D = new Dictionary<String, String>();

            public void setToDefault()
            {
                D.Clear();
            }

            public void prepare()
            {
                D.Add("A+", "B");
                D.Add("A-", "B");
                D.Add("Ad", "C");
                D.Add("Bd", "C");
                D.Add("Cd", "C");
            }

            public char convert(char c)
            {
                if (Char.IsDigit(c))
                {
                    return 'd';
                }
                return c;
            }

            public string delta(string st, char akt)
            {
                if (D.ContainsKey(st + convert(akt)))
                {
                    return D[st + convert(akt)];
                }
                return "Error";
            }

            public void main(string input)
            {
                prepare();
                int i = 0;
                while (i < input.Length && state != "Error")
                {
                    state = delta(state, input[i]);
                    i++;
                }

                if (state != "Error")
                {
                    Console.WriteLine("{0} helyes bemenet", input);
                }
                else
                {
                    Console.WriteLine("{0} helytelen bemenő adat. Hibás karakter található a {1}. helyen", input, i);
                }
                state = "A";
                i = 0;
                setToDefault();
            }
        }

        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            StreamReader sr = new StreamReader("teszt.txt");
            string seged = "";
            while (!sr.EndOfStream)
            {
                seged += sr.ReadLine();
            }
            String[] array = seged.Split(' ');
            Automata A = new Automata();

            for (int i = 0; i < array.Length; i++)
            {
                A.main(array[i]);
            }
            Console.ReadLine();
        }
    }
}
