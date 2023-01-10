using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace BooksManager.WPF.Tests
{
    public class MainWindowTests
    {
        [Fact]
        public void Click_on_Laden_button_should_show_books_in_grid()
        {
            var appPath= typeof(MainWindow).Assembly.Location.Replace(".dll",".exe");
            var app = FlaUI.Core.Application.Launch(appPath);

            using (var auto = new UIA3Automation())
            {
                var win = app.GetMainWindow(auto);
                var ladenBtn = win.FindFirstDescendant(x => x.ByAutomationId("b1")).AsButton();
                ladenBtn.Click();

                var grid = win.FindFirstDescendant(x => x.ByAutomationId("g1")).AsGrid();

                Assert.NotEqual(0, grid.Rows?.Length);
            }

            app.Close();
        }
    }
}