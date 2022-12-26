<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListTODOControl.ascx.cs" Inherits="ToDoLista.Controls.ListTODOControl" %>
<asp:HiddenField ID="hf_listToDo"  ClientIDMode="Static" runat="server" />
<asp:HiddenField ID="hf_endDate" runat="server" />
<p>ToDo List</p>

 

<div id="dv_showButton">

    <asp:LinkButton ID="btn_showNewTaskControls" ViewStateMode="Disabled" AutoPostBack="false" class="showButton" runat="server">
        <img src="~/Image/Icon/addTask_32_addTask_32.png" runat="server"/>
        <asp:Label Text="Show new task field" class="labelAddButton" runat="server"></asp:Label></>
    </asp:LinkButton>

</div>
<div id="dv_NewTaskContener" class="contenerAddTask">

    <div class="contenerNewTask">
        <asp:Label runat="server" Text="New Task:"></asp:Label>
        <asp:TextBox ID="tb_newTask" TextMode="SingleLine" ViewStateMode="Disabled" AutoPostBack="false" class="textClass" runat="server"></asp:TextBox>
    </div>

    <div class="contenerNewEndDate">
        <asp:Label runat="server" AutoPostBack="false" Text="End task date:"></asp:Label>
        <asp:TextBox ID="tb_dateTask" ViewStateMode="Disabled" OnTextChanged="tb_endDate_TextChanged" class="textClass" runat="server" TextMode="DateTimeLocal" ToolTip="Enter date"></asp:TextBox>
     
    </div>

    <asp:LinkButton ID="bt_newTask" ViewStateMode="Disabled" AutoPostBack="false" class="AddButton" runat="server">
        <img src="../Image/Icon/add_32_addDocument_32.png" runat="server"/>
        <asp:Label Text="Create  task" class="labelAddButton" runat="server"></asp:Label></>
    </asp:LinkButton>

</div>

<div style="display: none;">
    <asp:Button runat="server" AutoPostBack="false" ID="NewTask" OnClick="AddNewTask_Click" />
    <asp:Button runat="server" AutoPostBack="false" ID="SaveCheck" OnClick="SaveCheck_Click" />
    <asp:Button runat="server" ID="CheckRow" AutoPostBack="false" OnClick="CheckRow_Click" />
    <asp:Button runat="server" ID="DeleteRow" AutoPostBack="false" OnClick="DeleteRow_Click" />
    <asp:Button runat="server" ID="ClearGridViewButton" AutoPostBack="false" OnClick="ClearGridView_Click" />
</div>




<div class="WordWrap">


    <asp:CheckBox ID="cb_showEndTask" CssClass="cb_showEndTask" OnDataBinding="cb_showEndTask_DataBinding" runat="server" />
    <asp:Label ID="lb_showEndTask" runat="server"></asp:Label>


    <asp:GridView ID="gv_toDoList"
        OnDataBinding="gv_toDoList_DataBinding"
        OnDataBound="gv_toDoList_DataBound"
        AutoGenerateColumns="false"
        AllowPaging="True"
        CssClass="gv_toDoList"
        HeaderStyle-CssClass="gv_toDoList_header"
        OnRowCreated="gv_toDoList_RowCreated"
        RowStyle-CssClass="gv_toDoList_rows"
        EditRowStyle-CssClass="gv_toDoList_row_editrow"
        OnRowCommand="gv_toDoList_RowCommand"
        OnRowEditing="gv_toDoList_RowEditing"
        OnRowUpdating="gv_toDoList_RowUpdating"
        OnRowCancelingEdit="gv_toDoList_RowCancelingEdit"
        OnRowDeleting="gv_toDoList_RowDeleting"
        PagerSettings-Mode="NextPrevious"
        PagerSettings-Visible="true"
        PagerSettings-NextPageImageUrl="~/Image/Icon/arrowRightWhite_32_arrowRightWhite_32.png"
        PagerSettings-PreviousPageImageUrl="~/Image/Icon/arrowLeftWhite_32_arrowLeftWhiteDocument_32.png"
        PagerStyle-HorizontalAlign="Center"
        PagerSettings-Position="Bottom"
        PagerStyle-CssClass="gv_toDoList_pager"
        PagerSettings-PreviousPageText="Previous page"
        PagerSettings-NextPageText="Next page"
        OnPageIndexChanging="gv_toDoList_PageIndexChanging"
        PageSize="8"
        Width="900px"
        PageIndex="0"
        runat="server"
        DataKeyNames="ID_ToDo">

        <Columns>


            <asp:BoundField DataField="ID_ToDo" ItemStyle-CssClass="hiddencol" ItemStyle-Width="10" HeaderStyle-CssClass="hiddencol" HeaderText="ID_ToDo"
                InsertVisible="false" ReadOnly="True" />

            <asp:ButtonField CommandName="Accept" ItemStyle-Width="50"  ImageUrl="~/Image/Icon/ok_32_okDocument_32.png" ButtonType="Image"  />


            <asp:CommandField ShowDeleteButton="true" ItemStyle-Width="75" DeleteImageUrl="~/Image/Icon/delete_32_deleteDocument_32.png" DeleteText="Is Do" UpdateText="Update" UpdateImageUrl="~/Image/Icon/update_32_updateDocument_32.png" CancelText="Cancel edit" CancelImageUrl="~/Image/Icon/cancel_32_cancelDocument_32.png" EditText="Edit" ShowEditButton="true" ButtonType="Image" EditImageUrl="~/Image/Icon/edit_32_editDocument_32.png" />
            <asp:BoundField DataField="Task" ItemStyle-Wrap="true" ReadOnly="false" HeaderText="Task">
                <ItemStyle Width="50" />
                <HeaderStyle Width="300px" />



            </asp:BoundField>

            <asp:TemplateField ItemStyle-Width="150" HeaderText="End task date" SortExpression="EndDate">
                <ItemTemplate>
                    <asp:Label ID="l_endDate" CssClass="l_endDate"  runat="server" ForeColor="White"
                        ></asp:Label>

                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tb_endDate" ViewStateMode="Disabled" OnTextChanged="tb_endDate_TextChanged" ForeColor="Black" CssClass="tb_endDate" TextMode="DateTimeLocal"  runat="server"></asp:TextBox>
                </EditItemTemplate>

            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</div>

