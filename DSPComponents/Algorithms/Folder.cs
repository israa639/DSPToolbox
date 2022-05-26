using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Folder : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputFoldedSignal { get; set; }

        public override void Run()
        {
            OutputFoldedSignal = new Signal(new List<float>(), new List<int>(), InputSignal.Periodic, new List<float>(), new List<float>(), new List<float>());
            int size = InputSignal.Samples.Count();

            int y=size-1;;
            for(int i=0;i<size;i++)
            {
                OutputFoldedSignal.SamplesIndices.Add(InputSignal.SamplesIndices[y]*-1);
                OutputFoldedSignal.Samples.Add(InputSignal.Samples[y]);
            
                y--;
            }
            
           
        }
    }
}
