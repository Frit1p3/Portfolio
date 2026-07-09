# Strategie de tests

## Objectif

Eviter les regressions pendant la construction progressive du portfolio, sans ajouter
d'outil payant ni infrastructure lourde.

## Niveaux de test retenus

- Tests unitaires .NET pour les contenus, conventions et garde-fous de structure.
- Tests de composants Blazor avec bUnit pour chaque composant cree.
- Tests navigateur avec Playwright pour les parcours critiques et le responsive.

## Regle de contribution

Chaque nouveau composant Blazor doit etre accompagne d'un test bUnit adapte a son role.

Exemples attendus :

- rendu du contenu principal ;
- classes CSS structurantes ;
- attributs d'accessibilite quand le composant en expose ;
- variantes visuelles ou fonctionnelles importantes.

## Playwright

Les tests Playwright ciblent l'application lancee localement ou en preview.

La variable d'environnement `PORTFOLIO_BASE_URL` permet d'activer ces tests :

```powershell
$env:PORTFOLIO_BASE_URL = "https://localhost:5001"
dotnet test Portfolio.slnx
```

Sans cette variable, les tests Playwright restent non bloquants afin de permettre
l'execution rapide des tests unitaires et bUnit pendant le developpement courant.
