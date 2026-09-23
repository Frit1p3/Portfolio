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

- `Home / Desktop` (`64:2`)
- `Home / Desktop - Animated Product Proof`
- `Home / Desktop - Concept Demo Landing` (`90:377`)
- `Prototype / Concept Landing Motion / 01 - Grid wake`
- `Prototype / Concept Landing Motion / 06 - Demo takeover`

Planche de composants :

- `02 - Components` (`2:3`)

Le noeud `90:377` est la direction visuelle principale de la landing publiee. Le noeud
`64:2` reste la reference fonctionnelle pour les sections de preuve, de contact et de
navigation qui ne sont pas encore transposees dans la direction conceptuelle sombre.

## Legende de parite

| Statut | Signification |
| --- | --- |
| `present` | Le besoin Figma est couvert par un composant ou une section reutilisable. |
| `partiel` | Le besoin existe, mais il manque du contenu, des variantes ou une composition importante. |
| `absent` | Aucun equivalent fonctionnel n'existe encore dans le code. |
| `ignore` | L'ecart est intentionnel ou ne sert pas la landing publique cible. |

## Inventaire des ecrans de reference

### `90:377` - Home / Desktop - Concept Demo Landing

| Element Figma | Equivalent code | Statut | Ecart restant |
| --- | --- | --- | --- |
| Header sombre et navigation | `HeaderNavigation` | `partiel` | Navigation plus courte, pas de lien Projets/Vision et CTA moins proche de la composition Figma. |
| Hero conceptuel plein ecran | `ConceptHeroSection` | `partiel` | Structure, sources et stack presentes ; la grille, le globe, les rails de flux et la composition spatiale restent simplifies. |
| Sources ERP, Atelier, BI, GED | `ConceptSourceChip` | `present` | Les quatre sources sont pilotees par `LandingContent`. |
| Stack UX / design system / KPI | markup de `ConceptHeroSection` | `present` | La representation est adaptee au responsive web plutot que reproduite en perspective stricte. |
| Tabs Cadrer, Structurer, Unifier, Animer, Decider, Documenter | `ConceptTab` et `LandingContent.ConceptSteps` | `partiel` | Quatre etapes seulement ; `Animer` et `Documenter` manquent et les micro-descriptions Figma ne sont pas modelisees. |
| Cartes Flux metier, Diagnostic KPI, Design system | `ConceptDemoCard` | `partiel` | Le composant existe et reagit au tab actif, mais le contenu actuel suit quatre etapes et n'a pas la section Modules distincte. |
| Sequence motion en six etats | `LandingMotionSequence` et sous-composants | `present` | Les six etats pilotent le hero, la scene conceptuelle et la demo produit. Les controles, le responsive, l'accessibilite et `prefers-reduced-motion` sont couverts. |
| Large product demo / Data explorer | `ProductDemoPanel` | `partiel` | Surface produit presente ; navigation laterale, cartographie libre et densite du data explorer Figma restent a rapprocher. |
| Section Concept Demonstrations / Modules | cartes integrees au hero | `partiel` | Les cartes existent, mais pas comme section claire apres la demonstration produit. |
| CTA final sombre | `LandingContactSection` | `partiel` | Passage a l'action couvert plus bas, avec une composition differente et sans CTA intermediaire dedie. |

### `64:2` - Home / Desktop

| Element Figma | Equivalent code | Statut | Ecart restant |
| --- | --- | --- | --- |
| Header complet | `HeaderNavigation` | `present` | Marque, lien d'evitement, navigation vers les sections disponibles et CTA Contact sont couverts. |
| Hero clair classique | `ConceptHeroSection` | `ignore` | Divergence intentionnelle : la landing publiee retient le hero conceptuel de `90:377`. |
| Panneau de KPI hero | `HeroKpiCard` dans `ConceptHeroSection` | `partiel` | Trois KPI contextualises existent, sans reprendre le panneau lateral clair de `64:2`. |
| Expertise en trois skill cards | `LandingExpertiseSection`, `SkillCard` | `present` | UX metier, Front-End .NET et Data & KPI sont pilotes par `LandingContent`, avec tags et variantes de ton. |
| Methode / timeline | `LandingMethodSection` | `present` | Trois etapes enrichies avec meta, preuve de sortie, fil conducteur et mise en avant de la conception. |
| Filtres de projets | aucun equivalent | `absent` | Aucun controle de filtrage ni etat actif pour les familles de projets. |
| Project cards riches | cartes internes de `LandingProjectsSection` | `partiel` | Les cas d'usage existent, sans visuel, role, stack, statut et action secondaire de la carte Figma. |
| Case Study Block / Homepage Proof | `LandingCaseStudySection` | `partiel` | Recit, points et metriques presents ; tags, mockup, comparaison et hierarchie Figma manquent. |
| Alert / Status de materialite | aucun equivalent | `absent` | Le bandeau de contexte et son composant generique ne sont pas implementes. |
| Contact Panel / Guidance | highlights de `LandingContactSection` | `partiel` | Les modes de collaboration couvrent l'intention, mais pas le panneau de recommandations structure. |
| Contact Form / Homepage Wide | aucun equivalent | `absent` | Pas de champs, validation, etats erreur/succes ni strategie d'envoi. |
| Footer / Layout Wide | `SiteFooter` | `present` | Identite, navigation, disponibilite, contact, copyright et retour en haut sont couverts. |

## Inventaire du design system `2:3`

| Composant Figma | Equivalent code | Statut | Decision |
| --- | --- | --- | --- |
| Button | `Button` | `present` | Conserver le composant et etendre ses variantes uniquement au besoin. |
| Badge | `Badge` | `present` | Conserver les tons existants. |
| KPI Card / Hero Compact | `HeroKpiCard` | `present` | Couverture suffisante pour la landing actuelle. |
| Project Card / Source Compact | `SourceCompactCard` | `present` | Utilise dans la demonstration produit. |
| Section Header | `SectionHeader` | `present` | Structure partagee, largeurs explicites, alignement start/center et contenu additionnel optionnel. |
| Header / Navigation | `HeaderNavigation` | `present` | Ancres reelles, CTA Contact, lien d'evitement et navigation mobile en grille. |
| Footer / Layout Wide | `SiteFooter` | `present` | Composition en colonnes responsive avec navigation et zone de contact. |
| Link | liens HTML et liens internes a `Button` | `partiel` | Formaliser seulement si plusieurs variantes de lien deviennent necessaires. |
| Skill Card | `SkillCard` | `present` | Code, categorie, titre, description, tags et ton sont configurables. |
| Project Card | cartes internes de `LandingProjectsSection` | `partiel` | Extraire une carte reutilisable lors de la parite projets. |
| Timeline | `LandingMethodSection`, `DecisionTimelineCard` | `present` | Les deux timelines specialisees couvrent leurs usages sans abstraction generique prematuree. |
| Tabs | `ConceptTab`, `LandingMotionTabs` | `partiel` | Les tabs conceptuels sont accessibles ; les filtres projets restent absents. |
| Accordion | aucun equivalent | `ignore` | Aucun parcours actuel ne justifie encore un accordion. |
| Alert / Status | aucun equivalent | `absent` | A introduire avec le bandeau de materialite, pas comme composant isole. |
| Contact Panel | highlights de `LandingContactSection` | `partiel` | Recomposer avec la guidance Figma. |
| Contact Form | aucun equivalent | `absent` | Necessite validation accessible et decision sur le transport du message. |
| Case Study Block | `LandingCaseStudySection` | `partiel` | Extraire les sous-composants seulement si une seconde etude de cas les reutilise. |

## Ordre d'implementation issu de l'inventaire

Les travaux restent decoupes en branches courtes depuis `develop`. Chaque branche doit
conserver la landing publiable et ses ancres existantes.

| Ordre | Branche | Perimetre | Definition of Done |
| --- | --- | --- | --- |
| 1 | `LandingHeroMotionParity` | Relier les six etats du storyboard `2:6` a la scene du hero. | Grille, message, assemblage, convergence, switch et takeover visibles ; controles, responsive et reduced motion conserves. |
| 2 | `LandingSectionHeaderParity` | Creer un `SectionHeader` reutilisable et migrer methode, projets, case study et contact. | Une seule structure d'en-tete, variantes d'alignement explicites, tests bUnit et rendu responsive stable. |
| 3 | `LandingHeaderFooterParity` | Completer les ancres du header et transformer le footer minimal en navigation utile. | Toutes les ancres pointent vers un id reel, focus visible, CTA contact et footer responsive. |
| 4 | `LandingExpertiseMethodParity` | Ajouter les trois skill cards et enrichir la timeline methode observees dans `64:2`. | Contenu data-driven, composant `SkillCard`, timeline en trois etapes, navigation et responsive couverts. |
| 5 | `LandingProjectsCaseStudyParity` | Creer les project cards riches, les filtres accessibles et completer la preuve projet. | Filtrage clavier, cartes reutilisables, tags/role/stack/impact, case study enrichi et bandeau de materialite. |
| 6 | `LandingContactFormParity` | Recomposer la guidance et ajouter un formulaire accessible. | Validation textuelle, etats erreur/succes et strategie d'envoi documentee sans exposer de secret client. |
| 7 | `LandingConceptDemoParity` | Completer les six tabs, isoler Modules et rapprocher le data explorer de `90:377`. | Six etapes coherentes, relation tab/carte conservee, section Modules distincte et demo responsive. |
| 8 | `LandingVisualParityQa` | Audit visuel, responsive, accessibilite, performance et nettoyage CSS. | Tests Playwright desktop/tablette/mobile, console propre, contraste et reduced motion verifies. |

La premiere branche est volontairement structurelle : `SectionHeader` supprime une
duplication deja visible dans quatre sections et fournit la fondation attendue par les
branches expertise, projets et contact.

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
| `Section Header` | `SectionHeader` | `Components/UI` | En-tete reutilisable avec eyebrow, titre identifie, introduction et contenu optionnel. |
| `Skill Card` | `SkillCard` | `Components/UI` | Domaine d'expertise avec categorie, description et tags associes. |
| `Header / Navigation` | `HeaderNavigation` | `Components/Layout` | Navigation principale, lien d'evitement et CTA de contact. |
| `Footer / Layout Wide` | `SiteFooter` | `Components/Layout` | Navigation de fin de page, disponibilite et acces direct au contact. |
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
