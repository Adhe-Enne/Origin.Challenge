import { HttpClient } from "@angular/common/http";
import { EventEmitter, Injectable, Input } from "@angular/core";
import { environment } from "src/environments/environment";
import { cardDTO } from "../DTO/cardDTO";

@Injectable({providedIn: 'root'})
export class operationService{
  
  private url = environment.apiUrl + 'Operation/' as string;
  constructor(private http: HttpClient) {

  }

  doBalance(entity: cardDTO): any {
    return this.http.post(`${this.url}balance`,entity);
  }

  doWithDraw(entity: cardDTO): any {
    return this.http.post(`${this.url}withdraw`,entity);
  }

  getMovements(codeNumber: string, pinNumber: string): any {
    return this.http.get(`${this.url}movements/${codeNumber}/${pinNumber}`);
  }
}