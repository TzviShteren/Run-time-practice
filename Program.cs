namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }



        static public void BabelSors(int[] ints)
        {
            for (int j = ints.Length - 1; j < 0; j--)
            {
                bool isDon = false;
                for (int i = 0; i < j; i++)
                {
                    if (ints[i] > ints[i + 1])
                    {
                        int tamp = ints[i];
                        ints[i] = ints[i + 1];
                        ints[i + 1] = tamp;
                        isDon = true;
                    }
                    if (!isDon)
                    {
                        break;
                    }
                }
            }
        }

        static public void SelectionSort(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                int minNme = 0;
                for (int j = i + 1; j < ints.Length; j++)
                {
                    if (ints[j] < ints[minNme])
                    {
                        ints[minNme] = ints[j];
                    }
                }
                if (ints[i] != minNme) 
                {
                    int tamp = ints[i];
                    ints[i] = ints[minNme];
                    ints[minNme] = tamp;
                }
            }
        }
    }
}