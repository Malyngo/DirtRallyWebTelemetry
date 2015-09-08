class RPMGauge {

    private revContainer: d3.Selection<any>;
    private needle: d3.Selection<any>;
    private pie: d3.layout.Pie<number>;
    private arc: d3.svg.Arc<d3.svg.arc.Arc>;
    private needleArc: d3.svg.Arc<d3.svg.arc.Arc>;
    private _value: number = 0;

    constructor(public element: Element, private _maxValue: number = 8000) {

        var width = 500,
            height = 500,
            radius = height / 2 - 10;

        var arc = d3.svg.arc()
            .innerRadius(radius - 40)
            .outerRadius(radius);

        this.needleArc = d3.svg.arc()
            .innerRadius(radius - 45)
            .outerRadius(radius + 5)
            .startAngle(- Math.PI * 4 / 5)
            .endAngle(- Math.PI * 4 / 5 + 0.01);

        var pie = d3.layout.pie()
            .sort(null)
            .startAngle(- Math.PI * 4 / 5)
            .endAngle(Math.PI / 2)
            .padAngle(.03);


        var svg = d3.select(element).append("svg")
            .attr("width", width)
            .attr("height", height);

        var revContainer =
            svg.append("g")
                .attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");

        var needle = svg.append("g")
            .attr("transform", "translate(" + width / 2 + "," + height / 2 + ")")
            .append("path")
            .attr("class", "needle");

        this.needle = needle;
        this.arc = arc;
        this.pie = pie;
        this.revContainer = revContainer;

        this.update();
    }

    value(revs: number) {
        this._value = revs;
        this.update();
    }

    update() {
        var data = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1];
        var val = this._value / this._maxValue * 50;
        var ticks = this.revContainer.selectAll("path").data(this.pie(data));

        var startAngle = 13 / 500 * Math.PI * val - Math.PI * 4 / 5;
        this.needleArc
            .startAngle(startAngle)
            .endAngle(startAngle + 0.01);

        this.needle.attr("d", this.needleArc);

        ticks
            .enter().append("path")
            .attr("d", <any>this.arc);

        ticks
            .attr("class", function (d: any, i: number) { return i < val ? "active" : null; });
    }
}

export = RPMGauge;