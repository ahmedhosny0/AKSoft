<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report1.aspx.cs" Inherits="AKSoft.Reports.Report1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">تسجيل فاتورة مبيعات</asp:LinkButton>
&nbsp;<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="Reports\Report1.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    </form>

</body>
</html>
