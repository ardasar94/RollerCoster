using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerCoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int l, c, n;
            int totalMoney = 0;
            Console.WriteLine("Please enter the number of places(L), number of times per day(C), Number of groups(N) with that order and a space between them and following these rules 1 ≤ L ≤ 10^7 , 1 ≤ C ≤ 10 ^ 7 , 1 ≤ N ≤ 1000");
            string basics = Console.ReadLine();
            string basicsCheck = basics.Replace(" ", "");

            List<string> basicsList = basics.Split(' ').ToList();
            if (!isInt(basicsCheck) || basicsList.Count != 3)
            {
                Console.WriteLine("You should enter the nums with given rules");
                return;
            }

            l = Convert.ToInt32(basicsList[0]);
            c = Convert.ToInt32(basicsList[1]);
            n = Convert.ToInt32(basicsList[2]);

            if (l < 1 || l > Math.Pow(10, 7) || c < 1 || c > Math.Pow(10, 7) || n < 1 || n > 1000)
            {
                Console.WriteLine("You should enter the nums with given rules");
                return;
            }

            List<int> groups = new List<int>();
            Console.WriteLine($"The a group size cannot be larger than 10^7 or L.");
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine($"Please enter {j + 1}'st gruop size");
                string x = Console.ReadLine();
                if (!isInt(x) || Convert.ToInt32(x) > l || Convert.ToInt32(x) > l || Convert.ToInt32(x) > Math.Pow(10, 6))
                {
                    Console.WriteLine("You should enter the nums with given rules");
                    Environment.Exit(0);
                }
                groups.Add(Convert.ToInt32(x));
            }

            for (int i = 0; i < c; i++)
            {
                totalMoney += CheckOneRide(groups, l);
            }

            Console.WriteLine("TotalEarned Money: " + totalMoney);
            Console.ReadLine();
        }
        static bool isInt(string x)
        {
            int z;
            bool bNum = int.TryParse(x, out z);
            return bNum;
        }

        private static int CheckOneRide(List<int> groups, int L)
        {
            int multiply = 0;
            int oneGroupSize = 0;
            foreach (var item in groups)
            {
                if (oneGroupSize + item > L)
                {
                    for (int i = 0; i < multiply; i++)
                    {
                        int x = groups[0];
                        for (int j = 1; j < groups.Count; j++)
                        {
                            groups[j - 1] = groups[j];
                        }
                        groups[groups.Count - 1] = x;
                    }

                    return oneGroupSize;
                }
                oneGroupSize += item;
                multiply++;
            }
            return oneGroupSize;
        }
    }
}
