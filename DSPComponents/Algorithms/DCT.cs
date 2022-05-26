using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class DCT: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            OutputSignal=new Signal(new List<float>(), new List<int>(), InputSignal.Periodic, new List<float>(), new List<float>(), new List<float>());
            int N = InputSignal.Samples.Count;
            double sum = 0;
            for (int k = 0; k < N; k++)

            {
                for (int n = 0; n < N; n++)
                {
                    sum += InputSignal.Samples[n] * Math.Cos((2 * n + 1) * k * Math.PI / (2 * N));

                }
                if (k == 0)
                {
                    double m = Math.Sqrt(1.0 / N);
                    sum = sum * m;
                }
                else
                {
                    sum *= Math.Sqrt(2.0 / N);
                }
                OutputSignal.Samples.Add((float)sum);
                OutputSignal.SamplesIndices.Add(k);
                sum = 0;
            }





        }
    }
}
