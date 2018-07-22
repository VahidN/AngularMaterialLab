import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { SharedModule } from "../shared/shared.module";
import { MainContentComponent } from "./components/main-content/main-content.component";
import { NewContactDialogComponent } from "./components/new-contact-dialog/new-contact-dialog.component";
import { NotesComponent } from "./components/notes/notes.component";
import { PersianDatepickerComponent } from "./components/persian-datepicker/persian-datepicker.component";
import { SearchAutoCompleteComponent } from "./components/search-auto-complete/search-auto-complete.component";
import { SidenavComponent } from "./components/sidenav/sidenav.component";
import { ToolbarComponent } from "./components/toolbar/toolbar.component";
import { ContactManagerAppComponent } from "./contact-manager-app/contact-manager-app.component";
import { ContactManagerRoutingModule } from "./contact-manager-routing.module";

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ContactManagerRoutingModule
  ],
  declarations: [
    ContactManagerAppComponent,
    ToolbarComponent,
    MainContentComponent,
    SidenavComponent,
    NotesComponent,
    NewContactDialogComponent,
    PersianDatepickerComponent,
    SearchAutoCompleteComponent
  ],
  entryComponents: [
    NewContactDialogComponent,
    PersianDatepickerComponent,
    SearchAutoCompleteComponent
  ]
})
export class ContactManagerModule { }
