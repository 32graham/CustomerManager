namespace CustomerManager.Models
{
    using System;
using System.Collections.Generic;

    [Serializable]
    public class CustomerM
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public IList<EmailAddressM> EmailAddresses { get; set; }
    }
}
