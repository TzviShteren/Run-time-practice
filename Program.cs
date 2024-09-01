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
            bool isDon = false;
            for (int i = 0; i < ints.Length - 1; i++)
            {
                if (ints[i] > ints[i + 1])
                {
                    int tamp = ints[i];
                    ints[i] = ints[i + 1];
                    ints[i + 1] = tamp;
                    isDon = true;
                }
                if(!isDon)
                {
                    break;
                }
            }
        }
    }
}