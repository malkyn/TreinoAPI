import { Component, OnInit } from '@angular/core';
import { InfosolutionDetailsService } from '../shared/infosolution-details.service';

@Component({
  selector: 'app-infosolution-details',
  templateUrl: './infosolution-details.component.html',
  styles: [
  ]
})
export class InfosolutionDetailsComponent implements OnInit {

  constructor(public service:InfosolutionDetailsService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

}
