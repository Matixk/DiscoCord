import { Component, OnInit } from '@angular/core';
import { IServer } from "./server";
import { ServersService } from './servers.service';
import { ActivatedRoute } from '@angular/router';
import { Basic } from '../Basic';

@Component({
  selector: 'app-servers',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.css']
})
export class ServersComponent implements OnInit {
  errorMessage: string;
  servers: Basic[];
  id: number;

  _newServerName: string;
  set newServerName(value: string) {
    this._newServerName = value;
  }

  constructor(private readonly serversService: ServersService,
    private readonly route: ActivatedRoute) { }

  ngOnInit() {
    const param = this.route.snapshot.paramMap.get("id");
    if (param) {
      this.id = +param;
      this.getServer(this.id);
    } else {
      this.getServers();
    }
  }

  getServer(id: number) {
    this.serversService.getServer(id).subscribe(
      servers => this.servers[0] = servers,
      error => this.errorMessage = error
    )
  }

  getServers() {
    this.serversService.getServers().subscribe(
      servers => this.servers = servers,
      error => this.errorMessage = error
    )
  }

}
