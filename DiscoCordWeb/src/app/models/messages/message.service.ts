import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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
      tap(data)), catchError(this.handleError);
  }
}
