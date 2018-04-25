using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MVVM;
using MVVM.Annotations;
using Model;

namespace ViewModels
{
  public class MainViewModel : INotifyPropertyChanged
  {
    public LoginViewModel LoginVM { get; set; }
    public AccountViewModel AccountVM { get; set; }
    public UserAccount ThisAccount { get; }
    private bool _isLoggedIn = false;
    private string _userName;
    private bool _isNotLoggedIn = true;

    public string UserName
    {
      get => _userName;
      set
      {
        if (value == _userName) return;
        _userName = value;
        OnPropertyChanged();
      }
    }

    public bool IsLoggedIn
    {
      get => _isLoggedIn;
      set
      {
        if (value == _isLoggedIn) return;
        _isLoggedIn = value;
        IsNotLoggedIn = !_isLoggedIn;
        OnPropertyChanged();
      }
    }

    public bool IsNotLoggedIn
    {
      get => _isNotLoggedIn;
      set
      {
        if (value == _isNotLoggedIn) return;
        _isNotLoggedIn = value;
        OnPropertyChanged();
      }
    }

    public MainViewModel()
    {
      ThisAccount = UserAccount.CreateUserAccount();
      LoginVM = new LoginViewModel(ThisAccount);
      AccountVM = new AccountViewModel(ThisAccount);
      
      
      LoginVM.OnLoggedIn += LogInUser;
    }

    private void LogInUser(bool isLoggedIn, string userName)
    {
      IsLoggedIn = isLoggedIn;
      UserName = userName;
    }

    // Method to Implement INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
