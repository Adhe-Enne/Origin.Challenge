import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms'; 
import { BalanceComponent } from './balance/balance.component';
import { routing,appRoutingProviders } from './app.routing';
import { HttpClientModule,HTTP_INTERCEPTORS } from '@angular/common/http';
import { PinComponent } from './pin/pin.component';
import { UntilnexttimeComponent } from './untilnexttime/untilnexttime.component';
import { OperationComponent } from './operation/operation.component';
import { ReportComponent } from './report/report.component';
import { ExtractComponent } from './extract/extract.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BalanceComponent,
    PinComponent,
    UntilnexttimeComponent,
    OperationComponent,
    ExtractComponent,
    ReportComponent
  ],
  imports: [
    BrowserModule, 
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    routing
  ],
  providers: [appRoutingProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
