async function askPermission() {
    const permission = await Notification.requestPermission();
    if (permission !== 'granted') {
        throw new Error('Permiss�o para notifica��es negada');
    }
}

async function sendNotification(title, body) {
    const registration = await navigator.serviceWorker.ready;
    if (Notification.permission === 'granted') {
        registration.showNotification(title, {
            body: body
        });
    } else {
        console.error('Notifica��es n�o est�o permitidas.');
    }
}

function scheduleNotification(title, body, delay) {
    setTimeout(() => {
        sendNotification(title, body);
    }, delay);
}