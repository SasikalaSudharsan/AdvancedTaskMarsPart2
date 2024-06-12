/*
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
var showControllersOnly = false;
var seriesFilter = "";
var filtersOnlySampleSeries = true;

/*
 * Add header in statistics table to group metrics by category
 * format
 *
 */
function summaryTableHeader(header) {
    var newRow = header.insertRow(-1);
    newRow.className = "tablesorter-no-sort";
    var cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Requests";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 3;
    cell.innerHTML = "Executions";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 7;
    cell.innerHTML = "Response Times (ms)";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Throughput";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 2;
    cell.innerHTML = "Network (KB/sec)";
    newRow.appendChild(cell);
}

/*
 * Populates the table identified by id parameter with the specified data and
 * format
 *
 */
function createTable(table, info, formatter, defaultSorts, seriesIndex, headerCreator) {
    var tableRef = table[0];

    // Create header and populate it with data.titles array
    var header = tableRef.createTHead();

    // Call callback is available
    if(headerCreator) {
        headerCreator(header);
    }

    var newRow = header.insertRow(-1);
    for (var index = 0; index < info.titles.length; index++) {
        var cell = document.createElement('th');
        cell.innerHTML = info.titles[index];
        newRow.appendChild(cell);
    }

    var tBody;

    // Create overall body if defined
    if(info.overall){
        tBody = document.createElement('tbody');
        tBody.className = "tablesorter-no-sort";
        tableRef.appendChild(tBody);
        var newRow = tBody.insertRow(-1);
        var data = info.overall.data;
        for(var index=0;index < data.length; index++){
            var cell = newRow.insertCell(-1);
            cell.innerHTML = formatter ? formatter(index, data[index]): data[index];
        }
    }

    // Create regular body
    tBody = document.createElement('tbody');
    tableRef.appendChild(tBody);

    var regexp;
    if(seriesFilter) {
        regexp = new RegExp(seriesFilter, 'i');
    }
    // Populate body with data.items array
    for(var index=0; index < info.items.length; index++){
        var item = info.items[index];
        if((!regexp || filtersOnlySampleSeries && !info.supportsControllersDiscrimination || regexp.test(item.data[seriesIndex]))
                &&
                (!showControllersOnly || !info.supportsControllersDiscrimination || item.isController)){
            if(item.data.length > 0) {
                var newRow = tBody.insertRow(-1);
                for(var col=0; col < item.data.length; col++){
                    var cell = newRow.insertCell(-1);
                    cell.innerHTML = formatter ? formatter(col, item.data[col]) : item.data[col];
                }
            }
        }
    }

    // Add support of columns sort
    table.tablesorter({sortList : defaultSorts});
}

$(document).ready(function() {

    // Customize table sorter default options
    $.extend( $.tablesorter.defaults, {
        theme: 'blue',
        cssInfoBlock: "tablesorter-no-sort",
        widthFixed: true,
        widgets: ['zebra']
    });

    var data = {"OkPercent": 98.71741445571143, "KoPercent": 1.2825855442885585};
    var dataset = [
        {
            "label" : "FAIL",
            "data" : data.KoPercent,
            "color" : "#FF6347"
        },
        {
            "label" : "PASS",
            "data" : data.OkPercent,
            "color" : "#9ACD32"
        }];
    $.plot($("#flot-requests-summary"), dataset, {
        series : {
            pie : {
                show : true,
                radius : 1,
                label : {
                    show : true,
                    radius : 3 / 4,
                    formatter : function(label, series) {
                        return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">'
                            + label
                            + '<br/>'
                            + Math.round10(series.percent, -2)
                            + '%</div>';
                    },
                    background : {
                        opacity : 0.5,
                        color : '#000'
                    }
                }
            }
        },
        legend : {
            show : true
        }
    });

    // Creates APDEX table
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.7116266148076121, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.9986795774647887, 500, 1500, "DeleteEducation"], "isController": false}, {"data": [0.9991095280498664, 500, 1500, "ViewShareSkill"], "isController": false}, {"data": [1.0, 500, 1500, "SignOut"], "isController": false}, {"data": [0.48488888888888887, 500, 1500, "AddShareSkill"], "isController": false}, {"data": [0.4946188340807175, 500, 1500, "DeleteShareSkill"], "isController": false}, {"data": [0.4897413024085638, 500, 1500, "Disable/Enable"], "isController": false}, {"data": [0.505632582322357, 500, 1500, "UpdateSkill"], "isController": false}, {"data": [0.4480349344978166, 500, 1500, "UpdateEducation"], "isController": false}, {"data": [0.0, 500, 1500, "SearchSkillByCategory"], "isController": false}, {"data": [0.968694885361552, 500, 1500, "AddCertification"], "isController": false}, {"data": [0.9849914236706689, 500, 1500, "AddLanguage"], "isController": false}, {"data": [0.9930795847750865, 500, 1500, "AddSkill"], "isController": false}, {"data": [0.5163370593293207, 500, 1500, "UpdateLanguage"], "isController": false}, {"data": [0.8384819064430715, 500, 1500, "DeleteCertifiction"], "isController": false}, {"data": [0.4752136752136752, 500, 1500, "SignIn"], "isController": false}, {"data": [0.9446366782006921, 500, 1500, "DeleteLanguage"], "isController": false}, {"data": [0.9995648389904265, 500, 1500, "DeleteSkill"], "isController": false}, {"data": [0.8667247386759582, 500, 1500, "AddEducation"], "isController": false}, {"data": [0.49734513274336284, 500, 1500, "AddDescription"], "isController": false}]}, function(index, item){
        switch(index){
            case 0:
                item = item.toFixed(3);
                break;
            case 1:
            case 2:
                item = formatDuration(item);
                break;
        }
        return item;
    }, [[0, 0]], 3);

    // Create statistics table
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 21597, 277, 1.2825855442885585, 859.978608140023, 2, 13122, 385.0, 1161.0, 3708.9500000000007, 8730.390000000098, 69.20407463542651, 40.040201541806994, 44.00602280246542], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["DeleteEducation", 1136, 0, 0.0, 275.323063380282, 3, 2313, 277.0, 294.0, 304.14999999999986, 324.25999999999976, 3.849659935409755, 0.8197749274799977, 2.2304825037022478], "isController": false}, {"data": ["ViewShareSkill", 1123, 0, 0.0, 281.62065894924325, 268, 2317, 276.0, 294.0, 302.0, 319.76, 3.8606189366280947, 0.6635438797329537, 2.122586388009392], "isController": false}, {"data": ["SignOut", 1071, 0, 0.0, 8.144724556489267, 2, 360, 5.0, 14.0, 20.0, 34.559999999999945, 3.790801554547192, 7.481650333730347, 0.4442345571734991], "isController": false}, {"data": ["AddShareSkill", 1125, 0, 0.0, 623.7440000000004, 539, 3014, 558.0, 593.0, 618.4000000000001, 2543.44, 3.835728532705979, 0.8390656165294328, 6.300483781261187], "isController": false}, {"data": ["DeleteShareSkill", 1115, 0, 0.0, 1127.1766816143493, 1076, 3426, 1105.0, 1143.0, 1171.0, 1849.319999999992, 3.8541173379974487, 0.7151194279487455, 2.2131064401782226], "isController": false}, {"data": ["Disable/Enable", 1121, 0, 0.0, 865.8840321141844, 805, 2916, 824.0, 857.8000000000001, 877.7999999999997, 2770.7799999999997, 3.84681376754401, 0.7137642732747674, 2.1713460523832397], "isController": false}, {"data": ["UpdateSkill", 1154, 0, 0.0, 1065.641247833623, 274, 3039, 1100.0, 1137.5, 1151.25, 1199.3500000000001, 3.891260512135742, 0.7975415185104632, 2.5176280592253897], "isController": false}, {"data": ["UpdateEducation", 1145, 33, 2.8820960698689957, 1120.894323144105, 6, 3650, 1166.0, 1457.0, 1608.6000000000004, 1900.3399999999992, 3.8652920405366173, 0.814619660115925, 2.7680182846036474], "isController": false}, {"data": ["SearchSkillByCategory", 1102, 0, 0.0, 5912.508166969154, 3637, 13122, 4847.5, 9880.5, 10573.7, 11627.650000000003, 3.774554297751366, 21.1249713675909, 2.7903687533181487], "isController": false}, {"data": ["AddCertification", 1134, 0, 0.0, 344.28659611993015, 280, 2342, 304.5, 375.0, 571.25, 896.4500000000012, 3.8435205835101445, 0.785858718843419, 2.5223103829285325], "isController": false}, {"data": ["AddLanguage", 1166, 0, 0.0, 315.40994854202444, 272, 2404, 283.0, 304.0, 315.64999999999986, 2224.6499999999996, 3.8668683009657223, 0.7887092047052425, 2.2506381907964554], "isController": false}, {"data": ["AddSkill", 1156, 0, 0.0, 298.7577854671284, 271, 2364, 281.0, 302.0, 311.0, 371.0400000000018, 3.875267346514606, 0.785467883638058, 2.361491039282338], "isController": false}, {"data": ["UpdateLanguage", 1163, 0, 0.0, 1053.3619948409278, 271, 3136, 1099.0, 1134.0, 1146.0, 3042.08, 3.8808450431631387, 0.8234028063965536, 2.4017297425644943], "isController": false}, {"data": ["DeleteCertifiction", 1133, 182, 16.063548102383052, 244.79258605472174, 6, 2218, 276.0, 294.0, 301.29999999999995, 328.32000000000016, 3.840560796450278, 0.7374146053594974, 2.225809345011508], "isController": false}, {"data": ["SignIn", 1170, 0, 0.0, 1071.9965811965806, 864, 6689, 951.0, 1321.9, 1500.5000000000005, 4027.0, 3.807156151973864, 1.8292195573936927, 1.3151161996121257], "isController": false}, {"data": ["DeleteLanguage", 1156, 62, 5.3633217993079585, 270.99653979238735, 7, 2236, 278.0, 295.0, 302.0, 329.2900000000002, 3.8748906416027835, 0.7244273663313567, 2.235300304024724], "isController": false}, {"data": ["DeleteSkill", 1149, 0, 0.0, 276.70496083550916, 2, 783, 277.0, 297.0, 306.0, 330.0, 3.885392749295794, 0.7394681319173686, 2.5138237736412115], "isController": false}, {"data": ["AddEducation", 1148, 0, 0.0, 461.3815331010451, 288, 2793, 384.0, 700.2000000000003, 876.0, 1165.08, 3.882089971154854, 0.7865020653192073, 2.638608027269315], "isController": false}, {"data": ["AddDescription", 1130, 0, 0.0, 846.2026548672557, 808, 2872, 833.0, 866.9, 883.0, 928.69, 3.836673162980518, 0.8242852498590956, 2.4840960029844563], "isController": false}]}, function(index, item){
        switch(index){
            // Errors pct
            case 3:
                item = item.toFixed(2) + '%';
                break;
            // Mean
            case 4:
            // Mean
            case 7:
            // Median
            case 8:
            // Percentile 1
            case 9:
            // Percentile 2
            case 10:
            // Percentile 3
            case 11:
            // Throughput
            case 12:
            // Kbytes/s
            case 13:
            // Sent Kbytes/s
                item = item.toFixed(2);
                break;
        }
        return item;
    }, [[0, 0]], 0, summaryTableHeader);

    // Create error table
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 277, 100.0, 1.2825855442885585], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 21597, 277, "500/Internal Server Error", 277, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["UpdateEducation", 1145, 33, "500/Internal Server Error", 33, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["DeleteCertifiction", 1133, 182, "500/Internal Server Error", 182, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": ["DeleteLanguage", 1156, 62, "500/Internal Server Error", 62, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
