using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace electroinc_blood_bank.Helper
{
    public static class Upload
    {
        [HttpPost, DisableRequestSizeLimit]
        public  static string UploadImage(IFormFile Request)
        {
            try
            {
                var folderName = Path.Combine("Resources");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                {
                    var file = Request;
                    

                  
                     
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                            var fullPath = Path.Combine(pathToSave, fileName);
                            var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                           var imagesPath=dbPath;
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                       
                    return imagesPath;

                }
            }

            catch (Exception ex)
            {
                return  "Internal server error" ;
            }
        }
    }
}
