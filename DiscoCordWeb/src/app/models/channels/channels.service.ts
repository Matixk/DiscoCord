import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Basic } from '../Basic';

@Injectable({
    providedIn: "root"
})
export class ChannelsService {
    private adress = "http://localhost:5000/api";

    constructor(private client: HttpClient) { }

    getServerChannels(id: number): Observable<Basic[]> {
        const headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json; charset=utf-8');
        return this.client.get<Basic[]>(this.adress + '/servers/' + id + '/channels', { headers: headers });
   }
}