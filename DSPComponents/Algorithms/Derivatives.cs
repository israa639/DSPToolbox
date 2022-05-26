using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class Derivatives: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal FirstDerivative { get; set; }
        public Signal SecondDerivative { get; set; }

        public override void Run()
        {

            
             int size = InputSignal.Samples.Count();
            
            FirstDerivative = new Signal(new List<float>(), new List<int>(), InputSignal.Periodic, new List<float>(), new List<float>(), new List<float>());
            SecondDerivative = new Signal(new List<float>(), new List<int>(), InputSignal.Periodic, new List<float>(), new List<float>(), new List<float>());
        //first derivative
            for(int i=0;i<size;i++)
         {
             if (i == 0)
             {
                 continue;
             }
               

             FirstDerivative.Samples.Add(InputSignal.Samples[i]-InputSignal.Samples[i-1]);

         }
            //second derivative
            for (int i = 0; i < size; i++)
            {
                if (i == 0)
                {
                    SecondDerivative.Samples.Add(InputSignal.Samples[i + 1] - 2 * InputSignal.Samples[i] );

                    continue;
                }
                if(i==size-1)
                {
                    break;
                }
                SecondDerivative.Samples.Add(InputSignal.Samples[i+1] -2* InputSignal.Samples[i] + InputSignal.Samples[i-1]);

            }
        }
    }
}
