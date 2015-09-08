import RPMGauge = require("./RPMGauge");
class App {

    rpmGauge: RPMGauge;
    signalRHub: any;


    constructor() {

        $.connection.hub.url = "/signalr";
        var hub = $.connection.diRtHub;

        hub.client.data = (d: any) => {
            $("#speed").text(Math.round(d.Speed * 3.6));
            $("#gear").text(d.Gear);
            this.rpmGauge.value(Math.round(d.EngineRevs * 10));

        };

        this.rpmGauge = new RPMGauge(document.getElementById("rev"));
        $.connection.hub.start().done(() => {
            // hub started
        });
    }

    /**
     * function for testing, just throws out some testdata every few seconds
     */
    runTest() {
        var intv: number;
        var oldRev = 0;
        var self = this;
        setInterval(function () {
            var revs = Math.random() * 800;
            clearInterval(intv);
            var deltaRev = (revs - oldRev) / 100;
            intv = setInterval(() => {
                oldRev += deltaRev;
                self.signalRHub.client.data({
                    Speed: 34.166666666666664, Gear: 4, EngineRevs: oldRev
                });
            }, 10);
        }, 1000);
    }
}

export = App;