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

    var data = {"OkPercent": 96.46196345091373, "KoPercent": 3.538036549086273};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.512882490437739, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.8758553274682307, 500, 1500, "DeleteEducation"], "isController": false}, {"data": [0.9310689310689311, 500, 1500, "ViewShareSkill"], "isController": false}, {"data": [1.0, 500, 1500, "SignOut"], "isController": false}, {"data": [0.029382957884427033, 500, 1500, "AddShareSkill"], "isController": false}, {"data": [0.013803680981595092, 500, 1500, "DeleteShareSkill"], "isController": false}, {"data": [0.017482517482517484, 500, 1500, "Disable/Enable"], "isController": false}, {"data": [0.40679611650485437, 500, 1500, "UpdateSkill"], "isController": false}, {"data": [0.29296875, 500, 1500, "UpdateEducation"], "isController": false}, {"data": [0.0, 500, 1500, "SearchSkillByCategory"], "isController": false}, {"data": [0.8137829912023461, 500, 1500, "AddCertification"], "isController": false}, {"data": [0.7812197483059051, 500, 1500, "AddLanguage"], "isController": false}, {"data": [0.8276699029126213, 500, 1500, "AddSkill"], "isController": false}, {"data": [0.42642787996127784, 500, 1500, "UpdateLanguage"], "isController": false}, {"data": [0.4472140762463343, 500, 1500, "DeleteCertifiction"], "isController": false}, {"data": [0.32259615384615387, 500, 1500, "SignIn"], "isController": false}, {"data": [0.7922330097087379, 500, 1500, "DeleteLanguage"], "isController": false}, {"data": [0.8690360272638754, 500, 1500, "DeleteSkill"], "isController": false}, {"data": [0.6398635477582846, 500, 1500, "AddEducation"], "isController": false}, {"data": [0.4066471163245357, 500, 1500, "AddDescription"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 18824, 666, 3.538036549086273, 13648.684817254607, 2, 267828, 867.0, 43484.5, 121393.0, 180316.0, 22.454379104926268, 11.861888428610964, 14.535539912617109], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["DeleteEducation", 1023, 0, 0.0, 553.1612903225816, 3, 64260, 282.0, 1061.0, 1599.9999999999986, 3357.8, 1.3634964153239404, 0.2904942732817346, 0.788310413187396], "isController": false}, {"data": ["ViewShareSkill", 1001, 0, 0.0, 404.77522477522507, 269, 2790, 292.0, 488.8000000000004, 1198.4999999999995, 2201.88, 1.6895085066162572, 0.2903842745746692, 0.9288996965087429], "isController": false}, {"data": ["SignOut", 540, 0, 0.0, 19.048148148148147, 2, 389, 6.0, 32.900000000000034, 69.89999999999986, 338.6500000000011, 0.9187032673511573, 1.8131829133952042, 0.10766053914271376], "isController": false}, {"data": ["AddShareSkill", 1021, 0, 0.0, 48945.45543584729, 545, 204802, 20036.0, 149632.2, 199804.3, 201476.84, 1.6910777017906211, 0.3699232472666984, 2.7777272406365476], "isController": false}, {"data": ["DeleteShareSkill", 978, 0, 0.0, 26737.41922290386, 1095, 248856, 9889.0, 74336.3, 75548.0, 244346.54000000007, 1.654419227802363, 0.3069723176586415, 0.9499985409646381], "isController": false}, {"data": ["Disable/Enable", 1001, 0, 0.0, 30628.807192807224, 814, 245185, 10391.0, 72789.2, 154069.9, 204795.70000000004, 1.6733366097966251, 0.3104823787708582, 0.9445200785766107], "isController": false}, {"data": ["UpdateSkill", 1030, 0, 0.0, 2306.1029126213607, 273, 185442, 1112.0, 5157.599999999999, 5735.949999999996, 6447.819999999995, 1.2950436291397391, 0.26940620520783565, 0.8369860393825282], "isController": false}, {"data": ["UpdateEducation", 1024, 84, 8.203125, 1661.6230468749982, 6, 150219, 1139.0, 2794.5, 4634.5, 6239.25, 1.3126875611316289, 0.27077335676899394, 0.9384065588228885], "isController": false}, {"data": ["SearchSkillByCategory", 918, 0, 0.0, 116843.41938997815, 3713, 267828, 129747.0, 153239.30000000002, 159515.84999999998, 254278.84999999998, 1.4762307551290175, 8.261990681293359, 1.0913151187819006], "isController": false}, {"data": ["AddCertification", 1023, 0, 0.0, 688.6979472140754, 279, 84523, 324.0, 1433.8000000000002, 2190.199999999999, 3121.52, 1.4905192485335212, 0.3122336976278452, 0.9781532568501234], "isController": false}, {"data": ["AddLanguage", 1033, 0, 0.0, 22611.160696999017, 273, 201433, 291.0, 130988.40000000001, 177203.5, 180249.6, 1.2838167012994761, 0.26300479015562395, 0.7472214394282107], "isController": false}, {"data": ["AddSkill", 1030, 0, 0.0, 724.2999999999993, 271, 84676, 289.0, 1970.6999999999998, 2246.8999999999996, 2690.349999999999, 1.2900817761545293, 0.2625261128051263, 0.7861435823441663], "isController": false}, {"data": ["UpdateLanguage", 1033, 0, 0.0, 4462.580832526627, 272, 201929, 1110.0, 3246.6, 4765.799999999999, 88272.15999999999, 1.2857630063703147, 0.27449509608371275, 0.7949316039893505], "isController": false}, {"data": ["DeleteCertifiction", 1023, 500, 48.87585532746823, 405.55425219941316, 5, 5106, 273.0, 1039.8000000000004, 2103.3999999999996, 3613.999999999999, 1.6997251861722453, 0.2708051092900034, 0.9722610701248792], "isController": false}, {"data": ["SignIn", 1040, 0, 0.0, 3832.474038461533, 860, 29625, 987.5, 9227.099999999999, 25329.999999999996, 28420.49999999999, 1.28570298283092, 0.6177401050320437, 0.4441516102657202], "isController": false}, {"data": ["DeleteLanguage", 1030, 82, 7.961165048543689, 813.7184466019409, 6, 189552, 281.0, 1138.1999999999991, 1744.199999999999, 2300.389999999998, 1.287786532503482, 0.23798019668751297, 0.7420987107131337], "isController": false}, {"data": ["DeleteSkill", 1027, 0, 0.0, 736.7468354430375, 2, 185066, 282.0, 1420.2, 1549.5999999999963, 2846.520000000002, 1.3016130115674993, 0.24960966263889048, 0.8412274118813061], "isController": false}, {"data": ["AddEducation", 1026, 0, 0.0, 960.0984405458092, 289, 146621, 637.5, 1540.3000000000002, 1731.6, 2587.5600000000013, 1.3022039738797684, 0.2649241610557244, 0.885091763496405], "isController": false}, {"data": ["AddDescription", 1023, 0, 0.0, 1390.3000977517108, 810, 6923, 845.0, 3332.200000000001, 4744.8, 5992.759999999998, 1.7002732403917111, 0.36529307899040664, 1.1008605062301802], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 666, 100.0, 3.538036549086273], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 18824, 666, "500/Internal Server Error", 666, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["UpdateEducation", 1024, 84, "500/Internal Server Error", 84, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["DeleteCertifiction", 1023, 500, "500/Internal Server Error", 500, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": ["DeleteLanguage", 1030, 82, "500/Internal Server Error", 82, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
