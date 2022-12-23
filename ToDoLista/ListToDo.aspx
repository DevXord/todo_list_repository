<%@ Page Title="List ToDo"  Language="C#" EnableEventValidation="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListToDo.aspx.cs" Inherits="ToDoLista.ListToDo" %>

<%@ Register Src="~/Controls/ListTODOControl.ascx" TagPrefix="uc1" TagName="ListTODOControl" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
     <script>
         window.onloadstart = function () {
             if (localStorage.getItem('UserName') == null || localStorage.getItem('UserName') == "")
                 window.open("../", '_self');
             
         }                   

     </script>


     
    <link href="Content/ToDoList/ListToDo.css" rel="stylesheet" />

    <div class="jumbotron">
        <uc1:ListTODOControl runat="server" id="ListTODOControl" />

        

    </div>
    <script src="Scripts/ToDoList/ListToDo.js"></script>
    
</asp:Content>
