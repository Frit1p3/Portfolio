# Deploiement

## Objectif

Publier rapidement une version statique du portfolio afin de disposer d'une base
consultable par des clients, tout en gardant la suite Figma en chantier.

## Cible retenue

La cible de publication prioritaire est GitHub Pages :

- repository : `Frit1p3/Portfolio` ;
- branche de reference : `main` ;
- URL attendue : `https://frit1p3.github.io/Portfolio/`.

Le workflow `.github/workflows/pages.yml` publie le dossier statique genere par
Blazor WebAssembly a chaque push sur `main`.

## Points techniques

- La source conserve `<base href="/" />` pour le developpement local.
- Le workflow remplace le `base href` par `/Portfolio/` uniquement dans l'artefact
  publie.
- Le workflow copie `index.html` vers `404.html` pour conserver le fallback SPA sur
  GitHub Pages.
- Le fichier `.nojekyll` est cree dans l'artefact afin de servir correctement les
  fichiers Blazor commencant par `_`.

## Activation GitHub

Dans les parametres du repository GitHub :

1. ouvrir `Settings` ;
2. ouvrir `Pages` ;
3. choisir `Build and deployment` > `Source` > `GitHub Actions`.

Apres merge dans `main`, le workflow `Publish GitHub Pages` doit construire,
tester, publier puis exposer l'URL de deploiement.

## Verification avant publication

```powershell
dotnet test Portfolio.slnx
dotnet build Portfolio.slnx --configuration Release
```

Verifier aussi que l'adresse de contact publique dans `LandingContent.ContactEmail`
est l'adresse finale a afficher aux clients.
