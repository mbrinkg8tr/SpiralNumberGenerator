

// This function accepts a numeric value and creates a table
// of numbers starting at the inValue, and spirals toward the
// center to 0.  A fade-in effect is included in this method.
// Uses an XHR call to get the data from a service

var drawSpiral = function (inValue) {
    $.getJSON("/Generate/"+inValue,
        function(data) {
            var tableResult = document.createElement("tbody");
            tableResult.id = "visibleTable";
            $.each(data,
                function() {
                    var row = tableResult.insertRow();
                    $.each(this,
                        function(key, value) {
                            var cell = row.insertCell();
                            cell.id = value;
                            cell.className = value;

                            // Filter out the number from the response if
                            // it is higher than the input value
                            var outElement;
                            if (value > inValue) outElement = document.createTextNode(".");                      
                            else outElement = document.createTextNode(value.toString());

                            // Fade In Effect - use a different delay for each number (not for production use!!)
                            value = value / (inValue / 3);
                            cell.setAttribute('style', 'animation: fadein ' + value +
                                's; -moz-animation: fadein ' + value +
                                's; -webkit-animation: fadein ' + value +
                                's; -o-animation: fadein ' + value + 's;');


                            cell.appendChild(outElement);
                        });
                });
            $("#visibleTable").remove();
            $("#spiralTable").append(tableResult);
        });
}


