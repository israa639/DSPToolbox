using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class QuantizationAndEncoding : Algorithm
    {
        // You will have only one of (InputLevel or InputNumBits), the other property will take a negative value
        // If InputNumBits is given, you need to calculate and set InputLevel value and vice versa
        public int InputLevel { get; set; }
        public int InputNumBits { get; set; }
        public Signal InputSignal { get; set; }
        public Signal OutputQuantizedSignal { get; set; }
        public List<int> OutputIntervalIndices { get; set; }
        public List<string> OutputEncodedSignal { get; set; }
        public List<float> OutputSamplesError { get; set; }

        public override void Run(){
            OutputQuantizedSignal = new Signal(new List<float>(), InputSignal.Periodic);
            float min, max,delta=0.0f;
            List<KeyValuePair<double, double>> ranges = new List<KeyValuePair<double, double>>();
            OutputIntervalIndices = new List<int>();
            OutputSamplesError = new List<float>();
            List<double> midPoints = new List<double>();
            OutputEncodedSignal = new List<string>();
            min=max = InputSignal.Samples[0];
            for (int i = 0; i < InputSignal.Samples.Count(); i++)
            {
                if (max < InputSignal.Samples[i])
                {
                    max = InputSignal.Samples[i];
                }
                if (min > InputSignal.Samples[i])
                {
                    min = InputSignal.Samples[i];
                }
                

            }
            delta = (max - min);
            if(InputLevel>0)
            {
                delta /= (float)InputLevel;
                InputNumBits = Convert.ToInt32(Math.Log(InputLevel,2));

            }
            else
            {
               
                InputLevel = Convert.ToInt32(Math.Pow(2, InputNumBits));
                delta /= (float)InputLevel;

            }
            ranges.Add(new KeyValuePair<double, double>(min, min + delta));
            midPoints.Add((ranges[0].Key+ranges[0].Value)/2.0f);
            
            for(int i=1;i<InputLevel;i++)
            {
                ranges.Add(new KeyValuePair<double, double>(ranges[i - 1].Value, ranges[i - 1].Value + delta));
            midPoints.Add((ranges[i].Key+ranges[i].Value)/2.0f);
            
            }
            float x = InputSignal.Samples[0]; 
            float x1 = InputSignal.Samples[1];
            float x12 = InputSignal.Samples[2];

            float x13= InputSignal.Samples[3];

            float x4 = InputSignal.Samples[4];

            float x5= InputSignal.Samples[5];

            float x6= InputSignal.Samples[6];

            float x7= InputSignal.Samples[7];


            for (int i = 0; i < InputSignal.Samples.Count(); i++)
            {

                for(int j=0;j<ranges.Count();j++)
                {
                   
                    if ((InputSignal.Samples[i] >= ranges[j].Key && InputSignal.Samples[i] < ranges[j].Value) )
                    {
                        OutputQuantizedSignal.Samples.Add((float)midPoints[j]);
                        OutputIntervalIndices.Add ( j+1);
                        
                        OutputSamplesError.Add((float)((double)  OutputQuantizedSignal.Samples[i]-InputSignal.Samples[i]));
                        
                        OutputEncodedSignal.Add(Convert.ToString((j ), 2).PadLeft(InputNumBits, '0'));
                        break;
                    }
                    if (InputSignal.Samples[i] >= ranges[ranges.Count() - 1].Value)
                    {
                        OutputQuantizedSignal.Samples.Add((float) midPoints[ranges.Count() - 1]);
                        OutputIntervalIndices.Add((ranges.Count() - 1) + 1);
                        OutputSamplesError.Add((float)(midPoints[ranges.Count() - 1] - (double)InputSignal.Samples[i]));
                        
                        OutputEncodedSignal.Add(Convert.ToString((ranges.Count() - 1), 2).PadLeft(InputNumBits, '0'));
                        break;
                    }
     
                }



            }
        }
    }
}
