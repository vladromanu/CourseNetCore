using Homework12;
using Homework12.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkTests
{
    [TestClass]
    public class Homework12Tests
    {
        private readonly List<User> allUsers;
        private readonly List<Post> allPosts;

        public Homework12Tests()
        {
            this.allUsers = Program.ReadUsers("users.json");
            this.allPosts = Program.ReadPosts("posts.json");
        }

        [TestMethod]
        public void TestExercise3()
        {
            Dictionary<int, int> dict = Program.Exercise3(this.allUsers, this.allPosts);
            foreach (KeyValuePair<int, int> item in dict)
            {
                Assert.IsTrue(item.Value > 0);
            }
        }

        [TestMethod]
        public void TestExercise4()
        {
            Dictionary<int, Geo> dict = Program.Exercise4(this.allUsers, this.allPosts);
            foreach (KeyValuePair<int, Geo> item in dict)
            {
                Assert.IsTrue(item.Value.Lat < 0);
                Assert.IsTrue(item.Value.Lng < 0);

                Assert.IsTrue(item.Key > 0);
            }
        }

        [TestMethod]
        public void TestExercise5()
        {
            (int postId, int count) = Program.Exercise5(this.allUsers, this.allPosts);

            Assert.AreEqual(76, postId);
            Assert.AreEqual(102, count);
        }
       
        [TestMethod]
        public void TestExercise6()
        {
            Assert.AreEqual("Nicholas Runolfsdottir V", Program.Exercise6(this.allUsers, this.allPosts));
        }

        [TestMethod]
        public void TestExercise7()
        {
            List<Address> addressList = Program.Exercise7(this.allUsers, this.allPosts);
            foreach (Address address in addressList)
            {
                Assert.IsTrue(address.GetType() == typeof(Address));
            }
        }

        [TestMethod]
        public void TestExercise8()
        {
            (string name, double lat) = Program.Exercise8(this.allUsers, this.allPosts);

            Assert.AreEqual("Mrs. Dennis Schulist", name);
            Assert.AreEqual((double)71.7478, lat);
        }

        [TestMethod]
        public void TestExercise9()
        {
            (string name, double lng) = Program.Exercise9(this.allUsers, this.allPosts);

            Assert.AreEqual("Leanne Graham", name);
            Assert.AreEqual((double)81.1496, lng);
        }

        [TestMethod]
        public void TestExercise10()
        {
            List<UserPosts> list = Program.Exercise10(this.allUsers, this.allPosts);

            foreach (UserPosts up in list)
            {
                Assert.IsTrue(up.GetType() == typeof(UserPosts));
                Assert.IsTrue(up.User.GetType() == typeof(User));
                Assert.IsTrue(up.Posts.GetType() == typeof(List<Post>));
            }
        }

        [TestMethod]
        public void TestExercise11()
        {
            List<User>  list = Program.Exercise11(this.allUsers, this.allPosts);
            string currentZipCode = list.First().Address.Zipcode;

            foreach (User user in list)
            {
                Assert.IsTrue(string.Compare(currentZipCode, user.Address.Zipcode) <= 0);
                currentZipCode = user.Address.Zipcode;
            }
        }

        [TestMethod]
        public void TestExercise12()
        {
            Dictionary<int, int> dict = Program.Exercise12(this.allUsers, this.allPosts);

            int currentMaxValue = dict.First().Value;
            foreach (KeyValuePair<int, int> item in dict)
            {
                Assert.IsTrue(item.Value > 0);
                Assert.IsTrue(currentMaxValue >= item.Value);

                currentMaxValue = item.Value;
            }
        }

    }
}