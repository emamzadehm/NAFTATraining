using _01.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Models
{
    public class Site_EvaluationResult : DomainBase
    {
        public string Title { get; private set; }
        public int Percentage { get; private set; }
        protected Site_EvaluationResult()
        {

        }

        public Site_EvaluationResult(string title, int percentage)
        {
            Title = title;
            Percentage = percentage;
        }
        public void Edit(string title, int percentage)
        {
            Title = title;
            Percentage = percentage;
        }
    }

}
