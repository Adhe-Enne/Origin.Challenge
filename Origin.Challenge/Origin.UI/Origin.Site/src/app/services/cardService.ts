import { HttpClient } from "@angular/common/http";
import { EventEmitter, Injectable, Input } from "@angular/core";
import { environment } from "src/environments/environment";
import { cardDTO } from "../DTO/cardDTO";

@Injectable({providedIn: 'root'})
export class cardService {

  private url = environment.apiUrl + 'Card/' as string;
  
  public card: cardDTO = new cardDTO();

  constructor(private http: HttpClient) {

   }

  saveCode(code: string){
  this.card.codeNumber = code;
  }
  savePin(pin: string){
    this.card.pinNumber = pin;
  }
  saveCard(card: cardDTO){
    this.card = card;
  }
  getCard(codeNumber: string): any {
    return this.http.get(`${this.url}${codeNumber}`);
  }

  validatePin(entity: any): any {
    return this.http.post(`${this.url}pin`,entity);
  }

}
