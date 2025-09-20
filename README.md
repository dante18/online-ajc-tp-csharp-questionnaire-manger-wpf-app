# online-ajc-tp-csharp-questionnaire-manger-wpf-app

## Objectif pédagogique
L’objectif de ce TP est de développer une application WPF en C# permettant de créer, gérer et sauvegarder des questionnaires de type « question-réponse ». Ce projet permettra de mettre en pratique :
- La conception d’interfaces graphiques avec WPF (XAML)
- L’utilisation de la programmation orientée objet (POO) en C#
- La gestion de collections dynamiques (ObservableCollection)
- L’accès aux données avec Entity Framework (Code First) et une base de données locale

## Énoncé
Vous devez concevoir une application WPF permettant de créer et gérer des questionnaires. L’application doit permettre les fonctionnalités suivantes :
- Gestion des questionnaires
  - Créer un nouveau questionnaire
  - Ouvrir un questionnaire existant depuis la base de données
  - Sauvegarder un questionnaire et ses questions dans la base

- Gestion des questions
  - Ajouter une question avec :
    - Un intitulé (texte de la question)
    - Jusqu’à quatre réponses possibles
    - L’indication de la réponse correcte
  - Modifier ou supprimer une question existante
    
- Interface utilisateur
  - Une fenêtre principale proposant :
    - La liste des questionnaires existant et l’ajout de nouveaux questionnaires
  - Une page secondaire proposant :
    - Une zone listant les questions du questionnaire sélectionné
    - Un formulaire pour ajouter/modifier une question
  - L’affichage doit être réactif : lorsqu’une question est ajoutée ou supprimée, la liste s’actualise automatiquement.
    
- Contrainte technique.
  - Behavior
  - Converter
  - Navigation
  - Style
  - Template
  - MVVM : non obligatoire cependant pénalité sur le barème de notation.
  - Code First
