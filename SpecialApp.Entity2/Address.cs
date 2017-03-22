namespace SpecialApp.Entity2
{
    public class Address : BaseEntity
    {
        #region Private member
        private string _addressLine1;
        private string _addressLine2;
        private string _city;
        private string _suburb;
        private string _addresState;
        private string _postalCode;
        private string _province;
        private Country _country;
        private int _counrtyId;
        private int _addressTypeId;
        private AddressType _addressType;
        #endregion Private member

        public int CounrtyId
        {
            get { return _counrtyId; }
            set { _counrtyId = value; }
        }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>

        public virtual Country Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// Gets or sets the State
        /// </summary>

        public string AddressState
        {
            get { return _addresState; }
            set { _addresState = value; }
        }

        /// <summary>
        /// Gets or sets the PostalCode
        /// </summary>

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        /// <summary>
        /// Gets or sets the province
        /// </summary>

        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        /// <summary>
        /// Gets or sets the address line 2
        /// </summary>

        public string AddressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; }
        }

        /// <summary>
        /// Gets or sets the address line 1
        /// </summary>

        public string AddressLine1
        {
            get { return _addressLine1; }
            set { _addressLine1 = value; }
        }

        /// <summary>
        /// Gets or sets City
        /// </summary>

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        /// <summary>
        /// Gets or sets the suburb
        /// </summary>

        public string Suburb
        {
            get { return _suburb; }
            set { _suburb = value; }
        }


        public int AddressTypeId
        {
            get { return _addressTypeId; }
            set { _addressTypeId = value; }
        }



        public virtual AddressType AddressType
        {
            get { return _addressType; }
            set { _addressType = value; }
        }

    }
}