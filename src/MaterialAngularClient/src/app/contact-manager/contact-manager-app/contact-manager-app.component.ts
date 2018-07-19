import { Component, OnInit } from "@angular/core";
import { MatIconRegistry } from "@angular/material";
import { DomSanitizer } from "@angular/platform-browser";

@Component({
  selector: "app-contact-manager-app",
  templateUrl: "./contact-manager-app.component.html",
  styleUrls: ["./contact-manager-app.component.css"]
})
export class ContactManagerAppComponent implements OnInit {

  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    iconRegistry.addSvgIconSet(sanitizer.bypassSecurityTrustResourceUrl("/assets/avatars.svg"));
  }

  ngOnInit() {
  }

}
