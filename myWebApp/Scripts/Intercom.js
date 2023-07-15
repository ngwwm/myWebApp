
let MyWebApp = { name: '', email: '', hash: '' };


window.intercomSettings = {
    api_base: "https://api-iam.intercom.io",
    app_id: "aah8u1xq",
    //email: MyWebApp.email, // Email address
    //user_hash: MyWebApp.hash // HMAC using SHA-256
};

(function () {
    let e0 = document.getElementById('userName');
    MyWebApp.name = e0.textContent;

    if (MyWebApp.name !== '') window.intercomSettings.name = MyWebApp.name;

    let e1 = document.getElementById('userEmail');
    MyWebApp.email = e1.textContent;

    if (MyWebApp.email !== '') window.intercomSettings.email = MyWebApp.email;

    let e2 = document.getElementById('userHash');
    MyWebApp.hash = e2.textContent;

    if (MyWebApp.hash !== '') window.intercomSettings.user_hash = MyWebApp.hash;
})();

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