using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateProject.Domain
{
    public class Users
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string surname { get; set; }
        public virtual int age { get; set; }
        public virtual string phone { get; set; }
        public virtual string info { get; set; }
    }
    public class UserRating
    {
        public virtual int id { get; set; }
        public virtual int points { get; set; }
        public virtual Users userID { get; set; }
    }

}
