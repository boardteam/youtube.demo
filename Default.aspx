<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
LBAH

 
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID"
EmptyDataText="No records has been added." 
        DataSourceID="SqlDataSourceRegistration">
<Columns>
    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Country" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtCountry" runat="server" Text='<%# Eval("Country") %>'></asp:TextBox>
        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
    </asp:TemplateField>
    <asp:CommandField ButtonType="Link" ShowEditButton="true" 
        ShowDeleteButton="true" ItemStyle-Width="150">
<ItemStyle Width="150px"></ItemStyle>
    </asp:CommandField>
</Columns>
</asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceRegistration" runat="server" 
        ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>" 
        SelectCommand="SELECT * FROM [Customers]"></asp:SqlDataSource>
<table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
<tr>
    <td style="width: 150px">
        Name:<br />
        <asp:TextBox ID="txtName" runat="server" Width="140" />
    </td>
    <td style="width: 150px">
        Country:<br />
        <asp:TextBox ID="txtCountry" runat="server" Width="140" />
    </td>
    <td style="width: 100px">
        <asp:Button ID="btnAdd" runat="server" Text="Add"  />
    </td>
</tr>
</table>

</body>
</html>