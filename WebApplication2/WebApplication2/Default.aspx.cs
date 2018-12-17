using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2;

namespace WebApplication2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {

                string OrgPrefix = txtOrgPrefix.Text;
                string Lname = txtLname.Text;
                string Password = txtPassword.Text.Trim();

                //bool Status = Mailer.SendMail(6, OrgPrefix, "", "", "Test", "Test", "");
                string ststus2 = Mailer.Send2(6, OrgPrefix, "support@maestroweb.com", "", "Test", "Test", "");
                Label4.Text = ststus2;
            }
            catch (Exception ex)
            {
                Label4.Text = ex.StackTrace.ToString();
            }
        }
    }
}