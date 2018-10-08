import { Component, OnInit } from "@angular/core";
import { MatDatepickerInputEvent } from "@angular/material";
import * as moment from "jalali-moment";

import { UserService } from "../../services/user.service";

@Component({
  selector: "app-persian-datepicker",
  templateUrl: "./persian-datepicker.component.html",
  styleUrls: ["./persian-datepicker.component.css"]
})
export class PersianDatepickerComponent implements OnInit {

  startDate = moment("2017-01-01", "YYYY-MM-DD"); // = moment.from("2017-01-01", "en");
  minDate = moment.from("2017-10-02", "en"); // = moment('2017-10-02', 'YYYY-MM-DD');
  maxDate = moment.from("1396-07-29", "fa"); // = moment('1396-07-29', 'jYYYY-jMM-jDD');
  jsonDate = "2018-01-08T20:21:29.4674496";
  dateControl = this.jsonDate;

  myFilter = (d: moment.Moment): boolean => {
    const day: number = d.day();
    // Prevent Thursday and Friday from being selected.
    return day !== 5 && day !== 4;
  }

  constructor(private userService: UserService) { }

  ngOnInit() {
  }

  onInput(event: MatDatepickerInputEvent<moment.Moment>) {
    console.log("OnInput: ", event.value);
    this.postDateValue(event.value.utc(true).toJSON());
  }

  onChange(event: MatDatepickerInputEvent<moment.Moment>) {
    const x = moment(event.value).format("jYYYY/jMM/jDD");
    console.log("OnChange: ", x);
    this.postDateValue(event.value.utc(true).toJSON());
  }

  postDate() {
    if (this.dateControl) {
      console.log(`this.dateControl: ${this.dateControl}`);
      const date = moment.from(this.dateControl, "en").utc(true).toJSON();
      console.log(`date: ${date}`);
      this.postDateValue(date);
    }
  }

  private postDateValue(value: string) {
    console.log(`Posting ${value} to server.`);
    this.userService.postBirthDate(value)
      .subscribe(data => console.log(`Server's response: ${data}.`));
  }
}
