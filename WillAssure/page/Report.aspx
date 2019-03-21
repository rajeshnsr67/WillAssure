<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="WillAssure.Views.ViewDocument.Report" %>

<%@ Register Assembly="CrystalDecisions.Web" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     



        
   
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1" Visible="true" ToolPanelView="None" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" Visible="true">
            <Report FileName="D:\Will Assure\WillAssure\WillAssure\CrystalReports\WillTestator.rpt">
            </Report>
        </CR:CrystalReportSource>



    </form>
</body>
</html>
