using SpecialApp.Entity2;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Special
{
    public class CompanyFranchise : BaseEntity
    {
        #region "Private member"

        //private Company _company = new Company();
        private List<SpecialAppUsers> _companyFranchiseUsers = new List<SpecialAppUsers>();
        private Address _address = new Address();
        private bool? _canSellOnline;
        private bool? _canContactCustomers;
        private bool? _canGetCustomerDetails;
        private bool? _isConfirmed;
        //private List<CompanyFranchiseFollowedByUser> _companyFranchiseFollowedByUsers = new List<CompanyFranchiseFollowedByUser>();
        //private List<CompanyFranchiseSpecial> _companyFranchiseSpecial = new List<CompanyFranchiseSpecial>();
        //private List<CompanyFranchiseViewed> _companyFranchiseViewed = new List<CompanyFranchiseViewed>();
        private CompanyFranchiseCategory _companyFranchiseCaregory = new CompanyFranchiseCategory();
        private string _confirmationToken;
        private SpecialAppUsers _createdBy;
        private int _companyFranchiseCaregoryId;
        private int _addressId;
        private int _createdById;
        #endregion

        public bool? IsConfirmed
        {
            get { return _isConfirmed; }
            set { _isConfirmed = value; }
        }


        public bool? CanGetCustomerDetails
        {
            get { return _canGetCustomerDetails; }
            set { _canGetCustomerDetails = value; }
        }


        public bool? CanContactCustomers
        {
            get { return _canContactCustomers; }
            set { _canContactCustomers = value; }
        }


        public bool? CanSellOnline
        {
            get { return _canSellOnline; }
            set { _canSellOnline = value; }
        }

        public string ConfirmationToken
        {
            get { return _confirmationToken; }
            set { _confirmationToken = value; }
        }

        public int AddressId
        {
            get { return _addressId; }
            set { _addressId = value; }
        }

        public int CompanyFranchiseCategoryId
        {
            get { return _companyFranchiseCaregoryId; }
            set { _companyFranchiseCaregoryId = value; }
        }

        public int CreatedById
        {
            get { return _createdById; }
            set { _createdById = value; }
        }

        //public Company Company
        //{
        //    get { return _company; }
        //    set { _company = value; }
        //}

        public virtual Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public virtual CompanyFranchiseCategory CompanyFranchiseCategory
        {
            get { return _companyFranchiseCaregory; }
            set { _companyFranchiseCaregory = value; }
        }

        public virtual SpecialAppUsers CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        public List<SpecialAppUsers> CompanyFranchiseUsers
        {
            get { return _companyFranchiseUsers; }
            set { _companyFranchiseUsers = value; }
        }

        //public List<CompanyFranchiseFollowedByUser> CompanyFranchiseFollowedByUsers
        //{
        //    get { return _companyFranchiseFollowedByUsers; }
        //    set { _companyFranchiseFollowedByUsers = value; }
        //}

        //public List<CompanyFranchiseSpecial> CompanyFranchiseSpecial
        //{
        //    get { return _companyFranchiseSpecial; }
        //    set { _companyFranchiseSpecial = value; }
        //}

        //public List<CompanyFranchiseViewed> CompanyFranchiseViewed
        //{
        //    get { return _companyFranchiseViewed; }
        //    set { _companyFranchiseViewed = value; }
        //}
    }
}
