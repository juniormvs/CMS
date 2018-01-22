jQuery(document).ready(function ($) {
    function LoadMapProperty() {
        var locations = new Array(
            [imovelLatitude, imovelLongitude]
        );
        var types = new Array(
            'family-house'
        );
        var markers = new Array();
        var plainMarkers = new Array();

        var mapOptions = {
            center: new google.maps.LatLng(imovelLatitude, imovelLongitude),
            zoom: zoomMaps,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            scrollwheel: false
        };

        var map = new google.maps.Map(document.getElementById('property-map'), mapOptions);

        $.each(locations, function (index, location) {
            var marker = new google.maps.Marker({
                position: new google.maps.LatLng(location[0], location[1]),
                map: map,
            });

            var myOptions = {
                draggable: true,
                content: '<div class="marker ' + types[index] + '"><div class="marker-inner"></div></div>',
                disableAutoPan: true,
                pixelOffset: new google.maps.Size(-21, -58),
                position: new google.maps.LatLng(location[0], location[1]),
                closeBoxURL: "",
                isHidden: false,
                enableEventPropagation: true
            };
            marker.marker = new InfoBox(myOptions);
            marker.marker.isHidden = false;
            marker.marker.open(map, marker);
            markers.push(marker);
        });

        google.maps.event.addListener(map, 'zoom_changed', function () {
            $.each(markers, function (index, marker) {
                marker.infobox.close();
            });
        });
    }

    google.maps.event.addDomListener(window, 'load', LoadMapProperty);

    var dragFlag = false;
    var start = 0, end = 0;

    function thisTouchStart(e) {
        dragFlag = true;
        start = e.touches[0].pageY;
    }

    function thisTouchEnd() {
        dragFlag = false;
    }

    function thisTouchMove(e) {
        if (!dragFlag)
            return;
        end = e.touches[0].pageY;
        window.scrollBy(0, (start - end));
    }

    document.getElementById("property-map").addEventListener("touchstart", thisTouchStart, true);
    document.getElementById("property-map").addEventListener("touchend", thisTouchEnd, true);
    document.getElementById("property-map").addEventListener("touchmove", thisTouchMove, true);
});