using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers.GuidHelper
{
  public  class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
            
            //Yüklenilen dosya için benzersiz bir isim oluşturduk.
            //Dosya yüklendiğinde dosya yüklendiği isim ile olmasın.
            //Guid.NewGuid()=> bu metot bize eşsiz bir değer oluşturdu.
            //ToString()=>  string hale getirdik.

        }
    }
}
