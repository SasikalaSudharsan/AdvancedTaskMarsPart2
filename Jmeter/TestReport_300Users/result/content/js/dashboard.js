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

    var data = {"OkPercent": 98.41821658265253, "KoPercent": 1.581783417347471};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.6402746393186164, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.9712041884816754, 500, 1500, "DeleteEducation"], "isController": false}, {"data": [0.9745354439091535, 500, 1500, "ViewShareSkill"], "isController": false}, {"data": [1.0, 500, 1500, "SignOut"], "isController": false}, {"data": [0.19238476953907815, 500, 1500, "AddShareSkill"], "isController": false}, {"data": [0.19680111265646733, 500, 1500, "DeleteShareSkill"], "isController": false}, {"data": [0.23275862068965517, 500, 1500, "Disable/Enable"], "isController": false}, {"data": [0.47767857142857145, 500, 1500, "UpdateSkill"], "isController": false}, {"data": [0.39922229423201555, 500, 1500, "UpdateEducation"], "isController": false}, {"data": [0.0, 500, 1500, "SearchSkillByCategory"], "isController": false}, {"data": [0.937992125984252, 500, 1500, "AddCertification"], "isController": false}, {"data": [0.934823677581864, 500, 1500, "AddLanguage"], "isController": false}, {"data": [0.9570883661792753, 500, 1500, "AddSkill"], "isController": false}, {"data": [0.48484848484848486, 500, 1500, "UpdateLanguage"], "isController": false}, {"data": [0.7825082508250825, 500, 1500, "DeleteCertifiction"], "isController": false}, {"data": [0.39209535759096614, 500, 1500, "SignIn"], "isController": false}, {"data": [0.9145489199491741, 500, 1500, "DeleteLanguage"], "isController": false}, {"data": [0.9758376288659794, 500, 1500, "DeleteSkill"], "isController": false}, {"data": [0.816010329244674, 500, 1500, "AddEducation"], "isController": false}, {"data": [0.4851288830138797, 500, 1500, "AddDescription"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 28765, 455, 1.581783417347471, 3429.7751434034385, 2, 155894, 582.0, 5426.9000000000015, 13383.600000000035, 108507.62000000005, 49.0090010273745, 27.60418086476651, 31.260961376767025], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["DeleteEducation", 1528, 0, 0.0, 338.99803664921455, 3, 4616, 282.0, 336.10000000000014, 429.64999999999986, 2503.9500000000016, 2.723329020207529, 0.5799765975051597, 1.577195483515661], "isController": false}, {"data": ["ViewShareSkill", 1453, 0, 0.0, 341.86097728836893, 269, 11181, 282.0, 332.60000000000014, 465.29999999999995, 1711.4400000000023, 2.650985772617306, 0.45563817966859943, 1.457524404280804], "isController": false}, {"data": ["SignOut", 1294, 0, 0.0, 11.557959814528608, 2, 171, 6.0, 25.0, 34.0, 91.04999999999995, 2.3681633922934036, 4.67388497639157, 0.2775191475343832], "isController": false}, {"data": ["AddShareSkill", 1497, 0, 0.0, 14810.50968603875, 541, 108220, 2620.0, 62094.0, 93915.79999999999, 99714.3, 2.6752589479101885, 0.5852128948553538, 4.39432182654779], "isController": false}, {"data": ["DeleteShareSkill", 1438, 0, 0.0, 4154.073713490962, 1080, 126634, 1770.5, 6184.600000000002, 15771.299999999997, 50036.87999999999, 2.593818486818965, 0.48127491454648763, 1.4894192092280776], "isController": false}, {"data": ["Disable/Enable", 1450, 0, 0.0, 7249.317931034473, 805, 100568, 1608.0, 16642.300000000043, 48859.95, 79174.92, 2.6050602846881743, 0.48336079501050105, 1.4704344185056295], "isController": false}, {"data": ["UpdateSkill", 1568, 0, 0.0, 1233.8533163265315, 272, 12904, 1112.0, 1300.0, 1735.7499999999998, 5032.319999999974, 2.751572327044025, 0.5654885976676564, 1.7800361105481033], "isController": false}, {"data": ["UpdateEducation", 1543, 61, 3.9533376539209333, 1240.401166558652, 6, 13157, 1169.0, 1701.2000000000003, 1918.1999999999998, 4786.12, 2.707559055670783, 0.5682434458382905, 1.9382611445534723], "isController": false}, {"data": ["SearchSkillByCategory", 1428, 0, 0.0, 31673.690476190473, 3641, 155894, 9820.5, 134163.90000000002, 150467.5, 154495.82, 2.53932576277576, 14.211792916472541, 1.8772164086145025], "isController": false}, {"data": ["AddCertification", 1524, 0, 0.0, 402.12926509186326, 279, 5448, 312.0, 501.5, 647.25, 2581.75, 2.729187260927494, 0.559423788251601, 1.7910291399836678], "isController": false}, {"data": ["AddLanguage", 1588, 0, 0.0, 432.1404282115869, 273, 11486, 288.0, 475.0, 1135.1999999999998, 3840.22, 2.7704793906341045, 0.5652956130296274, 1.6125055828300061], "isController": false}, {"data": ["AddSkill", 1573, 0, 0.0, 379.8512396694215, 271, 4845, 287.0, 417.0, 544.5999999999999, 3741.779999999998, 2.7618198162766525, 0.560037894915653, 1.682983950543585], "isController": false}, {"data": ["UpdateLanguage", 1584, 0, 0.0, 1231.7260101010113, 272, 13064, 1110.0, 1369.5, 2099.75, 6009.950000000015, 2.769308232398109, 0.5884756091298008, 1.7136897623010432], "isController": false}, {"data": ["DeleteCertifiction", 1515, 305, 20.13201320132013, 280.8930693069305, 5, 3981, 279.0, 325.0, 384.20000000000005, 1946.4399999999987, 2.7140858367714737, 0.5101244834951335, 1.570744637553095], "isController": false}, {"data": ["SignIn", 1594, 0, 0.0, 1446.3682559598496, 861, 13991, 992.0, 2703.5, 3216.0, 7767.949999999988, 2.7391846028268247, 1.316092602139451, 0.946228103385316], "isController": false}, {"data": ["DeleteLanguage", 1574, 89, 5.65438373570521, 322.9243964421863, 6, 4224, 281.0, 382.0, 497.5, 1775.75, 2.7635804344123707, 0.5159954809797542, 1.5940736650449212], "isController": false}, {"data": ["DeleteSkill", 1552, 0, 0.0, 335.55541237113374, 2, 11782, 282.0, 345.70000000000005, 438.0, 1992.5800000000004, 2.7300008091497245, 0.5201257166911757, 1.7660658134461333], "isController": false}, {"data": ["AddEducation", 1549, 0, 0.0, 553.7850225952229, 285, 12917, 395.0, 878.0, 1079.0, 2981.0, 2.722606953281541, 0.5520460060595141, 1.8505219135585473], "isController": false}, {"data": ["AddDescription", 1513, 0, 0.0, 943.2742894910772, 809, 6341, 843.0, 972.6000000000001, 1162.3, 4329.199999999993, 2.707665215897377, 0.5817249487279521, 1.7531074591210558], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 455, 100.0, 1.581783417347471], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 28765, 455, "500/Internal Server Error", 455, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["UpdateEducation", 1543, 61, "500/Internal Server Error", 61, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["DeleteCertifiction", 1515, 305, "500/Internal Server Error", 305, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": ["DeleteLanguage", 1574, 89, "500/Internal Server Error", 89, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
