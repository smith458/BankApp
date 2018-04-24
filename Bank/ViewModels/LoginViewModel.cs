using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM;

namespace ViewModels
{
    public class LoginViewModel : ObservableObject
    {
      private string _userName = "";
      private string _password = "";
      
      public string UserName
      {
        get => _userName;
        set
        {
          _userName = value;
          RaisePropertyChangedEvent(nameof(UserName));
        }
      }

      public string Password
      {
        get => _password;
        set
        {
          _password = value;
          RaisePropertyChangedEvent(nameof(Password));
        }
      }

      public ICommand LoginCommand => new DelegateCommand(Login);

      public void Login()
      {
        UserName = "";
        Password = "";
      }
    }
}
