import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule} from '@angular/forms'

import { AppComponent } from './app.component';
import { InfosolutionDetailsComponent } from './infosolution-details/infosolution-details.component';
import { InfosolutionDetailFormComponent } from './infosolution-details/infosolution-detail-form/infosolution-detail-form.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    InfosolutionDetailsComponent,
    InfosolutionDetailFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
