# Mapping Figma vers code - landing animee

## Objectif

Ce document sert de pont entre la maquette Figma et la future implementation Blazor.
Il liste les composants Figma stabilises pour la landing animee, leur equivalent code
pressenti, leur role dans l'interface et les regles a respecter pendant le developpement.

Le but est d'eviter deux derives :

- reconstruire en code des blocs ponctuels non reutilisables ;
- reproduire les erreurs Figma corrigees, notamment le scaling manuel et les composants
  dessines hors design system.

## Source Figma

- Fichier : `Portfolio - Design System & Maquettes`
- URL : privee, conservee hors depot public.
- Page layouts : `03 - Layouts`
- Page prototype : `05 - Prototype`
- Page composants : `02 - Components`

Frames de reference :

- `Home / Desktop`
- `Home / Desktop - Animated Product Proof`
- `Home / Desktop - Concept Demo Landing`
- `Prototype / Concept Landing Motion / 01 - Grid wake`
- `Prototype / Concept Landing Motion / 06 - Demo takeover`

## Regles generales de transposition

- Preferer des composants Blazor reutilisables aux blocs HTML ponctuels.
- Garder les donnees de contenu dans des modeles ou fichiers dedies quand elles peuvent evoluer.
- Utiliser des tokens CSS pour couleurs, espacements, rayons, ombres et typographie.
- Ne pas encoder une taille obtenue par compression visuelle ; creer une variante CSS explicite.
- Ne pas animer un element si l'animation ne clarifie pas le concept.
- Respecter WCAG AA et anticiper les controles RGAA : focus visible, contraste, navigation clavier.

## Mapping composants Figma vers Blazor

| Figma | Composant Blazor pressenti | Dossier cible | Role |
| --- | --- | --- | --- |
| `Project Card / Source Compact` | `SourceCompactCard` | `Components/UI` | Carte compacte de source connectee dans la demo produit. |
| `Timeline / Decision Compact` | `DecisionTimelineCard` | `Components/UI` | Lecture decisionnelle courte associee a une metrique. |
| `KPI Card / Hero Compact` | `HeroKpiCard` | `Components/UI` | Preuve chiffree compacte dans le hero ou les sections de preuve. |
| `Timeline / Method Compact` | `MethodTimelineCard` | `Components/UI` | Etape de methode en carte horizontale compacte. |
| `Concept Source Chip` | `ConceptSourceChip` | `Components/UI` | Source de donnees dans la scene conceptuelle sombre. |
| `Concept Tab` | `ConceptTab` | `Components/UI` | Repere narratif de la sequence conceptuelle. |
| `Concept Demo Card` | `ConceptDemoCard` | `Components/UI` | Carte pedagogique sous la scene conceptuelle. |
| `Large product demo / Data explorer` | `ProductDemoPanel` | `Components/Sections` | Surface de demonstration applicative structuree. |
| `Hero / Full Concept Scene` | `ConceptHeroSection` | `Components/Sections` | Hero sombre DOSS-like avec schema conceptuel anime. |
| `Prototype / Concept Landing Motion` | `LandingMotionSequence` | `Components/Sections` | Orchestration des etats d'ouverture et de demonstration. |

## Composants de layout existants a prevoir

Ces composants existent deja en Figma dans le design system principal et devront etre
developpes comme base avant ou pendant la landing :

- `Header / Navigation` -> `HeaderNavigation`
- `Footer` -> `SiteFooter`
- `Button` -> `Button`
- `Badge` -> `Badge`
- `Project Card` -> `ProjectCard`
- `Case Study Block` -> `CaseStudyBlock`
- `Contact Form` -> `ContactForm`
- `Alert / Status` -> `AlertStatus`
- `Tabs` -> `Tabs`

## Structure de fichiers recommandee

```text
Portfolio/
  Components/
    Layout/
      HeaderNavigation.razor
      SiteFooter.razor
    UI/
      Badge.razor
      Button.razor
      ConceptDemoCard.razor
      ConceptSourceChip.razor
      ConceptTab.razor
      DecisionTimelineCard.razor
      HeroKpiCard.razor
      MethodTimelineCard.razor
      SourceCompactCard.razor
    Sections/
      ConceptHeroSection.razor
      ProductDemoPanel.razor
      LandingMotionSequence.razor
    CaseStudies/
  Content/
    landing/
      landing-content.cs
  Pages/
    Home.razor
  wwwroot/
    css/
      tokens/
      base/
      layout/
      components/
      pages/
```

## Donnees de contenu pressenties

Les composants suivants doivent recevoir leurs contenus depuis des modeles simples,
afin d'eviter de figer les textes dans le markup.

### `ConceptSourceChip`

```csharp
public sealed record ConceptSource(
    string Label,
    string Tone,
    string? Description = null
);
```

### `DecisionTimelineCard`

```csharp
public sealed record DecisionMetric(
    string Step,
    string Meta,
    string Title,
    string Description,
    string Tone
);
```

### `ConceptDemoCard`

```csharp
public sealed record ConceptDemo(
    string Title,
    string Body,
    string Tone,
    bool IsHighlighted
);
```

### `HeroKpiCard`

```csharp
public sealed record HeroKpi(
    string Label,
    string Value,
    string Delta,
    string Caption,
    string Tone
);
```

## Classes CSS pressenties

Les noms ci-dessous sont indicatifs et devront rester alignes avec les conventions finales.

```text
.concept-hero
.concept-hero__grid
.concept-hero__scene
.concept-stack
.concept-source-chip
.concept-tab
.concept-demo-card
.product-demo-panel
.source-compact-card
.decision-timeline-card
.hero-kpi-card
.method-timeline-card
.motion-sequence
.motion-state
```

## Animation web cible

La sequence Figma doit etre traduite en etats web progressifs, pas en animation
decorative continue.

Etats pressentis :

1. `grid-wake` : grille, signal et silhouette du systeme.
2. `message-reveal` : headline et promesse deviennent lisibles.
3. `system-assembly` : stack et couches se structurent.
4. `data-convergence` : sources connectees et rails de flux.
5. `concept-switch` : tabs conceptuelles et focus narratif.
6. `demo-takeover` : demo produit devient l'objet principal.

Regles :

- Prevoir `prefers-reduced-motion`.
- Ne jamais bloquer l'acces au contenu si l'animation ne se joue pas.
- Les etats doivent pouvoir etre controles ou rejoues.
- Les elements essentiels doivent exister dans le DOM avec une structure semantique claire.

## Priorite d'implementation

1. Initialiser le socle Blazor et les tokens CSS.
2. Developper les composants UI de base : `Button`, `Badge`, `HeaderNavigation`, `SiteFooter`.
3. Developper les nouveaux composants compacts issus de la landing animee.
4. Construire `ProductDemoPanel` en version statique.
5. Construire `ConceptHeroSection` en version statique.
6. Ajouter `LandingMotionSequence` avec animation progressive.
7. Tester responsive desktop, tablette et mobile.
8. Tester accessibilite : clavier, focus, contrastes, reduced motion.

## Points de vigilance

- La landing ne doit pas redevenir une partition texte a gauche / image a droite.
- Les schemas doivent expliquer une promesse metier, pas seulement decorer.
- Les KPI doivent toujours avoir un contexte.
- Les composants ne doivent pas etre dupliques sous forme de HTML ponctuel.
- Les animations doivent renforcer la comprehension, pas masquer l'information.
