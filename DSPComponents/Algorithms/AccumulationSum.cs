using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;


namespace DSPAlgorithms.Algorithms
{
    public class AccumulationSum : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            int size = InputSignal.Samples.Count();
            OutputSignal = new Signal(new List<float>(), InputSignal.Periodic);
            OutputSignal.Samples.Add(InputSignal.Samples[0]);
            for(int i=1;i<size;i++)
            {
                OutputSignal.Samples.Add(OutputSignal.Samples[i-1]+InputSignal.Samples[i]);
            }
        }
    }
}
