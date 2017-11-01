$(document).ready(function () {
    $("#menu-imovel").addClass("active open");
    
    $('textarea.limited').inputlimiter({
        remText: '%n caractere%s restantes...',
        limitText: 'max permitido : %n.'
    });

    CKEDITOR.replace('Descricao', {
        extraPlugins: 'autogrow',
        autoGrow_bottomSpace: 50
    });

    CKEDITOR.replace('CentralNegocio', {
        extraPlugins: 'autogrow',
        autoGrow_bottomSpace: 50
    });

    $("#Valor").maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',', affixesStay: false });
    $("#ValorCondominio").maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',', affixesStay: false });

    $('#modal-delete').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var nome = button.data('nome');
        var id = button.data('id');
        var isUpload = button.data('local') == 'upload' ? true : false;

        $('#fotoNome').val(nome);
        $('#fotoId').val(id);
        $('#isUpload').val(isUpload);

        if (typeof id == 'undefined' || id == null) {
            $('#imgFotoExclusao').attr('src', '/Administrativo/Img/GaleriaUpload?nome=' + nome + '&thumb=true')
        } else {
            $('#imgFotoExclusao').attr('src', '/Administrativo/Img/GaleriaImovel?id=' + id + '&thumb=true')
        }
    });


    $('#btnExcluirFoto').on('click', function () {
        var foto = $('#fotoNome').val();
        var isUpload = $('#isUpload').val();

        var url = '/Administrativo/ImagemImovel/Delete/?imagem=' + foto;

        if (isUpload == 'false') {
            $.ajax({
                url: url,
                data: { imagem: foto },
                type: 'POST',
                ajaxasync: true,
                success: function (result) {
                    $('#modal-delete').modal('hide');
                    if (result.status == 'success') {
                        $('[data-nome="' + foto + '"]').hide();
                    }
                },
                error: function (result) {
                    $('#modal-delete').modal('hide');
                    alert("Não foi possível excluir o registro!");
                }
            });
        } else {

            fotosMultiUpload.pop(foto);
            $('[data-nome="' + foto + '"]').hide();
            $('#modal-delete').modal('hide');

        }

        return false;

    });

});
