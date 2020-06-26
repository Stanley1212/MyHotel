$(function () {

    $('#loader').hide();


    $(document).on('ajaxStart', function () {
        //showLoader();
        $('#loader').show();
    });


    $(document).ajaxComplete(function () {
       // showClose();
        $('#loader').hide();
    });

   
});

const Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000
});

function AlertSuccess(text) {
    Toast.fire({
        icon: 'success',
        title: text
    });
}

function AlertError(text) {
    Toast.fire({
        icon: 'error',
        title: text
    });
}

function OnBegin(){
}

function OnFailure() {
}

function OnComplete() {
}

function RegisterAjaxEvents() {
    $.validator.unobtrusive.parse('form');
}

