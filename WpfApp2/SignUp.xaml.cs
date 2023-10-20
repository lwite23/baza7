using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
            CreateCaptcha();
        }
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentUser = AppData.db.User.FirstOrDefault((u) => u.UserLogin == TBLogin.Text && u.UserPassword == TBPassword.Text);

                if (currentUser == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации");
                }
                else
                {
                    App.CurrentUser = currentUser;
                    if (currentUser.UserLogin.Equals(TBLogin.Text) && currentUser.UserPassword.Equals(TBPassword.Text))
                    { 

                        if (currentUser.UserRole == 1 || currentUser.UserRole == 2 || currentUser.UserRole == 3)
                        {
                            MainWindow admin = new MainWindow(); //currentUser.userID
                            admin.Show();
                        }
                        else
                        {
                            MessageBox.Show("Введите корректные логин и пароль", "Ошибка авторизации");
                        }
                        Window.GetWindow(this).Close();
                    }
                   
                }



                //if (CurrentUser == null)
                //{
                //    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации");

                //} else
                //{
                //    switch (CurrentUser.roleID)
                //    {
                //        case 1:MessageBox.Show("Здравствуйте, Администратор " + CurrentUser.name + "!");
                //            break;
                //        case 2:MessageBox.Show("Здравствуйте, гость " + CurrentUser.name + "!");
                //            break;
                //        default:MessageBox.Show("Ошибка");
                //            break;
                //    }

                //    if (CurrentUser.login.Equals(TBLogin.Text) && CurrentUser.password.Equals(TBPassword.Text))
                //    {
                //        NavigationService.Navigate(new DataPage());
                //    }
                //    else
                //    {
                //        MessageBox.Show("Введите корректные логин и пароль");
                //    }                
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString());
            }

        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUp());
        }

        public string CaptchaValue { get; set; }

        public event System.EventHandler CaptchaRefreshed;

        private void ResetCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            CreateCaptcha();
        }

        private void CreateCaptcha()
        {
            string allowchar = string.Empty;
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            string[] ar = allowchar.Split(a);
            string pwd = string.Empty;
            string temp = string.Empty;
            System.Random r = new System.Random();

            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];

                pwd += temp;
            }

            CaptchaText.Text = pwd;

            CaptchaValue = CaptchaText.Text;

            CaptchaRefreshed?.Invoke(this, System.EventArgs.Empty);
        }

        private void CaptchaText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    
}
    

