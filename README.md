# Portfolio professionnel

Portfolio premium pense comme une application metier industrielle, concu pour demontrer une expertise Front-End .NET, UI/UX, data visualisation et interfaces B2B.

## Objectif

Donner a voir la proposition d'un developpeur Front-End .NET specialise dans la conception d'interfaces metier industrielles : dashboards BI, KPI, outils atelier, habilitations, interfacage ERP/GED et experiences utilisateur orientees performance operationnelle.

## Vision

Une interface professionnelle doit guider l'utilisateur, reduire la charge cognitive, mettre en valeur la donnee et accelerer la prise de decision.

## Stack

- .NET 10.
- Blazor WebAssembly.
- CSS Vanilla organise autour de tokens, couches base/layout/components/pages et composants reutilisables.
- bUnit pour les tests de composants.
- Playwright pour les audits navigateur actives a la demande.

Le portfolio est pense pour le desktop, la tablette et le mobile. Il reste une application de demonstration sans back-office : les contenus sont maintenus dans le depot, principalement via `Content/LandingContent.cs`.

Hebergement vise : GitHub Pages ou Azure Static Web Apps Free.

## Experience actuelle

La page d'accueil est composee comme une landing applicative, centree sur la preuve produit et la lisibilite metier :

- `ConceptHeroSection` : hero conceptuel sombre, tabs narratives, KPI et demonstration produit.
- `LandingMotionSequence` : sequence interactive en six etats, pilotable au clavier et compatible `prefers-reduced-motion`.
- `ProductDemoPanel` : surface de demonstration applicative avec sources, decisions et signal operationnel.
- `LandingMethodSection` : methode de conception en etapes.
- `LandingProjectsSection` : cas d'usage projets.
- `LandingCaseStudySection` : preuve par etude de cas, recit et metriques.
- `LandingContactSection` : appel a l'echange.
- `SiteFooter` : repere final et liens de navigation.

Les textes, metriques, etats de motion et listes de contenus sont centralises dans `LandingContent`.

## Commandes utiles

```powershell
dotnet test Portfolio.slnx
dotnet build Portfolio.slnx --configuration Release
dotnet run --urls http://127.0.0.1:5057
```

Pour activer les tests Playwright, lancer l'application puis definir l'URL locale :

```powershell
$env:PORTFOLIO_BASE_URL = "http://127.0.0.1:5057"
dotnet test Portfolio.slnx
```

Sans `PORTFOLIO_BASE_URL`, les tests Playwright sont ignores afin de garder une boucle de tests rapide. Les avertissements `NU1902` lies a AngleSharp peuvent apparaitre pendant les commandes .NET.

## Qualite

La suite de tests couvre :

- les composants UI et sections Blazor via bUnit ;
- les garde-fous de fondation, dont imports CSS et references aux tokens d'espacement ;
- la composition de la landing et ses contenus structurants ;
- l'interactivite de `LandingMotionSequence`, dont clavier, replay, auto-play et reduced motion ;
- les audits Playwright responsive, accessibilite, SEO minimal, erreurs console et erreurs page quand une URL de preview est fournie.

## Structure documentaire

- `docs/product/positionnement.md` : proposition de valeur, messages cles et angles de communication.
- `docs/product/personas.md` : publics cibles et attentes.
- `docs/architecture/choix-techniques.md` : decisions techniques initiales.
- `docs/architecture/strategie-tests.md` : strategie de tests unitaires, composants et navigateur.
- `docs/design-system/figma-code-mapping.md` : mapping entre les composants Figma et les composants Blazor.

Les fichiers de contexte de travail locaux sont exclus du depot public via `.gitignore`.

## Principes de conception

- Application metier avant site vitrine.
- Design System avant pages isolees.
- Contenu oriente impact metier.
- Accessibilite et responsive integres des le depart.
- Composants reutilisables et maintenables.
