using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Program
    {
        public static List<string> DivideOnSubstring2(string s, int stepSize)
        {
            List<string> ans = new List<string>();
            int start = 0;
            bool flag = false;
            do
            {
                ans.Add(s.Substring(start, stepSize));
                start += stepSize;
                if (stepSize > s.Length - start) flag = true;
            } while (!flag);
            ans.Add(s.Substring(start, s.Length - start));
            return ans;
        }
        static void Main(string[] args)
        {
            int r;
            string parol = string.Empty;
            var rnd = new Random();
            Console.WriteLine("Выберите цифру нужного регистра: 1.А; 2.а; 3.А+а; 4.любой");
            var reg = Console.ReadLine();
            Console.WriteLine("Вам нужен пароль только из цифр? 1.да; 2.нет");
            var cifra = Console.ReadLine();
            Console.WriteLine("Вам нужны спецсимволы в пароле? 1.да; 2.нет");
            var specsymbol = Console.ReadLine();
            Console.WriteLine("Выберите раскладку: 1.RUS; 2.ENG");
            var yazyk = Console.ReadLine();
            string sbor = reg + cifra + specsymbol + yazyk;
            Console.WriteLine("Введите количество символов в пароле");
            int dlina = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество паролей");
            int colvo = Convert.ToInt32(Console.ReadLine());
            char[] symbol_mal_a = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            char[] symbol_bol_a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            char[] symbol_mal_bol_a = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            char[] symbol_mal_bol_a_spec = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^*()_+".ToCharArray();
            char[] symbol_mal_a_spec = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^*()_+".ToCharArray();
            char[] symbol_bol_a_spec = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            char[] symbol_cif = "0123456789".ToCharArray();
            char[] symbol_cif_spec = "0123456789!@#$%^*()_+".ToCharArray();
            char[] symbol_mal_r = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789".ToCharArray();
            char[] symbol_bol_r = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789".ToCharArray();
            char[] symbol_mal_bol_r = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789".ToCharArray();
            char[] symbol_mal_bol_r_spec = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789!@#$%^*()_+".ToCharArray();
            char[] symbol_mal_r_spec = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789!@#$%^*()_+".ToCharArray();
            char[] symbol_bol_r_spec = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789!@#$%^*()_+".ToCharArray();
            if (dlina < 6)
            {
                Console.WriteLine("Запустите программу снова и введите число символов в пароле больше 6");
            }
            for (int a = 0; a < colvo; a++)
            {
                switch (sbor)
                {
                    case "1222": //большой регистр, не только цифры, без спецсимволов, англ
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_bol_a.Length);
                            parol += symbol_bol_a[r];
                        }
                        
                        break;
                    case "2222": // малый регистр, не только цифры, без спецсимволов, англ
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_mal_a.Length);
                            parol += symbol_mal_a[r];
                        }
                        break;
                    case "3222":
                    case "4222":  //большой и малый регистр, не только цифры, без спецсимволов, англ
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_mal_bol_a.Length);
                            parol += symbol_mal_bol_a[r];
                        }
                        break;
                    case "1221": //большой регистр, не только цифры, без спецсимволов, рус
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_bol_r.Length);
                            parol += symbol_bol_r[r];
                        }
                        break;
                    case "2221": // малый регистр, не только цифры, без спецсимволов, рус
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_mal_r.Length);
                            parol += symbol_mal_r[r];
                        }
                        break;
                    case "3221":
                    case "4221": //большой и малый регистр, не только цифры, без спецсимволов, рус
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_mal_bol_r.Length);
                            parol += symbol_mal_bol_r[r];
                        }
                        break;
                    case "1212": //большой регистр, не только цифры, спецсимволы, англ
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_bol_a_spec.Length);
                            parol += symbol_bol_a_spec[r];
                        }
                        break;
                    case "2212": //малый регистр, не только цифры, спецсимволы, англ
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_mal_a_spec.Length);
                            parol += symbol_mal_a_spec[r];
                        }
                        break;
                    case "3212":
                    case "4212": //большой и малый регистр, не только цифры, спецсимволы, англ
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_mal_bol_a_spec.Length);
                            parol += symbol_mal_bol_a_spec[r];
                        }
                        break;
                    case "1211": //большой регистр, не только цифры, спецсимволы, рус
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_bol_r_spec.Length);
                            parol += symbol_bol_r_spec[r];
                        }
                        break;
                    case "2211": //малый регистр, не только цифры, спецсимволы, рус
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_mal_r_spec.Length);
                            parol += symbol_mal_r_spec[r];
                        }
                        break;
                    case "3211":
                    case "4211": //большой и малый регистр, не только цифры, спецсимволы, рус
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_mal_bol_r_spec.Length);
                            parol += symbol_mal_bol_r_spec[r];
                        }
                        break;
                    case "1121":
                    case "1122":
                    case "2121":
                    case "2122":
                    case "3121":
                    case "3122":
                    case "4121":
                    case "4122": //только цифры без спец
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_cif.Length);
                            parol += symbol_cif[r];
                        }
                        break;
                    case "1111":
                    case "1112":
                    case "2111":
                    case "2112":
                    case "3111":
                    case "3112":
                    case "4111":
                    case "4112": // цифры и спец
                        for (int i = 0; i < dlina; i++)
                        {
                            r = rnd.Next(symbol_cif_spec.Length);
                            parol += symbol_cif_spec[r];
                        }
                        break;

                };
                
            }
           
            List<string> otherStrings = DivideOnSubstring2(parol, dlina);
            foreach (var S in otherStrings)
            {
                Console.WriteLine(S);
            }
            Console.ReadLine();


        }
    }
}