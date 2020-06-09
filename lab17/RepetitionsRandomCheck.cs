
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace lab17
{
    class RepetitionsRandomCheck
    {
        Random rnd = new Random();

        private double PreviousRandom = new double();

        private static RepetitionsRandomCheck Instance { get; set; }

        public static RepetitionsRandomCheck getInstance
        {
            get
            {
                if (Instance ==  null)
                {
                    Instance = new RepetitionsRandomCheck();
                    return Instance;
                }
                else
                {
                    return Instance;
                }
            }
        }

        public double GetNumb()
        {
            var Temp = rnd.NextDouble();
            while (Temp == Instance.PreviousRandom)
            {
                Temp = rnd.NextDouble();
            }
            Instance.PreviousRandom = Temp;
            return Temp;
        }

    }
}