# Strategie de tests

## Objectif

Eviter les regressions pendant la construction progressive du portfolio, sans ajouter
d'outil payant ni infrastructure lourde.

## Niveaux de test retenus

- Tests unitaires .NET pour les contenus, conventions et garde-fous de structure.
- Tests de composants Blazor avec bUnit pour chaque composant cree.
- Tests navigateur avec Playwright pour les parcours critiques et le responsive.

## Tests de fondation

Les tests de fondation verifient les invariants qui doivent rester stables pendant
les refontes de composants :

- presence des contenus structurants dans `LandingContent` ;
- coherence des imports CSS ;
- references aux tokens d'espacement definies dans les fichiers de tokens ;
- conventions de fichiers locaux exclus du depot public.

## Regle de contribution

Chaque nouveau composant Blazor doit etre accompagne d'un test bUnit adapte a son role.

Exemples attendus :

- rendu du contenu principal ;
- classes CSS structurantes ;
- attributs d'accessibilite quand le composant en expose ;
- variantes visuelles ou fonctionnelles importantes.

Les sections de landing doivent aussi tester leur composition avec les donnees
centralisees : hero, sequence motion, methode, projets, etude de cas et contact.

## Playwright

Les tests Playwright ciblent l'application lancee localement ou en preview.

La variable d'environnement `PORTFOLIO_BASE_URL` permet d'activer ces tests :

```powershell
$env:PORTFOLIO_BASE_URL = "http://127.0.0.1:5057"
dotnet test Portfolio.slnx
```

Sans cette variable, les tests Playwright restent non bloquants afin de permettre
l'execution rapide des tests unitaires et bUnit pendant le developpement courant.

## Audits navigateur couverts

Les tests Playwright servent de filet de securite automatisable apres une QA
manuelle locale. Ils couvrent actuellement :

- le rendu du contenu cle de la page d'accueil ;
- la visibilite et l'ergonomie de `LandingMotionSequence` sur desktop, tablette et mobile ;
- les debordements horizontaux des sections de landing sur les viewports 1440, 1024, 768, 390 et 360 px ;
- la presence des landmarks, ancres et controles accessibles attendus ;
- la navigation clavier des tabs motion ;
- le comportement `prefers-reduced-motion`, avec lecture auto desactivee ;
- les metadonnees navigateur utiles : titre, description, langue, viewport et theme color ;
- l'absence d'erreurs console et d'erreurs page pendant le chargement.

## Commande de verification complete

```powershell
dotnet test Portfolio.slnx
dotnet build Portfolio.slnx --configuration Release
```

Pour verifier aussi Playwright :

```powershell
dotnet run --urls http://127.0.0.1:5057
$env:PORTFOLIO_BASE_URL = "http://127.0.0.1:5057"
dotnet test Portfolio.slnx
```
