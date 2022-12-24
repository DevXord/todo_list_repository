function showAskToast() {
    iziToast.show({
        id: 'question',
        title: 'Question',
        theme: 'light',
        message: "Mark this task as done?",
        color: 'yellow',
        close: false,
        overlay: true,
        displayMode: 'once',
        position: 'center',
        timeout: null,
        buttons: [
            ['<button><b>Yes</b></button>', function (instance, toast) {
                var button = document.getElementById('MainContent_ListTODOControl_DeleteRow');
                button.click();
                instance.hide({
                    transitionOut: 'fadeOutUp',
                }, toast, 'close', 'white-button');
            }],
            ['<button ><b>No</b></button>', function (instance, toast) {
                instance.hide({
                    transitionOut: 'fadeOutUp',
                }, toast, 'close', 'white-button');
            }]
        ],
    });
    return false;
}

$('#MainContent_ListTODOControl_bt_newTask').click(function () {
    if ($('#MainContent_ListTODOControl_tb_newTask').val() == null || $('#MainContent_ListTODOControl_tb_newTask').val() == "") {
        ToastError('The new task field is empty!');
        return false;
    }
    if ($('#MainContent_ListTODOControl_tb_dateTask').val() == null || $('#MainContent_ListTODOControl_tb_dateTask').val() == "") {
        ToastError('The end task date field is empty!');
        return false;
    }

    if (new Date($('#MainContent_ListTODOControl_tb_dateTask').val()).toString() == 'Invalid Date') {
        ToastError('Invalid Date!');
        return false;
    }
    if (new Date($('#MainContent_ListTODOControl_tb_dateTask').val()) < new Date()) {
        ToastError('The date must be from the future!');
        return false;
    }
   

    var button = document.getElementById('MainContent_ListTODOControl_NewTask');
    button.click();

  
    return false;
}); 


$('#MainContent_ListTODOControl_btn_showNewTaskControls').click(function () {

    if ($("#dv_NewTaskContener").is(":visible"))
        $("#dv_NewTaskContener").hide()
    else
        $("#dv_NewTaskContener").show()

    return false;
});




 

function changeTextLabel() {
    if ($('#MainContent_ListTODOControl_cb_showEndTask').prop('checked'))
        $("#MainContent_ListTODOControl_lb_showEndTask").text("View completed tasks")
    else
        $("#MainContent_ListTODOControl_lb_showEndTask").text("Hide completed tasks")


    return false;
}






$('#MainContent_ListTODOControl_cb_showEndTask').change(function () {
    var button = document.getElementById('MainContent_ListTODOControl_SaveCheck');
    button.click();
    return false;
});
