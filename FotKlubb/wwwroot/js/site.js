var map = L.map('map').setView([60.145, 10.25], 15);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

const interactWithButton = document.getElementById("markerClear");

let currentMarker;
let startMarkerSpam = false;

interactWithButton.addEventListener("click", function () {
    if (currentMarker != null) {
        startMarkerSpam = false;
        currentMarker.remove();
        currentMarker = null;
    }
    
});


map.on('click', function (eventListner) {
    

    if (startMarkerSpam) {
        return;
    }

    var lati = eventListner.latlng.lat;
    var long = eventListner.latlng.lng;

    document.getElementById("latit").value = lati; //getting the ID from the html, and setting the value to variable lati
    document.getElementById("longi").value = long; //same here, getting the ID from html, and attaching it

    

    currentMarker = L.marker([lati, long]).addTo(map); //adding the variables at last stage to the map

    startMarkerSpam = true;

});
