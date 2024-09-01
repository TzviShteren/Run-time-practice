using ConsoleApp0109;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var values = new MyLinkedList<int>(); 
            values.Push(1);
            values.Push(2);
            values.Push(3);
            values.Push(4);
            values.Push(5);
            Console.WriteLine(values.ToString());
            Console.WriteLine(values.All(x => x > 0));
            Console.WriteLine(values.All(x => x > 3));
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
                int minIndex = 0;
                for (int j = i + 1; j < ints.Length; j++)
                {
                    if (ints[j] < ints[minIndex])
                    {
                        ints[minIndex] = ints[j];
                    }
                }
                if (ints[i] != minIndex) 
                {
                    int tamp = ints[i];
                    ints[i] = ints[minIndex];
                    ints[minIndex] = tamp;
                }
            }
        }
    }
}