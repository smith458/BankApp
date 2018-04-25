using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class UserAccount
  {
    private static UserAccount thisAccount;

    public static UserAccount CreateUserAccount()
    {
      return thisAccount ?? (thisAccount = new UserAccount());
    }

    private UserAccount()
    {
      
    }

    public string UserName { get; set; }
  }
}
