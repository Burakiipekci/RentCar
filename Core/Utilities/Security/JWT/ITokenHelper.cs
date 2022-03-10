using Core.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        // Kullanıcı şifresini girdip gönderdikden sonra eğer doğru ise bu kısım çalışacak ve JsonWebToken oluşturup verecek.
    }
}
