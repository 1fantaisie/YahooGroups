<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewGroup.aspx.cs" Inherits="YahooGroups.NewGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <table style="width: 700px; height: 420px">
        <tr>
            <td style="width: 150px"> 
                <asp:Label ID="Label1" runat="server" Text="Group name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Name" runat="server" Width="225px"></asp:TextBox>
             </td>
          </tr>
            <tr> 
                <td>
                        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Description" runat="server" Height="56px" Width="229px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Group Category"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="Category" runat="server" Height="17px" Width="232px">
                        <asp:ListItem>All Categories</asp:ListItem>
                        <asp:ListItem >Music</asp:ListItem>
                        <asp:ListItem>Games</asp:ListItem>
                        <asp:ListItem >Science</asp:ListItem>
                        <asp:ListItem >Computers and Internet</asp:ListItem>
                        <asp:ListItem >Politics</asp:ListItem>
                        <asp:ListItem >Recreational and Sports</asp:ListItem>
                        <asp:ListItem >Romance and Relationships</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Create Group" OnClick="AddGroup" />
                </td>
                <td>
                    <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
</asp:Content>
