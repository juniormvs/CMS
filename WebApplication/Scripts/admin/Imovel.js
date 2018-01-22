var placeSearch, autocomplete;

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

    CKEDITOR.replace('Observacao', {
        extraPlugins: 'autogrow',
        autoGrow_bottomSpace: 50
    });

    CKEDITOR.replace('PontosFortes', {
        extraPlugins: 'autogrow',
        autoGrow_bottomSpace: 50
    });

    CKEDITOR.replace('Informacao', {
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
        var isUpload = button.data('local') === 'upload' ? true : false;

        $('#fotoNome').val(nome);
        $('#fotoId').val(id);
        $('#isUpload').val(isUpload);

        if (typeof id === 'undefined' || id === null) {
            $('#imgFotoExclusao').attr('src', '/Administrativo/Img/GaleriaUpload?nome=' + nome + '&thumb=true');
        } else {
            $('#imgFotoExclusao').attr('src', '/Administrativo/Img/GaleriaImovel?id=' + id + '&thumb=true');
        }
    });


    $('#btnExcluirFoto').on('click', function () {
        var foto = $('#fotoNome').val();
        var isUpload = $('#isUpload').val();

        var url = '/Administrativo/ImagemImovel/Delete/?imagem=' + foto;

        if (isUpload === 'false') {
            $.ajax({
                url: url,
                data: { imagem: foto },
                type: 'POST',
                ajaxasync: true,
                success: function (result) {
                    $('#modal-delete').modal('hide');
                    if (result.status === 'success') {
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

    $('#btnSalvarBairro').on('click', function () {
        alert('salvar bairro e atualizar select');
    });

    $('#btnSalvarResponsavel').on('click', function () {
        alert('salvar responsavel e atualizar select');
    });

});

function VerificarBairro(nomeBairro) {

    if ($("#BairroId option:contains(" + nomeBairro + ")").length === 0) {
        $('#BairroId').append('<option value="0" selected>' + nomeBairro + '</option>')
        /*
        $('.blah').append('<option value="foo">Bar</option>');
        Then, you need to trigger the chosen:updated event:

        $('.blah').trigger("chosen:updated");

        https://harvesthq.github.io/chosen/
        */
    } else {
        $("#BairroId option").filter(function () {
            return this.text == nomeBairro;
        }).attr('selected', true);
    }
    $('#BairroId').trigger('chosen:updated');
}

function AdicionarNovoBairro(nomeBairro) {

    $.ajax({
        url: '',
        method: 'POST',
        type: 'POST',
        ajaxasync: true,
        beforeSend: function (response) {
            console.log('iniciando adicionar bairro');
        },
        success: function (response) {
            console.log('response', response);
        },
        error: function (error) {
            console.log('error', error);
        },
        complete: function (response) {
            console.log('finalizando adicionar bairro');


        },
    });
}

function AdicionarNovoResponsavel() {

}


//FUNÇÕES PARA AUTOCOMPLETE E LOCALIZAÇÃO DO GOOGLE
function initAutocomplete() {
    // Create the autocomplete object, restricting the search to geographical
    // location types.
    autocomplete = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('EnderecoGoogle')),
        { types: ['geocode'] });

    // When the user selects an address from the dropdown, populate the address
    // fields in the form.
    autocomplete.addListener('place_changed', fillInAddress);
}

function fillInAddress() {
    // Get the place details from the autocomplete object.
    var place = autocomplete.getPlace();

    console.log('place', place);
    console.log('bairro', place.vicinity);

    $('#EnderecoGoogle').val(place.formatted_address);
    $('#Logradouro').val(place.name);

    if (place.vicinity !== '' && typeof place.vicinity !== 'undefined') {
        VerificarBairro(place.vicinity);
    }

    $('#Bairro').val(place.vicinity);

    for (var i = 0; i < place.address_components.length; i++) {
        var addressType = place.address_components[i].types[0];
        console.log(addressType);

        switch (addressType) {
            case "administrative_area_level_2":
                $('#Cidade').val(place.address_components[i].long_name);
                break;
            case "administrative_area_level_1":
                $('#Uf').val(place.address_components[i].short_name);
                break;
            case "postal_code":
                $('#Cep').val(place.address_components[i].long_name);
                break;
            case "street_number":
                $('#Numero').val(place.address_components[i].long_name);
            default:
        }
    }

}
