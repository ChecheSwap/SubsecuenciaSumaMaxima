using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsecsum.ROUTINES
{
    static class rutinasX
    {
        public static int xprotoOne(ref int[] a)
        {
            int MaxSum = 0;
            for (int i = 0; i < a.Length; ++i)
            {
                for (int j = i; j < a.Length; ++j)
                {
                    int SumaActual = 0;
                    for (int k = i; k <= j; ++k)
                    {
                        SumaActual += a[k];
                    }
                    if (SumaActual > MaxSum)
                        MaxSum = SumaActual;
                }
            }
            return MaxSum;
        }

        public static int xprotoTwo(ref int[] a)
        {
            //orden n^2
            int MaxSum = 0;
            for (int i = 0; i < a.Length; ++i)
            {
                int SumaActual = 0;
                for (int j = i; j < a.Length; ++j)
                {
                    SumaActual += a[j];

                    if (SumaActual > MaxSum)
                        MaxSum = SumaActual;
                }
            }

            return MaxSum;
        }

        public static int xprotoThree(ref int[] arr)
        {
            return xrecursiva(arr, 0, arr.Length - 1);
        }

        public static int xrecursiva(int[] a, int left, int right) //   n
        {
            // 
            if (left == right)
            {
                if (a[left] > 0)
                {
                    return a[left];
                }
                else
                {
                    return 0;
                }
            }
            int center = (left + right) / 2;

            int maxLeftSum = xrecursiva(a, left, center); //          n/2  
            int maxRightSum = xrecursiva(a, center + 1, right); //   n/2  

            int maxLeftBorderSum = 0, leftBorderSum = 0; //   c
            for (int i = center; i >= left; i--)       //    n/2
            {
                leftBorderSum += a[i]; //cc
                if (leftBorderSum > maxLeftBorderSum)
                {
                    maxLeftBorderSum = leftBorderSum;  //c
                }
            }
            int maxRightBorderSum = 0, rigthBorderSum = 0;
            for (int i = center + 1; i <= right; ++i)//    n/2
            {
                rigthBorderSum += a[i];
                if (rigthBorderSum > maxRightBorderSum)
                {
                    maxRightBorderSum = rigthBorderSum;
                }
            }
            //TODO calcular el maximo de los 3 numeros
            return getmax(ref maxLeftSum, ref maxRightSum, maxLeftBorderSum + maxRightBorderSum);
        }

        private static int getmax(ref int x, ref int y, int z)
        {
            int max = x;

            if (y > max)
            {
                max = y;
            }

            if (z > max)
            {
                max = z;
            }

            return max;
        }

        public static int xprotofour(ref int[] a){

            int summax = 0;
            int estasuma = 0;

            for(int j = 0; j<a.Length; ++j)
            {
                estasuma += a[j];

                if(estasuma > summax)
                {
                    summax = estasuma;
                }
                else if(estasuma < 0)
                {
                    estasuma = 0;
                }
            }

            return summax;
        }


    }
}
