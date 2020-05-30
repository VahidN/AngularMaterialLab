import { Component, OnInit } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";

import { User } from "../../models/user";
import { UserService } from "../../services/user.service";

@Component({
  selector: "app-new-contact-dialog",
  templateUrl: "./new-contact-dialog.component.html",
  styleUrls: ["./new-contact-dialog.component.css"],
})
export class NewContactDialogComponent implements OnInit {
  avatars = [
    "user1",
    "user2",
    "user3",
    "user4",
    "user5",
    "user6",
    "user7",
    "user8",
  ];
  user: User = {
    id: 0,
    birthDate: new Date(),
    name: "",
    avatar: "",
    bio: "",
    userNotes: null,
  };

  constructor(
    private dialogRef: MatDialogRef<NewContactDialogComponent>,
    private userService: UserService
  ) {}

  ngOnInit() {}

  save() {
    this.userService.addUser(this.user).subscribe((data) => {
      console.log("Saved user", data);
      this.dialogRef.close(data);
    });
  }

  dismiss() {
    this.dialogRef.close(null);
  }
}
