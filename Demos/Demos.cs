using static System.Console;

public static class Demos
{
    public static void CreatingFiles()
    {
        WriteLine("Demo 1 - Creating a file");
        string file = SanitizeFileName();
        CreateFile(file);
    }

    public static void CreatingDirectories()
    {
        WriteLine("Demo 2 - Creating Directories");

        var path = Path.Combine(Environment.CurrentDirectory, "globe");
        if (!Directory.Exists(path))
        {
            var dirGlobe = Directory.CreateDirectory(path);
            var dirNorAm = dirGlobe.CreateSubdirectory("North America");
            var dirCenAm = dirGlobe.CreateSubdirectory("Central America");
            var dirSouAm = dirGlobe.CreateSubdirectory("South America");

            dirSouAm.CreateSubdirectory("Brazil");
            dirSouAm.CreateSubdirectory("Argentina");
            dirSouAm.CreateSubdirectory("Chile");

            dirCenAm.CreateSubdirectory("El Salvador");
            dirCenAm.CreateSubdirectory("Panama");
            dirCenAm.CreateSubdirectory("Guatemala");

            dirNorAm.CreateSubdirectory("Mexico");
            dirNorAm.CreateSubdirectory("USA");
            dirNorAm.CreateSubdirectory("Canada");
        }
    }

    public static void MovingFiles()
    {
        WriteLine(@"Demo 3 - Moving Files");
        string name = SanitizeFileName();
        string origin = CreateFile(name);
        var destiny = Path.Combine(Environment.CurrentDirectory, "Globe", "South America", "Brazil", $"{name}.txt");
        MoveFile(origin, destiny);
    }

    static string CreateFile(string fileName)
    {
        string path = Path.Combine(Environment.CurrentDirectory, $"{fileName}.txt");

        using (var sw = System.IO.File.CreateText(path))
        {
            for (int i = 0; i < 2; i++)
            {
                WriteLine($"Write for line {i + 1}:");
                sw.WriteLine(ReadLine());
            }
        }

        return path;
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

    public static void MoveFile(string origin, string destiny)
    {
        File.Move(origin, destiny);
    }
}

