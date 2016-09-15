<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="Job.WebMvc.ReportView.ReportViewer" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>&lt;Scegli un report&gt;</asp:ListItem>
        <asp:ListItem Value="WorkPeople.rdl">Work People</asp:ListItem>
        <asp:ListItem Value="WorkCustomer.rdl">Work Customer</asp:ListItem>
        </asp:DropDownList><asp:Button ID="Button1" runat="server" Text="Vedi" />
    </div>
    <div>
        <rsweb:ReportViewer ID="rptViewer" runat="server" Height="100%" Width="100%">
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
