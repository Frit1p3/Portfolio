using Portfolio.Content;

namespace Portfolio.Tests;

public sealed class FoundationTests
{
    [Fact]
    public void Landing_positioning_content_is_available()
    {
        Assert.Contains(".NET", LandingContent.Positioning, StringComparison.Ordinal);
        Assert.Contains("interfaces metier industrielles", LandingContent.Positioning, StringComparison.Ordinal);
    }

    [Fact]
    public void Gitignore_keeps_private_and_generated_files_out_of_the_repository()
    {
        var root = FindRepositoryRoot();
        var gitignore = File.ReadAllText(Path.Combine(root, ".gitignore"));

        Assert.Contains(".ia/", gitignore, StringComparison.Ordinal);
        Assert.Contains(".idea/", gitignore, StringComparison.Ordinal);
        Assert.Contains("bin/", gitignore, StringComparison.Ordinal);
        Assert.Contains("obj/", gitignore, StringComparison.Ordinal);
    }

    [Fact]
    public void Css_entrypoint_imports_foundation_layers()
    {
        var root = FindRepositoryRoot();
        var appCss = File.ReadAllText(Path.Combine(root, "wwwroot", "css", "app.css"));

        Assert.Contains("tokens/colors.css", appCss, StringComparison.Ordinal);
        Assert.Contains("base/reset.css", appCss, StringComparison.Ordinal);
        Assert.Contains("layout/shell.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/button.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/source-compact-card.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/decision-timeline-card.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/product-demo-panel.css", appCss, StringComparison.Ordinal);
        Assert.Contains("pages/home.css", appCss, StringComparison.Ordinal);
    }

    private static string FindRepositoryRoot()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        while (directory is not null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "Portfolio.csproj")))
            {
                return directory.FullName;
            }

            directory = directory.Parent;
        }

        throw new DirectoryNotFoundException("Unable to locate the Portfolio project root.");
    }
}
