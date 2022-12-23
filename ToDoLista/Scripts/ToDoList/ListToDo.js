 function showAskToast() {
    iziToast.show({
        id: 'question',
        title: 'Question',
        theme: 'light',
        message: "Do you want to delete this task?",
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
