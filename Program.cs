using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.PixelFormats;

class Program
{
    static void Main()
    {
        // Chemin du dossier d'entrée contenant les images
        string inputFolderPath = "images";
        // Chemin du dossier de sortie pour les images converties
        string outputFolderPath = "imagesWebP";

        // Crée le dossier de sortie s'il n'existe pas
        if (!Directory.Exists(outputFolderPath))
        {
            Directory.CreateDirectory(outputFolderPath);
        }

        // Obtient tous les fichiers d'image dans le dossier d'entrée
        string[] imageFiles = Directory.GetFiles(inputFolderPath, "*.*", SearchOption.TopDirectoryOnly);

        foreach (string inputPath in imageFiles)
        {
            try
            {
                // Chargement de l'image
                using (Image<Rgba32> image = Image.Load<Rgba32>(inputPath))
                {
                    // Obtient le nom du fichier sans l'extension
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(inputPath);
                    // Chemin du fichier de sortie avec extension .webp
                    string outputPath = Path.Combine(outputFolderPath, fileNameWithoutExtension + ".webp");

                    // Enregistre l'image au format WebP
                    image.Save(outputPath, new WebpEncoder());

                    Console.WriteLine($"Image convertie : {inputPath} -> {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la conversion de l'image {inputPath}: {ex.Message}");
            }
        }

        Console.WriteLine("Conversion terminée pour toutes les images.");
    }
}
