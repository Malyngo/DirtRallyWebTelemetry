
define("jquery", function () { return jQuery; });

require.config({
    baseUrl: "js",
    paths: {
        // 'text': '../lib/require/text',
        // 'jquery': '../libs/js/jquery'
    }
});

interface SignalR {
    diRtHub: any;
}

require([
    "App"
],
    (App: any) => {
        "use strict";
        $(document).ready(function () {
            var app = new App();

            // make it available on the window object
            var anyWindow: any = window;
            anyWindow.app = app;
        });
    }
    );