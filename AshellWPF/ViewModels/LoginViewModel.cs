using AshellWPF.Views;
using System.Diagnostics;
using System.Windows.Controls;

namespace AshellWPF.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        public DelegateCommand BackCmd => new(Back);
        public DelegateCommand SettingCmd => new(Setting);
        public DelegateCommand<object> LoginCmd => new(Login);

        private string _UserName = string.Empty;

        public string UserName
        {
            get { return _UserName; }
            set
            {
                SetProperty(ref _UserName, value);
            }
        }

        private readonly IContainerExtension container;
        public LoginViewModel(IContainerExtension container)
        {
            this.container = container;
        }
        private void Back()
        {
            Debug.WriteLine($"back userName:{_UserName}");
        }
        private void Setting()
        {
            Debug.WriteLine($"LoginViewModel {nameof(Setting)}");
            UserName = string.Empty;
        }
        private void Login(object passwordBox)
        {
            var o = passwordBox as PasswordBox;
            Debug.WriteLine($"login userName:{UserName}, password:{o?.Password}");

            var mainView = container.Resolve<MainView>();
            var loginView = App.Current.MainWindow;
            mainView.Show();
            App.Current.MainWindow = mainView;
            loginView.Close();
        }
    }
}
