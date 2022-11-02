import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { cardService } from '../services/cardService';

@Component({
  selector: 'app-pin',
  templateUrl: './pin.component.html',
  styleUrls: ['./pin.component.css']
})
export class PinComponent implements OnInit {

  entity: any;
  pinBinding: string='';
  disableAcceptBtn = true;
  unShowPinField = true;
  colorModal: string= "success"
  modalMessage: string='';
  modalHead: string = '';

  @ViewChild('alertBtn') alertBtn!: ElementRef;
  
  constructor(private router: Router, private cardServ: cardService) {
    this.entity = this.cardServ.card;
   }

  ngOnInit(): void {
  }

  
 addCode(data : any){

  
  if (this.pinBinding.length == 4)return

  this.pinBinding+=data;

  if (this.pinBinding.length == 4)
  {
    this.disableAcceptBtn = false;
    return;
  }


 }

 clearBinding(){
  this.disableAcceptBtn = true;
  this.pinBinding='';
  }

  ToBack(){
    this.router.navigate(['/home']);
  }

  validateCodeNumber(){

    this.entity.pinNumber = this.pinBinding;

    this.cardServ.validatePin(this.entity)
    .subscribe(
      (response:any) => {
        if(response)
        {
          if(!response.hasError)
          {
            this.cardServ.saveCard(response.data);
            this.router.navigate(['/operation']);
          }
          else
          this.showModal(response.message, "warning","¡ATENCION!");
        }
        else
        this.showModal("ERROR AL CONECTARSE CON EL SERVIDOR, CONTACTE A SOPORTE","danger", "¡ERROR!")
      }
    );
  }

  showModal(message: string, alertType: string, alertHead: string){

    this.colorModal = alertType;
    this.modalMessage = message;
    this.modalHead = alertHead;
    setTimeout(() =>{
      this.alertBtn.nativeElement.click();
    }, 100);
  
  }
}
