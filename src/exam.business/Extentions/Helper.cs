using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.business.Extentions
{
    public static class Helper
    {
        public static string SaveFile(this IFormFile file,string rootpath,string foldername)
        {
            string filename=file.FileName.Length>64
                ?file.FileName.Substring(file.FileName.Length-64,64)
                :file.FileName;
            filename=Guid.NewGuid().ToString()+filename;
            string path=Path.Combine(rootpath,foldername,filename);
            using(FileStream fileStream =new FileStream(path,FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return filename;
        }
        public static void DeleteFile(string rootpath,string foldername,string ImageUrl)
        {
            string deletepath = Path.Combine(rootpath, foldername);
            if (File.Exists(deletepath))
            {
                File.Delete(deletepath);
            }
        }
    }
}
