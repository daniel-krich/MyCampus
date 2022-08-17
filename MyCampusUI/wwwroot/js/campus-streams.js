window.campusStreams = {
    createdObjectsUrl: [],

    createObjectBlobUrl: async function(objectStream, mimeType) {
        const arrayBuffer = await objectStream.arrayBuffer();
        const blob = new Blob([arrayBuffer], { type: mimeType });
        const url = URL.createObjectURL(blob);
        this.createdObjectsUrl.push(url);
        return url;
    },

    clearBlobUrlObjects: function () {
        this.createdObjectsUrl.forEach(url => URL.revokeObjectURL(url));
        this.createdObjectsUrl.length = 0;
    },

    clearBlobUrlObject: function (url) {
        URL.revokeObjectURL(url);
        this.createdObjectsUrl = this.createdObjectsUrl.filter(u => u != url);
    },

    downloadBlob: function (filename, blobLink) {
        var element = document.createElement('a');
        element.setAttribute('href', blobLink);
        element.setAttribute('download', filename);
        document.body.appendChild(element);
        element.click();
        document.body.removeChild(element);
    }
}