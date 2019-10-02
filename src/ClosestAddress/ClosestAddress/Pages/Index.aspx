<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ClosestAddress.Pages.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lblAddress" runat="server">Enter the address:</asp:Label>
  <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqAddress" runat="server" ControlToValidate="txtAddress" Text="Please enter a valid address"></asp:RequiredFieldValidator>
        <asp:Button ID="btnSubmitAddress" runat="server" OnClick="btnSubmitAddress_Click" Text="Find Closest Address" />

        <asp:Repeater ID="repAddress" runat="server" OnItemDataBound="repAddress_ItemDataBound">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            Address
                        </td>
                        <td>
                            Distance (in KM)
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblRepAddress" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblRepDistance" runat="server"></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
          </div>
    </form>
</body>
</html>
