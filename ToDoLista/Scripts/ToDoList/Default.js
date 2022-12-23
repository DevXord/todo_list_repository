$(document).ready(function () {
    $('#MainContent_tb_newUser').attr('placeholder', 'New user');
  

    $('#MainContent_bt_nextPage').click(function () {
        if ($('#MainContent_lb_selectUser').val() == null && ($('#MainContent_tb_newUser').val() == "" || $('#MainContent_tb_newUser').val() == null)) {
            ToastError('Select a user from the list or enter a new user!');
            return false;
        }  

        localStorage.setItem('UserName', $('#MainContent_lb_selectUser').val() == null ? $('#MainContent_tb_newUser').val() : $('#MainContent_lb_selectUser').val());
        window.open("../ListToDo.aspx", '_self');
        return false;
    });
});
