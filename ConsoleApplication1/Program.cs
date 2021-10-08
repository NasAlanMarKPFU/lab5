using System;
namespace ConsoleApplication1
{
    internal class Program
    {
        public static void zd1()
        {
            Console.Write("a = ");
            var a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            var b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            var c = double.Parse(Console.ReadLine());

            double x1, x2;
            var discriminant = b*b - 4 * a * c;
            if (discriminant < 0)
            {
                Console.WriteLine("no roots");
            }
            else
            {
                if (discriminant == 0) 
                {
                    x1 = -b / (2 * a);
                    x2 = x1;
                }
                else 
                {
                    x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                }
                Console.WriteLine($"x1 = {x1}; x2 = {x2}");
            }
        }

        public static void zd2()
        {
            Random rnd = new Random();
            int[] mass = new int[20];
            for (int i = 0; i < 20; i++)
            {
                mass[i] = rnd.Next();
            }

            Console.Write("postion 1 : ");
            int pos1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("postion 2 : ");
            int pos2 = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 20; i++)
            {
                Console.Write(mass[i] + " ");
            }

            Console.WriteLine();
            int tmp = mass[pos1];
            mass[pos1] = mass[pos2];
            mass[pos2] = tmp;
            for (int i = 0; i < 20; i++)
            {
                Console.Write(mass[i] + " ");
            }

        }

        static void zd3(int[] mass)
        {
            int temp;
            for (int i = 0; i < mass.Length - 1; i++)
            {
                for (int j = 0; j < mass.Length - i - 1; j++)
                {
                    if (mass[j + 1] < mass[j])
                    {
                        temp = mass[j + 1];
                        mass[j + 1] = mass[j];
                        mass[j] = temp;
                    }
                }
            }
            
        }
        public static int zd4(params int[] mass)
        {
            int sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }

            return sum;
        }

        public static void zd31()
        {
            Random rnd = new Random();
            int[] mass = new int[20];
            for (int i = 0; i < 20; i++)
            {
                mass[i] = rnd.Next(500);
            }
            zd3(mass);
            for (int i = 0; i < 20; i++)
            {
                Console.Write(mass[i] + " ");
            }
            
        }

        public static double zd4(ref double op, out double average,params double[] mass)
        {
            double sum = 0;
            op = 1;
            average = mass.Length;
            if (average == 0)
                return sum;
            for (int i = 0; i < average; i++)
            {
                sum += mass[i];
                op *= mass[i];

            }

            average = sum / average;
            return sum;
        }

        public static void zd5()
        {
            string[] digital = new string[]{
                "#####\n#   #\n#   #\n#   #\n#####\n",
                "##\n  # #\n #  #\n    #\n    #\n    #\n",
                "#####\n    #\n#####\n#\n#####\n",
                "#####\n    #\n#####\n    #\n#####\n",
                "#   #\n#   #\n#####\n    #\n    #\n",
                "#####\n#    \n#####\n    #\n#####\n",
                "#####\n#    \n#####\n#   #\n#####\n",
                "#####\n    #\n  ###\n  #  \n #   \n",
                "#####\n#   #\n#####\n#   #\n#####\n",
                "#####\n#   #\n#####\n    #\n#####\n"

            };
            Console.Write("input : ");
            string str = Console.ReadLine();
            if (str == "exit" || str == "закрыть")
                return;
            try
            {
                int num = int.Parse(str);
                if (str.Length != 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("error");
                    System.Threading.Thread.Sleep(3000);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(digital[num]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        

        public static void Main(string[] args)
        {


           
        }
    }
}