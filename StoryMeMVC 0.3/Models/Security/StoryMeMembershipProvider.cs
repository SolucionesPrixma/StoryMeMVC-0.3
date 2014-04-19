using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;

using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;
using HigLabo.Net.Smtp;

namespace StoryMeMVC.Models.Security
{
    public class StoryMeMembershipProvider : ExtendedMembershipProvider
    {
        StoryMeMVC.Models.Context.StoryMeContext db;
        public override bool ConfirmAccount(string accountConfirmationToken)
        {
            throw new NotImplementedException();
        }

        public override bool ConfirmAccount(string userName, string accountConfirmationToken)
        {
            throw new NotImplementedException();
        }

        public override string CreateAccount(string userName, string password, bool requireConfirmationToken)
        {
            throw new NotImplementedException();
        }

        public override string CreateUserAndAccount(string userName, string password, bool requireConfirmation, IDictionary<string, object> values)
        {

            db = new Context.StoryMeContext();
            Usuarios ent = new Usuarios();
            ent.USR_CREATIONDATE = DateTime.Now;
            ent.USR_NOMBRE = values["Nombre"].ToString();
            ent.USR_PASSWORD = EncryptPassword(password);
            ent.USR_ROL = "USER";
            ent.USR_SENTMAIL = 0;
            ent.USR_SRC = "WEB";
            ent.USR_USER = userName;
            db.Usuarios.Add(ent);
            if (sendMail(ent))
                db.SaveChanges();
            return "";
        }

        public bool sendMail(Usuarios ent)
        {


            SmtpClient smtp = new SmtpClient();
            smtp.ServerName = "smtp.zoho.com";
            smtp.HostName = "smtp.zoho.com";
            smtp.Port = 465;
            smtp.UserName = "info@storyme.co";
            smtp.Password = "StoryMe*2014";
            smtp.EncryptedCommunication = SmtpEncryptedCommunication.Ssl;
            smtp.AuthenticateMode = SmtpAuthenticateMode.Auto;
            smtp.Connect();
            smtp.Authenticate();
            smtp.AuthenticateByLogin();
            
            SmtpMessage msg = new SmtpMessage();
            msg.From = new HigLabo.Net.Mail.MailAddress("info@storyme.co");
            msg.To.Add(new HigLabo.Net.Mail.MailAddress(ent.USR_USER));
            msg.Subject = ent.USR_NOMBRE + ", te damos la bienbenida a StoryMe";
            msg.IsHtml = true;
            msg.BodyText = "Hola";

            
            //System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            //msg.To.Add(ent.USR_USER);
            //msg.From = new MailAddress("info@storyme.co", "Story Me", System.Text.Encoding.UTF8);
            //msg.Subject = ent.USR_NOMBRE + ", te damos la bienbenida a StoryMe";
            //msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //msg.Body =
            //    "<img name=\"imagen_interna_correo\" src=\"http://storyme.co/images/imagen_interna_correo.png\" width=\"1000\" height=\"574\" border=\"0\" id=\"imagen_interna_correo\" usemap=\"#m_imagen_interna_correo\" alt=\"\" />" +
            //    "<map name=\"m_imagen_interna_correo\" id=\"m_imagen_interna_correo\">" +
            //    "<area shape=\"rect\" coords=\"528,286,560,320\" href=\"https://twitter.com/StoryMe_co\" target=\"_blank\" alt=\"\" />" +
            //    "<area shape=\"rect\" coords=\"494,286,525,318\" href=\"http://instagram.com/storyme_co\" target=\"_blank\" alt=\"\" />" +
            //    "<area shape=\"rect\" coords=\"461,286,492,318\" href=\"https://www.facebook.com/pages/Storyme_co/800258586667974?fref=ts\" target=\"_blank\" alt=\"\" />" +
            //    "<area shape=\"rect\" coords=\"397,492,642,541\" href=\"http://storyme.co\" target=\"_blank\" alt=\"\" />" +
            //    "</map>";
            //msg.BodyEncoding = System.Text.Encoding.UTF8;
            //msg.IsBodyHtml = true;

            ////Aquí es donde se hace lo especial
            //SmtpClient client = new SmtpClient();
            //client.Credentials = new System.Net.NetworkCredential("info@storyme.co", "StoryMe*2014");
            //client.Port = 465;
            //client.Host = "smtp.zoho.com";
            //client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
       
            //client.UseDefaultCredentials = false;
            try
            {
                if (smtp.Authenticate())
                {
                    var rs = smtp.SendMail(msg);
                    if (!rs.SendSuccessful)
                    {

                    }
                }
                return false; 
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }

        public override bool DeleteAccount(string userName)
        {
            throw new NotImplementedException();
        }

        public override string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow)
        {
            throw new NotImplementedException();
        }

        public override ICollection<OAuthAccountData> GetAccountsForUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetCreateDate(string userName)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetLastPasswordFailureDate(string userName)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetPasswordChangedDate(string userName)
        {
            throw new NotImplementedException();
        }

        public override int GetPasswordFailuresSinceLastSuccess(string userName)
        {
            throw new NotImplementedException();
        }

        public override int GetUserIdFromPasswordResetToken(string token)
        {
            throw new NotImplementedException();
        }

        public override bool IsConfirmed(string userName)
        {
            throw new NotImplementedException();
        }

        public override bool ResetPasswordWithToken(string token, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            db = new Context.StoryMeContext();
            password = EncryptPassword(password);
            return db.Usuarios.Where(a => a.USR_USER == username && a.USR_PASSWORD == password).FirstOrDefault() != null;

        }
        /// <summary>
        /// Procuses an MD5 hash string of the password
        /// </summary>
        /// <param name="password">password to hash</param>
        /// <returns>MD5 Hash string</returns>
        public static string EncryptPassword(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}