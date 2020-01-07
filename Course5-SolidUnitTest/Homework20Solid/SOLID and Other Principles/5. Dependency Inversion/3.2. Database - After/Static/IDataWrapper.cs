using System.Collections.Generic;

namespace DependencyInversionDatabaseStaticAfter
{
    public interface IDataWrapper
    {
        IEnumerable<int> CourseIds();

        IEnumerable<string> CourseNames();

        IEnumerable<string> Search(string substring);

        string GetCourseById(int id);
    }
}
