import { Component, OnDestroy, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs";

import { User } from "../../models/user";
import { UserService } from "../../services/user.service";

@Component({
  selector: "app-main-content",
  templateUrl: "./main-content.component.html",
  styleUrls: ["./main-content.component.css"]
})
export class MainContentComponent implements OnInit, OnDestroy {

  private paramSubscription: Subscription;
  user: User;

  constructor(private route: ActivatedRoute, private userService: UserService) {
  }

  ngOnInit() {
    this.paramSubscription = this.route.params.subscribe(params => {
      this.user = null;

      const id = params["id"];
      if (!id) {
        return;
      }

      this.userService.getUserIncludeNotes(id)
        .subscribe(data => this.user = data);
    });
  }

  ngOnDestroy() {
    if (this.paramSubscription) {
      this.paramSubscription.unsubscribe();
    }
  }
}
