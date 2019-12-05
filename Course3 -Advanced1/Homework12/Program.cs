namespace Homework12
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Program
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


        private static string Exercise1(List<User> allUsers, List<Post> allPosts)
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

        private static IEnumerable<Post> Exercise2(List<User> allUsers, List<Post> allPosts)
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
        
        private static void Exercise3(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise 3 
            // Print number of posts for each user.
            Console.WriteLine("Exercise 3: ");

            List<object> list = new List<object>();
            var postsCounts = from post in allPosts
                              group post by post.UserId into g
                              select new
                              {
                                  UserId = g.Key,
                                  count = g.Count(),
                              };

            foreach (var post in postsCounts)
            {
                Console.WriteLine($"User[{post.UserId}] count: {post.count}");
            }
            #endregion
        }

        private static List<object> Exercise4(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise 4
            // Find all users that have lat and long negative.
            Console.WriteLine("\n\nExercise 4: ");

            List<object> list = new List<object>();
            var userNegLangLong = from user in allUsers
                                  where (user.Address.Geo.Lat < 0 ||
                                  user.Address.Geo.Lng < 0)
                                  select new
                                  {
                                      UserId = user.Id,
                                      Lat = user.Address.Geo.Lat,
                                      Lng = user.Address.Geo.Lng
                                  };

            foreach (var user in userNegLangLong)
            {
                list.Add(user);
                Console.WriteLine($"User[{user.UserId}] Lat: {user.Lat} Lng: {user.Lng}");
            }

            return list;
            #endregion
        }

        private static string Exercise5(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise 5 
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

            return longesPost.PostId.ToString();
            #endregion

        }

        private static string Exercise6(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise 6 
            // Print the name of the employee that have post with longest body.
            Console.WriteLine("\n\nExercise 6: ");
            var nameWithLongestPost = (from post in allPosts
                                       join user in allUsers on post.UserId equals user.Id
                                       orderby post.Body.Length
                                       select user.Name).FirstOrDefault();

            Console.WriteLine($"longesPost User name {nameWithLongestPost}");

            return nameWithLongestPost;
            #endregion
        }

        private static void Exercise7(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise 7 
            // Select all addresses in a new List<Address>. print the list.
            Console.WriteLine("\n\nExercise 7: ");
            /*List<Address> newList = from user in allUsers
                                    select new
                                    {
                                        Street = user.Address.Street,
                                        Suite = user.Address.Suite,
                                        City = user.Address.City,
                                        Zipcode = user.Address.Zipcode,
                                        Geo = new Geo()
                                        {
                                            Lat = user.Address.Geo.Lat,
                                            Lng = user.Address.Geo.Lng
                                        }
                                    };*/
            #endregion
        }

        //  var eventids = GetEventIdsByEventDate(DateTime.Now);
        //var result = eventsdb.Where(e => eventids.Contains(e));

        private static string Exercise8(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise 8 
            // Print the user with min lat
            Console.WriteLine("\n\nExercise 8: ");
            var result = (from user in allUsers
                                       orderby user.Address.Geo.Lat
                                  select new{
                                      Name = user.Name,
                                      Lat= user.Address.Geo.Lng
                                   }).FirstOrDefault();

            Console.WriteLine($"longesPost User with min lat {result.Name} [{result.Lat}]");
            
            return result.Name;
            #endregion
        }

        private static string Exercise9(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise 9 
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

            return result.Name;
            #endregion
        }

        private static void Exercise10(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise  10 
            //    - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only

            #endregion
        }

        private static void Exercise11(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise 11 
            // Order users by zip code

            #endregion
        }

        private static void Exercise12(List<User> allUsers, List<Post> allPosts)
        {
            #region Exercise 12 
            // Order users by number of posts

            #endregion
        }



        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }
}
