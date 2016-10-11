using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.BusinessLogic;

namespace TriageManager.Triage
{
    public partial class ListContents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TriageContentLogic triageContentLogic = new TriageContentLogic();

            grdListContents.DataSource = triageContentLogic.GetTriageContents();
            grdListContents.DataBind();
        }
    }
}