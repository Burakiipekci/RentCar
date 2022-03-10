using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Core.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            };
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length>0)
            {
                if (!Directory.Exists(root))//Directory=>System.IO'nın bir class'ı. burada ki işlem tam olarak şu. Bu Upload metodumun parametresi olan string root CarManager'dan gelmekte
                {                           
//O adres bizim Yükleyeceğimiz dosyaların kayıt edileceği adres burada *Check if a directory Exists* ifadesi şunu belirtiyor dosyanın kaydedileceği adres dizini var mı? varsa if yapısının kod bloğundan ayrılır eğer yoksa içinde ki kodda dosyaların kayıt edilecek dizini oluşturur.
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);// Seçmiş olduğumuz dosyanın uzantısını ALIYORUZ.
                string guid = GuidHelper.GuidHelper.CreateGuid();
                string filePath = guid + extension;// Oluşturulan dosyanın adını ve uzantısını yan yana getiriyorum.

                using(FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);//Yukarıda gelen IFromFile türündeki file dosyasını nereye kopyalacağını söyledim.
                    fileStream.Flush();//Ara bellekten siler
                    return filePath;
                }
            }
            return null;
        }
    }
}
