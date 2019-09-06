using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LottoAPI.Helpers
{
    public static class CalculateLineResult
    {
        /// <summary>
        /// Calculates the result value for a ticket line
        /// </summary>
        /// <param name="lineValues"></param>
        /// <returns></returns>
        public static int GetResult(List<int> lineValues)
        {
            int summedValues = lineValues.Sum();

            if (summedValues == 2)
            {
                return 10;
            }

            if (lineValues.ElementAt(0) == lineValues.ElementAt(1) && lineValues.ElementAt(2) == lineValues.ElementAt(1))
            {
                return 5;
            }

            if (lineValues.ElementAt(0) != lineValues.ElementAt(1) && lineValues.ElementAt(0) != lineValues.ElementAt(2))
            {
                return 1;
            }
                        
            return 0;
        }
    }
}
