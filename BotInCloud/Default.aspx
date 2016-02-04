<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BotInCloud.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div><span>Password: </span>
            <asp:TextBox ID="PasswordTB" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="StopButton" runat="server" Text="Stop" OnClick="StopButton_Click" />
        <asp:Button ID="RunButton" runat="server" Text="Run" OnClick="RunButton_Click" />
    </div>
    </form>
</body>
</html>
