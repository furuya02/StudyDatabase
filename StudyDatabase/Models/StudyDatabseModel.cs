using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyDatabase.Models {
    public class StudyDatabseModel {
        StudyDatabaseContext _db = new StudyDatabaseContext();
        public IList<StudyFile> GetStudyFileList(){
            return _db.StudyFiles.ToList();
        }
    }
}