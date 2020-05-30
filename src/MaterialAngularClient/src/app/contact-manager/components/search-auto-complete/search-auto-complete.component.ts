import { Component, OnDestroy, OnInit } from "@angular/core";
import { MatAutocompleteSelectedEvent } from "@angular/material/autocomplete";
import { MatDialogRef } from "@angular/material/dialog";
import { Subject, Subscription } from "rxjs";
import { debounceTime, distinctUntilChanged, finalize, switchMap, tap } from "rxjs/operators";

import { User } from "../../models/user";
import { UserService } from "../../services/user.service";

@Component({
  selector: "app-search-auto-complete",
  templateUrl: "./search-auto-complete.component.html",
  styleUrls: ["./search-auto-complete.component.css"],
})
export class SearchAutoCompleteComponent implements OnInit, OnDestroy {
  private modelChanged: Subject<string> = new Subject<string>();
  private dueTime = 300;
  private modelChangeSubscription: Subscription;
  private selectedUser: User = null;

  filteredUsers: User[] = [];
  isLoading = false;

  constructor(
    private userService: UserService,
    private dialogRef: MatDialogRef<SearchAutoCompleteComponent>
  ) {}

  ngOnInit() {
    this.modelChangeSubscription = this.modelChanged
      .pipe(
        debounceTime(this.dueTime),
        distinctUntilChanged(),
        tap(() => (this.isLoading = true)),
        switchMap((inputValue) =>
          this.userService
            .searchUsers(inputValue)
            .pipe(finalize(() => (this.isLoading = false)))
        )
      )
      .subscribe((users) => {
        this.filteredUsers = users;
      });
  }

  ngOnDestroy() {
    if (this.modelChangeSubscription) {
      this.modelChangeSubscription.unsubscribe();
    }
  }

  onSearchChange(value: string) {
    this.modelChanged.next(value);
  }

  displayFn(user: User) {
    if (user) {
      return user.name;
    }
  }

  onOptionSelected(event: MatAutocompleteSelectedEvent) {
    console.log("Selected user", event.option.value);
    this.selectedUser = event.option.value as User;
  }

  showUser() {
    if (this.selectedUser) {
      this.dialogRef.close(this.selectedUser);
    }
  }
}
