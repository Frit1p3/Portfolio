namespace Portfolio.Content;

public static class LandingContent
{
    public const string Positioning =
        "Front-End .NET specialise dans les interfaces metier industrielles.";

    public const string HeroEyebrow = "Portfolio applicatif";

    public const string HeroTitle =
        "Interfaces metier industrielles, lisibles et orientees decision.";

    public const string HeroIntro =
        "Developpeur Front-End .NET specialise dans les experiences B2B, les dashboards KPI et les design systems pour environnements industriels.";

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
            "Identifier les sources, les contraintes terrain et les decisions attendues.",
            "muted"),
        new ConceptDemo(
            "02",
            "Structurer l'interface",
            "Transformer la complexite metier en modules lisibles, hierarchises et reutilisables.",
            "accent",
            true),
        new ConceptDemo(
            "03",
            "Rendre la donnee exploitable",
            "Relier KPI, statut et contexte pour accelerer la lecture operationnelle.",
            "success"),
        new ConceptDemo(
            "04",
            "Decider plus vite",
            "Transformer les signaux consolides en priorites claires et actionnables.",
            "success")
    };

    public static readonly IReadOnlyList<HeroKpi> HeroKpis = new[]
    {
        new HeroKpi(
            "Experience",
            "3 ans",
            "Industrie",
            "Interfaces metier, KPI et donnees operationnelles.",
            "accent"),
        new HeroKpi(
            "Objectif UX",
            "- friction",
            "Decision",
            "Des parcours plus lisibles pour accelerer l'action.",
            "success"),
        new HeroKpi(
            "Socle",
            ".NET",
            "Blazor",
            "Composants reutilisables, CSS Vanilla et accessibilite.",
            "neutral")
    };

    public const string ProductDemoTitle = "Cartographie des flux metier";

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
            "Incidents, temps reels et qualite atelier.",
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
            "+6 pts vs semaine precedente",
            "success"),
        new DecisionMetric(
            "02",
            "Alertes critiques",
            "12 points ouverts",
            "3 priorites qualite a traiter",
            "warning"),
        new DecisionMetric(
            "03",
            "Cycle moyen",
            "2.8 j / objectif 3 j",
            "Delai compatible avec la cible",
            "neutral")
    };

    public static readonly IReadOnlyList<MotionState> LandingMotionStates = new[]
    {
        new MotionState(
            "grid-wake",
            "01",
            "Reveil de la grille",
            "Installer le cadre technique avant d'introduire les sources metier.",
            "muted"),
        new MotionState(
            "message-reveal",
            "02",
            "Message lisible",
            "Faire apparaitre la promesse sans separer artificiellement texte et demonstration.",
            "accent",
            true),
        new MotionState(
            "system-assembly",
            "03",
            "Assemblage du systeme",
            "Structurer UX, design system et KPI comme un meme outil de decision.",
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
            "Passer d'un concept a l'autre pour expliquer la methode sans surcharge.",
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
        "De la complexite metier a l'interface exploitable.";

    public const string MethodIntro =
        "Une approche courte et structuree pour transformer les flux industriels en parcours lisibles, testables et maintenables.";

    public static readonly IReadOnlyList<MethodStep> MethodSteps = new[]
    {
        new MethodStep(
            "01",
            "Cadrer",
            "Identifier les sources, les contraintes terrain et les decisions attendues avant de dessiner l'interface.",
            "muted"),
        new MethodStep(
            "02",
            "Structurer",
            "Organiser les parcours, la hierarchie visuelle et les composants reutilisables autour des usages critiques.",
            "accent"),
        new MethodStep(
            "03",
            "Livrer",
            "Valider le rendu responsive, l'accessibilite et les tests pour garder une base evolutive.",
            "success")
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
