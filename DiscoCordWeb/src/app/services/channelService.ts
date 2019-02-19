import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Basic } from '../models/Basic';
import { Observable } from 'rxjs';

@Injectable()
export class ChannelService {
    private adress: 'localhost:54405/api';

    constructor(private client: HttpClient) { }
    
    getServerChannels(id: number): Observable<Basic[]> {
        return this.client.get<Basic[]>(this.adress + '/servers/' + id + '/channels');
   }
}