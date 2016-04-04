

var margin = { top: 20, right: 40, bottom: 20, left: 40 },
    width = $("#fluid-content").width() - margin.right - margin.left,
    height = $(window).height() / 2 - margin.top - margin.bottom;

var i = 0,
    duration = 750,
    root;

var tree = d3.layout.cluster()
    .size([height, width]);

var diagonal = d3.svg.diagonal()
    .projection(function (d) { return [d.y, d.x]; });

var svg = d3.select("#fluid-content").append("svg")
    .attr("width", width + margin.right + margin.left)
    .attr("height", height + margin.top + margin.bottom)
    .append("g")
    .attr("transform", "translate(" + margin.left + "," + margin.top + ")");


var zoom = d3.behavior.zoom()
    .scaleExtent([0.5, 3])
    .on("zoom", zoomed);

zoom(d3.select("#fluid-content"));

function zoomed() {
    svg.attr("transform", "translate(" + d3.event.translate + ")scale(" + d3.event.scale + ")");
}

var tekenDeterminatietabel = function (x) {
    root = x;
    root.x0 = height / 2;
    root.y0 = 0;

    function collapse(d) {
        if (d.children) {
            d._children = d.children;
            d._children.forEach(collapse);
            d.children = null;
        }
    }

    root.children.forEach(collapse);
    update(root);
};


function update(source) {
    // Compute the new tree layout.
    var nodes = tree.nodes(root).reverse(),
        links = tree.links(nodes);

    // Normalize for fixed-depth.
    nodes.forEach(function (d) { d.y = d.depth * 180; });

    // Update the nodes…
    var node = svg.selectAll("g.node")
        .data(nodes, function (d) { return d.id || (d.id = ++i); });

    // Enter any new nodes at the parent's previous position.
    var nodeEnter = node.enter().append("g")
        .attr("class", "node")
        .attr("transform", function (d) { return "translate(" + source.y0 + "," + source.x0 + ")"; })
        .on("click", click);

    nodeEnter.append("circle")
        .attr("r", 10)
        .style("fill", function (d) { return d._children ? "lightsteelblue" : "#fff"; });

    nodeEnter.append("text")
        .attr("y", function (d) { return d.children || d._children ? 26 : 0; })
        .attr("x", function (d) {
            return 20;
        })
        .attr("dy", ".35em")
        .attr("text-anchor", function (d) { return d.children || d._children ? "end" : "start"; })
        .text(function (d) { return d.name; })
        .attr("class", function (d) { return d.children == undefined ? "leaf" : "" })
        .attr("style", function (d) { return d.children == undefined ? "font-weight : bold" : "" })
        .style("fill-opacity", 1);;

    // Transition nodes to their new position.
    var nodeUpdate = node.transition()
        .duration(duration)
        .attr("transform", function (d) { return "translate(" + d.y + "," + d.x + ")"; });

    nodeUpdate.select("circle")
        .attr("r", 10)
        .style("fill", function (d) { return d._children ? "lightsteelblue" : "#fff"; });

    nodeUpdate.select("text")
        .style("fill-opacity", 1);

    // Transition exiting nodes to the parent's new position.
    var nodeExit = node.exit().transition()
        .duration(duration)
        .attr("transform", function (d) { return "translate(" + source.y + "," + source.x + ")"; })
        .remove();

    nodeExit.select("circle")
        .attr("r", 10);

    nodeExit.select("text")
        .style("fill-opacity", 1e-6);

    // Update the links…
    var link = svg.selectAll("path.link")
        .data(links, function (d) { return d.target.id; });

    // Enter any new links at the parent's previous position.
    link.enter()
        //.insert("defs")
        .insert("path", "g")
        .attr("d", function (d) {
            var o = { x: source.x0, y: source.y0 };
            return diagonal({ source: o, target: o });
        }).attr("class", function (d) {
            return "link";
        })
        .attr("id", function (d) {
            svg.append("use")
                .attr({ "xlink:href": "#" + d.target.id });

            svg.append("text")
                .style("stroke", "none")
                .style("fill", "black")
                .append("textPath")
                .attr("xlink:href", "#" + +d.target.id)
                .attr("startOffset", "50%")
                .text(d.target.Yes ? "ja" : "nee");


            return d.target.id;
        });

    // Transition links to their new position.
    link.transition()
        .duration(duration)
        .attr("d", diagonal);

    // Transition exiting nodes to the parent's new position.
    link.exit().transition()
        .duration(duration)
        .attr("d", function (d) {
            var o = { x: source.x, y: source.y };
            return diagonal({ source: o, target: o });
        })
        .remove();

    // Stash the old positions for transition.
    nodes.forEach(function (d) {
        d.x0 = d.x;
        d.y0 = d.y;
    });
}

// Toggle children on click.
function click(d) {

    if (d.children) {
        d._children = d.children;
        d.children = null;
    } else {
        d.children = d._children;
        d._children = null;
    }
    update(d);
    //checken of het een leaf node is
    if (d.children === undefined && d._children === null)
        controleerKlimaatType(d);

}

function controleerKlimaatType(d) {
    $("#antwoord").html("" +
        "<div class=\"progress progress-striped active\">"
        + "<div class=\"progress-bar\" role=\"progressbar\" aria-valuenow=\"100\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width : 100%\"></div>"
        + "</div>");
    $("#klimaat").val(d.name);
    $("#klimaatForm").submit();
    $("#fluid-content path").attr("class", "link");
    controleerPad(d);
}

function controleerPad(d) {

    if (d.Correct) {
        $("#" + d.id).attr("class", "link correct");

    }
    else {
        $("#" + d.id).attr("class", "link fout");
    }
    if (d.parent !== undefined)
        controleerPad(d.parent);
}


