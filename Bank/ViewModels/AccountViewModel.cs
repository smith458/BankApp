using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Model;
using MVVM.Annotations;

namespace ViewModels
{
  public class AccountViewModel : INotifyPropertyChanged
  {
    public UserAccount Account;

    public AccountViewModel(UserAccount account)
    {
      Account = account;
    }

    /*
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
    */

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
