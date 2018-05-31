/*
 * Developed by Jamal D'eShaun Scott
 * ASAP! (A Simple Assistant Program!) (Password Organization Desk) 
 * Manages, updates, removes, encrypts, and decrypts passwords.
 * Created 4/24/2018
 * Completed 5/21/18
 * Release Version 1.0
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _POD__Password_Organization_Desk
{
    public partial class PasswordManagementScreen : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public struct PasswordInfo
        {
            /// <summary>
            /// Gets or sets the name of the website.
            /// </summary>
            /// <value>
            /// The name of the website.
            /// </value>
            public string WebsiteName { get; set; }

            /// <summary>
            /// Gets or sets the password.
            /// </summary>
            /// <value>
            /// The password.
            /// </value>
            public string Password { get; set; }
        }

        /// <summary>
        /// Gets or sets the encryption key.
        /// </summary>
        /// <value>
        /// The encryption key.
        /// </value>
        public string EncryptionKey { get; set; }

        /// <summary>
        /// Gets or sets the initilization vector.
        /// </summary>
        /// <value>
        /// The initilization vector.
        /// </value>
        public string InitilizationVector { get; set; }

        /// <summary>
        /// The passwords
        /// </summary>
        List<PasswordInfo> Passwords = new List<PasswordInfo>();

        /// <summary>
        /// The textbox display texts
        /// </summary>
        public string[] Textbox_Display_Texts =
        {
            Constants.PasswordMaintenanceScreen.PasswordDisplayText,
            Constants.PasswordMaintenanceScreen.NewWebDisplayText,
            Constants.PasswordMaintenanceScreen.NewWebPasswordDisplayText,
            Constants.PasswordMaintenanceScreen.ConfirmNewWebPasswordDisplayText
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordManagementScreen"/> class.
        /// </summary>
        public PasswordManagementScreen()
        {
            InitializeComponent();
            btnResetData.Enabled = false;
        }

        private void EnableControls(bool enabled)
        {
            cbWebsites.Enabled = enabled;
            btnDisplayPassWord.Enabled = enabled;
            btnClear.Enabled = enabled;
            tbPasswordDisplay.Enabled = enabled;
            tbNewWebsiteName.Enabled = enabled;
            tbNewPassWord.Enabled = enabled;
            tbConfirmNewPass.Enabled = enabled;
            btnAddNewWebPass.Enabled = enabled;
            btnClear.Enabled = enabled;
            btnUpdatePassword.Enabled = enabled;
            btnRemove.Enabled = enabled;
            btnSave.Enabled = enabled;
        }

        /// <summary>
        /// Handles the Load event of the PasswordManagementScreen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PasswordManagementScreen_Load(object sender, EventArgs e)
        {
            try
            {
                LoadOrCreateEncryptionKey();

                LoadOrCreatePasswordFile();
            }
            catch(Exception ex)
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + Constants.PasswordMaintenanceScreen.Log, ex.ToString());
                MessageBox.Show(Constants.PasswordMaintenanceScreen.InvalidKeyMessage,
               "Fatal Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1,
               MessageBoxOptions.DefaultDesktopOnly,
               false);
                EnableControls(false);
                btnResetData.BackColor = Color.Red;
                btnResetData.Enabled = true;
            }
        }

        private void SetDefaultText()
        {
            tbPasswordDisplay.BackColor = Color.White;
            tbPasswordDisplay.Text = Constants.PasswordMaintenanceScreen.PasswordDisplayText;
            tbPasswordDisplay.ForeColor = Color.DimGray;

            tbNewWebsiteName.BackColor = Color.White;
            tbNewWebsiteName.Text = Constants.PasswordMaintenanceScreen.NewWebDisplayText;
            tbNewWebsiteName.ForeColor = Color.DimGray;

            tbNewPassWord.BackColor = Color.White;
            tbNewPassWord.Text = Constants.PasswordMaintenanceScreen.NewWebPasswordDisplayText;
            tbNewPassWord.ForeColor = Color.DimGray;

            tbConfirmNewPass.BackColor = Color.White;
            tbConfirmNewPass.Text = Constants.PasswordMaintenanceScreen.ConfirmNewWebPasswordDisplayText;
            tbConfirmNewPass.ForeColor = Color.DimGray;

            cbWebsites.BackColor = Color.White;
            cbWebsites.Text = Constants.PasswordMaintenanceScreen.WebsitesDefaultText;
            cbWebsites.ForeColor = Color.DimGray;
        }

        private void SaveData()
        {
            string plaintext = string.Empty;
            var path = AppDomain.CurrentDomain.BaseDirectory + Constants.PasswordMaintenanceScreen.PasswordFile;
            foreach (PasswordInfo data in Passwords)
            {
                plaintext += data.WebsiteName + " " + data.Password + Environment.NewLine;
            }
            byte[] cipherText = Encrypt(plaintext);
            File.WriteAllText(path, Encoding.Default.GetString(cipherText));
        }

        private void LoadOrCreateEncryptionKey()
        {
            var key = AppDomain.CurrentDomain.BaseDirectory + Constants.PasswordMaintenanceScreen.Key;
            using (var fileStream = File.Open(key, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fileStream, true))
                {
                    EncryptionKey = sr.ReadToEnd();
                }
            }

            var initializationVector = AppDomain.CurrentDomain.BaseDirectory + Constants.PasswordMaintenanceScreen.InitializationVector;
            using (var fileStream = File.Open(initializationVector, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fileStream, true))
                {
                    InitilizationVector = sr.ReadToEnd();
                }
            }

            if (string.IsNullOrEmpty(EncryptionKey) || string.IsNullOrEmpty(InitilizationVector))
            {
                MessageBox.Show(Constants.PasswordMaintenanceScreen.FirstTimeUseMessage,
                "Set Up",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly,
                false);

                GenerateNewKey();
            }
        }

        /// <summary>
        /// Loads the or create password file.
        /// </summary>
        private void LoadOrCreatePasswordFile()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + Constants.PasswordMaintenanceScreen.PasswordFile;
            Passwords = new List<PasswordInfo>();
            string cipherText = string.Empty;
            using (var fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fileStream, true))
                {
                    cipherText = sr.ReadToEnd();
                }
            }

            if (!string.IsNullOrEmpty(cipherText))
            {
                string plainText = Decrypt(Encoding.Default.GetBytes(cipherText));
                PasswordInfo info = new PasswordInfo();
                string parsed = string.Empty;
                for (int i = 0; i < plainText.Length; i++)
                {
                    if (plainText[i] == ' ')
                    {
                        info.WebsiteName = parsed;
                        parsed = string.Empty;
                    }
                    else if (plainText[i] == '\r' || plainText[i] == '\n' || plainText[i].Equals(Environment.NewLine))
                    {
                        if (info.WebsiteName != null)
                        {
                            info.Password = parsed;
                            Passwords.Add(info);
                            info = new PasswordInfo();
                        }
                        parsed = string.Empty;
                    }
                    else if (i == plainText.Length - 1)
                    {
                        parsed += plainText[i];
                        info.Password = parsed;
                        Passwords.Add(info);
                    }
                    else
                    {
                        parsed += plainText[i];
                    }
                }
            }

            RefreshPasswordMenu();
        }

        #region Dropdown Handlers
        private void RefreshPasswordMenu()
        {
            cbWebsites.DataSource = null;
            cbWebsites.DataSource = Passwords;
            cbWebsites.DisplayMember = "WebsiteName";
            cbWebsites.ValueMember = "Password";

            SetDefaultText();
        }
        #endregion

        #region Button Handlers
        /// <summary>
        /// Handles the Click event of the btnDisplayPassWord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDisplayPassWord_Click(object sender, EventArgs e)
        {
            if (Passwords.Any())
            {
                if (cbWebsites.Text.Equals(Constants.PasswordMaintenanceScreen.WebsitesDefaultText) || string.IsNullOrEmpty(cbWebsites.Text))
                {
                    MessageBox.Show("Select a website to display a password for.",
                    "Invalid Entry",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign,
                    false);
                    tbPasswordDisplay.BackColor = Color.White;
                    cbWebsites.BackColor = Color.LightPink;
                }
                else
                {
                    tbPasswordDisplay.Text = Passwords.Where(x => x.WebsiteName == cbWebsites.Text).Select(x => x.Password).FirstOrDefault();
                    tbPasswordDisplay.BackColor = Color.PaleGreen;
                    tbPasswordDisplay.ForeColor = Color.Black;
                }
            }
            else if (!Passwords.Any())
            {
                MessageBox.Show("There are no saved websites and passwords to display.",
                "No Saved Data",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign,
                false);

                cbWebsites.BackColor = Color.LightPink;
                tbNewWebsiteName.BackColor = Color.LightPink;
                tbNewPassWord.BackColor = Color.LightPink;
                tbConfirmNewPass.BackColor = Color.LightPink;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnUpdatePassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbWebsites.Text) || cbWebsites.Text.Equals(Constants.PasswordMaintenanceScreen.WebsitesDefaultText))
            {
                MessageBox.Show("A website must be selected to update.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign,
                false);
                cbWebsites.BackColor = Color.LightPink;
            }
            else
            {
                PasswordInfo updatedWebPassinfo = Passwords.Where(x => x.WebsiteName == cbWebsites.Text).FirstOrDefault();
                Passwords.Remove(updatedWebPassinfo);
                updatedWebPassinfo.Password = tbPasswordDisplay.Text;
                Passwords.Add(updatedWebPassinfo);

                MessageBox.Show("Web info updated.",
                "Update Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign,
                false);

                RefreshPasswordMenu();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAddNewWebPass control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddNewWebPass_Click(object sender, EventArgs e)
        {
            if (!Textbox_Display_Texts.Contains(tbNewWebsiteName.Text) && !Textbox_Display_Texts.Contains(tbNewPassWord.Text) && !Textbox_Display_Texts.Contains(tbNewWebsiteName.Text))
            {
                var siteList = Passwords.Select(x => x.WebsiteName);
                if (!siteList.Contains(tbNewWebsiteName.Text))
                {
                    if (tbNewPassWord.Text.Equals(tbConfirmNewPass.Text))
                    {
                        PasswordInfo newInfo = new PasswordInfo();
                        newInfo.WebsiteName = tbNewWebsiteName.Text;
                        newInfo.Password = tbConfirmNewPass.Text;
                        Passwords.Add(newInfo);

                        MessageBox.Show("Web info has been added!.",
                        "Web Info Added",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign,
                        false);

                        RefreshPasswordMenu();
                    }
                    else
                    {
                        MessageBox.Show("Passwords do not match.",
                        "Invalid Input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign,
                        false);

                        tbNewPassWord.BackColor = Color.LightPink;
                        tbConfirmNewPass.BackColor = Color.LightPink;
                    }
                }
                else
                {
                    MessageBox.Show("This website already exists.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign,
                    false);

                    tbNewWebsiteName.BackColor = Color.LightPink;
                }
            }
            else
            {
                MessageBox.Show("A web name, password, and confirmation password are needed.",
                "Missing Input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign,
                false);

                tbNewWebsiteName.BackColor = Color.LightPink;
                tbNewPassWord.BackColor = Color.LightPink;
                tbConfirmNewPass.BackColor = Color.LightPink;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            SetDefaultText();
        }

        /// <summary>
        /// Handles the Click event of the bbtnRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bbtnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbWebsites.Text) || cbWebsites.Text.Equals(Constants.PasswordMaintenanceScreen.WebsitesDefaultText))
            {
                MessageBox.Show("A website must be selected to remove.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign,
                false);
                cbWebsites.BackColor = Color.LightPink;
            }
            else
            {
                Passwords.Remove(Passwords.Where(x => x.WebsiteName == cbWebsites.Text).FirstOrDefault());

                MessageBox.Show("Web info removed.",
                "Removal Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign,
                false);

                RefreshPasswordMenu();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnResetData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnResetData_Click(object sender, EventArgs e)
        {
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + Constants.PasswordMaintenanceScreen.PasswordFile);
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + Constants.PasswordMaintenanceScreen.Key);
            btnResetData.BackColor = DefaultBackColor;
            btnResetData.Enabled = false;
            EnableControls(true);
            LoadOrCreateEncryptionKey();
            LoadOrCreatePasswordFile();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All info Saved!",
               "Data Saved!",
               MessageBoxButtons.OK,
               MessageBoxIcon.Asterisk,
               MessageBoxDefaultButton.Button1,
               MessageBoxOptions.DefaultDesktopOnly,
               false);
            SaveData();
        }

        private void PasswordManagementScreen_Close(object sender, FormClosingEventArgs e)
        {
            SaveAndExit();
        }

        private void SaveAndExit()
        {
            SaveData();
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
            textBox.BackColor = Color.LightGoldenrodYellow;
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
            textBox.BackColor = Color.White;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                switch (textBox.Name)
                {
                    case "tbPasswordDisplay":
                        textBox.Text = Constants.PasswordMaintenanceScreen.PasswordDisplayText;
                        break;
                    case "tbNewWebsiteName":
                        textBox.Text = Constants.PasswordMaintenanceScreen.NewWebDisplayText;
                        break;
                    case "tbNewPassWord":
                        textBox.Text = Constants.PasswordMaintenanceScreen.NewWebPasswordDisplayText;
                        break;
                    case "tbConfirmNewPass":
                        textBox.Text = Constants.PasswordMaintenanceScreen.ConfirmNewWebPasswordDisplayText;
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

        #region Combobox Handlers
        /// <summary>
        /// Handles the Entered event of the Combobox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Combobox_Entered(object sender, EventArgs e)
        {
            cbWebsites.BackColor = Color.LightGoldenrodYellow;
            if (cbWebsites.Text.Equals(Constants.PasswordMaintenanceScreen.WebsitesDefaultText))
            {
                cbWebsites.Text = string.Empty;
                cbWebsites.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Handles the Exited event of the Combobox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Combobox_Exited(object sender, EventArgs e)
        {
            cbWebsites.BackColor = Color.White;
            if (cbWebsites.Text.Equals(Constants.PasswordMaintenanceScreen.WebsitesDefaultText) || string.IsNullOrEmpty(cbWebsites.Text))
            {
                cbWebsites.Text = Constants.PasswordMaintenanceScreen.WebsitesDefaultText;
                cbWebsites.ForeColor = Color.DimGray;
            }
        }
        #endregion

        #region Encryption and Decryption
        /// <summary>
        /// Encrypts the file.
        /// </summary>
        private byte[] Encrypt(string plainText)
        {
            byte[] encrypted;
            using (Aes AES = Aes.Create())
            {
                ICryptoTransform encryptor = AES.CreateEncryptor(Encoding.Default.GetBytes(EncryptionKey), Encoding.Default.GetBytes(InitilizationVector));
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt, Encoding.Default))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        /// <summary>
        /// Decrypts the file.
        /// </summary>
        private string Decrypt(byte[] encryptedText)
        {
            string decrypted;
            using (Aes AES = Aes.Create())
            {
                ICryptoTransform decryptor = AES.CreateDecryptor(Encoding.Default.GetBytes(EncryptionKey), Encoding.Default.GetBytes(InitilizationVector));
                using (MemoryStream msDecrypt = new MemoryStream(encryptedText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decrypted = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return decrypted;
        }

        /// <summary>
        /// Generates the new key and authentication.
        /// </summary>
        private void GenerateNewKey()
        {
            using (Aes AES = Aes.Create())
            {
                EncryptionKey = Encoding.Default.GetString(AES.Key);
                InitilizationVector = Encoding.Default.GetString(AES.IV);
            }

            var keyPath = AppDomain.CurrentDomain.BaseDirectory + Constants.PasswordMaintenanceScreen.Key;
            var ivPath = AppDomain.CurrentDomain.BaseDirectory + Constants.PasswordMaintenanceScreen.InitializationVector;

            File.WriteAllText(keyPath, EncryptionKey);
            File.WriteAllText(ivPath, InitilizationVector);
        }
        #endregion
    }
}
