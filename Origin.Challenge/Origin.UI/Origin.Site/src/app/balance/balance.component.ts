import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { cardDTO } from '../DTO/cardDTO';
import { cardService } from '../services/cardService';
import { operationService } from '../services/operationService';

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.scss']
})
export class BalanceComponent implements OnInit {
  
entity: cardDTO;


  constructor(cardService: cardService, private operationServ: operationService, private router: Router) {
    this.entity = cardService.card;

    this.operationServ.doBalance(this.entity).subscribe((response: any)=>{
      this.entity = response.data;
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
