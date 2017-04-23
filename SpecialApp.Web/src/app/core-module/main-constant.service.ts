import { Injectable } from '@angular/core';

@Injectable()
export class MainConstantService {

    commonVariable = {
        access_token: "access_token",
        previous_url: "previousUrl"
    }
    constructor() {

    }

}
