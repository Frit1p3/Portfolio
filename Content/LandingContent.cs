namespace Portfolio.Content;

public static class LandingContent
{
    public const string Positioning =
        "Front-End .NET pour interfaces metier industrielles, dashboards et outils terrain.";

    public const string HeroEyebrow = "Portfolio applicatif";

    public const string HeroTitle =
        "Interfaces industrielles qui rendent la donnee actionnable.";

    public const string HeroIntro =
        "Developpeur Front-End .NET, je concois des experiences B2B ou dashboards, design systems et contraintes terrain convergent vers des decisions plus rapides.";

    public static readonly IReadOnlyList<ConceptSource> ConceptSources = new[]
    {
        new ConceptSource("ERP", "accent", "Commandes et stocks"),
        new ConceptSource("Atelier", "success", "Terrain et qualite"),
        new ConceptSource("BI", "warning", "KPI consolides"),
        new ConceptSource("GED", "muted", "Preuves et procedures")
    };

    public static readonly IReadOnlyList<string> ConceptStack = new[]
    {
        "UX industrielle",
        "Design system",
        "KPI decisionnels"
    };

    public static readonly IReadOnlyList<ConceptStep> ConceptSteps = new[]
    {
        new ConceptStep("01", "Cadrer", "muted"),
        new ConceptStep("02", "Structurer", "accent", true),
        new ConceptStep("03", "Unifier", "accent"),
        new ConceptStep("04", "Decider", "success")
    };

    public static readonly IReadOnlyList<ConceptDemo> ConceptDemos = new[]
    {
        new ConceptDemo(
            "01",
            "Cadrer les flux",
            "Identifier les sources, les contraintes terrain et les arbitrages a rendre visibles.",
            "muted"),
        new ConceptDemo(
            "02",
            "Structurer l'interface",
            "Transformer la complexite metier en modules clairs, hierarchises et reutilisables.",
            "accent",
            true),
        new ConceptDemo(
            "03",
            "Mettre les signaux en contexte",
            "Relier KPI, statuts et preuves pour rendre la lecture terrain immediate.",
            "success"),
        new ConceptDemo(
            "04",
            "Decider plus vite",
            "Faire remonter les priorites utiles, au bon niveau de detail.",
            "success")
    };

    public static readonly IReadOnlyList<HeroKpi> HeroKpis = new[]
    {
        new HeroKpi(
            "Experience",
            "3 ans",
            "Industrie",
            "Dashboards, KPI et parcours metier.",
            "accent"),
        new HeroKpi(
            "Objectif UX",
            "- friction",
            "Decision",
            "Moins d'allers-retours entre signal, preuve et action.",
            "success"),
        new HeroKpi(
            "Socle",
            ".NET",
            "Blazor",
            "Composants reutilisables, CSS Vanilla et tests.",
            "neutral")
    };

    public const string ProductDemoTitle = "Cartographie operationnelle des flux";

    public static readonly IReadOnlyList<ProductSource> ProductSources = new[]
    {
        new ProductSource(
            "ERP",
            "Source metier",
            "Commandes, stocks et factures synchronises.",
            "sync",
            "accent"),
        new ProductSource(
            "Atelier",
            "Terrain",
            "Incidents, temps reels et qualite terrain.",
            "live",
            "success"),
        new ProductSource(
            "GED",
            "Documentation",
            "Procedures et preuves associees aux flux.",
            "ok",
            "neutral")
    };

    public static readonly IReadOnlyList<DecisionMetric> ProductDecisionMetrics = new[]
    {
        new DecisionMetric(
            "01",
            "OEE atelier",
            "87% de rendement",
            "+6 pts face a la semaine precedente",
            "success"),
        new DecisionMetric(
            "02",
            "Alertes critiques",
            "12 points ouverts",
            "3 priorites qualite a traiter en premier",
            "warning"),
        new DecisionMetric(
            "03",
            "Cycle moyen",
            "2.8 j / objectif 3 j",
            "Delai sous controle face a la cible",
            "neutral")
    };

    public static readonly IReadOnlyList<MotionState> LandingMotionStates = new[]
    {
        new MotionState(
            "grid-wake",
            "01",
            "Reveil de la grille",
            "Installer le cadre visuel avant d'introduire les sources metier.",
            "muted"),
        new MotionState(
            "message-reveal",
            "02",
            "Message lisible",
            "Faire apparaitre la promesse sans separer le discours de la demonstration.",
            "accent",
            true),
        new MotionState(
            "system-assembly",
            "03",
            "Assemblage du systeme",
            "Faire tenir UX, design system et KPI dans un meme outil de decision.",
            "accent"),
        new MotionState(
            "data-convergence",
            "04",
            "Convergence des donnees",
            "Relier ERP, atelier, BI et GED vers une lecture operationnelle commune.",
            "success"),
        new MotionState(
            "concept-switch",
            "05",
            "Focus narratif",
            "Passer d'un concept a l'autre pour expliquer la methode sans surcharge visuelle.",
            "warning"),
        new MotionState(
            "demo-takeover",
            "06",
            "Demo produit",
            "Donner la priorite a la surface applicative et aux preuves metier.",
            "success")
    };

    public const string MethodEyebrow = "Methode";

    public const string MethodTitle =
        "De la complexite terrain a l'ecran utile.";

    public const string MethodIntro =
        "Une approche courte pour transformer contraintes industrielles, donnees et arbitrages en ecrans testables et maintenables.";

    public static readonly IReadOnlyList<MethodStep> MethodSteps = new[]
    {
        new MethodStep(
            "01",
            "Cadrer",
            "Identifier les sources, les irritants terrain et les arbitrages attendus avant de dessiner l'interface.",
            "muted"),
        new MethodStep(
            "02",
            "Structurer",
            "Organiser parcours, hierarchie visuelle et composants reutilisables autour des usages critiques.",
            "accent"),
        new MethodStep(
            "03",
            "Livrer",
            "Valider responsive, accessibilite et tests pour garder une base claire et evolutive.",
            "success")
    };

    public const string ProjectsEyebrow = "Cas d'usage";

    public const string ProjectsTitle =
        "Des produits front-end pour usages industriels.";

    public const string ProjectsIntro =
        "Trois familles de produits pour connecter operations, donnees et pilotage sans perdre le contexte metier.";

    public static readonly IReadOnlyList<ProjectUseCase> ProjectUseCases = new[]
    {
        new ProjectUseCase(
            "01",
            "Pilotage atelier",
            "Suivre rendement, incidents, alertes qualite et temps reels pour prioriser l'action terrain.",
            "KPI temps reel",
            "success"),
        new ProjectUseCase(
            "02",
            "Flux ERP / operations",
            "Rendre commandes, stocks, documents et statuts synchronises lisibles dans une meme interface.",
            "Flux synchronises",
            "accent"),
        new ProjectUseCase(
            "03",
            "Reporting decisionnel",
            "Transformer les signaux consolides en syntheses courtes, lisibles et actionnables.",
            "Synthese exec",
            "warning")
    };

    public const string CaseStudyEyebrow = "Preuve projet";

    public const string CaseStudyTitle =
        "Rassembler les signaux atelier dans un dashboard actionnable.";

    public const string CaseStudyIntro =
        "Un exemple de cadrage produit pour faire ressortir les priorites sans multiplier les ecrans.";

    public const string CaseStudyContext =
        "Les equipes terrain consultent plusieurs sources pour suivre incidents, delais et qualite. L'enjeu est de rapprocher ces signaux dans une interface claire, lisible en quelques secondes.";

    public static readonly IReadOnlyList<CaseStudyPoint> CaseStudyPoints = new[]
    {
        new CaseStudyPoint(
            "Probleme",
            "Des indicateurs disperses entre ERP, atelier et reporting ralentissent les arbitrages quotidiens.",
            "warning"),
        new CaseStudyPoint(
            "Reponse UX",
            "Organiser la lecture par statut, niveau de criticite et prochaine action attendue.",
            "accent"),
        new CaseStudyPoint(
            "Livrable",
            "Un dashboard responsive avec composants reutilisables, KPI contextualises et parcours court.",
            "success")
    };

    public static readonly IReadOnlyList<CaseStudyMetric> CaseStudyMetrics = new[]
    {
        new CaseStudyMetric("3", "sources reliees", "ERP, atelier, reporting", "accent"),
        new CaseStudyMetric("1", "lecture priorisee", "statut, criticite, action", "success"),
        new CaseStudyMetric("0", "rupture de contexte", "preuve et action au meme endroit", "warning")
    };

    public const string ContactEyebrow = "Contact";

    public const string ContactTitle =
        "Passons d'un besoin metier a une interface utile.";

    public const string ContactIntro =
        "Disponible pour cadrer, concevoir ou renforcer une experience front-end .NET orientee operations, data et usage quotidien.";

    public const string ContactEmail = "contact@example.com";

    public const string ContactAvailability = "Ouvert aux missions front-end .NET, UI industrielle et design system.";

    public static readonly IReadOnlyList<ContactHighlight> ContactHighlights = new[]
    {
        new ContactHighlight("Cadrage rapide", "Clarifier besoin, donnees sources et priorites produit.", "accent"),
        new ContactHighlight("Prototype utile", "Transformer l'idee en ecran testable avec composants reutilisables.", "success"),
        new ContactHighlight("Passage a l'echelle", "Stabiliser CSS, accessibilite et tests pour livrer sereinement.", "warning")
    };
}

public sealed record ConceptSource(string Label, string Tone, string? Description = null);

public sealed record ConceptStep(string Step, string Label, string Tone, bool IsActive = false);

public sealed record ConceptDemo(string Marker, string Title, string Body, string Tone, bool IsHighlighted = false);

public sealed record HeroKpi(string Label, string Value, string Delta, string Caption, string Tone);

public sealed record ProductSource(string Label, string Type, string Description, string Status, string Tone);

public sealed record DecisionMetric(string Step, string Meta, string Title, string Description, string Tone);

public sealed record MotionState(string Key, string Step, string Title, string Description, string Tone, bool IsActive = false);

public sealed record MethodStep(string Step, string Title, string Description, string Tone);

public sealed record ProjectUseCase(string Step, string Title, string Description, string Meta, string Tone);

public sealed record CaseStudyPoint(string Title, string Description, string Tone);

public sealed record CaseStudyMetric(string Value, string Label, string Detail, string Tone);

public sealed record ContactHighlight(string Title, string Description, string Tone);
