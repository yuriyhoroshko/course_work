import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ServersListComponent } from './servers-list/servers-list.component';
import { CounterChartComponent } from './counter-chart/counter-chart.component';


const routes: Routes = [
  {
    component: LoginComponent,
    path: 'login'
  },
  {
    component: LoginComponent,
    path: 'register'
  },
  {
    component: ServersListComponent,
    path: ''
  },
  {
    component: CounterChartComponent,
    path: 'chart/:counterName/:serverId'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
