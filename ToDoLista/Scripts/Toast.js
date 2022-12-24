
function ToastSuccess(message,time=5000,position = 'topRight'){
    iziToast.success({

        id: 'success', 
        title: 'Success',
        theme: 'light',  
        message: message,
        color: 'green', 
        closeOnClick: false,
        displayMode: 'replace',
        position: position,  
        timeout: time
    });
};


function ToastError(message,time=5000,position = 'topRight'){
    iziToast.error({

        id: 'error', 
        title: 'Error',
        theme: 'light', 
        message: message,
        color: 'red',  
        closeOnClick: false,
        displayMode: 'replace',
        position: position, 
        timeout: time
    });

};
function ToastInfo(message,time=5000,position = 'topRight'){
    iziToast.info({

        id: 'info', 
        title: 'Info',
        theme: 'light', 
        message: message,
        color: 'blue', 
        closeOnClick: false,
        displayMode: 'replace',
        position: position,  
        timeout: time
    });

};

function ToastWarning(message,time=5000,position = 'topRight'){
    iziToast.warning({

        id: 'warning', 
        title: 'Warning',
        theme: 'light',  
        message: message,
        color: 'yellow',  
        closeOnClick: false,
        displayMode: 'replace',
        position: position,  
        timeout: time
    });

};



function ToastInfoButtons(message, path) {
    iziToast.info({

        id: 'info',
        title: 'Info',
        theme: 'light',
        message: message,
        color: 'blue',
        close: false,
        drag: false,
        overlay: true,
        displayMode: 'once',
        position: 'center',
        maxWidth: 350,
        timeout: null,
        buttons: [
            ['<button><b>Ok</b></button>', function (instance, toast) {
                window.open(path, '_self');
                instance.hide({
                    transitionOut: 'fadeOutUp',
                }, toast, 'close', 'white-button');
            }],

            ['<button><b>Cancel</b></button>', function (instance, toast) {
           
                instance.hide({
                    transitionOut: 'fadeOutUp',
                }, toast, 'close', 'white-button');
            }]
        ],
    });

};

 