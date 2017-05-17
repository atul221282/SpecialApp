interface IAddress extends IBaseEntity {
    AddressState: string;
    PostalCode: string;
    Province: string;
    AddressLine2: string;
    AddressLine1: string;
    City: string;
    Suburb: string;
    AddressTypeId: number;
}

interface IBaseEntity {
    Id?: number;
    AuditCreatedBy: string;
    AuditLastUpdatedBy: string;
    AuditCreatedDate?: Date;
    AuditLastUpdatedDate?: Date;
    IsDeleted?: boolean;
    State?: number;
    RowVersion: Array<number>;
}

const State = {
    Unchanged: 0,
    Added: 1,
    Modified: 2,
    Deleted: 3
};
interface IBaseCode extends IBaseEntity {
    Code: string;
    Description: string;
}


export { IBaseEntity, IBaseCode, IAddress, State };