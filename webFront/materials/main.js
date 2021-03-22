//document.getElementById("workingTest").innerHTML="It works";
var stations;

function retrieveAllContracts(){
    var targetUrl = "https://api.jcdecaux.com/vls/v3/contracts?apiKey=" + document.getElementById("aiedy").value;
    var requestType = "GET";

    var caller = new XMLHttpRequest();
    caller.open(requestType, targetUrl, true);
    // The header set below limits the elements we are OK to retrieve from the server.
    caller.setRequestHeader ("Accept", "application/json");
    // onload shall contain the function that will be called when the call is finished.
    caller.onload=contractsRetrieved;
    caller.send();
}

function contractsRetrieved(){
    // Let's parse the response:
    var response = JSON.parse(this.responseText);
    console.log(response)
    for (let i=0; i<response.length; i++){
    	var optionNode = document.createElement("option")
    	optionNode.value = response[i].name
    	document.getElementById("dl").appendChild(optionNode)
    }
    console.log(document.getElementById("dl"))
}

function retrieveContractStations(){
    var targetUrl = "https://api.jcdecaux.com/vls/v1/stations?contract="+document.getElementById("komtract").value+"&apiKey=" + document.getElementById("aiedy").value;
    var requestType = "GET";

    var caller = new XMLHttpRequest();
    caller.open(requestType, targetUrl, true);
    // The header set below limits the elements we are OK to retrieve from the server.
    caller.setRequestHeader ("Accept", "application/json");
    // onload shall contain the function that will be called when the call is finished.
    caller.onload=saveStations;
    caller.send();
}

function saveStations(){
	var response = JSON.parse(this.responseText)
	stations = response
	console.log(stations)
}

function getDistanceFrom2GpsCoordinates(lat1, lon1, lat2, lon2) {
    // Radius of the earth in km
    var earthRadius = 6371;
    var dLat = deg2rad(lat2-lat1);
    var dLon = deg2rad(lon2-lon1);
    var a =
        Math.sin(dLat/2) * Math.sin(dLat/2) +
        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
        Math.sin(dLon/2) * Math.sin(dLon/2)
    ;
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
    var d = earthRadius * c; // Distance in km
    return d;
}

function deg2rad(deg) {
    return deg * (Math.PI/180)
}

function closestStation(){
	var lat = document.getElementById("lat").value
	var long = document.getElementById("lon").value
	var best = Math.pow(10,1000)//infinity
	nameBest = "None" 
	for (let i=0; i<stations.length; i++){
		if (best>getDistanceFrom2GpsCoordinates(lat, long, stations[i].position.lat, stations[i].position.lng)){
			best = getDistanceFrom2GpsCoordinates(lat, long, stations[i].position.lat, stations[i].position.lng)
			nameBest = stations[i].address
		}
	}
	console.log(nameBest)
}