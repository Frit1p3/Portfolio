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

Le workflow peut publier uniquement si GitHub Pages est active sur le repository.

Option simple :

Dans les parametres du repository GitHub :

1. ouvrir `Settings` ;
2. ouvrir `Pages` ;
3. choisir `Build and deployment` > `Source` > `GitHub Actions`.

Option automatisee :

1. creer un Personal Access Token GitHub avec les droits Pages requis ;
2. l'ajouter au repository dans `Settings` > `Secrets and variables` > `Actions`
   sous le nom `PAGES_TOKEN` ;
3. relancer le workflow.

Quand `PAGES_TOKEN` existe, le workflow utilise `actions/configure-pages` avec
`enablement: true` pour tenter d'activer Pages automatiquement. Sans ce secret,
GitHub Pages doit etre active manuellement avant le premier deploiement.

Apres merge dans `main`, le workflow `Publish GitHub Pages` doit construire,
tester, publier puis exposer l'URL de deploiement.

## Verification avant publication

```powershell
dotnet test Portfolio.slnx
dotnet build Portfolio.slnx --configuration Release
```

Verifier aussi que l'adresse de contact publique dans `LandingContent.ContactEmail`
est l'adresse finale a afficher aux clients.
