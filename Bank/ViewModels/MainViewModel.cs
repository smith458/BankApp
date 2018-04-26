using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM;
using MVVM.Annotations;

namespace ViewModels
{
  public class MainViewModel : INotifyPropertyChanged
  {
    private string _userName;
    private bool _isLoggedIn = false;
    private bool _isNotLoggedIn = true;
    private string _passwordFeedback = " ";

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
        IsLoggedIn = !_isNotLoggedIn;
        OnPropertyChanged();
      }
    }

    public string PasswordFeedback
    {
      get => _passwordFeedback;
      set
      {
        if (value == _passwordFeedback) return;
        _passwordFeedback = value;
        OnPropertyChanged();
      }
    }

    public MainViewModel()
    {

    }

    public ICommand LoginCommand => new DelegateCommand(LoginUser);

    private void LoginUser()
    {
      if (string.IsNullOrWhiteSpace(UserName))
      {
        PasswordFeedback = "Password cannot be empty";
      }
      else
      {
        IsLoggedIn = true;
      }
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
