using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectCorrelation : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public List<float> OutputNonNormalizedCorrelation { get; set; }
        public List<float> OutputNormalizedCorrelation { get; set; }
        public float Sum_of_product(Signal InputSignal1, Signal InputSignal2)
        {
            float sum = 0;
            for (int i = 0; i < InputSignal1.Samples.Count; i++)
            {
                sum += (InputSignal1.Samples[i] * InputSignal2.Samples[i]);
            }
            return sum;
        }
        public void Set_signal(Signal InputSignal1, Signal InputSignal2)
        {

            for (int j = 0; j < InputSignal1.Samples.Count; j++)
            {
                InputSignal2.Samples.Add(InputSignal1.Samples[j]);
                InputSignal2.SamplesIndices.Add(InputSignal1.SamplesIndices[j]);
            }
        }
        public void circular_shift(List<float> InputSignal)
        {

            float sample = InputSignal[0];

            InputSignal.RemoveAt(0);

            InputSignal.Add(sample);


        }
        public void shift(List<float> InputSignal)
        {

            InputSignal.RemoveAt(0);

            InputSignal.Add(0);


        }

        public override void Run()
        {
            float sum = 0;
            OutputNormalizedCorrelation = new List<float>();
            OutputNonNormalizedCorrelation = new List<float>();
            InputSignal2 = new Signal(new List<float>(), new List<int>(), InputSignal1.Periodic, new List<float>(), new List<float>(), new List<float>());
            float signal1_SOP = Sum_of_product(InputSignal1, InputSignal1), signal2_SOP;
            float product_of_2SOP = (float)Math.Sqrt(signal1_SOP * signal1_SOP) / InputSignal1.Samples.Count;
           
             Set_signal(InputSignal1, InputSignal2); 
            for (int j = 0; j < InputSignal1.Samples.Count; j++)
            {
                sum = 0;
                if (j > 0)
                {
                    if (InputSignal1.Periodic == true)
                    {
                        circular_shift(InputSignal2.Samples);
                    }
                    else
                    {
                        shift(InputSignal2.Samples);
                    }


                }
                //signal2_SOP = Sum_of_product(InputSignal2, InputSignal2);
                
                sum = Sum_of_product(InputSignal1, InputSignal2);


                sum /= InputSignal1.Samples.Count;
                OutputNonNormalizedCorrelation.Add(sum);
                OutputNormalizedCorrelation.Add(sum / product_of_2SOP);
            }

        }
    }
}