using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Lab03.Annotations;


namespace Lab03
{
    internal class AddPersonView : INotifyPropertyChanged
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private DateTime _dateOfBirth = DateTime.Today;
        private Command _proceed;
        private readonly Action<bool> _showLoaderAction;

        internal AddPersonView(Action<bool> showLoader)
        {
            _showLoaderAction = showLoader;
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {

                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {      
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public Command Proceed
        {
            get
            {
                return _proceed ?? (_proceed = new Command(CreatePersonImpl, x =>
                               !String.IsNullOrWhiteSpace(_firstName) &&
                               !String.IsNullOrWhiteSpace(_lastName) &&
                               !String.IsNullOrWhiteSpace(_email) &&
                               _dateOfBirth != DateTime.MinValue));
            }
        }

        private async void CreatePersonImpl(object o)
        {
            Person newPerson = null;

            _showLoaderAction.Invoke(true);
            await Task.Run(() =>
            {
                try
                {
                    newPerson = new Person(_firstName, _lastName, _email, _dateOfBirth);
                    Thread.Sleep(2000);

                    Current.CurrUser = newPerson;
                    if (Current.CurrUser.IsBirthday)
                        MessageBox.Show("Happy birhday!!!");

                    MessageBox.Show(Current.CurrUser.ToString());
                }
             
                catch (BadEmail e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (FutureBirth e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (OverPastBirth e)
                {
                    MessageBox.Show(e.Message);
                }         
            });

            _showLoaderAction.Invoke(false);
        }



        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
