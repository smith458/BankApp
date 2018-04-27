using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;
using MVVM;
using MVVM.Annotations;

namespace ViewModels
{
  public delegate void LoginDelegate(bool IsLoggedIn, string userName);

  public class LoginViewModel : INotifyPropertyChanged
  {
    private string _password = "";
    private readonly DelegateCommand _loginCommand;
    public UserAccount Account;

    public LoginViewModel(UserAccount account)
    {
      Account = account;
      _loginCommand = new DelegateCommand(Login);
    }

    public string Password
    {
      get => _password;
      set
      {
        _password = value;
        OnPropertyChanged();
      }
    }

    public ICommand LoginCommand => _loginCommand;

    public void Login()
    {
      OnPropertyChanged("");
    }

    public event LoginDelegate OnLoggedIn;
    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
