<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewTopic.aspx.cs" Inherits="YahooGroups.NewTopic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 700px; height: 420px">
        <tr>
            <td style="width: 150px"> 
                <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="PostTitle" runat="server" Width="225px"></asp:TextBox>
             </td>
          </tr>
            <tr> 
                <td>
                        <asp:Label ID="Label2" runat="server" Text="Message"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Message" runat="server" Height="56px" Width="228px"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Create Topic" OnClick="AddTopic" />
                </td>
                <td>
                    <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
</asp:Content>
