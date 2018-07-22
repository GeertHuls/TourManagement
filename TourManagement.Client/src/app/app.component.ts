import {  } from "automapper-ts";
import {Component, OnInit} from '@angular/core';
import {OpenIdConnectService} from './shared/open-id-connect.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Pluralsight Demo';

  constructor(private openIdConnectService: OpenIdConnectService) {
  }
}
