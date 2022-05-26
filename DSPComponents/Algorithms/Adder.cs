using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
namespace DSPAlgorithms.Algorithms
{
    public class Adder : Algorithm
    {
        public List<Signal> InputSignals { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            this.OutputSignal = new Signal(InputSignals[0].Samples, InputSignals[0].Periodic);
          
            for (int i = 0; i < OutputSignal.Samples.Count(); i++) 
            {
                OutputSignal.Samples[i] += InputSignals[1].Samples[i];
            

            }
            //for(int i=0;i<InputSignals[0].Samples.Count();i++)
            //{
            //    float x = InputSignals[0].Samples[i] + InputSignals[1].Samples[i];
            //    this.OutputSignal.Samples.Add(x);
            //}
            
        }
    }
}