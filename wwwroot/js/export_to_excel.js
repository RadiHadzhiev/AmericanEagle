function exporttocsv() {
    $("#mytable").tableToCSV({
        filename: 'employeelist'
    });
} 