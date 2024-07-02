using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Notes.Pages.Services
{
    /// <summary>
    /// Métodos da API Notification JavaScript
    /// </summary>
    public class PushNotification
    {
        private readonly IJSRuntime _jsRuntime;

        public PushNotification(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task RequestNotificationPermission()
        {
            await _jsRuntime.InvokeVoidAsync("askPermission");
        }

        public async Task SendImmediateNotification(string title, string body)
        {
            await _jsRuntime.InvokeVoidAsync("sendNotification", title, body);
        }

        public async Task ScheduleNotification(string title, string body, int id, int milliseconds)
        {
            await _jsRuntime.InvokeVoidAsync("scheduleNotification", title, body, id, milliseconds);
        }
    }
}
