using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class DC_Component: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            //InverseDiscreteFourierTransform IDFT = new InverseDiscreteFourierTransform();
            //DiscreteFourierTransform DFT = new DiscreteFourierTransform();
            //DFT.InputTimeDomainSignal = new DSPAlgorithms.DataStructures.Signal(Samples, false);
            //DFT.InputSamplingFrequency = 4;
            OutputSignal = new Signal(new List<float>(), InputSignal.Periodic);
            float mean = 0;
            for(int i=0;i<InputSignal.Samples.Count;i++)
            {
                mean += InputSignal.Samples[i];
            }
            mean /= InputSignal.Samples.Count;

            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                 OutputSignal.Samples.Add(InputSignal.Samples[i]-mean);
            }








        }
    }
}
