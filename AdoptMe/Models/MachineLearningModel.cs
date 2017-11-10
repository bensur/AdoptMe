using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Accord.Controls;
using Accord.IO;
using Accord.Math;
using Accord.Statistics.Distributions.Univariate;
using Accord.MachineLearning.Bayes;

namespace AdoptMe.Models
{
    public class MachineLearningModel
    {
        /* Gender (Male=0,Female=1),
           Age (<18=0,18<<25=1,25<<40=2,40<=3),
           Location (Darom=0,Merkaz=1,Tzafon=2),
           Salary (<5000=0,5000<<10000=1,100000<=2)
        */
        private static double[][] LearningDataInputs =
        {
            new double[] { 0, 0, 0, 0},
            new double[] { 0, 1, 2, 2},
            new double[] { 1, 3, 1, 1},
            new double[] { 0, 1, 2, 2},
            new double[] { 1, 2, 2, 2},
            new double[] { 1, 1, 1, 1},
            new double[] { 1, 2, 2, 1},
            new double[] { 1, 2, 2, 1},
            new double[] { 0, 0, 1, 2},
            new double[] { 0, 2, 2, 1},
            new double[] { 0, 0, 2 ,0},
            new double[] { 0, 2, 1, 0},
            new double[] { 0, 1, 2, 2},
            new double[] { 0, 1, 1, 2},
            new double[] { 1, 1, 1, 2},
            new double[] { 1, 0, 2, 2},
            new double[] { 0, 3, 1, 2},
            new double[] { 1, 3, 2, 1},
            new double[] { 0, 2, 1, 1},
            new double[] { 1, 2, 2, 1},
            new double[] { 0, 3, 1, 0},
            new double[] { 0, 3, 1, 2},
            new double[] { 1, 2, 1, 2},
            new double[] { 0, 1, 2 ,1},
            new double[] { 0, 2, 1, 1},
            new double[] { 1, 2, 1, 0},
            new double[] { 0, 1, 2 ,1},
            new double[] { 0, 1, 0, 1}
        };
        /* Cat-0, Dog=1, Bunny=2, Other=3*/
        private static int[] LearningDataOutputs = new int[]
        {
            0, 0, 0, 0, 0, 0, 0,
            1, 1, 1, 1, 1, 1, 1,
            2, 2, 2, 2, 2, 2, 2,
            3, 3, 3, 3, 3, 3, 3
        };
        private NaiveBayes<NormalDistribution> bays = (new NaiveBayesLearning<NormalDistribution>()).Learn(LearningDataInputs, LearningDataOutputs);

        public string Decide(double[] input)
        {
            int descision = bays.Decide(input);
            switch (descision.ToString())
            {
                case "0":
                    return "Cat";
                case "1":
                    return "Dog";
                case "2":
                    return "Bunny";
                case "3":
                    return "Other";
                default:
                    return "Could not decide!";
            }
        }
    }
}