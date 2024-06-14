window.indexedDBFunctions = {
    db: null,

    openDb: function () {
        return new Promise((resolve, reject) => {
            const request = indexedDB.open('notes-data', 1);

            request.onupgradeneeded = function (event) {
                const db = event.target.result;
                if (!db.objectStoreNames.contains('notes')) {
                    db.createObjectStore('notes', { keyPath: 'id' });
                }
                if (!db.objectStoreNames.contains('data')) {
                    db.createObjectStore('data', { keypath: 'key' });
                }
            };

            request.onsuccess = function (event) {
                indexedDBFunctions.db = event.target.result;
                resolve();
            };

            request.onerror = function () {
                reject('Erro ao abrir o banco de dados');
            }
        })
    },

    getLastId: function () {
        return new Promise((resolve, reject) => {
            const transaction = indexedDBFunctions.db.transaction(['data'], 'readonly');
            const store = transaction.objectStore('data');
            const request = store.get('lastId');

            request.onsuccess = function (event) {
                const result = event.target.result;
                if (result) {
                    //console.log('Último ID: ' + result);
                    resolve(result);
                } else {
                    //console.log('Nenhum último ID encontrado, retornando 0');
                    resolve(0);
                }
            };

            request.onerror = function () {
                reject('Erro ao pegar o ultimo id');
            }
        });
    },

    saveLastId: function (lastId) {
        return new Promise((resolve, reject) => {
            const transaction = indexedDBFunctions.db.transaction(['data'], 'readwrite');
            const store = transaction.objectStore('data');

            const request = store.put(lastId, 'lastId'); 

            request.onsuccess = function () {
                //console.log('Ultimo id salvo: ' + lastId);
                resolve();
            }

            request.onerror = function () {
                reject('Erro ao salvar o último id');
            }
        });
    },

    addNote: function (note) {
        return new Promise(async (resolve, reject) => {
            let lastId = await indexedDBFunctions.getLastId();
            note.id = ++lastId;
            console.log("Id da nota: " + note.id);

            const transaction = indexedDBFunctions.db.transaction(['notes'], 'readwrite');
            const store = transaction.objectStore('notes');
            const request = store.add(note);

            request.onsuccess = async function () {
                await indexedDBFunctions.saveLastId(lastId);
                resolve();
            };

            request.onerror = function () {
                reject('Erro ao adicionar nota');
            };
        });
    },

    getAllNotes: function () {
        return new Promise((resolve, reject) => {
            const transaction = indexedDBFunctions.db.transaction(['notes'], 'readonly');
            const store = transaction.objectStore('notes');
            const request = store.getAll();

            request.onsuccess = function (event) {
                resolve(event.target.result);
            };

            request.onerror = function () {
                reject('Erro ao ler notas');
            };
        });
    },

    deleteNote: function (id) {
        return new Promise((resolve, reject) => {
            const transaction = indexedDBFunctions.db.transaction(['notes'], 'readwrite');
            const store = transaction.objectStore('notes');
            const request = store.delete(id);

            request.onsuccess = function () {
                resolve();
            };

            request.onerror = function () {
                reject('Erro ao ler notas');
            };
        });
    }
};

indexedDBFunctions.openDb()
    .then(() => {
        console.log('Banco de dados IndexedDB aberto com sucesso!');
    })
    .catch(error => {
        console.error('Erro ao abrir o banco de dados IndexedDB:', error);
    });