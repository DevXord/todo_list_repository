 

$(document).ready(function () {
    $('#MainContent_tb_newUser').attr('placeholder', 'New user');
  

    $('#MainContent_bt_nextPage').click(function () {
        if ($('#MainContent_lb_selectUser').val() == null && ($('#MainContent_tb_newUser').val() == "" || $('#MainContent_tb_newUser').val() == null)) {
            ToastError('Select a user from the list or enter a new user!');
            return false;
        }
        var userName = $('#MainContent_lb_selectUser').val() == null || $('#MainContent_lb_selectUser').val() == "" ? $('#MainContent_tb_newUser').val() : $('#MainContent_lb_selectUser').val();


        if ($('#MainContent_lb_selectUser').val() == null && $('#MainContent_lb_selectUser')[0].options.length != 0) {
            for (var i = 0; i < $('#MainContent_lb_selectUser')[0].options.length; i++) {
                if ($('#MainContent_lb_selectUser')[0][i].value == $('#MainContent_tb_newUser').val()) {
                    ToastError('This name is already used!');
                    return false;
                }
            }
        }

        localStorage.setItem('userName', userName);

        var button = document.getElementById('MainContent_SelectUser');
        button.click();
       


        return false;
    });
});
