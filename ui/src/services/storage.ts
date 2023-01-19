enum Storage_types {
    AUTH = 'auth',
    EMAIL = 'email',
}

const getLocalStorage = (identifier: Storage_types) => {
    const auth = localStorage.getItem(identifier);
    if (!auth) return null;

    return JSON.parse(auth);
};

const setLocalStorage = (value: any, identifier: Storage_types) => {
    if (value) {
        localStorage.setItem(identifier, JSON.stringify(value));
    }
};

const removeLocalStorage = (identifier: Storage_types) => {
    localStorage.removeItem(identifier);
};

export default {
    getLocalStorage,
    setLocalStorage,
    removeLocalStorage,
};