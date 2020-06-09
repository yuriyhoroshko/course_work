import { Component, OnInit } from '@angular/core';
import ApiService from '../services/apiService';
import { ServerModel } from '../models/server-model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-servers-list',
  templateUrl: './servers-list.component.html',
  styleUrls: ['./servers-list.component.less']
})
export class ServersListComponent implements OnInit {
  public servers: ServerModel[];

  constructor(private apiService: ApiService, private router: Router) { }

  async ngOnInit() {
    this.servers = await this.apiService.apiGet<ServerModel[]>('server/getServersList');
    console.log(this.servers);
  }

  public viewData = (counterName: string, serverId: number) => {
    this.router.navigate(['/chart', counterName, serverId]);
  }
}
