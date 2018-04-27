<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="YahooGroups.Group" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Label ID="GroupName" runat="server" Text="Label" style="font-size:25px;margin-top:25px;"></asp:Label>
    <asp:Label ID="GroupCategory" runat="server" Text="Label"  style="font-size:20px;margin-left:30px;"></asp:Label> <br>
    <asp:Label ID="GroupDescription" runat="server" Text="Label" style="margin-top:10px;display:inline-block;margin-bottom:20px;"></asp:Label> <br>
   
    <asp:Button ID="JoinGroupButton" runat="server" Text="Join Group" onclick="JoinGroup" BorderColor="#0099FF" BorderStyle="Outset" BackColor="#CCCCCC" ForeColor="#333333" />
    <asp:Label ID="Pending" runat="server" style="padding:5px;" Text="Pending Group Joining Request" BackColor="#CCCCCC" BorderColor="#9966FF" BorderStyle="Inset" ForeColor="#333333"></asp:Label>
    <asp:Label ID="GroupMember" runat="server" Text="Group Joined" visible="false" style="margin-right:20px;padding:5px;" BorderStyle="Inset" BorderWidth="3px" BorderColor="#00CC00" BackColor="#CCCCCC"></asp:Label>
    <asp:HyperLink ID="MembersList" runat="server" Visible="False" style="margin-right:20px;padding:5px;text-decoration:none;" BorderStyle="Outset" BackColor="#CCCCCC" BorderColor="#0099FF" ForeColor="#333333">View Group Members</asp:HyperLink>
     <asp:HyperLink ID="Name"  runat="server" style="margin-bottom:12px;display:inline-block;padding:5px;text-decoration:none;" BorderStyle="Outset" BackColor="#CCCCCC" BorderColor="#FF9900" ForeColor="#333333">Create topic</asp:HyperLink>
   
     <asp:Label ID="EroareBazaDate" runat="server" ></asp:Label>
    <table>
    <asp:Label ID="Requests" runat="server" Text=""></asp:Label>
    </table>
     <table>
         <tr>
             <td>
                 <asp:Label ID="Label1" runat="server" Text="Existing topics"></asp:Label>
             </td>
         </tr>
    <asp:Label ID="Topics" runat="server" ></asp:Label>
    </table>
     
</asp:Content>
