
$(document).ready(function () {
    $('#skin-colorpicker').on('change', function() {
        var skin_class = $(this).find('option:selected').data('skin');
        console.log(skin_class);
        
        var url = 'http://' + window.location.host + '/Administrativo/Empresa/AtualizarSkin';

        $.post(url, { skin: skin_class }, function (data) {
            console.log(data);
        });
        
    });
});