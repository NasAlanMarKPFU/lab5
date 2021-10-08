using System;

namespace metodichka
{
    internal class Program
    {
        public static int max(int a, int b)
        {
            return a > b ? a : b;
        }

        public static void swap(ref int a, ref int b)
        {
            a += b;
            b = a - b;
            a = a - b;
        }

        public static bool factI(int n, out int fact)
        {
            fact = 1;
            try
            {
                for (int i = 2; i <= n; i++)
                {
                    checked
                    {
                        fact *= i;
                    }
                }

            }
            catch (System.OverflowException e)
            {
                return false;
            }

            return true;
        }
        public static bool factStarR(int n, out int fact)
        {
            fact = 1;
            if (n == 0 || n == 1)
                return true;
            try
            {
                checked
                {
                    fact *= n;
                }
            }
            catch (System.OverflowException e)
            {
                return false;
            }
            return true && factR(n-1,ref fact);
        }
        public static bool factR(int n, ref int fact)
        {
            if (n == 0 || n == 1)
                return true;
            try
            {
                checked
                {
                    fact *= n;
                }
            }
            catch (System.OverflowException e)
            {
                return false;
            }
            return true && factR(n-1,ref fact);
        }
        public static int nod(int a, int b) 
        {
            while (b!=0) {
                a %= b;
                swap (ref a, ref b);
            }
            return a;
        }
        public static int nod(int a, int b,int c)
        {
            return nod(a, nod(b, c));
        }

        public static  int fibo(int num)
        {
            if (num == 1 || num ==0 )
                return 1; 
            return fibo(num-1) + fibo(num-2);
        }
        
        
        
        public static void Main(string[] args)
        {
            /*
            int n = 1000, fact;
            //if(factStarR(n,out fact))
            //if(factI(n,out fact))
                Console.WriteLine(fact);
            else
            {
                Console.WriteLine("false");
            }*/
            
        }
    }
}