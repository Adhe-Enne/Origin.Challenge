import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { identity } from 'rxjs';
import { apiResult } from '../DTO/apiResult';
import { cardService } from '../services/cardService';
import { Router } from '@angular/router';
import { cardDTO } from '../DTO/cardDTO';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  formModal: any;
  disableAcceptBtn = true;
  binding:  string = '';
  maxLenghtChar = 17;
  apiresponse? : apiResult; 
  codeNumber: string = '';
  pinBinding: string= '';
  colorModal: string= "success"
  modalMessage: string='';
  modalHead: string = '';
  
  @ViewChild('alertBtn') alertBtn!: ElementRef;

  constructor(private router: Router, private cardServi: cardService) { }

  ngOnInit(): void {
  }

 showValue(){
  console.log(this.binding);
  }

 addCode(data : any){

  if (this.codeNumber.length == 16)
  {
    return;
  }

  this.binding+=data;
  this.codeNumber+=data;
  
  if( this.codeNumber.length % 4  === 0 )
      if (this.binding.length < 16)
        this.binding+="-";

        
  if (this.codeNumber.length == 16)
  {
    this.disableAcceptBtn = false;
    return;
  }

 }

 clearBinding(){

  console.log(this.codeNumber);
  this.codeNumber='';
   this.binding='';
   this.disableAcceptBtn = true;
  }

  async validateCodeNumber(){
   
    this.cardServi.getCard(this.codeNumber).subscribe(
      (response:any) => {
        if(response)
        {
          if(!response.hasError)
          {
            //debugger
            this.cardServi.saveCode(this.codeNumber);
            this.router.navigate(['/pin']);
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
