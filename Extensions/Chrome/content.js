let webSocket = null;

function connect() {
	try{
		webSocket = new WebSocket('ws://localhost:42570/chrome');
	}
	catch (error){
		webSocket = null;
		console.log('Could not connect to Unimote Server...');
		return;
	}

  webSocket.onopen = (event) => {
    console.log('Connected to Unimote Server!');
  };

  webSocket.onmessage = (event) => {
	var split = event.data.split(';');
	var targetPage = split[0]
	var targetElement = split[1]
	var action = split[2]
	
	if (window.location.href == targetPage){
		if (action == "click"){
			var element = getElementByXPath(targetElement)
			element.click();
		}
	}
  };

  webSocket.onclose = (event) => {
    console.log('Unimote connection closed.');
    webSocket = null;
	tryConnecting();
  };
}

var getElementByXPath = function (xPath) {
    var xPathResult = document.evaluate(xPath, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null);
    return xPathResult.singleNodeValue;
};

function disconnect() {
  if (webSocket == null) {
    return;
  }
  webSocket.close();
}

function sleep(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

function tryConnecting(){
	while(webSocket == null){
		sleep(10000).then(connect());
	}
}

chrome.storage.local.get(["unimote_enabled"]).then((result) => {
	if (result.unimote_enabled == true)
		tryConnecting();
});