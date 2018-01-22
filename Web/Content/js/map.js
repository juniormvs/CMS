google.maps.event.addDomListener(window, 'load', initialize);

var host = window.location.protocol;
var url = "/api/ImovelApi";

var markersArray = [];
var infowindowArray = [];

//intialize the map
function initialize() {
    var mapOptions = {
        zoom: 14,
        //gestureHandling: 'greedy', //desativa o zoom com ctrl ou dois dedos
        center: new google.maps.LatLng(-22.128800, -51.392244)
    };

    var map = new google.maps.Map(
        document.getElementById('map-canvas'),
        mapOptions
    );

    $('#btnFiltrarMapa').on('click', function () {
        var contrato = $('#TipoContrato').val();
        var tipo = $('#TipoImovel').val();
        var bairro = $('#Bairro').val();

        var buscaMapaParam = { contrato: contrato, tipo: tipo, bairro: bairro };
        buscaMapa(buscaMapaParam);
    });

    //quando a pagina carregar...
    $(document).ready(function () {
        console.log("ready!");

        $.ajax({
            url: host + url,
            method: "GET",
            beforeSend: function (jqXHR, settings) {
                $('#modalLoading').modal('show');
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log('jqXHR', jqXHR);
                console.log('textStatus', textStatus);
                console.log('errorThrown', errorThrown);
                console.error('deu ruim');
            },
            success: function (retorno, textStatus, jqXHR) {
                if (textStatus == 'success') {
                    tratarRetorno(retorno);
                }
                else {
                    swal('Oops...','Ocorreu um erro ao obter dados.','error');
                }
            },
            complete: function (jqXHR, textStatus) {
                $('#modalLoading').modal('hide');
            }
        });
    });

    function buscaMapa(parametros) {
        
        $.ajax({
            url: host + url,
            method: "GET",
            data: parametros,
            beforeSend: function (jqXHR, settings) {
                $('#modalLoading').modal('show');
                removeMarker();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log('jqXHR', jqXHR);
                console.log('textStatus', textStatus);
                console.log('errorThrown', errorThrown);
                console.error('deu ruim');
            },
            success: function (retorno, textStatus, jqXHR) {
                if (textStatus == 'success') {

                    tratarRetorno(retorno);

                    if (retorno.length <= 0) {
                        swal('Nenhum im&oacute;vel encontrado para a sua pesquisa.');
                    }
                }
                else {
                    alert('Ocorreu um erro ao obter dados.');
                }
            },
            complete: function (jqXHR, textStatus) {
                $('#modalLoading').modal('hide');
            }
        });
    }

    function tratarRetorno(dados) {
        
        
        
        $.each(dados, function (key, valor) {
            if (valor.Latitude == null) return true;

            var marker;
            
            if (valor.Valor != null) {
                marker = new RichMarker({
                    map: map,
                    shadow: 'none',
                    position: new google.maps.LatLng(valor.Latitude, valor.Longitude),
                    content: '<div><div class="label_content"> R$ ' + (valor.Valor).toLocaleString('pt-BR') + '</div></div>'
                });
            } else {
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(valor.Latitude, valor.Longitude),
                    map: map,
                    icon: '../Content/img/pin.png'
                });
            }

            var contentString = '<div class="info-box">' +
                '<img src="/Img/Imovel/' + valor.Id + '" style="max-width: 25.0rem; max-height: 15.0rem; margin-bottom: 1.0rem; float: left; margin-right: 1.0rem;" alt="" />' +
                '<h4>' + valor.Titulo + '</h4>' +
                '<p>' + valor.Endereco + '</p>' +
                '<a href="http://' + window.location.host + '/Imovel/' + valor.Id + '/' + valor.UrlAmigavel + '" class="btn btn-red">Visualizar Detalhes</a><br/></div>';

            var infowindow = new google.maps.InfoWindow({ content: contentString });

            markersArray.push(marker);

            infowindowArray.push(infowindow);

            google.maps.event.addListener(marker, 'click', function () {

                console.log('infowindow', infowindowArray);
                for (var i = 0; i < infowindowArray.length; i++) {
                    infowindowArray[i].close();
                }

                infowindow.open(map, marker);
            });
        });
    }

    function removeMarker(){
        
        var allMarkers = [];

        for (var i = 0; i < markersArray.length; i++) {
            markersArray[i].setMap(null);
        }
        markersArray.length = 0;
    }
}


