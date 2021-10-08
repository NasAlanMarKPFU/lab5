using System;
using System.Collections.Generic;
namespace ConsoleApplication2
{
    internal class Program
    {
       
        public static void qSortR(int[] mass, int left, int right)
        {
            int pivot; 
            int lb = left; 
            int rb = right; 
            pivot = mass[left];
            while (left < right) 
            {
                while ((mass[right] >= pivot) && (left < right))
                    right--; 
                if (left != right) 
                {
                    mass[left] = mass[right]; 
                    left++; 
                }
                while ((mass[left] <= pivot) && (left < right))
                    left++; 
                if (left != right) 
                {
                    mass[right] = mass[left]; 
                    right--; 
                }
            }
            mass[left] = pivot; 
            pivot = left;
            left = lb;
            right = rb;
            if (left < pivot) 
                qSortR(mass, left, pivot - 1);
            if (right > pivot)
                qSortR(mass, pivot + 1, right);
        }
        public static void qSortI(int[] mass, int size) 
        {
 
            int i, j; 
            int lb, rb; 
 
            int[] lbstack = new int[1000];
            int[] rbstack = new int[1000];
            int stackpos = 1; 
            int ppos; 
            int pivot; 
            int temp;
 
            lbstack[1] = 0;
            rbstack[1] = size-1;
 
            do {

                lb = lbstack[ stackpos ];
                rb = rbstack[ stackpos ];
                stackpos--;
 
                do {
                    ppos = ( lb + rb ) >> 1;
                    i = lb; j = rb; pivot = mass[ppos];
                    do {
                        while ( mass[i] < pivot ) i++;
                        while ( pivot < mass[j] ) j--;
                        if ( i <= j ) {
                            temp = mass[i]; mass[i] = mass[j]; mass[j] = temp;
                            i++; j--;
                        }
                    } while ( i <= j );
 

                    if ( i < ppos ) { 
                        if ( i < rb ) { 
                            stackpos++; 
                            lbstack[ stackpos ] = i;
                            rbstack[ stackpos ] = rb;
                        }
                        rb = j; 

                    } else { 
                        if ( j > lb ) {
                            stackpos++;
                            lbstack[ stackpos ] = lb;
                            rbstack[ stackpos ] = j;
                        }
                        lb = i;
                    }
                } while ( lb < rb ); 
            } while ( stackpos != 0 ); 
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int[][] list_of_ribs(int len, int kol)
        {
            int[][] mass= new int[len][];
            for (int i = 0; i < len; i++)
            {
                mass[i] = new int[len];
            }
            string[] s;
            int first, second;
            for (int i = 0; i < kol; i++)
            {
                s = Console.ReadLine().Split(' ');
                first =Convert.ToInt32(s[0]);
                second = Convert.ToInt32(s[1]);
                mass[first-1][second-1] = 1;
                mass[second-1][first-1] = 1;

            }

            return mass;
        }

        public static int[][] list_of_compatibility(int len)
        {
            string[] s;
            int sum, now;
            int[][] mass= new int[len][];
            for (int i = 0; i < len; i++)
            {
                mass[i] = new int[len];
            }
            for (int i = 0; i < len; i++)
            {
                s = Console.ReadLine().Split(' ');
                sum =Convert.ToInt32(s[0]);
                for (int j = 1; j <=sum; j++)
                {
                    now = Convert.ToInt32(s[j]);
                    mass[i][now - 1] = 1;
                    mass[now - 1][i] = 1;

                }

            }
            return mass;
        }
      

        public static int[][] incidence_matrix(int len, int reb)
        {
            int[][] mass= new int[len][];
            int[][] mass_incid = new int[len][];
            string s;
            int first, second;

            for (int i = 0; i < len; i++)
            {
                mass[i] = new int[len];
                mass_incid[i] = new int[reb];
                s = Console.ReadLine(); 
                for (int j = 0; j < reb; j++)
                {
                    if (s[j] == '1')
                        mass_incid[i][j] = 1;
                }

            }

            for (int i = 0; i < reb; i++)
            {
                first = 0;
                second = 0;
                for (int j = 0; j < len; j++)
                {
                    if (mass_incid[j][i] == 1 && first == 0)
                    {
                        first = j;
                        
                    }else if (mass_incid[j][i] == 1 && first != 0)
                    {
                        second = j;
                    }
                }
                mass[first][second] = 1;
                mass[second][first] = 1;
            }
            

            return mass;
        }

        public static int[][] adjacency_matrix(int len)
        {
            int[][] mass= new int[len][];
            string s;
            for (int i = 0; i < len; i++)
            {
                mass[i] = new int[len];
                s = Console.ReadLine();
                for (int j = 0; j < len; j++)
                {

                    if (s[j] == '1')
                        mass[i][j] = 1;
                    else
                        mass[i][j] = 0;


                }

            }
            return mass;
        }

        public static void test1()
        {
            Random rnd = new Random();
            int[] mass = new int[20];
            for (int i = 0; i < 20; i++)
            {
                mass[i] = rnd.Next(500);
            }
            for (int i = 0; i < 20; i++)
            {
                Console.Write(mass[i]+" ");
            }
            Console.WriteLine();
            //qSortR(mass,0,mass.Length-1);
            qSortI(mass,mass.Length);
            for (int i = 0; i < 20; i++)
            {
                Console.Write(mass[i]+" ");
            }
        }

        public static Stack<int> dfs_way(int[][] mass, int len,int start,int end)
        {
            Stack<int> way = new Stack<int>();
            int[] visit = new int[len];
            visit[start] = 1;
            int now =start;
            way.Push(start);
            while (way.Count!=0) 
            {
             
                for (int i = 0; i < len; i++)
                {
                    if (now == end)
                    {
                        return way;
                    }
                    if (mass[now][i] == 1 && visit[i] != 1)
                    {
                        visit[i] = 1;
                        way.Push(i);
                        now = i;
                        break;
                    }

                    if (i == len - 1)
                    {
                        way.Pop();
                        if (way.Count != 0)
                            now = way.Peek();
                        else
                            return way;
                    }
                        
                }
               
            }

            
            return way;
        }

        public static int[] bfs_way(int[][] mass, int len, int start, int end)
        {
            int[] roots = new int[len];
            int[] visit = new int[len];
            visit[start] = 1;
            roots[start] = -1;
            Queue<int> queue = new Queue<int>();
            int now;
            queue.Enqueue(start);
            while (queue.Count!=0)
            {
                now =queue.Dequeue();
                for (int i = 0; i < len; i++)
                {
                    if (now == end)
                    {
                        return roots;
                    }
                    if (mass[now][i] == 1 && visit[i] != 1)
                    {
                        
                        visit[i] = 1;
                        queue.Enqueue(i);
                        roots[i] = now;

                    }

                }

            }

            roots[start] = -2;
            return roots;

        }
        public static void test2()
        {
            int[][] mass;
            int num, len, reb,start,end;
            Console.WriteLine("1)adjacency_matrix\n2)incidence_matrix\n3)list_of_compatibility\n4)list_of_ribs");
            Console.Write("num :");
            num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.Write("graph vertices :");
                    len = Convert.ToInt32(Console.ReadLine());
                    mass = adjacency_matrix(len);
                    break;

                case 2:
                    Console.Write("graph vertices :");
                    len = Convert.ToInt32(Console.ReadLine());
                    Console.Write("graph reb :");
                    reb = Convert.ToInt32(Console.ReadLine());
                    mass = incidence_matrix(len, reb);
                    break;

                case 3:
                    Console.Write("graph vertices :");
                    len = Convert.ToInt32(Console.ReadLine());
                    mass = list_of_compatibility(len);
                    break;
                case 4:
                    Console.Write("graph vertices :");
                    len = Convert.ToInt32(Console.ReadLine());
                    Console.Write("graph reb :");
                    reb = Convert.ToInt32(Console.ReadLine());
                    mass = list_of_ribs(len, reb);
                    break;
                default:
                    Console.WriteLine("error");
                    return;
            }
            
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    Console.Write(mass[i][j] +" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("1)dfs\n2)bfs");
            Console.Write("num : ");
            num = Convert.ToInt32(Console.ReadLine());
            Console.Write("start : ");
            start = Convert.ToInt32(Console.ReadLine());
            Console.Write("end : ");
            end = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                Stack<int> stck = dfs_way(mass, len, end-1, start-1);
                if(stck.Count == 0)
                    Console.WriteLine("can't be way");
                else
                {
                    while (stck.Count!= 1)
                    {
                        Console.Write((stck.Pop()+1)+"->");
                        
                    }
                    Console.WriteLine(stck.Pop()+1);

                }
            }
            else
            {
                int[] roots = bfs_way(mass, len, end-1, start-1);
                if(roots[end-1]==-2)
                    Console.WriteLine("can't be way");
                else
                {
                    reb = start-1;
                    while (roots[reb]!=-1)
                    {
                        
                        Console.Write((reb+1)+"->");
                        reb = roots[reb];

                    }
                    

                    Console.WriteLine($"{end}");
                }
            }

        }
 
        
        public static void Main(string[] args)
        {
            
            test2();

        }
    }
}