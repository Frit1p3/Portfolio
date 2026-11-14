namespace Portfolio.Content;

public static class CaseStudyNavigationContent
{
    public static readonly IReadOnlyList<CaseStudyNavigationItem> Studies = new[]
    {
        new CaseStudyNavigationItem(
            "portail-bi",
            "Interface & usages",
            "Portail BI industriel",
            "Produit professionnel en production",
            "Concevoir des écrans Blazor qui rendent des données métier complexes lisibles et actionnables.",
            "projets/portail-bi"),
        new CaseStudyNavigationItem(
            "poc-ssis",
            "Data & industrialisation",
            "POC SSIS traçable",
            "Expérience professionnelle · POC terminé",
            "Structurer un flux ERP incrémental, contrôlé et documenté jusqu'au data warehouse.",
            "projets/poc-ssis"),
        new CaseStudyNavigationItem(
            "ci-cd-cesizen",
            "Delivery & fiabilité",
            "Chaîne CI/CD .NET",
            "Projet scolaire terminé",
            "Automatiser les contrôles, la livraison Azure, la supervision et le retour arrière.",
            "projets/ci-cd-cesizen")
    };
}

public sealed record CaseStudyNavigationItem(
    string Key,
    string Axis,
    string Title,
    string Status,
    string Description,
    string Href);
