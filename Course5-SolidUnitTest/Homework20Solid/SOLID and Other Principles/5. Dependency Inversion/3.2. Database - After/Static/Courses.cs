namespace DependencyInversionDatabaseStaticAfter
{
    public class Courses
    {
        private readonly IDataWrapper DataWrapper;

        // static classes cannot implement interfaces, so any class using it will always depend on whatever implementation exists at the time. Static classes therefore violate this principle
        // this is why we need to create a wrapper for it

        public Courses(IDataWrapper dataWrapper)
        {
            this.DataWrapper = dataWrapper;
        }

        public void PrintAll()
        {
            var courses = this.DataWrapper.CourseNames();
            // print courses
        }

        public void PrintIds()
        {
            var courses = this.DataWrapper.CourseIds();
            // print courses
        }

        public void PrintById(int id)
        {
            var courses = this.DataWrapper.GetCourseById(id);
            // print courses
        }

        public void Search(string substring)
        {
            var courses = this.DataWrapper.Search(substring);
            // print courses
        }
    }
}
