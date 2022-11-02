import { ModuleWithProviders } from "@angular/core";
import { Routes,RouterModule } from "@angular/router";
import { BalanceComponent } from "./balance/balance.component";
import { ErrorComponent } from "./error/error.component";
import { ExtractComponent } from "./extract/extract.component";
import { HomeComponent } from "./home/home.component";
import { OperationComponent } from "./operation/operation.component";
import { PinComponent } from "./pin/pin.component";
import { ReportComponent } from "./report/report.component";
import { UntilnexttimeComponent } from "./untilnexttime/untilnexttime.component";

const appRoutes:Routes=[
  {path:' ',redirectTo:'home'},
  {path:'home',component:HomeComponent},
  {path:'pin',component:PinComponent},
  {path:'extract',component:ExtractComponent},
  {path:'balance',component:BalanceComponent},
  {path:'operation',component:OperationComponent},
  {path:'report',component:ReportComponent},
  {path:'bye',component:UntilnexttimeComponent},
  {path:'error',component:ErrorComponent},
  {path:'**',component:HomeComponent},

];

export const appRoutingProviders: any[]=[];
export const routing: ModuleWithProviders<RouterModule>= RouterModule.forRoot(appRoutes);