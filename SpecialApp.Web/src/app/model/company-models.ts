import { IBaseEntity, IAddress } from './';

interface ICreateCompanyModel {
    ComapnyId?: number;
    CompanyName: string;
    NumberOfEmployees?: number;
    Details: string;
    Addresses: IAddress[];
    State: number;
}

export { ICreateCompanyModel };