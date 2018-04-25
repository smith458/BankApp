using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MVVM;
using MVVM.Annotations;

namespace Model
{
  public class UserAccount : INotifyPropertyChanged
  {
    private static UserAccount thisAccount;
    private string _userName = "Steven";

    public static UserAccount CreateUserAccount()
    {
      return thisAccount ?? (thisAccount = new UserAccount());
    }

    private UserAccount()
    {
      
    }

    public string UserName
    {
      get => _userName;
      set
      {
        if (_userName == value) return;
        _userName = value;
        OnPropertyChanged();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
