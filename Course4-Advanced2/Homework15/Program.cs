using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Homework15
{
    class Program
    {
        private static int FilesToProcess = 10;

        static void Main(string[] args)
        {
            /**
             * Having the 10 files at some location (containing words), read the data using tasks and use TPL in order to:
                count of all words
                count of distinct words
                search for a specific words (contains)

                group words per categories
                    xs (0-5 chars)
                    s (5-10 chars)
                    m (10-15 chars)
                    l (larger than 15)

                you have files here: https://github.com/andreiscutariu002/wantsome-dotnet-public/tree/master/advanced.day.02.threading.home/data
                you can generate own files also using https://github.com/andreiscutariu002/wantsome-dotnet-public/tree/master/advanced.day.02.threading.home/sln/WordGenerator (just run the console)
            */
            string searchedWord = "oqerelo";

            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // Bag to put the words
            ConcurrentBag<string> bag = new ConcurrentBag<string>();
            
            Parallel.For(0, FilesToProcess, (index, state) =>
            {
                List<string> words = new List<string>();

                var fileLines = File.ReadAllLines($"{dir}\\data\\file.{index}.dat");
                foreach (string line in fileLines)
                {
                    List<string> wordss = new List<string>( line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) );
                    foreach (string w in wordss)
                    {
                        bag.Add(w);
                    }
                }
            });


            ConcurrentDictionary<string, List<string>> wordCategDictionary = new ConcurrentDictionary<string, List<string>>();
            
            var parent = Task.Factory.StartNew(() =>
            {
                var childFactory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);

                // xs
                childFactory.StartNew(() =>
                {
                    var xs = from item in bag
                             where item.Length > 0 & item.Length < 5
                             select item;
                    wordCategDictionary.TryAdd("xs", xs.ToList());
                });

                // s
                childFactory.StartNew(() =>
                {
                    var s = from item in bag
                            where item.Length > 5 & item.Length < 10
                            select item;
                    wordCategDictionary.TryAdd("s", s.ToList());
                });

                // m
                childFactory.StartNew(() =>
                {
                    var m = from item in bag
                            where item.Length > 10 & item.Length < 15
                            select item;
                    wordCategDictionary.TryAdd("m", m.ToList());
                });

                // l
                childFactory.StartNew(() =>
                {
                    var l = from item in bag
                            where item.Length > 15
                            select item;
                    wordCategDictionary.TryAdd("l", l.ToList());
                });

                // searched item
                childFactory.StartNew(() =>
                {
                    var searchedObj = from item in bag
                            where item == searchedWord
                            group item by item into g
                            select new
                            {
                                item = g.Key,
                                count = g.Count(),
                            };
                    
                    //Console.WriteLine($"Word {searchedObj.item} is found {searchedObj.count} times");

                });
            });

            try
            {
                parent.Wait();
            }
            catch (AggregateException aex)
            {
                aex.Flatten().Handle(ex => 
                {
                    Console.WriteLine(ex.Message);
                    return false; // All exceptions are 'handled'
                });
            }

            Console.WriteLine($"Total words: {bag.Count}");

            HashSet<string> distinctWords = new HashSet<string>(bag);
            Console.WriteLine($"Total distinct words: {distinctWords.Count}");

            foreach (KeyValuePair<string, List<string>> item in wordCategDictionary)
            {
                Console.WriteLine($"Total words [{item.Key}]: {item.Value.Count}");
            }

        }

    }
}
