function initMap() {
    var mapOptions = {
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };    
    var map = new google.maps.Map(document.getElementById("map_part"), mapOptions);

    setZoom(map, markers);
    setMarkers(map, markers)
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
    var infoWindow = new google.maps.InfoWindow();
    for (i = 0; i < markers.length; i++) {
        var data = markers[i]
        var markerLatlng = new google.maps.LatLng(data.Latitude, data.Longitude);
        var marker = new google.maps.Marker({
            position: markerLatlng,
            map: map,
            title: data.Address,
            animation: google.maps.Animation.DROP,
            icon: data.IconLink
        });
        (function (marker, data) {
            google.maps.event.addListener(marker, "click", function (e) {
                infoWindow.setContent(data.InfoHtml);
                infoWindow.open(map, marker);
            });
        })(marker, data);
    }
}




//var marker, gmarkers = [];

//function initialize() {
//    var newark = new google.maps.LatLng(48.5153535344, 35.0552970171);
//    var myOptions = {
//        zoom: 11,
//        mapTypeId: google.maps.MapTypeId.ROADMAP
//    };
//    var gMap = new google.maps.Map(document.getElementById("map_part"), myOptions);

    
//    var legmas = [];
//    //legmas = leginimas(sites);
//    //legini(sites, legmas);
//    //gMap.controls[google.maps.ControlPosition.RIGHT_TOP].push(container);
//    //document.getElementById("legend").className = "legendoff";
//    //setZoom(gMap, sites);

//    //setMarkersQ(gMap, newark);
//    //infowindow = new google.maps.InfoWindow({
//    //    content: "Загрузка..."
//    //});
//    //google.maps.event.addListener(infowindow, "closeclick", function () {
//    //    for (var i = 0; i < sites.length; i++)
//    //        if (sites[i][6] != 2) {
//    //            document.getElementById("t" + sites[i][5]).className = "trcpas";
//    //        }
//    //    for (var a = 0; a < legmas.length; a++) {
//    //        var iss = legmas[a];
//    //        var ids = 'leg' + iss;
//    //        document.getElementById(ids).className = "legendoff";
//    //    }
//    //    document.getElementById("legend").className = "legendoff";
//    //});
//}
//function setMarkersQ(map, markers) {
//    for (var i = 0; i < markers.length; i++) {
//        var site = markers[i];
//        var siteLatLng = new google.maps.LatLng(site.lat, site.lng);
//        var marker = new google.maps.Marker({
//            position: siteLatLng,
//            map: map,
//            title: site.title,
//            //zIndex: 10,
//            //html: site[4],
//            //cl: site[5],
//            animation: google.maps.Animation.DROP,
///*            icon: "http://www.rtm.com.ua/maps/red-dot.png",*/
//        });
//        //google.maps.event.addDomListener(document.getElementById(site.Id))
//        //    , "click", function () {
//        //    k = this.id.replace("t", "");
//        //    marksetclass(k, markers, 0, legmas);
//        //    infowindow.setContent(masmark[k].html);
//        //    map.setOptions({
//        //        styles: stylesoff
//        //    });
//        //    infowindow.open(map, masmark[k]);
//        //});
//        masmark[i] = marker;
        
//    }
//}
//function setMarkers(map, markers, legmas) {
//    var stylesoff = [{
//        "stylers": [{
//            "color": "#828383"
//        }]
//    }, {}];
//    var styleson = [{
//        "stylers": [{
//            "color": ""
//        }]
//    }, {}];
//    var masmark = [];
//    for (var i = 0; i < markers.length; i++) {
//        var site = markers[i];
//        var siteLatLng = new google.maps.LatLng(site[1], site[2]);
//        if (site[6] == 0) {
//            var marker = new google.maps.Marker({
//                position: siteLatLng,
//                map: map,
//                title: site[0],
//                zIndex: 10,
//                html: site[4],
//                cl: site[5],
//                animation: google.maps.Animation.DROP,
//                icon: "http://www.rtm.com.ua/maps/red-dot.png",
//            });
//            google.maps.event.addDomListener(document.getElementById("t" + i), "click", function () {
//                k = this.id.replace("t", "");
//                marksetclass(k, markers, 0, legmas);
//                infowindow.setContent(masmark[k].html);
//                map.setOptions({
//                    styles: stylesoff
//                });
//                infowindow.open(map, masmark[k]);
//            });
//            masmark[i] = marker;
//        } else if (site[6] == 1) {
//            var marker = new google.maps.Marker({
//                position: siteLatLng,
//                map: map,
//                title: site[0],
//                zIndex: 10,
//                html: site[4],
//                cl: site[5],
//                animation: google.maps.Animation.DROP,
//                icon: "http://www.rtm.com.ua/maps/red-dot.png",
//            });
//            google.maps.event.addListener(marker, "click", function () {
//                infowindow.setContent(this.html);
//                marksetclass(this.cl, markers, 1, legmas);
//                map.setOptions({
//                    styles: styleson
//                });
//                infowindow.open(map, this);
//            });
//            masmark[i] = marker;
//            google.maps.event.addDomListener(document.getElementById("t" + i), "click", function () {
//                k = this.id.replace("t", "");
//                marksetclass(k, markers, 1, legmas);
//                infowindow.setContent(masmark[k].html);
//                map.setOptions({
//                    styles: styleson
//                });
//                infowindow.open(map, masmark[k]);
//            });
//            google.maps.event.addDomListener(document.getElementById("chcode" + i), "click", function () {
//                chk(masmark, markers);
//            });
//        } else if (site[6] == 2) {
//            var marker = new google.maps.Marker({
//                position: siteLatLng,
//                map: map,
//                title: site[0],
//                zIndex: 1,
//                html: site[4],
//                cl: site[5],
//                animation: google.maps.Animation.DROP,
//                icon: "http://www.rtm.com.ua/maps/gmap/def_poi.png",
//            });
//            masmark[i] = marker;
//            google.maps.event.addListener(marker, "click", function () {
//                infowindow.setContent(this.html);
//                marksetclass(this.cl, markers, 1, legmas);
//                map.setOptions({
//                    styles: styleson
//                });
//                infowindow.open(map, this);
//            });
//        } else if (site[6] == 3) {
//            google.maps.event.addDomListener(document.getElementById("t" + i), "click", function () {
//                k = this.id.replace("t", "");
//                marksetclass3(k, markers, site[8], legmas);
//                map.setOptions({
//                    styles: styleson
//                });
//                infowindow.close(map)
//            });
//            google.maps.event.addDomListener(document.getElementById("chcode" + i), "click", function () {
//                chk(masmark, markers);
//            });
//        }
//        if (site[6] == 4) {
//            var marker = new google.maps.Marker({
//                position: siteLatLng,
//                map: map,
//                title: site[0],
//                zIndex: 1,
//                html: site[4],
//                cl: site[5],
//                animation: google.maps.Animation.DROP,
//                icon: "http://www.rtm.com.ua/maps/blue-dot.png",
//            });
//            google.maps.event.addListener(marker, "click", function () {
//                infowindow.setContent(this.html);
//                marksetclass3(this.cl, markers, site[8], legmas);
//                map.setOptions({
//                    styles: styleson
//                });
//                infowindow.open(map, this);
//            });
//            masmark[i] = marker;
//            for (var mk = 0; mk < site[10].length; mk++) {
//                var pmk = site[10][mk];
//                if (document.getElementById("t" + i + "p" + pmk)) {
//                    google.maps.event.addDomListener(document.getElementById("t" + i + "p" + pmk), "click", function () {
//                        kh = this.id;
//                        k = kh.split('p')[0].split('t')[1];
//                        marksetclass3(k, markers, site[8], legmas);
//                        infowindow.setContent(masmark[k].html);
//                        map.setOptions({
//                            styles: styleson
//                        });
//                        infowindow.open(map, masmark[k]);
//                    });
//                }
//            }
//        }
//    }
//    google.maps.event.addDomListener(document.getElementById("rsi1"), "click", function () {
//        chk(masmark, markers);
//    });
//    google.maps.event.addDomListener(document.getElementById("rsi2"), "click", function () {
//        chk(masmark, markers);
//    });
//}
//function marksetclass(id, sitesmarkers, slc, legmas) {
//    for (var a = 0; a < legmas.length; a++) {
//        var iss = legmas[a];
//        var ids = 'leg' + iss;
//        document.getElementById(ids).className = "legendoff";
//    }
//    document.getElementById("container").className = "legendoff";
//    for (var i = 0; i < sitesmarkers.length; i++) {
//        if (sitesmarkers[i][6] != 2 && sitesmarkers[i][6] != 4) {
//            document.getElementById("t" + sitesmarkers[i][5]).className = "trcpas";
//        }
//    }
//    if (sitesmarkers[id][6] != 2 && sitesmarkers[id][6] != 4) {
//        document.getElementById("t" + id).className = "trcact";
//    }
//}
//function marksetclass3(id, sitesmarkers, slc, legmas) {
//    for (var a = 0; a < legmas.length; a++) {
//        var iss = legmas[a];
//        var ids = 'leg' + iss;
//        document.getElementById(ids).className = "legendoff";
//    }
//    if (sitesmarkers[id][6] != 4) {
//        ids = 'leg' + sitesmarkers[id][8];
//        document.getElementById(ids).className = "legendon";
//        document.getElementById("container").className = "legendon";
//    }
//    if (sitesmarkers[id][6] == 4) {
//        for (var k = 0; k < sitesmarkers[id][10].length; k++) {
//            ids = 'leg' + sitesmarkers[id][10][k];
//            if (document.getElementById(ids)) {
//                document.getElementById(ids).className = "legendon";
//            }
//            document.getElementById("container").className = "legendon";
//        }
//    }
//    var elements = document.getElementsByClassName("trcactl");
//    for (; elements[0];) {
//        elements[0].className = "trcpasl";
//    }
//    for (var i = 0; i < sitesmarkers.length; i++) {
//        if (sitesmarkers[i][6] != 2 && sitesmarkers[i][6] != 4 && document.getElementById("t" + sitesmarkers[i][5])) {
//            document.getElementById("t" + sitesmarkers[i][5]).className = "trcpas";
//        }
//        if (sitesmarkers[id][10].indexOf(sitesmarkers[i][8]) != -1 && sitesmarkers[i][6] == 3 && document.getElementById("t" + sitesmarkers[i][5])) {
//            document.getElementById("t" + sitesmarkers[i][5]).className = "trcact";
//        }
//    }
//    if (sitesmarkers[id][6] != 2 && sitesmarkers[id][6] != 4 && document.getElementById("t" + id)) {
//        document.getElementById("t" + id).className = "trcact";
//    }
//    if (sitesmarkers[id][6] == 4) {
//        for (var kak = 0; kak < sitesmarkers[id][10].length; kak++) {
//            var pkak = sitesmarkers[id][10][kak];
//            if (document.getElementById("t" + id + "p" + pkak)) {
//                document.getElementById("t" + id + "p" + pkak).className = "trcactl";
//            }
//        }
//    }
//}
//function leginimas(masik) {
//    var arc = [];
//    var arr = [];
//    for (var i = 0; i < masik.length; i++) {
//        if (masik[i][6] == 3) {
//            arr[i] = masik[i][8];
//        }
//    }
//    arc = Array.from(new Set(arr));
//    return arc;
//}
//function legini(sitesmarkers, legmas) {
//    for (var a = 0; a < legmas.length; a++) {
//        var iss = legmas[a];
//        var legendiss = document.getElementById('container');
//        var divleg = document.createElement('div');
//        var ids = 'leg' + iss;
//        var htnet = '';
//        for (sn = 0; sn < sitesmarkers.length; sn++) {
//            var snm = sitesmarkers[sn];
//            if (snm[6] == 3 && snm[8] == iss) {
//                htnet = htnet + ', ' + snm[9];
//            }
//        }
//        divleg.id = ids;
//        divleg.className = 'legendoff';
//        divleg.innerHTML = 'Cеть: ' + htnet;
//        legendiss.appendChild(divleg);
//        for (var i = 0; i < sitesmarkers.length; i++) {
//            var st = sitesmarkers[i];
//            if (st[6] == 4 && st[10].indexOf(iss) != -1) {
//                var legendt = document.getElementById(ids);
//                var div = document.createElement('div');
//                div.id = 't' + st[5] + 'p' + iss;
//                div.className = 'trcpasl';
//                div.innerHTML = st[0];
//                legendt.appendChild(div);
//            }
//        }
//    }
//}
//function leg(sitesmarkers, net) {
//    for (var i = 0; i < sitesmarkers.length; i++) {
//        var st = sitesmarkers[i];
//        if (st[6] == 4 && st[10].indexOf(net) != -1) {
//            var legend = document.getElementById('container');
//            var div = document.createElement('div');
//            div.id = 't' + st[5];
//            div.className = 'trcpasl';
//            div.innerHTML = st[0];
//            legend.appendChild(div);
//        }
//    }
//    document.getElementById("container").className = "legendon";
//}
//function setZoom(map, markers) {
//    var boundbox = new google.maps.LatLngBounds();
//    for (var i = 0; i < markers.length; i++) {
//        boundbox.extend(new google.maps.LatLng(markers[i][1], markers[i][2]));
//    }
//    map.setCenter(boundbox.getCenter());
//    map.fitBounds(boundbox);
//}
//function chk(markers, site) {
//    var f = document.getElementById('chform');
//    var rarr = document.getElementsByName('rsi');
//    var si = rarr[0].checked;
//    var name_ = '';
//    var str = '';
//    var citus = 'ch[]';
//    var kd = '';
//    var chkm = [];
//    var ico = 0;
//    var arrobjact = [];
//    var arrobjpas = [];
//    for (i = 1; i <= f.length; i++) {
//        if (f.elements[i - 1].type == 'checkbox') {
//            str = f.elements[i - 1].name;
//            if (str == citus) {
//                if (f.elements[i - 1].checked == true) {
//                    chkm = i - 1;
//                    if (si == 1) {
//                        if (site[i - 1][6] == 3) {
//                            arrobjact.push(site[i - 1][8]);
//                        } else {
//                            ico = 1;
//                            chkico(markers, chkm, site[i - 1][3], ico);
//                        }
//                    } else {
//                        if (site[i - 1][6] == 3) {
//                            arrobjact.push(site[i - 1][8]);
//                        } else {
//                            ico = 2;
//                            chkico(markers, chkm, site[i - 1][3], ico);
//                        }
//                    }
//                } else {
//                    chkm = i - 1;
//                    if (si == 1) {
//                        if (site[i - 1][6] == 3) {
//                            arrobjpas.push(site[i - 1][8]);
//                        } else {
//                            ico = 3;
//                            chkico(markers, chkm, site[i - 1][3], ico);
//                        }
//                    } else {
//                        if (site[i - 1][6] == 3) {
//                            arrobjpas.push(site[i - 1][8]);
//                        } else {
//                            ico = 4;
//                            chkico(markers, chkm, site[i - 1][3], ico);
//                        }
//                    }
//                }
//            }
//        }
//    }
//    chkicoobj(markers, chkm, site, si, arrobjpas, 0);
//    chkicoobj(markers, chkm, site, si, arrobjact, 1);
//}
//function chkicoobj(markers, chkm, site, si, arrobj, t) {
//    switch (t) {
//        case 0:
//            for (var z = 0; z < site.length; z++) {
//                for (var i = 0; i < arrobj.length; i++) {
//                    if (site[z][10].indexOf(arrobj[i]) != -1 && site[z][6] === 4) {
//                        if (si == 1) {
//                            ico = 7;
//                        } else {
//                            ico = 8;
//                        }
//                        chkico(markers, site[z][5], site[z][3], ico);
//                    }
//                }
//            }
//            break;
//        case 1:
//            for (var z = 0; z < site.length; z++) {
//                for (var i = 0; i < arrobj.length; i++) {
//                    if (site[z][10].indexOf(arrobj[i]) != -1 && site[z][6] === 4) {
//                        if (si == 1) {
//                            ico = 5;
//                        } else {
//                            ico = 6;
//                        }
//                        chkico(markers, site[z][5], site[z][3], ico);
//                    }
//                }
//            }
//            break;
//    }
//}
//function chkico(markers, chkm, si, ico) {
//    switch (ico) {
//        case 1:
//            var icon = {
//                anchor: new google.maps.Point(16, 16),
//                url: "http://www.rtm.com.ua/maps/gmap/g32_" + si + ".png"
//            };
//            markers[chkm].setIcon(icon);
//            break;
//        case 2:
//            markers[chkm].setIcon("http://www.rtm.com.ua/maps/green-dot.png");
//            break;
//        case 3:
//            var icon = {
//                anchor: new google.maps.Point(16, 16),
//                url: "http://www.rtm.com.ua/maps/gmap/r32_" + si + ".png"
//            };
//            markers[chkm].setIcon(icon);
//            break;
//        case 4:
//            markers[chkm].setIcon("http://www.rtm.com.ua/maps/red-dot.png");
//            break;
//        case 5:
//            var icon = {
//                anchor: new google.maps.Point(16, 16),
//                url: "http://www.rtm.com.ua/maps/gmap/g32_" + si + ".png"
//            };
//            markers[chkm].setIcon(icon);
//            break;
//        case 6:
//            markers[chkm].setIcon("http://www.rtm.com.ua/maps/green-dot.png");
//            break;
//        case 7:
//            var icon = {
//                anchor: new google.maps.Point(16, 16),
//                url: "http://www.rtm.com.ua/maps/gmap/b32_" + si + ".png"
//            };
//            markers[chkm].setIcon(icon);
//            break;
//        case 8:
//            markers[chkm].setIcon("http://www.rtm.com.ua/maps/blue-dot.png");
//            break;
//    }
//}
//function check() {
//    var f = document.getElementById('chform');
//    var name_ = '';
//    var str = '';
//    var citus = 'ch[]';
//    var kd = '';
//    for (i = 1; i <= f.length; i++) {
//        if (f.elements[i - 1].type == 'checkbox') {
//            str = f.elements[i - 1].name;
//            if (str == citus) {
//                if (f.elements[i - 1].checked == true) {
//                    kd = kd + (f.elements[i - 1].value + ', ');
//                }
//            }
//        }
//    }
//    if (kd.length < 1) {
//        var body_message = 0;
//    } else {
//        var body_message = ' http://www.rtm.com.ua/maps/160259679413.html Список выбранных плоскостей: ' + kd;
//    }
//    return body_message;
//}
//function smail() {
//    var body_message = check();
//    var email = '';
//    var subject = 'Выборка (Презентация)';
//    var mailto_link = 'mailto:' + email + '?subject=' + subject + '&body=' + body_message;
//    top.location.href = mailto_link;
//}
//function msel() {
//    var elm = document.getElementById('txt');
//    elm.select();
//}
//function offvis() {
//    document.getElementById("divinfmail").style.visibility = "hidden";
//}
//function onvis() {
//    var body_message = check();
//    if (body_message == 0) {
//        offvis();
//    } else {
//        document.getElementById("divinfmail").style.visibility = "visible";
//        document.getElementById("txt").innerHTML = body_message;
//    }
//}