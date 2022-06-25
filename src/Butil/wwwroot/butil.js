var butil = (function () {
    let _dotnetObj = null;

    return {
        init,
        register
    };

    function init(dotnetObj) {
        _dotnetObj = dotnetObj;
    }

    function register(elementName, eventName, dotnetMethodName, dotnetMethodId, selectedMembers, options) {
        const handler = e => {
            _dotnetObj.invokeMethodAsync(dotnetMethodName, dotnetMethodId, selectedMembers && select(e, selectedMembers));
        };

        window[elementName].addEventListener(eventName, handler, options);
    }

    function select(source, members) {
        return members.reduce((pre, cur) => pre[cur] = source[cur], {});
    }
}());