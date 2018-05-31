using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _POD__Password_Organization_Desk
{
    class Constants
    {
        #region Password Organization Screen Constants
        public class PasswordMaintenanceScreen
        {
            public const string WebsitesDefaultText = "Select a Website";
            public const string PasswordFile = @"/POD.pod";
            public const string Key = @"/Key.psek";
            public const string InitializationVector = @"/Vector.iv";
            public const string Log = @"/Log.txt";
            public const string PasswordDisplayText = "Password Display Here";
            public const string NewWebDisplayText = "New Website Name Here";
            public const string NewWebPasswordDisplayText = "New Website Password Here";
            public const string ConfirmNewWebPasswordDisplayText = "Confirm New Password Here";
            public const string FirstTimeUseMessage = "This appears to be your first time using this program. " +
                                                      "\nA special key will be generated for encrypting and decrypting your passwords. " +
                                                      "\nDo not modify this file as you will be unable read the contents of your password file." +
                                                      "\nPlease see the 'READ ME.txt' document in the installation folder for me details.";
            public const string InvalidKeyMessage = "A key is missing or corrupted.If your key is missing, you must reset all data." +
                                                    "\nPlease refer to: 'READ ME.txt' and the Logs 'LOG.txt'!";
        }
        #endregion


        /*
         * LOGIN functionality is in determination of development
         */
        #region Login Screen Constants
        [Obsolete]
        public class LoginScreen
        {
            public const string UserNameDefaultText = "Username";
            public const string LoginPasswordDefaultText = "Password";
        }
        #endregion

        #region Create New User Constants
        [Obsolete]
        public class CreateNewUserScreen
        {
            public const string CreateUserNameText = "New Username";
            public const string NewUserPasswordText = "Password";
            public const string NewUserConfirmPasswprdText = " Confirm Password";
            public const string SelectRevoceryQuestion = "Select a Recovery Question";
            public const string RecoveryAnswer1 = "Recovery Answer 1";
            public const string RecoverAnswer2 = "Recovery Answer 2";
        }
        #endregion

        #region Forgot Password Screen Constants

        #endregion
    }
}
