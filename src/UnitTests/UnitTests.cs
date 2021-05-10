using System;
using System.Collections.Generic;
using IoReader.Mediators;
using IoReader.ViewModels;
using IoReader.ViewModels.ContentViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        public class NavigateExpectedResult
        {
            public IContentViewModel ContentViewModel { get; set; }
            public BookViewModel BookViewModel { get; set; }
            public IContentViewModel LastContentViewModel { get; set; }
        }

        private static object[] NavigateFromAnyToBookTestData(WindowContentViewModel windowContentViewModel)
        { 
            BookViewModel targetBookViewModel = windowContentViewModel.BookVm;

            return new object[]
            {
                windowContentViewModel, windowContentViewModel.ContentVm, targetBookViewModel,
                new NavigateExpectedResult()
                {
                    ContentViewModel = targetBookViewModel,
                    BookViewModel = targetBookViewModel,
                    LastContentViewModel = windowContentViewModel.ContentVm
                }
            };
        }

        private static object[] NavigateFromBookToBookTestData(WindowContentViewModel windowContentViewModel)
        {
            BookViewModel targetBookViewModel = windowContentViewModel.BookVm;

            return new object[]
            {
                windowContentViewModel, windowContentViewModel.ContentVm, targetBookViewModel,
                new NavigateExpectedResult()
                {
                    ContentViewModel = targetBookViewModel,
                    BookViewModel = targetBookViewModel,
                    LastContentViewModel = windowContentViewModel.LastContentViewModel
                }
            };
        }

        private static object[] NavigateFromBookToAnyTestData(WindowContentViewModel windowContentViewModel)
        {
            IContentViewModel targetContentViewModel = windowContentViewModel.LibraryVm;

            return new object[]
            {
                windowContentViewModel, windowContentViewModel.ContentVm, targetContentViewModel,
                new NavigateExpectedResult()
                {
                    ContentViewModel = targetContentViewModel,
                    BookViewModel = windowContentViewModel.BookVm,
                    LastContentViewModel = windowContentViewModel.LastContentViewModel
                }
            };

        }

        private static object[] NavigateFromAnyToAnyTestData(WindowContentViewModel windowContentViewModel)
        {
            IContentViewModel targetContentViewModel = windowContentViewModel.BookInfoVm;

            return new object[]
            {
                windowContentViewModel, windowContentViewModel.ContentVm, targetContentViewModel,
                new NavigateExpectedResult()
                {
                    ContentViewModel = targetContentViewModel,
                    BookViewModel = windowContentViewModel.BookVm,
                    LastContentViewModel = windowContentViewModel.ContentVm
                }
            };
        }

        public static IEnumerable<object[]> NavigateFromBookToAnySequenceTestData(
            WindowContentViewModel windowContentViewModel)
        { 
            yield return NavigateFromBookToBookTestData(windowContentViewModel);
            yield return NavigateFromBookToAnyTestData(windowContentViewModel);
            yield return NavigateFromAnyToAnyTestData(windowContentViewModel);
        }

        public static IEnumerable<object[]> NavigateToTestData
        {
            get
            {
                IContentMediator contentMediator = new ContentMediator();
                var windowContentViewModel = new WindowContentViewModel(contentMediator);

                if (windowContentViewModel.ContentVm is BookViewModel)
                {
                    foreach (var data in NavigateFromBookToAnySequenceTestData(windowContentViewModel))
                        yield return data;
                    yield return NavigateFromAnyToBookTestData(windowContentViewModel);
                }
                else
                {
                    yield return NavigateFromAnyToBookTestData(windowContentViewModel);
                    foreach (var data in NavigateFromBookToAnySequenceTestData(windowContentViewModel))
                        yield return data;
                }
            }
        }

        [TestMethod]
        [DynamicData("NavigateToTestData", DynamicDataSourceType.Property)]
        public void TestNavigation(
            WindowContentViewModel windowContentViewModel,
            IHasContentMediator hasMediator,
            IContentViewModel navigationTargetContentViewModel, 
            NavigateExpectedResult navigateExpectedResult
            )
        {
            // Arrange

            // Act
            hasMediator.Mediator.Navigate(navigationTargetContentViewModel);

            // Assert
            Assert.AreSame(windowContentViewModel.ContentVm, navigateExpectedResult.ContentViewModel);
            Assert.AreSame(windowContentViewModel.BookVm, navigateExpectedResult.BookViewModel);
            Assert.AreSame(windowContentViewModel.LastContentViewModel, navigateExpectedResult.LastContentViewModel);
        }
    }
}
