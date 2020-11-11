using _01.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Models
{
    public class Site_FunFact : DomainBase
    {
        public string Title { get; private set; }
        public int ValueNumber { get; private set; }
        protected Site_FunFact()
        {

        }

        public Site_FunFact(string title, int valueNumber)
        {
            Title = title;
            ValueNumber = valueNumber;
        }
        public void Edit(string title, int valueNumber)
        {
            Title = title;
            ValueNumber = valueNumber;
        }
    }
}
