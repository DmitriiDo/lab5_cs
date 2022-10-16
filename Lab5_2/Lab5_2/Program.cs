namespace Lab5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<float> list = new();
            list.Add(1f);
            list.Add(2f);
            list.Add(5f);
            list.Add(7f);
            list.Add(10f);
            for (int i = 0; i < list.Count; ++i)
            {
                Console.WriteLine(list[i]);
            }
            Console.ReadKey();
        }
    }
}