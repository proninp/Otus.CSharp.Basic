using System.IO;
using System.Text;

var dir1 = @"C:\Otus\TestDir1";
var dir2 = @"C:\Otus\TestDir2";

var directoryInfo1 = new DirectoryInfo(dir1);
var directoryInfo2 = new DirectoryInfo(dir2);

directoryInfo1.Create();
directoryInfo2.Create();

await CreateAndWriteFilesAsync(directoryInfo1);
await CreateAndWriteFilesAsync(directoryInfo2);

Console.WriteLine("Содержимое файлов в TestDir1:");
ReadAndPrintFiles(directoryInfo1);

Console.WriteLine("Содержимое файлов в TestDir2:");
ReadAndPrintFiles(directoryInfo2);

static async Task CreateAndWriteFilesAsync(DirectoryInfo directory)
{
    for (int i = 0; i < 10; i++)
    {
        var fileName = $"File{i}.txt";
        var filePath = Path.Combine(directory.FullName, fileName);

        await CreateAndWriteFileAsync(fileName, filePath);
    }
}

static async Task CreateAndWriteFileAsync(string fileName, string filePath)
{
    try
    {
        await File.WriteAllTextAsync(filePath, fileName, Encoding.UTF8);
        await File.AppendAllTextAsync(filePath, $"{Environment.NewLine}{DateTime.Now}", Encoding.UTF8);

    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine($"Нет доступа к файлу: {filePath}");
    }
    catch (IOException ex)
    {
        Console.WriteLine($"Ошибка при работе с файлом: {filePath}." +
            $"{Environment.NewLine}Причина: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Непредвиденная ошибка чтения файла: {filePath}." +
            $"{Environment.NewLine}Причина: {ex.Message}");
    }
}

static void ReadAndPrintFiles(DirectoryInfo directory)
{
    foreach (var file in directory.GetFiles("File*.txt"))
    {
        ReadAndPrintFile(file);
    }
}

static void ReadAndPrintFile(FileInfo? file)
{
    try
    {
        var content = File.ReadAllText(file.FullName, Encoding.UTF8);
        Console.WriteLine($"{file.FullName}: {content}");
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine($"Файл не найден: {file.FullName}");
    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine($"Нет доступа к файлу: {file.FullName}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Непредвиденная ошибка чтения файла: {file.FullName}." +
            $"{Environment.NewLine}Причина: {ex.Message}");
    }
}