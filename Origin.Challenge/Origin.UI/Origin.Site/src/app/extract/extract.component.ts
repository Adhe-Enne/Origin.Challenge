import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { cardDTO } from '../DTO/cardDTO';
import { cardService } from '../services/cardService';
import { operationService } from '../services/operationService';

@Component({
  selector: 'app-extract',
  templateUrl: './extract.component.html',
  styleUrls: ['./extract.component.scss']
})
export class ExtractComponent implements OnInit {


  withDrawValue: string='';
  binding: string='';
  entity: any;
  disableAcceptBtn = true;
  unShowPinField = true;
  colorModal: string= "success"
  modalMessage: string='';
  codeNumber?:string='';
  modalHead: string = '';

  @ViewChild('alertBtn') alertBtn!: ElementRef;

  constructor(private router: Router, private cardServ: cardService, private operationServ: operationService ) {
  
    
    
  }

  ngOnInit(): void {
    
  }

  addCode(data: any){

    if(data == "0" && this.binding.length == 0)
      return;
    
    this.withDrawValue += data;
    this.binding = "ARS$ " + this.withDrawValue;
    this.disableAcceptBtn= false;
  }

  clearBinding(){
    this.withDrawValue='';
    this.binding ='';
    this.disableAcceptBtn= true;
  }

  ToBack(){
    this.router.navigate(['/home']);
  }

  withDrawAmount(){

    this.entity = this.cardServ.card;

    this.entity.WithDraw = this.withDrawValue;
    this.operationServ.doWithDraw(this.entity).subscribe((response: any)=>{
    this.entity = response.data;

    if(response)
    {
        if(!response.hasError)
        {
         
          this.showModal('Extraccion Exitosa! Retiro ' +this.binding, "success" ,"¡EXITO!");
          this.clearBinding();
        }
        else
        {
          this.clearBinding();
          this.showModal(response.message, "warning","¡ATENCION!");
        }
    }
    else
      {
        this.clearBinding();
        this.showModal("ERROR AL CONECTARSE CON EL SERVIDOR, CONTACTE A SOPORTE","danger", "¡ERROR!");
      }
      debugger
    });

  }

  showModal(message: string, alertType: string, alertHead: string){

    this.colorModal = alertType;
    this.modalMessage = message;
    this.modalHead = alertHead;


    setTimeout(() =>{
      this.alertBtn.nativeElement.click();
    }, 100);
  
  }

 tryBalance(){

 }


}

