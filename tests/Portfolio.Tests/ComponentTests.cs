using Bunit;
using Microsoft.AspNetCore.Components.Web;
using Portfolio.Components.Layout;
using Portfolio.Components.Sections;
using Portfolio.Components.UI;
using Portfolio.Content;
using Portfolio.Pages;

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
    public void SectionHeader_renders_content_variants_and_optional_child_content()
    {
        var cut = Render<SectionHeader>(parameters => parameters
            .Add(component => component.Eyebrow, "Expertise")
            .Add(component => component.Title, "Concevoir pour décider")
            .Add(component => component.TitleId, "expertise-title")
            .Add(component => component.Description, "Une introduction métier.")
            .Add(component => component.Width, "wide")
            .Add(component => component.Alignment, "center")
            .AddChildContent("<div class=\"section-header-action\">Action</div>"));

        var header = cut.Find(".section-header");

        Assert.Contains("section-header--wide", header.ClassList);
        Assert.Contains("section-header--center", header.ClassList);
        Assert.Equal("expertise-title", cut.Find("h2").Id);
        Assert.Equal("Expertise", cut.Find(".section-header__eyebrow").TextContent);
        Assert.Contains("Une introduction métier.", header.TextContent);
        Assert.Equal("Action", cut.Find(".section-header-action").TextContent);
    }

    [Fact]
    public void SkillCard_renders_expertise_content_tags_and_tone()
    {
        var cut = Render<SkillCard>(parameters => parameters
            .Add(component => component.Code, "UX")
            .Add(component => component.Category, "Conception métier")
            .Add(component => component.Title, "UX métier")
            .Add(component => component.Description, "Transformer une contrainte en parcours testable.")
            .Add(component => component.Tags, new[] { "Audit", "Parcours", "Figma" })
            .Add(component => component.Tone, "accent"));

        var card = cut.Find("article");

        Assert.Contains("skill-card--accent", card.ClassList);
        Assert.Equal("UX métier - Conception métier", card.GetAttribute("aria-label"));
        Assert.Equal(3, cut.FindAll(".skill-card__tags li").Count);
        Assert.Contains("Transformer une contrainte", card.TextContent);
    }

    [Fact]
    public void ProjectCard_renders_project_evidence_and_action()
    {
        var cut = Render<ProjectCard>(parameters => parameters
            .Add(component => component.Step, "01")
            .Add(component => component.Category, "Opérations")
            .Add(component => component.Title, "Pilotage atelier")
            .Add(component => component.Description, "Une vue métier actionnable.")
            .Add(component => component.Role, "Conception UX et front-end")
            .Add(component => component.Stack, new[] { "Blazor", "KPI" })
            .Add(component => component.Impact, "Décisions plus rapides")
            .Add(component => component.Status, "Prototype validé")
            .Add(component => component.ActionLabel, "Voir la preuve")
            .Add(component => component.ActionHref, "#case-study")
            .Add(component => component.Tone, "success")
            .Add(component => component.Preview, "frontend")
            .Add(component => component.Featured, true));

        Assert.Contains("project-card--success", cut.Find("article").ClassList);
        Assert.Contains("project-card--featured", cut.Find("article").ClassList);
        Assert.Contains("project-card__visual--frontend", cut.Find(".project-card__visual").ClassList);
        Assert.Equal(3, cut.FindAll(".project-card__preview-kpis > div").Count);
        Assert.Equal(2, cut.FindAll(".project-card__stack li").Count);
        Assert.Contains("Conception UX", cut.Markup);
        Assert.Contains("Décisions plus rapides", cut.Markup);
        Assert.Equal("#case-study", cut.Find(".project-card__link").GetAttribute("href"));
    }

    [Fact]
    public void HeaderNavigation_exposes_main_navigation_landmarks()
    {
        var cut = Render<HeaderNavigation>();

        var header = cut.Find("header");
        var navigationLinks = cut.FindAll(".site-header__nav a");

        Assert.Equal("top", header.Id);
        Assert.Equal("Navigation principale", cut.Find("nav").GetAttribute("aria-label"));
        Assert.Contains("Merryl", cut.Markup);
        Assert.Contains("Merryl Bouchereau - Retour à l'accueil", cut.Find(".site-header__brand").GetAttribute("aria-label"));
        Assert.Equal("#main-content", cut.Find(".skip-link").GetAttribute("href"));
        Assert.Equal(5, navigationLinks.Count);
        Assert.Contains("#expertise", cut.Markup);
        Assert.Contains("#approach", cut.Markup);
        Assert.Contains("#projects", cut.Markup);
        Assert.Contains("#case-study", cut.Markup);
        Assert.Contains("#contact", cut.Markup);
        Assert.Equal("Me contacter", cut.Find(".button").TextContent);
        Assert.Equal("false", cut.Find(".site-header__menu").GetAttribute("aria-expanded"));
        Assert.Equal("Menu de navigation - Ouvrir", cut.Find(".site-header__menu").GetAttribute("aria-label"));
    }

    [Fact]
    public void HeaderNavigation_toggles_compact_navigation()
    {
        var cut = Render<HeaderNavigation>();
        var menu = cut.Find(".site-header__menu");

        menu.Click();

        Assert.Equal("true", cut.Find(".site-header__menu").GetAttribute("aria-expanded"));
        Assert.Contains("site-header__nav--open", cut.Find(".site-header__nav").ClassList);

        cut.Find(".site-header__nav a").Click();

        Assert.Equal("false", cut.Find(".site-header__menu").GetAttribute("aria-expanded"));
        Assert.DoesNotContain("site-header__nav--open", cut.Find(".site-header__nav").ClassList);
    }

    [Fact]
    public void SiteFooter_exposes_contact_area()
    {
        var cut = Render<SiteFooter>();

        var footer = cut.Find("footer");

        Assert.Contains("site-footer", footer.ClassList);
        Assert.Contains("Full-Stack .NET", footer.TextContent);
        Assert.Equal("Navigation de pied de page", cut.Find("nav").GetAttribute("aria-label"));
        Assert.Equal(5, cut.FindAll(".site-footer__nav a").Count);
        Assert.Equal($"mailto:{LandingContent.ContactEmail}", cut.Find(".site-footer__contact a").GetAttribute("href"));
        Assert.Equal("#top", cut.Find(".site-footer__bottom a").GetAttribute("href"));
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
    public void ConceptHeroSection_prioritizes_message_product_preview_and_evidence()
    {
        var cut = Render<ConceptHeroSection>();

        var section = cut.Find("section.concept-hero");

        Assert.Equal("concept-hero-title", section.GetAttribute("aria-labelledby"));
        Assert.Contains("Relier les usages", section.TextContent);
        Assert.Contains("Je conçois et développe des solutions .NET", section.TextContent);
        Assert.Equal("#projects", cut.FindAll(".concept-hero__actions a")[0].GetAttribute("href"));
        Assert.Equal("#case-study", cut.FindAll(".concept-hero__actions a")[1].GetAttribute("href"));
        Assert.NotNull(cut.Find(".concept-hero__dashboard"));
        Assert.Contains(".NET", cut.Find(".concept-hero__primary-metric").TextContent);
        Assert.Equal(2, cut.FindAll(".concept-hero__signal-list > div").Count);
        Assert.Equal(3, cut.FindAll(".concept-hero__dashboard-footer li").Count);
        Assert.Empty(cut.FindAll(".hero-kpi-card"));
        Assert.Empty(cut.FindAll(".motion-sequence"));
        Assert.Empty(cut.FindAll(".concept-demo-card"));
    }

    [Fact]
    public void ConceptHeroSection_exposes_compact_specialties()
    {
        var cut = Render<ConceptHeroSection>();

        var specialties = cut.FindAll(".concept-hero__credentials li");

        Assert.Collection(
            specialties,
            item => Assert.Equal("Applications métier", item.TextContent),
            item => Assert.Equal("Blazor & .NET", item.TextContent),
            item => Assert.Equal("Data & architecture", item.TextContent));
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
        Assert.Contains("Faire apparaître la promesse", stage.TextContent);
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
        Assert.Contains("Assemblage du système", cut.Find(".motion-sequence__stage").TextContent);

        tabs[2].KeyDown(new KeyboardEventArgs { Key = "ArrowLeft" });
        tabs = cut.FindAll(".motion-sequence__tab");

        Assert.Equal("true", tabs[1].GetAttribute("aria-selected"));
        Assert.Contains("Message lisible", cut.Find(".motion-sequence__stage").TextContent);

        tabs[1].KeyDown(new KeyboardEventArgs { Key = "Home" });
        tabs = cut.FindAll(".motion-sequence__tab");

        Assert.Equal("true", tabs[0].GetAttribute("aria-selected"));
        Assert.Contains("Réveil de la grille", cut.Find(".motion-sequence__stage").TextContent);

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
        Assert.Contains("Réveil de la grille", cut.Find(".motion-sequence__stage").TextContent);
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
        Assert.Equal("Aperçu de démonstration produit - Chaîne applicative métier", panel.GetAttribute("aria-label"));
        Assert.Equal(3, cut.FindAll(".source-compact-card").Count);
        Assert.Equal(3, cut.FindAll(".decision-timeline-card").Count);
        Assert.Contains("Chaîne applicative métier", panel.TextContent);
        Assert.Contains("Réalisation", panel.TextContent);
        Assert.Contains("Data", panel.TextContent);
    }

    [Fact]
    public void LandingExpertiseSection_composes_three_data_driven_skill_cards()
    {
        var cut = Render<LandingExpertiseSection>();

        var section = cut.Find("section.expertise-section");

        Assert.Equal("expertise", section.Id);
        Assert.Equal("expertise-section-title", section.GetAttribute("aria-labelledby"));
        Assert.Contains("section-header--center", cut.Find(".section-header").ClassList);
        Assert.Equal(3, cut.FindAll(".skill-card").Count);
        Assert.Contains("Front-End & UX", section.TextContent);
        Assert.Contains("Data & architecture", section.TextContent);
        Assert.Contains("Delivery & projet", section.TextContent);
    }

    [Fact]
    public void LandingMethodSection_composes_method_steps()
    {
        var cut = Render<LandingMethodSection>();

        var section = cut.Find("section.method-section");

        Assert.Equal("approach", section.Id);
        Assert.Equal("method-section-title", section.GetAttribute("aria-labelledby"));
        Assert.Contains("section-header--narrow", cut.Find(".section-header").ClassList);
        Assert.Contains("section-header--center", cut.Find(".section-header").ClassList);
        Assert.Contains("solution vérifiable", section.TextContent);
        Assert.Contains("sépare clairement", section.TextContent);
        Assert.Equal(3, cut.FindAll(".method-section__step").Count);
        Assert.Contains("Définir le problème", section.TextContent);
        Assert.Contains("Concevoir, développer, documenter", section.TextContent);
        Assert.Contains("Distinguer résultats et suites", section.TextContent);
        Assert.Equal("step", cut.Find(".method-section__step--highlighted").GetAttribute("aria-current"));
    }

    [Fact]
    public void LandingProjectsSection_composes_project_use_cases()
    {
        var cut = Render<LandingProjectsSection>();

        var section = cut.Find("section.projects-section");

        Assert.Equal("projects", section.Id);
        Assert.Equal("projects-section-title", section.GetAttribute("aria-labelledby"));
        Assert.Contains("section-header--default", cut.Find(".section-header").ClassList);
        Assert.Contains("réalisations réelles", section.TextContent);
        Assert.Contains("projet professionnel", section.TextContent);
        Assert.Equal(4, cut.FindAll(".projects-section__filter").Count);
        Assert.Equal(3, cut.FindAll(".project-card").Count);
        Assert.Single(cut.FindAll(".project-card--featured"));
        Assert.Single(cut.FindAll(".project-card__visual--frontend"));
        Assert.Single(cut.FindAll(".project-card__visual--data"));
        Assert.Single(cut.FindAll(".project-card__visual--delivery"));
        Assert.Contains("Portail de Business Intelligence", section.TextContent);
        Assert.Contains("POC d'architecture décisionnelle SSIS", section.TextContent);
        Assert.Contains("Chaîne de livraison CI/CD", section.TextContent);

        cut.Find("[data-filter='data']").Click();

        Assert.Equal("true", cut.Find("[data-filter='data']").GetAttribute("aria-pressed"));
        Assert.Single(cut.FindAll(".project-card"));
        Assert.Contains("POC d'architecture décisionnelle SSIS", section.TextContent);
    }

    [Fact]
    public void LandingCaseStudySection_composes_story_points_and_metrics()
    {
        var cut = Render<LandingCaseStudySection>();

        var section = cut.Find("section.case-study-section");

        Assert.Equal("case-study", section.Id);
        Assert.Equal("case-study-section-title", section.GetAttribute("aria-labelledby"));
        Assert.Contains("section-header--wide", cut.Find(".section-header").ClassList);
        Assert.Contains("portail BI", section.TextContent);
        Assert.Contains("visualisations de données de production", section.TextContent);
        Assert.Equal(3, cut.FindAll(".case-study-section__point").Count);
        Assert.Equal(3, cut.FindAll(".case-study-section__metric").Count);
        Assert.Equal(3, cut.FindAll(".case-study-section__facts > div").Count);
        Assert.Equal(2, cut.FindAll(".case-study-section__comparison-item").Count);
        Assert.Contains("Filtres, tableaux", cut.Find(".case-study-section__priority").TextContent);
        Assert.Contains("Expérience professionnelle anonymisée", section.TextContent);
        Assert.Contains("Accéder à la donnée", section.TextContent);
        Assert.Contains("écrans complets", section.TextContent);
        Assert.Contains("Besoin", section.TextContent);
        Assert.Contains("Réalisation", section.TextContent);
        Assert.Contains("Valeur vérifiée", section.TextContent);
        Assert.Equal("#contact", cut.Find(".case-study-section__link").GetAttribute("href"));
    }

    [Fact]
    public void ProjectPilotageAtelier_composes_a_complete_and_honest_case_study()
    {
        var cut = Render<ProjectPilotageAtelier>();

        Assert.Contains("Explorer la lisibilité", cut.Find("h1").TextContent);
        Assert.Equal(4, cut.FindAll(".project-study__summary > div").Count);
        Assert.Equal(3, cut.FindAll(".project-study__problem-grid article").Count);
        Assert.Equal(3, cut.FindAll(".project-study__decisions li").Count);
        Assert.Equal(3, cut.FindAll(".project-study__system-grid article").Count);
        Assert.Equal(2, cut.FindAll(".project-study__outcome").Count);
        Assert.Equal(4, cut.FindAll("[data-reveal]").Count);
        Assert.Contains("sans inventer de résultat client", cut.Find("#project-outcome-title").TextContent);
        Assert.Contains("Prototype conceptuel", cut.Find(".project-study__eyebrow").TextContent);
        Assert.Contains("Aucun déploiement client", cut.Find(".project-study__outcomes").TextContent);
        Assert.Equal("./#contact", cut.Find(".project-study__next .button").GetAttribute("href"));
    }

    [Fact]
    public void LandingContactSection_composes_contact_call_to_action()
    {
        var cut = Render<LandingContactSection>();
        var heading = cut.Find("h2");
        var section = cut.Find("section.contact-section");

        Assert.Equal("contact-guidance-title", heading.Id);
        Assert.Equal("Votre besoin métier", heading.TextContent);
        Assert.Equal("contact-guidance-title", section.GetAttribute("aria-labelledby"));

        Assert.Equal("contact", section.Id);
        Assert.Contains("Décrire votre besoin", section.TextContent);
        Assert.Equal($"mailto:{LandingContent.ContactEmail}", cut.Find(".contact-section__email").GetAttribute("href"));
        Assert.Equal(3, cut.FindAll(".contact-section__highlight").Count);
        Assert.Equal(3, cut.FindAll(".contact-section__highlight h3").Count);
        Assert.Contains("Front-End métier", section.TextContent);
    }

    [Fact]
    public void ContactForm_exposes_labels_helper_and_textual_validation()
    {
        var cut = Render<ContactForm>();

        Assert.Equal(3, cut.FindAll(".contact-form__field").Count);
        Assert.Equal("Nom", cut.Find("label[for='contact-name']").TextContent);
        Assert.Equal("Email", cut.Find("label[for='contact-email']").TextContent);
        Assert.Contains("Tous les champs sont obligatoires", cut.Find(".contact-form__helper").TextContent);

        cut.Find("form").Submit();

        Assert.Equal(3, cut.FindAll(".validation-message").Count);
        Assert.Contains("incomplets ou invalides", cut.Find("[role='status']").TextContent);
    }

    [Fact]
    public void ContactForm_prepares_an_encoded_mailto_after_valid_submission()
    {
        var cut = Render<ContactForm>();

        cut.Find("#contact-name").Change("Merryl Dupont");
        cut.Find("#contact-email").Change("contact@example.com");
        cut.Find("#contact-message").Change("Je souhaite cadrer une interface métier industrielle.");
        cut.Find("form").Submit();

        var link = cut.Find(".contact-form__status a");
        var href = link.GetAttribute("href");

        Assert.StartsWith($"mailto:{LandingContent.ContactEmail}?", href, StringComparison.Ordinal);
        Assert.Contains("Merryl%20Dupont", href);
        Assert.Contains("contact%40example.com", href);
        Assert.Contains("message est prêt", cut.Find("[role='status']").TextContent);
    }
}
