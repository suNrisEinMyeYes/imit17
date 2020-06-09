using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace lab17
{
    class Flow
    {
        float t0 = 0, La;
        int Count = 0;
        

        public Flow(float La)
        {

            this.La = La;
            
        }

        public float MoveForward()
        {

            var tNext = t0 + (-((float)Math.Log(RepetitionsRandomCheck.getInstance.GetNumb()) / La));
            var Tau = tNext - t0;
            t0 = tNext;
            return La * (float)Math.Pow(Math.E,(-La*Tau));

        }

        public float GetTime() => t0;

        public void CountPlus() => Count++;

        public int GetCount() => Count;
        
    }
}