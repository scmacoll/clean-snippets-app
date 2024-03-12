using System.Text.RegularExpressions;

namespace clean_snippets_app;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    //
    // // Call this method from your "Clean" button's Clicked event in XAML.
    // private void OnCleanButtonClicked(object sender, EventArgs e)
    // {
    //     var cleanedCode = CleanCode(inputArea.Text);
    //     outputArea.Text = cleanedCode;
    // }
    //
    // // Call this method from your "Clear" button's Clicked event in XAML.
    // private void OnClearButtonClicked(object sender, EventArgs e)
    // {
    //     inputArea.Text = string.Empty;
    //     outputArea.Text = string.Empty;
    //     // Reset checkboxes if needed
    // }
    //
    // private string CleanCode(string code)
    // {
    //     code = CleanSVGs(code);
    //     code = CleanComments(code);
    //     // Continue with other cleaning functions...
    //     return code;
    // }
    //
    // private string CleanSVGs(string code)
    // {
    //     // Assuming you have a CheckBox named cleanSvgToggle in your XAML
    //     if (cleanSvgToggle.IsChecked)
    //     {
    //         code = Regex.Replace(code, @"<svg[\s\S]*?<\/svg>", "<svg></svg>");
    //     }
    //     return code;
    // }
    //
    // private string CleanComments(string code)
    // {
    //     // Assuming you have a CheckBox named cleanCommentsToggle in your XAML
    //     if (cleanCommentsToggle.IsChecked)
    //     {
    //         // Adapt the regex patterns from your JavaScript functions to C#
    //         code = Regex.Replace(code, @"^\s*\/\/.*\n?", "", RegexOptions.Multiline)
    //             .Replace("/\\*[\\s\\S]*?\\*/\\s*\\n?", "") // Multi-line comments
    //             .Replace("^\\s*#.*\\n?", "") // Single-line hash comments
    //             .Replace("/'''[\\s\\S]*?'''\\s*\\n?", "") // Multi-line quotes in Python
    //             .Replace("/\"\"\"[\\s\\S]*?\"\"\"\\s*\\n?", ""); // Multi-line double quotes in Python
    //     }
    //     return code;
    // }

    // Implement other cleaning functions similar to CleanSVGs and CleanComments
}