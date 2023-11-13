using SixLabors.ImageSharp.Formats.Png;

string imageDirectory = "The path of the photos to be resized on your local.";
string compressedDirectory = "The path of the resized photos on your local.";
int maxWidth = 400; //You can write any desired width value.
int maxHeight = 400; // You can write any desired height value.

string[] imageFiles = Directory.GetFiles(imageDirectory);

foreach (string imageFilePath in imageFiles)
{
    try
    {
        using var image = Image.Load(imageFilePath);
        image.Mutate(x => x
            .Resize(new ResizeOptions
            {
                Size = new Size(maxWidth, maxHeight),
                Mode = ResizeMode.Max
            })
        );

        string fileName = Path.GetFileName(imageFilePath);

        string compressedFilePath = Path.Combine(compressedDirectory, fileName);

        image.Save(compressedFilePath, new PngEncoder());

        Console.WriteLine($"'{fileName}' compressed and saved.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

Console.WriteLine("All photos compressed and saved.");
