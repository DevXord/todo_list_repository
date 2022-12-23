
function ToastSuccess(message,time=5000,position = 'topRight'){
    iziToast.success({

        id: 'success', 
        title: 'Success',
        theme: 'light', // dark 
        message: message,
        color: 'green', // blue, red, green, yellow
        closeOnClick: false,
        displayMode: 'once',
        position: position, // bottomRight, bottomLeft, topRight, topLeft, topCenter, bottomCenter, center
        timeout: time
    });
};


function ToastError(message,time=5000,position = 'topRight'){
    iziToast.error({

        id: 'error', 
        title: 'Error',
        theme: 'light', // dark  light
        message: message,
        color: 'red', // blue, red, green, yellow
        closeOnClick: false,
        displayMode: 'once',
        position: position, // bottomRight, bottomLeft, topRight, topLeft, topCenter, bottomCenter, center
        timeout: time
    });

};
function ToastInfo(message,time=5000,position = 'topRight'){
    iziToast.info({

        id: 'info', 
        title: 'Info',
        theme: 'light', // dark light
        message: message,
        color: 'blue', // blue, red, green, yellow
        closeOnClick: false,
        displayMode: 'once',
        position: position, // bottomRight, bottomLeft, topRight, topLeft, topCenter, bottomCenter, center
        timeout: time
    });

};

function ToastWarning(message,time=5000,position = 'topRight'){
    iziToast.warning({

        id: 'warning', 
        title: 'Warning',
        theme: 'light', // dark light
        message: message,
        color: 'yellow', // blue, red, green, yellow
        closeOnClick: false,
        displayMode: 'once',
        position: position, // bottomRight, bottomLeft, topRight, topLeft, topCenter, bottomCenter, center
        timeout: time
    });

};
 