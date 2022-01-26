using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPost
{
    public class Job
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return Title + "\n" + Company + "\n" + Location + "\n" + Description;
        }
    }
}

