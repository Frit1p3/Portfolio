using Bunit;
using Microsoft.AspNetCore.Components.Web;
using Portfolio.Components.Layout;
using Portfolio.Components.Sections;
using Portfolio.Components.UI;
using Portfolio.Content;

namespace Portfolio.Tests;

public sealed class ComponentTests : BunitContext
{
    public ComponentTests()
    {
        JSInterop.Setup<bool>("portfolioMotion.prefersReducedMotion").SetResult(false);
    }

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
        Assert.Contains("#approach", cut.Markup);
        Assert.Contains("#contact", cut.Markup);
    }

    [Fact]
    public void SiteFooter_exposes_contact_area()
    {
        var cut = Render<SiteFooter>();

        var footer = cut.Find("footer");

        Assert.Contains("site-footer", footer.ClassList);
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
    public void HeroKpiCard_renders_kpi_content_and_tone()
    {
        var cut = Render<HeroKpiCard>(parameters => parameters
            .Add(component => component.Label, "Experience")
            .Add(component => component.Value, "3 ans")
            .Add(component => component.Delta, "Industrie")
            .Add(component => component.Caption, "Interfaces metier, KPI et donnees operationnelles.")
            .Add(component => component.Tone, "accent"));

        var card = cut.Find("article");

        Assert.Contains("hero-kpi-card", card.ClassList);
        Assert.Contains("hero-kpi-card--accent", card.ClassList);
        Assert.Equal("Experience - 3 ans - Industrie", card.GetAttribute("aria-label"));
        Assert.Contains("Experience", card.TextContent);
        Assert.Contains("3 ans", card.TextContent);
        Assert.Contains("Industrie", card.TextContent);
        Assert.Contains("Interfaces metier, KPI et donnees operationnelles.", card.TextContent);
    }

    [Fact]
    public void ConceptSourceChip_renders_source_label_description_and_tone()
    {
        var cut = Render<ConceptSourceChip>(parameters => parameters
            .Add(component => component.Label, "ERP")
            .Add(component => component.Description, "Donnees synchronisees")
            .Add(component => component.Tone, "accent"));

        var chip = cut.Find("span.concept-source-chip");

        Assert.Contains("concept-source-chip", chip.ClassList);
        Assert.Contains("concept-source-chip--accent", chip.ClassList);
        Assert.Equal("ERP - Donnees synchronisees", chip.GetAttribute("aria-label"));
        Assert.Contains("ERP", chip.TextContent);
        Assert.Contains("Donnees synchronisees", chip.TextContent);
    }

    [Fact]
    public void ConceptTab_renders_active_tab_with_step_and_tone()
    {
        var cut = Render<ConceptTab>(parameters => parameters
            .Add(component => component.Label, "Structurer")
            .Add(component => component.Step, "02")
            .Add(component => component.Tone, "accent")
            .Add(component => component.IsActive, true));

        var tab = cut.Find("button");

        Assert.Contains("concept-tab", tab.ClassList);
        Assert.Contains("concept-tab--accent", tab.ClassList);
        Assert.Contains("concept-tab--active", tab.ClassList);
        Assert.Equal("tab", tab.GetAttribute("role"));
        Assert.Equal("true", tab.GetAttribute("aria-selected"));
        Assert.Equal("02 - Structurer", tab.GetAttribute("aria-label"));
        Assert.Contains("02", tab.TextContent);
        Assert.Contains("Structurer", tab.TextContent);
    }

    [Fact]
    public void ConceptDemoCard_renders_highlighted_concept_content()
    {
        var cut = Render<ConceptDemoCard>(parameters => parameters
            .Add(component => component.Title, "Unifier les donnees")
            .Add(component => component.Body, "Transformer plusieurs sources metier en lecture decisionnelle commune.")
            .Add(component => component.Marker, "03")
            .Add(component => component.Tone, "accent")
            .Add(component => component.IsHighlighted, true));

        var card = cut.Find("article");

        Assert.Contains("concept-demo-card", card.ClassList);
        Assert.Contains("concept-demo-card--accent", card.ClassList);
        Assert.Contains("concept-demo-card--highlighted", card.ClassList);
        Assert.Equal("03 - Unifier les donnees", card.GetAttribute("aria-label"));
        Assert.Contains("03", card.TextContent);
        Assert.Contains("Unifier les donnees", card.TextContent);
        Assert.Contains("Transformer plusieurs sources metier en lecture decisionnelle commune.", card.TextContent);
    }

    [Fact]
    public void ConceptHeroSection_composes_landing_concept_components()
    {
        var cut = Render<ConceptHeroSection>();

        var section = cut.Find("section.concept-hero");

        Assert.Equal("concept-hero-title", section.GetAttribute("aria-labelledby"));
        Assert.Contains("Interfaces industrielles", section.TextContent);
        Assert.Equal(4, cut.FindAll(".concept-source-chip").Count);
        Assert.Equal(4, cut.FindAll(".concept-tab").Count);
        Assert.Equal(4, cut.FindAll(".concept-demo-card").Count);
        Assert.Equal(3, cut.FindAll(".hero-kpi-card").Count);
        Assert.NotNull(cut.Find(".motion-sequence"));
        Assert.NotNull(cut.Find(".product-demo-panel"));
        Assert.Contains("Structurer l'interface", section.TextContent);
    }

    [Fact]
    public void ConceptHeroSection_updates_active_step_and_highlighted_demo_card()
    {
        var cut = Render<ConceptHeroSection>();

        var tabs = cut.FindAll(".concept-tab");

        Assert.Equal("true", tabs[1].GetAttribute("aria-selected"));
        Assert.Contains("concept-demo-card--highlighted", cut.FindAll(".concept-demo-card")[1].ClassList);

        tabs[3].Click();

        tabs = cut.FindAll(".concept-tab");
        var cards = cut.FindAll(".concept-demo-card");

        Assert.Equal("false", tabs[1].GetAttribute("aria-selected"));
        Assert.Equal("true", tabs[3].GetAttribute("aria-selected"));
        Assert.DoesNotContain("concept-demo-card--highlighted", cards[1].ClassList);
        Assert.Contains("concept-demo-card--highlighted", cards[3].ClassList);
        Assert.Contains("Decider plus vite", cards[3].TextContent);
    }

    [Fact]
    public void LandingMotionSequence_updates_active_motion_state()
    {
        var cut = Render<LandingMotionSequence>();

        var tabs = cut.FindAll(".motion-sequence__tab");
        var stage = cut.Find(".motion-sequence__stage");

        Assert.Equal("true", tabs[1].GetAttribute("aria-selected"));
        Assert.Equal("motion-sequence-tab-message-reveal", tabs[1].Id);
        Assert.All(tabs, tab => Assert.Equal("motion-sequence-panel", tab.GetAttribute("aria-controls")));
        Assert.Equal("tabpanel", stage.GetAttribute("role"));
        Assert.Equal("motion-sequence-panel", stage.Id);
        Assert.Equal("motion-sequence-tab-message-reveal", stage.GetAttribute("aria-labelledby"));
        Assert.Contains("Message lisible", stage.TextContent);

        tabs[5].Click();

        tabs = cut.FindAll(".motion-sequence__tab");
        stage = cut.Find(".motion-sequence__stage");

        Assert.Equal("false", tabs[1].GetAttribute("aria-selected"));
        Assert.Equal("true", tabs[5].GetAttribute("aria-selected"));
        Assert.Equal("motion-sequence-tab-demo-takeover", tabs[5].Id);
        Assert.All(tabs, tab => Assert.Equal("motion-sequence-panel", tab.GetAttribute("aria-controls")));
        Assert.Equal("motion-sequence-panel", stage.Id);
        Assert.Equal("motion-sequence-tab-demo-takeover", stage.GetAttribute("aria-labelledby"));
        Assert.Contains("Demo produit", stage.TextContent);
    }

    [Fact]
    public void LandingMotionStage_renders_active_state_with_accessibility_links()
    {
        var state = LandingContent.LandingMotionStates[1];

        var cut = Render<LandingMotionStage>(parameters => parameters
            .Add(component => component.State, state)
            .Add(component => component.PanelId, "motion-sequence-panel")
            .Add(component => component.ActiveTabId, "motion-sequence-tab-message-reveal"));

        var stage = cut.Find(".motion-sequence__stage");

        Assert.Equal("motion-sequence-panel", stage.Id);
        Assert.Equal("tabpanel", stage.GetAttribute("role"));
        Assert.Equal("motion-sequence-tab-message-reveal", stage.GetAttribute("aria-labelledby"));
        Assert.Contains("motion-sequence__stage--accent", stage.ClassList);
        Assert.Contains("Message lisible", stage.TextContent);
        Assert.Contains("Faire apparaitre la promesse", stage.TextContent);
    }

    [Fact]
    public void LandingMotionControls_renders_auto_play_states()
    {
        var cut = Render<LandingMotionControls>(parameters => parameters
            .Add(component => component.IsAutoPlaying, true)
            .Add(component => component.IsAutoPlayDisabled, true));

        var controls = cut.FindAll(".motion-sequence__control");
        var autoPlayControl = controls[3];

        Assert.Equal(4, controls.Count);
        Assert.Contains("Precedent", controls[0].TextContent);
        Assert.Contains("Suivant", controls[1].TextContent);
        Assert.Contains("Rejouer", controls[2].TextContent);
        Assert.True(autoPlayControl.HasAttribute("disabled"));
        Assert.Equal("true", autoPlayControl.GetAttribute("aria-disabled"));
        Assert.Equal("true", autoPlayControl.GetAttribute("aria-pressed"));
        Assert.Contains("Lecture auto indisponible", autoPlayControl.TextContent);
    }

    [Fact]
    public void LandingMotionTabs_renders_tablist_with_active_state()
    {
        var cut = Render<LandingMotionTabs>(parameters => parameters
            .Add(component => component.States, LandingContent.LandingMotionStates)
            .Add(component => component.ActiveStateKey, "message-reveal")
            .Add(component => component.PanelId, "motion-sequence-panel"));

        var tablist = cut.Find(".motion-sequence__tabs");
        var tabs = cut.FindAll(".motion-sequence__tab");

        Assert.Equal("tablist", tablist.GetAttribute("role"));
        Assert.Equal(6, tabs.Count);
        Assert.Equal("motion-sequence-tab-message-reveal", tabs[1].Id);
        Assert.Equal("true", tabs[1].GetAttribute("aria-selected"));
        Assert.Equal("0", tabs[1].GetAttribute("tabindex"));
        Assert.Equal("motion-sequence-panel", tabs[1].GetAttribute("aria-controls"));
        Assert.Contains("motion-sequence__tab--active", tabs[1].ClassList);
        Assert.Equal("false", tabs[0].GetAttribute("aria-selected"));
        Assert.Equal("-1", tabs[0].GetAttribute("tabindex"));
    }

    [Fact]
    public void LandingMotionSequence_supports_keyboard_navigation()
    {
        var cut = Render<LandingMotionSequence>();

        var tabs = cut.FindAll(".motion-sequence__tab");

        Assert.Equal("true", tabs[1].GetAttribute("aria-selected"));
        Assert.Equal("0", tabs[1].GetAttribute("tabindex"));

        tabs[1].KeyDown(new KeyboardEventArgs { Key = "ArrowRight" });
        tabs = cut.FindAll(".motion-sequence__tab");

        Assert.Equal("false", tabs[1].GetAttribute("aria-selected"));
        Assert.Equal("-1", tabs[1].GetAttribute("tabindex"));
        Assert.Equal("true", tabs[2].GetAttribute("aria-selected"));
        Assert.Equal("0", tabs[2].GetAttribute("tabindex"));
        Assert.Contains("Assemblage du systeme", cut.Find(".motion-sequence__stage").TextContent);

        tabs[2].KeyDown(new KeyboardEventArgs { Key = "ArrowLeft" });
        tabs = cut.FindAll(".motion-sequence__tab");

        Assert.Equal("true", tabs[1].GetAttribute("aria-selected"));
        Assert.Contains("Message lisible", cut.Find(".motion-sequence__stage").TextContent);

        tabs[1].KeyDown(new KeyboardEventArgs { Key = "Home" });
        tabs = cut.FindAll(".motion-sequence__tab");

        Assert.Equal("true", tabs[0].GetAttribute("aria-selected"));
        Assert.Contains("Reveil de la grille", cut.Find(".motion-sequence__stage").TextContent);

        tabs[0].KeyDown(new KeyboardEventArgs { Key = "End" });
        tabs = cut.FindAll(".motion-sequence__tab");

        Assert.Equal("true", tabs[5].GetAttribute("aria-selected"));
        Assert.Contains("Demo produit", cut.Find(".motion-sequence__stage").TextContent);
    }

    [Fact]
    public void LandingMotionSequence_replays_from_first_motion_state()
    {
        var cut = Render<LandingMotionSequence>();

        var tabs = cut.FindAll(".motion-sequence__tab");

        tabs[5].Click();

        tabs = cut.FindAll(".motion-sequence__tab");
        Assert.Equal("true", tabs[5].GetAttribute("aria-selected"));
        Assert.Contains("Demo produit", cut.Find(".motion-sequence__stage").TextContent);

        cut.FindAll(".motion-sequence__control")[2].Click();

        tabs = cut.FindAll(".motion-sequence__tab");

        Assert.Equal("true", tabs[0].GetAttribute("aria-selected"));
        Assert.Equal("0", tabs[0].GetAttribute("tabindex"));
        Assert.Equal("-1", tabs[5].GetAttribute("tabindex"));
        Assert.Equal("motion-sequence-tab-grid-wake", cut.Find(".motion-sequence__stage").GetAttribute("aria-labelledby"));
        Assert.Contains("Reveil de la grille", cut.Find(".motion-sequence__stage").TextContent);
    }

    [Fact]
    public void LandingMotionSequence_toggles_optional_auto_play()
    {
        var cut = Render<LandingMotionSequence>();

        var autoPlayControl = cut.FindAll(".motion-sequence__control")[3];

        Assert.Equal("false", autoPlayControl.GetAttribute("aria-pressed"));
        Assert.Contains("Lecture auto", autoPlayControl.TextContent);

        autoPlayControl.Click();
        autoPlayControl = cut.FindAll(".motion-sequence__control")[3];

        Assert.Equal("true", autoPlayControl.GetAttribute("aria-pressed"));
        Assert.Contains("Pause", autoPlayControl.TextContent);

        autoPlayControl.Click();
        autoPlayControl = cut.FindAll(".motion-sequence__control")[3];

        Assert.Equal("false", autoPlayControl.GetAttribute("aria-pressed"));
        Assert.Contains("Lecture auto", autoPlayControl.TextContent);
    }

    [Fact]
    public void LandingMotionSequence_stops_auto_play_on_manual_interaction()
    {
        var cut = Render<LandingMotionSequence>();

        var controls = cut.FindAll(".motion-sequence__control");

        controls[3].Click();
        controls = cut.FindAll(".motion-sequence__control");

        Assert.Equal("true", controls[3].GetAttribute("aria-pressed"));

        controls[1].Click();
        controls = cut.FindAll(".motion-sequence__control");

        Assert.Equal("false", controls[3].GetAttribute("aria-pressed"));
        Assert.Contains("Lecture auto", controls[3].TextContent);

        controls[3].Click();
        var tabs = cut.FindAll(".motion-sequence__tab");
        tabs[4].Click();
        controls = cut.FindAll(".motion-sequence__control");

        Assert.Equal("false", controls[3].GetAttribute("aria-pressed"));

        controls[3].Click();
        tabs = cut.FindAll(".motion-sequence__tab");
        tabs[4].KeyDown(new KeyboardEventArgs { Key = "ArrowRight" });
        controls = cut.FindAll(".motion-sequence__control");

        Assert.Equal("false", controls[3].GetAttribute("aria-pressed"));
    }

    [Fact]
    public void LandingMotionSequence_disables_auto_play_when_reduced_motion_is_preferred()
    {
        JSInterop.Setup<bool>("portfolioMotion.prefersReducedMotion").SetResult(true);

        var cut = Render<LandingMotionSequence>();

        var autoPlayControl = cut.FindAll(".motion-sequence__control")[3];

        Assert.True(autoPlayControl.HasAttribute("disabled"));
        Assert.Equal("true", autoPlayControl.GetAttribute("aria-disabled"));
        Assert.Equal("false", autoPlayControl.GetAttribute("aria-pressed"));
        Assert.Contains("Lecture auto indisponible", autoPlayControl.TextContent);
    }

    [Fact]
    public void ProductDemoPanel_composes_sources_and_decision_cards()
    {
        var cut = Render<ProductDemoPanel>();

        var panel = cut.Find("section");

        Assert.Equal("proof", panel.Id);
        Assert.Contains("product-demo-panel", panel.ClassList);
        Assert.Equal("Apercu de demonstration produit - Cartographie operationnelle des flux", panel.GetAttribute("aria-label"));
        Assert.Equal(3, cut.FindAll(".source-compact-card").Count);
        Assert.Equal(3, cut.FindAll(".decision-timeline-card").Count);
        Assert.Contains("Cartographie operationnelle des flux", panel.TextContent);
        Assert.Contains("OEE atelier", panel.TextContent);
        Assert.Contains("GED", panel.TextContent);
    }

    [Fact]
    public void LandingMethodSection_composes_method_steps()
    {
        var cut = Render<LandingMethodSection>();

        var section = cut.Find("section.method-section");

        Assert.Equal("approach", section.Id);
        Assert.Equal("method-section-title", section.GetAttribute("aria-labelledby"));
        Assert.Contains("De la complexite terrain", section.TextContent);
        Assert.Contains("ecrans testables", section.TextContent);
        Assert.Equal(3, cut.FindAll(".method-section__step").Count);
        Assert.Contains("Cadrer", section.TextContent);
        Assert.Contains("Structurer", section.TextContent);
        Assert.Contains("Livrer", section.TextContent);
    }

    [Fact]
    public void LandingProjectsSection_composes_project_use_cases()
    {
        var cut = Render<LandingProjectsSection>();

        var section = cut.Find("section.projects-section");

        Assert.Equal("projects-section-title", section.GetAttribute("aria-labelledby"));
        Assert.Contains("Des produits front-end", section.TextContent);
        Assert.Contains("usages industriels", section.TextContent);
        Assert.Equal(3, cut.FindAll(".projects-section__card").Count);
        Assert.Contains("Pilotage atelier", section.TextContent);
        Assert.Contains("Flux ERP", section.TextContent);
        Assert.Contains("Reporting decisionnel", section.TextContent);
    }

    [Fact]
    public void LandingCaseStudySection_composes_story_points_and_metrics()
    {
        var cut = Render<LandingCaseStudySection>();

        var section = cut.Find("section.case-study-section");

        Assert.Equal("case-study-section-title", section.GetAttribute("aria-labelledby"));
        Assert.Contains("Rassembler les signaux atelier", section.TextContent);
        Assert.Contains("equipes terrain", section.TextContent);
        Assert.Equal(3, cut.FindAll(".case-study-section__point").Count);
        Assert.Equal(3, cut.FindAll(".case-study-section__metric").Count);
        Assert.Contains("Probleme", section.TextContent);
        Assert.Contains("Reponse UX", section.TextContent);
        Assert.Contains("Livrable", section.TextContent);
    }

    [Fact]
    public void LandingContactSection_composes_contact_call_to_action()
    {
        var cut = Render<LandingContactSection>();

        var section = cut.Find("section.contact-section");
        var link = cut.Find("a.button");

        Assert.Equal("contact", section.Id);
        Assert.Equal("contact-section-title", section.GetAttribute("aria-labelledby"));
        Assert.Contains("Passons d'un besoin metier", section.TextContent);
        Assert.Contains("Demarrer un echange", link.TextContent);
        Assert.Equal($"mailto:{LandingContent.ContactEmail}", link.GetAttribute("href"));
        Assert.Equal(3, cut.FindAll(".contact-section__highlight").Count);
        Assert.Contains("Cadrage rapide", section.TextContent);
    }
}
