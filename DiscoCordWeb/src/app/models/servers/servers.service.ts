import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Basic } from '../Basic';
import { catchError, tap, map } from 'rxjs/operators';
import { IServer } from './server';

@Injectable({
  providedIn: 'root'
})
export class ServersService {
  private serversUrl = 'http://localhost:5000/api/Servers';

  constructor(private http: HttpClient) { }

  getServers(): Observable<Basic[]> {
    return this.http.get<Basic[]>(this.serversUrl).pipe(
      tap(data => console.log(`All: ${JSON.stringify(data)}`)),
      catchError(this.handleError)
    );
  }

  getServer(id: number): Observable<Basic> {
    return this.http.get<Basic>(`${this.serversUrl}/${id}`).pipe(
      tap(data => console.log(`Server: ${JSON.stringify(data)}`)),
      catchError(this.handleError)
    );
  }

  addServer(server: IServer): void {
    this.http.post(this.serversUrl, server);
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
