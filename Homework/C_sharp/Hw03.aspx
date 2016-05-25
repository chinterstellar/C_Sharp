<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["num"] =="") Response.Write("輸入字串格式不正確");
        else
        {
        int n = Convert.ToInt32(Request["num"]);
        string str = "";
        switch (n)
        {
            case 1:
                str = "Monday";
                break;
            case 2:
                str = "Tuesday";
                break;
            case 3:
                str = "Wednesday";
                break;
            case 4:
                str = "Thursday";
                break;
            case 5:
                str = "Friday";
                break;
            case 6:
                str = "Saturday";
                break;
            case 7:
                str = "Sunday";
                break;
            default:
                str = "輸入錯誤";
                break;
        }
        Response.Write(str);
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
    
    </div>
    </form>
</body>
</html>
