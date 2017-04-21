import { Injectable } from '@angular/core';

@Injectable()
export class StorageService {

    constructor() { }

    setItem(key: string, value: any): void {
        localStorage.setItem(key, JSON.stringify(value));
    }

    getItem<T>(key: string): T {
        if (localStorage.getItem(key) !== null)
            return JSON.parse(localStorage.getItem(key)) as T;
        return null;
    }

    removeItem(key: string) {
        localStorage.removeItem(key);
    }
}
