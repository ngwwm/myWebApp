window.intercomSettings = {
    api_base: "https://api-iam.intercom.io",
    app_id: "aah8u1xq",
//    email: "customer@example.com", // Email address
//    user_hash: "INSERT_HMAC_VALUE_HERE" // HMAC using SHA-256
};

// We pre-filled your app ID in the widget URL: 'https://widget.intercom.io/widget/aah8u1xq'
(function () {
    let w = window;
    let ic = w.Intercom;

    if (typeof ic === "function") {
        ic('reattach_activator');
        ic('update', w.intercomSettings);
    } else {
        let d = document;
        let i = function () {
            i.c(arguments);
        };
        i.q = [];
        i.c = function (args) {
            i.q.push(args);
        };
        w.Intercom = i;

        let l = function () {
            let s = d.createElement('script');

            s.type = 'text/javascript';
            s.async = true;
            s.src = 'https://widget.intercom.io/widget/aah8u1xq';

            let x = d.getElementsByTagName('script')[0];
            x.parentNode.insertBefore(s, x);
        };

        if (document.readyState === 'complete') {
            l();
        } else if (w.attachEvent) {
            w.attachEvent('onload', l);
        } else {
            w.addEventListener('load', l, false);
        }
    }
})();