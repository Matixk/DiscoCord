import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Basic } from '../models/Basic';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: "root"
})
export class ChannelService {
    private adress = "http://localhost:5000/api";

    constructor(private client: HttpClient) { }
    
    getServerChannels(id: number): Observable<Basic[]> {
        const headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json; charset=utf-8');
        return this.client.get<Basic[]>(this.adress + '/servers/' + 2 + '/channels', { headers: headers });
   }
}