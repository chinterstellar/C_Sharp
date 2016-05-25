<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Random rd = new Random();
        int n = rd.Next(1, 6);
        str = "<img src=" + n.ToString() + ".jpg>";
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
        <%=str %>
    </div>
    </form>
</body>
</html>
