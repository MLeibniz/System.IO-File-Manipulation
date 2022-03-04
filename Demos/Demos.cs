using static System.Console;

public static class Demos
{
    public static void Demo1()
    {
        string file = SanitizeFileName();
        string path = Path.Combine(Environment.CurrentDirectory, $"{file}.txt");

        CreateFile(path);

        static void CreateFile(string path)
        {
            using (var sw = File.CreateText(path))
            {
                for (int i = 0; i < 2; i++)
                {
                    WriteLine($"Write for line {i + 1}:");
                    sw.WriteLine(ReadLine());
                }
            }
        }

        static string SanitizeFileName()
        {
            WriteLine("File name:");
            string name = ReadLine();

            foreach (char @char in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(@char, '-');
            }

            return name;
        }
    }
}

