

$(document).ready(function () {
    $('#MainContent_tb_newUser').attr('placeholder', 'New user');


    $('#MainContent_bt_nextPage').click(function () {
        if ($('#MainContent_cmb_selectUser_cmb_selectUser_TextBox').val() == "" && $('#MainContent_tb_newUser').val() == "") {
            ToastError('Select a user from the list or enter a new user!');
            return false;
        }
        if ($('#MainContent_cmb_selectUser_cmb_selectUser_TextBox').val() == "" && $('#MainContent_tb_newUser').val() == "") {
            ToastError('Select a user from the list or enter a new user!');
            return false;
        }
        if (typeof ($("#MainContent_cmb_selectUser_cmb_selectUser_OptionList")[0]) != "undefined") {
            if ($('#MainContent_cmb_selectUser_cmb_selectUser_TextBox').val() == "") {

                if ($("#MainContent_cmb_selectUser_cmb_selectUser_OptionList")[0].innerHTML.includes('>' + $('#MainContent_tb_newUser').val() + '<')) {
                    ToastError('This name is already used!');
                    return false;
                }

            }
        }

        if ($('#MainContent_cmb_selectUser_cmb_selectUser_TextBox').val() != "") {
            if (!$("#MainContent_cmb_selectUser_cmb_selectUser_OptionList")[0].innerHTML.includes('>' + $('#MainContent_cmb_selectUser_cmb_selectUser_TextBox').val() + '<')) {
                ToastError('This name is not in the list!');
                return false;
            }
        }



        if ($('#MainContent_tb_newUser').val().length >= 16) {

            ToastError('The name is too long!');
            return false;

        }
        var userName = $('#MainContent_cmb_selectUser_cmb_selectUser_TextBox').val() == "" ? $('#MainContent_tb_newUser').val() : $('#MainContent_cmb_selectUser_cmb_selectUser_TextBox').val();

        localStorage.setItem('userName', userName);

        var button = document.getElementById('MainContent_SelectUser');
        button.click();



        return false;
    });
});
