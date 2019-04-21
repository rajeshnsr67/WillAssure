<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeTemplate.aspx.cs" Inherits="WillAssure.page.ChangeTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
</head>
<body>
   
    <form id="form1" runat="server">
         <div class="row">
        
        <center><h4>Template Selection</h4></center>
             <br />
       <center> 
            <asp:DropDownList runat="server" ID="ddltemplate" Width="400" CssClass="form-control">
                <asp:ListItem Value="0" Text="--Select Template--" />
                <asp:ListItem Value="1" Text="WillTestator1" />
                <asp:ListItem Value="2" Text="WillTestator2" />
                <asp:ListItem Value="3" Text="WillTestator3" />
                <asp:ListItem Value="4" Text="WillTestator4" />
                <asp:ListItem Value="5" Text="WillTestator5" />
            </asp:DropDownList>
           </center>
             <br />
    <center>
        <asp:button text="Submit" ID="btnupdatetemplate" CssClass="btn btn-primary" runat="server" OnClick="btnupdatetemplate_Click"  />
    </center>
    </div>
        
    </form>
</body>
</html>
