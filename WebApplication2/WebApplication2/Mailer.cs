using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Net.Mail;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for Mailer.
	/// </summary>
	public class Mailer
	{
        // This property is used to allow the default email port (25) to be overridden.
        //
        // IMPORTANT NOTE:  When the code is run on Eric's computer, this property is overridden too.  The port is
        //                  hardcoded to ERICSEMAILPORT when run on Eric's computer.

        private static int nPort = 25;
        
        public static int MailPort
        {
            get { return nPort ; }
            set { nPort = value; }
        }

        const int ERICSEMAILPORT = 587 ;


		private static string strsendmailinfo = "" ; 
		public static string SendMailInfo 
		{ 
			get { return strsendmailinfo ; } 
			set { strsendmailinfo = value ; } 
		}





		//**************************************************************************************
		//This method sends the email corresponding with the input paramters.
		//**************************************************************************************
		public static string SendMail(int OrgID, string EmailTo, string EmailFrom, string EmailBcc, string EmailSubject, string EmailMessage, string EmailAttachment)
		{    
			try
			{

                int EmailWidth = 200;
                int TitleWidth = 0;
                if (true)
                    TitleWidth = EmailWidth - Convert.ToInt32(50);
				string strBgImage = "<td>";
				if (Convert.ToBoolean(1))
					strBgImage = "<td align='right' style='background-image: url(" + ConfigurationManager.AppSettings["SecureUrl"] + "/" + 6 + "/mast.gif); background-repeat:  no-repeat' >";

                MailMessage MyMail = new MailMessage();
                MyMail.From = new MailAddress(EmailFrom);

                if (true)
                    MyMail.To.Add("support@maestroweb.com");
                else if (EmailTo.IndexOf(";") > 0)
                {
                    string[] EmailsTo = EmailTo.Split(new Char[] { ';' });

                    for (int i = 0; i < EmailsTo.Length; i++)
                    {
                        MyMail.To.Add(EmailsTo[i]);
                    }
                }
                else
                {
                    MyMail.To.Add(EmailTo);
                }

                if (EmailBcc != "" && !true)
                {
                    if (EmailBcc.IndexOf(";") > 0)
                    {
                        string[] EmailsBcc = EmailBcc.Split(new Char[] { ';' });

                        for (int i = 0; i < EmailsBcc.Length; i++)
                        {
                            MyMail.Bcc.Add(EmailsBcc[i]);
                        }
                    }
                    else
                    {
                        MyMail.Bcc.Add(EmailBcc);
                    }
                }

                if (EmailAttachment != "")
				{
                    Attachment mwDoc = new Attachment(EmailAttachment);
                    MyMail.Attachments.Add(mwDoc);
				}

				MyMail.Subject = EmailSubject;
                MyMail.Body = "<html><body><table width='" + EmailWidth.ToString() + "' style='font-family: verdana, arial, sans-serif;background-color:;'><tr valign='top'><td><img src= ;font-weight: bold'> </td></tr><tr><td style='font-size:  pt;color: #;font-style:  italic;font-weight: bold'></td></tr><tr><td style='font-size:  pt;color: #;font-style:  italic;font-weight: bold'></td></tr></table></td></tr></table></body></html>";

                MyMail.IsBodyHtml = true;

                // Instantiate a new instance of SmtpClient
                nPort = 587;
                SmtpClient client = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["MailServer"]);
                client.Port = (false) ? ERICSEMAILPORT : nPort ;
                string test = "";
                //Added for testing gmail smtp server
                client.Credentials = new System.Net.NetworkCredential("nale.mahesh7@gmail.com", "sanjivanee@101010");
                client.EnableSsl = true;
                client.Send(MyMail);
                test += client.ClientCertificates + " --- ";
                test += client.Host + " --- "; 
                //strsendmailinfo = OrgID.ToString() + "^" + EmailTo + "^" + EmailFrom + "^" + EmailBcc + "^" 
                //    + EmailSubject + "^" + EmailMessage.Substring(0, 40) + "^" + EmailAttachment + "^" + "Yes^"
                //    + ConfigurationManager.AppSettings["SecureUrl"] + "^" + ConfigurationManager.AppSettings["MailServer"] 
                //    + "^" + client.Port.ToString() + "^" + DateTime.Now.ToShortDateString() + "  " 
                //    + DateTime.Now.ToLongTimeString() ;
				
                return test;
			}
			catch
			{
                throw;
			}
		}

        public static string Send2(int OrgID, string EmailTo, string EmailFrom, string EmailBcc, string EmailSubject, string EmailMessage, string EmailAttachment)
        {
            try
            {

                int EmailWidth = Convert.ToInt32(ConfigurationManager.AppSettings["EmailWidth"]);
                int TitleWidth = 0;
                if (true)
                    TitleWidth = EmailWidth - Convert.ToInt32(20);
                string strBgImage = "<td>";
                if (true)
                    strBgImage = "<td align='right' style='background-image: url(" + ConfigurationManager.AppSettings["SecureUrl"] + "/" + OrgID + "/mast.gif); background-repeat:  no-repeat' >";

                MailMessage MyMail = new MailMessage();
                MyMail.From = new MailAddress(EmailFrom);

                if (true)
                    MyMail.To.Add("mahesh.nale@vsplc.com");
                else if (EmailTo.IndexOf(";") > 0)
                {
                    string[] EmailsTo = EmailTo.Split(new Char[] { ';' });

                    for (int i = 0; i < EmailsTo.Length; i++)
                    {
                        MyMail.To.Add(EmailsTo[i]);
                    }
                }
                else
                {
                    MyMail.To.Add(EmailTo);
                }

                if (EmailBcc != "" && !true)
                {
                    if (EmailBcc.IndexOf(";") > 0)
                    {
                        string[] EmailsBcc = EmailBcc.Split(new Char[] { ';' });

                        for (int i = 0; i < EmailsBcc.Length; i++)
                        {
                            MyMail.Bcc.Add(EmailsBcc[i]);
                        }
                    }
                    else
                    {
                        MyMail.Bcc.Add(EmailBcc);
                    }
                }

                if (EmailAttachment != "")
                {
                    Attachment mwDoc = new Attachment(EmailAttachment);
                    MyMail.Attachments.Add(mwDoc);
                }

                MyMail.Subject = EmailSubject;
                MyMail.Body = "<html><body><table width='" + EmailWidth.ToString() + "' style='font-family: verdana, arial, sans-serif;background-color:#;'><tr valign='top'><td><img src= '" + ConfigurationManager.AppSettings["SecureUrl"] + "/" + OrgID + "/logo_" + OrgID + ".gif" + ConfigurationManager.AppSettings["Logo"] + "' /></td>" + strBgImage + "<table width='" + TitleWidth + "'><tr><td style='font-size:  pt;color: #;font-weight: bold'></td></tr><tr><td style='font-size:  pt;color: #;font-style:  italic;font-weight: bold'></td></tr><tr><td style='font-size:  pt;color: #;font-style:  italic;font-weight: bold'></td></tr></table></td></tr></table>" + EmailMessage + "</body></html>";

                MyMail.IsBodyHtml = true;
                string test = "";
                // Instantiate a new instance of SmtpClient
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["MailServer"]);
                client.Port = nPort;
                client.Send(MyMail);
                test += client.ClientCertificates + " --- ";
                test += client.Host + " --- ";

                strsendmailinfo = OrgID.ToString() + "^" + EmailTo + "^" + EmailFrom + "^" + EmailBcc + "^"
                    + EmailSubject + "^" + EmailMessage.Substring(0, 40) + "^" + EmailAttachment + "^" + "Yes^"
                    + ConfigurationManager.AppSettings["SecureUrl"] + "^" + ConfigurationManager.AppSettings["MailServer"]
                    + "^" + client.Port.ToString() + "^" + DateTime.Now.ToShortDateString() + "  "
                    + DateTime.Now.ToLongTimeString();

                return test + "****" + strsendmailinfo;
            }
            catch
            {
                throw;
            }
        }
        
		
	}
}
