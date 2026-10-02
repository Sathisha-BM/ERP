window.deviceHelper = {

    getDeviceId() {
        return this.getDeviceInfo().deviceId;
    },

    isMobile() {
        return this.getDeviceInfo().isMobile;
    },

    getPlatform() {
        return this.getDeviceInfo().platform;
    },

    getUserAgent() {
        return this.getDeviceInfo().userAgent;
    },

    getDeviceInfo() {

        let id = localStorage.getItem("deviceId");

        if (!id) {

            id = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'
                .replace(/[xy]/g, function (c) {
                    var r = Math.random() * 16 | 0;
                    var v = c === 'x' ? r : (r & 0x3 | 0x8);
                    return v.toString(16);
                });

            localStorage.setItem("deviceId", id);
        }

        return {
            deviceId: id,
            platform: navigator.platform,
            userAgent: navigator.userAgent,
            language: navigator.language,
            screenResolution: screen.width + "x" + screen.height,
            isMobile: /Android|iPhone|iPad|iPod|Opera Mini|IEMobile/i.test(navigator.userAgent)
        };
    }
};