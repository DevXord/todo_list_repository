<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="ListTODOControl.ascx.cs" Inherits="ToDoLista.Controls.ListTODOControl" %>
<asp:HiddenField ID="hf_listToDo"  runat="server" />
<p>ToDo List</p>
<asp:GridView ID="gv_toDoList"
    OnDataBinding="gv_toDoList_DataBinding"
    AutoGenerateColumns="False"
    AllowPaging="True"
    CssClass="gv_toDoList"
    PagerStyle-CssClass="gv_toDoList_pager"
    HeaderStyle-CssClass="gv_toDoList_header" 
    RowStyle-CssClass="gv_toDoList_rows"
    EditRowStyle-CssClass="gv_toDoList_row_editrow"
    OnRowCommand="gv_toDoList_RowCommand"
    OnRowEditing="gv_toDoList_RowEditing"
    OnRowUpdating="gv_toDoList_RowUpdating"
    Width="900px"
    runat="server" DataKeyNames="ID_ToDo"
    >
    <Columns>


        <asp:BoundField DataField="ID_ToDo"  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="ID_ToDo"
             InsertVisible="false" ReadOnly="True" />
     
        <asp:ButtonField ImageUrl="~/Image/Icon/delete_16_deleteDocument_16.png" Text="Delete" ButtonType="Image" CommandName="bt_deleteToDo" />
        <asp:CommandField UpdateText="Update" UpdateImageUrl="~/Image/Icon/update_16_updateDocument_16.png" CancelText="Cancel edit" CancelImageUrl="~/Image/Icon/cancel_16_cancelDocument_16.png" EditText="Edit" ShowEditButton="true" ButtonType="Image" EditImageUrl="~/Image/Icon/edit_16_editDocument_16.png" />
        
        <asp:BoundField DataField="Task" HeaderText="Task"  />
        <asp:BoundField DataField="EnteredDate" DataFormatString = "{0:dd/MM/yyyy}" HeaderText="Task entered" />
        <asp:BoundField DataField="EndDate" DataFormatString = "{0:dd/MM/yyyy}"  HeaderText="End task date" />
    </Columns>


</asp:GridView>

<div style="display: none;">
   <asp:Button runat="server" ID="DeleteRow"  OnClick="DeleteRow_Click" />
</div>
