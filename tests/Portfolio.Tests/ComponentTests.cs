using Bunit;
using Portfolio.Components.Layout;
using Portfolio.Components.Sections;
using Portfolio.Components.UI;

namespace Portfolio.Tests;

public sealed class ComponentTests : BunitContext
{
    [Fact]
    public void Button_renders_link_with_variant_and_content()
    {
        var cut = Render<Button>(parameters => parameters
            .Add(component => component.Href, "#proof")
            .Add(component => component.Variant, "secondary")
            .AddChildContent("Voir la demonstration"));

        var link = cut.Find("a");

        Assert.Equal("#proof", link.GetAttribute("href"));
        Assert.Contains("button", link.ClassList);
        Assert.Contains("button--secondary", link.ClassList);
        Assert.Contains("Voir la demonstration", link.TextContent);
    }

    [Fact]
    public void Badge_renders_tone_and_content()
    {
        var cut = Render<Badge>(parameters => parameters
            .Add(component => component.Tone, "accent")
            .AddChildContent("Portfolio applicatif"));

        var badge = cut.Find("span");

        Assert.Contains("badge", badge.ClassList);
        Assert.Contains("badge--accent", badge.ClassList);
        Assert.Contains("Portfolio applicatif", badge.TextContent);
    }

    [Fact]
    public void HeaderNavigation_exposes_main_navigation_landmarks()
    {
        var cut = Render<HeaderNavigation>();

        Assert.NotNull(cut.Find("header"));
        Assert.Equal("Navigation principale", cut.Find("nav").GetAttribute("aria-label"));
        Assert.Contains("Merryl", cut.Markup);
        Assert.Contains("#proof", cut.Markup);
        Assert.Contains("#contact", cut.Markup);
    }

    [Fact]
    public void SiteFooter_exposes_contact_area()
    {
        var cut = Render<SiteFooter>();

        var footer = cut.Find("footer");

        Assert.Equal("contact", footer.Id);
        Assert.Contains("Front-End .NET", footer.TextContent);
        Assert.StartsWith("mailto:", cut.Find("a").GetAttribute("href"));
    }

    [Fact]
    public void SourceCompactCard_renders_source_content_and_tone()
    {
        var cut = Render<SourceCompactCard>(parameters => parameters
            .Add(component => component.Label, "ERP")
            .Add(component => component.Type, "Source metier")
            .Add(component => component.Description, "Commandes, stocks et factures synchronises.")
            .Add(component => component.Status, "sync")
            .Add(component => component.Tone, "accent"));

        var card = cut.Find("article");

        Assert.Contains("source-compact-card", card.ClassList);
        Assert.Contains("source-compact-card--accent", card.ClassList);
        Assert.Equal("ERP - Source metier - sync", card.GetAttribute("aria-label"));
        Assert.Contains("ERP", card.TextContent);
        Assert.Contains("Commandes, stocks et factures synchronises.", card.TextContent);
        Assert.Contains("sync", card.TextContent);
    }

    [Fact]
    public void DecisionTimelineCard_renders_decision_content_and_tone()
    {
        var cut = Render<DecisionTimelineCard>(parameters => parameters
            .Add(component => component.Step, "01")
            .Add(component => component.Meta, "OEE atelier")
            .Add(component => component.Title, "87% de rendement")
            .Add(component => component.Description, "+6 pts vs semaine precedente")
            .Add(component => component.Tone, "success"));

        var card = cut.Find("article");

        Assert.Contains("decision-timeline-card", card.ClassList);
        Assert.Contains("decision-timeline-card--success", card.ClassList);
        Assert.Equal("01 - OEE atelier - 87% de rendement", card.GetAttribute("aria-label"));
        Assert.Contains("01", card.TextContent);
        Assert.Contains("OEE atelier", card.TextContent);
        Assert.Contains("87% de rendement", card.TextContent);
        Assert.Contains("+6 pts vs semaine precedente", card.TextContent);
    }

    [Fact]
    public void ProductDemoPanel_composes_sources_and_decision_cards()
    {
        var cut = Render<ProductDemoPanel>();

        var panel = cut.Find("section");

        Assert.Equal("proof", panel.Id);
        Assert.Contains("product-demo-panel", panel.ClassList);
        Assert.Equal("Apercu de demonstration produit - Cartographie des flux metier", panel.GetAttribute("aria-label"));
        Assert.Equal(3, cut.FindAll(".source-compact-card").Count);
        Assert.Equal(3, cut.FindAll(".decision-timeline-card").Count);
        Assert.Contains("Cartographie des flux metier", panel.TextContent);
        Assert.Contains("OEE atelier", panel.TextContent);
        Assert.Contains("GED", panel.TextContent);
    }
}
