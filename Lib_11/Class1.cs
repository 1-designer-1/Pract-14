using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_11
{
    public class Class1
    {
        /// <summary>
        /// Проверяет строки массива на условие 
        /// </summary>
        public List <int> JobArrey(int[,] array)
        {
            List<int> mass = new List<int>();
            int sum = 0;
            for (int i = 1; i < array.GetLength(1); i += 2)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                   sum += array[j, i];
                 
                }

                mass.Add(sum);
                sum = 0;
            }
            
            return mass;

        }


    }
}
