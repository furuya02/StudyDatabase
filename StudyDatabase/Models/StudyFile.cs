using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyDatabase.Models {
    public class StudyFile {
        public int Id { get; set; }
        public String Filename { get; set; }
        public DateTime UpdateAt { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
    }
}