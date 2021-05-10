using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PhotoSauce.MagicScaler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.FileManager
{
    public class FileManager : IFileManager
    {
        private string _imagePath;

        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Images"];
        }

        public FileStream ImageStream(string image)
        {
             return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);  //hapet dhe lexohet file
        }
        
        public bool RemoveImage(string image)
        {
            try
            {
                var file = Path.Combine(_imagePath, image);
                if (File.Exists(file))
                    File.Delete(file);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                var save_path = Path.Combine(_imagePath);  //sherben per te marr path
                if (!Directory.Exists(_imagePath))
                {
                    Directory.CreateDirectory(save_path);  //krijon direktorin nese nuk ekziston
                }

                var mime = image.FileName.Substring(image.FileName.LastIndexOf('.')); 
                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyy-HH-mm-ss")}{mime}";

                using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
                {
                    //await image.CopyToAsync(fileStream);
                    MagicImageProcessor.ProcessImage(image.OpenReadStream(), fileStream, ImageOptions());
                }



                return fileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error";
            }
        }

        //metode editon fotot
        private ProcessImageSettings ImageOptions() => new ProcessImageSettings
        {
            Width = 600,
            Height = 200,
            ResizeMode = CropScaleMode.Crop,
            SaveFormat = FileFormat.Jpeg,
            JpegQuality = 100,
            JpegSubsampleMode = ChromaSubsampleMode.Subsample420
        };

    }
}
