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
- L'heure de début des horaires de travail n'est ni enregistrée ni affichée : seule l'heure de fin l'est.
- Un médecin ou un patient qui a des rendez-vous ne peut pas être supprimé tant que ces rendez-vous existent.

## Lancer le projet

1. Ouvre `Gestion_Clinique.sln` dans Visual Studio.
2. Crée la base de données dans la console du Gestionnaire de package :

   ```powershell
   Update-Database
   ```

3. Lance l'application avec F5.