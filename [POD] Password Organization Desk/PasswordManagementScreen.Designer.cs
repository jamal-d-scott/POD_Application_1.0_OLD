using System;

namespace _POD__Password_Organization_Desk
{
    partial class PasswordManagementScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordManagementScreen));
            this.btnAddNewWebPass = new System.Windows.Forms.Button();
            this.cbWebsites = new System.Windows.Forms.ComboBox();
            this.btnDisplayPassWord = new System.Windows.Forms.Button();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbPasswordDisplay = new System.Windows.Forms.TextBox();
            this.tbNewWebsiteName = new System.Windows.Forms.TextBox();
            this.tbNewPassWord = new System.Windows.Forms.TextBox();
            this.tbConfirmNewPass = new System.Windows.Forms.TextBox();
            this.lblSavedPasswordsHeader = new System.Windows.Forms.Label();
            this.lblCreatePasswordsHeader = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnResetData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddNewWebPass
            // 
            this.btnAddNewWebPass.Location = new System.Drawing.Point(15, 353);
            this.btnAddNewWebPass.Name = "btnAddNewWebPass";
            this.btnAddNewWebPass.Size = new System.Drawing.Size(108, 24);
            this.btnAddNewWebPass.TabIndex = 0;
            this.btnAddNewWebPass.Text = "Add Web Pass";
            this.btnAddNewWebPass.UseVisualStyleBackColor = true;
            this.btnAddNewWebPass.Click += new System.EventHandler(this.btnAddNewWebPass_Click);
            // 
            // cbWebsites
            // 
            this.cbWebsites.FormattingEnabled = true;
            this.cbWebsites.Location = new System.Drawing.Point(15, 42);
            this.cbWebsites.Name = "cbWebsites";
            this.cbWebsites.Size = new System.Drawing.Size(251, 21);
            this.cbWebsites.TabIndex = 1;
            this.cbWebsites.Enter += new System.EventHandler(this.Combobox_Entered);
            this.cbWebsites.Leave += new System.EventHandler(this.Combobox_Exited);
            // 
            // btnDisplayPassWord
            // 
            this.btnDisplayPassWord.Location = new System.Drawing.Point(15, 80);
            this.btnDisplayPassWord.Name = "btnDisplayPassWord";
            this.btnDisplayPassWord.Size = new System.Drawing.Size(108, 24);
            this.btnDisplayPassWord.TabIndex = 3;
            this.btnDisplayPassWord.Text = "Display Password";
            this.btnDisplayPassWord.UseVisualStyleBackColor = true;
            this.btnDisplayPassWord.Click += new System.EventHandler(this.btnDisplayPassWord_Click);
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Location = new System.Drawing.Point(15, 164);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(108, 24);
            this.btnUpdatePassword.TabIndex = 4;
            this.btnUpdatePassword.Text = "Update Password";
            this.btnUpdatePassword.UseVisualStyleBackColor = true;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(158, 353);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 24);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Data";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbPasswordDisplay
            // 
            this.tbPasswordDisplay.Location = new System.Drawing.Point(15, 127);
            this.tbPasswordDisplay.Name = "tbPasswordDisplay";
            this.tbPasswordDisplay.Size = new System.Drawing.Size(251, 20);
            this.tbPasswordDisplay.TabIndex = 6;
            this.tbPasswordDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPasswordDisplay.Enter += new System.EventHandler(this.TextBox_InputFocused);
            this.tbPasswordDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.tbPasswordDisplay.Leave += new System.EventHandler(this.TextBox_InputExited);
            // 
            // tbNewWebsiteName
            // 
            this.tbNewWebsiteName.Location = new System.Drawing.Point(15, 243);
            this.tbNewWebsiteName.Name = "tbNewWebsiteName";
            this.tbNewWebsiteName.Size = new System.Drawing.Size(251, 20);
            this.tbNewWebsiteName.TabIndex = 7;
            this.tbNewWebsiteName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNewWebsiteName.Enter += new System.EventHandler(this.TextBox_InputFocused);
            this.tbNewWebsiteName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.tbNewWebsiteName.Leave += new System.EventHandler(this.TextBox_InputExited);
            // 
            // tbNewPassWord
            // 
            this.tbNewPassWord.Location = new System.Drawing.Point(15, 279);
            this.tbNewPassWord.Name = "tbNewPassWord";
            this.tbNewPassWord.Size = new System.Drawing.Size(251, 20);
            this.tbNewPassWord.TabIndex = 8;
            this.tbNewPassWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNewPassWord.Enter += new System.EventHandler(this.TextBox_InputFocused);
            this.tbNewPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.tbNewPassWord.Leave += new System.EventHandler(this.TextBox_InputExited);
            // 
            // tbConfirmNewPass
            // 
            this.tbConfirmNewPass.Location = new System.Drawing.Point(15, 314);
            this.tbConfirmNewPass.Name = "tbConfirmNewPass";
            this.tbConfirmNewPass.Size = new System.Drawing.Size(251, 20);
            this.tbConfirmNewPass.TabIndex = 9;
            this.tbConfirmNewPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbConfirmNewPass.Enter += new System.EventHandler(this.TextBox_InputFocused);
            this.tbConfirmNewPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.tbConfirmNewPass.Leave += new System.EventHandler(this.TextBox_InputExited);
            // 
            // lblSavedPasswordsHeader
            // 
            this.lblSavedPasswordsHeader.AutoSize = true;
            this.lblSavedPasswordsHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblSavedPasswordsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavedPasswordsHeader.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSavedPasswordsHeader.Location = new System.Drawing.Point(76, 11);
            this.lblSavedPasswordsHeader.Name = "lblSavedPasswordsHeader";
            this.lblSavedPasswordsHeader.Size = new System.Drawing.Size(137, 16);
            this.lblSavedPasswordsHeader.TabIndex = 10;
            this.lblSavedPasswordsHeader.Text = "Saved Passwords:";
            // 
            // lblCreatePasswordsHeader
            // 
            this.lblCreatePasswordsHeader.AutoSize = true;
            this.lblCreatePasswordsHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatePasswordsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatePasswordsHeader.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCreatePasswordsHeader.Location = new System.Drawing.Point(58, 208);
            this.lblCreatePasswordsHeader.Name = "lblCreatePasswordsHeader";
            this.lblCreatePasswordsHeader.Size = new System.Drawing.Size(172, 16);
            this.lblCreatePasswordsHeader.TabIndex = 11;
            this.lblCreatePasswordsHeader.Text = "Create New Passwords:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(158, 80);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 24);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(158, 164);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(108, 24);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "Remove Web Info";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.bbtnRemove_Click);
            // 
            // btnResetData
            // 
            this.btnResetData.BackColor = System.Drawing.SystemColors.Control;
            this.btnResetData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResetData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnResetData.Location = new System.Drawing.Point(15, 395);
            this.btnResetData.Name = "btnResetData";
            this.btnResetData.Size = new System.Drawing.Size(251, 24);
            this.btnResetData.TabIndex = 14;
            this.btnResetData.Text = "Reset Data";
            this.btnResetData.UseVisualStyleBackColor = false;
            this.btnResetData.Click += new System.EventHandler(this.btnResetData_Click);
            // 
            // PasswordManagementScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(300, 431);
            this.Controls.Add(this.btnResetData);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblCreatePasswordsHeader);
            this.Controls.Add(this.lblSavedPasswordsHeader);
            this.Controls.Add(this.tbConfirmNewPass);
            this.Controls.Add(this.tbNewPassWord);
            this.Controls.Add(this.tbNewWebsiteName);
            this.Controls.Add(this.tbPasswordDisplay);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdatePassword);
            this.Controls.Add(this.btnDisplayPassWord);
            this.Controls.Add(this.cbWebsites);
            this.Controls.Add(this.btnAddNewWebPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PasswordManagementScreen";
            this.Text = "ASAP! (P.O.D)";
            this.Load += new System.EventHandler(this.PasswordManagementScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewWebPass;
        private System.Windows.Forms.ComboBox cbWebsites;
        private System.Windows.Forms.Button btnDisplayPassWord;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbPasswordDisplay;
        private System.Windows.Forms.TextBox tbNewWebsiteName;
        private System.Windows.Forms.TextBox tbNewPassWord;
        private System.Windows.Forms.TextBox tbConfirmNewPass;
        private System.Windows.Forms.Label lblSavedPasswordsHeader;
        private System.Windows.Forms.Label lblCreatePasswordsHeader;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnResetData;
    }
}

