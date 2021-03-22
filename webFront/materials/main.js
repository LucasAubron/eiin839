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