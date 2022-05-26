using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Normalizer : Algorithm
    {
        public Signal InputSignal { get; set; }
        public float InputMinRange { get; set; }
        public float InputMaxRange { get; set; }
        public Signal OutputNormalizedSignal { get; set; }

        public override void Run()
        {
            //InputMinRange *= -1;
            float range = InputMaxRange -InputMinRange;
           
            this.OutputNormalizedSignal = new Signal(InputSignal.Samples, InputSignal.Periodic);
            float min, max;
            min=max = OutputNormalizedSignal.Samples[0];
            for (int i = 0; i < OutputNormalizedSignal.Samples.Count(); i++)
            {
                if (max <OutputNormalizedSignal.Samples[i])
                {
                    max = OutputNormalizedSignal.Samples[i];
                }
                if (min> OutputNormalizedSignal.Samples[i])
                {
                    min = OutputNormalizedSignal.Samples[i];
                }
                

            }
            for (int i = 0; i < OutputNormalizedSignal.Samples.Count(); i++)
            {
                OutputNormalizedSignal.Samples[i] -= min;
                OutputNormalizedSignal.Samples[i] /= (max-min);

            }
            for (int i = 0; i < OutputNormalizedSignal.Samples.Count(); i++)
            {
               
                OutputNormalizedSignal.Samples[i] *= range;
                OutputNormalizedSignal.Samples[i] += InputMinRange;

            }

        }
    }
}
