﻿/// Use https://developers.google.com/maps/documentation/javascript/controls;
var googleMap;
var infoWindow;
var googleMarkers = [];
var googlePois = [];

function initMap() {
    var mapOptions = {
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        disableDefaultUI: true,
    };    
    googleMap = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
    infoWindow = new google.maps.InfoWindow();

    setZoom(googleMap, boards);
    setPois(googleMap, pois);
    setMarkers(googleMap, boards);    
}

function setZoom(map, markers) {
    var boundbox = new google.maps.LatLngBounds();
    for (var i = 0; i < markers.length; i++) {
        boundbox.extend(new google.maps.LatLng(markers[i].Latitude, markers[i].Longitude));
    }
    map.setCenter(boundbox.getCenter());
    map.fitBounds(boundbox);
}
function setMarkers(map, markers) {
    
    for (i = 0; i < markers.length; i++) {
        var data = markers[i]
        var markerLatlng = new google.maps.LatLng(data.Latitude, data.Longitude);
        var marker = new google.maps.Marker({
            position: markerLatlng,
            map: map,
            title: data.Address,
            animation: google.maps.Animation.DROP,
            icon: data.Icon
        });
        (function (marker, data) {
            google.maps.event.addListener(marker, "click", function (e) {
                deselectRows();
                document.getElementById(data.Id).className = "rowAct";
                infoWindow.setContent(data.InfoHtml);
                infoWindow.open(map, marker);
            });
        })(marker, data);
        googleMarkers[i] = marker;
    }
}
function setPois(map, pois) {

    for (i = 0; i < pois.length; i++) {
        var data = pois[i]
        var markerLatlng = new google.maps.LatLng(data.Latitude, data.Longitude);
        var marker = new google.maps.Marker({
            position: markerLatlng,
            map: map,
            title: data.Address,
            animation: google.maps.Animation.DROP,
            icon: data.Icon
        });

        (function (marker, data) {
            google.maps.event.addListener(marker, "click", function (e) {  

                const contentString =
                    '<div class="informWindow">' +
                    '<strong>' + data.Address + '</strong>' + 
                    '<p>' + data.Description + '</p>' +
                    "</div>";

                infoWindow.setContent(contentString);
                infoWindow.open(map, marker);
            });
        })(marker, data);    

        googlePois[i] = marker;
    }
}


function onRowClick(x) {
    deselectRows();
    x.className = "rowAct";
    infoWindow.setContent(boards[x.rowIndex - 1].InfoHtml);
    infoWindow.open(googleMap, googleMarkers[x.rowIndex - 1]);
    //alert("Row index is: " + x.rowIndex);
}
function deselectRows() {
    var selected = document.getElementsByClassName("rowAct");
    for (var i = 0; i < selected.length; i++) {
        selected[i].className = "rowPass";
    }
}