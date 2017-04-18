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

interface IToken {
    token: string;
    expiration: Date;
    expires_in: Date;
}

export { IRegisterCustomer, ILoginModel, IToken };