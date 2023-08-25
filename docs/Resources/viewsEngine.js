const viewsPath = "Resources/Views";
const indexTargetId = "index";
const docTargetId = "docContent";

document.body.onload = () => { loadViews("index"); }

function loadDoc(view) {
    var file = viewsPath + "/" + view;
    const xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (this.readyState == 4 /* 4 = DONE */)
            if (this.status == 200) {
                document.getElementById(docTargetId).innerHTML = this.responseText;
            } else {
                console.error(this.status);
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
                        var vPath = v.getElementsByTagName("path")[0].childNodes[0].nodeValue;
                        var vTitle = v.getElementsByTagName("title")[0].childNodes[0].nodeValue;
                        index +=
                            '<li><a href="#" onclick="loadDoc(\'' +
                            vPath +
                            "');\">" +
                            vTitle +
                            "</a></li>";

                        if (v.hasAttribute('default') && (v.getAttribute('default') == 'true' || v.getAttribute('default') == "1")) {
                            loadDoc(vPath);
                        }
                    }
                    index += "</ul>";
                    document.getElementById(indexTargetId).innerHTML = index;
                } catch (ex) {
                    document.body.innerHTML = "<!-- " + document.body.innerHTML + "-->" + '<div class="container">' + "An error occourred: " + ex.message + "." + '</div>';
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
