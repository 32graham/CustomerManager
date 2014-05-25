namespace CustomerManager.Models
{
    using System;

    public class EmailAddressM
    {
        public Guid Id { get; set; }

        public AddressTypeM AddressType { get; set; }

        public string Address { get; set; }
    }
}
