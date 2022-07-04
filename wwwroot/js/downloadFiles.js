function exportToExcel() {

    var dataType = 'application/vnd.ms-excel';
    var table = document.getElementById('tbl');
    var tableHTML = table.outerHTML.replace(/ /g, '%20');


    var filename = 'excel_data.xls';


    downloadLink = document.createElement("a");

    document.body.appendChild(downloadLink);

    if (navigator.msSaveOrOpenBlob) {
        var blob = new Blob(['\ufeff', tableHTML], {
            type: dataType
        });
        navigator.msSaveOrOpenBlob(blob, filename);
    } else {

        downloadLink.href = 'data:' + dataType + ', ' + tableHTML;


        downloadLink.download = filename;


        downloadLink.click();
    }
}

//this can be used when te request is not cross domain
async function downloadImage(imageSrc) {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", imageSrc, true);
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhr.responseType = "blob";
    xhr.onload = function () {
        var urlCreator = window.URL || window.webkitURL;
        var imageUrl = urlCreator.createObjectURL(this.response);
        var tag = document.createElement('a');
        tag.href = imageUrl;
        document.body.appendChild(tag);
        tag.click();
        document.body.removeChild(tag);
    }
    xhr.send();
}