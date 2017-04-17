interface IRegisterCustomer {
    FirstName: string;
    LastName: string;
    Password: string;
    EmailAddress: string;
    UserName: string;
    DateOfBirth: Date;
    PhoneNumber: string;
}

interface ILoginModel {
    EmailAddress: string;
    Password: string;
    RememberMe: boolean;
}

export { IRegisterCustomer, ILoginModel };