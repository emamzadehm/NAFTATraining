using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Framework.Domain
{
    public class DomainBase
    {
        public long ID { get; protected set; }
        public bool Status { get; protected set; }
        public DateTime CreationDate { get; private set; }
        
        protected DomainBase()
        {
            Status = true;
            CreationDate = DateTime.Now;
        }

        public void Remove()
        {
            Status = false;
        }

    }
}
