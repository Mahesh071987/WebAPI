<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
          <asp:Label ID="Label1" runat="server" Text="OrgPrefix"></asp:Label>--- <asp:TextBox ID="txtOrgPrefix" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Lname"></asp:Label>--- <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>--- <asp:TextBox ID="txtPassword" TextMode="password" runat="server"></asp:TextBox>
        <asp:Button ID="submit" runat="server" Text="Check" OnClick="submit_Click" />
        <asp:Label ID="Label4" runat="server" Text="Status"></asp:Label>
    </div>
    </form>
</body>
</html>
