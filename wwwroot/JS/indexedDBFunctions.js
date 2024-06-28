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
                    db.createObjectStore('data', { keyPath: 'key' });
                }
                if (!db.objectStoreNames.contains('workspaces')) {
                    db.createObjectStore('workspaces', { keyPath: 'id', autoIncrement: true });
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

    getLastId: function (key) {
        return new Promise((resolve, reject) => {
            const transaction = indexedDBFunctions.db.transaction(['data'], 'readonly');
            const store = transaction.objectStore('data');
            const request = store.get(key);

            request.onsuccess = function (event) {
                const result = event.target.result;
                if (result) {
                    resolve(result.id);
                } else {
                    resolve(0);
                }
            };

            request.onerror = function () {
                reject('Erro ao pegar o ultimo id');
            }
        });
    },

    saveLastId: function (lastId, key) {
        return new Promise((resolve, reject) => {
            const transaction = indexedDBFunctions.db.transaction(['data'], 'readwrite');
            const store = transaction.objectStore('data');

            const request = store.put({ key: key, id: lastId });

            request.onsuccess = function () {
                resolve();
            }

            request.onerror = function () {
                reject('Erro ao salvar o último id');
            }
        });
    },

    addNote: function (note) {
        return new Promise(async (resolve, reject) => {
            console.log(note.createDate);
            let lastId = await indexedDBFunctions.getLastId('lastId');
            note.id = ++lastId;

            const transaction = indexedDBFunctions.db.transaction(['notes'], 'readwrite');
            const store = transaction.objectStore('notes');
            const request = store.add(note);

            request.onsuccess = async function () {
                await indexedDBFunctions.saveLastId(lastId, 'lastId');
                resolve();
            };

            request.onerror = function () {
                reject('Erro ao adicionar nota');
            };
        });
    },

    updateNote: function (note) {
        return new Promise(async (resolve, reject) => {
            const transaction = indexedDBFunctions.db.transaction(['notes'], 'readwrite');
            const store = transaction.objectStore('notes');
            const request = store.put(note);

            request.onsuccess = async function () {
                resolve();
            };

            request.onerror = function () {
                reject('Erro ao editar nota');
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
    },

    addWorkspace: function (workspace) {
        return new Promise(async (resolve, reject) => {
            let lastId = await indexedDBFunctions.getLastId('lastIdWks');
            workspace.id = ++lastId;
            workspace.name = "Workspace" + workspace.id;

            const transaction = indexedDBFunctions.db.transaction(['workspaces'], 'readwrite');
            const store = transaction.objectStore('workspaces');
            const request = store.add(workspace);

            request.onsuccess = async function () {
                await indexedDBFunctions.saveLastId(lastId, 'lastIdWks');
                resolve();
            };

            request.onerror = function () {
                reject('Erro ao adicionar workspace');
            };
        });
    },

    updateWorkspace: function (workspace) {
        return new Promise(async (resolve, reject) => {
            const transaction = indexedDBFunctions.db.transaction(['workspaces'], 'readwrite');
            const store = transaction.objectStore('workspaces');
            const request = store.put(workspace);

            request.onsuccess = async function () {
                resolve();
            };

            request.onerror = function () {
                reject('Erro ao editar nota');
            };

        });
    },

    deleteWorkspace: function (id) {
        return new Promise((resolve, reject) => {
            const transaction = indexedDBFunctions.db.transaction(['workspaces'], 'readwrite');
            const store = transaction.objectStore('workspaces');
            const request = store.delete(id);

            request.onsuccess = function () {
                resolve();
            };

            request.onerror = function () {
                reject('Erro ao deletar workspace');
            };
        });
    },

    getAllWorkspaces: function () {
        return new Promise((resolve, reject) => {
            const transaction = indexedDBFunctions.db.transaction(['workspaces'], 'readonly');
            const store = transaction.objectStore('workspaces');
            const request = store.getAll();

            request.onsuccess = function (event) {
                resolve(event.target.result);
            };

            request.onerror = function () {
                reject('Erro ao ler workspaces');
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
