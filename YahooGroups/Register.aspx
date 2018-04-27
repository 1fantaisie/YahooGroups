<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="YahooGroups.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <table>
    <tr><td> 
        <asp:Label ID="Label1" runat="server" Text="username"></asp:Label>
        </td><td>
    <asp:TextBox ID="Username" runat="server"></asp:TextBox> </td>
       </tr>
   <tr> <td><asp:Label ID="Label2" runat="server" Text="password"></asp:Label></td>
       <td> <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></td>
       </tr>
      <tr> <td>
        <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Register"  /></td>
          <td> <asp:Label ID="EroareBazaDate" runat="server" Text="Label"></asp:Label></td>
      </tr>

   </table>
</asp:Content>
