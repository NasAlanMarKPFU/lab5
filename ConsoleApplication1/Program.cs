using System;
using System.Drawing;
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

        public static void zd51()
        {
            Console.WriteLine("Введите цифру от 0 до 9\n");
            int number_to_draw = Convert.ToInt32(Console.ReadLine());
 
 
            string[] paths = new string[] { @".\jpg",
                @"G:\coding\download\numbers\01.gif", @"G:\coding\download\numbers\02.gif",
                @"G:\coding\download\numbers\03.gif", @"G:\coding\download\numbers\04.gif",
                @"G:\coding\download\numbers\05.gif", @"G:\coding\download\numbers\06.gif",
                @"G:\coding\download\numbers\07.gif", @"G:\coding\download\numbers\08.gif",
                @"G:\coding\download\numbers\09.gif"};
 
            string path = paths[number_to_draw];
            Bitmap bitmap = new Bitmap(path);
            string result = "";
            for (int y = 0; y < bitmap.Height; y ++)
            {
                for (int x = 0; x < bitmap.Width; x ++)
                {
                    int pixelcolor = bitmap.GetPixel(x, y).R;
                    if (pixelcolor == 255)
                    {
                        result += "..";
                    }
                    else
                    {
                        result += "#";
                    }
                }
                result += "\n";
            }
 
            Console.WriteLine(result);
        }



        public static void zd5()
        {

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

                    Bitmap bitmap =
                        new Bitmap(@"C:\Users\lm\RiderProjects\ConsoleApplication1\ConsoleApplication1\error.jpg");
                    string result = "";
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {

                            int color = bitmap.GetPixel(x, y).R;
                            if (color <= 120)
                            {
                                result += " ";
                            }
                            else
                            {
                                result += "#";
                            }
                        }

                        result += "\n";
                    }


                    Console.WriteLine(result);
                    System.Threading.Thread.Sleep(3000);
                    Console.ResetColor();
                }
                else
                {
                    string[] digital = new string[]
                    {
                        @"C:\Users\lm\RiderProjects\ConsoleApplication1\ConsoleApplication1\0.jpg",
                        @"C:\Users\lm\RiderProjects\ConsoleApplication1\ConsoleApplication1\1.jpg",
                        @"C:\Users\lm\RiderProjects\ConsoleApplication1\ConsoleApplication1\2.jpg",
                        @"C:\Users\lm\RiderProjects\ConsoleApplication1\ConsoleApplication1\3.jpg",
                        @"C:\Users\lm\RiderProjects\ConsoleApplication1\ConsoleApplication1\4.jpg",
                        @"C:\Users\lm\RiderProjects\ConsoleApplication1\ConsoleApplication1\5.jpg",
                        @"C:\Users\lm\RiderProjects\ConsoleApplication1\ConsoleApplication1\6.jpg",
                        @"C:\Users\lm\RiderProjects\ConsoleApplication1\ConsoleApplication1\7.jpg",
                        @"C:\Users\lm\RiderProjects\ConsoleApplication1\ConsoleApplication1\8.jpg",
                        @"C:\Users\lm\RiderProjects\ConsoleApplication1\ConsoleApplication1\9.jpg"
                    };

                    Bitmap bitmap = new Bitmap(digital[num]);
                    string result = "";
                    for (int y = 0; y < bitmap.Height; y += 15)
                    {
                        for (int x = 0; x < bitmap.Width; x += 15)
                        {

                            int color = bitmap.GetPixel(x, y).R;
                            if (color >= 120)
                            {
                                result += " ";
                            }
                            else
                            {
                                result += "#";
                            }
                        }

                        result += "\n";
                    }


                    Console.WriteLine(result);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public static void Main(string[] args)
        {
            zd5();
        }
    }
}
