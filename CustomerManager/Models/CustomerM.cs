namespace CustomerManager.Models
{
    using System;

    [Serializable]
    public class CustomerM
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
