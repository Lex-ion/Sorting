namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");



            //  MergeSort(DataGen(10));

            

          Console.WriteLine(IsSorted(HeapSort(DataGen(500))));
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
                    break;
                }
            }
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] > input[i])
                {
                    
                    return isSorted;
                }
            }

            return !isSorted;
        }

        public static int[] Reverse(int[] input)
        {
            for (int i = 0; i < input.Length / 2; i++)
            {
                (input[i], input[input.Length-1-i]) = (input[input.Length - 1 - i], input[i]);
            }return input;
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

        public static int[] InsertionSort(int[] input)
        {
            for (int i = 0; i < input.Length-1; i++)
            {
                
                int cycles = i+1;
                int currentNum = input[cycles];
                while (cycles > 0 && currentNum > input[cycles-1])
                {
                    input[cycles] = input[cycles - 1];
                    cycles--;
                        
                }

                input[cycles] = currentNum;
             }
            return input;
        }

        public static int[] MergeSort(int[] input)
        {
           if (input.Length <= 1)
           {
               return input;
           }



           //rozdělení

           int sizeOfHalf = 0;
           int sizeOfSecHalf = 0;
           if (input.Length % 2==1)
           {
               sizeOfHalf = (input.Length + 1) / 2;
               sizeOfSecHalf = input.Length - sizeOfHalf;
           }
           else
           {
              sizeOfHalf=input.Length/2;
               sizeOfSecHalf = sizeOfHalf;
           }
           int[] half = new int[sizeOfHalf];
           int[] secHalf =new int[sizeOfSecHalf];
        
           for (int i = 0; i < half.Length; i++)
           {
               half[i] = input[i];
           }
           for (int i = half.Length; i < secHalf.Length + half.Length; i++)
           {
               secHalf[i-half.Length] = input[i];
           }
        
               half=MergeSort(half);
               secHalf=MergeSort(secHalf);
        
            //skládání:

            int indexOfFirst=0;
            int indexOfSecond=0;
           

            int[] output=new int[half.Length+secHalf.Length];

            for (int i = 0; i < output.Length; i++)
            {
                if (indexOfFirst > half.Length-1)
                {
                    output[i] = secHalf[indexOfSecond];
                    indexOfSecond++;
                }
                else if (indexOfSecond>secHalf.Length-1)
                {
                    output[i] = half[indexOfFirst];
                    indexOfFirst++;
                }
                else if (half[indexOfFirst] > secHalf[indexOfSecond])
                {
                    output[i] = half[indexOfFirst];
                    indexOfFirst++;
                }
                else
                {
                    output[i] = secHalf[indexOfSecond];
                    indexOfSecond++;
                }
                
            }

            
        return output;
        }

        public static int[] HeapSort(int[] input)
        {
            for (int countOfSorted = 0; countOfSorted < input.Length; countOfSorted++)
            {
                //heapify
                bool changed = false;
                while (!changed)
                {
                    changed = true;
                    for (int i = 0; i < input.Length - countOfSorted; i++)
                    {
                        if ((i + 1) * 2 - 1 < input.Length - 1 - countOfSorted)
                        {
                            if (input[i] < input[(i + 1) * 2 - 1])
                            {
                                (input[i], input[(i + 1) * 2 - 1]) = (input[(i + 1) * 2 - 1], input[i]);
                                changed = false;
                            }
                            if (input[i] < input[(i + 1) * 2])
                            {
                                (input[i], input[(i + 1) * 2]) = (input[(i + 1) * 2], input[i]);
                                changed = false;
                            }
                        }

                    }
                }
                (input[0], input[input.Length - 1 - countOfSorted]) = (input[input.Length - 1 - countOfSorted], input[0]);

            }return input;
        }

        public static int[] BubbleSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 1; j<input.Length-i; j++)
                {
                    if(input[j] < input[j - 1])
                    (input[j], input[j - 1]) = (input[j - 1], input[j]);
                }
            }return input;
        }


    }
}