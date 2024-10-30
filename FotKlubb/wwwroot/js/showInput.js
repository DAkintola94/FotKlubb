var map = L.map('map').setView([0, 0], 5);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 15,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

modelFormatJson.forEach(function (pinPoints) {
    var marker = L.marker([pinPoints.latitude, pinPoints.longitude]).addTo(map);
    //when serialized, they will typically be represented in camel case in your JavaScript as
    //follow lowercase for accessing the properties after serialization

    //starting the api here
    fetch(`https://nominatim.openstreetmap.org/reverse?format=json&lat=${pinPoints.latitude}&lon=${pinPoints.longitude}`)
    .then(response => response.json())
        .then(data => {
            var address = data.display_name ? data.display_name : "No address found";
            marker.bindPopup(`${pinPoints.description}<br>Address: ${address}`).openPopup();
        })
        .catch(error => {
            console.error('Error:', error);
        });

});

