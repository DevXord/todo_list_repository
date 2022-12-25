<%@ Page Title="Select user Page" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ToDoLista._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>

        window.onloadstart = function () {
            if (localStorage.getItem('UserName') != null || localStorage.getItem('UserName') != "")
                localStorage.setItem('UserName', "");

        }

    </script>


    <link href="Content/ToDoList/Default.css" rel="stylesheet" />


    <div class="jumbotron">
        <p>Select a user or enter a new name</p>

        <div id="contenerTBBT">
            <ajaxToolkit:ComboBox ID="cmb_selectUser" AutoPostBack="False" DataValueField="ID_User" DataTextField="Name" OnDataBinding="cmb_selectUser_DataBinding" runat="server" ToolTip="Select user" >
            </ajaxToolkit:ComboBox>

            <asp:TextBox ID="tb_newUser" TextMode="SingleLine" CssClass="textClass" AutoPostBack="false" runat="server"></asp:TextBox>
            <asp:LinkButton ID="bt_nextPage" ToolTip="Login" CssClass="buttonClass" runat="server" >
                <img src="~/Image/Icon/login_32_loginDocument_32.png" runat="server"/>
                <asp:Label Text="LogIN" class="labelAddButton" runat="server"></asp:Label></>
            </asp:LinkButton>
        </div>

    </div>
    <div style="display: none;">
        <asp:Button runat="server" ID="SelectUser" OnClick="SelectUser_Click" />
    </div>

    <script src="Scripts/ToDoList/Default.js"></script>
</asp:Content>

