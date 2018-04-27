<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="YahooGroups.Topic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="TopicTitle" runat="server" Text="Label"></asp:Label>
    <table>
    <asp:Label ID="Messages" runat="server" ></asp:Label>
        <tr>
            <td> <asp:TextBox ID="ReplyMessage" runat="server" Height="105px" Width="375px" ></asp:TextBox>
  </td>
            <td>   <asp:Button ID="Reply" runat="server" Text="Reply" OnClick="reply" /></td>
        </tr>
    </table>
   
   
     <asp:Label ID="EroareBazaDate" runat="server" Text=""></asp:Label>
</asp:Content>
