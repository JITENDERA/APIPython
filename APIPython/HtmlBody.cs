
using System.Linq;

using System.Data;

namespace APIPython
{
    public class HtmlBody
    {
        
        //"Case Number","Subject","Area","Catagory","Status","Time Loged(Hr)","Billable Time(Min)","Assigned To"
        public string MailBodyData(DataTable maildata)
        {
            DataRow dr = maildata.Rows[0];
            dr.Delete();

            var result = from test in maildata.AsEnumerable()

                          group test by new { Area = test[" Area "] } into groupby

                          select new

                          {

                              Value = groupby.Key,

                              ColumnValues = groupby

                          };

            string MailBody = "<table style=\"color:blue; border: 1px solid #dddddd\"><tr><th>Area</th><th>Subject</th><th>Billable Time(Min)</th><th>Assigned To</th></tr>";

            foreach (var key in result)

            {

                MailBody += "<p style=\"color:red\">" + key.Value.Area + "</p>";

                foreach (var columnValue in key.ColumnValues)

                {
                    MailBody += "<tr><td>" + columnValue["Case Number "].ToString() + "</td><td>" + columnValue[" Subject "].ToString() + "</td><td>" + columnValue[" Billable Time(Min) "].ToString() + "</td><td>" + columnValue[" Assigned To"].ToString() + "</td></tr>";

                }

            }
            MailBody += "</table>";
            return MailBody;
        }
    }
}
