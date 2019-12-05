namespace Homework12
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Program
    {
        private static void Main(string[] args)
        {
            List<User> allUsers = ReadUsers("users.json");
            List<Post> allPosts = ReadPosts("posts.json");

            Exercise1(allUsers, allPosts);
            Exercise2(allUsers, allPosts);
            Exercise3(allUsers, allPosts);
            Exercise4(allUsers, allPosts);
            Exercise5(allUsers, allPosts);
            Exercise6(allUsers, allPosts);
            Exercise7(allUsers, allPosts);
            Exercise8(allUsers, allPosts);
            Exercise9(allUsers, allPosts);
            Exercise10(allUsers, allPosts);
            Exercise11(allUsers, allPosts);
            Exercise12(allUsers, allPosts);

            Console.WriteLine("Closing the app ... ");
            Console.ReadKey();
        }

        public static string Exercise1(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise 1 
            // Find all users having email ending with ".net".

            var users1 = from user in allUsers
                         where user.Email.EndsWith(".net")
                         select user;

            var users11 = allUsers.Where(user => user.Email.EndsWith(".net"));

            IEnumerable<string> userNames = from user in allUsers
                                            select user.Name;

            var userNames2 = allUsers.Select(user => user.Name);
            foreach (var value in userNames2)
            {
                Console.WriteLine(value);
            }

            IEnumerable<Company> allCompanies = from user in allUsers
                                                select user.Company;

            var users2 = from user in allUsers
                         orderby user.Email
                         select user;

            var netUser = allUsers.First(user => user.Email.Contains(".net"));
            Console.WriteLine(netUser.Username);

            return netUser.Username;

            #endregion
        }

        public static IEnumerable<Post> Exercise2(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise 2 
            // Find all posts for users having email ending with ".net".
            IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                       where user.Email.EndsWith(".net")
                                                       select user.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;

            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " " + "user: " + post.UserId);
            }

            return posts;
            #endregion
        }

        public static Dictionary<int, int> Exercise3(List<User> allUsers, List<Post> allPosts)
        {
            // Print number of posts for each user.
            Console.WriteLine("Exercise 3: ");

            Dictionary<int, int> postsCounts = (from post in allPosts
                              group post by post.UserId into g
                              select new
                              {
                                  UserId = g.Key,
                                  count = g.Count(),
                              }).ToDictionary(k => k.UserId, v => v.count);

            foreach (var post in postsCounts)
            {
                Console.WriteLine($"User[{post.Key}] count: {post.Value}");
            }

            return postsCounts;
        }

        public static Dictionary<int, Geo> Exercise4(List<User> allUsers, List<Post> allPosts)
        {
            // Find all users that have lat and long negative.
            Console.WriteLine("\n\nExercise 4: ");

            Dictionary<int, Geo> list = (from user in allUsers
                                  where (user.Address.Geo.Lat < 0 &&
                                  user.Address.Geo.Lng < 0)
                                  select new
                                  {
                                      UserId = user.Id,
                                      Lat = user.Address.Geo.Lat,
                                      Lng = user.Address.Geo.Lng
                                  }).ToDictionary(k => k.UserId, v => new Geo()
                                  {
                                      Lat = v.Lat,
                                      Lng = v.Lng
                                  });

            foreach (var user in list)
            {
                Console.WriteLine($"User[{user.Key}] Lat: {user.Value.Lat} Lng: {user.Value.Lng}");
            }

            return list;
        }

        public static (int id, int count) Exercise5(List<User> allUsers, List<Post> allPosts)
        {
            // Find the post with longest body.
            Console.WriteLine("\n\nExercise 5: ");
            var longesPost = (from post in allPosts
                              orderby post.Body.Length
                              select new
                              {
                                  PostId = post.Id,
                                  Body = post.Body,
                                  Count = post.Body.Length
                              }).FirstOrDefault();

            Console.WriteLine($"longesPost ID[{longesPost.PostId}] Count: {longesPost.Count} Body: {longesPost.Body}");

            return (longesPost.PostId, longesPost.Body.Length);
        }

        public static string Exercise6(List<User> allUsers, List<Post> allPosts)
        {
            // Print the name of the employee that have post with longest body.
            Console.WriteLine("\n\nExercise 6: ");
            var nameWithLongestPost = (from post in allPosts
                                       join user in allUsers on post.UserId equals user.Id
                                       orderby post.Body.Length
                                       select user.Name).FirstOrDefault();

            Console.WriteLine($"longesPost User name {nameWithLongestPost}");

            return nameWithLongestPost;
        }

        public static List<Address> Exercise7(List<User> allUsers, List<Post> allPosts)
        {
            // Select all addresses in a new List<Address>. print the list.
            Console.WriteLine("\n\nExercise 7: ");
            var addressList = (from user in allUsers
                                    select user.Address).ToList();

            addressList.ForEach(address => Console.WriteLine($"{address}"));

            return addressList;
        }

        //  var eventids = GetEventIdsByEventDate(DateTime.Now);
        //var result = eventsdb.Where(e => eventids.Contains(e));

        public static (string name, double lat) Exercise8(List<User> allUsers, List<Post> allPosts)
        {
            // Print the user with min lat
            Console.WriteLine("\n\nExercise 8: ");
            var result = (from user in allUsers
                                       orderby user.Address.Geo.Lat
                                  select new{
                                      Name = user.Name,
                                      Lat= user.Address.Geo.Lng
                                  }).FirstOrDefault();

            Console.WriteLine($"longesPost User with min lat {result.Name} [{result.Lat}]");

            return (result.Name, result.Lat);
        }

        public static (string name, double lng) Exercise9(List<User> allUsers, List<Post> allPosts)
        {
            // Print the user with max long
            Console.WriteLine("\n\nExercise 9: ");
            var result = (from user in allUsers
                                  orderby user.Address.Geo.Lng descending
                                   select new
                                   {
                                      Name = user.Name,
                                      Lng = user.Address.Geo.Lng
                                   }).FirstOrDefault();

            Console.WriteLine($"longesPost User with max long {result.Name} [{result.Lng}]");

            return (result.Name, result.Lng);
        }

        public static List<UserPosts> Exercise10(List<User> allUsers, List<Post> allPosts)
        {
            //    - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only
            
            List<UserPosts> userPosts = (from user in allUsers
                       join post in allPosts on user.Id equals post.UserId
                       group post by user into gr
                       select new UserPosts()
                       {
                           User = gr.Key,
                           Posts = gr.ToList()
                       }).ToList();
            
            userPosts.ForEach(up =>
            {
                Console.WriteLine($"{up.User}");
                up.Posts.ForEach(post => Console.WriteLine($"{post}"));
                Console.WriteLine("\n\n");
            });

            return userPosts;
        }

        public static List<User> Exercise11(List<User> allUsers, List<Post> allPosts)
        {
            // Order users by zip code
            Console.WriteLine("\n\nExercise 11: ");
            List<User> usersByZipCode = (from user in allUsers
                                 orderby user.Address.Zipcode
                                 select user).ToList();

            foreach (User user in usersByZipCode)
            {
                Console.WriteLine($"User ID[{user.Id}] ZipCode: {user.Address.Zipcode}");
            }

            return usersByZipCode;
        }

        public static Dictionary<int, int> Exercise12(List<User> allUsers, List<Post> allPosts)
        {
            // Order users by number of posts
            Console.WriteLine("\n\nExercise 12: ");
            Dictionary<int, int> usersByPostCounts = (from user in allUsers
                                 join post in allPosts on user.Id equals post.UserId
                                 group post by user.Id into gr
                                 orderby gr.Count() descending
                                 select new { id = gr.Key, count = gr.Count() }).ToDictionary(k => k.id, v => v.count);

            foreach (var user in usersByPostCounts)
            {
                Console.WriteLine($"User ID[{user.Key}] PostCount: {user.Value}");
            }

            return usersByPostCounts;
        }



        public static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        public static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }
}
