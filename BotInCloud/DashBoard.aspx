<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="BotInCloud.DashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>Дата: <asp:TextBox ID="DateTB" runat="server"></asp:TextBox></div>
        
        <div>Месяц: <asp:TextBox ID="MonthTB" runat="server"></asp:TextBox></div>
        
        <div>Год: <asp:TextBox ID="YearTB" runat="server"></asp:TextBox></div>
        
        <div>Часы: <asp:TextBox ID="HoursTB" runat="server"></asp:TextBox></div>
        
        <div>Минуты: <asp:TextBox ID="MinTB" runat="server"></asp:TextBox></div>
        
        <div>Секунды: <asp:TextBox ID="SecTB" runat="server"></asp:TextBox></div>
        <br/>
        <asp:RadioButtonList ID="RBList" runat="server">
            <asp:ListItem>Hometask</asp:ListItem>
            <asp:ListItem>Deadline</asp:ListItem>
        </asp:RadioButtonList>
        <br/>
        <div>Предмет/Модуль: <asp:TextBox ID="NameTB" runat="server"></asp:TextBox></div>
        <div>Описание: <asp:TextBox ID="DescTB" runat="server" TextMode="MultiLine"></asp:TextBox></div>
    </div>
        <asp:Button ID="SubmitBut" runat="server" Text="Отправить" OnClick="SubmitBut_Click" />
    <asp:Button ID="ClearBut" runat="server" Text="Очистить БД" OnClick="ClearBut_Click" />
    <br/>
    <br/>
    <asp:Button ID="RunBut" runat="server" Text="Запустить" OnClick="RunBut_Click"/>
    <asp:Button ID="StopBut" runat="server" Text="Остановить" OnClick="StopBut_Click"/>

    </form>
    
</body>
</html>
