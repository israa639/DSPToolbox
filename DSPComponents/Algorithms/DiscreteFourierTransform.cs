using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;


namespace DSPAlgorithms.Algorithms
{
    public class DiscreteFourierTransform : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public float InputSamplingFrequency { get; set; }
        public Signal OutputFreqDomainSignal { get; set; }

        public override void Run()
        {
            OutputFreqDomainSignal = new Signal(InputTimeDomainSignal.Periodic,new List<float>(),new List<float>(),new List<float>());

            int N = InputTimeDomainSignal.Samples.Count;
            double[] real = new double[N];
            double[] imaginary = new double[N];
            double theta, phaseShift;
             OutputFreqDomainSignal.Frequencies=new List<float>();

            for (int i = 0; i < N; i++)
            {
                real[i] = 0;
                imaginary[i] = 0;
                for (int j = 0; j < N; j++)
                {
                    theta = (i * j * 2 * Math.PI) / N;

                    real[i] += (InputTimeDomainSignal.Samples[j] * Math.Cos(theta));
                    imaginary[i] +=( InputTimeDomainSignal.Samples[j] * -1 * Math.Sin(theta));



                }
                phaseShift = imaginary[i] / real[i];
                OutputFreqDomainSignal.Frequencies.Add((float)i);
                OutputFreqDomainSignal.FrequenciesAmplitudes.Add((float)Math.Sqrt((real[i] * real[i]) +( imaginary[i] * imaginary[i])));
                OutputFreqDomainSignal.FrequenciesPhaseShifts.Add ((float)Math.Atan2(imaginary[i],real[i]));

            }
        }
    }
}
