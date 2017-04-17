import { Injectable } from '@angular/core';
import { ApiClientService } from '../core-module/api-client.service';
import {ILoginModel } from '../model/account-models';

@Injectable()
export class AuthService {
    public baseUrl: string = "/account";
  constructor(private apiService:ApiClientService) { }

  login(model: ILoginModel) {
      return this.apiService.post(`${this.baseUrl}/Auth`, model).subscribe();
  }
}
