<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deafult.aspx.cs" Inherits="MesclarImagens.Deafult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;<asp:Button ID="btUpload" runat="server" onclick="btUpload_Click" Text="Upload" />
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" />
        <asp:label runat="server" text="" ID="lblErro"></asp:label>
    </div>
    </form>
</body>

</html>
