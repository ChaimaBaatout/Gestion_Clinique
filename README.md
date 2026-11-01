# Gestion Clinique

Application web de gestion de clinique, réalisée avec ASP.NET Core MVC dans le cadre de mes études.

## Fonctionnalités

Pages de création, consultation, modification et suppression pour :

- les patients
- les médecins
- les rendez-vous
- les spécialités
- les horaires de travail
- les utilisateurs

## Technologies

- C#, ASP.NET Core MVC (.NET 5)
- Entity Framework Core et SQL Server LocalDB
- Bootstrap et jQuery

## Limites actuelles

- Il n'y a pas de page de connexion ni de contrôle d'accès.
- Les mots de passe des utilisateurs ne sont pas chiffrés : ne pas utiliser de vraies données.
- Des modèles sont à corriger avant de compiler et de lancer le projet : `RendezVous` utilise un champ `id` qui n'existe pas, et certaines propriétés de `Patient` et `Specialite` s'appellent elles-mêmes.

## Lancer le projet

Une fois les modèles corrigés :

1. Ouvre `Gestion_Clinique.sln` dans Visual Studio.
2. Crée la base de données dans la console du Gestionnaire de package :

   ```powershell
   Update-Database
   ```

3. Lance l'application avec F5.