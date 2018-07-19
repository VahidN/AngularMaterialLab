import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { MainContentComponent } from "./components/main-content/main-content.component";
import { ContactManagerAppComponent } from "./contact-manager-app/contact-manager-app.component";

const routes: Routes = [
  {
    path: "", component: ContactManagerAppComponent,
    children: [
      { path: ":id", component: MainContentComponent },
      { path: "", component: MainContentComponent }
    ]
  },
  { path: "**", redirectTo: "" }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContactManagerRoutingModule { }
