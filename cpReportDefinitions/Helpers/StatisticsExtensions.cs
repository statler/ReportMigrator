using System;
using System.Collections.Generic;
using System.Linq;

namespace cpReportDefinitions.Helpers
{
    public static class StatisticsExtensions
    {
        /// <summary>
        /// Computes Standard Deviation
        /// </summary>
        /// <param name="values">List of doubles</param>
        /// <remarks>Standard Deviation for input list</remarks>
        public static double StandardDeviationSample(this List<double> values)
        {
            double mean = values.Average();
            List<double> temp = values.Select(val => Math.Pow(val - mean, 2)).ToList();
            return Math.Sqrt(temp.Sum() / (temp.Count - 1));
        }

        public static float StandardDeviationSample(this List<float> values)
        {
            float mean = values.Average();
            List<float> temp = values.Select(val => (float)Math.Pow(val - mean, 2)).ToList();
            return (float)Math.Sqrt(temp.Sum() / (temp.Count - 1));
        }
    }
}
