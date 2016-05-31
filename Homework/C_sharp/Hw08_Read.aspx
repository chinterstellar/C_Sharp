<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html>

<script runat="server">
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn;
        SqlCommand cmd;
        string sql = null;
        sql = "select * from SalaryDB";
        conn = SqlUtil.GetConnection("MyComp.mdf");
        try
        {
            cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            //Response.Write("<h2>讀取資料</h2><table><tr><th>姓名</th><th>年紀</th><th>地址</th><th>薪水</th></tr>");
            str = "<h2>讀取資料</h2><table><tr><th>姓名</th><th>年紀</th><th>地址</th><th>薪水</th></tr>";
            while (rd.Read())
            {
                /*
                Response.Write("<tr align = center>");
                Response.Write("<td>"+rd["name"] + "</td>");
                Response.Write("<td>"+rd["age"] + "</td>");
                Response.Write("<td>"+rd["address"] + "</td>");
                Response.Write("<td>"+rd["salary"] + "</td>");
                Response.Write("</tr>");
                */
                str += "<tr align = center>";
                str += "<td>" + rd["name"] + "</td>";
                str += "<td>" + rd["age"] + "</td>";
                str += "<td>" + rd["address"] + "</td>";
                str += "<td>" + rd["salary"] + "</td>";
                str += "</tr>";
            }
            //Response.Write("</table>");
            str += "</table>";
            rd.Close();
            cmd.Dispose();
            conn.Close();
        }catch(Exception ex) { };
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="index.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <th><a href="Hw08_Create.html">新增資料</a></th>
                <th><a href="Hw08_Read.aspx">讀取資料</a></th>
                <th><a href="Hw08_Update.html">更新資料</a></th>
                <th><a href="Hw08_Delete.html">刪除資料</a></th>
            </tr>
        </table>
        <%=str %>
    </div>
    </form>
</body>
</html>
