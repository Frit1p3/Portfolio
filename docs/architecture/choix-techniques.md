# Choix techniques initiaux

## Decision retenue

Le portfolio sera une application Blazor WebAssembly responsive desktop/mobile, sans back-office et sans outil payant obligatoire.

Le projet est un portfolio de demonstration : le contenu sera maintenu dans le depot sous forme de fichiers statiques et versionnes, plutot que pilote par un CMS ou une interface d'administration.

## Orientation front-end

- Blazor WebAssembly pour la structure applicative.
- CSS Vanilla pour le controle fin du design system.
- JavaScript uniquement lorsque necessaire pour des interactions specifiques.
- Composants reutilisables pour les elements UI recurrents.
- Contenus statiques ou semi-statiques, stockes dans le depot.
- Aucune dependance obligatoire a un service payant.

## Architecture cible

```text
Portfolio/
  Components/
    Layout/
    UI/
    Sections/
    CaseStudies/
  Pages/
  Content/
  wwwroot/
    css/
      tokens/
      base/
      layout/
      components/
      pages/
    images/
    icons/
  docs/
    product/
    architecture/
    design-system/
```

## Principes de code

- Modularite.
- Lisibilite.
- Separation des responsabilites.
- Composants orientes usage.
- Styles organises par fondations, layout, composants et pages.
- Documentation des decisions importantes.

## CSS

Le CSS doit etre structure autour de tokens : couleurs, espacements, typographies, rayons, ombres, borders et breakpoints.

Aucun style ponctuel ne doit etre ajoute sans raison claire. Les composants doivent utiliser les memes variables et conventions.

## Accessibilite

- Contrastes conformes WCAG AA.
- Navigation clavier.
- Etats focus visibles.
- Structure semantique HTML.
- Textes alternatifs pour les visuels utiles.
- Composants interactifs comprehensibles par les technologies d'assistance.
- Attention particuliere aux preconisations du RGAA comme critere de developpement et de verification.

## Performance

- Chargement rapide.
- Images optimisees.
- CSS limite et organise.
- Animations sobres.
- Aucun effet visuel qui degrade la lisibilite ou la fluidite.

## Hebergement cible

Options gratuits ou compatibles avec une stack sans outil payant :

- GitHub Pages comme option simple pour une publication statique.
- Azure Static Web Apps Free comme alternative si le workflow .NET/Blazor le justifie.

Azure App Service n'est pas prioritaire a ce stade, car le projet ne necessite ni serveur applicatif permanent, ni back-office.

