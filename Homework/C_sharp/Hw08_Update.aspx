<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html>

<script runat="server">
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string odd_name = Request["odd_name"];
        string new_name = Request["new_name"];
        string new_age = Request["new_age"];
        string new_address = Request["new_address"];
        string new_salary = Request["new_salary"];
        SqlConnection conn;
        SqlCommand cmd;
        string UpdateString = null;
        UpdateString = "update SalaryDB set name='"+new_name+"',address='"+new_address+"', age="+new_age+",salary="+new_salary+" where name='"+odd_name+"'";
        conn = SqlUtil.GetConnection("MyComp.mdf");
        int flag = 0;
        try
        {
            cmd = new SqlCommand(UpdateString, conn);
            flag=cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        catch(Exception ex) { };
        if (flag!=0)
        {
            //Response.Write("新增成功");
            str = "更新成功";
        }
        else
        {
            //Response.Write("新增失敗");
            str = "更新失敗";
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
        <br />
        <%=str %>
    </div>
    </form>
</body>
</html>
