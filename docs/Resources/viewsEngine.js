const viewsPath = "Resources/Views";
const indexTargetId = "index";
const docTargetId = "docContent";

addEventListener("hashchange", loadfromhash);
document.body.onload = body_onLoad;

function body_onLoad() {
	loadViews("index");
	loadfromhash();
}

function loadfromhash() {
	var hash = window.location.hash.substring(1);
	if (hash) loadDoc(hash);
}

function htmlEntities(str) {
	return String(str).replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/"/g, "&quot;");
}

function loadDoc(view) {
	var file = viewsPath + "/" + view + ".html";
	const xhr = new XMLHttpRequest();

	xhr.onreadystatechange = function () {
		if (this.readyState == 4 /* 4 = DONE */)
			if (this.status == 200) {
				document.getElementById(docTargetId).innerHTML = this.responseText;
			} else {
				console.error(this.status);
				if (this.status == 404)
					document.getElementById(docTargetId).innerHTML =
						"<h2>Not Found</h2>\nThe requested view could not be found.";
			}
	};

	xhr.open("GET", file, true);
	xhr.send();
	return;
}

function loadViews() {
	const xhr = new XMLHttpRequest();
	xhr.onreadystatechange = function () {
		if (this.readyState == 4)
			if (this.status == 200) {
				var xml = this.responseXML;
				var index = "<h2>Index</h2>\n<ul>";
				try {
					var views = xml.getElementsByTagName("view");
					var i;
					for (i = 0; i < views.length; i++) {
						var v = views[i];
						var vPath = v.getElementsByTagName("name")[0].childNodes[0].nodeValue;
						var vTitle = v.getElementsByTagName("title")[0].childNodes[0].nodeValue;
						index += '<li><a href="#/' + vPath + '">' + vTitle + "</a></li>";

						if (
							v.hasAttribute("default") &&
							(v.getAttribute("default") == "true" || v.getAttribute("default") == "1")
						) {
							if (!window.location.hash) loadDoc(vPath);
						}
					}
					index += "</ul>";
					document.getElementById(indexTargetId).innerHTML = index;
				} catch (ex) {
					var html = htmlEntities(document.body.innerHTML);
					document.body.innerHTML =
						"<!-- An error occourred. This was the body before the error: \n" +
						html +
						"\n-->" +
						'<div class="container">' +
						"An error occourred: " +
						ex.message +
						"." +
						"</div>";
					throw ex;
				}
			} else {
				console.error(this.status);
			}
	};

	xhr.open("GET", viewsPath + "/views.xml");
	xhr.send();
	return;
}
