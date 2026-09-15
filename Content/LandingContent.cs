namespace Portfolio.Content;

public static class LandingContent
{
    public const string Positioning =
        "Front-End .NET pour interfaces métier industrielles, dashboards et outils terrain.";

    public const string HeroEyebrow = "Portfolio applicatif";

    public const string HeroTitle =
        "Interfaces industrielles qui rendent la donnée actionnable.";

    public const string HeroIntro =
        "Développeur Front-End .NET, je conçois des expériences B2B où dashboards, design systems et contraintes terrain convergent vers des décisions plus rapides.";

    public static readonly IReadOnlyList<ConceptSource> ConceptSources = new[]
    {
        new ConceptSource("ERP", "accent", "Commandes et stocks"),
        new ConceptSource("Atelier", "success", "Terrain et qualité"),
        new ConceptSource("BI", "warning", "KPI consolidés"),
        new ConceptSource("GED", "muted", "Preuves et procédures")
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
        new ConceptStep("04", "Décider", "success")
    };

    public static readonly IReadOnlyList<ConceptDemo> ConceptDemos = new[]
    {
        new ConceptDemo(
            "01",
            "Cadrer les flux",
            "Identifier les sources, les contraintes terrain et les arbitrages à rendre visibles.",
            "muted"),
        new ConceptDemo(
            "02",
            "Structurer l'interface",
            "Transformer la complexité métier en modules clairs, hiérarchisés et réutilisables.",
            "accent",
            true),
        new ConceptDemo(
            "03",
            "Mettre les signaux en contexte",
            "Relier KPI, statuts et preuves pour rendre la lecture terrain immédiate.",
            "success"),
        new ConceptDemo(
            "04",
            "Décider plus vite",
            "Faire remonter les priorités utiles, au bon niveau de détail.",
            "success")
    };

    public static readonly IReadOnlyList<HeroKpi> HeroKpis = new[]
    {
        new HeroKpi(
            "Expérience",
            "3 ans",
            "Industrie",
            "Dashboards, KPI et parcours métier.",
            "accent"),
        new HeroKpi(
            "Objectif UX",
            "- friction",
            "Décision",
            "Moins d'allers-retours entre signal, preuve et action.",
            "success"),
        new HeroKpi(
            "Socle",
            ".NET",
            "Blazor",
            "Composants réutilisables, CSS Vanilla et tests.",
            "neutral")
    };

    public const string ProductDemoTitle = "Cartographie opérationnelle des flux";

    public static readonly IReadOnlyList<ProductSource> ProductSources = new[]
    {
        new ProductSource(
            "ERP",
            "Source métier",
            "Commandes, stocks et factures synchronisés.",
            "sync",
            "accent"),
        new ProductSource(
            "Atelier",
            "Terrain",
            "Incidents, temps réels et qualité terrain.",
            "live",
            "success"),
        new ProductSource(
            "GED",
            "Documentation",
            "Procédures et preuves associées aux flux.",
            "ok",
            "neutral")
    };

    public static readonly IReadOnlyList<DecisionMetric> ProductDecisionMetrics = new[]
    {
        new DecisionMetric(
            "01",
            "OEE atelier",
            "87% de rendement",
            "+6 pts face à la semaine précédente",
            "success"),
        new DecisionMetric(
            "02",
            "Alertes critiques",
            "12 points ouverts",
            "3 priorités qualité à traiter en premier",
            "warning"),
        new DecisionMetric(
            "03",
            "Cycle moyen",
            "2.8 j / objectif 3 j",
            "Délai sous contrôle face à la cible",
            "neutral")
    };

    public static readonly IReadOnlyList<MotionState> LandingMotionStates = new[]
    {
        new MotionState(
            "grid-wake",
            "01",
            "Réveil de la grille",
            "Installer le cadre visuel avant d'introduire les sources métier.",
            "muted"),
        new MotionState(
            "message-reveal",
            "02",
            "Message lisible",
            "Faire apparaître la promesse sans séparer le discours de la démonstration.",
            "accent",
            true),
        new MotionState(
            "system-assembly",
            "03",
            "Assemblage du système",
            "Faire tenir UX, design system et KPI dans un même outil de décision.",
            "accent"),
        new MotionState(
            "data-convergence",
            "04",
            "Convergence des données",
            "Relier ERP, atelier, BI et GED vers une lecture opérationnelle commune.",
            "success"),
        new MotionState(
            "concept-switch",
            "05",
            "Focus narratif",
            "Passer d'un concept à l'autre pour expliquer la méthode sans surcharge visuelle.",
            "warning"),
        new MotionState(
            "demo-takeover",
            "06",
            "Demo produit",
            "Donner la priorité à la surface applicative et aux preuves métier.",
            "success")
    };

    public const string MethodEyebrow = "Méthode";

    public const string MethodTitle =
        "De la complexité terrain à l'écran utile.";

    public const string MethodIntro =
        "Une approche courte pour transformer contraintes industrielles, données et arbitrages en écrans testables et maintenables.";

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
            "Organiser parcours, hiérarchie visuelle et composants réutilisables autour des usages critiques.",
            "accent"),
        new MethodStep(
            "03",
            "Livrer",
            "Valider le responsive, l'accessibilité et les tests pour garder une base claire et évolutive.",
            "success")
    };

    public const string ProjectsEyebrow = "Cas d'usage";

    public const string ProjectsTitle =
        "Des produits front-end pour usages industriels.";

    public const string ProjectsIntro =
        "Trois familles de produits pour connecter opérations, données et pilotage sans perdre le contexte métier.";

    public static readonly IReadOnlyList<ProjectUseCase> ProjectUseCases = new[]
    {
        new ProjectUseCase(
            "01",
            "Pilotage atelier",
            "Suivre rendement, incidents, alertes qualité et temps réels pour prioriser l'action terrain.",
            "KPI temps réel",
            "success"),
        new ProjectUseCase(
            "02",
            "Flux ERP / opérations",
            "Rendre commandes, stocks, documents et statuts synchronisés et lisibles dans une même interface.",
            "Flux synchronisés",
            "accent"),
        new ProjectUseCase(
            "03",
            "Reporting décisionnel",
            "Transformer les signaux consolidés en synthèses courtes, lisibles et actionnables.",
            "Synthèse exec",
            "warning")
    };

    public const string CaseStudyEyebrow = "Preuve projet";

    public const string CaseStudyTitle =
        "Rassembler les signaux atelier dans un dashboard actionnable.";

    public const string CaseStudyIntro =
        "Un exemple de cadrage produit pour faire ressortir les priorités sans multiplier les écrans.";

    public const string CaseStudyContext =
        "Les équipes terrain consultent plusieurs sources pour suivre incidents, délais et qualité. L'enjeu est de rapprocher ces signaux dans une interface claire, lisible en quelques secondes.";

    public static readonly IReadOnlyList<CaseStudyPoint> CaseStudyPoints = new[]
    {
        new CaseStudyPoint(
            "Problème",
            "Des indicateurs dispersés entre ERP, atelier et reporting ralentissent les arbitrages quotidiens.",
            "warning"),
        new CaseStudyPoint(
            "Réponse UX",
            "Organiser la lecture par statut, niveau de criticité et prochaine action attendue.",
            "accent"),
        new CaseStudyPoint(
            "Livrable",
            "Un dashboard responsive avec composants réutilisables, KPI contextualisés et parcours court.",
            "success")
    };

    public static readonly IReadOnlyList<CaseStudyMetric> CaseStudyMetrics = new[]
    {
        new CaseStudyMetric("3", "sources reliées", "ERP, atelier, reporting", "accent"),
        new CaseStudyMetric("1", "lecture priorisée", "statut, criticité, action", "success"),
        new CaseStudyMetric("0", "rupture de contexte", "preuve et action au même endroit", "warning")
    };

    public const string ContactEyebrow = "Contact";

    public const string ContactTitle =
        "Passons d'un besoin métier à une interface utile.";

    public const string ContactIntro =
        "Disponible pour cadrer, concevoir ou renforcer une expérience front-end .NET orientée opérations, data et usage quotidien.";

    public const string ContactEmail = "fritp3@gmail.com";

    public const string ContactAvailability = "Ouvert aux missions front-end .NET, UI industrielle et design system.";

    public static readonly IReadOnlyList<ContactHighlight> ContactHighlights = new[]
    {
        new ContactHighlight("Cadrage rapide", "Clarifier besoin, données sources et priorités produit.", "accent"),
        new ContactHighlight("Prototype utile", "Transformer l'idée en écran testable avec composants réutilisables.", "success"),
        new ContactHighlight("Passage à l'échelle", "Stabiliser CSS, accessibilité et tests pour livrer sereinement.", "warning")
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
