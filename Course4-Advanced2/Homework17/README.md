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
        what is happening with the work in progress stuff when app exit12 - Homework https://github.com/andreiscutariu002/wantsome-dotnet-public/tree/master/advanced.day.02.threading.home/sln/UiFormApp 