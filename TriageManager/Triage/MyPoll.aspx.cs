using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.Models;
using DataAccessLayer.BusinessLogic;

namespace TriageManager.Triage
{
    public partial class MyPoll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            if (Request["TriageDate"] == null && Session["TriageDate"] == null)
                Session["TriageDate"] = triagePollLogic.GetTriageDate(true).Rows[0][0].ToString();
            else if (triagePollLogic.GetValidTriageDate(Request["TriageDate"]))
                Session["TriageDate"] = Request["TriageDate"].ToString();
            else
                ClearAll1();
            //Response.Redirect("~/Default.aspx");

            lblIsTriageAttended.Text = Session["TriageDate"].ToString();

            Session["PollValidation"] = triagePollLogic.PollValidation(HttpContext.Current.User.Identity.Name.ToString(), Convert.ToDateTime(Session["TriageDate"].ToString()));

            if (!IsPostBack)
            {
                ClearAll1();
                dvSuccessMessage.Visible = false;
            }
            if (Convert.ToBoolean(Session["PollValidation"]) == false)
            {
                ClearAll1();
                dvErrorBlock.Visible = true;
                lblErrorMessage.Text = "You have already Submitted Poll for date: " + Session["TriageDate"].ToString();
            }
        }

        protected void rdbIsAttendedYes_CheckedChanged(object sender, EventArgs e)
        {
            btnSubmit.Enabled = true;
            dvAttendedYes.Visible = true;
            dvAttendedNo.Visible = false;
            ClearAll();
            if (Convert.ToBoolean(Session["PollValidation"]) == false)
            {
                ClearAll1();
                dvErrorBlock.Visible = true;
                lblErrorMessage.Text = "You have already Submitted Poll for date: " + Session["TriageDate"].ToString();
            }
        }

        protected void rdbIsAttendedNo_CheckedChanged(object sender, EventArgs e)
        {
            btnSubmit.Enabled = true;
            dvAttendedYes.Visible = false;
            dvAttendedNo.Visible = true;
            ClearAll();
            if (Convert.ToBoolean(Session["PollValidation"]) == false)
            {
                ClearAll1();
                dvErrorBlock.Visible = true;
                lblErrorMessage.Text = "You have already Submitted Poll for date: " + Session["TriageDate"].ToString();
            }
        }

        private void ClearAll()
        {
            rdbTriageLevel1.Checked = false;
            rdbTriageLevel2.Checked = false;
            rdbTriageLevel3.Checked = false;
            rdbTriageLevel4.Checked = false;

            rdbTriageQuality1.Checked = false;
            rdbTriageQuality2.Checked = false;
            rdbTriageQuality3.Checked = false;

            rdbPresentation1.Checked = false;
            rdbPresentation2.Checked = false;
            rdbPresentation3.Checked = false;

            txtComments.Text = string.Empty;
            txtReason.Text = string.Empty;

            dvErrorBlock.Visible = false;
        }

        private void ClearAll1()
        {
            rdbIsAttendedYes.Checked = false;
            rdbIsAttendedNo.Checked = false;

            dvAttendedYes.Visible = false;
            dvAttendedNo.Visible = false;

            btnSubmit.Enabled = false;

            ClearAll();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            dvSuccessMessage.Visible = false;
            ClearAll1();
        }

        private bool ValidationManager()
        {
            if (rdbIsAttendedYes.Checked)
            {
                if (rdbTriageLevel1.Checked == false && rdbTriageLevel2.Checked == false && rdbTriageLevel3.Checked == false && rdbTriageLevel4.Checked == false)
                {
                    lblErrorMessage.Text = "Please Select Triage Level";
                    return false;
                }
                else if (rdbTriageQuality1.Checked == false && rdbTriageQuality2.Checked == false && rdbTriageQuality3.Checked == false)
                {
                    lblErrorMessage.Text = "Please Select Triage Quality";
                    return false;
                }
                else if (rdbPresentation1.Checked == false && rdbPresentation2.Checked == false && rdbPresentation3.Checked == false)
                {
                    lblErrorMessage.Text = "Please Select Triage Presentation";
                    return false;
                }
                else if (txtComments.Text.Trim() == string.Empty)
                {
                    lblErrorMessage.Text = "Please enter comments";
                    return false;
                }
            }
            else
            {
                if (txtReason.Text.Trim() == string.Empty)
                {
                    lblErrorMessage.Text = "Reason is Mandatory.";
                    return false;
                }
            }
            return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidationManager())
            {
                int retval = 0;

                dvErrorBlock.Visible = false;

                TriagePoll triagePoll = new TriagePoll();
                TriagePollLogic triagePollLogic = new TriagePollLogic();

                
                triagePoll.TriageDate = Convert.ToDateTime(Session["TriageDate"].ToString());
                triagePoll.Alias = HttpContext.Current.User.Identity.Name.ToString();

                if (rdbIsAttendedYes.Checked)
                {
                    triagePoll.IsTriageAttended = "Yes";
                    triagePoll.TriageLevel = GetTriageLevel();
                    triagePoll.TriageQuality = GetTriageQuality();
                    triagePoll.Presentation = GetTriagePresentation();
                    triagePoll.Comments = txtComments.Text;
                    triagePoll.Reason = string.Empty;
                }
                else
                {
                    triagePoll.IsTriageAttended = "No";
                    triagePoll.TriageLevel = 0;
                    triagePoll.TriageQuality = string.Empty;
                    triagePoll.Presentation = string.Empty; 
                    triagePoll.Comments = string.Empty;
                    triagePoll.Reason = txtReason.Text;
                }
                retval = triagePollLogic.SubmitPoll(triagePoll);

                if (retval > 0)
                {
                    ClearAll1();
                    lblSuccessMessage.Text = "Thank you for submitting your Feedback!!!";
                    dvSuccessMessage.Visible = true;
                }
                else
                {
                    Response.Redirect("~/CustomError.aspx");
                }
            }
            else
            {
                dvErrorBlock.Visible = true;
            }
        }

        private int GetTriageLevel()
        {
            if (rdbTriageLevel1.Checked)
            {
                return 100;
            }
            else if (rdbTriageLevel2.Checked)
            {
                return 200;
            }
            else if (rdbTriageLevel3.Checked)
            {
                return 300;
            }
            else if (rdbTriageLevel4.Checked)
            {
                return 400;
            }
            else throw new Exception("Please select Triage Level");
        }

        private string GetTriageQuality()
        {
            if (rdbTriageQuality1.Checked)
            {
                return "Above Expectation";
            }
            else if (rdbTriageQuality2.Checked)
            {
                return "Met Expectation";
            }
            else if (rdbTriageQuality3.Checked)
            {
                return "Below Expectation";
            }
            else throw new Exception("Please Select Triage Quality");
        }

        private string GetTriagePresentation()
        {
            if (rdbPresentation1.Checked)
            {
                return "Good";
            }
            else if (rdbPresentation2.Checked)
            {
                return "Averare";
            }
            else if (rdbPresentation3.Checked)
            {
                return "Need Improvement";
            }
            else throw new Exception("Please Select Triage Presentation");
        }
    }
}