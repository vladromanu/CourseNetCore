using System.Collections.Generic;

namespace DependencyInversionDatabaseStaticAfter
{ 
    class DataWrapper : IDataWrapper
    {
        public IEnumerable<int> CourseIds()
        {
            return Data.CourseIds();
        }

        public IEnumerable<string> CourseNames()
        {
            return Data.CourseNames();
        }

        public string GetCourseById(int id)
        {
            return Data.GetCourseById(id);
        }

        public IEnumerable<string> Search(string substring)
        {
            return Data.Search(substring);
        }
    }
}
