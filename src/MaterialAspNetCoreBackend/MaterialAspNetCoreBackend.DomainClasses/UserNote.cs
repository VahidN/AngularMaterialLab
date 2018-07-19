using System;

namespace MaterialAspNetCoreBackend.DomainClasses
{
    public class UserNote
    {
        public int Id { set; get; }
        public DateTimeOffset Date { set; get; }
        public string Title { set; get; }

        public User User { set; get; }
        public int UserId { set; get; }
    }
}
