import { Component, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { MediaChange, ObservableMedia } from "@angular/flex-layout";
import { MatSidenav } from "@angular/material";
import { Router } from "@angular/router";
import { Subscription } from "rxjs";

import { User } from "../../models/user";
import { UserService } from "../../services/user.service";

@Component({
  selector: "app-sidenav",
  templateUrl: "./sidenav.component.html",
  styleUrls: ["./sidenav.component.css"]
})
export class SidenavComponent implements OnInit, OnDestroy {

  dir = "ltr";
  isScreenSmall = false;
  isAlternateTheme = false;
  watcher: Subscription;
  users: User[] = [];
  subscription: Subscription | null = null;

  @ViewChild(MatSidenav) sidenav: MatSidenav;

  constructor(
    private media: ObservableMedia,
    private userService: UserService,
    private router: Router) {
    this.watcher = media.subscribe((change: MediaChange) => {
      this.isScreenSmall = change.mqAlias === "xs";
    });
  }

  ngOnInit() {
    this.userService.getAllUsersIncludeNotes()
      .subscribe(data => {
        this.users = data;
        if (data && data.length > 0 && this.router.url === "/contactmanager") {
          this.router.navigate(["/contactmanager", data[0].id]);
        }
      });

    this.router.events.subscribe(() => {
      if (this.isScreenSmall) {
        this.sidenav.close();
      }
    });

    this.subscription = this.userService.usersSourceChanges$.subscribe(user => {
      if (user) {
        this.users.push(user);
      }
    });
  }

  ngOnDestroy() {
    this.watcher.unsubscribe();
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  toggleTheme() {
    this.isAlternateTheme = !this.isAlternateTheme;
  }

  toggleDir() {
    this.dir = this.dir === "ltr" ? "rtl" : "ltr";
  }

}
