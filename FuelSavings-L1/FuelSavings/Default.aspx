<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FuelSavings._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h1>Fuel Savings Calculator</h1>
        <table>
            <tbody>
                <tr>
                    <td>
                        <label for="newMpg">New Vehicle MPG</label></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNewMpg" MaxLength="2" />
                        <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="txtNewMpg" Type="Integer" MinimumValue="1" MaximumValue="100" ErrorMessage="Enter a value between 1 and 100"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="tradeMpg">Trade-in MPG</label></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTradeMpg" MaxLength="2" />
                        <asp:RangeValidator runat="server" Display="Dynamic" CssClass="error" ControlToValidate="txtTradeMpg" Type="Integer" MinimumValue="1" MaximumValue="100" ErrorMessage="Enter a value between 1 and 100"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="newPpg">Price per gallon</label></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPpg" MaxLength="4" />
                        <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="txtPpg" Type="Currency" MinimumValue="1" MaximumValue="5" ErrorMessage="Enter a value between 1 and 5"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="milesDriven">Miles Driven</label></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMilesDriven" MaxLength="6" />
                        <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="txtMilesDriven" Type="Integer" MinimumValue="1" MaximumValue="100000" ErrorMessage="Enter a value between 1 and 100,000"></asp:RangeValidator>
                        miles per
                <asp:DropDownList runat="server" ID="ddMilesDrivenTimeFrame">
                    <asp:ListItem Text="Week"></asp:ListItem>
                    <asp:ListItem Text="Month"></asp:ListItem>
                    <asp:ListItem Text="Year"></asp:ListItem>
                </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddMilesDrivenTimeFrame" ErrorMessage="Miles driven timeframe is required."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Date Modified</label></td>
                    <td>
                        <asp:Literal runat="server" ID="litDateModified"></asp:Literal></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button runat="server" CausesValidation="true" OnClick="onBtnCalculateClick" ID="btnCalculate" Text="Calculate" /></td>
                </tr>
                <tr id="trResult" runat="server">
                    <td>
                        <label runat="server" id="lblSavingsOrLoss"></label>
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="litSavingsOrLoss"></asp:Literal></td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
