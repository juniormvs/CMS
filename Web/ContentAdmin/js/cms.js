
$(document).ready(function () {
    $('#skin-colorpicker').on('change', function() {
        var skin_class = $(this).find('option:selected').data('skin');
        console.log(skin_class);
        //alert('3');

        var data = { skin : skin_class };

        $.ajax({
            url: 'http://localhost:55532/Administrativo/Empresa/AtualizarSkin',
            data: data,
            method: "POST",
            success: function (response) {
                console.log(response);
            },
            error: function (error) {
                console.log(error);
            }
        });
        //TODO salvar o skin_class no banco
    });
});