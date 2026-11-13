namespace Portfolio.Content;

public static class LandingContent
{
    public const string Positioning =
        "Développeur Full-Stack .NET · applications métier, interfaces et data";

    public static readonly IReadOnlyList<NavigationLink> PrimaryNavigationLinks = new[]
    {
        new NavigationLink("Projets", "#projects"),
        new NavigationLink("Preuve Front-End", "#case-study"),
        new NavigationLink("Expertises", "#expertise"),
        new NavigationLink("Méthode", "#approach")
    };

    public const string HeroEyebrow = "Full-Stack .NET · Applications métier";

    public const string HeroTitle =
        "Relier les usages, les interfaces et la donnée";

    public const string HeroIntro =
        "Je conçois et développe des solutions .NET pour des environnements où l'interface, les flux de données et la fiabilité opérationnelle doivent fonctionner ensemble.";

    public static readonly IReadOnlyList<ConceptSource> ConceptSources = new[]
    {
        new ConceptSource("Blazor", "accent", "Interfaces métier"),
        new ConceptSource("SQL / SSIS", "success", "Flux de données"),
        new ConceptSource("BI", "warning", "Exploration et restitution"),
        new ConceptSource("CI/CD", "muted", "Livraison contrôlée")
    };

    public static readonly IReadOnlyList<string> ConceptStack = new[]
    {
        "UX",
        "Design system",
        "KPI"
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
            "Identifier les sources, les contraintes terrain et les arbitrages à rendre visibles",
            "muted"),
        new ConceptDemo(
            "02",
            "Structurer l'interface",
            "Transformer la complexité métier en modules clairs, hiérarchisés et réutilisables",
            "accent",
            true),
        new ConceptDemo(
            "03",
            "Mettre les signaux en contexte",
            "Relier KPI, statuts et preuves pour rendre la lecture terrain immédiate",
            "success"),
        new ConceptDemo(
            "04",
            "Décider plus vite",
            "Faire remonter les priorités utiles, au bon niveau de détail",
            "success")
    };

    public static readonly IReadOnlyList<HeroKpi> HeroKpis = new[]
    {
        new HeroKpi(
            "Industrie",
            "3 ans",
            "2023–2026",
            "Applications métier, data et coordination technique",
            "accent"),
        new HeroKpi(
            "Approche",
            "Full-Stack",
            ".NET",
            "Du besoin métier à une solution testable et documentée",
            "success"),
        new HeroKpi(
            "Spécialisation",
            "Front-End",
            "UX & data",
            "Interfaces Blazor, visualisation et composants maintenables",
            "neutral")
    };

    public const string ProductDemoTitle = "Chaîne applicative métier";

    public static readonly IReadOnlyList<ProductSource> ProductSources = new[]
    {
        new ProductSource(
            "Métier",
            "Besoin",
            "Usages, contraintes et responsabilités clarifiés",
            "cadré",
            "accent"),
        new ProductSource(
            "Data",
            "Flux",
            "Sources, transformations et contrôles documentés",
            "tracé",
            "success"),
        new ProductSource(
            "Application",
            "Livrable",
            "Interface, services et livraison testés",
            "vérifié",
            "neutral")
    };

    public static readonly IReadOnlyList<DecisionMetric> ProductDecisionMetrics = new[]
    {
        new DecisionMetric(
            "01",
            "Besoin métier",
            "Périmètre explicite",
            "Objectifs, risques et arbitrages identifiés",
            "success"),
        new DecisionMetric(
            "02",
            "Réalisation",
            "Livrable testable",
            "Interfaces, flux et contrôles reliés",
            "warning"),
        new DecisionMetric(
            "03",
            "Validation",
            "Résultats vérifiés",
            "Limites et suites distinguées du périmètre livré",
            "neutral")
    };

    public static readonly IReadOnlyList<MotionState> LandingMotionStates = new[]
    {
        new MotionState(
            "grid-wake",
            "01",
            "Réveil de la grille",
            "Installer le cadre visuel avant d'introduire les sources métier",
            "muted"),
        new MotionState(
            "message-reveal",
            "02",
            "Message lisible",
            "Faire apparaître la promesse sans séparer le discours de la démonstration",
            "accent",
            true),
        new MotionState(
            "system-assembly",
            "03",
            "Assemblage du système",
            "Faire tenir UX, design system et KPI dans un même outil de décision",
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
            "Passer d'un concept à l'autre pour expliquer la méthode sans surcharge visuelle",
            "warning"),
        new MotionState(
            "demo-takeover",
            "06",
            "Demo produit",
            "Donner la priorité à la surface applicative et aux preuves métier",
            "success")
    };

    public const string ExpertiseEyebrow = "Domaines d'intervention";

    public const string ExpertiseTitle =
        "Trois façons de rendre une application métier utile";

    public const string ExpertiseIntro =
        "Une pratique Full-Stack structurée autour des usages, de la donnée et de la fiabilité de livraison";

    public static readonly IReadOnlyList<ExpertiseSkill> ExpertiseSkills = new[]
    {
        new ExpertiseSkill(
            "UI",
            "Concevoir l'expérience métier",
            "Front-End & UX",
            "Traduire un besoin opérationnel en écrans complets, lisibles et maintenables",
            new[] { "Blazor", "Figma", "MudBlazor" },
            "accent"),
        new ExpertiseSkill(
            "ETL",
            "Structurer et valoriser",
            "Data & architecture",
            "Relier les sources, contrôler les transformations et préparer des données exploitables",
            new[] { "SQL Server", "SSIS", "BI" },
            "success"),
        new ExpertiseSkill(
            "OPS",
            "Fiabiliser et coordonner",
            "Delivery & projet",
            "Sécuriser la livraison, documenter les décisions et coordonner les parties prenantes",
            new[] { "Tests", "CI/CD", "Cadrage" },
            "warning")
    };

    public const string MethodEyebrow = "Méthode";

    public const string MethodTitle =
        "Du besoin métier à une solution vérifiable";

    public const string MethodIntro =
        "Une méthode qui sépare clairement le problème, le périmètre livré, les résultats constatés et les suites recommandées";

    public static readonly IReadOnlyList<MethodStep> MethodSteps = new[]
    {
        new MethodStep(
            "01",
            "Cadrage",
            "Définir le problème et le périmètre",
            "Clarifier les usages, les responsabilités, les risques et les décisions attendues",
            "Responsabilités explicites",
            "muted"),
        new MethodStep(
            "02",
            "Réalisation",
            "Concevoir, développer, documenter",
            "Relier interface, services et données dans un livrable testable et maintenable",
            "Périmètre livré et tracé",
            "accent",
            true),
        new MethodStep(
            "03",
            "Validation",
            "Distinguer résultats et suites",
            "Vérifier ce qui fonctionne, documenter les limites et ne chiffrer que les effets mesurés",
            "Preuves et limites séparées",
            "success")
    };

    public const string ProjectsEyebrow = "Expériences sélectionnées";

    public const string ProjectsTitle =
        "Des réalisations réelles, chacune avec son statut";

    public const string ProjectsIntro =
        "Une sélection volontairement courte pour montrer le Front-End, la data et la livraison sans mélanger projet professionnel, POC et formation";

    public static readonly IReadOnlyList<ProjectFilter> ProjectFilters = new[]
    {
        new ProjectFilter("all", "Tous"),
        new ProjectFilter("frontend", "Front-End & BI"),
        new ProjectFilter("data", "Data & architecture"),
        new ProjectFilter("delivery", "Delivery")
    };

    public static readonly IReadOnlyList<ProjectUseCase> ProjectUseCases = new[]
    {
        new ProjectUseCase(
            "01",
            "frontend",
            "Front-End & BI",
            "Portail de Business Intelligence",
            "Concevoir et développer des visualisations de données de production adaptées au périmètre de chaque service",
            "Développeur Full-Stack à dominante Front-End",
            new[] { "Blazor", ".NET 9/10", "MudBlazor", "Figma" },
            "Plusieurs interfaces métier déployées : tableaux, filtres, graphiques et exports",
            "En production · évolution continue",
            "Lire l'étude de cas",
            "projets/portail-bi",
            "success"),
        new ProjectUseCase(
            "02",
            "data",
            "Data & architecture",
            "POC d'architecture décisionnelle SSIS",
            "Valider la standardisation d'un flux ETL entre une source ERP de test et un data warehouse SQL Server",
            "Développeur et chef de projet du POC",
            new[] { "SSIS", "SQL Server", "C#", "ETL" },
            "POC opérationnel, extraction incrémentale, contrôles, rejets et journalisation",
            "POC professionnel terminé",
            "Lire l'étude de cas",
            "projets/poc-ssis",
            "accent"),
        new ProjectUseCase(
            "03",
            "delivery",
            "Delivery",
            "Chaîne de livraison CI/CD",
            "Automatiser les tests, les contrôles de sécurité, la création des images et le déploiement multi-environnements",
            "Conception et réalisation en autonomie",
            new[] { "GitHub Actions", "Docker", "Azure", "Trivy" },
            "Pipeline fonctionnel, traçable, observable et réversible",
            "Projet scolaire terminé",
            "Échanger sur ce projet",
            "#contact",
            "warning")
    };

    public const string CaseStudyEyebrow = "Preuve Front-End professionnelle";

    public const string CaseStudyTitle =
        "Concevoir un portail BI adapté aux besoins de chaque service";

    public const string CaseStudyIntro =
        "Un produit interne en production, développé de la demande métier à la livraison sans inventer de résultat chiffré";

    public const string CaseStudyContext =
        "Le portail remplace progressivement un ancien outil de reporting. Mon rôle a couvert la traduction des besoins, les maquettes, les composants Blazor responsive, l'intégration des données et la livraison.";

    public const string CaseStudyDisclosure =
        "Expérience professionnelle anonymisée : produit en production et résultats qualitatifs documentés, sans donnée industrielle ni gain chiffré exposé.";

    public static readonly IReadOnlyList<CaseStudyFact> CaseStudyFacts = new[]
    {
        new CaseStudyFact("Rôle", "Full-Stack à dominante Front-End"),
        new CaseStudyFact("État", "En production · évolution continue"),
        new CaseStudyFact("Socle", "Blazor · .NET · MudBlazor · SQL/LINQ")
    };

    public static readonly IReadOnlyList<CaseStudyPoint> CaseStudyPoints = new[]
    {
        new CaseStudyPoint(
            "Besoin",
            "Rétablir un accès opérationnel aux données après l'arrêt progressif de l'ancien reporting",
            "warning"),
        new CaseStudyPoint(
            "Réalisation",
            "Construire des écrans responsive, filtres avancés, graphiques et exports adaptés aux services",
            "accent"),
        new CaseStudyPoint(
            "Valeur vérifiée",
            "Plusieurs interfaces métier déployées dans un portail déjà en production",
            "success")
    };

    public static readonly IReadOnlyList<CaseStudyMetric> CaseStudyMetrics = new[]
    {
        new CaseStudyMetric("Tables", "détail manipulable", "filtres multiples et recherche", "accent"),
        new CaseStudyMetric("Charts", "lecture synthétique", "graphiques dynamiques par usage", "success"),
        new CaseStudyMetric("Exports", "continuité bureautique", "sorties PDF et CSV", "warning")
    };

    public static readonly IReadOnlyList<CaseStudyComparison> CaseStudyComparisons = new[]
    {
        new CaseStudyComparison(
            "Besoin",
            "Remplacer un reporting devenu indisponible",
            "La transformation de l'ERP impose de maintenir un accès fiable aux données utiles aux services.",
            "warning"),
        new CaseStudyComparison(
            "Livré",
            "Un portail en production et évolutif",
            "Plusieurs interfaces réunissent tableaux, graphiques, filtres, exports et droits d'accès en environnement .NET.",
            "success")
    };

    public const string ContactEyebrow = "Travailler ensemble";

    //public const string ContactTitle =
    //    "Un portfolio pensé comme point d'entrée vers des missions concrètes";

    //public const string ContactIntro =
    //    "La page permet de comprendre rapidement le profil, les preuves disponibles et le bon motif de contact";

    public const string ContactEmail = "fritp3@gmail.com";

    public const string ContactAvailability = "Ouvert aux missions .NET, applications métier, Front-End et data";

    public const string ContactGuidanceTitle = "Votre besoin métier";

    public const string ContactGuidanceBody =
        "Application .NET, portail de données, flux ETL, amélioration d'une interface métier ou cadrage d'une intégration technique.";

    public const string ContactFormTitle = "Décrire votre besoin";

    public const string ContactFormIntro =
        "Quelques lignes suffisent pour identifier le contexte, les contraintes et la meilleure suite à donner.";

    public const string ContactFormHelper =
        "Tous les champs sont obligatoires. Les erreurs restent textuelles, pas uniquement colorées.";

    public static readonly IReadOnlyList<ContactHighlight> ContactHighlights = new[]
    {
        new ContactHighlight("Front-End métier", "Concevoir des écrans Blazor lisibles, structurés et maintenables.", "accent"),
        new ContactHighlight("Data & ETL", "Relier les sources, contrôler les transformations et documenter les flux.", "success"),
        new ContactHighlight("Cadrage & delivery", "Clarifier le périmètre, les risques, les responsabilités et la livraison.", "warning")
    };
}

public sealed record ConceptSource(string Label, string Tone, string? Description = null);

public sealed record ConceptStep(string Step, string Label, string Tone, bool IsActive = false);

public sealed record ConceptDemo(string Marker, string Title, string Body, string Tone, bool IsHighlighted = false);

public sealed record HeroKpi(string Label, string Value, string Delta, string Caption, string Tone);

public sealed record ProductSource(string Label, string Type, string Description, string Status, string Tone);

public sealed record DecisionMetric(string Step, string Meta, string Title, string Description, string Tone);

public sealed record MotionState(string Key, string Step, string Title, string Description, string Tone, bool IsActive = false);

public sealed record ExpertiseSkill(
    string Code,
    string Category,
    string Title,
    string Description,
    IReadOnlyList<string> Tags,
    string Tone);

public sealed record MethodStep(
    string Step,
    string Meta,
    string Title,
    string Description,
    string Evidence,
    string Tone,
    bool IsHighlighted = false);

public sealed record ProjectFilter(string Key, string Label);

public sealed record ProjectUseCase(
    string Step,
    string CategoryKey,
    string Category,
    string Title,
    string Description,
    string Role,
    IReadOnlyList<string> Stack,
    string Impact,
    string Status,
    string ActionLabel,
    string ActionHref,
    string Tone);

public sealed record CaseStudyPoint(string Title, string Description, string Tone);

public sealed record CaseStudyFact(string Label, string Value);

public sealed record CaseStudyMetric(string Value, string Label, string Detail, string Tone);

public sealed record CaseStudyComparison(string Label, string Title, string Description, string Tone);

public sealed record ContactHighlight(string Title, string Description, string Tone);

public sealed record NavigationLink(string Label, string Href);
