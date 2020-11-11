using _01.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Models
{
    public class Site_FAQ : DomainBase
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public Site_FAQ()
        {

        }

        public Site_FAQ(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }

        public void Edit(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }
}
