import { Component, OnInit } from "@angular/core";
import { MatDatepickerInputEvent } from "@angular/material";
import * as moment from "jalali-moment";

@Component({
  selector: "app-persian-datepicker",
  templateUrl: "./persian-datepicker.component.html",
  styleUrls: ["./persian-datepicker.component.css"]
})
export class PersianDatepickerComponent implements OnInit {

  startDate = moment("2017-01-01", "YYYY-MM-DD");
  minDate = moment.from("2017-10-02", "en"); // = moment('2017-10-02', 'YYYY-MM-DD');
  maxDate = moment.from("1396-07-29", "fa"); // = moment('1396-07-29', 'jYYYY-jMM-jDD');
  jsonDate = "2018-01-08T20:21:29.4674496";
  dateControl = this.jsonDate;

  myFilter = (d: moment.Moment): boolean => {
    const day: number = d.day();
    // Prevent Thursday and Friday from being selected.
    return day !== 5 && day !== 4;
  }

  constructor() { }

  ngOnInit() {
  }

  onInput(event: MatDatepickerInputEvent<moment.Moment>) {
    console.log("OnInput: ", event.value);
  }

  onChange(event: MatDatepickerInputEvent<moment.Moment>) {
    const x = moment(event.value).format("jYYYY/jMM/jDD");
    console.log("OnChange: ", x);
  }
}
