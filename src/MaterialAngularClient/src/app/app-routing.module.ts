import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
  { path: "contactmanager", loadChildren: () => import('./contact-manager/contact-manager.module').then(m => m.ContactManagerModule) },
  { path: "", redirectTo: "contactmanager", pathMatch: "full" },
  { path: "**", redirectTo: "contactmanager" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
