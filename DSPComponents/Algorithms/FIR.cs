using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
   
    public class FIR : Algorithm
    {
        //double getHd(FILTER_TYPES InputFilterType)
        //{
        //    switch(InputFilterType)
        //    {

        //        case FILTER_TYPES.BAND_PASS:



        //        case FILTER_TYPES.BAND_STOP:

        //        case FILTER_TYPES.LOW:

        //        case FILTER_TYPES.BAND_PASS:

        //    }
        //}
        double high_pass(int n, float fc)
        {
           
            if (n == 0)
            {

                return 1-(2 * fc);
            }
            else
            {
                return (-2 * fc * Math.Sin(n * 2 * fc * Math.PI)) / (n * 2 * fc * Math.PI);

            }
        }
       float low_pass(int n, float fc)
        {
           

            if (n == 0)
            {

                return   2* fc;
            }
            else
            {
                
                return (float)((2 * fc * (float)Math.Sin(n * 2 * fc * Math.PI)) / (n * 2 * fc * Math.PI));

            }
        }
        double band_pass(int n, float f1,float f2)
        {
            if (n == 0)
            {
                return 2 * (f2 - f1);
            }
            else
            {
                return ((2 * f2 * Math.Sin(n * 2 * f2 * Math.PI)) / (n * 2 * f2 * Math.PI))-(( 2 * f1 * Math.Sin(n * 2 * f1 * Math.PI)) / (n * 2 * f1 * Math.PI));

            }
        }
        double band_stop(int n, float f1, float f2)
        {
            if (n == 0)
            {
                return 1-2 * (f2 - f1);
            }
            else
            {
                return ((2 * f1 * Math.Sin(n * 2 * f1 * Math.PI)) / (n * 2 * f1 * Math.PI)) - ((2 * f2 * Math.Sin(n * 2 * f2 * Math.PI)) / (n * 2 * f2 * Math.PI));

            }

        }
       List<float> Blackman( int N)
        {
            List<float> result=new List<float>();
            for (int n = 0; n <= N/2; n++)
            {
                result.Add((float)((0.42 + 0.5)*Math.Cos((2 * Math.PI * n) / (N - 1)) + (0.08 * (Math.Cos((4 * Math.PI * n) / (N - 1))))));

            }
            return result;
        }
        List<float> hamming(int N)
        {

            List<float> result = new List<float>();
            for (float n = 0; n <= (float)N; n++)
            {


                result.Add((float)0.55 + (float)0.46 * (float)Math.Cos(((float)2.0 * (float)Math.PI * n) / N)); }
            return result;
        }
        double himming(int n,int N)
        {
            return (0.5 + 0.5 * Math.Cos((2 * Math.PI * n) / N));
        }
        double rectangular()
        {
            return 1;
        }
        double GetN(double df, float InputStopBandAttenuation,ref int type_no)
        {
            if(InputStopBandAttenuation<=21)
            {
                type_no = 1;
                return Math.Ceiling(( 0.9/df));
            }
            else if( InputStopBandAttenuation<=44)
            {
                type_no = 2;
                return Math.Ceiling( 3.1/df);

            }
            else if (InputStopBandAttenuation <= 53)
            {
                type_no = 3;
                return Math.Ceiling( 3.3/df);

            }
            else
            {
                type_no = 4;
                return Math.Ceiling( 5.5/df);

            }

        }
        public Signal InputTimeDomainSignal { get; set; }
        public FILTER_TYPES InputFilterType { get; set; }
        public float InputFS { get; set; }
        public float? InputCutOffFrequency { get; set; }
        public float? InputF1 { get; set; }
        public float? InputF2 { get; set; }
        public float InputStopBandAttenuation { get; set; }
        public float InputTransitionBand { get; set; }
        public Signal OutputHn { get; set; }
        public Signal OutputYn { get; set; }

        public override void Run()
        {
            OutputHn = new Signal(new List<float>(), new List<int>(), InputTimeDomainSignal.Periodic, new List<float>(), new List<float>(), new List<float>());
            OutputYn= new Signal(new List<float>(), new List<int>(), InputTimeDomainSignal.Periodic, new List<float>(), new List<float>(), new List<float>());
            float df = InputTransitionBand / InputFS;
            int type_no=0;
            
            int N = (int)GetN(df, InputStopBandAttenuation,ref type_no);
            List<float> wn = Blackman(N);
            int size = ((N) / 2);
            if (InputFilterType == FILTER_TYPES.LOW)
            {
                
                InputCutOffFrequency =(float) (InputCutOffFrequency+ InputTransitionBand / 2.0);
                InputCutOffFrequency /= InputFS;

                int x = 0;
                for (int i =size; i >=0; i--)
                {
                    float hn =( low_pass(i,(float) InputCutOffFrequency)*wn[i]);
                    OutputHn.Samples.Add(hn);
                    OutputHn.SamplesIndices.Add(x);
                    x++;

                }
                int j = size-1 ;
                while(j!=-1)
                {
                    OutputHn.Samples.Add(OutputHn.Samples[j]);
                    OutputHn.SamplesIndices.Add(x);
                    j--;
                    x++;
                }
                

            }
            else if(InputFilterType == FILTER_TYPES.BAND_STOP)
            {
                InputCutOffFrequency += InputTransitionBand / 2;

            }
        }
    }
    }
