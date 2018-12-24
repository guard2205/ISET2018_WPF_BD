using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace ISET2018_WPFBD.ViewModel
{
 public class BasePropriete : INotifyPropertyChanged
 {
  public event PropertyChangedEventHandler PropertyChanged;
  protected void NotifyPropertyChanged(String propertyName)
  { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
  protected bool AssignerChamp<T>(ref T field, T value, string propertyName)
  {
   if (EqualityComparer<T>.Default.Equals(field, value)) return false;
   PropertyChangedEventHandler handler = PropertyChanged;
   field = value;
   if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName.Substring(4)));
   //OnPropertyChanged();
   return true;
  }
 }
 public class BaseCommande : ICommand
 {
  private Action _Action;
  public BaseCommande(Action Action_)
  { _Action = Action_; }
  public event EventHandler CanExecuteChanged;
  public bool CanExecute(object parameter)
  { return true; }
  public void Execute(object parameter)
  { if (_Action != null) _Action(); }
 }
}
