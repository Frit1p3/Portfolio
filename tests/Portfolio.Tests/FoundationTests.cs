using System.Text.RegularExpressions;
using Portfolio.Content;

namespace Portfolio.Tests;

public sealed class FoundationTests
{
    [Fact]
    public void Landing_positioning_content_is_available()
    {
        Assert.Contains(".NET", LandingContent.Positioning, StringComparison.Ordinal);
        Assert.Contains("applications métier", LandingContent.Positioning, StringComparison.Ordinal);
    }

    [Fact]
    public void Landing_concept_hero_content_is_available()
    {
        Assert.Contains("interfaces et la donnée", LandingContent.HeroTitle, StringComparison.Ordinal);
        Assert.Equal(4, LandingContent.ConceptSources.Count);
        Assert.Equal(3, LandingContent.ConceptStack.Count);
        Assert.Equal(4, LandingContent.ConceptSteps.Count);
        Assert.Equal(4, LandingContent.ConceptDemos.Count);
        Assert.Equal(3, LandingContent.HeroKpis.Count);
        Assert.Contains(LandingContent.ConceptSteps, step => step.IsActive);
        Assert.Equal(6, LandingContent.LandingMotionStates.Count);
        Assert.Contains(LandingContent.LandingMotionStates, state => state.IsActive);
        Assert.Contains("solution vérifiable", LandingContent.MethodTitle, StringComparison.Ordinal);
        Assert.Equal(3, LandingContent.MethodSteps.Count);
        Assert.Contains("réalisations réelles", LandingContent.ProjectsTitle, StringComparison.Ordinal);
        Assert.Equal(3, LandingContent.ProjectUseCases.Count);
        Assert.Equal(4, LandingContent.ProjectFilters.Count);
        Assert.Contains("portail BI", LandingContent.CaseStudyTitle, StringComparison.Ordinal);
        Assert.Equal(3, LandingContent.CaseStudyPoints.Count);
        Assert.Equal(3, LandingContent.CaseStudyMetrics.Count);
        Assert.Equal(2, LandingContent.CaseStudyComparisons.Count);
        Assert.Equal("Votre besoin métier", LandingContent.ContactGuidanceTitle);
        Assert.Contains("@", LandingContent.ContactEmail, StringComparison.Ordinal);
        Assert.Equal(3, LandingContent.ContactHighlights.Count);
    }

    [Fact]
    public void Landing_product_demo_content_is_available()
    {
        Assert.Contains("Chaîne applicative", LandingContent.ProductDemoTitle, StringComparison.Ordinal);
        Assert.Equal(3, LandingContent.ProductSources.Count);
        Assert.Equal(3, LandingContent.ProductDecisionMetrics.Count);
        Assert.Contains(LandingContent.ProductSources, source => source.Label == "Data");
        Assert.Contains(LandingContent.ProductDecisionMetrics, metric => metric.Meta == "Réalisation");
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
    public void GitHub_pages_emits_static_metadata_and_a_real_case_study_route()
    {
        var root = FindRepositoryRoot();
        var indexHtml = File.ReadAllText(Path.Combine(root, "wwwroot", "index.html"));
        var workflow = File.ReadAllText(Path.Combine(root, ".github", "workflows", "pages.yml"));

        Assert.Contains("data-static-head name=\"description\"", indexHtml, StringComparison.Ordinal);
        Assert.Contains("data-static-head rel=\"canonical\"", indexHtml, StringComparison.Ordinal);
        Assert.Contains("property=\"og:image\"", indexHtml, StringComparison.Ordinal);
        Assert.Contains("name=\"twitter:card\" content=\"summary_large_image\"", indexHtml, StringComparison.Ordinal);
        Assert.True(File.Exists(Path.Combine(root, "wwwroot", "images", "og-portfolio.jpg")));
        Assert.Contains("[data-static-head]", indexHtml, StringComparison.Ordinal);
        Assert.Contains("mkdir -p publish/wwwroot/projets/pilotage-atelier", workflow, StringComparison.Ordinal);
        Assert.Contains(
            "cp publish/wwwroot/index.html publish/wwwroot/projets/pilotage-atelier/index.html",
            workflow,
            StringComparison.Ordinal);
        Assert.Contains("property=\"og:type\" content=\"article\"", workflow, StringComparison.Ordinal);
        Assert.Contains("Prototype UI Pilotage atelier", workflow, StringComparison.Ordinal);
        Assert.Contains("mkdir -p publish/wwwroot/projets/poc-ssis", workflow, StringComparison.Ordinal);
        Assert.Contains(
            "cp publish/wwwroot/index.html publish/wwwroot/projets/poc-ssis/index.html",
            workflow,
            StringComparison.Ordinal);
        Assert.Contains("POC SSIS : architecture décisionnelle", workflow, StringComparison.Ordinal);
        Assert.Contains("Portfolio/projets/poc-ssis", workflow, StringComparison.Ordinal);
        Assert.Contains("mkdir -p publish/wwwroot/projets/portail-bi", workflow, StringComparison.Ordinal);
        Assert.Contains(
            "cp publish/wwwroot/index.html publish/wwwroot/projets/portail-bi/index.html",
            workflow,
            StringComparison.Ordinal);
        Assert.Contains("Portail BI industriel en Blazor", workflow, StringComparison.Ordinal);
        Assert.Contains("Portfolio/projets/portail-bi", workflow, StringComparison.Ordinal);
        Assert.Contains("/og.description/", workflow, StringComparison.Ordinal);
        Assert.Contains("content=\"https://frit1p3.github.io/Portfolio/\"", workflow, StringComparison.Ordinal);
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
        Assert.Contains("components/project-card.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/contact-form.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/landing-projects-section.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/landing-case-study-section.css", appCss, StringComparison.Ordinal);
        Assert.Contains("components/landing-contact-section.css", appCss, StringComparison.Ordinal);
        Assert.Contains("pages/home.css", appCss, StringComparison.Ordinal);
        Assert.Contains("pages/project-case-study.css", appCss, StringComparison.Ordinal);
        Assert.Contains("pages/project-ssis.css", appCss, StringComparison.Ordinal);
        Assert.Contains("pages/project-bi.css", appCss, StringComparison.Ordinal);
    }

    [Fact]
    public void Css_spacing_token_references_are_defined()
    {
        var root = FindRepositoryRoot();
        var cssRoot = Path.Combine(root, "wwwroot", "css");
        var spacingCss = File.ReadAllText(Path.Combine(cssRoot, "tokens", "spacing.css"));
        var definedTokens = Regex.Matches(spacingCss, @"--space-[\w-]+(?=\s*:)")
            .Select(match => match.Value)
            .ToHashSet(StringComparer.Ordinal);
        var undefinedTokens = Directory.EnumerateFiles(cssRoot, "*.css", SearchOption.AllDirectories)
            .SelectMany(path => Regex.Matches(File.ReadAllText(path), @"var\((--space-[\w-]+)").Select(match => match.Groups[1].Value))
            .Where(token => !definedTokens.Contains(token))
            .Distinct(StringComparer.Ordinal)
            .Order(StringComparer.Ordinal)
            .ToArray();

        Assert.True(undefinedTokens.Length == 0, $"Undefined spacing tokens: {string.Join(", ", undefinedTokens)}");
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
