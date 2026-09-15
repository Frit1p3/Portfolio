# Mapping Figma vers code - landing

## Objectif

Ce document sert de pont entre la maquette Figma et l'implementation Blazor.
Il liste les composants Figma stabilises pour la landing, leur equivalent code,
leur role dans l'interface et les regles a respecter pendant les evolutions.

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

| Figma | Composant Blazor | Dossier | Role |
| --- | --- | --- | --- |
| `Project Card / Source Compact` | `SourceCompactCard` | `Components/UI` | Carte compacte de source connectee dans la demo produit. |
| `Timeline / Decision Compact` | `DecisionTimelineCard` | `Components/UI` | Lecture decisionnelle courte associee a une metrique. |
| `KPI Card / Hero Compact` | `HeroKpiCard` | `Components/UI` | Preuve chiffree compacte dans le hero ou les sections de preuve. |
| `Concept Source Chip` | `ConceptSourceChip` | `Components/UI` | Source de donnees dans la scene conceptuelle sombre. |
| `Concept Tab` | `ConceptTab` | `Components/UI` | Repere narratif de la sequence conceptuelle. |
| `Concept Demo Card` | `ConceptDemoCard` | `Components/UI` | Carte pedagogique sous la scene conceptuelle. |
| `Large product demo / Data explorer` | `ProductDemoPanel` | `Components/Sections` | Surface de demonstration applicative structuree. |
| `Hero / Full Concept Scene` | `ConceptHeroSection` | `Components/Sections` | Hero sombre DOSS-like avec schema conceptuel anime. |
| `Prototype / Concept Landing Motion` | `LandingMotionSequence` | `Components/Sections` | Orchestration des etats d'ouverture et de demonstration. |
| `Prototype / Motion Controls` | `LandingMotionControls` | `Components/Sections` | Navigation precedente, suivante, replay et lecture auto. |
| `Prototype / Motion Stage` | `LandingMotionStage` | `Components/Sections` | Scene active associee a l'etat motion courant. |
| `Prototype / Motion Tabs` | `LandingMotionTabs` | `Components/Sections` | Liste de tabs accessible pilotant les etats motion. |
| `Method / Timeline` | `LandingMethodSection` | `Components/Sections` | Methode de conception en etapes depuis les donnees de contenu. |
| `Projects / Use Cases` | `LandingProjectsSection` | `Components/Sections` | Cas d'usage projets et preuves d'expertise. |
| `Case Study / Proof Block` | `LandingCaseStudySection` | `Components/Sections` | Recit de cas client, points de preuve et metriques. |
| `Contact / CTA` | `LandingContactSection` | `Components/Sections` | Bloc de contact final et appel a l'echange. |

## Composants de layout et UI transposes

Ces composants existent dans le design system principal et servent de base a la landing :

- `Header / Navigation` -> `HeaderNavigation`
- `Footer` -> `SiteFooter`
- `Button` -> `Button`
- `Badge` -> `Badge`

Les blocs projet, etude de cas et contact sont implementes comme sections dediees,
car ils portent une composition propre a la page d'accueil actuelle.

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
      SourceCompactCard.razor
    Sections/
      ConceptHeroSection.razor
      LandingCaseStudySection.razor
      LandingContactSection.razor
      LandingMethodSection.razor
      LandingMotionSequence.razor
      LandingMotionControls.razor
      LandingMotionStage.razor
      LandingMotionTabs.razor
      LandingProjectsSection.razor
      MotionTabKeyDown.cs
      ProductDemoPanel.razor
  Content/
    LandingContent.cs
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

## Donnees de contenu

Les composants suivants doivent recevoir leurs contenus depuis des modeles simples,
afin d'eviter de figer les textes dans le markup.

Les donnees de la landing sont centralisees dans `Content/LandingContent.cs`.

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
.motion-sequence
.motion-state
.method-section
.projects-section
.case-study-section
.contact-section
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

## Etat d'implementation

Le socle Blazor, les tokens CSS, les composants UI principaux, la landing animee,
les sections de contenu et les tests de non-regression sont implementes.

Les evolutions suivantes doivent conserver :

1. les contenus de landing dans `LandingContent` quand ils peuvent evoluer ;
2. des composants Blazor reutilisables plutot que du HTML ponctuel ;
3. des tests bUnit pour les nouveaux composants ou variantes significatives ;
4. des audits Playwright quand une modification touche le responsive, l'accessibilite,
   la motion ou les metadonnees navigateur.

## Points de vigilance

- La landing ne doit pas redevenir une partition texte a gauche / image a droite.
- Les schemas doivent expliquer une promesse metier, pas seulement decorer.
- Les KPI doivent toujours avoir un contexte.
- Les composants ne doivent pas etre dupliques sous forme de HTML ponctuel.
- Les animations doivent renforcer la comprehension, pas masquer l'information.
