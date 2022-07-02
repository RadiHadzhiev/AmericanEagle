function exportToExcel() {

    var dataType = 'application/vnd.ms-excel';
    var table = document.getElementById("tbl");
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