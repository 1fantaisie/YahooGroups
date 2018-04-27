<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyGroups.aspx.cs" Inherits="YahooGroups.MyGroups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table>
         <tr>
             <td>
                 <asp:Label ID="Label1" runat="server" Text="Group Name"></asp:Label>
             </td>
             <td>
                 <asp:Label ID="Label2" runat="server" Text="Role"></asp:Label>
             </td>
           </tr>
    <asp:Label ID="Groups" runat="server" Text=""></asp:Label>
    </table>
    <asp:Label ID="EroareBazaDate" runat="server" Text=""></asp:Label>
</asp:Content>
