<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListTODOControl.ascx.cs" Inherits="ToDoLista.Controls.ListTODOControl" %>
<asp:HiddenField ID="hf_listToDo" runat="server" />
<p>ToDo List</p>


<div class="WordWrap">


    <asp:GridView ID="gv_toDoList"
        OnDataBinding="gv_toDoList_DataBinding"
        AutoGenerateColumns="False"
        AllowPaging="True"
        CssClass="gv_toDoList"
        PagerStyle-CssClass="gv_toDoList_pager"
        HeaderStyle-CssClass="gv_toDoList_header"
        OnRowCreated="gv_toDoList_RowCreated"
        RowStyle-CssClass="gv_toDoList_rows"
        EditRowStyle-CssClass="gv_toDoList_row_editrow"
        OnRowCommand="gv_toDoList_RowCommand"
        OnRowEditing="gv_toDoList_RowEditing"
        OnRowUpdating="gv_toDoList_RowUpdating"
        OnRowCancelingEdit="gv_toDoList_RowCancelingEdit"
        OnRowDeleting="gv_toDoList_RowDeleting"
        Width="900px" GridLines="Both"
        PageIndex="0"
        PagerSettings-Mode="NextPrevious"
        PagerSettings-Visible="true"
        PagerSettings-PreviousPageText="Previous page"
        PagerSettings-NextPageText="Next page"
        PageSize="8"
        runat="server" DataKeyNames="ID_ToDo">

        <Columns>


            <asp:BoundField DataField="ID_ToDo" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="ID_ToDo"
                InsertVisible="false" ReadOnly="True" />




            <asp:CommandField UpdateText="Update" ShowDeleteButton="true" DeleteImageUrl="~/Image/Icon/ok_16_okDocument_16.png" DeleteText="Is Do" UpdateImageUrl="~/Image/Icon/update_32_updateDocument_32.png" CancelText="Cancel edit" CancelImageUrl="~/Image/Icon/cancel_32_cancelDocument_32.png" EditText="Edit" ShowEditButton="true" ButtonType="Image" EditImageUrl="~/Image/Icon/edit_16_editDocument_16.png" />
            <%--<asp:Calendar runat="server"></asp:Calendar>--%>
            <asp:BoundField DataField="Task" ItemStyle-Wrap="true" ReadOnly="false" HeaderText="Task">
                <ItemStyle Width="50" />
                <HeaderStyle Width="300px" />



            </asp:BoundField>

            <asp:TemplateField HeaderText="End task date" SortExpression="EndDate">
                <ItemTemplate>
                    <asp:Label ID="l_endDate" runat="server" ForeColor="White"
                        Text='<%#  Bind("EndDate.Date")%>'></asp:Label>

                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tb_endDate" ForeColor="Black" Text='<%# Bind("EndDate.Date") %>' runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender runat="server" Format="dd/MM/yyyy" ClearTime="true" ID="ce_endDate" TargetControlID="tb_endDate" PopupButtonID="tb_endDate" />
                </EditItemTemplate>

            </asp:TemplateField>

        </Columns>


    </asp:GridView>


</div>
<div style="display: none;">
    <asp:Button runat="server" ID="DeleteRow" OnClick="DeleteRow_Click" />
</div>
<div class="contenerAddTask">
    <div class="contenerNewTask">
        <asp:Label runat="server" Text="New Task:"></asp:Label>
        <asp:TextBox ID="tb_newTask" class="textClass" runat="server"></asp:TextBox>

    </div> 

    <div class="contenerNewEndDate">
        <asp:Label runat="server" Text="End task date:"></asp:Label>
        <asp:TextBox ID="tb_dateTask" class="textClass" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender runat="server" TargetControlID="tb_dateTask" />
    </div>
    <asp:LinkButton ID="bt_newTask" class="AddButton"  runat="server">
        <img src="../Image/Icon/add_32_addDocument_32.png" runat="server"/>
        <asp:Label Text="New Task" class="labelAddButton" runat="server"></asp:Label></>

    </asp:LinkButton>

</div>
<div style="display: none;">
    <asp:Button runat="server" ID="NewTask" OnClick="AddNewTask_Click" />
</div>
