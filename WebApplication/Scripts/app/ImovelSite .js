var urlProposta = window.location.host + "/Contato/Proposta";

$(document).ready(function () {
    $("[data-fancybox]").fancybox({

    });

    $('#ImovelUrl').val(window.location.href);

    $('#btnEnviar').on('click', function () {
        $.ajax({
            url: this.action,
            type: 'POST',
            data: $('form').serialize(),
            beforeSend: function () {

            },
            success: function (result) {
                console.log('result', result);

                if (result.status === "success") {
                    $('#msgProposta').removeClass('hidden');
                    $('#msgProposta').addClass('alert-success');
                    $('#txtProposta').html(result.msg);
                } else if (result.status == "error") {
                    $('#msgProposta').removeClass('hidden');
                    $('#msgProposta').addClass('alert-danger');
                    $('#txtProposta').html(result.msg);
                }
            },
            error: function (error) {
                console.log('error', error);
            },
            complete: function () {
                console.log('complete');
            }
        });
    });
   
    
});
