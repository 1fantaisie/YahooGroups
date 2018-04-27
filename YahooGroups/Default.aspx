<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YahooGroups._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="GroupName" runat="server"></asp:TextBox>
    <asp:Button ID="SearchGroup" runat="server" Text="Search group" onclick="Search"/>
    
    <asp:HyperLink href="NewGroup.aspx" runat="server" ID="creategroup">Create group</asp:HyperLink> <br>
    <table>
        <tr>
            <td>
                <asp:HyperLink ID="SearchedName" runat="server"></asp:HyperLink>
            </td>
            <td>
                 <asp:Label ID="SearchedCategory" runat="server" Text=""></asp:Label>
            </td>
            <td>
                 <asp:Label ID="SearchedDescription" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Group name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Group Category"></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label3" runat="server" Text="Group Description"></asp:Label>
            </td>
        </tr>
    <asp:Label ID="Name" runat="server" Text=""></asp:Label>
    </table>
    <asp:Label ID="EroareBazaDate" runat="server" Text=""></asp:Label>
   

</asp:Content>
