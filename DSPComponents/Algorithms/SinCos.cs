using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    
    public class SinCos: Algorithm
    {
        void cosFun(float A, float PhaseShift, float AnalogFrequency, float SamplingFrequency, List<float> samples)
        {
            for (int i = 0; i < (int)SamplingFrequency; i++)
            {
                samples.Add((float)((A * Math.Cos((2 * Math.PI * i * AnalogFrequency / SamplingFrequency) + PhaseShift))));
            }
        }
        void sinFun(float A, float PhaseShift, float AnalogFrequency, float SamplingFrequency, List<float> samples)
        {
            for (int i = 0; i < (int)SamplingFrequency; i++)
            {
                samples.Add((float)((A * Math.Sin((2 * Math.PI * i * AnalogFrequency / SamplingFrequency) + PhaseShift))));
            }
        }
        public string type { get; set; }
        public float A { get; set; }
        public float PhaseShift { get; set; }
        public float AnalogFrequency { get; set; }
        public float SamplingFrequency { get; set; }
        public List<float> samples { get; set; }
        public override void Run()
        {
            samples = new List<float>();
            if(type== "cos")
            {
                cosFun(A, PhaseShift, AnalogFrequency, SamplingFrequency, samples);
            }
            else
            {
                sinFun(A, PhaseShift, AnalogFrequency, SamplingFrequency, samples);
            }
        }
    }
}
