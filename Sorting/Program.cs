namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            


           


          Console.WriteLine(IsSorted(SelectionSort(DataGen(500))));
        }

        public static int[] DataGen(int length)
        {
            int[] data = new int[length];
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                while (true)
                {
                    int tmp = rnd.Next(length + 1);
                    if (!data.Contains(tmp))
                    {
                        data[i] = tmp;
                        break;
                    }
                }
                
            }return data;
            
        }

        public static bool IsSorted(int[] input)
        {
           

            bool isSorted = true;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] < input[i])
                {
                    isSorted = false;
                    return isSorted;
                }
            }return isSorted;
        }




        public static int[] QuickSort(int[] input)
        {
            if (input.Length <= 1)
                return input;

            int[] output = new int[input.Length];
            int indexOfLastGreaterNum=0;

            int pivot=input[0];
            for (int i = 1; i < input.Length ; i++)
            {
                if (pivot < input[i])
                {
                    indexOfLastGreaterNum++;
                    if (input[i] > input[indexOfLastGreaterNum])
                    {
                        (input[indexOfLastGreaterNum ], input[i]) = (input[i], input[indexOfLastGreaterNum ]); 
                    }
                    
                }

            }
            (input[0], input[indexOfLastGreaterNum]) = (input[indexOfLastGreaterNum], input[0]);
            if (input.Length <= 2)
            {
                return input;
            }

            output[indexOfLastGreaterNum]=input[indexOfLastGreaterNum];

            int[] LargerOutput=new int[indexOfLastGreaterNum];
            int[] SmallerOutput=new int[input.Length- indexOfLastGreaterNum-1];

           

            for (int i = 0; i < LargerOutput.Length; i++)
            {
                LargerOutput[i] = input[i];
                
            }

            for (int i = 1; i < SmallerOutput.Length+1; i++)
            {
                SmallerOutput[i-1]=input[i+indexOfLastGreaterNum];
                
            }

            int[] LargerReturned = QuickSort(LargerOutput);
            int[] SmallerReturnded = QuickSort(SmallerOutput);

           for (int i =0;i<LargerReturned.Length;i++)
           {
               output[i]=LargerReturned[i];
           }
           
           for (int i = indexOfLastGreaterNum + 1; i < SmallerReturnded.Length + indexOfLastGreaterNum+1; i++)
           {
                output[i] = SmallerReturnded[i-indexOfLastGreaterNum-1];
           }

            

            return output;
        }

        public static int[] SelectionSort(int[] input)
        {
            int[] output = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                int tmpMaxIndex;
                
                tmpMaxIndex = i;
                for (int j = i; j < input.Length; j++)
                {
                    if (input[j] > input[tmpMaxIndex] )
                    {
                        tmpMaxIndex = j;
                    }
                }
                (input[i], input[tmpMaxIndex]) = (input[tmpMaxIndex], input[i]);

            }return input;
        }

        

    }
}