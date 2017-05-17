import { Injectable } from '@angular/core';
import { ApiClientService } from '../core-module/api-client.service';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { ICreateCompanyModel } from '../model/';
import { State } from '../model/';

@Injectable()
export class CompanyAccountService {

    public baseurl: string = "account/company";

    constructor(private apiClient: ApiClientService) { }

    createCompany(company: ICreateCompanyModel) {
        company.State = State.Added;
        return this.apiClient.post(`${this.baseurl}`, company)
            .catch(this.handleError);
    }

    private handleError(error: Response, er: any) {
        let msg = `Error status code ${error.status} at ${error.url}`;
        return Observable.throw(msg);
    }
}
