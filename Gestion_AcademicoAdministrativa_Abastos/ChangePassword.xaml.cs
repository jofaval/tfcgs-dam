using Controller;
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
using System.Windows.Shapes;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public const int DiviedBy = 25;

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void TxtNewPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox senderAsTextBox)
            {
                StrengthLevel.Value = DataIntegrityChecker.CheckPasswordStrengthLevel(senderAsTextBox.Text) * DiviedBy;
            }
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            var user = XamlBridge.CurrentUser;
            var oldPassword = Cryptography.Decrypt(user.Contrasenya, Constants.EncryptationKey);

            if (!oldPassword.Equals(TxtOldPassword.Password))
            {
                Notification.CreateNotificaion("La contraseña antigua no es correcta");
                return;
            }
            else
            {
                var newPassword = TxtNewPassword.Password;

                if (!newPassword.Equals(TxtNewPasswordRepeated.Password))
                {
                    Notification.CreateNotificaion("La contraseñas no coinciden");
                    return;
                }
                else
                {
                    if (StrengthLevel.Value/ DiviedBy > 2)
                    {
                        Notification.CreateNotificaion("La contraseña es débil");
                        return;
                    }
                    else
                    {
                        user.Contrasenya = Cryptography.Decrypt(newPassword, user.Username);
                        Notification.CreateNotificaion("La contraseña se ha cambiado correctamente");
                    }
                }
            }

        }
    }
}
