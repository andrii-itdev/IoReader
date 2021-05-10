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
        #region EnclosedClasses

        /// <summary>
        /// This class represents bundled expected results for navigation tests
        /// </summary>
        public class NavigateExpectedResult
        {
            public IContentViewModel ContentViewModel { get; set; }
            public BookViewModel BookViewModel { get; set; }
            public IContentViewModel LastContentViewModel { get; set; }
        }

        #endregion

        #region AuxiliaryMethods

        private static void NavigationMakeAssertion(WindowContentViewModel windowContentViewModel,
            NavigateExpectedResult navigateExpectedResult)
        {
            Assert.AreSame(windowContentViewModel.ContentVm, navigateExpectedResult.ContentViewModel);
            Assert.AreSame(windowContentViewModel.BookVm, navigateExpectedResult.BookViewModel);
            Assert.AreSame(windowContentViewModel.LastContentViewModel, navigateExpectedResult.LastContentViewModel);
        }

        #endregion

        #region TestNavigate

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
                    LastContentViewModel = windowContentViewModel.ContentVm
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
                    LastContentViewModel = windowContentViewModel.LastContentViewModel
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
            NavigationMakeAssertion(windowContentViewModel, navigateExpectedResult);
        }

        #endregion

        #region TestNavigateLast

        private static object[] NavigateToLastTestData(
            WindowContentViewModel windowContentViewModel, 
            IEnumerable<IContentViewModel> navigationSequence,
            IContentViewModel expectedLastContentViewModel)
        {
            IContentViewModel lastContentViewModel = null;
            foreach (IContentViewModel contentViewModel in navigationSequence)
            {
                windowContentViewModel.Mediator.Navigate(contentViewModel);
                lastContentViewModel = contentViewModel;
            }

            return new object[]
            {
                windowContentViewModel, windowContentViewModel.ContentVm,
                new NavigateExpectedResult()
                {
                    ContentViewModel = expectedLastContentViewModel, 
                    BookViewModel = windowContentViewModel.BookVm,
                    LastContentViewModel = lastContentViewModel
                    // After NavigateLast expectedLastContentViewModel and lastContentViewModel will be swapped
                }
            };
        }

        public static IEnumerable<object[]> NavigateToLastContentViewModelTestData
        {
            get
            {
                IContentMediator contentMediator = new ContentMediator();
                var windowContentViewModel = new WindowContentViewModel(contentMediator);

                yield return NavigateToLastTestData(windowContentViewModel, 
                    new IContentViewModel[] { windowContentViewModel.BookVm, windowContentViewModel.LibraryVm, windowContentViewModel.LibraryVm },
                    windowContentViewModel.BookVm);

                yield return NavigateToLastTestData(windowContentViewModel,
                    new IContentViewModel[] { windowContentViewModel.BookVm, windowContentViewModel.LibraryVm, windowContentViewModel.BookVm },
                    windowContentViewModel.LibraryVm);

                yield return NavigateToLastTestData(windowContentViewModel,
                    new IContentViewModel[] { windowContentViewModel.BookVm, windowContentViewModel.BookVm, windowContentViewModel.LibraryVm },
                    windowContentViewModel.BookVm);

                yield return NavigateToLastTestData(windowContentViewModel,
                    new IContentViewModel[] { windowContentViewModel.LibraryVm, windowContentViewModel.LibraryVm, windowContentViewModel.BookVm },
                    windowContentViewModel.LibraryVm);

                yield return NavigateToLastTestData(windowContentViewModel,
                    new IContentViewModel[] { windowContentViewModel.LibraryVm, windowContentViewModel.BookVm, windowContentViewModel.LibraryVm },
                    windowContentViewModel.BookVm);

                yield return NavigateToLastTestData(windowContentViewModel,
                    new IContentViewModel[] { windowContentViewModel.LibraryVm, windowContentViewModel.BookVm, windowContentViewModel.BookVm },
                    windowContentViewModel.LibraryVm);
            }
        }

        [TestMethod]
        [DynamicData("NavigateToLastContentViewModelTestData", DynamicDataSourceType.Property)]
        public void TestNavigationToLastContentViewModel(
            WindowContentViewModel windowContentViewModel,
            IHasContentMediator hasMediator,
            NavigateExpectedResult navigateExpectedResult
        )
        {
            // Arrange

            // Act
            hasMediator.Mediator.NavigateLast();

            // Assert
            NavigationMakeAssertion(windowContentViewModel, navigateExpectedResult);
        }

        #endregion

        #region TestNavigateBook

        private static object[] NavigateToBookTestData(
            WindowContentViewModel windowContentViewModel,
            IEnumerable<IContentViewModel> navigationSequence,
            IContentViewModel lastContentViewModel)
        {
            foreach (IContentViewModel contentViewModel in navigationSequence)
            {
                windowContentViewModel.Mediator.Navigate(contentViewModel);
            }

            return new object[]
            {
                windowContentViewModel, windowContentViewModel.ContentVm,
                new NavigateExpectedResult()
                {
                    ContentViewModel = windowContentViewModel.BookVm,
                    BookViewModel = windowContentViewModel.BookVm,
                    LastContentViewModel = lastContentViewModel
                }
            };
        }

        public static IEnumerable<object[]> NavigateToBookContentViewModelTestData
        {
            get
            {
                IContentMediator contentMediator = new ContentMediator();
                var windowContentViewModel = new WindowContentViewModel(contentMediator);

                yield return NavigateToBookTestData(windowContentViewModel,
                    new IContentViewModel[] { windowContentViewModel.BookInfoVm, windowContentViewModel.LibraryVm },
                    windowContentViewModel.LibraryVm);

                yield return NavigateToBookTestData(windowContentViewModel,
                    new IContentViewModel[] { windowContentViewModel.BookInfoVm, windowContentViewModel.BookVm },
                    windowContentViewModel.BookInfoVm);

                yield return NavigateToBookTestData(windowContentViewModel,
                    new IContentViewModel[] { windowContentViewModel.LibraryVm, windowContentViewModel.BookInfoVm },
                    windowContentViewModel.BookInfoVm);

                yield return NavigateToBookTestData(windowContentViewModel,
                    new IContentViewModel[] { windowContentViewModel.LibraryVm, windowContentViewModel.BookVm },
                    windowContentViewModel.LibraryVm);

                yield return NavigateToBookTestData(windowContentViewModel,
                    new IContentViewModel[] { windowContentViewModel.BookVm, windowContentViewModel.LibraryVm },
                    windowContentViewModel.LibraryVm);

                yield return NavigateToBookTestData(windowContentViewModel,
                    new IContentViewModel[] { windowContentViewModel.BookVm, windowContentViewModel.BookInfoVm },
                    windowContentViewModel.BookInfoVm);
            }
        }

        [TestMethod]
        [DynamicData("NavigateToBookContentViewModelTestData", DynamicDataSourceType.Property)]
        public void TestNavigationToBookContentViewModel(
            WindowContentViewModel windowContentViewModel,
            IHasContentMediator hasMediator,
            NavigateExpectedResult navigateExpectedResult
        )
        {
            // Arrange

            // Act
            hasMediator.Mediator.NavigateBook();

            // Assert
            NavigationMakeAssertion(windowContentViewModel, navigateExpectedResult);
        }

        #endregion
    }
}
