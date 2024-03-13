using System;
using Microsoft.Maui.Controls;
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
    private void OnCleanButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(inputArea.Text))
        {
            // Optionally, show a message indicating the input area is empty
            return;
        }

        string cleanedCode = inputArea.Text;

        // Example: Cleaning comments based on a checkbox being checked
        if (cleanCommentsToggle.IsChecked)
        {
            cleanedCode = CleanComments(cleanedCode);
        }
        if (cleanImportsToggle.IsChecked)
        {
            cleanedCode = CleanImports(cleanedCode);
        }

        outputArea.Text = cleanedCode;
        clearButton.IsVisible = !string.IsNullOrWhiteSpace(outputArea.Text);
    }

    private void OnClearButtonClicked(object sender, EventArgs e)
    {
        outputArea.Text = string.Empty;
        clearButton.IsVisible = false;
        // UpdateCharacterCount();
    }
    private void OutputArea_TextChanged(object sender, TextChangedEventArgs e)
    {
        // Show clearButton only if outputArea has text
        clearButton.IsVisible = !string.IsNullOrWhiteSpace(outputArea.Text);
    }

    private string CleanComments(string code)
    {
        // Remove single-line comments for languages like C++, Java, C#, JavaScript, etc.
        code = Regex.Replace(code, @"^\s*//.*\n?", "", RegexOptions.Multiline);

        // Remove multi-line comments for languages like C++, Java, C#, etc.
        code = Regex.Replace(code, @"/\*[\s\S]*?\*/\s*\n?", "");

        // Remove single-line comments for languages like Python, Ruby, etc.
        code = Regex.Replace(code, @"^\s*#.*\n?", "", RegexOptions.Multiline);

        // Remove multi-line comments for Python (triple quotes)
        code = Regex.Replace(code, @"'''[\s\S]*?'''\s*\n?", "");
        code = Regex.Replace(code, @"""""[\s\S]*?""""\s*\n?", "");

        // Remove HTML comments
        code = Regex.Replace(code, @"<!--[\s\S]*?-->\s*\n?", "");

        // Extra removal for inline comments in languages like Python and Ruby (without removing the entire line)
        code = Regex.Replace(code, @"\s*#.*$", "", RegexOptions.Multiline);

        return code;
    }

    private string CleanImports(string code)
    {
        // For JavaScript imports
        code = Regex.Replace(code, @"^import .*;\s+", "", RegexOptions.Multiline);

        // For Python imports
        code = Regex.Replace(code, @"^import .*\s+", "", RegexOptions.Multiline);

        // For Python 'from' imports
        code = Regex.Replace(code, @"^from .* import .*\s+", "", RegexOptions.Multiline);

        return code;
    }

}