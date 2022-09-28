import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { InfosolutionDetails } from './infosolution-details.model';

@Injectable({
  providedIn: 'root'
})
export class InfosolutionDetailsService {

  constructor(private http:HttpClient) { }

  formSolution:InfosolutionDetails = new InfosolutionDetails();
  readonly baseUrl = 'https://localhost:44382/Login/Login'
  list : InfosolutionDetails[];

  postInfoDetails(){
    return this.http.post(this.baseUrl, this.formSolution)
  }

  refreshList()
  {
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res =>this.list = res as InfosolutionDetails[])
  }

}
