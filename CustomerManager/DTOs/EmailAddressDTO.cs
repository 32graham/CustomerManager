namespace CustomerManager.DTOs
{
    using System;

    public class EmailAddressDTO
    {
        public Guid Id { get; set; }

        public AddressTypeDTO AddressType { get; set; }

        public string Address { get; set; }
    }
}
