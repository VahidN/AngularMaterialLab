using System;
using System.Collections.Generic;

namespace MaterialAspNetCoreBackend.DomainClasses
{
    public class User
    {
        public User()
        {
            UserNotes = new HashSet<UserNote>();
        }

        public int Id { set; get; }
        public DateTimeOffset BirthDate { set; get; }
        public string Name { set; get; }
        public string Avatar { set; get; }
        public string Bio { set; get; }

        public ICollection<UserNote> UserNotes { set; get; }
    }
}
