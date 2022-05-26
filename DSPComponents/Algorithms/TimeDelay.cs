using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
     
    public class TimeDelay:Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public float InputSamplingPeriod { get; set; }
        public float OutputTimeDelay { get; set; }
        public void Set_signal(Signal InputSignal1, Signal InputSignal2)
        {

            for (int j = 0; j < InputSignal1.Samples.Count; j++)
            {
                InputSignal2.Samples.Add(InputSignal1.Samples[j]);
                InputSignal2.SamplesIndices.Add(InputSignal1.SamplesIndices[j]);
            }
        }
        public override void Run()
        {
            DirectCorrelation dc = new DirectCorrelation();
            dc.InputSignal1 = new Signal(new List<float>(), InputSignal1.Periodic);
            dc.InputSignal2=new Signal(new List<float>(), InputSignal1.Periodic);
            Set_signal(InputSignal1,dc.InputSignal1);
            Set_signal(InputSignal2, dc.InputSignal2);
            float max_absolute_value = 0.0f;
            int j = 0;
            dc.Run();
            for(int i=0;i<dc.OutputNormalizedCorrelation.Count;i++)
            {
                if(Math.Abs(dc.OutputNormalizedCorrelation[i])>max_absolute_value)
                {
                    max_absolute_value = Math.Abs(dc.OutputNormalizedCorrelation[i]);
                    j = i;
                }
            }
            OutputTimeDelay = j * InputSamplingPeriod;


        }
    }
}
