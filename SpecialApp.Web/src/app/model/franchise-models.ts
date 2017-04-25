import { IRegisterCustomer } from './account-models';
import { IAddress } from './common-models';

interface IRegisterFranchiseModel {
    IsConfirmed: boolean;
    CanGetCustomerDetails: boolean;
    CanContactCustomers: boolean;
    CanSellOnline: boolean;
    ConfirmationToken: string;
    CompanyFranchiseCategoryId: number;
    CreatedBy: IRegisterCustomer;
    Address?: IAddress;
    CompanyId: number;
}