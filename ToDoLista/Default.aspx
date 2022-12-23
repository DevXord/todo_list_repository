<%@ Page Title="Select user Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ToDoLista._Default" %>

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
        <div style="display: block; text-align: center; margin: auto auto;">
            
            <asp:ListBox ID="lb_selectUser"
                Width="550px" 
                Height="250"
                DataTextField="Name"
                AutoPostBack="false" 
                OnDataBinding="lb_selectUser_DataBinding"
                ViewStateMode="Inherit"
                runat="server"> 
                

            </asp:ListBox> 
        </div>
        <div id="contenerTBBT" style="display: block; text-align: center; margin: 25px auto;">
            
            <asp:TextBox ID="tb_newUser"  CssClass="textClass"  AutoPostBack="false" runat="server"></asp:TextBox>
            <asp:Button runat="server" ID="bt_nextPage" CssClass="buttonClass" AutoPostBack="false" Text="Next"></asp:Button>
        </div>

    </div>
    <div style="display: none;">
       <asp:Button runat="server" ID="SelectUser" OnClick="SelectUser_Click" />
    </div>

     <script src="Scripts/ToDoList/Default.js"></script>
</asp:Content>
 
