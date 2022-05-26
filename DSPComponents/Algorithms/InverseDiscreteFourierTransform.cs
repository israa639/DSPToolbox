using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class InverseDiscreteFourierTransform : Algorithm
    {
        public Signal InputFreqDomainSignal { get; set; }
        public Signal OutputTimeDomainSignal { get; set; }

        public override void Run()
        {
             OutputTimeDomainSignal = new Signal(new List<float>(),InputFreqDomainSignal.Periodic);

            int N = InputFreqDomainSignal.Frequencies.Count;
            double[] real = new double[N];
            double[] imaginary = new double[N];
            double theta;
            double r,c;
            for (int i = 0; i < N; i++)
            {

                real[i] = InputFreqDomainSignal.FrequenciesAmplitudes[i]*Math.Cos(InputFreqDomainSignal.FrequenciesPhaseShifts[i]);
                imaginary[i] = InputFreqDomainSignal.FrequenciesAmplitudes[i]*Math.Sin(InputFreqDomainSignal.FrequenciesPhaseShifts[i]);}
            for(int i=0;i<N;i++){
                r=0;c=0;
                for (int j = 0; j < N; j++)
                {
                    theta = (i * j * 2 * Math.PI) / N;

                   r+=(Math.Cos(theta)*real[j]);
                  //c += (Math.Cos(theta) * imaginary[j]);
                   r += (Math.Sin(theta) * real[j]);
                   c += (Math.Sin(theta) * imaginary[j]*-1);

                
            }
                
                OutputTimeDomainSignal.Samples.Add((float) (r+c)/N);
            
            
            }
        
        }
    }
}
