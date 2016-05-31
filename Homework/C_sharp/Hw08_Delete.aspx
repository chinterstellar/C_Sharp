<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html>

<script runat="server">
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Request["name"];
        SqlConnection conn;
        SqlCommand cmd;
        string DeleteString = null;
        DeleteString = "Delete from SalaryDB where name='" + name + "'";
        conn = SqlUtil.GetConnection("MyComp.mdf");
        int flag = 0;
        try
        {
            cmd = new SqlCommand(DeleteString, conn);
            flag=cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        catch(Exception ex) { };
        if (flag!=0)
        {
            //Response.Write("新增成功");
            str = "刪除成功";
        }
        else
        {
            //Response.Write("新增失敗");
            str = "刪除失敗";
        }
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
        <br/>
        <%=str %>
    </div>
    </form>
</body>
</html>
