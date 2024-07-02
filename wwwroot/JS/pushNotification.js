async function askPermission() {
    const permission = await Notification.requestPermission();
    if (permission !== 'granted') {
        throw new Error('Permissão para notificações negada');
    }
}

async function sendNotification(title, body) {
    const registration = await navigator.serviceWorker.ready;
    if (Notification.permission === 'granted') {
        registration.showNotification(title, {
            body: body,
            icon: "/images/Maskable/icon128_maskable.png"
        });
    } else {
        console.error('Notificações não estão permitidas.');
    }
}

function notificationSendConfirm(noteId) {
    const result = DotNet.invokeMethodSync('Notes', 'MeuNamespace.MinhaClasse.MeuMetodo');
}

function scheduleNotification(title, body, id, delay) {
    setTimeout(async () => {
        sendNotification(title, body);

        try {
            var note = await indexedDBFunctions.getNote(id);

            note.task.notification = true;

            await indexedDBFunctions.updateNote(note);
        } catch (error) {
            console.error('Erro ao obter ou atualizar a nota:', error);
        }
    }, delay);
}