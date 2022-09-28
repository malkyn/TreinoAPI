import { InfosolutionDetailsService } from './../../shared/infosolution-details.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-infosolution-detail-form',
  templateUrl: './infosolution-detail-form.component.html',
  styles: [
  ]
})
export class InfosolutionDetailFormComponent implements OnInit {

  constructor(public service:InfosolutionDetailsService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm)
  {
    this.service.postInfoDetails().subscribe(
      res => {

      },
      err =>{
        console.log(err);
      }
    )
  }

}
