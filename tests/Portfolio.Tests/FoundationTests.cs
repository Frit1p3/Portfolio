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
    public void Landing_concept_hero_content_is_available()
    {
        Assert.Contains("Interfaces metier industrielles", LandingContent.HeroTitle, StringComparison.Ordinal);
        Assert.Equal(4, LandingContent.ConceptSources.Count);
        Assert.Equal(3, LandingContent.ConceptStack.Count);
        Assert.Equal(4, LandingContent.ConceptSteps.Count);
        Assert.Equal(4, LandingContent.ConceptDemos.Count);
        Assert.Equal(3, LandingContent.HeroKpis.Count);
        Assert.Contains(LandingContent.ConceptSteps, step => step.IsActive);
        Assert.Equal(6, LandingContent.LandingMotionStates.Count);
        Assert.Contains(LandingContent.LandingMotionStates, state => state.IsActive);
        Assert.Contains("complexite metier", LandingContent.MethodTitle, StringComparison.Ordinal);
        Assert.Equal(3, LandingContent.MethodSteps.Count);
        Assert.Contains("decisions terrain", LandingContent.ProjectsTitle, StringComparison.Ordinal);
        Assert.Equal(3, LandingContent.ProjectUseCases.Count);
    }

    [Fact]
    public void Landing_product_demo_content_is_available()
    {
        Assert.Contains("Cartographie", LandingContent.ProductDemoTitle, StringComparison.Ordinal);
        Assert.Equal(3, LandingContent.ProductSources.Count);
        Assert.Equal(3, LandingContent.ProductDecisionMetrics.Count);
        Assert.Contains(LandingContent.ProductSources, source => source.Label == "ERP");
        Assert.Contains(LandingContent.ProductDecisionMetrics, metric => metric.Meta == "OEE atelier");
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
        Assert.Contains("components/hero-kpi-card.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/concept-source-chip.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/concept-tab.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/concept-demo-card.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/product-demo-panel.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/concept-hero-section.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/landing-motion-sequence.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/landing-method-section.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/landing-projects-section.css", appCss, StringComparison.Ordinal);
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
