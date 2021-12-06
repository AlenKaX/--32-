using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ПР11
{
    struct Igrushki
    {
        public string nazv;
        public Double price;
        public string vozr1;
        public string vozr2;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (i != 7)
            {
                Console.WriteLine("Выберите необходимый пункт");
                Console.WriteLine();
                Console.WriteLine("1. Ввод информации об игрушках");
                Console.WriteLine("2. Получить названия и стоимость игрушек для указанного возраста");
                Console.WriteLine("3. Получить минимальную стоимость указанной игрушки");
                Console.WriteLine("4. Получить количество игрушек с указанным названием");
                Console.WriteLine("5. Получить среднюю стоимость определенного товара");
                Console.WriteLine("6. Вывод всей информации");
                Console.WriteLine("7. Выход");
                i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Vvod();
                        break;
                    case 2:
                        Nazv();
                        break;
                    case 3:
                        Min();
                        break;
                    case 4:
                        Kol();
                        break;
                    case 5:
                        Sr();
                        break;
                    case 6:
                        Vivod();
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Такого пункта нет");
                        break;
                }
            }
            Console.ReadKey();
        }
        static void Vvod()
        {
            FileStream f = new FileStream("D://Assort.txt", FileMode.Append);
            StreamWriter w = new StreamWriter(f);
            Igrushki I;
            Console.Write("Введите название игрушки: ");
            I.nazv = Console.ReadLine();
            I.nazv = I.nazv.Replace(" ", "_");
            Console.Write("Введите цену игрушки: ");
            I.price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите нижнюю границу возрастных ограничений игрушки: ");
            I.vozr1 = Console.ReadLine();
            Console.Write("Введите верхнюю границу возрастных ограничений игрушки: ");
            I.vozr2 = Console.ReadLine();
            String s = I.nazv + " " + I.price + " " + I.vozr1 + " " + I.vozr2;
            w.WriteLine(s);
            w.Close();
        }
        static void Nazv()
        {
            int i, max, min;
            string s;
            FileStream f = new FileStream("d://Assort.txt", FileMode.Open);
            StreamReader r = new StreamReader(f);
            Console.WriteLine();
            Console.WriteLine("Введите возраст");
            Console.WriteLine();
            i = Convert.ToInt32(Console.ReadLine());
            while (!r.EndOfStream)
            {
                s = r.ReadLine();
                string[] w = s.Split(new char[] { ' ' });
                min = Convert.ToInt32(w[2]);
                max = Convert.ToInt32(w[3]);
                if ((i > min) && (i < max))
                {
                    string c = w[0].Replace("_", " ");
                    Console.WriteLine(c + " " + w[1]);
                }
            }
            Console.WriteLine();
            r.Close();
        }
        static void Min()
        {
            string s, c;
            int i = 0, k;
            Double a = 999999;
            Double[] j = new Double[9999];
            FileStream f = new FileStream("d://Assort.txt", FileMode.Open);
            StreamReader r = new StreamReader(f);
            Console.WriteLine();
            Console.Write("Введите название игрушки: ");
            c = Console.ReadLine();
            c = c.Replace(" ", "_");
            Console.WriteLine();
            while (!r.EndOfStream)
            {
                s = r.ReadLine();
                string[] w = s.Split(new char[] { ' ' });
                k = w[0].IndexOf(c);
                double h = Convert.ToDouble(w[1]);
                if (k >= 0)
                {
                    j[i] = h;
                    if (a >= j[i])
                        a = j[i];
                }
                i++;
            }
            Console.WriteLine("Минимальная стоимость: " + a);
            Console.WriteLine();
            r.Close();
        }
        static void Kol()
        {
            int k, i = 0;
            string c, s;
            FileStream f = new FileStream("d://Assort.txt", FileMode.Open);
            StreamReader r = new StreamReader(f);
            Console.WriteLine();
            Console.Write("Введите название игрушки: ");
            c = Console.ReadLine();
            c = c.Replace(" ", "_");
            Console.WriteLine();
            while (!r.EndOfStream)
            {
                s = r.ReadLine();
                string[] w = s.Split(new char[] { ' ' });
                k = w[0].IndexOf(c);
                if (k >= 0)
                    i++;
            }
            Console.WriteLine("Кол-во: " + i);
            Console.WriteLine();
        }
        static void Sr()
        {
            int k, i = 0;
            double d, dd = 0;
            string c, s;
            FileStream f = new FileStream("d://Assort.txt", FileMode.Open);
            StreamReader r = new StreamReader(f);
            Console.WriteLine();
            Console.Write("Введите название игрушки: ");
            c = Console.ReadLine();
            c = c.Replace(" ", "_");
            Console.WriteLine();
            while (!r.EndOfStream)
            {
                s = r.ReadLine();
                string[] w = s.Split(new char[] { ' ' });
                k = w[0].IndexOf(c);
                if (k >= 0)
                {
                    i++;
                    d = Convert.ToDouble(w[1]);
                    dd += d;
                }
                dd /= i;
            }
            Console.WriteLine("Cредняя стоимость: " + dd);
            Console.WriteLine();
        }
        static void Vivod()
        {
            Console.WriteLine();
            FileStream f = new FileStream("d://Assort.txt", FileMode.Open);
            StreamReader r = new StreamReader(f);
            while (!r.EndOfStream)
            {
                string s = r.ReadLine();
                s = s.Replace("_", " ");
                Console.WriteLine(s);
            }
            Console.WriteLine();
            r.Close();
        }
    }
}

