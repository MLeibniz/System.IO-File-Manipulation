using static System.Console;

public static class Demos
{
    public static void CreatingFiles()
    {
        string file = SanitizeFileName();
        string path = Path.Combine(Environment.CurrentDirectory, $"{file}.txt");

        CreateFile(path);

        static void CreateFile(string path)
        {
            using (var sw = System.IO.File.CreateText(path))
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

    public static void CreatingDirectories()
    {
        var path = Path.Combine(Environment.CurrentDirectory, "globe");
        var dirGlobe = Directory.CreateDirectory(path);
        var dirNorAm = dirGlobe.CreateSubdirectory("North America");
        var dirCenAm = dirGlobe.CreateSubdirectory("Central America");
        var dirSouAm = dirGlobe.CreateSubdirectory("South America");

        var dirBra = dirSouAm.CreateSubdirectory("Brazil");
        var dirArg = dirSouAm.CreateSubdirectory("Argentina");
        var dirChi = dirSouAm.CreateSubdirectory("Chile");

        var dirElS = dirCenAm.CreateSubdirectory("El Salvador");
        var dirPan = dirCenAm.CreateSubdirectory("Panama");
        var dirGua = dirCenAm.CreateSubdirectory("Guatemala");

        var dirMex = dirNorAm.CreateSubdirectory("Mexico");
        var dirUSA = dirNorAm.CreateSubdirectory("USA");
        var dirCan = dirNorAm.CreateSubdirectory("Canada");


    }
}

