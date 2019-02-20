import { Component, OnInit } from '@angular/core';
import { Basic } from 'src/app/models/Basic';
import { ActivatedRoute } from '@angular/router';
import { ChannelService } from 'src/app/services/channel.service';

@Component({
  selector: 'app-channel',
  templateUrl: './channel.component.html',
  styleUrls: ['./channel.component.css']
})
export class ChannelComponent implements OnInit {

  serverId: number;
  channels: Basic[];

  constructor(private route: ActivatedRoute, private client: ChannelService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.serverId = params['id'];
      this.client.getServerChannels(this.serverId).subscribe(data => this.channels = data);
    })
  }

}
