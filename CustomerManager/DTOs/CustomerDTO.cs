namespace CustomerManager.DTOs
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class CustomerDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public IList<EmailAddressDTO> EmailAddresses { get; set; }
    }
}
