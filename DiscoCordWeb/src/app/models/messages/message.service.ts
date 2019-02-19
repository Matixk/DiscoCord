import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

import { IMessage } from './message'

@Injectable({
  providedIn: "root"
})
export class MessageService {
  private messagesUrl = "http://localhost:54405/api/Messages";

  constructor(private http: HttpClient) { }

  getMessages(): Observable<IMessage[]> {
    return this.http.get<IMessage[]>(this.messagesUrl).pipe(
      tap(data => console.log(`All: ${JSON.stringify(data)}`)),
      catchError(this.handleError)
    );
  }

  getMessage(id: number): Observable<IMessage | undefined> {
    return this.getMessages().pipe(
      map((messages: IMessage[]) => messages.find(m => m.id === id))
    );
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: {err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
