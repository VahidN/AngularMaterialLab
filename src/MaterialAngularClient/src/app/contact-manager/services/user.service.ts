import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, throwError } from "rxjs";
import { catchError, map } from "rxjs/operators";

import { User } from "../models/user";

@Injectable({
  providedIn: "root"
})
export class UserService {

  private usersSource = new BehaviorSubject<User>(null);
  usersSourceChanges$ = this.usersSource.asObservable();

  constructor(private http: HttpClient) { }

  addUser(user: User): Observable<User> {
    const headers = new HttpHeaders({ "Content-Type": "application/json" });
    return this.http
      .post<User>("/api/users", user, { headers: headers }).pipe(
        map(response => {
          const addedUser = response || {} as User;
          this.notifyUsersSourceHasChanged(addedUser);
          return addedUser;
        }),
        catchError((error: HttpErrorResponse) => throwError(error))
      );
  }

  notifyUsersSourceHasChanged(user: User) {
    this.usersSource.next(user);
  }

  getAllUsersIncludeNotes(): Observable<User[]> {
    return this.http
      .get<User[]>("/api/users").pipe(
        map(response => response || []),
        catchError((error: HttpErrorResponse) => throwError(error))
      );
  }

  getUserIncludeNotes(id: number): Observable<User> {
    return this.http
      .get<User>(`/api/users/${id}`).pipe(
        map(response => response || {} as User),
        catchError((error: HttpErrorResponse) => throwError(error))
      );
  }

  searchUsers(term: string): Observable<User[]> {
    return this.http
      .get<User[]>(`/api/Typeahead/SearchUsers?term=${encodeURIComponent(term)}`)
      .pipe(
        map(response => response || []),
        catchError((error: HttpErrorResponse) => throwError(error))
      );
  }

  postBirthDate(date: string): Observable<string> {
    const headers = new HttpHeaders({ "Content-Type": "application/json" });
    return this.http
      .post<string>("/api/PersianDatepicker", { "BirthDate": date }, { headers: headers }).pipe(
        map(response => {
          const data = response || {} as string;
          return data;
        }),
        catchError((error: HttpErrorResponse) => throwError(error))
      );
  }
}
