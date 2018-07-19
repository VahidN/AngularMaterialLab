import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
  { path: "contactmanager", loadChildren: "./contact-manager/contact-manager.module#ContactManagerModule" },
  { path: "", redirectTo: "contactmanager", pathMatch: "full" },
  { path: "**", redirectTo: "contactmanager" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
