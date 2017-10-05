function initMap(location) {
    /*var location = {lat: -25.363, lng: 131.044};*/
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 4,
        center: location
    });
    var marker = new google.maps.Marker({
        position: location,
        map: map
    });
}
/*<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC3-A9m2-bK6oetw4cCJaB0aNPDa4MTaME&callback=setMap"></script>*/
/*Need to create funtion set map that generates location var and pass to initMap funcion*/