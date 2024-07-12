
    using Microsoft.JSInterop;
    using System.Threading.Tasks;

    namespace JSandBlazor.services
    {
        public class JsInterop
        {
            private readonly IJSRuntime _jsRuntime;

            public JsInterop(IJSRuntime jsRuntime)
            {
                _jsRuntime = jsRuntime;
            }

            public async ValueTask<string> ShowPrompt(string message)
            {
                return await _jsRuntime.InvokeAsync<string>("exampleJsFunctions.showPrompt", message);
            }

            public async ValueTask ShowAlert(string message)
            {
                await _jsRuntime.InvokeVoidAsync("exampleJsFunctions.showAlert", message);
            }
        public async Task InvokeBlazorMethod()
        {
            var dotNetObjectReference = DotNetObjectReference.Create(new JsInteropBlazorMethods());
            await _jsRuntime.InvokeVoidAsync("exampleJsFunctions.callBlazorMethod", dotNetObjectReference);
        }
    }

    public class JsInteropBlazorMethods
    {
        [JSInvokable]
        public Task<string> BlazorMethod()
        {
            return Task.FromResult("Hello from Blazor method!");
        }
    }
}