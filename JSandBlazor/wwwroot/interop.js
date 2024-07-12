window.exampleJsFunctions = {
    showPrompt: function (message) {
        return prompt(message);
    },
    showAlert: function (message) {
        alert(message);
    },
    callBlazorMethod: function (dotNetObjectReference) {
        dotNetObjectReference.invokeMethodAsync('BlazorMethod')
            .then(result => {
                console.log('Blazor method returned: ' + result);
                alert('Blazor method returned: ' + result);
            });
    }
};
