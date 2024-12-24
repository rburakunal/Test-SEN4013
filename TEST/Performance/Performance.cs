using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using BookClass;

namespace LibraryManagementSystem.PerformanceTests
{
    public class PerformanceTests
    {
        private Library _library;

        // Setup method called before every benchmark
        [GlobalSetup]
        public void Setup()
        {
            _library = new Library();
        }

        [Benchmark]
        public void AddBooks_PerformanceTest()
        {
            // Adding 1000 books to the library
            for (int i = 0; i < 1000; i++)
            {
                string title = $"Book {i}";
                string author = $"Author {i}";
                int totalCopies = 10;
                _library.AddBook(title, author, totalCopies);
            }
        }

        [Benchmark]
        public void SearchBooks_PerformanceTest()
        {
            // Adding 1000 books first
            AddBooks_PerformanceTest();

            // Searching for a book
            _library.SearchBooks("Book 100");
        }

        [Benchmark]
        public void BorrowAndReturnBooks_PerformanceTest()
        {
            // Adding 100 books first
            AddBooks_PerformanceTest();

            // Borrow and return 100 books in succession
            for (int i = 0; i < 100; i++)
            {
                int memberId = i;
                int bookId = _library.Books[i % 1000].Id;
                _library.BorrowBook(memberId, bookId);
                _library.ReturnBook(memberId, bookId);
            }
        }

        // Running the benchmarks
        public static void RunBenchmark()
        {
            var summary = BenchmarkRunner.Run<PerformanceTests>();
        }
    }
}
