using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bmstats
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnStr"].ToString();
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT `id`, `steam`, `name`, `score`, `kills`, `deaths`, `assists`, `suicides`, `tk`, `shots`, `hits`, `headshots`, `connected`,`c4_planted`, `c4_defused`, `damage`, `match_win`, `match_lose`, `first_blood` FROM `rankme` ORDER BY `rankme`.`score` DESC";
                cmd.Connection = con;
                MySqlDataReader rd = cmd.ExecuteReader();
                table.Append("<table border='1'>");
                table.Append("<tr>");
                table.Append("<th>Player ID</th>" +
                    "<th>SteamID</th>" +
                    "<th>Name</th>" +
                    "<th>Score</th>" +
                    "<th>Kills</th>" +
                    "<th>Deaths</th>" +
                    "<th>Assists</th>" +
                    "<th>Suicides</th>" +
                    "<th>TKs</th>" +
                    "<th>Shots Fired</th>" +
                    "<th>Shots Hit</th>" +
                    "<th>Headshots</th>" +
                    "<th>Playtime</th>" +
                    "<th>Bombs Planted</th>" +
                    "<th>Bombs Defused</th>" +
                    "<th>Total Damage</th>" +
                    "<th>Matches Won</th>" +
                    "<th>Matches Lost</th>" +
                    "<th>First Blood</th>");
                table.Append("</tr>");

        //        `id`, `steam`, `name`, `score`, `kills`, `deaths`, `assists`, `suicides`, `tk`, `shots`, 
      //          `hits`, `headshots`, `connected`,`c4_planted`, `c4_defused`, `damage`, `match_win`, `match_lose`, `first_blood`, 
     //           `no_scope`, `no_scope_dis

                if (rd.HasRows)
                {
                    while(rd.Read())
                    {
                        table.Append("<tr>");
                        table.Append("<td>" + rd[0] + "</td>");
                        table.Append("<td>" + rd[1] + "</td>");
                        table.Append("<td>" + rd[2] + "</td>");
                        table.Append("<td>" + rd[3] + "</td>");
                        table.Append("<td>" + rd[4] + "</td>");
                        table.Append("<td>" + rd[5] + "</td>");
                        table.Append("<td>" + rd[6] + "</td>");
                        table.Append("<td>" + rd[7] + "</td>");
                        table.Append("<td>" + rd[8] + "</td>");
                        table.Append("<td>" + rd[9] + "</td>");
                        table.Append("<td>" + rd[10] + "</td>");
                        table.Append("<td>" + rd[11] + "</td>");
                        table.Append("<td>" + rd[12] + "</td>");
                        table.Append("<td>" + rd[13] + "</td>");
                        table.Append("<td>" + rd[14] + "</td>");
                        table.Append("<td>" + rd[15] + "</td>");
                        table.Append("<td>" + rd[16] + "</td>");
                        table.Append("<td>" + rd[17] + "</td>");
                        table.Append("<td>" + rd[18] + "</td>");
                        table.Append("</tr>");
                    }
                }
                table.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                rd.Close();
                rd.Dispose();
            }
        }
    }
}