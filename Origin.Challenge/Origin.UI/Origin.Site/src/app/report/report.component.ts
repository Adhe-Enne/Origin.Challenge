import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { cardDTO } from '../DTO/cardDTO';
import { movementDTO } from '../DTO/movementDTO';
import { cardService } from '../services/cardService';
import { operationService } from '../services/operationService';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})

export class ReportComponent implements OnInit {

  entities: Array<any> =[];
  showAlert: boolean=false;
  result: any;
  entity: any;

  constructor(private operationServ: operationService, cardServ: cardService, private router: Router) {
  this.entity = cardServ.card;
  this.operationServ.getMovements(this.entity.codeNumber, this.entity.pinNumber).subscribe(
    (response:any) => {
      if(response)
      {
        if(!response.hasError)
        {
          this.entities = response.data;
          if(!this.entities)
            this.showAlert = true;
        }
        else
        this.showAlert = true;
      }
      else
      this.showAlert = true;
    });
    

  }

  ngOnInit(): void {
    

  }

  ToBack(){
    this.router.navigate(['/operation']);
  }

  ToOut(){
    this.router.navigate(['/bye']);
  }
}
