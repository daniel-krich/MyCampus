window.campusCore = {

    writeCookie: function (name, value, dateTime = "") {

        var expires;
        if (dateTime) {
            var date = new Date(dateTime);
            expires = "; expires=" + date.toGMTString();
        }
        else {
            expires = "";
        }
        document.cookie = name + "=" + value + expires + "; path=/";
    },

    getCookie: function(name){
        return document.cookie.split(';').some(c => {
            return c.trim().startsWith(name + '=');
        });
    },

    deleteCookie: function(name) {
        if (this.getCookie(name)) {
            document.cookie = name + '=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
        }
    }
}