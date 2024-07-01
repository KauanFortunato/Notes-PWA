using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Notes.Pages.Services
{
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

        public async Task SendImmediateNotification()
        {
            await _jsRuntime.InvokeVoidAsync("sendNotification", "Notificação Imediata", "Esta é uma notificação enviada imediatamente.");
        }

        public async Task ScheduleNotification(int seconds)
        {
            await _jsRuntime.InvokeVoidAsync("scheduleNotification", "Notificação Agendada", "Esta é uma notificação agendada.", seconds);
        }

    }
}
