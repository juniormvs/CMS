var placeSearch, autocomplete;

function initAutocomplete() {
    // Create the autocomplete object, restricting the search to geographical
    // location types.
    autocomplete = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('Endereco')),
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

    $('#Endereco').val(place.formatted_address);
    $('#Rua').val(place.name);
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
            default:
        }
    }

}
