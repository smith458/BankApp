using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM;

namespace ViewModels
{
  public delegate void LoginDelegate(bool IsLoggedIn, string userName);

  public class LoginViewModel : ObservableObject
  {
    private string _userName = "";
    private string _password = "";
    private readonly DelegateCommand _loginCommand;

    public LoginViewModel()
    {
      _loginCommand = new DelegateCommand(Login);
    }

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

    public ICommand LoginCommand => _loginCommand;

    public void Login()
    {
      OnLoggedIn(true, _userName);
    }

    public event LoginDelegate OnLoggedIn;
  }
}
