using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common
{
    public class MathHelper
    {
        public static int combinations(int m, int n)
        {
            if (m > n)
            {
                int temp = n;
                n = m;
                m = temp;
            }
            
            
            if (m == n)
            {
                return 1;
            }

            if (m == 0 || n == 0)
            {
                return 0;
            }

            int a = 1;
            for (int i = m+1; i <= n; i++)
            {
                a = a * i;
            }

            int b = 1;
            for (int i = 1; i <= (n-m); i++)
            {
                b = b * i;
            }
            return a/b;
        }
    }
}
