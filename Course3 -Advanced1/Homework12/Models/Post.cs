namespace Homework12.Models
{
    public class Post
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public override string ToString()
        {
            return new string($"Post[{this.Id}] by {this.UserId} -- title: {this.Title} --- body: {this.Body}");
        }
    }
}
