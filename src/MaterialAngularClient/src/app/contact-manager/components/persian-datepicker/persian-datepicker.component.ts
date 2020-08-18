import { Component, OnInit } from "@angular/core";
import { MatDatepickerInputEvent } from "@angular/material/datepicker/datepicker-input-base";
import * as jalaliMoment from "jalali-moment";

import { UserService } from "../../services/user.service";

@Component({
  selector: "app-persian-datepicker",
  templateUrl: "./persian-datepicker.component.html",
  styleUrls: ["./persian-datepicker.component.css"],
})
export class PersianDatepickerComponent implements OnInit {
  startDate: string;
  minDate: string;
  maxDate: string;
  jsonDate: string;
  dateControl: string;

  myFilter = (d: jalaliMoment.Moment): boolean => {
    const day: number = d.day();
    // Prevent Thursday and Friday from being selected.
    return day !== 5 && day !== 4;
  };

  constructor(private userService: UserService) {
    jalaliMoment.locale("fa", { useGregorianParser: true });

    this.jsonDate = jalaliMoment("2018-01-08T20:21:29.4674496").format();
    this.dateControl = this.jsonDate;

    this.startDate = jalaliMoment("2017-01-01").format("YYYY/MM/DD");
    this.minDate = jalaliMoment("2017-10-02").format("YYYY/MM/DD");

    this.maxDate = jalaliMoment("1396-07-29", "jYYYY-jMM-jDD", "fa").format(
      "YYYY/MM/DD"
    );
    console.log("dates", {
      startDate: this.startDate,
      minDate: this.minDate,
      maxDate: this.maxDate,
      jsonDate: this.jsonDate,
      dateControl: this.dateControl,
    });
  }

  ngOnInit() {}

  onInput(event: MatDatepickerInputEvent<jalaliMoment.Moment>) {
    console.log("OnInput: ", event.value);
    this.postDateValue(event.value.utc(true).toJSON());
  }

  onChange(event: MatDatepickerInputEvent<jalaliMoment.Moment>) {
    const x = jalaliMoment(event.value).format("jYYYY/jMM/jDD");
    console.log("OnChange: ", x);
    this.postDateValue(event.value.utc(true).toJSON());
  }

  postDate() {
    if (this.dateControl) {
      console.log(`this.dateControl: ${this.dateControl}`);
      const date = jalaliMoment.from(this.dateControl, "en").utc(true).toJSON();
      console.log(`date: ${date}`);
      this.postDateValue(date);
    }
  }

  private postDateValue(value: string) {
    console.log(`Posting ${value} to server.`);
    this.userService
      .postBirthDate(value)
      .subscribe((data) => console.log(`Server's response: ${data}.`));
  }
}
