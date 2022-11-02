import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { cardService } from '../services/cardService';

@Component({
  selector: 'app-operation',
  templateUrl: './operation.component.html',
  styleUrls: ['./operation.component.scss']
})
export class OperationComponent implements OnInit {
  disableAcceptBtn = true;
  balance =false;
  withdraw=false;
  movement= false;
  ownerName?: string;
  constructor(private router: Router, cardService: cardService) {
    this.ownerName = cardService.card.owner;
   }

  ngOnInit(): void {
  }

  toBalance(){
    this.router.navigate(['/balance']);
  }

  toExtract(){
    this.router.navigate(['/extract']);
  }

  movements(){
    this.router.navigate(['/report']);
  }
}
