using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Shifter : Algorithm
    {
        public Signal InputSignal { get; set; }
        public int ShiftingValue { get; set; }
        public Signal OutputShiftedSignal { get; set; }

        public override void Run()
        {
            OutputShiftedSignal = new Signal(new List<float>(), new List<int>(), InputSignal.Periodic, new List<float>(), new List<float>(), new List<float>());
            int size = InputSignal.Samples.Count();
            int x=1;
            if(InputSignal.Samples[0]>InputSignal.Samples[size-1])
            {
                x = -1;
            }
            for(int i=0;i<size;i++)
            {
               
                OutputShiftedSignal.SamplesIndices.Add( InputSignal.SamplesIndices[i]+(x*-1*ShiftingValue));
                
               
                OutputShiftedSignal.Samples .Add( InputSignal.Samples[i]);
            }
        
        }
    }
}
