using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectConvolution : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputConvolvedSignal { get; set; }
       public void setSample_index(Dictionary<int, int> d1,List<int>samples)
        {

            for(int i=0;i<samples.Count;i++)
            {
                d1[samples[i]] = i;
            }



        }

        /// <summary>
        /// Convolved InputSignal1 (considered as X) with InputSignal2 (considered as H)
        /// </summary>
        public override void Run()
        {
            OutputConvolvedSignal =new Signal(new List<float>(), new List<int>(), InputSignal1.Periodic, new List<float>(), new List<float>(), new List<float>());

            int size = InputSignal2.Samples.Count;
            int windowSize= InputSignal1.Samples.Count;
            Dictionary<int, int> d1 = new Dictionary<int, int>();
            setSample_index(d1, InputSignal2.SamplesIndices);
        
                float sum = 0;
            bool empty_sum = true;
            int n = InputSignal1.SamplesIndices[0] + InputSignal2.SamplesIndices[0];
            int lastSampleIndex= InputSignal1.SamplesIndices[windowSize - 1] + InputSignal2.SamplesIndices[size-1];
            for (int i=n;i<size*size&& n<=lastSampleIndex;i++)
            {
                sum = 0;
                empty_sum = true;
                int currentIndex;
                for (int j= 0;j < InputSignal1.Samples.Count;j++)
                {if (d1.ContainsKey(n - InputSignal1.SamplesIndices[j]) == false)
                        continue;

                    currentIndex = d1[n - InputSignal1.SamplesIndices[j]];
                    if (j>= InputSignal1.Samples.Count|| currentIndex >= InputSignal2.Samples.Count|| currentIndex < 0)
                    {
                        continue;
                    }
                    
                    sum += InputSignal1.Samples[j] * InputSignal2.Samples[currentIndex];
                    empty_sum = false;
                }
                if(!empty_sum)
                OutputConvolvedSignal.Samples.Add(sum);
                OutputConvolvedSignal.SamplesIndices.Add(n);
                n += 1;
            }

        }
    }
}
