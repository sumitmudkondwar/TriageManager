using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Claims;
using System.Threading;
using System.Web.Configuration;
using System.Data;

namespace TriageManager.Triage
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Col1");
            dt.Columns.Add("Col2");

            var appSettings = System.Configuration.ConfigurationManager.AppSettings;
            var secretmessage = appSettings["secret"] == null ? "" : appSettings["secret"];

            var claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (claimsPrincipal != null && claimsPrincipal.Identity.IsAuthenticated)
            {
                divAuthentic.Visible = true;
                divUnauthentic.Visible = false;

                lblAuthentication.Text = "Authentication Succeeded";
                lblPrincipleName.Text = "Principal Name: " + claimsPrincipal.Identity.Name;
                lblRequestHeaders.Text = Request.Headers["X-MS-CLIENT-PRINCIPAL-NAME"];

                foreach (var claim in claimsPrincipal.Claims)
                {
                    DataRow dr = dt.NewRow();
                    dr["Col1"] = claim.Type;
                    dr["Col2"] = claim.Value;
                    dt.Rows.Add(dr);
                }

                grdClaimPrinciple.DataSource = dt;
                grdClaimPrinciple.DataBind();
            }
            else
            {
                divAuthentic.Visible = false;
                divUnauthentic.Visible = true;
            }

            dt = new DataTable();
            dt.Columns.Add("Col1");
            dt.Columns.Add("Col2");
            foreach (string header in this.Request.Headers)
            {
                DataRow dr = dt.NewRow();
                dr["Col1"] = header;
                dr["Col2"] = this.Request.Headers[header];
                dt.Rows.Add(dr);
            }

            grdRawHTTPHeaders.DataSource = dt;
            grdRawHTTPHeaders.DataBind();
        }
    }
}