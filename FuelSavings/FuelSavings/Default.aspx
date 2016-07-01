<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FuelSavings._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h1>Fuel Savings Calculator</h1>
        <table>
          <tbody>
          <tr>
            <td><label for="newMpg">New Vehicle MPG</label></td>
            <td><asp:TextBox runat="server" ID="txtNewMpg" /></td>
          </tr>
          <tr>
            <td><label for="tradeMpg">Trade-in MPG</label></td>
            <td><asp:TextBox runat="server" ID="txtTradeMpg" /></td>
          </tr>
          <tr>
            <td><label for="newPpg">Price per gallon</label></td>
            <td><asp:TextBox runat="server" ID="txtPpg" /></td>
          </tr>
          <tr>
            <td><label for="milesDriven">Miles Driven</label></td>
            <td>
                <asp:TextBox runat="server" ID="txtMilesDriven" /> miles per
                <asp:DropDownList runat="server" ID="ddMilesDrivenTimeFrame">
                    <asp:ListItem Text="Week"></asp:ListItem>
                    <asp:ListItem Text="Month"></asp:ListItem>
                    <asp:ListItem Text="Year"></asp:ListItem>
                </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td><label>Date Modified</label></td>
            <td><asp:Literal runat="server" ID="litDateModified"></asp:Literal></td>
          </tr>
          </tbody>
        </table>

        <asp:Button runat="server" OnClick="onBtnCalculateClick" ID="btnCalculate" Text="Calculate" />

        <table id="tblResult" runat="server" visible="false">
            <tr>
                <td><label runat="server" ID="lblSavingsOrLoss"></label></td>
                <td><asp:Literal runat="server" ID="litSavingsOrLoss"></asp:Literal></td>
            </tr>
        </table>
    </div>
</asp:Content>
