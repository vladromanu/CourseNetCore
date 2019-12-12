# 1. Integer with the largest number of divisors.

    Write a program that uses multiple threads to find the integer in the range 1 to 100 000 that has the largest number of divisors.
    By using threads, your program will should take less time to do the computation when it is run on a multiprocessor computer.
    At the end of the program, output the elapsed time, the integer that has the largest number of divisors, and the number of divisors that it has.

# 2. Having the 10 files at some location (containing words), read the data using tasks and use TPL in order to:

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

# 3. Fix the UI Windows App

    The app has 2 text boxes, 2 btn and 2 text areas. If enter an URL in a textbox and press ok, in the text area the result is displayed.

    App is freezing now, if you should fix that. In the implementation have a look also on exception handling.

    Provide 2 implementations
        using BackgroundWorker
        using async/await

    the app is here: https://github.com/andreiscutariu002/wantsome-dotnet-public/tree/master/advanced.day.02.threading.home/sln/UiFormApp

# 4. File processor

    Implement a console app that process files from a specific location. Each file should be processed. After 10 files is processed, the content is displayed to console and the program exit.

    Use publisher/consumer pattern.

    Notes:
        an worker wait for files. each file is dispached to a consumer.
        at the same time, cannot be processed more than 4 files.
        when a consumer process files, read the file and add the content to shared data structure.
        after 10 files are processed, each file name + content is displayed.

    Have a look on:
        exception handling
        what is happening with the work in progress stuff when app exit12 - Homework

