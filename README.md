Angular Material Lab
==========================

This project is a collection of tips and tricks about how to use an Angular Material (6+) app with an ASP.NET Core app and includes:

- How to manage Angular Material's dependencies using `shared\material.module.ts` file.
- How to use `@angular/flex-layout`.
- How to work with modal dialogs.
- How to work with form fields and validations.
- How to work with data tables including paging, sorting and filtering.
- How to create a custom template and change it dynamically.
- How to change the datepicker's format to Persian.

How to run it
-------------

- Update all of the outdated global dependencies using the `npm update -g` command.
- Install the `Angular-CLI`.
- Now open the `src\MaterialAngularClient` folder and then run the following files:
  - _0-restore.bat
  - _2-ng-build-dev.bat

- Then open the `src\MaterialAspNetCoreBackend\MaterialAspNetCoreBackend.WebApp` folder and then run the following files:
  - _0-restore.bat
  - _1-dotnet_run.bat

- Now to browse the application, navigate to https://localhost:5001/
