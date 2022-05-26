using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class MovingAverage : Algorithm
    {
        public Signal InputSignal { get; set; }
        public int InputWindowSize { get; set; }
        public Signal OutputAverageSignal { get; set; }
 
        public override void Run()
        {
            OutputAverageSignal = new Signal(new List<float>(), new List<int>(), InputSignal.Periodic, new List<float>(), new List<float>(), new List<float>());
            int size = InputSignal.Samples.Count();
            int k = InputWindowSize / 2;
            float sum = 0;
            for(int i=0;i<size;i++)
            {
                if (i < k)
                    continue;
                if (i + k > size - 1)
                    break;
                sum += InputSignal.Samples[i];
                for(int j=0;j<k;j++)
                {
                    if((i+j+1)<size)
                    { sum += InputSignal.Samples[i+j+1];}
                    if((i-j-1)>=0){
                    sum += InputSignal.Samples[i-j-1];}
                }
                sum /= InputWindowSize;

            
            OutputAverageSignal.Samples.Add(sum);
            sum = 0;
            }
        }
    }
}
