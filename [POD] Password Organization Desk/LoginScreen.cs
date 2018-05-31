using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _POD__Password_Organization_Desk
{
    /*
     * LOGIN functionality is in determination of development
     */
    [Obsolete]
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The textbox display texts
        /// </summary>
        public string[] Textbox_Display_Texts =
        {
            Constants.LoginScreen.UserNameDefaultText,
            Constants.LoginScreen.LoginPasswordDefaultText
        };

        /// <summary>
        /// Handles the Load event of the PasswordManagementScreen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LoginScreen_Load(object sender, EventArgs e)
        {

            tbUsername.Text = Constants.LoginScreen.UserNameDefaultText;
            tbUsername.ForeColor = Color.DimGray;

            tbPassword.Text = Constants.LoginScreen.LoginPasswordDefaultText;
            tbPassword.ForeColor = Color.DimGray;
        }

        #region Button Handlers
        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            PasswordManagementScreen PasswordOrganizationDesk = new PasswordManagementScreen();
            PasswordOrganizationDesk.Show();
            //Hides the login screen
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        #region Text Box Handlers
        /// <summary>
        /// Handles the InputFocused event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TextBox_InputFocused(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (Textbox_Display_Texts.Contains(textBox.Text))
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Handles the InputExited event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TextBox_InputExited(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                switch (textBox.Name)
                {
                    case "tbUsername":
                        textBox.Text = Constants.LoginScreen.UserNameDefaultText;
                        break;
                    case "tbPassword":
                        textBox.Text = Constants.LoginScreen.LoginPasswordDefaultText;
                        break;
                    default:
                        break;
                }

                textBox.ForeColor = Color.DimGray;
            }
            else
            {
                textBox.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Handles the KeyPress event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
        #endregion
    }
}
