import { Component, OnInit } from '@angular/core';
import { Basic } from 'src/app/models/Basic';
import { ActivatedRoute } from '@angular/router';

import { ChannelsService } from './channels.service';

@Component({
  selector: 'app-channels',
  templateUrl: './channels.component.html',
})
export class ChannelsComponent implements OnInit {
  visible: boolean;
  formVisible: string;

  serverId: number;
  channels: Basic[];

  constructor(private route: ActivatedRoute, private client: ChannelsService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.serverId = params['id'];
      this.client.getServerChannels(this.serverId).subscribe(data => this.channels = data);
    })
  }

  changeFormVisible() {
    this.visible = !this.visible;

    if (this.visible) {
      this.formVisible = "visible";
    } else {
        this.formVisible = "hidden";
    }
  }
}
