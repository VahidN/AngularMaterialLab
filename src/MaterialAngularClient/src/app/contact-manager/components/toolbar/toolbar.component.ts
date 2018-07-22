import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { MatDialog, MatSnackBar, MatSnackBarRef, SimpleSnackBar } from "@angular/material";
import { Router } from "@angular/router";

import { User } from "../../models/user";
import { NewContactDialogComponent } from "../new-contact-dialog/new-contact-dialog.component";
import { PersianDatepickerComponent } from "../persian-datepicker/persian-datepicker.component";
import { SearchAutoCompleteComponent } from "../search-auto-complete/search-auto-complete.component";

@Component({
  selector: "app-toolbar",
  templateUrl: "./toolbar.component.html",
  styleUrls: ["./toolbar.component.css"]
})
export class ToolbarComponent implements OnInit {

  @Output() toggleSidenav = new EventEmitter<void>();
  @Output() toggleTheme = new EventEmitter<void>();
  @Output() toggleDir = new EventEmitter<void>();

  constructor(
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private router: Router) { }

  ngOnInit() { }

  openAddContactDialog(): void {
    const dialogRef = this.dialog.open(NewContactDialogComponent, { width: "450px" });
    dialogRef.afterClosed().subscribe((result: User) => {
      console.log("The AddContact dialog was closed", result);
      if (result) {
        this.openSnackBar(`${result.name} contact has been added.`, "Navigate").onAction().subscribe(() => {
          this.router.navigate(["/contactmanager", result.id]);
        });
      }
    });
  }

  openPersianDatepickerDialog() {
    const dialogRef = this.dialog.open(PersianDatepickerComponent, { width: "650px" });
    dialogRef.afterClosed().subscribe(result => {
      console.log("The PersianDatepicker dialog was closed", result);
    });
  }

  openSearchDialog() {
    const dialogRef = this.dialog.open(SearchAutoCompleteComponent, { width: "650px" });
    dialogRef.afterClosed().subscribe((result: User) => {
      console.log("The SearchAutoComplete dialog was closed", result);
      if (result) {
        this.router.navigate(["/contactmanager", result.id]);
      }
    });
  }

  openSnackBar(message: string, action: string): MatSnackBarRef<SimpleSnackBar> {
    return this.snackBar.open(message, action, {
      duration: 5000,
    });
  }
}
