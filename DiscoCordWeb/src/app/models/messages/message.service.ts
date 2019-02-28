import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

import { IMessage } from './message'

@Injectable({
  providedIn: "root"
})
export class MessageService {
  private messagesUrl = "http://localhost:5000/api/Messages";

  constructor(private http: HttpClient) { }

  getMessages(id: number): Observable<IMessage[]> {
    return this.http.get<IMessage[]>(`${this.messagesUrl}/channel/${id}`).pipe(
      tap(data => console.log(`All: ${JSON.stringify(data)}`)),
      catchError(this.handleError)
    );
  }

  getMessage(id: number): Observable<IMessage | undefined> {
    return this.http.get<IMessage>(`${this.messagesUrl}/${id}`).pipe(
      tap(data => console.log(`All: ${JSON.stringify(data)}`)),
      catchError(this.handleError)
    );
  }

  sendMessage(channelId: number, messageContent: string): void {
    let data: FormData = new FormData();
    data.append("Content", messageContent);
    data.append("channelId", channelId.toString());
    this.http.post(this.messagesUrl, data);
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
